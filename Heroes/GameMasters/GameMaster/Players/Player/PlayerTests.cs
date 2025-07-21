using Heroes.Genres;
using NUnit.Framework;

namespace Heroes.GameMasters.GameMaster.Players.Player;

public class PlayerTests
{
    Player? Player = null;
    int? givenIndex = null;
    String? expectedPlayerKey = null;
    String? expectedPlayerName = null;
    GenreKeySet? expectedPlayerGenreKeys = null;
    Genres.Genres? expectedPlayerGenres = null;
    GameMasters? expectedGameMasters = null;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NullConstructorTest()
    {
        expectedPlayerKey = IPlayer.DefaultKey;
        expectedPlayerName = IPlayer.DefaultName;
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedPlayerKey = IPlayer.DefaultKey;
        expectedPlayerName = IPlayer.DefaultName;
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = IPlayer.DefaultName;
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = IPlayer.DefaultName;
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGameMastersConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Name: expectedPlayerName, GameMasters: expectedGameMasters));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGameMastersInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Name: expectedPlayerName, GameMasters: expectedGameMasters));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresGameMastersConstructorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys, GameMasters: expectedGameMasters));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresGameMastersInitializorTest()
    {
        expectedPlayerKey = "Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys, GameMasters: expectedGameMasters));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameConstructorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameInitializorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresConstructorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresInitializorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGameMastersConstructorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Key: expectedPlayerKey, Name: expectedPlayerName, GameMasters: expectedGameMasters));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGameMastersInitializorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Key: expectedPlayerKey, Name: expectedPlayerName, GameMasters: expectedGameMasters));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresGameMastersConstructorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys, GameMasters: expectedGameMasters));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresGameMastersInitializorTest()
    {
        expectedPlayerKey = "Alternate Custom Player Key";
        expectedPlayerName = "Custom Player";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys, GameMasters: expectedGameMasters));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void IndexConstructorTest()
    {
        givenIndex = 1;
        expectedPlayerKey = "Player 1";
        expectedPlayerName = "Unknown Player 1";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void IndexInitializorTest()
    {
        givenIndex = 1;
        expectedPlayerKey = "Player 1";
        expectedPlayerName = "Unknown Player 1";
        expectedPlayerGenreKeys = IPlayer.DefaultGenreKeys;
        expectedGameMasters = IPlayer.DefaultGameMasters;
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedPlayerKey = "Player 1";
        expectedPlayerName = "Unknown Player 1";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new(Player: new(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys, GameMasters: expectedGameMasters)));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedPlayerKey = "Player 1";
        expectedPlayerName = "Unknown Player 1";
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedPlayerGenres = expectedPlayerGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedPlayerGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.Not.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.Not.EqualTo(expectedPlayerName));
        Assert.DoesNotThrow(() => Player.Init(Player: new(Key: expectedPlayerKey, Name: expectedPlayerName, GenreKeys: expectedPlayerGenreKeys, GameMasters: expectedGameMasters)));
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
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
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
        expectedPlayerGenreKeys = new(new(2), ref IGenres.GENRES);
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
        expectedGameMasters = IPlayer.DefaultGameMasters;
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void SetGameMastersAccessorTest()
    {
        expectedPlayerKey = IPlayer.DefaultKey;
        expectedPlayerName = IPlayer.DefaultName;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => Player = new());
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GenreKeys.Count, Is.Not.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.False);
        }
        Assert.DoesNotThrow(() => Player.GameMasters = expectedGameMasters);
        Assert.That(Player, Is.InstanceOf<Player>());
        Assert.That(Player, Is.Not.Null);
        Assert.That(Player.Key, Is.EqualTo(expectedPlayerKey));
        Assert.That(Player.Name, Is.EqualTo(expectedPlayerName));
        Assert.That(Player.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Player.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Player.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Player.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
}
