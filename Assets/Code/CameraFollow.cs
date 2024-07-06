using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothing speed for the camera movement
    private Vector3 offset; // Offset between the camera and player

    private void Start()
    {
        // Calculate and store the offset value by getting the distance between the player's position and camera's position
        offset = transform.position - player.position;
    }

    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerMovement>().transform;
        }
    }
    private void LateUpdate()
    {
        if (player != null)
        {
            // Define a target position based on the player's position and the original offset
            Vector3 targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

            // Smoothly interpolate between the camera's current position and the target position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // Apply the smoothed position to the camera
            transform.position = smoothedPosition;
        }
    }
}
