using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 2f; // normal patrol speed
    private float currentSpeed;
    private Rigidbody2D rb;
    private Transform player;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        MaskEvents.OnMaskChanged += OnMaskChanged;

        currentSpeed = baseSpeed;
    }

    void OnDestroy()
    {
        MaskEvents.OnMaskChanged -= OnMaskChanged;
    }

    void FixedUpdate()
    {
        // Move toward or away from player based on currentSpeed
        float dir = Mathf.Sign(player.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(dir * currentSpeed, rb.linearVelocity.y);
    }

    void OnMaskChanged(MaskType mask)
    {
        if (mask == MaskType.Fear)
            currentSpeed = -baseSpeed; // flee
        else if (mask == MaskType.None)
            currentSpeed = 0f; // stop moving when no mask is worn
        else
            currentSpeed = baseSpeed; // normal behavior for other masks
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Damage the player
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // 1 damage per touch
            }
        }
    }

}
