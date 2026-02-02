using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Level_1_Awakening
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
