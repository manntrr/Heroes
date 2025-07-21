using Heroes.GameMasters.GameMaster;
using Heroes.GameMasters.GameMaster.Players.Player;
using Heroes.Genres;
using NUnit.Framework;

namespace Heroes.Campaigns.Campaign;

public class CampaignTests
{
    Campaign? Campaign = null;
    int? givenIndex = null;
    String? expectedCampaignKey = null;
    String? expectedCampaignName = null;
    GenreKeySet? expectedCampaignGenreKeys = null;
    Genres.Genres? expectedCampaignGenres = null;
    GameMasters.GameMasters? expectedGameMasters = null;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NullConstructorTest()
    {
        expectedCampaignKey = ICampaign.DefaultKey;
        expectedCampaignName = ICampaign.DefaultName;
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedCampaignKey = ICampaign.DefaultKey;
        expectedCampaignName = ICampaign.DefaultName;
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Index: 1));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = ICampaign.DefaultName;
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Key: expectedCampaignKey));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = ICampaign.DefaultName;
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.DoesNotThrow(() => Campaign.Init(Key: expectedCampaignKey));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Name: expectedCampaignName));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Name: expectedCampaignName));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGameMastersConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Name: expectedCampaignName, GameMasters: expectedGameMasters));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGameMastersInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Name: expectedCampaignName, GameMasters: expectedGameMasters));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresGameMastersConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys, GameMasters: expectedGameMasters));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void NameGenresGameMastersInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys, GameMasters: expectedGameMasters));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameConstructorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Key: expectedCampaignKey, Name: expectedCampaignName));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameInitializorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Key: expectedCampaignKey, Name: expectedCampaignName));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresConstructorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Key: expectedCampaignKey, Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresInitializorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Key: expectedCampaignKey, Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGameMastersConstructorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Key: expectedCampaignKey, Name: expectedCampaignName, GameMasters: expectedGameMasters));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGameMastersInitializorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Key: expectedCampaignKey, Name: expectedCampaignName, GameMasters: expectedGameMasters));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresGameMastersConstructorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Key: expectedCampaignKey, Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys, GameMasters: expectedGameMasters));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void KeyNameGenresGameMastersInitializorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Key: expectedCampaignKey, Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys, GameMasters: expectedGameMasters));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void IndexConstructorTest()
    {
        givenIndex = 1;
        expectedCampaignKey = "Campaign 1";
        expectedCampaignName = "Unknown Campaign 1";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Index: (int)givenIndex));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void IndexInitializorTest()
    {
        givenIndex = 1;
        expectedCampaignKey = "Campaign 1";
        expectedCampaignName = "Unknown Campaign 1";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Index: (int)givenIndex));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedCampaignKey = "Campaign 1";
        expectedCampaignName = "Unknown Campaign 1";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Campaign: new(Key: expectedCampaignKey, Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys, GameMasters: expectedGameMasters)));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedCampaignKey = "Campaign 1";
        expectedCampaignName = "Unknown Campaign 1";
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Campaign: new(Key: expectedCampaignKey, Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys, GameMasters: expectedGameMasters)));
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void GetKeyAccessorTest()
    {
        expectedCampaignKey = ICampaign.DefaultKey;
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
    }
    [Test]
    public void SetKeyAccessorTest()
    {
        expectedCampaignKey = "Campaign 1";
        expectedCampaignName = ICampaign.DefaultName;
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Key = expectedCampaignKey);
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
    }
    [Test]
    public void GetNameAccessorTest()
    {
        expectedCampaignName = ICampaign.DefaultName;
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
    }
    [Test]
    public void SetNameAccessorTest()
    {
        expectedCampaignKey = ICampaign.DefaultKey;
        expectedCampaignName = "Unknown Campaign 1";
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Name = expectedCampaignName);
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
    }
    [Test]
    public void GetGenresAccessorTest()
    {
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
    }
    [Test]
    public void SetGenresAccessorTest()
    {
        expectedCampaignKey = ICampaign.DefaultKey;
        expectedCampaignName = ICampaign.DefaultName;
        expectedCampaignGenreKeys = new(new(2), ref IGenres.GENRES);
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.Not.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.False);
        }
        Assert.DoesNotThrow(() => Campaign.GenreKeys = expectedCampaignGenreKeys);
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenreKeys.Keys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GenreKeys.Count, Is.EqualTo(expectedCampaignGenreKeys.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedCampaignGenres.ContainsKey(key), Is.True);
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Key, Is.EqualTo(expectedCampaignGenres[key].Key));
            Assert.That(Campaign.GenreKeys.Genres(IGenres.GENRES)[key].Name, Is.EqualTo(expectedCampaignGenres[key].Name));
        }
    }
    [Test]
    public void GetGameMastersAccessorTest()
    {
        expectedGameMasters = ICampaign.DefaultGameMasters;
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
    [Test]
    public void SetGameMastersAccessorTest()
    {
        expectedCampaignKey = ICampaign.DefaultKey;
        expectedCampaignName = ICampaign.DefaultName;
        expectedGameMasters = [
            new(Key: "Game Master 1", Name: "Game Master 1", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys),
            new(Key: "Game Master 2", Name: "Game Master 2", CampaignKeys: IPlayer.DefaultCampaignKeys, GenreKeys: IGameMaster.DefaultGenreKeys)
            ];
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GenreKeys.Count, Is.Not.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GenreKeys.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.False);
        }
        Assert.DoesNotThrow(() => Campaign.GameMasters = expectedGameMasters);
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.EqualTo(expectedCampaignName));
        Assert.That(Campaign.GameMasters.Count, Is.EqualTo(expectedGameMasters.Count));
        foreach (String key in Campaign.GameMasters.Keys)
        {
            Assert.That(expectedGameMasters.ContainsKey(key), Is.True);
            Assert.That(Campaign.GameMasters[key].Key, Is.EqualTo(expectedGameMasters[key].Key));
            Assert.That(Campaign.GameMasters[key].Name, Is.EqualTo(expectedGameMasters[key].Name));
        }
    }
}
