namespace Heroes.GameMasters;

public class GameMasters : Dictionary<String, GameMaster.GameMaster>
{
    public void Add(GameMaster.GameMaster gameMaster)
    {
        this.Add(gameMaster.Key, gameMaster);
    }
}