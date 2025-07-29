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

public class GenreKeySetTests
{
    static readonly Heroes heroes = new();
    static _Campaigns campaigns = heroes.Campaigns;
    static _Players players = heroes.Players;
    static _GameMasters gameMasters = heroes.GameMasters;
    _Genres? genres = null;
    GenreKeySet? genreKeySet = null;
    int? expectedGenreCount = null;
    String[]? expectedGenreKeys = null;
    Dictionary<String, String>? expectedGenreNames = null;
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
    static readonly TestCaseData[] GenreKeySetConstructor_Cases = [
        new TestCaseData(
            new _Genres((IGenres)IGenres.GENRES),
            new string[] {"Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"})
            .SetName("GenreKeySetConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(GenreKeySetConstructor_Cases))]
    public void GenreKeySetConstructorTest(_Genres caseGenres, string[] caseExpectedGenreKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseGenres, Is.Not.Null);
            Assert.That(caseExpectedGenreKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genreKeySet = new(IGenres.GENRES, ref caseGenres));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Count, Is.EqualTo(caseExpectedGenreKeys.Length));
        for (int index = 0; index < genreKeySet.Count; index++)
        {
            Assert.That(genreKeySet.Keys[index], Is.EqualTo(caseExpectedGenreKeys[index]));
        }
    }
    static readonly TestCaseData[] GenreKeySetConstructorReturn_Cases = [
        new TestCaseData(
            new _Genres((IGenres)IGenres.GENRES),
            new string[] {"Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"},
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenreKeySetConstructorReturnTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(GenreKeySetConstructorReturn_Cases))]
    public void GenreKeySetConstructorReturnTest(_Genres caseExpectedGenres, string[] caseExpectedKeyNames, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedKeyNames, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.That(caseExpectedGenres, Is.InstanceOf<_Genres>());
        Assert.DoesNotThrow(() => genres = new());
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.DoesNotThrow(() => genres.Clear());
        Assert.DoesNotThrow(() => genreKeySet = new(caseExpectedGenres, ref genres));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Count, Is.EqualTo(caseExpectedKeyNames.Length));
        for (int index = 0; index < genreKeySet.Count; index++)
        {
            Assert.That(genreKeySet.Keys[index], Is.EqualTo(caseExpectedKeyNames[index]));
        }
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] CopyGenreKeySetConstructor_Cases = [
        new TestCaseData(
            new _Genres((IGenres)IGenres.GENRES),
            new string[] {"Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"})
            .SetName("CopyGenreKeySetConstructorTest").SetDescription("").SetCategory("Constructor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(CopyGenreKeySetConstructor_Cases))]
    public void CopyGenreKeySetConstructorTest(_Genres caseGenres, string[] caseExpectedGenreKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseGenres, Is.Not.Null);
            Assert.That(caseExpectedGenreKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genreKeySet = new(Original: new GenreKeySet(IGenres.GENRES, ref caseGenres)));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Count, Is.EqualTo(caseExpectedGenreKeys.Length));
        for (int index = 0; index < genreKeySet.Count; index++)
        {
            Assert.That(genreKeySet.Keys[index], Is.EqualTo(caseExpectedGenreKeys[index]));
        }
    }
    static readonly TestCaseData[] GenresAccessor_Cases = [
        new TestCaseData(
            new _Genres((IGenres)IGenres.GENRES),
            new string[] {"Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"},
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenresAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(GenresAccessor_Cases))]
    public void GenresAccessorTest(_Genres caseExpectedGenres, string[] caseExpectedKeyNames, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedKeyNames, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.That(caseExpectedGenres, Is.InstanceOf<_Genres>());
        Assert.DoesNotThrow(() => genres = new());
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.DoesNotThrow(() => genres.Clear());
        Assert.DoesNotThrow(() => genreKeySet = new(caseExpectedGenres, ref genres));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Count, Is.EqualTo(caseExpectedKeyNames.Length));
        for (int index = 0; index < genreKeySet.Count; index++)
        {
            Assert.That(genreKeySet.Keys[index], Is.EqualTo(caseExpectedKeyNames[index]));
        }
        Assert.DoesNotThrow(() => genres = genreKeySet.Genres(IGenres.GENRES));
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] GenresAccessorWithMissingThrown_Cases = [
        new TestCaseData(
            new _Genres((IGenres)IGenres.GENRES),
            new string[] {"Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"},
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenresAccessorWithMissingThrownTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(GenresAccessorWithMissingThrown_Cases))]
    public void GenresAccessorWithMissingThrownTest(_Genres caseExpectedGenres, string[] caseExpectedKeyNames, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedKeyNames, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.That(caseExpectedGenres, Is.InstanceOf<_Genres>());
        Assert.DoesNotThrow(() => genres = new());
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.DoesNotThrow(() => genres.Clear());
        Assert.DoesNotThrow(() => genreKeySet = new(caseExpectedGenres, ref genres));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Count, Is.EqualTo(caseExpectedKeyNames.Length));
        for (int index = 0; index < genreKeySet.Count; index++)
        {
            Assert.That(genreKeySet.Keys[index], Is.EqualTo(caseExpectedKeyNames[index]));
        }
        _Genres missing = new(Original: IGenres.GENRES);
        missing.Remove("Custom");
        Assert.Throws<ArgumentOutOfRangeException>(() => genres = genreKeySet.Genres(missing));
    }
    static readonly TestCaseData[] GenresAccessorWithMissingNotThrown_Cases = [
        new TestCaseData(
            new _Genres((IGenres)IGenres.GENRES),
            new string[] {"Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"},
            new string[] {"Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions"},
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("GenresAccessorWithMissingNotThrownTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    [TestCaseSource(nameof(GenresAccessorWithMissingNotThrown_Cases))]
    public void GenresAccessorWithMissingNotThrownTest(_Genres caseExpectedGenres, string[] caseProvidedKeyNames, string[] caseExpectedKeyNames, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedGenres, Is.Not.Null);
            Assert.That(caseExpectedKeyNames, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.That(caseExpectedGenres, Is.InstanceOf<_Genres>());
        Assert.DoesNotThrow(() => genres = new());
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.DoesNotThrow(() => genres.Clear());
        Assert.DoesNotThrow(() => genreKeySet = new(caseExpectedGenres, ref genres));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Count, Is.EqualTo(caseProvidedKeyNames.Length));
        for (int index = 0; index < genreKeySet.Count; index++)
        {
            Assert.That(genreKeySet.Keys[index], Is.EqualTo(caseProvidedKeyNames[index]));
        }
        _Genres missing = new(Original: IGenres.GENRES);
        missing.Remove("Custom");
        caseExpectedGenres.Remove("Custom");
        Assert.DoesNotThrow(() => genres = genreKeySet.Genres(missing, false));
        Assert.That(genres, Is.InstanceOf<_Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres, Is.GenresEqual(heroes, caseExpectedGenres));
        Assert.Multiple(() =>
        {
            Assert.That(genres, Is.GenresCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genres, Is.GenresPlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genres, Is.GenresGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
    }
    static readonly TestCaseData[] KeysAccessor_Cases = [
        new TestCaseData(
            new _Genres((IGenres)IGenres.GENRES),
            new string[] {"Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"},
            new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
            new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
            new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
            .SetName("KeysAccessorTest").SetDescription("").SetCategory("Accessor").SetProperty("TestCaseId", "A")
    ];
    [Test]
    //[TestCaseSource(nameof(KeysAccessor_Cases))]//_Genres caseExpectedGenres, string[] caseExpectedKeyNames, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys
    public void KeysAccessorTest()
    {
        expectedGenreKeys = ["Genre 1"];
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genreKeySet = new(new(), ref IGenres.GENRES));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Keys.Count, Is.EqualTo(expectedGenreKeys.Length));
        foreach (String key in genreKeySet.Keys)
        {
            Assert.That(expectedGenreKeys.Contains(key), Is.True);
        }
    }
}