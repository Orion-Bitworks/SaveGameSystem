using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CoinData
{
    public bool enable;
    public int value;
    public float[] pos;

    public CoinData(CoinController coin)
    {
        value = coin.GetValue();
        enable = coin.IsEnabled();
        pos = new float[] { coin.transform.position.x, coin.transform.position.y, coin.transform.position.z };
    }
}
