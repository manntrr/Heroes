using Heroes.Genres;
using Heroes.Campaigns;

namespace Heroes.GameMasters.GameMaster.Players.Player;

public interface IPlayer
{
    static public String PlayerString = "Player";
    static public String KeyString = "Key";
    static public String UnknownString = "Unknown";
    static public String DefaultKey = UnknownString + " " + PlayerString + " " + KeyString;
    static public String DefaultName = UnknownString + " " + PlayerString;
    static public CampaignKeySet DefaultCampaignKeys = new(Campaigns: new Campaigns.Campaigns(ICampaigns.CAMPAIGNS["Unknown Campaign"]), ref ICampaigns.CAMPAIGNS);
    static public GenreKeySet DefaultGenreKeys = new(Genres: new Genres.Genres(IGenres.GENRES["Unknown"]), ref IGenres.GENRES);

    static public void INIT(IPlayer Player)
    {
        Player.Key = DefaultKey;
        Player.Name = DefaultName;
        Player.CampaignKeys = DefaultCampaignKeys;
        Player.GenreKeys = DefaultGenreKeys;
    }
    static public void INIT(IPlayer Player, String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null)
    {
        INIT(Player: Player, Key: Name + " " + KeyString, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    }
    static public void INIT(IPlayer Player, String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null)
    {
        Player.Key = Key;
        if (Name is not null) Player.Name = Name;
        if (CampaignKeys is not null) Player.CampaignKeys = CampaignKeys;
        if (GenreKeys is not null) Player.GenreKeys = GenreKeys;
    }
    static public void INIT(IPlayer Player, int Index)
    {
        INIT(Player: Player, Key: PlayerString + " " + Index.ToString(), Name: DefaultName + " " + Index.ToString());
    }
    static public void INIT(IPlayer Player, IPlayer Original)
    {
        INIT(Player: Player, Key: Original.Key, Name: Original.Name, CampaignKeys: Original.CampaignKeys, GenreKeys: Original.GenreKeys);
    }
    static public GameMasterKeySet GAME_MASTER_KEYS(IPlayer Player, Heroes Heroes)
    {
        GameMasters temp = new();
        GameMasters gameMasters = new();
        gameMasters.Clear();
        foreach (KeyValuePair<string, GameMaster> pair in Heroes.GameMasters)
        {
            // TODO: fix this
            //if (pair.Value.PlayerKeys.Contains(Player.Key)) gameMasters.Add(pair.Value);
            if (pair.Value.CampaignKeys.Contains(Player.Key)) gameMasters.Add(pair.Value);
        }
        return new(gameMasters, ref temp);
    }
    public String Key { get; set; }
    public String Name { get; set; }
    public CampaignKeySet CampaignKeys { get; set; }
    public GenreKeySet GenreKeys { get; set; }
    public void Init();
    public void Init(String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null);
    public void Init(String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null);
    public void Init(int Index);
    public void Init(IPlayer Player);
    public void Init(Player Player);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes);
}