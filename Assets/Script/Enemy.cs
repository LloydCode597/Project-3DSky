using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Vector3 startPos;

    [SerializeField]
    private Vector3 endPos;

    private Vector3 targetPos;

    void Start()
    {
        targetPos = endPos;
        transform.position = startPos;
    }

    void Update()
    {
        // Move to the target position.
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Did we reach the target position?
        // If so, change the target pos so that the enemy moves to the other point.
        if (transform.position == targetPos)
        {
            if (targetPos == startPos)
            {
                targetPos = endPos;
            }
            else if (targetPos == endPos)
            {
                targetPos = startPos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().GameOver();
        }
    }



}
