using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;         // Player's transform
    public float smoothSpeed = 0.125f; // Adjust for smoother camera movement
    public Vector2 minPosition;      // Minimum x and y coordinates for the camera
    public Vector2 maxPosition;      // Maximum x and y coordinates for the camera

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Clamping the camera's position to stay within boundaries
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
