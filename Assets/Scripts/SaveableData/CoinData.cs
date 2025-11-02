[System.Serializable]
public class CoinData : SaveData
{
    private int value;
    private float floatDistance;
    private float floatSpeed;

    public CoinData(CoinController coin)
    {
        SetEnabled(coin.gameObject.activeSelf);
        SetPos(coin.transform.position);
        SetValue(coin.GetValue());
        SetFloatDistance(coin.GetFloatDistance());
        SetFloatSpeed(coin.GetFloatSpeed());
    }

    public void SetValue(int value)
    {
        this.value = value;
    }

    public int GetValue()
    {
        return value;
    }

    public void SetFloatDistance(float floatDistance)
    {
        this.floatDistance = floatDistance;
    }

    public float GetFloatDistance()
    {
        return floatDistance;
    }

    public void SetFloatSpeed(float floatSpeed)
    {
        this.floatSpeed = floatSpeed;
    }

    public float GetFloatSpeed()
    {
        return floatSpeed;
    }
}
