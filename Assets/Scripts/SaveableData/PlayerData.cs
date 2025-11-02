[System.Serializable]
public class PlayerData : CharacterData
{
    public PlayerData(Player player)
    {
        SetHealth(player.GetHealth());
        SetPos(player.transform.position);
    }
}