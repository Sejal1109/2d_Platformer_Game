using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManagerButton : MonoBehaviour
{
    
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;
    // Start is called before the first frame update
   // public GameObject off;
    void Start()
    {
        //  off = GameObject.Find("SoundOffIcon");
        //  off.SetActive(false);

        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            loadButton();
        }
        else
        {
            loadButton();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
        Debug.Log("GotHERE");


      
       
    }

    public void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;

        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }

    }
   

    private void SaveButton()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    private void loadButton()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        SaveButton();
        UpdateButtonIcon();
    }
}
