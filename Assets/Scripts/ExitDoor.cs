using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    [Header("Final Level Settings")]
    public bool isFinalDoor = false;              // Check for Level 6
    public string finalMessage = "You were never the mask.\nThe mask was how the world chose to see you.";
    public Canvas messageCanvas;                  // Assign the Canvas containing the Text
    public TMP_Text messageText;                      // Assign the Text component in the Canvas

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (isFinalDoor)
        {
            // Show the final message
            if (messageCanvas != null && messageText != null)
            {
                messageText.text = finalMessage;
                messageCanvas.gameObject.SetActive(true);
            }

            // Stop the player from moving (Unity 6)
            var rb = other.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;

            var movement = other.GetComponent<PlayerMovement>();
            if (movement != null) movement.enabled = false;

            // Optional: pause game time
            // Time.timeScale = 0f;
        }
        else
        {
            // Normal behavior: load next scene in build order
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextScene < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(nextScene);
        }
    }
}
