using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ISaveable
{
    public static GameManager instance;
    private string id = "GameManager";
    GameManagerData data;

    [SerializeField] int obtainedCoins;

    public string GetUniqueID() => id;

    public object CaptureData()
    {
        return data = new GameManagerData(this);
    }

    public void RestoreData(object data)
    {
        GameManagerData dt = (GameManagerData) data;
        obtainedCoins = dt.obtainedCoins;
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
}
