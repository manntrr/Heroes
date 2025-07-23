using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres;

namespace Heroes.Campaigns.Campaign;

public interface ICampaign
{
    static public String CampaignString = "Campaign";
    static public String KeyString = "Key";
    static public String UnknownString = "Unknown";
    static public String DefaultKey = UnknownString + " " + CampaignString + " " + KeyString;
    static public String DefaultName = UnknownString + " " + CampaignString;
    static public GenreKeySet DefaultGenreKeys = new(Genres: new Genres.Genres(IGenres.GENRES["Unknown"]), ref IGenres.GENRES);

    static public void INIT(ICampaign Campaign)
    {
        Campaign.Key = DefaultKey;
        Campaign.Name = DefaultName;
        Campaign.GenreKeys = DefaultGenreKeys;
    }
    static public void INIT(ICampaign Campaign, String Name, GenreKeySet? GenreKeys = null)
    {
        INIT(Campaign: Campaign, Key: Name + " " + KeyString, Name: Name, GenreKeys: GenreKeys);
    }
    static public void INIT(ICampaign Campaign, String Key, String? Name = null, GenreKeySet? GenreKeys = null)
    {
        Campaign.Key = Key;
        if (Name is not null) Campaign.Name = Name;
        if (GenreKeys is not null) Campaign.GenreKeys = GenreKeys;
    }
    static public void INIT(ICampaign Campaign, int Index)
    {
        INIT(Campaign: Campaign, Key: CampaignString + " " + Index.ToString(), Name: DefaultName + " " + Index.ToString());
    }
    static public void INIT(ICampaign Campaign, ICampaign Original)
    {
        INIT(Campaign: Campaign, Key: Original.Key, Name: Original.Name, GenreKeys: Original.GenreKeys);
    }
    static public PlayerKeySet PLAYER_KEYS(ICampaign Campaign, Heroes Heroes)
    {
        GameMasters.GameMaster.Players.Players temp = new();
        GameMasters.GameMaster.Players.Players players = new();
        players.Clear();
        foreach (KeyValuePair<string, GameMasters.GameMaster.Players.Player.Player> pair in Heroes.Players)
        {
            if (pair.Value.CampaignKeys.Contains(Campaign.Key)) players.Add(pair.Value);
        }
        return new(players, ref temp);
    }
    static public GameMasterKeySet GAME_MASTER_KEYS(ICampaign Campaign, Heroes Heroes)
    {
        GameMasters.GameMasters temp = new();
        GameMasters.GameMasters gameMasters = new();
        gameMasters.Clear();
        foreach (KeyValuePair<string, GameMasters.GameMaster.GameMaster> pair in Heroes.GameMasters)
        {
            if (pair.Value.CampaignKeys.Contains(Campaign.Key)) gameMasters.Add(pair.Value);
        }
        return new(gameMasters, ref temp);
    }
    public String Key { get; set; }
    public String Name { get; set; }
    public GenreKeySet GenreKeys { get; set; }
    public void Init();
    public void Init(String Name, GenreKeySet? GenreKeys = null);
    public void Init(String Key, String? Name = null, GenreKeySet? GenreKeys = null);
    public void Init(int Index);
    public void Init(ICampaign Campaign);
    public void Init(Campaign Campaign);
    public PlayerKeySet PlayerKeys(Heroes Heroes);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes);
}