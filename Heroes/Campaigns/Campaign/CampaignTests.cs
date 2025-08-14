using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.GameMasters.GameMaster.Players.Player;
using Heroes.Genres;
using NUnit.Framework;

namespace Heroes.Campaigns.Campaign;

public class CampaignTests
{
    Heroes? heroes = null;
    Campaign? Campaign = null;
    int? givenIndex = null;
    String? expectedCampaignKey = null;
    String? expectedCampaignName = null;
    GenreKeySet? expectedCampaignGenreKeys = null;
    Genres.Genres? expectedCampaignGenres = null;
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
        expectedCampaignKey = ICampaign.DefaultKey;
        expectedCampaignName = ICampaign.DefaultName;
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedCampaignKey = ICampaign.DefaultKey;
        expectedCampaignName = ICampaign.DefaultName;
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = ICampaign.DefaultName;
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = ICampaign.DefaultName;
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGameMastersConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGameMastersInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresGameMastersConstructorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameGenresGameMastersInitializorTest()
    {
        expectedCampaignKey = "Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameConstructorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameInitializorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresConstructorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresInitializorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGameMastersConstructorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGameMastersInitializorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresGameMastersConstructorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameGenresGameMastersInitializorTest()
    {
        expectedCampaignKey = "Alternate Custom Campaign Key";
        expectedCampaignName = "Custom Campaign";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void IndexConstructorTest()
    {
        givenIndex = 1;
        expectedCampaignKey = "Campaign 1";
        expectedCampaignName = "Unknown Campaign 1";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedPlayerKeys = new(Players: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterPlayers: ref IPlayers.PLAYERS);
        expectedGameMasterKeys = new(GameMasters: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void IndexInitializorTest()
    {
        givenIndex = 1;
        expectedCampaignKey = "Campaign 1";
        expectedCampaignName = "Unknown Campaign 1";
        expectedCampaignGenreKeys = ICampaign.DefaultGenreKeys;
        expectedPlayerKeys = new(Players: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterPlayers: ref IPlayers.PLAYERS);
        expectedGameMasterKeys = new(GameMasters: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedCampaignKey = "Campaign 1";
        expectedCampaignName = "Unknown Campaign 1";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        expectedPlayerKeys = new(Players: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterPlayers: ref IPlayers.PLAYERS);
        expectedGameMasterKeys = new(GameMasters: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new(Campaign: new(Key: expectedCampaignKey, Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys)));
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedCampaignKey = "Campaign 1";
        expectedCampaignName = "Unknown Campaign 1";
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
        expectedPlayerKeys = new(Players: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterPlayers: ref IPlayers.PLAYERS);
        expectedGameMasterKeys = new(GameMasters: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => expectedCampaignGenres = expectedCampaignGenreKeys.Genres(IGenres.GENRES));
        Assert.That(expectedCampaignGenres, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.Key, Is.Not.EqualTo(expectedCampaignKey));
        Assert.That(Campaign.Name, Is.Not.EqualTo(expectedCampaignName));
        Assert.DoesNotThrow(() => Campaign.Init(Campaign: new(Key: expectedCampaignKey, Name: expectedCampaignName, GenreKeys: expectedCampaignGenreKeys)));
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
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
        expectedPlayerKeys = new(Players: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterPlayers: ref IPlayers.PLAYERS);
        expectedGameMasterKeys = new(GameMasters: new([IGameMasters.GAME_MASTERS["Game Master 1"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
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
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
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
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Genres.Genres genres = new(IGenres.GENRES);
        expectedCampaignGenreKeys = new(new(2), ref genres);
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
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GetGameMastersAccessorTest()
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaign = new());
        Assert.That(Campaign, Is.InstanceOf<Campaign>());
        Assert.That(Campaign, Is.Not.Null);
        Assert.That(Campaign.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaign.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaign.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaign.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
}
