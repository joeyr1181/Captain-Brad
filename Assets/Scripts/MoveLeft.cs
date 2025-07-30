using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private PlayerController playerControllerScript;
    private float leftBound = -15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
