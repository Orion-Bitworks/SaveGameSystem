using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{

    public static SaveSystemController instance;
    private static string saveFolder => Application.persistentDataPath + "/Saves";
    private static string saveFile => saveFolder + "/SaveData.dat";



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // === GUARDAR TODO ===
    public static void SaveGame()
    {
        if (!Directory.Exists(saveFolder))
            Directory.CreateDirectory(saveFolder);

        SaveData saveData = new SaveData();
        ISaveable[] saveables = FindObjectsOfType<MonoBehaviour>(true) as ISaveable[];

        // Captura de datos de todos los ISaveable
        foreach (MonoBehaviour mono in FindObjectsOfType<MonoBehaviour>(true))
        {
            if (mono is ISaveable saveable)
            {
                string id = saveable.GetUniqueID();
                object data = saveable.CaptureData();
                saveData.allData[id] = data;
            }
        }

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(saveFile, FileMode.Create))
        {
            formatter.Serialize(stream, saveData);
        }

        Debug.Log($"✅ Juego guardado en: {saveFile}");
    }

    // === CARGAR TODO ===
    public static void LoadGame()
    {
        if (!File.Exists(saveFile))
        {
            Debug.LogWarning("❌ No se encontró archivo de guardado.");
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        SaveData saveData;

        using (FileStream stream = new FileStream(saveFile, FileMode.Open))
        {
            saveData = formatter.Deserialize(stream) as SaveData;
        }

        foreach (MonoBehaviour mono in FindObjectsOfType<MonoBehaviour>(true))
        {
            if (mono is ISaveable saveable)
            {
                string id = saveable.GetUniqueID();
                if (saveData.allData.ContainsKey(id))
                {
                    saveable.RestoreData(saveData.allData[id]);
                }
            }
        }

        Debug.Log("✅ Juego cargado correctamente");
    }








    /*public static SaveSystemController instance;
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

    public static void SaveSaveableObjects(SceneObject SaveObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = (Application.persistentDataPath + "/Saves");
        string binaryPath = (Application.persistentDataPath + "/Saves/SaveObjectData.dat");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else Debug.Log("La carpeta ya existe!");

        FileStream stream = new FileStream(binaryPath, FileMode.Create);
        ObjectData data = new ObjectData(SaveObject);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ObjectData LoadObject()
    {
        string binaryPath = (Application.persistentDataPath + "/Saves/SaveObjectData.dat");

        if (File.Exists(binaryPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(binaryPath, FileMode.Open);
            ObjectData data = formatter.Deserialize(stream) as ObjectData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found at " + binaryPath);
            return null;
        }
    }*/

}
