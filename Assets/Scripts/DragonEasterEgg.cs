using UnityEngine;
using TMPro;

public class DragonEasterEgg : MonoBehaviour
{
    public TMP_Text messageText;
    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            messageText.gameObject.SetActive(true);
        }
    }
}
