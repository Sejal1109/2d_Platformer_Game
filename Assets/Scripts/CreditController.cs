using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    public void Return()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
