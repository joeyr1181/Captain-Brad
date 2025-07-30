using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public float moveSpeed = 5f;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.Play("Falling", 0, 0f);
        animator.SetBool("Looping", true);
    }

    void Update()
    {
        // Move the enemy to the left
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Destroy when off-screen (optional)
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
