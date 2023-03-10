using UnityEngine;
using System.IO;

public class JSONLoaderSaver : MonoBehaviour
{
    public static void SavePlayerAsJSON(string savePath, string fname,
    PlayerStats player)
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            Debug.Log("Creating save data directory: " + savePath);
        }
        string json = JsonUtility.ToJson(player);
        File.WriteAllText(savePath + fname, json);
    }
    public static PlayerStats LoadPlayerFromJSON(string savePath, string fname)
    {
        if (File.Exists(savePath + fname))
        {
            string json = File.ReadAllText(savePath + fname);
            PlayerStats player = JsonUtility.FromJson<PlayerStats>(json);
            return player;
        }
        else
        {
            Debug.LogError("Cannot find file: " + savePath);
        }
        return null;
    }
}