namespace Heroes.GameMasters.GameMaster.Players;

public class Players : Dictionary<String, Player.Player>
{
    public void Add(Player.Player player)
    {
        this.Add(player.Key, player);
    }
}