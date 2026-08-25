using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target; // The object the camera should follow

    [SerializeField]
    private Vector3 offset; // Position offset from the target

    [SerializeField]
    private float smoothing; // Speed of the smooth follow movement

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
