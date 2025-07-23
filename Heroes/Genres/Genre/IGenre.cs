using Heroes.Campaigns;
using Heroes.Campaigns.Campaign;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;

namespace Heroes.Genres.Genre;

public interface IGenre
{
    static public String GenreString = "Genre";
    static public String KeyString = "Key";
    static public String UnknownString = "Unknown";
    static public String DefaultKey = UnknownString + " " + GenreString + " " + KeyString;
    static public String DefaultName = UnknownString + " " + GenreString;
    static public void INIT(IGenre Genre)
    {
        Genre.Key = DefaultKey;
        Genre.Name = DefaultName;
    }
    static public void INIT(IGenre Genre, String Name)
    {
        INIT(Genre: Genre, Key: Name + " " + KeyString, Name: Name);
    }
    static public void INIT(IGenre Genre, String Key, String? Name = null)
    {
        Genre.Key = Key;
        if (Name is not null) Genre.Name = Name;
    }
    static public void INIT(IGenre Genre, int Index)
    {
        INIT(Genre: Genre, Key: GenreString + " " + Index.ToString(), Name: DefaultName + " " + Index.ToString());
    }
    static public void INIT(IGenre Genre, IGenre Original)
    {
        INIT(Genre: Genre, Key: Original.Key, Name: Original.Name);
    }
    static public CampaignKeySet CAMPAIGN_KEYS(IGenre Genre, Heroes Heroes)
    {
        Campaigns.Campaigns temp = new();
        Campaigns.Campaigns campaigns = new();
        campaigns.Clear();
        foreach (KeyValuePair<string, Campaign> pair in Heroes.Campaigns)
        {
            if (pair.Value.GenreKeys.Contains(Genre.Key)) campaigns.Add(pair.Value);
        }
        return new(campaigns, ref temp);
    }
    static public PlayerKeySet PLAYER_KEYS(IGenre Genre, Heroes Heroes)
    {
        GameMasters.GameMaster.Players.Players temp = new();
        GameMasters.GameMaster.Players.Players players = new();
        players.Clear();
        foreach (KeyValuePair<string, GameMasters.GameMaster.Players.Player.Player> pair in Heroes.Players)
        {
            if (pair.Value.GenreKeys.Contains(Genre.Key)) players.Add(pair.Value);
        }
        return new(players, ref temp);
    }
    static public GameMasterKeySet GAME_MASTER_KEYS(IGenre Genre, Heroes Heroes)
    {
        GameMasters.GameMasters temp = new();
        GameMasters.GameMasters gameMasters = new();
        gameMasters.Clear();
        foreach (KeyValuePair<string, GameMasters.GameMaster.GameMaster> pair in Heroes.GameMasters)
        {
            if (pair.Value.GenreKeys.Contains(Genre.Key)) gameMasters.Add(pair.Value);
        }
        return new(gameMasters, ref temp);
    }
    public String Key { get; set; }
    public String Name { get; set; }
    public void Init();
    public void Init(String Name);
    public void Init(String Key, String? Name = null);
    public void Init(int Index);
    public void Init(IGenre Genre);
    public void Init(Genre Genre);
    public CampaignKeySet CampaignKeys(Heroes Heroes);
    public PlayerKeySet PlayerKeys(Heroes Heroes);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes);
}