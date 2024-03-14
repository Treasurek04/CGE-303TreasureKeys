using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public AudioClip jumpSound;

    private Rigidbody2D rb;
    private AudioSource playerAudio;
    private bool isGrounded;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>(); // Initialize playerAudio

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    void Update()
    {
        // Get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Move the player horizontally
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Flip the player's sprite based on movement direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); //Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); //Facing left
        }
    }

    void Jump()
    {
        // Apply jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        // Play jump sound
        if (playerAudio && jumpSound)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f); // Play jump sound with volume 1.0f
        }
    }
}
