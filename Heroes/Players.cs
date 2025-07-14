namespace Heroes;

public class Players : Dictionary<String, Player>
{
    public void Add(Player player)
    {
        this.Add(player.Key, player);
    }
}