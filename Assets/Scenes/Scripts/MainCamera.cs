using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float smoothSpeed = 5f;
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
