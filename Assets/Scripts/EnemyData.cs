using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public int health;
    public float[] enemyPosition;
    public float velocityX;
    public float velocityZ;

    public EnemyData(Enemies enemies) //setejem cada variable amb lo que es
    {
        health = enemies.GetHealth();
        enemyPosition = new float[] { enemies.transform.position.x, enemies.transform.position.y, enemies.transform.position.z };

        velocityX = enemies.velocityX;
        velocityZ = enemies.velocityZ;
    }

}
