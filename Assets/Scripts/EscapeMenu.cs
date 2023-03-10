using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escScreen;
    public GameObject player;
    private bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        escScreen = GameObject.Find("EscMenuUI");
        escScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (open == false)
            {
                Debug.Log("open");
                open = true;
                escScreen.SetActive(true);
                player.GetComponent<PlayerInput>().enabled = false;

            }
            else
            {
                open = false;
                Debug.Log("close");
                //player.SetActive(true);
                escScreen.SetActive(false);
                player.GetComponent<PlayerInput>().enabled = true;

            }
        }
    }
}
