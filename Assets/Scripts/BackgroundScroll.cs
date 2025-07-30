using UnityEngine;

public class BackgroundLoop3D : MonoBehaviour
{
    public float scrollSpeed = 5f;

    private float backgroundWidth;
    private Vector3 startPosition;

    void Start()
    {
        // Store the starting position
        startPosition = transform.position;

        // Get the actual width in world units from Renderer bounds (accounts for scale)
        backgroundWidth = GetComponent<Renderer>().bounds.size.x;

        Debug.Log("Calculated background width: " + backgroundWidth);
    }

    void Update()
    {
        // Move background left
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Reset position once moved full width to the left
        if (transform.position.x <= startPosition.x - backgroundWidth)
        {
            transform.position = startPosition;
        }
    }
}
