using UnityEngine;

public class Collectible : MonoBehaviour
{

    // This script handles collectible items like coins
    // When the player collides with a collectible, it adds to the score and destroys the collectible
    // Adjust the score value as needed
    public int scoreValue = 1;

    // This method is called when another collider enters the trigger collider attached to this GameObject
    // It checks if the collider belongs to the player and updates the score
    // If so, it adds the score and destroys the collectible
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
