using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Is = NUnit.Framework.Constraints.Is;
using _Campaigns = Heroes.Campaigns.Campaigns;
using _Players = Heroes.GameMasters.GameMaster.Players.Players;
using _GameMasters = Heroes.GameMasters.GameMasters;
using NUnit.Framework.Constraints;
using Heroes.Campaigns.Campaign;

namespace Heroes.Genres.Genre;

public class GenreTests
{
    static readonly Heroes heroes = new();
    static _Campaigns campaigns = heroes.Campaigns;
    static _Players players = heroes.Players;
    static _GameMasters gameMasters = heroes.GameMasters;
    Genre? genre = null;
    [SetUp]
    public void Setup()
    {
    }
    static readonly TestCaseData[] NullConstructor_Cases = [
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            //new CampaignKeySet(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            //new PlayerKeySet(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            //new GameMasterKeySet(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("NullConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(NullConstructor_Cases))]
    public void NullConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedKey, Is.Not.Null);
            Assert.That(caseExpectedName, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] NullInitializor_Cases = [
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("NullInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(NullInitializor_Cases))]
    public void NullInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedKey, Is.Not.Null);
            Assert.That(caseExpectedName, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.Multiple(() =>
        {
            Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
            Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
            //Assert.That(genre, Is.Not.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
        Assert.DoesNotThrow(() => genre.Init());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] KeyConstructor_Cases = [
        new TestCaseData(
            "Custom Genre Key", IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("KeyConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("KeyConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    ];
    [Test]
    [TestCaseSource(nameof(KeyConstructor_Cases))]
    public void KeyConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] KeyInitializor_Cases = {
        new TestCaseData(
            "Custom Genre Key", IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("KeyInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("KeyInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(KeyInitializor_Cases))]
    public void KeyInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] NameConstructor_Cases = {
        new TestCaseData(
            "Custom Genre Key", "Custom Genre",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("NameConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("NameConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(NameConstructor_Cases))]
    public void NameConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Name: caseExpectedName));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] NameInitializor_Cases = {
        new TestCaseData(
            "Custom Genre Key", "Custom Genre",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("NameInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("NameInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(NameInitializor_Cases))]
    public void NameInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Name: caseExpectedName));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] KeyNameConstructor_Cases = {
        new TestCaseData(
            "Alternate Custom Genre Key", "Custom Genre",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("KeyNameConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("KeyNameConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(KeyNameConstructor_Cases))]
    public void KeyNameConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey, Name: caseExpectedName));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] KeyNameInitializor_Cases = {
        new TestCaseData(
            "Alternate Custom Genre Key", "Custom Genre",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("KeyNameInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("KeyNameInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(KeyNameInitializor_Cases))]
    public void KeyNameInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Key: caseExpectedKey, Name: caseExpectedName));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] IndexConstructor_Cases = {
        new TestCaseData(
            1, "Genre 1", "Unknown Genre 1",
            new CampaignKeySet(Campaigns: new([new Campaign(Key: "Campaign 1")]), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("IndexConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            2, "Genre 2", "Unknown Genre 2",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("IndexConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(IndexConstructor_Cases))]
    public void IndexConstructorTest(int givenIndex, string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: givenIndex));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] IndexInitializor_Cases = {
        new TestCaseData(
            1, "Genre 1", "Unknown Genre 1",
            new CampaignKeySet(Campaigns: new([new Campaign(Key: "Campaign 1")]), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("IndexInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            2, "Genre 2", "Unknown Genre 2",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("IndexInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(IndexInitializor_Cases))]
    public void IndexInitializorTest(int givenIndex, string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Index: givenIndex));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] CopyConstructor_Cases = {
        new TestCaseData(
            "Alternate Custom Genre Key", "Custom Genre",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("CopyConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("CopyConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(CopyConstructor_Cases))]
    public void CopyConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Genre: new(Key: caseExpectedKey, Name: caseExpectedName)));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] CopyInitializor_Cases = {
        new TestCaseData(
            "Alternate Custom Genre Key", "Custom Genre",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("CopyInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            IGenre.DefaultKey, IGenre.DefaultName,
            //new CampaignKeySet(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            //new PlayerKeySet(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            //new GameMasterKeySet(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("CopyInitializorTest").SetDescription("").SetCategory("Initializor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(CopyInitializor_Cases))]
    public void CopyInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Genre: new(Key: caseExpectedKey, Name: caseExpectedName)));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] GetKeyAccessor_Cases = {
        new TestCaseData(
            IGenre.DefaultKey
            ).SetName("GetKeyAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A")
    };
    [Test]
    [TestCaseSource(nameof(GetKeyAccessor_Cases))]
    public void GetKeyAccessorTest(string caseExpectedKey)
    {
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
    }
    static TestCaseData[] SetKeyAccessor_Cases = {
        new TestCaseData(
            "Genre 1", IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new([new Campaign(Key: "Campaign 1")]), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("SetKeyAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            "Custom Genre Key", IGenre.DefaultName,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("SetKeyAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(SetKeyAccessor_Cases))]
    public void SetKeyAccessorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Key = caseExpectedKey);
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] GetNameAccessor_Cases = {
        new TestCaseData(
            IGenre.DefaultName
            ).SetName("GetNameAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A")
    };
    [Test]
    [TestCaseSource(nameof(GetNameAccessor_Cases))]
    public void GetNameAccessorTest(string caseExpectedName)
    {
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreNameEqual(caseExpectedName));
    }
    static TestCaseData[] SetNameAccessor_Cases = {
        new TestCaseData(
            IGenre.DefaultKey, "Unknown Genre 1",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("SetNameAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A"),
        new TestCaseData(
            IGenre.DefaultKey, "Custom Genre",
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("SetNameAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(SetNameAccessor_Cases))]
    public void SetNameAccessorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Name = caseExpectedName);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static TestCaseData[] GetCampaignKeysAccessor_Cases = {
        new TestCaseData(
            IGenre.DefaultKey,
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns)
            ).SetName("GetCampaignKeysAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A"),
            new TestCaseData(
            "Genre 1",
            new CampaignKeySet(Campaigns: new([new Campaign(Key: "Campaign 1")]), MasterCampaigns: ref campaigns)
            ).SetName("GetCampaignKeysAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "B")
    };
    [Test]
    [TestCaseSource(nameof(GetCampaignKeysAccessor_Cases))]
    public void GetCampaignKeysAccessorTest(string caseExpectedKey, CampaignKeySet caseExpectedCampaignKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
    }
    static TestCaseData[] GetPlayerKeysAccessor_Cases = {
        new TestCaseData(
            IGenre.DefaultKey,
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players)
            ).SetName("GetPlayerKeysAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A")
    };
    [Test]
    [TestCaseSource(nameof(GetPlayerKeysAccessor_Cases))]
    public void GetPlayerKeysAccessorTest(string caseExpectedKey, PlayerKeySet caseExpectedPlayerKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
    }
    static TestCaseData[] GetGameMasterKeysAccessor_Cases = {
        new TestCaseData(
            IGenre.DefaultKey,
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
            ).SetName("GetGameMasterKeysAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A")
    };
    [Test]
    [TestCaseSource(nameof(GetGameMasterKeysAccessor_Cases))]
    public void GetGameMasterKeysAccessorTest(string caseExpectedKey, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
    }
}
