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

    // Metdo de guardado
    public static void SaveGame()
    {
        if (!Directory.Exists(saveFolder))
            Directory.CreateDirectory(saveFolder);
        //guardamos los datos que hay en la clase SaveData
        SaveData saveData = new SaveData();
        //hacemos una lista de los ISaveable que tenemos 
        ISaveable[] saveables = FindObjectsOfType<MonoBehaviour>(true) as ISaveable[];

        // verificamos si los MonoBEhaviours son isaveables y en ese caso guardamos la informacion
        foreach (MonoBehaviour mono in FindObjectsOfType<MonoBehaviour>(true))
        {
            if (mono is ISaveable saveable)
            {
                string id = saveable.GetUniqueID();
                object data = saveable.CaptureData();
                saveData.allData[id] = data;
            }
        }
        //lo pasamos a binario
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
        //
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


    public static void SaveEnemy(Enemies enemies)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = (Application.persistentDataPath + "/Saves");
        string binaryPath = (Application.persistentDataPath + "/Saves/SaveDataEnemy.dat");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else Debug.Log("La carpeta de los enemigos ya existe!");

        FileStream stream = new FileStream(binaryPath, FileMode.Create);
        EnemyData data = new EnemyData(enemies);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static EnemyData LoadEnemy()
    {
        string binaryPath = (Application.persistentDataPath + "/Saves/SaveDataEnemy.dat");

        if (File.Exists(binaryPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(binaryPath, FileMode.Open);
            EnemyData data = formatter.Deserialize(stream) as EnemyData;
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
