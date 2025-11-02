using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : SaveableObject
{
    private int health;
    private bool isAlive = true;
    [SerializeField] float velocityX, velocityZ; //Recordar que en unity els eixos son diferents (x, y) NO, (x, z) SI
    private int moveCheck = 9;

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

    public int GetHealth() //Retornem la vida
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
            health--; //Li restem una vida

            if (health <= 0)
            {
                isAlive = false;
                GameManager.instance.AddKilledEnemy();
                gameObject.SetActive(isAlive); //Desactiva el gameObject
            }
        }
    }
    
    void MoveEnemy() //Mètode per moure els enemics de manera random
    {
        transform.Translate (velocityX * Time.deltaTime, 0 , velocityZ * Time.deltaTime);

        if((transform.position.x < -moveCheck) || (transform.position.x > moveCheck))
        {
            velocityX = -velocityX;
        }

        if ((transform.position.z < -moveCheck) || (transform.position.z > moveCheck))
        {
            velocityZ = -velocityZ;
        }
    }

    public float GetVelocityX()
    {
        return velocityX;
    }

    public float GetVelocityZ()
    {
        return velocityZ;
    }
}
