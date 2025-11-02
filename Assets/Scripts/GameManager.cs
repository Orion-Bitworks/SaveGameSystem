using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SaveableObject
{
    public static GameManager instance;

    [SerializeField] int obtainedCoins;
    [SerializeField] int killedEnemies;

    public override object CaptureData()
    {
        return data = new GameManagerData(this);
    }

    public override void RestoreData(object data)
    {
        GameManagerData d = (GameManagerData) data;
        obtainedCoins = d.GetObtainedCoins();
        killedEnemies = d.GetKilledEnemies();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public int GetObtainedCoins()
    {
        return obtainedCoins;
    }

    public void SetObtainedCoins(int newObtainedCoins)
    {
        obtainedCoins = newObtainedCoins;
    }
    
    public void AddObtainedCoins(int coinValue)
    {
        obtainedCoins += coinValue;
    }
    
    public void LoseObtainedCoins()
    {
        obtainedCoins--;
    }

    public void AddKilledEnemy()
    {
        killedEnemies++;
    }

    public void LoseKilledEnemy()
    {
        killedEnemies--;
    }
}
