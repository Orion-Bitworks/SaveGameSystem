[System.Serializable]
public class PlayerData : CharacterData
{
    public PlayerData(PlayerController player)
    {
        SetHealth(player.GetHealth());
        SetPos(player.transform.position);
    }
}