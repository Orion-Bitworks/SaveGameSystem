using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CoinData
{
    public bool enable;
    public int value;
    public float movementQuantity;
    public float movementSpeed;
    public float[] pos;
    public float[] posIni;

    public CoinData(CoinController coin)
    {
        value = coin.GetValue();
        movementQuantity = coin.GetMovementQuantity();
        movementSpeed = coin.GetMovementSpeed();
        enable = coin.IsEnabled();
        pos = new float[] { coin.transform.position.x, coin.transform.position.y, coin.transform.position.z };
        posIni = new float[] { coin.GetPosIni().x, coin.GetPosIni().y, coin.GetPosIni().z };
    }
}
