using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameManagerData
{
    public int obtainedCoins;

    public GameManagerData(GameManager gm)
    {
        obtainedCoins = gm.GetObtainedCoins();
    }
}
