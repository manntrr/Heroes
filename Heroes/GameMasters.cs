namespace Heroes;

public class GameMasters : Dictionary<String, GameMaster>
{
    public void Add(GameMaster gameMaster)
    {
        this.Add(gameMaster.Key, gameMaster);
    }
}