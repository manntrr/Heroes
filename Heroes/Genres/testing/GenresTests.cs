using NUnit.Framework;
using NUnit.Framework.Constraints;
using Heroes.Genres.Genre;
using Heroes.Campaigns;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.GameMasters;
using CampaignKeySet = Heroes.Campaigns.CampaignKeySet;
using PlayerKeySet = Heroes.GameMasters.GameMaster.Players.PlayerKeySet;
using GameMasterKeySet = Heroes.GameMasters.GameMasterKeySet;
using CampaignsObject = Heroes.Campaigns.Campaigns;
using PlayersObject = Heroes.GameMasters.GameMaster.Players.Players;
using GameMastersObject = Heroes.GameMasters.GameMasters;
using GenreObject = Heroes.Genres.Genre.Genre;
using GenresObject = Heroes.Genres.Genres;
using GenresInterfaceObject = Heroes.Genres.IGenres;
using Is = NUnit.Framework.Constraints.Is;
using HeroesObject = Heroes.Heroes;

namespace Heroes.Genres;

public class GenresTests
{
    static readonly HeroesObject heroes = new();
    static CampaignsObject campaigns = heroes.Campaigns;
    static PlayersObject players = heroes.Players;
    static GameMastersObject gameMasters = heroes.GameMasters;
    GenresObject? genres = null;
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
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
    static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NullConstructorTestCases))]
    public void NullConstructorTest(GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] NullInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NullInitializorTestCases))]
    public void NullInitializorTest(GenresObject preInitSetupGenres, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GeneratedCountConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GeneratedCountConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GeneratedCountConstructorTestCases))]
    public void GeneratedCountConstructorTest(int caseExpectedCount, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(Count: caseExpectedCount));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GeneratedCountInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GeneratedCountInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GeneratedCountInitializorTestCases))]
    public void GeneratedCountInitializorTest(GenresObject preInitSetupGenres, int caseExpectedCount, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Count: caseExpectedCount));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreElementsConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreElementsConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreElementsConstructorTestCases))]
    public void GenreElementsConstructorTest(string caseExpectedKey, string caseExpectedName, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(Key: caseExpectedKey, Name: caseExpectedName));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreElementsInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreElementsInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreElementsInitializorTestCases))]
    public void GenreElementsInitializorTest(GenresObject preInitSetupGenres, string caseExpectedKey, string caseExpectedName, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Key: caseExpectedKey, Name: caseExpectedName));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] KeyNameKeyValuePairConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KeyNameKeyValuePairConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KeyNameKeyValuePairConstructorTestCases))]
    public void KeyNameKeyValuePairConstructorTest(KeyValuePair<string, string> caseExpectedKeyValuePair, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(GenreKeyNamePair: caseExpectedKeyValuePair));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] KeyNameKeyValuePairInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KeyNameKeyValuePairInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KeyNameKeyValuePairInitializorTestCases))]
    public void KeyNameKeyValuePairInitializorTest(GenresObject preInitSetupGenres, KeyValuePair<string, string> caseExpectedKeyValuePair, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(GenreKeyNamePair: caseExpectedKeyValuePair));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreKeyValuePairConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreKeyValuePairConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreKeyValuePairConstructorTestCases))]
    public void GenreKeyValuePairConstructorTest(KeyValuePair<string, GenreObject> caseExpectedKeyValuePair, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(Genre: caseExpectedKeyValuePair));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreKeyValuePairInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreKeyValuePairInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreKeyValuePairInitializorTestCases))]
    public void GenreKeyValuePairInitializorTest(GenresObject preInitSetupGenres, KeyValuePair<string, GenreObject> caseExpectedKeyValuePair, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Genre: caseExpectedKeyValuePair));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreElementsDictionaryConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreElementsDictionaryConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreElementsDictionaryConstructorTestCases))]
    public void GenreElementsDictionaryConstructorTest(Dictionary<string, string> caseExpectedDictionary, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(Dictionary: caseExpectedDictionary));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreElementsDictionaryInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreElementsDictionaryInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreElementsDictionaryInitializorTestCases))]
    public void GenreElementsDictionaryInitializorTest(GenresObject preInitSetupGenres, Dictionary<string, string> caseExpectedDictionary, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Dictionary: caseExpectedDictionary));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreConstructorTestCases))]
    public void GenreConstructorTest(GenreObject caseExpectedGenre, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(Genre: caseExpectedGenre));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreInitializorTestCases))]
    public void GenreInitializorTest(GenresObject preInitSetupGenres, GenreObject caseExpectedGenre, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Genre: caseExpectedGenre));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreArrayConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreArrayConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreArrayConstructorTestCases))]
    public void GenreArrayConstructorTest(GenreObject[] caseExpectedGenreArray, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(Array: caseExpectedGenreArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreArrayInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreArrayInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreArrayInitializorTestCases))]
    public void GenreArrayInitializorTest(GenresObject preInitSetupGenres, GenreObject[] caseExpectedGenreArray, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Array: caseExpectedGenreArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] KeyNameKeyValuePairArrayConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KeyNameKeyValuePairArrayConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KeyNameKeyValuePairArrayConstructorTestCases))]
    public void KeyNameKeyValuePairArrayConstructorTest(KeyValuePair<string, string>[] caseExpectedKeyValuePairArray, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(GenreKeyNamePairArray: caseExpectedKeyValuePairArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] KeyNameKeyValuePairArrayInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KeyNameKeyValuePairArrayInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KeyNameKeyValuePairArrayInitializorTestCases))]
    public void KeyNameKeyValuePairArrayInitializorTest(GenresObject preInitSetupGenres, KeyValuePair<string, string>[] caseExpectedKeyValuePairArray, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(GenreKeyNamePairArray: caseExpectedKeyValuePairArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreKeyValuePairArrayConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreKeyValuePairArrayConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreKeyValuePairArrayConstructorTestCases))]
    public void GenreKeyValuePairArrayConstructorTest(KeyValuePair<string, GenreObject>[] caseExpectedKeyValuePairArray, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(Array: caseExpectedKeyValuePairArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreKeyValuePairArrayInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreKeyValuePairArrayInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreKeyValuePairArrayInitializorTestCases))]
    public void GenreKeyValuePairArrayInitializorTest(GenresObject preInitSetupGenres, KeyValuePair<string, GenreObject>[] caseExpectedKeyValuePairArray, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Array: caseExpectedKeyValuePairArray));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreDictionaryConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreDictionaryConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreDictionaryConstructorTestCases))]
    public void GenreDictionaryConstructorTest(Dictionary<string, GenreObject> caseExpectedGenreDictionary, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(Dictionary: caseExpectedGenreDictionary));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenreDictionaryInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GenreDictionaryInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GenreDictionaryInitializorTestCases))]
    public void GenreDictionaryInitializorTest(GenresObject preInitSetupGenres, Dictionary<string, GenreObject> caseExpectedGenreDictionary, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Dictionary: caseExpectedGenreDictionary));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] CopyConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyConstructorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyConstructorTestCases))]
    public void CopyConstructorTest(GenresObject caseExpectedOriginalGenres, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new(Original: caseExpectedOriginalGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] CopyInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyInitializorTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyInitializorTestCases))]
    public void CopyInitializorTest(GenresObject preInitSetupGenres, GenresObject caseExpectedOriginalGenres, GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
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
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = new((GenresInterfaceObject)preInitSetupGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, preInitSetupGenres));
        //Assert.That(genres, Is.Not.GenresEqual(heroes, caseExpectedGenres));
        Assert.DoesNotThrow(() => genres.Init(Original: caseExpectedOriginalGenres));
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] DefaultGenresCollectionTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(DefaultGenresCollectionTest), GenresInterfaceObject.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(DefaultGenresCollectionTestCases))]
    public void DefaultGenresCollectionTest(GenresObject caseExpectedGenres, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<HeroesObject>());
        Assert.DoesNotThrow(() => genres = GenresInterfaceObject.GENRES);
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.InstanceOf<GenresObject>());
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
}