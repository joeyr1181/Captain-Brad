using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    // This script moves the object to the left at a constant speed
    // It also destroys the object if it goes beyond a certain left boundary
    // Adjust the speed and left boundary as needed
    // The object should have a Rigidbody component if physics interactions are needed
    private float speed = 30f;
    private PlayerController playerControllerScript;
    private float leftBound = -15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Initialize the PlayerController script to check for game state
    // This is useful to prevent movement when the game is over
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object to the left at a constant speed
        if (playerControllerScript.gameOver == false) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // If the object goes beyond the left bound, destroy it
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
