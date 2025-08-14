using Heroes.Campaigns;
using Heroes.Genres;
using NUnit.Framework;

namespace Heroes.GameMasters.GameMaster.Players.Player;

public class PlayerTests
{
    Heroes? heroes = null;
    Player? Player = null;
    int? givenIndex = null;
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
        expectedPlayerKey = IPlayer.DefaultKey;
        expectedPlayerName = IPlayer.DefaultName;
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedPlayerCampaignKeys = IPlayer.DefaultCampaignKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedPlayerKey = IPlayer.DefaultKey;
        expectedPlayerName = IPlayer.DefaultName;
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Index: 1));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = IPlayer.DefaultName;
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Key: expectedPlayerKey));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = IPlayer.DefaultName;
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.DoesNotThrow(() => Player.Init(Key: expectedPlayerKey));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Name: expectedPlayerName));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Name: expectedPlayerName));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGameMastersConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Name: expectedPlayerName));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGameMastersInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Name: expectedPlayerName));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresGameMastersConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresGameMastersInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameConstructorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Key: expectedPlayerKey, Name: expectedPlayerName));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameInitializorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Key: expectedPlayerKey, Name: expectedPlayerName));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresConstructorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresInitializorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGameMastersConstructorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Key: expectedPlayerKey, Name: expectedPlayerName));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGameMastersInitializorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Key: expectedPlayerKey, Name: expectedPlayerName));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresGameMastersConstructorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresGameMastersInitializorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void IndexConstructorTest()
    {
        givenIndex = 1;
        expectedPlayerKey = "Player 1";
        expectedPlayerName = "Unknown Player 1";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Index: (int)givenIndex));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void IndexInitializorTest()
    {
        givenIndex = 1;
        expectedPlayerKey = "Player 1";
        expectedPlayerName = "Unknown Player 1";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Index: (int)givenIndex));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedPlayerKey = "Player 1";
        expectedPlayerName = "Unknown Player 1";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Player: new(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys)));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedPlayerKey = "Player 1";
        expectedPlayerName = "Unknown Player 1";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Player: new(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys)));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GetKeyAccessorTest()
    {
        expectedPlayerKey = IPlayer.DefaultKey;
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
    }
    [Test]
    public void SetKeyAccessorTest()
    {
        expectedPlayerKey = "Player 1";
        expectedPlayerName = IPlayer.DefaultName;
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Key = expectedPlayerKey);
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
    }
    [Test]
    public void GetNameAccessorTest()
    {
        expectedPlayerName = IPlayer.DefaultName;
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
    }
    [Test]
    public void SetNameAccessorTest()
    {
        expectedPlayerKey = IPlayer.DefaultKey;
        expectedPlayerName = "Unknown Player 1";
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Name = expectedPlayerName);
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
    }
    [Test]
    public void GetGenresAccessorTest()
    {
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
    }
    [Test]
    public void SetGenresAccessorTest()
    {
        expectedPlayerKey = IPlayer.DefaultKey;
        expectedPlayerName = IPlayer.DefaultName;
        Genres.Genres genres = new(IGenres.GENRES);
        expectedPlayerGenreKeys = new(new(2), ref genres);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.Not.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.False);
        }
        Assert.DoesNotThrow(() => Player.GenreKeys = expectedPlayerGenreKeys);
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Player.GenreKeys.Count, Is.EqualTo(expectedPlayerGenreKeys.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedPlayerGenres.ContainsKey(key), Is.True);
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedPlayerGenres[key].Key));
            Assert.That(Player.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedPlayerGenres[key].Name));
        }
    }
    [Test]
    public void GetGameMastersAccessorTest()
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void SetGameMastersAccessorTest()
    {
        expectedPlayerKey = IPlayer.DefaultKey;
        expectedPlayerName = IPlayer.DefaultName;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Player.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
}
