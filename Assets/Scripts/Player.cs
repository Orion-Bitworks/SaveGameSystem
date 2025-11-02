using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ISaveable
{
    [SerializeField] int health = 3;
    PlayerData data;
    public string GetUniqueID() => "PLAYER";

    //guardamos los datos de Player 
    public object CaptureData()
    {
       return data = new PlayerData(this);
    }

    //cargamos los datos que previamente hemos guardado de player data
    public void RestoreData(object data)
    {
        PlayerData d = (PlayerData)data;
        health = d.health;
        transform.position = new Vector3(d.pos[0], d.pos[1], d.pos[2]);
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetTransform(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }
}
