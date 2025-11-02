[System.Serializable]
public class EnemyData : CharacterData
{
    private float velocityX;
    private float velocityZ;

    public EnemyData(Enemies enemy) //setejem cada variable amb lo que es
    {
        SetHealth(enemy.GetHealth());
        SetPos(enemy.transform.position);
        SetEnabled(enemy.isAlive);
        SetVelocityX(enemy.velocityX);
        SetVelocityZ(enemy.velocityZ);
    }

    public void SetVelocityX(float velocityX)
    {
        this.velocityX = velocityX;
    }

    public float GetVelocityX()
    {
        return velocityX;
    }

    public void SetVelocityZ(float velocityZ)
    {
        this.velocityZ = velocityZ;
    }

    public float GetVelocityZ()
    {
        return velocityZ;
    }
}
