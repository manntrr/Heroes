using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Heroes.Campaigns;
using Heroes.GameMasters.GameMaster.Players.Player;
using Heroes.Genres;
using NUnit.Framework;

namespace Heroes.GameMasters.GameMaster.Players;

public class PlayersTests
{
    Heroes? heroes = null;
    KeyValuePair<String, Player.IPlayer>? PlayerPair = null;
    Players? Players = null;
    PlayerKeySet? PlayerKeySet = null;
    int? expectedSetupPlayerCount = null;
    String[]? expectedSetupPlayerKeys = null;
    Dictionary<String, String>? expectedSetupPlayerNames = null;
    int? expectedPlayerCount = null;
    String[]? expectedPlayerKeys = null;
    Dictionary<String, String>? expectedPlayerNames = null;
    String? expectedPlayerKey = null;
    String? expectedPlayerName = null;
    GenreKeySet? expectedPlayerGenreKeys = null;
    Genres.Genres? expectedPlayerGenres = null;
    // TODO: add campaign tests
    CampaignKeySet? expectedPlayerCampaignKeys = null;
    //expectedGameMasterKeys = new(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
    GameMasterKeySet? expectedGameMasterKeys = null;
    [SetUp]
    public void Setup()
    {
        Assert.DoesNotThrow(() => heroes = new());
        Assert.That(heroes, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => expectedGameMasterKeys = new(GameMasters: new(), MasterGameMasters: ref IGameMasters.GAME_MASTERS/*heroes.GameMasters*/));
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.InstanceOf<GameMasterKeySet>());
        Assert.DoesNotThrow(() => expectedGameMasterKeys.Clear());
    }

    [Test]
    public void NullConstructorTest()
    {
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> { { expectedPlayerKeys[0], "Unknown Player 1" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new());
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedSetupPlayerCount = 2;
        expectedSetupPlayerKeys = ["Player 1", "Player 2"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" } };
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> { { expectedPlayerKeys[0], "Unknown Player 1" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => Players.Init());
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GeneratedCountConstructorTest()
    {
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player 1" },
            { expectedPlayerKeys[1], "Unknown Player 2" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GeneratedCountInitializorTest()
    {
        expectedSetupPlayerCount = 3;
        expectedSetupPlayerKeys = ["Player 1", "Player 2", "Player 3"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" },
            { expectedSetupPlayerKeys[2], "Unknown Player 3" } };
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player 1" },
            { expectedPlayerKeys[1], "Unknown Player 2" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => Players.Init(Count: (int)expectedPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerElementsConstructorTest()
    {
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]]));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerElementsInitializorTest()
    {
        expectedSetupPlayerCount = 2;
        expectedSetupPlayerKeys = ["Player 1", "Player 2"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" } };
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => Players.Init(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]]));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerKeyValuePairConstructorTest()
    {
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => PlayerPair = new(key: expectedPlayerKeys[0], value: new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])));
        Assert.That(PlayerPair, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Player: (KeyValuePair<String, Player.IPlayer>)PlayerPair));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerKeyValuePairInitializorTest()
    {
        expectedSetupPlayerCount = 2;
        expectedSetupPlayerKeys = ["Player 1", "Player 2"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" } };
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => PlayerPair = new(key: expectedPlayerKeys[0], value: new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])));
        Assert.That(PlayerPair, Is.Not.Null);
        Assert.DoesNotThrow(() => Players.Init(Player: (KeyValuePair<String, Player.IPlayer>)PlayerPair));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerElementsDictionaryConstructorTest()
    {
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Dictionary: new Dictionary<string, string> {
            { expectedPlayerKeys[0], expectedPlayerNames[expectedPlayerKeys[0]]},
            { expectedPlayerKeys[1], expectedPlayerNames[expectedPlayerKeys[1]]}
        }));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerElementsDictionaryInitializorTest()
    {
        expectedSetupPlayerCount = 3;
        expectedSetupPlayerKeys = ["Player 1", "Player 2", "Player 3"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" },
            { expectedSetupPlayerKeys[2], "Unknown Player 3" } };
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => Players.Init(Dictionary: new Dictionary<string, string> {
            { expectedPlayerKeys[0], expectedPlayerNames[expectedPlayerKeys[0]]},
            { expectedPlayerKeys[1], expectedPlayerNames[expectedPlayerKeys[1]]}
        }));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerConstructorTest()
    {
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Player: new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerInitializorTest()
    {
        expectedSetupPlayerCount = 2;
        expectedSetupPlayerKeys = ["Player 1", "Player 2"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" } };
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => Players.Init(Player: new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerArrayConstructorTest()
    {
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Array: [
            new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]]),
            new Player.Player(Key: expectedPlayerKeys[1], Name: expectedPlayerNames[expectedPlayerKeys[1]])]));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerArrayInitializorTest()
    {
        expectedSetupPlayerCount = 3;
        expectedSetupPlayerKeys = ["Player 1", "Player 2", "Player 3"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" },
            { expectedSetupPlayerKeys[2], "Unknown Player 3" } };
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => Players.Init(Array: [
            new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]]),
            new Player.Player(Key: expectedPlayerKeys[1], Name: expectedPlayerNames[expectedPlayerKeys[1]])]));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerKeyValuePairArrayConstructorTest()
    {
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Array: new KeyValuePair<string, Player.IPlayer>[] {
            new KeyValuePair<string, Player.IPlayer>(
                key: expectedPlayerKeys[0],
                value: new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])
                ),
            new KeyValuePair<string, Player.IPlayer>(
                key: expectedPlayerKeys[1],
                value: new Player.Player(Key: expectedPlayerKeys[1], Name: expectedPlayerNames[expectedPlayerKeys[1]])
                )}));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerKeyValuePairArrayInitializorTest()
    {
        expectedSetupPlayerCount = 3;
        expectedSetupPlayerKeys = ["Player 1", "Player 2", "Player 3"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" },
            { expectedSetupPlayerKeys[2], "Unknown Player 3" } };
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => Players.Init(Array: new KeyValuePair<string, Player.IPlayer>[] {
            new KeyValuePair<string, Player.IPlayer>(
                key: expectedPlayerKeys[0],
                value: new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])
                ),
            new KeyValuePair<string, Player.IPlayer>(
                key: expectedPlayerKeys[1],
                value: new Player.Player(Key: expectedPlayerKeys[1], Name: expectedPlayerNames[expectedPlayerKeys[1]])
                )}));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerDictionaryConstructorTest()
    {
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Dictionary: new Dictionary<string, Player.Player> {
            { expectedPlayerKeys[0], new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])},
            { expectedPlayerKeys[1], new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[1]])}
        }));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayerDictionaryInitializorTest()
    {
        expectedSetupPlayerCount = 3;
        expectedSetupPlayerKeys = ["Player 1", "Player 2", "Player 3"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" },
            { expectedSetupPlayerKeys[2], "Unknown Player 3" } };
        expectedPlayerCount = 2;
        expectedPlayerKeys = ["Player 1", "Player 2"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => Players.Init(Dictionary: new Dictionary<string, Player.Player> {
            { expectedPlayerKeys[0], new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])},
            { expectedPlayerKeys[1], new Player.Player(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[1]])}
        }));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Original: new Players(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedSetupPlayerCount = 2;
        expectedSetupPlayerKeys = ["Player 1", "Player 2"];
        expectedSetupPlayerNames = new Dictionary<String, String> {
            { expectedSetupPlayerKeys[0], "Unknown Player 1" },
            { expectedSetupPlayerKeys[1], "Unknown Player 2" } };
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerNames = new Dictionary<String, String> {
            { expectedPlayerKeys[0], "Unknown Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new(Count: (int)expectedSetupPlayerCount));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedSetupPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedSetupPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedSetupPlayerKeys[index]].Key, Is.EqualTo(expectedSetupPlayerKeys[index]));
            Assert.That(Players[expectedSetupPlayerKeys[index]].Name, Is.EqualTo(expectedSetupPlayerNames[expectedSetupPlayerKeys[index]]));
        }
        Assert.DoesNotThrow(() => Players.Init(Original: new Players(Key: expectedPlayerKeys[0], Name: expectedPlayerNames[expectedPlayerKeys[0]])));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void DefaultPlayersCollectionTest()
    {
        expectedPlayerCount = 8;
        expectedPlayerKeys = ["Unknown Player",
        "Unknown Fantasy Player",
        "Unknown Western Player",
        "Unknown Pulp Fiction Player",
        "Unknown Modern Player",
        "Unknown Star Hero Player",
        "Unknown Champions Player",
        "Unknown Custom Player"];
        expectedPlayerNames = new()
        {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Fantasy Player" },
            { expectedPlayerKeys[2], "Unknown Western Player" },
            { expectedPlayerKeys[3], "Unknown Pulp Fiction Player" },
            { expectedPlayerKeys[4], "Unknown Modern Player" },
            { expectedPlayerKeys[5], "Unknown Star Hero Player" },
            { expectedPlayerKeys[6], "Unknown Champions Player" },
            { expectedPlayerKeys[7], "Unknown Custom Player" } };
        Assert.That(IPlayers.PLAYERS, Is.InstanceOf<Players>());
        Assert.That(IPlayers.PLAYERS, Is.Not.Null);
        Assert.That(IPlayers.PLAYERS.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < IPlayers.PLAYERS.Count; index++)
        {
            Assert.That(IPlayers.PLAYERS.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(IPlayers.PLAYERS.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(IPlayers.PLAYERS[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(IPlayers.PLAYERS[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
    }
    [Test]
    public void PlayerKeySetConstructorTest()
    {
        expectedPlayerKeys = ["Unknown Player", "Unknown Fantasy Player", "Unknown Western Player", "Unknown Pulp Fiction Player", "Unknown Modern Player", "Unknown Star Hero Player", "Unknown Champions Player", "Unknown Custom Player"];
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => PlayerKeySet = new(IPlayers.PLAYERS, ref IPlayers.PLAYERS));
        Assert.That(PlayerKeySet, Is.InstanceOf<PlayerKeySet>());
        Assert.That(PlayerKeySet, Is.Not.Null);
        Assert.That(PlayerKeySet.Count, Is.EqualTo(expectedPlayerKeys.Length));
        for (int index = 0; index < PlayerKeySet.Count; index++)
        {
            Assert.That(PlayerKeySet.Keys[index], Is.EqualTo(expectedPlayerKeys[index]));
        }
    }
    [Test]
    public void PlayerKeySetConstructorReturnTest()
    {
        expectedPlayerKeys = ["Unknown Player", "Unknown Fantasy Player", "Unknown Western Player", "Unknown Pulp Fiction Player", "Unknown Modern Player", "Unknown Star Hero Player", "Unknown Champions Player", "Unknown Custom Player"];
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = new());
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.DoesNotThrow(() => Players.Clear());
        Assert.DoesNotThrow(() => PlayerKeySet = new(IPlayers.PLAYERS, ref Players));
        Assert.That(PlayerKeySet, Is.InstanceOf<PlayerKeySet>());
        Assert.That(PlayerKeySet, Is.Not.Null);
        Assert.That(PlayerKeySet.Count, Is.EqualTo(expectedPlayerKeys.Length));
        for (int index = 0; index < PlayerKeySet.Count; index++)
        {
            Assert.That(PlayerKeySet.Keys[index], Is.EqualTo(expectedPlayerKeys[index]));
        }
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(IPlayers.PLAYERS.Count));
        Assert.That(PlayerKeySet.Count, Is.EqualTo(IPlayers.PLAYERS.Count));
        foreach (String key in IPlayers.PLAYERS.Keys)
        {
            Assert.That(PlayerKeySet.Keys.Contains(key), Is.True);
            Assert.That(Players.ContainsKey(key), Is.True);
            Assert.That(Players[key].Key, Is.EqualTo(IPlayers.PLAYERS[key].Key));
            Assert.That(Players[key].Name, Is.EqualTo(IPlayers.PLAYERS[key].Name));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyPlayerKeySetConstructorTest()
    {
        expectedPlayerKeys = ["Unknown Player", "Unknown Fantasy Player", "Unknown Western Player", "Unknown Pulp Fiction Player", "Unknown Modern Player", "Unknown Star Hero Player", "Unknown Champions Player", "Unknown Custom Player"];
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => PlayerKeySet = new(Original: new PlayerKeySet(IPlayers.PLAYERS, ref IPlayers.PLAYERS)));
        Assert.That(PlayerKeySet, Is.InstanceOf<PlayerKeySet>());
        Assert.That(PlayerKeySet, Is.Not.Null);
        Assert.That(PlayerKeySet, Is.InstanceOf<PlayerKeySet>());
        Assert.That(PlayerKeySet, Is.Not.Null);
        Assert.That(PlayerKeySet.Count, Is.EqualTo(expectedPlayerKeys.Length));
        for (int index = 0; index < PlayerKeySet.Count; index++)
        {
            Assert.That(PlayerKeySet.Keys[index], Is.EqualTo(expectedPlayerKeys[index]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayersAccessorTest()
    {
        expectedPlayerCount = 8;
        expectedPlayerKeys = ["Unknown Player",
        "Unknown Fantasy Player",
        "Unknown Western Player",
        "Unknown Pulp Fiction Player",
        "Unknown Modern Player",
        "Unknown Star Hero Player",
        "Unknown Champions Player",
        "Unknown Custom Player"];
        expectedPlayerNames = new()
        {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Fantasy Player" },
            { expectedPlayerKeys[2], "Unknown Western Player" },
            { expectedPlayerKeys[3], "Unknown Pulp Fiction Player" },
            { expectedPlayerKeys[4], "Unknown Modern Player" },
            { expectedPlayerKeys[5], "Unknown Star Hero Player" },
            { expectedPlayerKeys[6], "Unknown Champions Player" },
            { expectedPlayerKeys[7], "Unknown Custom Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => PlayerKeySet = new(IPlayers.PLAYERS, ref IPlayers.PLAYERS));
        Assert.That(PlayerKeySet, Is.InstanceOf<PlayerKeySet>());
        Assert.That(PlayerKeySet, Is.Not.Null);
        Assert.DoesNotThrow(() => Players = PlayerKeySet.Players(IPlayers.PLAYERS));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void PlayersAccessorWithMissingThrownTest()
    {
        expectedPlayerCount = 7;
        expectedPlayerKeys = ["Unknown Player",
        "Unknown Fantasy Player",
        "Unknown Western Player",
        "Unknown Pulp Fiction Player",
        "Unknown Modern Player",
        "Unknown Star Hero Player",
        "Unknown Champions Player"];
        expectedPlayerNames = new()
        {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Fantasy Player" },
            { expectedPlayerKeys[2], "Unknown Western Player" },
            { expectedPlayerKeys[3], "Unknown Pulp Fiction Player" },
            { expectedPlayerKeys[4], "Unknown Modern Player" },
            { expectedPlayerKeys[5], "Unknown Star Hero Player" },
            { expectedPlayerKeys[6], "Unknown Champions Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => PlayerKeySet = new(IPlayers.PLAYERS, ref IPlayers.PLAYERS));
        Assert.That(PlayerKeySet, Is.InstanceOf<PlayerKeySet>());
        Assert.That(PlayerKeySet, Is.Not.Null);
        Players missing = new(Original: IPlayers.PLAYERS);
        missing.Remove("Unknown Custom Player");
        Assert.Throws<ArgumentOutOfRangeException>(() => Players = PlayerKeySet.Players(missing));
    }
    [Test]
    public void PlayersAccessorWithMissingNotThrownTest()
    {
        expectedPlayerCount = 7;
        expectedPlayerKeys = ["Unknown Player",
        "Unknown Fantasy Player",
        "Unknown Western Player",
        "Unknown Pulp Fiction Player",
        "Unknown Modern Player",
        "Unknown Star Hero Player",
        "Unknown Champions Player"];
        expectedPlayerNames = new()
        {
            { expectedPlayerKeys[0], "Unknown Player" },
            { expectedPlayerKeys[1], "Unknown Fantasy Player" },
            { expectedPlayerKeys[2], "Unknown Western Player" },
            { expectedPlayerKeys[3], "Unknown Pulp Fiction Player" },
            { expectedPlayerKeys[4], "Unknown Modern Player" },
            { expectedPlayerKeys[5], "Unknown Star Hero Player" },
            { expectedPlayerKeys[6], "Unknown Champions Player" } };
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerGenreKeys.Clear();
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        expectedPlayerCampaignKeys.Clear();
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => PlayerKeySet = new(IPlayers.PLAYERS, ref IPlayers.PLAYERS));
        Assert.That(PlayerKeySet, Is.InstanceOf<PlayerKeySet>());
        Assert.That(PlayerKeySet, Is.Not.Null);
        Players missing = new(Original: IPlayers.PLAYERS);
        missing.Remove("Unknown Custom Player");
        Assert.DoesNotThrow(() => Players = PlayerKeySet.Players(missing, false));
        Assert.That(Players, Is.InstanceOf<Players>());
        Assert.That(Players, Is.Not.Null);
        Assert.That(Players.Count, Is.EqualTo(expectedPlayerCount));
        for (int index = 0; index < Players.Count; index++)
        {
            Assert.That(Players.Keys.Contains(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players.ContainsKey(expectedPlayerKeys[index]), Is.True);
            Assert.That(Players[expectedPlayerKeys[index]].Key, Is.EqualTo(expectedPlayerKeys[index]));
            Assert.That(Players[expectedPlayerKeys[index]].Name, Is.EqualTo(expectedPlayerNames[expectedPlayerKeys[index]]));
        }
        Assert.That(Players.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Players.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Players.CampaignKeys.Count, Is.EqualTo(expectedPlayerCampaignKeys.Count));
        foreach (String key in Players.CampaignKeys.Keys)
        {
            Assert.That(expectedPlayerCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(Players.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Players.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeysAccessorTest()
    {
        expectedPlayerCount = 1;
        expectedPlayerKeys = ["Player 1"];
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => PlayerKeySet = new(new(), ref IPlayers.PLAYERS));
        Assert.That(PlayerKeySet, Is.InstanceOf<PlayerKeySet>());
        Assert.That(PlayerKeySet, Is.Not.Null);
        Assert.That(PlayerKeySet.Keys.Count, Is.EqualTo(expectedPlayerCount));
        foreach (String key in PlayerKeySet.Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
    }
}