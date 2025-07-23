using Heroes.Campaigns;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres;
using NUnit.Framework;

namespace Heroes.GameMasters.GameMaster;

public class GameMasterTests
{
    Heroes? heroes = null;
    GameMaster? GameMaster = null;
    int? givenIndex = null;
    String? expectedGameMasterKey = null;
    String? expectedGameMasterName = null;
    GenreKeySet? expectedGameMasterGenreKeys = null;
    Genres.Genres? expectedGameMasterGenres = null;
    // TODO: add campaign tests
    CampaignKeySet? expectedGameMasterCampaignKeys = null;
    //expectedGameMasterPlayerKeys = new (Players: new ([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
    PlayerKeySet? expectedGameMasterPlayerKeys = null;
    // TODO: add player tests
    [SetUp]
    public void Setup()
    {
        Assert.DoesNotThrow(() => heroes = new());
        Assert.That(heroes, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
    }

    [Test]
    public void NullConstructorTest()
    {
        expectedGameMasterKey = IGameMaster.DefaultKey;
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedGameMasterKey = IGameMaster.DefaultKey;
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Index: 1));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyConstructorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey, null, null, null));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyInitializorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey, null, null, null));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameConstructorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Name: expectedGameMasterName, null, null, null));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameInitializorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Name: expectedGameMasterName, null, null, null));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresConstructorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Name: expectedGameMasterName, null, GenreKeys: expectedGameMasterGenreKeys, null));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresInitializorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Name: expectedGameMasterName, null, GenreKeys: expectedGameMasterGenreKeys, null));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGameMastersConstructorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Name: expectedGameMasterName, null, PlayerKeys: expectedGameMasterPlayerKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGameMastersInitializorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Name: expectedGameMasterName, null, PlayerKeys: expectedGameMasterPlayerKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresGameMastersConstructorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys, PlayerKeys: expectedGameMasterPlayerKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresGameMastersInitializorTest()
    {
        expectedGameMasterKey = "Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys, PlayerKeys: expectedGameMasterPlayerKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameConstructorTest()
    {
        expectedGameMasterKey = "Alternate Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, null));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameInitializorTest()
    {
        expectedGameMasterKey = "Alternate Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, null));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresConstructorTest()
    {
        expectedGameMasterKey = "Alternate Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, GenreKeys: expectedGameMasterGenreKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresInitializorTest()
    {
        expectedGameMasterKey = "Alternate Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, GenreKeys: expectedGameMasterGenreKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGameMastersConstructorTest()
    {
        expectedGameMasterKey = "Alternate Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, null, PlayerKeys: expectedGameMasterPlayerKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGameMastersInitializorTest()
    {
        expectedGameMasterKey = "Alternate Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, null, PlayerKeys: expectedGameMasterPlayerKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresGameMastersConstructorTest()
    {
        expectedGameMasterKey = "Alternate Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, GenreKeys: expectedGameMasterGenreKeys, PlayerKeys: expectedGameMasterPlayerKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresGameMastersInitializorTest()
    {
        expectedGameMasterKey = "Alternate Custom Game Master Key";
        expectedGameMasterName = "Custom Game Master";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, GenreKeys: expectedGameMasterGenreKeys, PlayerKeys: expectedGameMasterPlayerKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void IndexConstructorTest()
    {
        givenIndex = 1;
        expectedGameMasterKey = "Game Master 1";
        expectedGameMasterName = "Unknown Game Master 1";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Index: (int)givenIndex));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void IndexInitializorTest()
    {
        givenIndex = 1;
        expectedGameMasterKey = "Game Master 1";
        expectedGameMasterName = "Unknown Game Master 1";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Index: (int)givenIndex));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedGameMasterKey = "Game Master 1";
        expectedGameMasterName = "Unknown Game Master 1";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(GameMaster: new(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, GenreKeys: expectedGameMasterGenreKeys)));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedGameMasterKey = "Game Master 1";
        expectedGameMasterName = "Unknown Game Master 1";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(GameMaster: new(Key: expectedGameMasterKey, Name: expectedGameMasterName, null, GenreKeys: expectedGameMasterGenreKeys)));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GetKeyAccessorTest()
    {
        expectedGameMasterKey = IGameMaster.DefaultKey;
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
    }
    [Test]
    public void SetKeyAccessorTest()
    {
        expectedGameMasterKey = "GameMaster 1";
        expectedGameMasterName = IGameMaster.DefaultName;
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Key = expectedGameMasterKey);
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
    }
    [Test]
    public void GetNameAccessorTest()
    {
        expectedGameMasterName = IGameMaster.DefaultName;
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
    }
    [Test]
    public void SetNameAccessorTest()
    {
        expectedGameMasterKey = IGameMaster.DefaultKey;
        expectedGameMasterName = "Unknown Game Master 1";
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Name = expectedGameMasterName);
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
    }
    [Test]
    public void GetGenresAccessorTest()
    {
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        /*
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
        /**/
    }
    [Test]
    public void SetGenresAccessorTest()
    {
        expectedGameMasterKey = IGameMaster.DefaultKey;
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.Not.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.False);
        }
        Assert.DoesNotThrow(() => GameMaster.GenreKeys = expectedGameMasterGenreKeys);
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        /*
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
        /**/
    }
    [Test]
    public void GetGameMastersAccessorTest()
    {
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void SetGameMastersAccessorTest()
    {
        expectedGameMasterKey = IGameMaster.DefaultKey;
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterCampaignKeys = IGameMaster.DefaultCampaignKeys;
        expectedGameMasterPlayerKeys = IGameMaster.DefaultPlayerKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedGameMasterGenreKeys, Is.Not.Null);
        Assert.That(expectedGameMasterCampaignKeys, Is.Not.Null);
        Assert.That(expectedGameMasterPlayerKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.CampaignKeys.Count, Is.EqualTo(expectedGameMasterCampaignKeys.Count));
        foreach (String key in GameMaster.CampaignKeys.Keys)
        {
            Assert.That(expectedGameMasterCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.PlayerKeys.Count, Is.EqualTo(expectedGameMasterPlayerKeys.Count));
        foreach (String key in GameMaster.PlayerKeys.Keys)
        {
            Assert.That(expectedGameMasterPlayerKeys.Contains(key), Is.True);
        }
    }
}
