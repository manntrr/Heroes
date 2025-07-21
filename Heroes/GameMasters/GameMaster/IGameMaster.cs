using Heroes.Genres;
using Heroes.Campaigns;
using Heroes.GameMasters.GameMaster.Players.Player;

namespace Heroes.GameMasters.GameMaster;

public interface IGameMaster : IPlayer
{
    static public String GameMasterString = "GameMaster";
    static new public String KeyString = "Key";
    static new public String UnknownString = "Unknown";
    static new public String DefaultKey = UnknownString + " " + GameMasterString + " " + KeyString;
    static new public String DefaultName = UnknownString + " " + GameMasterString;

    static new public CampaignKeySet DefaultCampaignKeys = new(Campaigns: new Campaigns.Campaigns(ICampaigns.CAMPAIGNS["Unknown Campaign"]), ref ICampaigns.CAMPAIGNS);
    static new public GenreKeySet DefaultGenreKeys = new(Genres: new Genres.Genres(IGenres.GENRES["Unknown"]), ref IGenres.GENRES);
    // TODO: update to Game Master Keys
    static new public GameMasters DefaultGameMasters = new GameMasters();

    static public void INIT(IGameMaster GameMaster)
    {
        GameMaster.Key = DefaultKey;
        GameMaster.Name = DefaultName;
        GameMaster.CampaignKeys = DefaultCampaignKeys;
        GameMaster.GenreKeys = DefaultGenreKeys;
        GameMaster.GameMasters = DefaultGameMasters;
    }
    static public void INIT(IGameMaster GameMaster, String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null)
    {
        INIT(GameMaster: GameMaster, Key: Name + " " + KeyString, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    }
    static protected void INIT(IGameMaster GameMaster, String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null, GameMasters? GameMasters = null)
    {
        INIT(GameMaster: GameMaster, Key: Name + " " + KeyString, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys, GameMasters: GameMasters);
    }
    static public void INIT(IGameMaster GameMaster, String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null)
    {
        GameMaster.Key = Key;
        if (Name is not null) GameMaster.Name = Name;
        if (CampaignKeys is not null) GameMaster.CampaignKeys = CampaignKeys;
        if (GenreKeys is not null) GameMaster.GenreKeys = GenreKeys;
        //TODO:  fix this to use GameMasterKeys
        GameMaster.GameMasters = [];
    }
    static protected void INIT(IGameMaster GameMaster, String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null, GameMasters? GameMasters = null)
    {
        GameMaster.Key = Key;
        if (Name is not null) GameMaster.Name = Name;
        if (CampaignKeys is not null) GameMaster.CampaignKeys = CampaignKeys;
        if (GenreKeys is not null) GameMaster.GenreKeys = GenreKeys;
        if (GameMasters is not null) GameMaster.GameMasters = GameMasters;
    }
    static public void INIT(IGameMaster GameMaster, int Index)
    {
        INIT(GameMaster: GameMaster, Key: GameMasterString + " " + Index.ToString(), Name: DefaultName + " " + Index.ToString(), null, null, null);
    }
    static public void INIT(IGameMaster GameMaster, IGameMaster Original)
    {
        INIT(GameMaster: GameMaster, Key: Original.Key, Name: Original.Name, CampaignKeys: Original.CampaignKeys, GenreKeys: Original.GenreKeys, GameMasters: Original.GameMasters);
    }
    public new String Key { get; set; }
    public new String Name { get; set; }
    public new CampaignKeySet CampaignKeys { get; set; }
    public new GenreKeySet GenreKeys { get; set; }
    // TODO:  update to Game Masters Keys
    protected new GameMasters GameMasters { get; set; }
    public new void Init();
    public void Init(String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null);
    protected new void Init(String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null, GameMasters? GameMasters = null);
    public void Init(String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null);
    protected new void Init(String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null, GameMasters? GameMasters = null);
    public new void Init(int Index);
    public void Init(IGameMaster GameMaster);
    public void Init(GameMaster GameMaster);
}