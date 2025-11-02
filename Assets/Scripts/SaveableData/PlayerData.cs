using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//guardamos los datos de player para luego poder pasarlos a binario
[System.Serializable]
public class PlayerData : SaveData
{
    public int health;

    public PlayerData(Player player)
    {
        health = player.GetHealth();
        SetPos(player.transform.position);
    }
}