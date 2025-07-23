using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster;
using Heroes.GameMasters.GameMaster.Players;
using NUnit.Framework;

namespace Heroes.Genres.Genre;

public class GenreTests
{
    Heroes? heroes = null;
    Genre? genre = null;
    int? givenIndex = null;
    String? expectedGenreKey = null;
    String? expectedGenreName = null;
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
        expectedGenreKey = IGenre.DefaultKey;
        expectedGenreName = IGenre.DefaultName;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedGenreKey = IGenre.DefaultKey;
        expectedGenreName = IGenre.DefaultName;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyConstructorTest()
    {
        expectedGenreKey = "Custom Genre Key";
        expectedGenreName = IGenre.DefaultName;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new(Key: expectedGenreKey));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyInitializorTest()
    {
        expectedGenreKey = "Custom Genre Key";
        expectedGenreName = IGenre.DefaultName;
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.DoesNotThrow(() => genre.Init(Key: expectedGenreKey));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameConstructorTest()
    {
        expectedGenreKey = "Custom Genre Key";
        expectedGenreName = "Custom Genre";
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new(Name: expectedGenreName));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NameInitializorTest()
    {
        expectedGenreKey = "Custom Genre Key";
        expectedGenreName = "Custom Genre";
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init(Name: expectedGenreName));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameConstructorTest()
    {
        expectedGenreKey = "Alternate Custom Genre Key";
        expectedGenreName = "Custom Genre";
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new(Key: expectedGenreKey, Name: expectedGenreName));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeyNameInitializorTest()
    {
        String expectedGenreKey = "Alternate Custom Genre Key";
        String expectedGenreName = "Custom Genre";
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init(Key: expectedGenreKey, Name: expectedGenreName));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void IndexConstructorTest()
    {
        givenIndex = 1;
        expectedGenreKey = "Genre 1";
        expectedGenreName = "Unknown Genre 1";
        expectedCampaignKeys = new(Campaigns: new([ICampaigns.CAMPAIGNS["Campaign 1"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new(Index: (int)givenIndex));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void IndexInitializorTest()
    {
        givenIndex = 1;
        expectedGenreKey = "Genre 1";
        expectedGenreName = "Unknown Genre 1";
        expectedCampaignKeys = new(Campaigns: new([ICampaigns.CAMPAIGNS["Campaign 1"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init(Index: (int)givenIndex));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        givenIndex = 1;
        expectedGenreKey = "Genre 1";
        expectedGenreName = "Unknown Genre 1";
        expectedCampaignKeys = new(Campaigns: new([ICampaigns.CAMPAIGNS["Campaign 1"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new(Genre: new(Index: (int)givenIndex)));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        givenIndex = 1;
        expectedGenreKey = "Genre 1";
        expectedGenreName = "Unknown Genre 1";
        expectedCampaignKeys = new(Campaigns: new([ICampaigns.CAMPAIGNS["Campaign 1"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedCampaignKeys, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init(Genre: new(Index: (int)givenIndex)));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.That(genre.CampaignKeys(heroes).Count, Is.EqualTo(expectedCampaignKeys.Count));
        foreach (String key in genre.CampaignKeys(heroes).Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
        Assert.That(genre.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in genre.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(genre.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in genre.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GetKeyAccessorTest()
    {
        expectedGenreKey = IGenre.DefaultKey;
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
    }
    [Test]
    public void SetKeyAccessorTest()
    {
        expectedGenreKey = "Genre 1";
        expectedGenreName = IGenre.DefaultName;
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Key = expectedGenreKey);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void GetNameAccessorTest()
    {
        expectedGenreName = IGenre.DefaultName;
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void SetNameAccessorTest()
    {
        expectedGenreKey = IGenre.DefaultKey;
        expectedGenreName = "Unknown Genre 1";
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Name = expectedGenreName);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
}
