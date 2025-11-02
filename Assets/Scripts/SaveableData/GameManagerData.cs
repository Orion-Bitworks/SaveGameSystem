using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameManagerData : SaveData
{
    private int obtainedCoins;
    private int killedEnemies;

    public GameManagerData(GameManager gm)
    {
        SetObtainedCoins(gm.GetObtainedCoins());
    }

    public void SetObtainedCoins(int obtainedCoins)
    {
        this.obtainedCoins = obtainedCoins;
    }

    public int GetObtainedCoins()
    {
        return obtainedCoins;
    }

    public void SetKilledEnemies(int killedEnemies)
    {
        this.killedEnemies = killedEnemies;
    }

    public int GetKilledEnemies()
    {
        return killedEnemies;
    }
}
