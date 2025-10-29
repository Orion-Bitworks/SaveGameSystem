using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 3;

    public void SavePlayer()
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
