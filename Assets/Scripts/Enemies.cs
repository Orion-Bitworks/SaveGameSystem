using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public int lives;
    private bool isAlive = true;

    public float velocityX, velocityZ; //recordar que en unity els eixos son diferents (x, y) NO, (x, z) SI

    private int enemiesDied; //Contabilitar quans enemics s'han matat

    private void Update()
    {
        MoveEnemy();
    }

    void SetHealth(int lifesRemaining)
    {
        lives = lifesRemaining;
    }

    public int GetHealth() //retornem la vida
    {
        return lives;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lives--; //li restem una vida

            isAlive = false; //no esta viu

            enemiesDied++; // sumem a 1 els enemics morts

            Destroy(gameObject); //destrueix el gameObject

            Debug.Log("Vidas restantes:" + lives + "\n ENEMIGO DESTRUIDO");

        }
        
    }
    
    void MoveEnemy() //mètode per moure els enemics de manera random
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
