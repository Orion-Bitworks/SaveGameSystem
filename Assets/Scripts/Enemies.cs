using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour, ISaveable
{

    public int lives;
    public bool isAlive = true;

    public float velocityX, velocityZ; //recordar que en unity els eixos son diferents (x, y) NO, (x, z) SI

    private int enemiesDied; //Contabilitar quans enemics s'han matat

    [SerializeField] private string id = System.Guid.NewGuid().ToString();

    EnemyData data;

    public string GetUniqueID() => id;

    private void Update()
    {
        MoveEnemy();
    }

    public object CaptureData()
    {
        return data = new EnemyData(this);
    }

    public void RestoreData(object data)
    {
        EnemyData d = (EnemyData)data;
        gameObject.SetActive(d.GetEnabled());
        lives = d.GetHealth();
        transform.position = d.GetPos();
        
        velocityX = d.GetVelocityX();
        velocityZ = d.GetVelocityZ();

        isAlive = d.GetEnabled();

    }

    /*public void SaveEnemy() //guardar el enemic
    {
        SaveSystemController.SaveEnemy(this);
    }*/

    public int GetHealth() //retornem la vida
    {
        return lives;
    }

    /*public void LoadEnemy() //carregar el enemic
    {
        EnemyData data = SaveSystemController.LoadEnemy();
            

        lives = data.health;
        Vector3 pos;

        pos.x = data.enemyPosition[0];
        pos.y = data.enemyPosition[1];
        pos.z = data.enemyPosition[2];

        SetPosition(pos);

        velocityX = data.velocityX;
        velocityZ = data.velocityZ;
    }*/


    public void SetPosition(Vector3 pos) //Setejar la posicio del enemic
    {
        gameObject.transform.position = pos;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lives--; //li restem una vida

            isAlive = false; //no esta viu

            enemiesDied++; // sumem a 1 els enemics morts

            gameObject.SetActive(isAlive); //destrueix el gameObject

            Debug.Log("Vidas restantes:" + lives + "\n ENEMIGO DESTRUIDO");

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
