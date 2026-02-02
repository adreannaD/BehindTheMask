using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;         // Player max health
    public int currentHealth;

    private Vector3 respawnPoint;

    private Rigidbody2D rb;
    private PlayerMovement movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;

        // Set initial respawn point to starting position
        respawnPoint = transform.position;
    }

    // Call this to set a new respawn point (e.g., after checkpoints)
    public void SetRespawnPoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        // Reset health
        currentHealth = maxHealth;

        // Respawn at respawn point
        transform.position = respawnPoint;

        // Stop movement
        rb.linearVelocity = Vector2.zero;
    }
}
