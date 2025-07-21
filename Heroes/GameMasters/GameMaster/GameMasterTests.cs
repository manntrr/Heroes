using Heroes.Genres;
using NUnit.Framework;

namespace Heroes.GameMasters.GameMaster;

public class GameMasterTests
{
    GameMaster? GameMaster = null;
    int? givenIndex = null;
    String? expectedGameMasterKey = null;
    String? expectedGameMasterName = null;
    GenreKeySet? expectedGameMasterGenreKeys = null;
    Genres.Genres? expectedGameMasterGenres = null;
    GameMasters? expectedGameMasters = null;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NullConstructorTest()
    {
        expectedGameMasterKey = IGameMaster.DefaultKey;
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
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
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedGameMasterKey = IGameMaster.DefaultKey;
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
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
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyConstructorTest()
    {
        expectedGameMasterKey = "Custom Player Key";
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyInitializorTest()
    {
        expectedGameMasterKey = "Custom GameMaster Key";
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameConstructorTest()
    {
        expectedGameMasterKey = "Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Name: expectedGameMasterName));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameInitializorTest()
    {
        expectedGameMasterKey = "Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Name: expectedGameMasterName));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresConstructorTest()
    {
        expectedGameMasterKey = "Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresInitializorTest()
    {
        expectedGameMasterKey = "Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGameMastersConstructorTest()
    {
        expectedGameMasterKey = "Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Name: expectedGameMasterName, GameMasters: expectedGameMasters));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGameMastersInitializorTest()
    {
        expectedGameMasterKey = "Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Name: expectedGameMasterName, GameMasters: expectedGameMasters));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresGameMastersConstructorTest()
    {
        expectedGameMasterKey = "Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys, GameMasters: expectedGameMasters));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresGameMastersInitializorTest()
    {
        expectedGameMasterKey = "Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys, GameMasters: expectedGameMasters));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameConstructorTest()
    {
        expectedGameMasterKey = "Alternate Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey, Name: expectedGameMasterName));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameInitializorTest()
    {
        expectedGameMasterKey = "Alternate Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey, Name: expectedGameMasterName));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresConstructorTest()
    {
        expectedGameMasterKey = "Alternate Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey, Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresInitializorTest()
    {
        expectedGameMasterKey = "Alternate Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey, Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGameMastersConstructorTest()
    {
        expectedGameMasterKey = "Alternate Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey, Name: expectedGameMasterName));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGameMastersInitializorTest()
    {
        expectedGameMasterKey = "Alternate Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey, Name: expectedGameMasterName, GameMasters: expectedGameMasters));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresGameMastersConstructorTest()
    {
        expectedGameMasterKey = "Alternate Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(Key: expectedGameMasterKey, Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresGameMastersInitializorTest()
    {
        expectedGameMasterKey = "Alternate Custom GameMaster Key";
        expectedGameMasterName = "Custom GameMaster";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(Key: expectedGameMasterKey, Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys, GameMasters: expectedGameMasters));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void IndexConstructorTest()
    {
        givenIndex = 1;
        expectedGameMasterKey = "GameMaster 1";
        expectedGameMasterName = "Unknown GameMaster 1";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
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
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void IndexInitializorTest()
    {
        givenIndex = 1;
        expectedGameMasterKey = "GameMaster 1";
        expectedGameMasterName = "Unknown GameMaster 1";
        expectedGameMasterGenreKeys = IGameMaster.DefaultGenreKeys;
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
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
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedGameMasterKey = "GameMaster 1";
        expectedGameMasterName = "Unknown GameMaster 1";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new(GameMaster: new(Key: expectedGameMasterKey, Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys)));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedGameMasterKey = "GameMaster 1";
        expectedGameMasterName = "Unknown GameMaster 1";
        expectedGameMasterGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => expectedGameMasterGenres = expectedGameMasterGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedGameMasterGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.Not.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.Not.EqualTo(expectedGameMasterName));
        Assert.DoesNotThrow(() => GameMaster.Init(GameMaster: new(Key: expectedGameMasterKey, Name: expectedGameMasterName, GenreKeys: expectedGameMasterGenreKeys)));
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
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
        expectedGameMasterName = "Unknown GameMaster 1";
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
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
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
        Assert.That(GameMaster.GenreKeys.Count, Is.EqualTo(expectedGameMasterGenreKeys.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasterGenres.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedGameMasterGenres[key].Key));
            Assert.That(GameMaster.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedGameMasterGenres[key].Name));
        }
    }
    [Test]
    public void GetGameMastersAccessorTest()
    {
        expectedGameMasters = IGameMaster.DefaultGameMasters;
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void SetGameMastersAccessorTest()
    {
        expectedGameMasterKey = IGameMaster.DefaultKey;
        expectedGameMasterName = IGameMaster.DefaultName;
        expectedGameMasters = new GameMasters((GameMaster[])[
            new GameMaster(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new GameMaster(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IGameMaster.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ]);
        Assert.DoesNotThrow(() => GameMaster = new());
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GenreKeys.Count, Is.Not.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.False);
        }
        Assert.DoesNotThrow(() => GameMaster.GameMasters = expectedGameMasters);
        Assert.That(GameMaster, Is.InstanceOf<GameMaster>());
        Assert.That(GameMaster, Is.Not.Null);
        Assert.That(GameMaster.Key, Is.EqualTo(expectedGameMasterKey));
        Assert.That(GameMaster.Name, Is.EqualTo(expectedGameMasterName));
        Assert.That(GameMaster.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in GameMaster.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMaster.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(GameMaster.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
}
