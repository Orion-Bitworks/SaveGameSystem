using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : SaveableObject
{
    public int health;
    public bool isAlive = true;
    public float velocityX, velocityZ; //recordar que en unity els eixos son diferents (x, y) NO, (x, z) SI

    private void Update()
    {
        MoveEnemy();
    }

    public override object CaptureData()
    {
        return data = new EnemyData(this);
    }

    public override void RestoreData(object data)
    {
        EnemyData d = (EnemyData)data;
        gameObject.SetActive(d.GetEnabled());
        health = d.GetHealth();
        transform.position = d.GetPos();
        
        velocityX = d.GetVelocityX();
        velocityZ = d.GetVelocityZ();

        isAlive = d.GetEnabled();

    }

    public int GetHealth() //retornem la vida
    {
        return health;
    }

    public void SetPosition(Vector3 pos) //Setejar la posicio del enemic
    {
        gameObject.transform.position = pos;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health--; //li restem una vida

            isAlive = false; //no esta viu

            GameManager.instance.AddKilledEnemy();

            gameObject.SetActive(isAlive); //destrueix el gameObject

            Debug.Log("Vidas restantes:" + health + "\n ENEMIGO DESTRUIDO");

        }
        
    }
    
    void MoveEnemy() //mètode per moure els enemics de manera random
    {
        transform.Translate (velocityX * Time.deltaTime, 0 , velocityZ * Time.deltaTime);

        if((transform.position.x < -9) || (transform.position.x > 9))
        {
            velocityX = -velocityX;
        }

        if ((transform.position.z < -9) || (transform.position.z > 9))
        {
            velocityZ = -velocityZ;
        }


    }
}
