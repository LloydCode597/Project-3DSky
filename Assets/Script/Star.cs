using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float bobHeight;
    [SerializeField]
    private float bobSpeed;
    private float startYPos;

    void Start()
    {
        startYPos = transform.position.y;
    }
    void Update()
    {
        // Rotate along the Y axis over time.
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        // Bob up and down over time.
        float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight / 2;
        Vector3 pos = transform.position;
        pos.y = startYPos + yOffset;
        transform.position = pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Add Score");
            Destroy(gameObject);
        }
    }


}
