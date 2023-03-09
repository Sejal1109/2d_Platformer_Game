using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONLoaderSaver : MonoBehaviour
{
/*    public static void SaveArmourAsJSON(string savePath, string fname, PlayerInput player)
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Creating save data directory: " + savePath);
        }
        string json = JsonUtility.ToJson(player);
        File.WriteAllText(savePath + fname, json);
    }
    public static PlayerInput LoadArmourFromJSON(string savePath, string fname)
    {
        if (File.Exists(savePath + fname))
        {
            string json = File.ReadAllText(savePath + fname);
            PlayerInput player = JsonUtility.FromJson<PlayerInput>(json);
            return player;
        }
        else
        {
            Debug.LogError("Cannot find file: " + savePath);
        }
        return null;
    }
*/
}
