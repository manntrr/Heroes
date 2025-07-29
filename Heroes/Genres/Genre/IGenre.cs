using Heroes.Campaigns;
using _Campaigns = Heroes.Campaigns.Campaigns;
using Heroes.Campaigns.Campaign;
using Heroes.GameMasters;
using _GameMasters = Heroes.GameMasters.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using _Players = Heroes.GameMasters.GameMaster.Players.Players;


namespace Heroes.Genres.Genre;

public interface IGenre
{
    static readonly String EmptyString = "";
    static readonly String SpaceString = " ";
    static readonly String DescriptionString = "Description";
    static readonly String CategoryString = "Category";
    static readonly String ConstructorString = "Constructor";
    static readonly String InitializorString = "Initializor";
    static readonly String AccessorString = "Accessor";
    static readonly String TestCaseIdString = "TestCaseId";
    static readonly String TestCaseDataString = "TestCaseData";
    static readonly String GenreString = "Genre";
    static readonly String KeyString = "Key";
    static readonly String UnknownString = "Unknown";
    static readonly String CustomString = "Custom";
    static readonly String AlternateString = "Alternate";
    static readonly String CustomGenreString = CustomString + SpaceString + UnknownString;
    static readonly String CustomGenreKeyString = CustomGenreString + SpaceString + KeyString;
    static readonly String AlternateCustomGenreKeyString = AlternateString + SpaceString + CustomGenreKeyString;
    static readonly String Genre1String = GenreString + SpaceString + "1";
    static readonly String UnknownGenre1String = UnknownString + SpaceString + Genre1String;
    static readonly String Genre2String = GenreString + SpaceString + "2";
    static readonly String UnknownGenre2String = UnknownString + SpaceString + Genre2String;
    public static readonly String DefaultKey = UnknownString + SpaceString + GenreString + SpaceString + KeyString;
    public static readonly String DefaultName = UnknownString + SpaceString + GenreString;
    static readonly String CampaignString = "Campaign";
    static readonly String Campaign1String = CampaignString + SpaceString + "1";
    public static void INIT(IGenre Genre)
    {
        Genre.Key = DefaultKey;
        Genre.Name = DefaultName;
    }
    public static void INIT(IGenre Genre, String Name)
    {
        INIT(Genre: Genre, Key: Name + SpaceString + KeyString, Name: Name);
    }
    public static void INIT(IGenre Genre, String Key, String? Name = null)
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
        Campaigns.Campaigns temp = new();
        Campaigns.Campaigns campaigns = new();
        campaigns.Clear();
        foreach (KeyValuePair<string, Campaign> pair in Heroes.Campaigns)
        {
            if (pair.Value.GenreKeys.Contains(Genre.Key)) campaigns.Add(pair.Value);
        }
        return new(campaigns, ref temp);
    }
    public static PlayerKeySet PLAYER_KEYS(IGenre Genre, Heroes Heroes)
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
    public static GameMasterKeySet GAME_MASTER_KEYS(IGenre Genre, Heroes Heroes)
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
    private static readonly Heroes heroes = new();
    private static _Campaigns campaigns = heroes.Campaigns;
    private static _Players players = heroes.Players;
    private static _GameMasters gameMasters = heroes.GameMasters;
    private static int counter = 0;
    static readonly Dictionary<String, Dictionary<String, Object[]>> TEST_CASE_DATA = new(){
     { nameof(GenreTests.NullConstructorTest),
            new(){ {
                    DescriptionString, [EmptyString] }, { CategoryString, [ConstructorString] }, { TestCaseIdString, [(counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            //new CampaignKeySet(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            //new PlayerKeySet(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            //new GameMasterKeySet(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.NullInitializorTest),
            new(){ {
                    DescriptionString, [EmptyString] }, { CategoryString, [InitializorString] }, { TestCaseIdString, [(counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.KeyConstructorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [ConstructorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            CustomGenreKeyString, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.KeyInitializorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [InitializorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            CustomGenreKeyString, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.NameConstructorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [ConstructorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            CustomGenreKeyString, CustomGenreString,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.NameInitializorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [InitializorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            CustomGenreKeyString, CustomGenreString,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.KeyNameConstructorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [ConstructorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            AlternateCustomGenreKeyString, CustomGenreString,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.KeyNameInitializorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [InitializorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            AlternateCustomGenreKeyString, CustomGenreString,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.IndexConstructorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [ConstructorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            1, Genre1String, UnknownGenre1String,
                            new CampaignKeySet(Campaigns: new([new Campaign(Key: Campaign1String)]), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            2, Genre2String, UnknownGenre2String,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.IndexInitializorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [InitializorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            1, Genre1String, UnknownGenre1String,
                            new CampaignKeySet(Campaigns: new([new Campaign(Key: Campaign1String)]), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            2, Genre2String, UnknownGenre2String,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.CopyConstructorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [ConstructorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            AlternateCustomGenreKeyString, CustomGenreString,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.CopyInitializorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [InitializorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            AlternateCustomGenreKeyString, CustomGenreString,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            IGenre.DefaultKey, IGenre.DefaultName,
                            //new CampaignKeySet(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            //new PlayerKeySet(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            //new GameMasterKeySet(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.GetKeyAccessorTest),
            new(){ {
                    DescriptionString, [EmptyString] }, { CategoryString, [AccessorString] }, { TestCaseIdString, [(counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            IGenre.DefaultKey
                            )}
                } }
        },
        { nameof(GenreTests.SetKeyAccessorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [AccessorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            Genre1String, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new([new Campaign(Key: Campaign1String)]), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            CustomGenreKeyString, IGenre.DefaultName,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.GetNameAccessorTest),
            new(){ {
                    DescriptionString, [EmptyString] }, { CategoryString, [AccessorString] }, { TestCaseIdString, [(counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            IGenre.DefaultName
                            )}
                } }
        },
        { nameof(GenreTests.SetNameAccessorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [AccessorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            IGenre.DefaultKey, UnknownGenre1String,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            ),
                        new(
                            IGenre.DefaultKey, CustomGenreString,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        },
        { nameof(GenreTests.GetCampaignKeysAccessorTest),
            new(){ {
                    DescriptionString, [EmptyString, EmptyString] }, { CategoryString, [AccessorString] }, { TestCaseIdString, [(counter++).ToString(), (counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            IGenre.DefaultKey,
                            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns)
                            ),
                        new(
                            Genre1String,
                            new CampaignKeySet(Campaigns: new([new Campaign(Key: Campaign1String)]), MasterCampaigns: ref campaigns)
                            )}
                } }
        },
        { nameof(GenreTests.GetPlayerKeysAccessorTest),
            new(){ {
                    DescriptionString, [EmptyString] }, { CategoryString, [AccessorString] }, { TestCaseIdString, [(counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            IGenre.DefaultKey,
                            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players)
                            )}
                } }
        },
        { nameof(GenreTests.GetGameMasterKeysAccessorTest),
            new(){ {
                    DescriptionString, [EmptyString] }, { CategoryString, [AccessorString] }, { TestCaseIdString, [(counter++).ToString()] }, { TestCaseDataString,
                    new TestCaseData[] {
                        new(
                            IGenre.DefaultKey,
                            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                            )}
                } }
        }
    };
}