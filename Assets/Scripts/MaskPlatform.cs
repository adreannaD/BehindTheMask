using UnityEngine;

public class MaskPlatform : MonoBehaviour
{
    public MaskType visibleMask; // truth or deception usually

    private SpriteRenderer sr;
    private Collider2D col;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        MaskEvents.OnMaskChanged += OnMaskChanged;

        // Initial state
        OnMaskChanged(MaskType.None);
    }

    void OnDestroy()
    {
        MaskEvents.OnMaskChanged -= OnMaskChanged;
    }

    void OnMaskChanged(MaskType current)
    {
        bool active = current != MaskType.None && current == visibleMask;
        sr.enabled = active;
        col.enabled = active;
    }
}
