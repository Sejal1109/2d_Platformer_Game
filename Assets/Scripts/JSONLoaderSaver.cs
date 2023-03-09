using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONLoaderSaver : MonoBehaviour


{
 

    public static void SaveArmourAsJSON(string savePath, string fname, PlayerInput player)
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Creating save data directory: " + savePath);
        }
        string json = JsonUtility.ToJson(player);
        File.WriteAllText(savePath + fname, json);
        Debug.Log(savePath + fname);
    }
    public static PlayerInput LoadArmourFromJSON(string savePath, string fname)
    {
        if (File.Exists(savePath + fname))
        {
            Debug.Log("Read in data");
            string json = File.ReadAllText(savePath + fname);

            Debug.Log("Read in data");
            PlayerInput player = JsonUtility.FromJson<PlayerInput>(json);  //i think this line is causing the error. idk how to change it tho
               
            return player;
           
          
        }
        else
        {
            Debug.LogError("Cannot find file: " + savePath);
        }
        return null;
    }
   
}
