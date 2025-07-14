namespace Heroes;

public class GameMaster : Player
{
    public GameMaster(string Key, string Name, Campaigns Campaigns, Genres? Genres = null) : base(Key: Key, Name: Name, Genres: Genres, Campaigns: Campaigns)
    {
    }
}
