using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using NUnit.Framework;

namespace Heroes.Genres;

public class GenresTests
{
    Heroes? heroes = null;
    KeyValuePair<String, Genre.IGenre>? genrePair = null;
    Genres? genres = null;
    GenreKeySet? genreKeySet = null;
    int? expectedSetupGenreCount = null;
    String[]? expectedSetupGenreKeys = null;
    Dictionary<String, String>? expectedSetupGenreNames = null;
    int? expectedGenreCount = null;
    String[]? expectedGenreKeys = null;
    Dictionary<String, String>? expectedGenreNames = null;
    //expectedCampaignKeys = new(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
    Campaigns.CampaignKeySet? expectedCampaignKeys = null;
    //expectedPlayerKeys = new(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
    GameMasters.GameMaster.Players.PlayerKeySet? expectedPlayerKeys = null;
    //expectedGameMasterKeys = new(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
    GameMasters.GameMasterKeySet? expectedGameMasterKeys = null;
    [SetUp]
    public void Setup()
    {
        Assert.DoesNotThrow(() => heroes = new());
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

    [Test]
    public void NullConstructorTest()
    {
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> { { expectedGenreKeys[0], "Unknown Genre 1" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new());
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedSetupGenreCount = 2;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" } };
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> { { expectedGenreKeys[0], "Unknown Genre 1" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genres.Init());
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GeneratedCountConstructorTest()
    {
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre 1" },
            { expectedGenreKeys[1], "Unknown Genre 2" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GeneratedCountInitializorTest()
    {
        expectedSetupGenreCount = 3;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2", "Genre 3"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" },
            { expectedSetupGenreKeys[2], "Unknown Genre 3" } };
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre 1" },
            { expectedGenreKeys[1], "Unknown Genre 2" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genres.Init(Count: (int)expectedGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreElementsConstructorTest()
    {
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]]));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreElementsInitializorTest()
    {
        expectedSetupGenreCount = 2;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" } };
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genres.Init(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]]));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreKeyValuePairConstructorTest()
    {
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genrePair = new(key: expectedGenreKeys[0], value: new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])));
        Assert.That(genrePair, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Genre: (KeyValuePair<String, Genre.IGenre>)genrePair));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreKeyValuePairInitializorTest()
    {
        expectedSetupGenreCount = 2;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" } };
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genrePair = new(key: expectedGenreKeys[0], value: new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])));
        Assert.That(genrePair, Is.Not.Null);
        Assert.DoesNotThrow(() => genres.Init(Genre: (KeyValuePair<String, Genre.IGenre>)genrePair));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreElementsDictionaryConstructorTest()
    {
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Dictionary: new Dictionary<string, string> {
            { expectedGenreKeys[0], expectedGenreNames[expectedGenreKeys[0]]},
            { expectedGenreKeys[1], expectedGenreNames[expectedGenreKeys[1]]}
        }));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreElementsDictionaryInitializorTest()
    {
        expectedSetupGenreCount = 3;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2", "Genre 3"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" },
            { expectedSetupGenreKeys[2], "Unknown Genre 3" } };
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genres.Init(Dictionary: new Dictionary<string, string> {
            { expectedGenreKeys[0], expectedGenreNames[expectedGenreKeys[0]]},
            { expectedGenreKeys[1], expectedGenreNames[expectedGenreKeys[1]]}
        }));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreConstructorTest()
    {
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Genre: new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreInitializorTest()
    {
        expectedSetupGenreCount = 2;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" } };
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genres.Init(Genre: new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreArrayConstructorTest()
    {
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Array: [
            new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]]),
            new Genre.Genre(Key: expectedGenreKeys[1], Name: expectedGenreNames[expectedGenreKeys[1]])]));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreArrayInitializorTest()
    {
        expectedSetupGenreCount = 3;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2", "Genre 3"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" },
            { expectedSetupGenreKeys[2], "Unknown Genre 3" } };
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genres.Init(Array: [
            new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]]),
            new Genre.Genre(Key: expectedGenreKeys[1], Name: expectedGenreNames[expectedGenreKeys[1]])]));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreKeyValuePairArrayConstructorTest()
    {
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Array: new KeyValuePair<string, Genre.IGenre>[] {
            new KeyValuePair<string, Genre.IGenre>(
                key: expectedGenreKeys[0],
                value: new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])
                ),
            new KeyValuePair<string, Genre.IGenre>(
                key: expectedGenreKeys[1],
                value: new Genre.Genre(Key: expectedGenreKeys[1], Name: expectedGenreNames[expectedGenreKeys[1]])
                )}));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreKeyValuePairArrayInitializorTest()
    {
        expectedSetupGenreCount = 3;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2", "Genre 3"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" },
            { expectedSetupGenreKeys[2], "Unknown Genre 3" } };
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genres.Init(Array: new KeyValuePair<string, Genre.IGenre>[] {
            new KeyValuePair<string, Genre.IGenre>(
                key: expectedGenreKeys[0],
                value: new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])
                ),
            new KeyValuePair<string, Genre.IGenre>(
                key: expectedGenreKeys[1],
                value: new Genre.Genre(Key: expectedGenreKeys[1], Name: expectedGenreNames[expectedGenreKeys[1]])
                )}));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreDictionaryConstructorTest()
    {
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Dictionary: new Dictionary<string, Genre.Genre> {
            { expectedGenreKeys[0], new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])},
            { expectedGenreKeys[1], new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[1]])}
        }));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreDictionaryInitializorTest()
    {
        expectedSetupGenreCount = 3;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2", "Genre 3"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" },
            { expectedSetupGenreKeys[2], "Unknown Genre 3" } };
        expectedGenreCount = 2;
        expectedGenreKeys = ["Genre 1", "Genre 2"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genres.Init(Dictionary: new Dictionary<string, Genre.Genre> {
            { expectedGenreKeys[0], new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])},
            { expectedGenreKeys[1], new Genre.Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[1]])}
        }));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Original: new Genres(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedSetupGenreCount = 2;
        expectedSetupGenreKeys = ["Genre 1", "Genre 2"];
        expectedSetupGenreNames = new Dictionary<String, String> {
            { expectedSetupGenreKeys[0], "Unknown Genre 1" },
            { expectedSetupGenreKeys[1], "Unknown Genre 2" } };
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new(Count: (int)expectedSetupGenreCount));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedSetupGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedSetupGenreKeys[index]), Is.True);
            Assert.That(genres[expectedSetupGenreKeys[index]].Key, Is.EqualTo(expectedSetupGenreKeys[index]));
            Assert.That(genres[expectedSetupGenreKeys[index]].Name, Is.EqualTo(expectedSetupGenreNames[expectedSetupGenreKeys[index]]));
        }
        Assert.DoesNotThrow(() => genres.Init(Original: new Genres(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void DefaultGenresCollectionTest()
    {
        int expectedGenreCount = 8;
        String[] expectedGenreKeys = ["Unknown",
            "Fantasy",
            "Western",
            "Pulp Fiction",
            "Modern",
            "Star Hero",
            "Champions",
            "Custom"];
        Dictionary<String, String> expectedGenreNames = new()
        {
            { expectedGenreKeys[0], "Unknown" },
            { expectedGenreKeys[1], "Fantasy" },
            { expectedGenreKeys[2], "Western" },
            { expectedGenreKeys[3], "Pulp Fiction" },
            { expectedGenreKeys[4], "Modern" },
            { expectedGenreKeys[5], "Star Hero" },
            { expectedGenreKeys[6], "Champions" },
            { expectedGenreKeys[7], "Custom" } };
        Assert.That(IGenres.GENRES, Is.InstanceOf<Genres>());
        Assert.That(IGenres.GENRES, Is.Not.Null);
        Assert.That(IGenres.GENRES.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < IGenres.GENRES.Count; index++)
        {
            Assert.That(IGenres.GENRES.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(IGenres.GENRES.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(IGenres.GENRES[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(IGenres.GENRES[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
    [Test]
    public void GenreKeySetConstructorTest()
    {
        expectedGenreKeys = ["Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"];
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genreKeySet = new(IGenres.GENRES, ref IGenres.GENRES));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Count, Is.EqualTo(expectedGenreKeys.Length));
        for (int index = 0; index < genreKeySet.Count; index++)
        {
            Assert.That(genreKeySet.Keys[index], Is.EqualTo(expectedGenreKeys[index]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenreKeySetConstructorReturnTest()
    {
        expectedGenreKeys = ["Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"];
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = new());
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.DoesNotThrow(() => genres.Clear());
        Assert.DoesNotThrow(() => genreKeySet = new(IGenres.GENRES, ref genres));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Count, Is.EqualTo(expectedGenreKeys.Length));
        for (int index = 0; index < genreKeySet.Count; index++)
        {
            Assert.That(genreKeySet.Keys[index], Is.EqualTo(expectedGenreKeys[index]));
        }
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(IGenres.GENRES.Count));
        Assert.That(genreKeySet.Count, Is.EqualTo(IGenres.GENRES.Count));
        foreach (String key in IGenres.GENRES.Keys)
        {
            Assert.That(genreKeySet.Keys.Contains(key), Is.True);
            Assert.That(genres.ContainsKey(key), Is.True);
            Assert.That(genres[key].Key, Is.EqualTo(IGenres.GENRES[key].Key));
            Assert.That(genres[key].Name, Is.EqualTo(IGenres.GENRES[key].Name));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyGenreKeySetConstructorTest()
    {
        expectedGenreKeys = ["Unknown", "Fantasy", "Western", "Pulp Fiction", "Modern", "Star Hero", "Champions", "Custom"];
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genreKeySet = new(Original: new GenreKeySet(IGenres.GENRES, ref IGenres.GENRES)));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Count, Is.EqualTo(expectedGenreKeys.Length));
        for (int index = 0; index < genreKeySet.Count; index++)
        {
            Assert.That(genreKeySet.Keys[index], Is.EqualTo(expectedGenreKeys[index]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenresAccessorTest()
    {
        expectedGenreCount = 8;
        expectedGenreKeys = ["Unknown",
            "Fantasy",
            "Western",
            "Pulp Fiction",
            "Modern",
            "Star Hero",
            "Champions",
            "Custom"];
        expectedGenreNames = new()
        {
            { expectedGenreKeys[0], "Unknown" },
            { expectedGenreKeys[1], "Fantasy" },
            { expectedGenreKeys[2], "Western" },
            { expectedGenreKeys[3], "Pulp Fiction" },
            { expectedGenreKeys[4], "Modern" },
            { expectedGenreKeys[5], "Star Hero" },
            { expectedGenreKeys[6], "Champions" },
            { expectedGenreKeys[7], "Custom" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genreKeySet = new(IGenres.GENRES, ref IGenres.GENRES));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.DoesNotThrow(() => genres = genreKeySet.Genres(IGenres.GENRES));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenresAccessorWithMissingThrownTest()
    {
        expectedGenreCount = 7;
        expectedGenreKeys = ["Unknown",
            "Fantasy",
            "Western",
            "Pulp Fiction",
            "Modern",
            "Star Hero",
            "Champions"];
        expectedGenreNames = new()
        {
            { expectedGenreKeys[0], "Unknown" },
            { expectedGenreKeys[1], "Fantasy" },
            { expectedGenreKeys[2], "Western" },
            { expectedGenreKeys[3], "Pulp Fiction" },
            { expectedGenreKeys[4], "Modern" },
            { expectedGenreKeys[5], "Star Hero" },
            { expectedGenreKeys[6], "Champions" }};
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genreKeySet = new(IGenres.GENRES, ref IGenres.GENRES));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Genres missing = new(Original: IGenres.GENRES);
        missing.Remove("Custom");
        Assert.Throws<ArgumentOutOfRangeException>(() => genres = genreKeySet.Genres(missing));
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GenresAccessorWithMissingNotThrownTest()
    {
        expectedGenreCount = 7;
        expectedGenreKeys = ["Unknown",
            "Fantasy",
            "Western",
            "Pulp Fiction",
            "Modern",
            "Star Hero",
            "Champions"];
        expectedGenreNames = new()
        {
            { expectedGenreKeys[0], "Unknown" },
            { expectedGenreKeys[1], "Fantasy" },
            { expectedGenreKeys[2], "Western" },
            { expectedGenreKeys[3], "Pulp Fiction" },
            { expectedGenreKeys[4], "Modern" },
            { expectedGenreKeys[5], "Star Hero" },
            { expectedGenreKeys[6], "Champions" }};
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genreKeySet = new(IGenres.GENRES, ref IGenres.GENRES));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Genres missing = new(Original: IGenres.GENRES);
        missing.Remove("Custom");
        Assert.DoesNotThrow(() => genres = genreKeySet.Genres(missing, false));
        Assert.That(genres, Is.InstanceOf<Genres>());
        Assert.That(genres, Is.Not.Null);
        Assert.That(genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < genres.Count; index++)
        {
            Assert.That(genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeysAccessorTest()
    {
        expectedGenreCount = 1;
        expectedGenreKeys = ["Genre 1"];
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genreKeySet = new(new(), ref IGenres.GENRES));
        Assert.That(genreKeySet, Is.InstanceOf<GenreKeySet>());
        Assert.That(genreKeySet, Is.Not.Null);
        Assert.That(genreKeySet.Keys.Count, Is.EqualTo(expectedGenreCount));
        foreach (String key in genreKeySet.Keys)
        {
            Assert.That(expectedGenreKeys.Contains(key), Is.True);
        }
        Assert.That(genres.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genres.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genres.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genres.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genres.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genres.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
}