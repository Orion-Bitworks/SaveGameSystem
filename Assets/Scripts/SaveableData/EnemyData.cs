[System.Serializable]
public class EnemyData : CharacterData
{
    private float velocityX;
    private float velocityZ;

    public EnemyData(EnemyController enemy)
    {
        SetHealth(enemy.GetHealth());
        SetPos(enemy.transform.position);
        SetEnabled(enemy.gameObject.activeSelf);
        SetVelocityX(enemy.GetVelocityX());
        SetVelocityZ(enemy.GetVelocityZ());
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
