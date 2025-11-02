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

}
