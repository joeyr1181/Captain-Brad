using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;

    public AudioClip crashSound;
    private AudioSource playerAudio;

    public float flyForce = 50f;
    public float gravityModifier = 5f;

    public bool gameOver = false;

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

    private IEnumerator FreezeAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerAnim.speed = 0f; // Freeze the animation
    }

}
