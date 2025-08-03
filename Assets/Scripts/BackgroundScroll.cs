using UnityEngine;

public class BackgroundLoop3D : MonoBehaviour
{
    // This script scrolls a 3D background texture in a loop
    // Adjust the scroll speed as needed
    // The background should be a plane or similar object with a texture applied
    public float scrollSpeed = 5f;

    private float backgroundWidth;
    private Vector3 startPosition;

    // Start is called before the first frame update
    // Initialize the background position and calculate its width
    void Start()
    {
        // Store the starting position
        startPosition = transform.position;

        // Get the actual width in world units from Renderer bounds (accounts for scale)
        backgroundWidth = GetComponent<Renderer>().bounds.size.x;

        Debug.Log("Calculated background width: " + backgroundWidth);
    }

    // Update is called once per frame
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
