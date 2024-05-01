using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = .5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded;

    private Rigidbody2D rb;
    private float horizontalInput;

    public AudioClip jumpSound;
    private AudioSource playerAudio;

    private Animator animator; 

  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>(); // Initialize playerAudio
        animator = GetComponent<Animator>(); 

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }

        if (playerAudio != null && playerAudio.clip == jumpSound && playerAudio.isPlaying)
        {
            playerAudio.Stop();
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

        //set animator parameter xVelocityAbs to absolute value of x velocity
        animator.SetFloat("xVelocityAbs", Mathf.Abs(rb.velocity.x));
        
        //set animator parameter yVelocity to y velocity
        animator.SetFloat("yVelocity", rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //set animator parameter onGround to isGrounded
        animator.SetBool("onGround", isGrounded);

        // Flip the player's sprite based on movement direction
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0); //Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); //Facing left
        }
    }
    private bool hasJumped = false; 

    void Jump()
    {
        if (!hasJumped && isGrounded)
        {
            // Apply jump force
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Play jump sound
            if (playerAudio && jumpSound)
            {
                playerAudio.PlayOneShot(jumpSound, 1.0f); // Play jump sound with volume 1.0f
            }
            hasJumped = true; 
        }
    }
}
