using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    int id;

    private Dictionary<string, List<GameObject>> saveDictionary = new Dictionary<string, List<GameObject>>();

    [SerializeField] List<SaveableObject> saveableList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
