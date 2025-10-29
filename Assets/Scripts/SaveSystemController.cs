using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    public static SaveSystemController instance;
    private void Awake()
    {
        if(instance != null & instance != this )
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = (Application.persistentDataPath + "/Saves");
        string binaryPath = (Application.persistentDataPath + "/Saves/SaveData.dat");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else Debug.Log("La carpeta ya existe!");

        FileStream stream = new FileStream(binaryPath, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string binaryPath = (Application.persistentDataPath + "/Saves/SaveData.dat");

        if (File.Exists(binaryPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(binaryPath, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found at " + binaryPath);
            return null;
        }
    }
}
