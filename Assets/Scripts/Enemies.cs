using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public int lives;
    private bool isAlive = true;

    public float velocityX, velocityY;


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
        transform.Translate (velocityX * Time.deltaTime, velocityY * Time.deltaTime, 0);

        if((transform.position.x < -9) || (transform.position.x > 9))
        {
            velocityX = -velocityX;
        }
    }
}
