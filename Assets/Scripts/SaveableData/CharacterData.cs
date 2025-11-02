[System.Serializable]
public class CharacterData : SaveData
{
    private int health;

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }
}
