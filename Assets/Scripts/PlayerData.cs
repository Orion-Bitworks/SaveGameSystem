using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//guardamos los datos de player para luego poder pasarlos a binario
[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] pos;

    public PlayerData(Player player)
    {
        health = player.GetHealth();
        pos = new float[] { player.transform.position.x, player.transform.position.y, player.transform.position.z };
    }
}