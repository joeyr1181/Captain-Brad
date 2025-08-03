using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    // This script controls the behavior of an enemy in the game
    // The enemy moves left at a specified speed and plays an animation
    // Adjust the move speed and animation settings as needed
    public float moveSpeed = 5f;

    private Animator animator;

    // Start is called before the first frame update
    // Initialize the animator component and set the initial animation state
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.Play("Falling", 0, 0f);
        animator.SetBool("Looping", true);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy to the left
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Destroy when off-screen
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
