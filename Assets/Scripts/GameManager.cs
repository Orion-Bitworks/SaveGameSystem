using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int obtainedCoins;

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
