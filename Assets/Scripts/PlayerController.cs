using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SaveableObject
{
    [SerializeField] int health = 3;

    //Guardamos los datos de Player 
    public override object CaptureData()
    {
       return data = new PlayerData(this);
    }

    //Cargamos los datos que previamente hemos guardado de player data
    public override void RestoreData(object data)
    {
        PlayerData d = (PlayerData) data;
        health = d.GetHealth();
        transform.position = d.GetPos();
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
