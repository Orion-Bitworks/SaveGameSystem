using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableObject : MonoBehaviour, ISaveable
{
    [SerializeField] private string id = System.Guid.NewGuid().ToString();

    public virtual string GetUniqueID() => id;

    //guardamos los datos de Player 
    public abstract object CaptureData();

    //cargamos los datos que previamente hemos guardado de player data
    public abstract void RestoreData(object obj);

    public void SetId(string id)
    {
        this.id = id;
    }

    public string GetId()
    {
        return id;
    }
}
