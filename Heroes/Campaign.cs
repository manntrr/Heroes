namespace Heroes;

public class Campaign
{
    public Campaign(string Key, Genres CampaignGenres, string? Name = null, GameMasters? GameMasters = null)
    {

    }
    public Campaign(string Key, Genres CampaignGenres, ref Genres? GlobalGenres, string? Name = null, GameMasters? GameMasters = null)
    {
        this.Key = Key;
        this.Genres = CampaignGenres.Keys;
        if (GlobalGenres is not null)
            foreach (KeyValuePair<String, Genre> genre in CampaignGenres)
                if (!GlobalGenres.ContainsKey(genre.Key)) GlobalGenres.Add(genre.Key, genre.Value);
        if (Name is not null) this.Name = Name;
        if (GameMasters is not null) this.GameMasters = GameMasters.Keys;
    }
    public string Key { get; }
    public string Name { get; } = "Unknown Campaign";
    public Dictionary<String, Genre>.KeyCollection Genres { get; }
    public Dictionary<String, GameMaster>.KeyCollection? GameMasters { get; } = null;
}
