using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;
    // Start is called before the first frame update
   // public GameObject off;
    void Start()
    {
      //  off = GameObject.Find("SoundOffIcon");
      //  off.SetActive(false);

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            load();
        }
        else
        {
            load();
        }

        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            loadButton();
        }
        else
        {
            loadButton();
        }
       // soundOffIcon.enabled = false;
        
        AudioListener.pause = muted;
        UpdateButtonIcon();
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
    public void ChangeVolume()
    {
        AudioListener.volume= volumeSlider.value;
        Save();
    }

    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);

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
