using CampaignsObject = Heroes.Campaigns.Campaigns;
using CampaignKeySet = Heroes.Campaigns.CampaignKeySet;
using CampaignObject = Heroes.Campaigns.Campaign.Campaign;
using GameMastersObject = Heroes.GameMasters.GameMasters;
using GameMasterKeySet = Heroes.GameMasters.GameMasterKeySet;
using GameMasterObject = Heroes.GameMasters.GameMaster.GameMaster;
using PlayersObject = Heroes.GameMasters.GameMaster.Players.Players;
using PlayerKeySet = Heroes.GameMasters.GameMaster.Players.PlayerKeySet;
using PlayerObject = Heroes.GameMasters.GameMaster.Players.Player.Player;

namespace Heroes.Genres.Genre;

public interface IGenre
{
    static readonly string EmptyString = "";
    static readonly string SpaceString = " ";
    static readonly string GenreString = "Genre";
    static readonly string KeyString = "Key";
    static readonly string UnknownString = "Unknown";
    static readonly string CustomString = "Custom";
    static readonly string AlternateString = "Alternate";
    static readonly string CustomGenreString = CustomString + SpaceString + UnknownString;
    static readonly string CustomGenreKeyString = CustomGenreString + SpaceString + KeyString;
    static readonly string AlternateCustomGenreKeyString = AlternateString + SpaceString + CustomGenreKeyString;
    static readonly string Genre1String = GenreString + SpaceString + "1";
    static readonly string UnknownGenre1String = UnknownString + SpaceString + Genre1String;
    static readonly string Genre2String = GenreString + SpaceString + "2";
    static readonly string UnknownGenre2String = UnknownString + SpaceString + Genre2String;
    public static readonly string DefaultKey = UnknownString + SpaceString + GenreString + SpaceString + KeyString;
    public static readonly string DefaultName = UnknownString + SpaceString + GenreString;
    static readonly string CampaignString = "Campaign";
    static readonly string Campaign1String = CampaignString + SpaceString + "1";
    public static void INIT(IGenre Genre)
    {
        Genre.Key = DefaultKey;
        Genre.Name = DefaultName;
    }
    public static void INIT(IGenre Genre, string Name)
    {
        INIT(Genre: Genre, Key: Name + SpaceString + KeyString, Name: Name);
    }
    public static void INIT(IGenre Genre, string Key, string? Name = null)
    {
        INIT(Genre: Genre);
        Genre.Key = Key;
        if (Name is not null) Genre.Name = Name;
    }
    public static void INIT(IGenre Genre, int Index)
    {
        INIT(Genre: Genre, Key: GenreString + SpaceString + Index.ToString(), Name: DefaultName + SpaceString + Index.ToString());
    }
    public static void INIT(IGenre Genre, IGenre Original)
    {
        INIT(Genre: Genre, Key: Original.Key, Name: Original.Name);
    }
    public static CampaignKeySet CAMPAIGN_KEYS(IGenre Genre, Heroes Heroes)
    {
        CampaignsObject temp = [];
        CampaignsObject campaigns = [];
        campaigns.Clear();
        foreach (KeyValuePair<string, CampaignObject> pair in Heroes.Campaigns)
        {
            if (pair.Value.GenreKeys.Contains(Genre.Key)) campaigns.Add(pair.Value);
        }
        return new(campaigns, ref temp);
    }
    public static PlayerKeySet PLAYER_KEYS(IGenre Genre, Heroes Heroes)
    {
        PlayersObject temp = [];
        PlayersObject players = [];
        players.Clear();
        foreach (KeyValuePair<string, PlayerObject> pair in Heroes.Players)
        {
            if (pair.Value.GenreKeys.Contains(Genre.Key)) players.Add(pair.Value);
        }
        return new(players, ref temp);
    }
    public static GameMasterKeySet GAME_MASTER_KEYS(IGenre Genre, Heroes Heroes)
    {
        GameMastersObject temp = [];
        GameMastersObject gameMasters = [];
        gameMasters.Clear();
        foreach (KeyValuePair<string, GameMasterObject> pair in Heroes.GameMasters)
        {
            if (pair.Value.GenreKeys.Contains(Genre.Key)) gameMasters.Add(pair.Value);
        }
        return new(gameMasters, ref temp);
    }
    public string Key { get; set; }
    public string Name { get; set; }
    public void Init();
    public void Init(string Name);
    public void Init(string Key, string? Name = null);
    public void Init(int Index);
    public void Init(IGenre Genre);
    public void Init(Genre Genre);
    public CampaignKeySet CampaignKeys(Heroes Heroes);
    public PlayerKeySet PlayerKeys(Heroes Heroes);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes);
    private static readonly Heroes heroes = new();
    private static CampaignsObject campaigns = heroes.Campaigns;
    private static PlayersObject players = heroes.Players;
    private static GameMastersObject gameMasters = heroes.GameMasters;
    private static int counter = 0;
    static readonly TestCasesDataDictionary TEST_CASE_DATA = new([
        new(nameof(GenreTests.NullConstructorTest), new(
            TestCaseDescriptions: [EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString()],
            TestCaseData: [
                new(
                    DefaultKey, DefaultName,
                    //new CampaignKeySet(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    //new PlayerKeySet(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    //new GameMasterKeySet(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.NullInitializorTest), new(
            TestCaseDescriptions: [EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString()],
            TestCaseData: [
                new(
                    DefaultKey, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.KeyConstructorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    CustomGenreKeyString, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    DefaultKey, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.KeyInitializorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    CustomGenreKeyString, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    DefaultKey, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.NameConstructorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    CustomGenreKeyString, CustomGenreString,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    DefaultKey, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.NameInitializorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    CustomGenreKeyString, CustomGenreString,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    DefaultKey, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.KeyNameConstructorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    AlternateCustomGenreKeyString, CustomGenreString,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    DefaultKey, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.KeyNameInitializorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    AlternateCustomGenreKeyString, CustomGenreString,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    DefaultKey, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.IndexConstructorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    1, Genre1String, UnknownGenre1String,
                    new CampaignKeySet(Campaigns: new([new CampaignObject(Key: Campaign1String)]), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    2, Genre2String, UnknownGenre2String,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.IndexInitializorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    1, Genre1String, UnknownGenre1String,
                    new CampaignKeySet(Campaigns: new([new CampaignObject(Key: Campaign1String)]), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    2, Genre2String, UnknownGenre2String,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.CopyConstructorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    AlternateCustomGenreKeyString, CustomGenreString,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    DefaultKey, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.CopyInitializorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    AlternateCustomGenreKeyString, CustomGenreString,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    DefaultKey, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.GetKeyAccessorTest), new(
            TestCaseDescriptions: [EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.AccessorString],
            TestCaseIds: [counter++.ToString()],
            TestCaseData: [
                new(
                    DefaultKey
                    )
            ])),
        new(nameof(GenreTests.SetKeyAccessorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.AccessorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    Genre1String, DefaultName,
                    new CampaignKeySet(Campaigns: new([new CampaignObject(Key: Campaign1String)]), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    CustomGenreKeyString, DefaultName,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.GetNameAccessorTest), new(
            TestCaseDescriptions: [EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.AccessorString],
            TestCaseIds: [counter++.ToString()],
            TestCaseData: [
                new(
                    DefaultName
                    )
            ])),
        new(nameof(GenreTests.SetNameAccessorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.AccessorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    DefaultKey, UnknownGenre1String,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    ),
                new(
                    DefaultKey, CustomGenreString,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenreTests.GetCampaignKeysAccessorTest), new(
            TestCaseDescriptions: [EmptyString, EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.AccessorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    DefaultKey,
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns)
                    ),
                new(
                    Genre1String,
                    new CampaignKeySet(Campaigns: new([new CampaignObject(Key: Campaign1String)]), MasterCampaigns: ref campaigns)
                    )
            ])),
        new(nameof(GenreTests.GetPlayerKeysAccessorTest), new(
            TestCaseDescriptions: [EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.AccessorString],
            TestCaseIds: [counter++.ToString()],
            TestCaseData: [
                new(
                    DefaultKey,
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players)
                    )
            ])),
        new(nameof(GenreTests.GetGameMasterKeysAccessorTest), new(
            TestCaseDescriptions: [EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.AccessorString],
            TestCaseIds: [counter++.ToString()],
            TestCaseData: [
                new(
                    DefaultKey,
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ]))
    ]);
}