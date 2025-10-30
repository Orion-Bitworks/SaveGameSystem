using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public int lives;
    private bool isAlive = true;

    public float velocityX, velocityZ;


    private void Update()
    {
        MoveEnemy();
    }

    void SetHealth(int lifesRemaining)
    {
        lives = lifesRemaining;
    }

    public int GetHealth()
    {
        return lives;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lives--;
            isAlive = false;
            Destroy(gameObject);

            Debug.Log("Vidas restantes:" + lives + "ENEMIGO DESTRUIDO");

        }
        
    }
    
    void MoveEnemy()
    {
        transform.Translate (velocityX * Time.deltaTime, 0 , velocityZ * Time.deltaTime);

        if((transform.position.x < -12) || (transform.position.x > 13))
        {
            velocityX = -velocityX;
        }

        if ((transform.position.z < -12) || (transform.position.z > 11))
        {
            velocityZ = -velocityZ;
        }


    }
}
