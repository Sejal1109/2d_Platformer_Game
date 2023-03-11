using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string gameState;

    public void PlayGame()
    {
        gameState = "New";
        Debug.Log("Play Game");
        SceneManager.LoadScene("LevelScene");
    }

    public void LoadGame()
    {
        gameState = "Load";
        Debug.Log("Load");
        SaveManager.instance.LoadPlayer();
        if (SaveManager.instance.stats != null)
        {
            SceneManager.LoadScene("LevelScene");
        }
        else 
        {
            Debug.Log("No Game to Load");
        }
        
    }
    public void Credits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

