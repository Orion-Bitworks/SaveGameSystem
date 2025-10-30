using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public int health;
    public float[] enemyPosition;


    public EnemyData(Enemies enemies)
    {
        health = enemies.GetHealth();

        enemyPosition = new float[] { enemies.transform.position.x, enemies.transform.position.y, enemies.transform.position.z };
    }

}
