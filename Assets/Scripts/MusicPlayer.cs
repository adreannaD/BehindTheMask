using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject); // keep across scenes
    }
}
