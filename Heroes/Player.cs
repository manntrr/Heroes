namespace Heroes;

public class Player
{
    public Player(string Key, string Name, Campaigns Campaigns, Genres? Genres = null, GameMasters? GameMasters = null)
    {
        this.Key = Key;
        this.Name = Name;
        this.Campaigns = Campaigns.Keys;
        if (Genres is not null) this.Genres = Genres.Keys;
        else
        {
            Genres genres = [];
            foreach (KeyValuePair<String, Campaign> campaign in Campaigns)
            {
                foreach (String genreKey in campaign.Value.GenreKeys.Keys)
                {
                    genres.Add(genreKey, new Genre(genreKey, null));
                }
            }
            this.Genres = genres.Keys;
        }
        if (GameMasters is not null) this.GameMasters = GameMasters.Keys;
    }
    public string Key { get; }
    public string Name { get; }
    public Dictionary<String, Genre>.KeyCollection Genres { get; }
    public Dictionary<String, Campaign>.KeyCollection Campaigns { get; }
    public Dictionary<String, GameMaster>.KeyCollection? GameMasters { get; } = null;
}