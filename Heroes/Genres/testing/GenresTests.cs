using NUnit.Framework;
using Heroes.Genres.Genre;
using Heroes.Campaigns;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.GameMasters;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using CampaignKeySet = Heroes.Campaigns.CampaignKeySet;
using PlayerKeySet = Heroes.GameMasters.GameMaster.Players.PlayerKeySet;
using GameMasterKeySet = Heroes.GameMasters.GameMasterKeySet;
using _Campaigns = Heroes.Campaigns.Campaigns;
using _Players = Heroes.GameMasters.GameMaster.Players.Players;
using _GameMasters = Heroes.GameMasters.GameMasters;
using _Genre = Heroes.Genres.Genre.Genre;
using _Genres = Heroes.Genres.Genres;
using Is = NUnit.Framework.Constraints.Is;
using NUnit.Framework.Constraints;

namespace Heroes.Genres;

public class GenresTests
{
    static readonly Heroes heroes = new();
    static _Campaigns campaigns = heroes.Campaigns;
    static _Players players = heroes.Players;
    static _GameMasters gameMasters = heroes.GameMasters;
    _Genres? genres = null;
    //expectedCampaignKeys = new(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
    CampaignKeySet? expectedCampaignKeys = null;
    //expectedPlayerKeys = new(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
    PlayerKeySet? expectedPlayerKeys = null;
    //expectedGameMasterKeys = new(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
    GameMasterKeySet? expectedGameMasterKeys = null;
    [SetUp]
    public void Setup()
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => expectedCampaignKeys = new(Campaigns: new(), MasterCampaigns: ref ICampaigns.CAMPAIGNS/*heroes.Campaigns*/));
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.InstanceOf<CampaignKeySet>());
        Assert.DoesNotThrow(() => expectedCampaignKeys.Clear());
        Assert.DoesNotThrow(() => expectedPlayerKeys = new(Players: new(), MasterPlayers: ref IPlayers.PLAYERS/*heroes.Players*/));
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.InstanceOf<PlayerKeySet>());
        Assert.DoesNotThrow(() => expectedPlayerKeys.Clear());
        Assert.DoesNotThrow(() => expectedGameMasterKeys = new(GameMasters: new(), MasterGameMasters: ref IGameMasters.GAME_MASTERS/*heroes.GameMasters*/));
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.InstanceOf<GameMasterKeySet>());
        Assert.DoesNotThrow(() => expectedGameMasterKeys.Clear());
    }
    static readonly TestCaseData[] NullConstructor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Genre 1", Name:  "Unknown Genre 1")]),
            //new CampaignKeySet(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            //new PlayerKeySet(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            //new GameMasterKeySet(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("NullConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(NullConstructor_Cases))]
    public void NullConstructorTest(_Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] NullInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1")]),
            new _Genres([new _Genre(Key: "Genre 1", Name:  "Unknown Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("NullInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(NullInitializor_Cases))]
    public void NullInitializorTest(_Genres preInitSetupGenres, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GeneratedCountConstructor_Cases = [
        new TestCaseData(
            0, new _Genres(new _Genre[0]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GeneratedCountConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            1, new _Genres([new _Genre(Key: "Genre 1", Name:  "Unknown Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GeneratedCountConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B"),
        new TestCaseData(
            2, new _Genres([new _Genre(Key: "Genre 1", Name:  "Unknown Genre 1"), new _Genre(Key: "Genre 2", Name:  "Unknown Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GeneratedCountConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "C")
    ];
    [Test]
    [TestCaseSource(nameof(GeneratedCountConstructor_Cases))]
    public void GeneratedCountConstructorTest(int caseExpectedCount, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(Count: caseExpectedCount));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GeneratedCountInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            0, new _Genres(new _Genre[0]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GeneratedCountInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            1, new _Genres([new _Genre(Key: "Genre 1", Name:  "Unknown Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GeneratedCountInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            2, new _Genres([new _Genre(Key: "Genre 1", Name:  "Unknown Genre 1"), new _Genre(Key: "Genre 2", Name:  "Unknown Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GeneratedCountInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "C")
    ];
    [Test]
    [TestCaseSource(nameof(GeneratedCountInitializor_Cases))]
    public void GeneratedCountInitializorTest(_Genres preInitSetupGenres, int caseExpectedCount, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Count: caseExpectedCount));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreElementsConstructor_Cases = [
        new TestCaseData(
            "Custom Genre 1 Key", "Custom Genre 1", new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreElementsConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            "Custom Genre 2 Key", "Custom Genre 2", new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreElementsConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreElementsConstructor_Cases))]
    public void GenreElementsConstructorTest(string caseExpectedKey, string caseExpectedName, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(Key: caseExpectedKey, Name: caseExpectedName));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreElementsInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            "Custom Genre 1 Key", "Custom Genre 1", new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreElementsInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            "Custom Genre 2 Key", "Custom Genre 2", new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreElementsInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreElementsInitializor_Cases))]
    public void GenreElementsInitializorTest(_Genres preInitSetupGenres, string caseExpectedKey, string caseExpectedName, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Key: caseExpectedKey, Name: caseExpectedName));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] KeyNameKeyValuePairConstructor_Cases = [
        new TestCaseData(
            new KeyValuePair<string,string>(key: "Custom Genre 1 Key", value: "Custom Genre 1"), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("KeyNameKeyValuePairConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new KeyValuePair<string,string>(key: "Custom Genre 2 Key", value: "Custom Genre 2"), new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("KeyNameKeyValuePairConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(KeyNameKeyValuePairConstructor_Cases))]
    public void KeyNameKeyValuePairConstructorTest(KeyValuePair<string, string> caseExpectedKeyValuePair, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(GenreKeyNamePair: caseExpectedKeyValuePair));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] KeyNameKeyValuePairInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new KeyValuePair<string,string>(key: "Custom Genre 1 Key", value: "Custom Genre 1"), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("KeyNameKeyValuePairInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new KeyValuePair<string,string>(key: "Custom Genre 2 Key", value: "Custom Genre 2"), new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("KeyNameKeyValuePairInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(KeyNameKeyValuePairInitializor_Cases))]
    public void KeyNameKeyValuePairInitializorTest(_Genres preInitSetupGenres, KeyValuePair<string, string> caseExpectedKeyValuePair, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(GenreKeyNamePair: caseExpectedKeyValuePair));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreKeyValuePairConstructor_Cases = [
        new TestCaseData(
            new KeyValuePair<string,IGenre>(key: "Custom Genre 1 Key", value: new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreKeyValuePairConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new KeyValuePair<string,IGenre>(key: "Custom Genre 2 Key", value: new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")), new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreKeyValuePairConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreKeyValuePairConstructor_Cases))]
    public void GenreKeyValuePairConstructorTest(KeyValuePair<string, IGenre> caseExpectedKeyValuePair, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(Genre: caseExpectedKeyValuePair));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreKeyValuePairInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new KeyValuePair<string,IGenre>(key: "Custom Genre 1 Key", value: new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreKeyValuePairInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new KeyValuePair<string,IGenre>(key: "Custom Genre 2 Key", value: new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")), new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreKeyValuePairInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreKeyValuePairInitializor_Cases))]
    public void GenreKeyValuePairInitializorTest(_Genres preInitSetupGenres, KeyValuePair<string, IGenre> caseExpectedKeyValuePair, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Genre: caseExpectedKeyValuePair));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreElementsDictionaryConstructor_Cases = [
        new TestCaseData(
            new Dictionary<string, string> { { "Custom Genre 1 Key", "Custom Genre 1"}, { "Custom Genre 2 Key", "Custom Genre 2"} },
            new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreElementsDictionaryConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new Dictionary<string, string> { { "Custom Genre 2 Key", "Custom Genre 2"} },
            new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreElementsDictionaryConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreElementsDictionaryConstructor_Cases))]
    public void GenreElementsDictionaryConstructorTest(Dictionary<string, string> caseExpectedDictionary, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(Dictionary: caseExpectedDictionary));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreElementsDictionaryInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new Dictionary<string, string> { { "Custom Genre 1 Key", "Custom Genre 1"}, { "Custom Genre 2 Key", "Custom Genre 2"} },
            new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreElementsDictionaryInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new Dictionary<string, string> { { "Custom Genre 2 Key", "Custom Genre 2"} },
            new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreElementsDictionaryInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreElementsDictionaryInitializor_Cases))]
    public void GenreElementsDictionaryInitializorTest(_Genres preInitSetupGenres, Dictionary<string, string> caseExpectedDictionary, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Dictionary: caseExpectedDictionary));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreConstructor_Cases = [
        new TestCaseData(
            new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2"), new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreConstructor_Cases))]
    public void GenreConstructorTest(_Genre caseExpectedGenre, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(Genre: caseExpectedGenre));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2"), new _Genres([new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreInitializor_Cases))]
    public void GenreInitializorTest(_Genres preInitSetupGenres, _Genre caseExpectedGenre, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Genre: caseExpectedGenre));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreArrayConstructor_Cases = [
        new TestCaseData(
            new _Genre[] { new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1") }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreArrayConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genre[] { new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2") }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreArrayConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreArrayConstructor_Cases))]
    public void GenreArrayConstructorTest(_Genre[] caseExpectedGenreArray, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(Array: caseExpectedGenreArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreArrayInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new _Genre[] { new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1") }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreArrayInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new _Genre[] { new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2") }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreArrayInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreArrayInitializor_Cases))]
    public void GenreArrayInitializorTest(_Genres preInitSetupGenres, _Genre[] caseExpectedGenreArray, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Array: caseExpectedGenreArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] KeyNameKeyValuePairArrayConstructor_Cases = [
        new TestCaseData(
            new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(key: "Custom Genre 1 Key", value:  "Custom Genre 1") }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("KeyNameKeyValuePairArrayConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(key: "Custom Genre 1 Key", value:  "Custom Genre 1"), new KeyValuePair<string, string>(key: "Custom Genre 2 Key", value:  "Custom Genre 2") }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("KeyNameKeyValuePairArrayConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(KeyNameKeyValuePairArrayConstructor_Cases))]
    public void KeyNameKeyValuePairArrayConstructorTest(KeyValuePair<string, string>[] caseExpectedKeyValuePairArray, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(GenreKeyNamePairArray: caseExpectedKeyValuePairArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] KeyNameKeyValuePairArrayInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(key: "Custom Genre 1 Key", value:  "Custom Genre 1") }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("KeyNameKeyValuePairArrayInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(key: "Custom Genre 1 Key", value:  "Custom Genre 1"), new KeyValuePair<string, string>(key: "Custom Genre 2 Key", value:  "Custom Genre 2") }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("KeyNameKeyValuePairArrayInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(KeyNameKeyValuePairArrayInitializor_Cases))]
    public void KeyNameKeyValuePairArrayInitializorTest(_Genres preInitSetupGenres, KeyValuePair<string, string>[] caseExpectedKeyValuePairArray, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(GenreKeyNamePairArray: caseExpectedKeyValuePairArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreKeyValuePairArrayConstructor_Cases = [
        new TestCaseData(
            new KeyValuePair<string, IGenre>[] { new KeyValuePair<string, IGenre>(key: "Custom Genre 1 Key", value:  new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")) }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreKeyValuePairArrayConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new KeyValuePair<string, IGenre>[] { new KeyValuePair<string, IGenre>(key: "Custom Genre 1 Key", value:  new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")), new KeyValuePair<string, IGenre>(key: "Custom Genre 2 Key", value:  new _Genre(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")) }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreKeyValuePairArrayConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreKeyValuePairArrayConstructor_Cases))]
    public void GenreKeyValuePairArrayConstructorTest(KeyValuePair<string, IGenre>[] caseExpectedKeyValuePairArray, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(Array: caseExpectedKeyValuePairArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreKeyValuePairArrayInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new KeyValuePair<string, IGenre>[] { new KeyValuePair<string, IGenre>(key: "Custom Genre 1 Key", value:  new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")) }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreKeyValuePairArrayInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new KeyValuePair<string, IGenre>[] { new KeyValuePair<string, IGenre>(key: "Custom Genre 1 Key", value:  new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")), new KeyValuePair<string, IGenre>(key: "Custom Genre 2 Key", value:  new _Genre(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")) }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreKeyValuePairArrayInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreKeyValuePairArrayInitializor_Cases))]
    public void GenreKeyValuePairArrayInitializorTest(_Genres preInitSetupGenres, KeyValuePair<string, IGenre>[] caseExpectedKeyValuePairArray, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Array: caseExpectedKeyValuePairArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreDictionaryConstructor_Cases = [
        new TestCaseData(
            new Dictionary<string, _Genre> { { "Custom Genre 1 Key", new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")} }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreDictionaryConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new Dictionary<string, _Genre> { { "Custom Genre 1 Key", new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")}, { "Custom Genre 2 Key", new _Genre(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")} }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreDictionaryConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreDictionaryConstructor_Cases))]
    public void GenreDictionaryConstructorTest(Dictionary<string, _Genre> caseExpectedGenreDictionary, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(Dictionary: caseExpectedGenreDictionary));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreDictionaryInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new Dictionary<string, _Genre> { { "Custom Genre 1 Key", new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")} }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreDictionaryInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new Dictionary<string, _Genre> { { "Custom Genre 1 Key", new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")}, { "Custom Genre 2 Key", new _Genre(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")} }, new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreDictionaryInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(GenreDictionaryInitializor_Cases))]
    public void GenreDictionaryInitializorTest(_Genres preInitSetupGenres, Dictionary<string, _Genre> caseExpectedGenreDictionary, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Dictionary: caseExpectedGenreDictionary));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] CopyConstructor_Cases = [
        new TestCaseData(
            new _Genres(Dictionary: new Dictionary<string, _Genre> { { "Custom Genre 1 Key", new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")} }), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("CopyConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres(Dictionary: new Dictionary<string, _Genre> { { "Custom Genre 1 Key", new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")}, { "Custom Genre 2 Key", new _Genre(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")} }), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("CopyConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(CopyConstructor_Cases))]
    public void CopyConstructorTest(_Genres caseExpectedOriginalGenres, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new(Original: caseExpectedOriginalGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] CopyInitializor_Cases = [
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new _Genres(Dictionary: new Dictionary<string, _Genre> { { "Custom Genre 1 Key", new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")} }), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("CopyInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            new _Genres([new _Genre(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new _Genre(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
            new _Genres(Dictionary: new Dictionary<string, _Genre> { { "Custom Genre 1 Key", new _Genre(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")}, { "Custom Genre 2 Key", new _Genre(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")} }), new _Genres([new _Genre(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new _Genre(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("CopyInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(CopyInitializor_Cases))]
    public void CopyInitializorTest(_Genres preInitSetupGenres, _Genres caseExpectedOriginalGenres, _Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(preInitSetupGenres, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = new((IGenres)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Original: caseExpectedOriginalGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] DefaultGenresCollection_Cases = [
        new TestCaseData(
            new _Genres([
                new _Genre(Key: "Unknown", Name:  "Unknown"),
                new _Genre(Key: "Fantasy", Name:  "Fantasy"),
                new _Genre(Key: "Western", Name:  "Western"),
                new _Genre(Key: "Pulp Fiction", Name:  "Pulp Fiction"),
                new _Genre(Key: "Modern", Name:  "Modern"),
                new _Genre(Key: "Star Hero", Name:  "Star Hero"),
                new _Genre(Key: "Champions", Name:  "Champions"),
                new _Genre(Key: "Custom", Name:  "Custom")
            ]),
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("DefaultGenresCollectionTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(DefaultGenresCollection_Cases))]
    public void DefaultGenresCollectionTest(_Genres caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genres = IGenres.GENRES);
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
}