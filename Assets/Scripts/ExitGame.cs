using UnityEngine;

public class ExitGame : MonoBehaviour
{
  
    public void button_exit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");

    }
}