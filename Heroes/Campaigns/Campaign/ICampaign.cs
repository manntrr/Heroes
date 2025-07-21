using Heroes.Genres;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster;

namespace Heroes.Campaigns.Campaign;

public interface ICampaign
{
    static public String CampaignString = "Campaign";
    static public String KeyString = "Key";
    static public String UnknownString = "Unknown";
    static public String DefaultKey = UnknownString + " " + CampaignString + " " + KeyString;
    static public String DefaultName = UnknownString + " " + CampaignString;
    static public GenreKeySet DefaultGenreKeys = new(Genres: new Genres.Genres(IGenres.GENRES["Unknown"]), ref IGenres.GENRES);
    static public GameMasters.GameMasters DefaultGameMasters = new GameMasters.GameMasters(IGameMasters.GAME_MASTERS["Unknown GameMaster"]);
    /*
     new GameMasters.GameMasters((GameMasters.GameMaster.GameMaster[])[
            new GameMasters.GameMaster.GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMasters.GameMaster.GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
    /**/

    static public void INIT(ICampaign Campaign)
    {
        Campaign.Key = DefaultKey;
        Campaign.Name = DefaultName;
        Campaign.GenreKeys = DefaultGenreKeys;
        Campaign.GameMasters = DefaultGameMasters;
    }
    static public void INIT(ICampaign Campaign, String Name, GenreKeySet? GenreKeys = null, GameMasters.GameMasters? GameMasters = null)
    {
        INIT(Campaign: Campaign, Key: Name + " " + KeyString, Name: Name, GenreKeys: GenreKeys, GameMasters: GameMasters);
    }
    static public void INIT(ICampaign Campaign, String Key, String? Name = null, GenreKeySet? GenreKeys = null, GameMasters.GameMasters? GameMasters = null)
    {
        Campaign.Key = Key;
        if (Name is not null) Campaign.Name = Name;
        if (GenreKeys is not null) Campaign.GenreKeys = GenreKeys;
        if (GameMasters is not null) Campaign.GameMasters = GameMasters;
    }
    static public void INIT(ICampaign Campaign, int Index)
    {
        INIT(Campaign: Campaign, Key: CampaignString + " " + Index.ToString(), Name: DefaultName + " " + Index.ToString());
    }
    static public void INIT(ICampaign Campaign, ICampaign Original)
    {
        INIT(Campaign: Campaign, Key: Original.Key, Name: Original.Name, GenreKeys: Original.GenreKeys, GameMasters: Original.GameMasters);
    }
    public String Key { get; set; }
    public String Name { get; set; }
    public GenreKeySet GenreKeys { get; set; }
    public GameMasters.GameMasters GameMasters { get; set; }
    public void Init();
    public void Init(String Name, GenreKeySet? GenreKeys = null, GameMasters.GameMasters? GameMasters = null);
    public void Init(String Key, String? Name = null, GenreKeySet? GenreKeys = null, GameMasters.GameMasters? GameMasters = null);
    public void Init(int Index);
    public void Init(ICampaign Campaign);
    public void Init(Campaign Campaign);
}