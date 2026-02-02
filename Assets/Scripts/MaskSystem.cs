using UnityEngine;
using UnityEngine.InputSystem;

public enum MaskType
{
    None,
    Truth,
    Deception,
    Fear
}

public class MaskSystem : MonoBehaviour
{
    public MaskType currentMask = MaskType.None;

    public Sprite truthMask;
    public Sprite deceptionMask;
    public Sprite fearMask;

    private SpriteRenderer maskRenderer;

    void Awake()
    {
        maskRenderer = transform.Find("Mask").GetComponent<SpriteRenderer>();
        SetMask(MaskType.None); // start with no mask
    }

    void Update()
    {
        // New Input System keys
        if (Keyboard.current.digit0Key.wasPressedThisFrame)
            SetMask(MaskType.None);
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            SetMask(MaskType.Truth);
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            SetMask(MaskType.Deception);
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            SetMask(MaskType.Fear);
    }

    void SetMask(MaskType newMask)
    {
        currentMask = newMask;

        // Update sprite
        switch (currentMask)
        {
            case MaskType.None:
                maskRenderer.sprite = null; // hide the mask
                break;
            case MaskType.Truth:
                maskRenderer.sprite = truthMask;
                break;
            case MaskType.Deception:
                maskRenderer.sprite = deceptionMask;
                break;
            case MaskType.Fear:
                maskRenderer.sprite = fearMask;
                break;
        }

        // Notify world objects
        MaskEvents.OnMaskChanged?.Invoke(currentMask);
    }
}
