using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    [SerializeField] private PlayerInput player = null;

    private string savePath;
    private void Start()
    {
        savePath = Application.persistentDataPath + "/saveData/";
        Debug.Log("Saving to path: " + savePath);
        //player = new PlayerInput();
        Debug.Log(player.name+"helllo");
    }
    [ContextMenu("Save Player")]
    public void SaveArmour()
    {
        JSONLoaderSaver.SaveArmourAsJSON(savePath, "player.json", this.player);
      //  BinaryLoaderSaver.SaveArmourAsBinary(savePath, "armour.bin", this.armour);
    }
    [ContextMenu("Load Armour")]
    public void LoadArmour()
    {
        this.player = JSONLoaderSaver.LoadArmourFromJSON(savePath, "player.json");
        //this.armour = BinaryLoaderSaver.LoadArmourFromBinary(savePath, "armour.bin");
    }
    
}
