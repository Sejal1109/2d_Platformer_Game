using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public PlayerStats stats = null;
    public static SaveManager instance;

    private string savePath;

    private void Awake()
    {
        instance= this;
        savePath = Application.persistentDataPath + "/saveData/";
    }
    private void Start()
    {
        if (MainMenu.gameState == "New")
        {
            Debug.Log("Saving to path: " + savePath);
            this.stats = new PlayerStats();
        }
    }

    public void SavePlayer()
    {
        JSONLoaderSaver.SavePlayerAsJSON(savePath, "player.json", this.stats);
    }
    public void LoadPlayer()
    {
        this.stats = JSONLoaderSaver.LoadPlayerFromJSON(savePath,
        "player.json");
    }

}
