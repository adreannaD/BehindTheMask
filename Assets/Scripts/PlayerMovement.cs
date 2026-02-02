using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;
    public float coyoteTime = 0.15f;
    public float jumpBufferTime = 0.15f;

    private Rigidbody2D rb;
    private bool isGrounded;

    private float coyoteCounter;
    private float jumpBufferCounter;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement using new Input System
        float move = 0f;
        if (Keyboard.current.aKey.isPressed) move -= 1f;
        if (Keyboard.current.dKey.isPressed) move += 1f;

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // Update timers
        coyoteCounter = isGrounded ? coyoteTime : coyoteCounter - Time.deltaTime;
        jumpBufferCounter -= Time.deltaTime;

        // Queue jump input
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jumpBufferCounter = jumpBufferTime;
        }

        // Perform jump if buffered and allowed
        if (jumpBufferCounter > 0f && coyoteCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpBufferCounter = 0f;
            coyoteCounter = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}
