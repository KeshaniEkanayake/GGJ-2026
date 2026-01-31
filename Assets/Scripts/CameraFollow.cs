using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target to follow")]
    public Transform target;

    [Header("Offset from target")]
    public Vector3 offset = new Vector3(0f, 15f, -20f);

    [Header("Follow smoothness")]
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position (target + offset in world space)
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate to that position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Keep camera’s rotation fixed (don’t rotate with player)
        transform.rotation = Quaternion.Euler(25f, 45f, 0f);
        // You can tweak this to your preferred isometric angle.
    }
}
