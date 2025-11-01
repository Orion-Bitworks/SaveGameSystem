using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ISaveable
{
    [SerializeField] int health = 3;
    PlayerData data;
    public string GetUniqueID() => "PLAYER";

    public object CaptureData()
    {
       return data = new PlayerData(this);
    }

    
    public void RestoreData(object data)
    {
        PlayerData d = (PlayerData)data;
        health = d.health;
        transform.position = new Vector3(d.pos[0], d.pos[1], d.pos[2]);
    }







    
    
    
    /*public void SavePlayer()
    {
        SaveSystemController.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystemController.LoadPlayer();

        health = data.health;
        Vector3 pos;

        pos.x = data.pos[0];
        pos.y = data.pos[1];
        pos.z = data.pos[2];

        SetTransform(pos);
    }*/

    public int GetHealth()
    {
        return health;
    }

    public void SetTransform(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }
}
