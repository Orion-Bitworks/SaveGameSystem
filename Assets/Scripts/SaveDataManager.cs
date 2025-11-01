using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    //creamos un la lista para guardar todos los savedata, que almacena como objetos al resto de datas
    int id;

    private Dictionary<string, List<GameObject>> saveDictionary = new Dictionary<string, List<GameObject>>();

    [SerializeField] List<SaveableObject> saveableList;

}
