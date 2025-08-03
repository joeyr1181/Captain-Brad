using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    // This script controls the player character's movement and interactions
    // It allows the player to fly upward by holding the spacebar
    // It also handles collision with obstacles, triggering game over state
    // Adjust the fly force and gravity modifier as needed
    private Rigidbody playerRb;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;

    public AudioClip crashSound;
    private AudioSource playerAudio;

    public float flyForce = 50f;
    public float gravityModifier = 5f;

    public bool gameOver = false;


    // Start is called before the first frame update
    // Initialize the Rigidbody, Animator, and AudioSource components
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Make gravity stronger for better falling effect
        Physics.gravity *= gravityModifier;

        // Freeze the slaute animation
        playerAnim.Play("Salute_Anim");
        StartCoroutine(FreezeAnimationAfterDelay(1.5f));
    }

    // Update is called once per frame
    // This method handles player input for flying and checks for game over state
    void Update()
    {
        if (gameOver) return;

        // Hold spacebar to fly upward
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * flyForce, ForceMode.Acceleration);
            playerAnim.SetBool("IsFlying", true);
        }
        else
        {
            playerAnim.SetBool("IsFlying", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressing Space");
        }
    }

    // This method is called when the player collides with an obstacle
    // It sets the game over state, plays the death animation, and triggers explosion effects
    // It also plays a crash sound effect
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound);
        }
    }

    // This coroutine freezes the player's animation after a specified delay
    private IEnumerator FreezeAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerAnim.speed = 0f; // Freeze the animation
    }

}
