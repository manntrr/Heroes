using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using NUnit.Framework;

namespace Heroes.Campaigns;

public class CampaignsTests
{
    Heroes? heroes = null;
    KeyValuePair<String, Campaign.ICampaign>? CampaignPair = null;
    Campaigns? Campaigns = null;
    CampaignKeySet? CampaignKeySet = null;
    int? expectedSetupCampaignCount = null;
    String[]? expectedSetupCampaignKeys = null;
    Dictionary<String, String>? expectedSetupCampaignNames = null;
    int? expectedCampaignCount = null;
    String[]? expectedCampaignKeys = null;
    Dictionary<String, String>? expectedCampaignNames = null;
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
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> { { expectedCampaignKeys[0], "Unknown Campaign 1" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new());
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedSetupCampaignCount = 2;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" } };
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> { { expectedCampaignKeys[0], "Unknown Campaign 1" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => Campaigns.Init());
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GeneratedCountConstructorTest()
    {
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign 1" },
            { expectedCampaignKeys[1], "Unknown Campaign 2" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void GeneratedCountInitializorTest()
    {
        expectedSetupCampaignCount = 3;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2", "Campaign 3"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" },
            { expectedSetupCampaignKeys[2], "Unknown Campaign 3" } };
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign 1" },
            { expectedCampaignKeys[1], "Unknown Campaign 2" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => Campaigns.Init(Count: (int)expectedCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignElementsConstructorTest()
    {
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]]));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignElementsInitializorTest()
    {
        expectedSetupCampaignCount = 2;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" } };
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => Campaigns.Init(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]]));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignKeyValuePairConstructorTest()
    {
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => CampaignPair = new(key: expectedCampaignKeys[0], value: new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])));
        Assert.That(CampaignPair, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Campaign: (KeyValuePair<String, Campaign.ICampaign>)CampaignPair));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignKeyValuePairInitializorTest()
    {
        expectedSetupCampaignCount = 2;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" } };
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => CampaignPair = new(key: expectedCampaignKeys[0], value: new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])));
        Assert.That(CampaignPair, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns.Init(Campaign: (KeyValuePair<String, Campaign.ICampaign>)CampaignPair));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignElementsDictionaryConstructorTest()
    {
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Dictionary: new Dictionary<string, string> {
            { expectedCampaignKeys[0], expectedCampaignNames[expectedCampaignKeys[0]]},
            { expectedCampaignKeys[1], expectedCampaignNames[expectedCampaignKeys[1]]}
        }));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignElementsDictionaryInitializorTest()
    {
        expectedSetupCampaignCount = 3;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2", "Campaign 3"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" },
            { expectedSetupCampaignKeys[2], "Unknown Campaign 3" } };
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => Campaigns.Init(Dictionary: new Dictionary<string, string> {
            { expectedCampaignKeys[0], expectedCampaignNames[expectedCampaignKeys[0]]},
            { expectedCampaignKeys[1], expectedCampaignNames[expectedCampaignKeys[1]]}
        }));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignConstructorTest()
    {
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Campaign: new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignInitializorTest()
    {
        expectedSetupCampaignCount = 2;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" } };
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => Campaigns.Init(Campaign: new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignArrayConstructorTest()
    {
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Array: [
            new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]]),
            new Campaign.Campaign(Key: expectedCampaignKeys[1], Name: expectedCampaignNames[expectedCampaignKeys[1]])]));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignArrayInitializorTest()
    {
        expectedSetupCampaignCount = 3;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2", "Campaign 3"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" },
            { expectedSetupCampaignKeys[2], "Unknown Campaign 3" } };
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => Campaigns.Init(Array: [
            new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]]),
            new Campaign.Campaign(Key: expectedCampaignKeys[1], Name: expectedCampaignNames[expectedCampaignKeys[1]])]));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignKeyValuePairArrayConstructorTest()
    {
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Array: new KeyValuePair<string, Campaign.ICampaign>[] {
            new KeyValuePair<string, Campaign.ICampaign>(
                key: expectedCampaignKeys[0],
                value: new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])
                ),
            new KeyValuePair<string, Campaign.ICampaign>(
                key: expectedCampaignKeys[1],
                value: new Campaign.Campaign(Key: expectedCampaignKeys[1], Name: expectedCampaignNames[expectedCampaignKeys[1]])
                )}));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignKeyValuePairArrayInitializorTest()
    {
        expectedSetupCampaignCount = 3;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2", "Campaign 3"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" },
            { expectedSetupCampaignKeys[2], "Unknown Campaign 3" } };
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => Campaigns.Init(Array: new KeyValuePair<string, Campaign.ICampaign>[] {
            new KeyValuePair<string, Campaign.ICampaign>(
                key: expectedCampaignKeys[0],
                value: new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])
                ),
            new KeyValuePair<string, Campaign.ICampaign>(
                key: expectedCampaignKeys[1],
                value: new Campaign.Campaign(Key: expectedCampaignKeys[1], Name: expectedCampaignNames[expectedCampaignKeys[1]])
                )}));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignDictionaryConstructorTest()
    {
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Dictionary: new Dictionary<string, Campaign.Campaign> {
            { expectedCampaignKeys[0], new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])},
            { expectedCampaignKeys[1], new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[1]])}
        }));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignDictionaryInitializorTest()
    {
        expectedSetupCampaignCount = 3;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2", "Campaign 3"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" },
            { expectedSetupCampaignKeys[2], "Unknown Campaign 3" } };
        expectedCampaignCount = 2;
        expectedCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => Campaigns.Init(Dictionary: new Dictionary<string, Campaign.Campaign> {
            { expectedCampaignKeys[0], new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])},
            { expectedCampaignKeys[1], new Campaign.Campaign(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[1]])}
        }));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Original: new Campaigns(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedSetupCampaignCount = 2;
        expectedSetupCampaignKeys = ["Campaign 1", "Campaign 2"];
        expectedSetupCampaignNames = new Dictionary<String, String> {
            { expectedSetupCampaignKeys[0], "Unknown Campaign 1" },
            { expectedSetupCampaignKeys[1], "Unknown Campaign 2" } };
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        expectedCampaignNames = new Dictionary<String, String> {
            { expectedCampaignKeys[0], "Unknown Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new(Count: (int)expectedSetupCampaignCount));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedSetupCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedSetupCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Key, Is.EqualTo(expectedSetupCampaignKeys[index]));
            Assert.That(Campaigns[expectedSetupCampaignKeys[index]].Name, Is.EqualTo(expectedSetupCampaignNames[expectedSetupCampaignKeys[index]]));
        }
        Assert.DoesNotThrow(() => Campaigns.Init(Original: new Campaigns(Key: expectedCampaignKeys[0], Name: expectedCampaignNames[expectedCampaignKeys[0]])));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void DefaultCampaignsCollectionTest()
    {
        expectedCampaignCount = 8;
        expectedCampaignKeys = ["Unknown Campaign",
        "Unknown Fantasy Campaign",
        "Unknown Western Campaign",
        "Unknown Pulp Fiction Campaign",
        "Unknown Modern Campaign",
        "Unknown Star Hero Campaign",
        "Unknown Champions Campaign",
        "Unknown Custom Campaign"];
        expectedCampaignNames = new()
        {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Fantasy Campaign" },
            { expectedCampaignKeys[2], "Unknown Western Campaign" },
            { expectedCampaignKeys[3], "Unknown Pulp Fiction Campaign" },
            { expectedCampaignKeys[4], "Unknown Modern Campaign" },
            { expectedCampaignKeys[5], "Unknown Star Hero Campaign" },
            { expectedCampaignKeys[6], "Unknown Champions Campaign" },
            { expectedCampaignKeys[7], "Unknown Custom Campaign" } };
        Assert.That(ICampaigns.CAMPAIGNS, Is.InstanceOf<Campaigns>());
        Assert.That(ICampaigns.CAMPAIGNS, Is.Not.Null);
        Assert.That(ICampaigns.CAMPAIGNS.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < ICampaigns.CAMPAIGNS.Count; index++)
        {
            Assert.That(ICampaigns.CAMPAIGNS.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(ICampaigns.CAMPAIGNS.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(ICampaigns.CAMPAIGNS[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(ICampaigns.CAMPAIGNS[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
    }
    [Test]
    public void CampaignKeySetConstructorTest()
    {
        expectedCampaignKeys = ["Unknown Campaign", "Unknown Fantasy Campaign", "Unknown Western Campaign", "Unknown Pulp Fiction Campaign", "Unknown Modern Campaign", "Unknown Star Hero Campaign", "Unknown Champions Campaign", "Unknown Custom Campaign"];
        Assert.DoesNotThrow(() => CampaignKeySet = new(ICampaigns.CAMPAIGNS, ref ICampaigns.CAMPAIGNS));
        Assert.That(CampaignKeySet, Is.InstanceOf<CampaignKeySet>());
        Assert.That(CampaignKeySet, Is.Not.Null);
        Assert.That(CampaignKeySet.Count, Is.EqualTo(expectedCampaignKeys.Length));
        for (int index = 0; index < CampaignKeySet.Count; index++)
        {
            Assert.That(CampaignKeySet.Keys[index], Is.EqualTo(expectedCampaignKeys[index]));
        }
    }
    [Test]
    public void CampaignKeySetConstructorReturnTest()
    {
        expectedCampaignKeys = ["Unknown Campaign", "Unknown Fantasy Campaign", "Unknown Western Campaign", "Unknown Pulp Fiction Campaign", "Unknown Modern Campaign", "Unknown Star Hero Campaign", "Unknown Champions Campaign", "Unknown Custom Campaign"];
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = new());
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns.Clear());
        Assert.DoesNotThrow(() => CampaignKeySet = new(ICampaigns.CAMPAIGNS, ref Campaigns));
        Assert.That(CampaignKeySet, Is.InstanceOf<CampaignKeySet>());
        Assert.That(CampaignKeySet, Is.Not.Null);
        Assert.That(CampaignKeySet.Count, Is.EqualTo(expectedCampaignKeys.Length));
        for (int index = 0; index < CampaignKeySet.Count; index++)
        {
            Assert.That(CampaignKeySet.Keys[index], Is.EqualTo(expectedCampaignKeys[index]));
        }
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(ICampaigns.CAMPAIGNS.Count));
        Assert.That(CampaignKeySet.Count, Is.EqualTo(ICampaigns.CAMPAIGNS.Count));
        foreach (String key in ICampaigns.CAMPAIGNS.Keys)
        {
            Assert.That(CampaignKeySet.Keys.Contains(key), Is.True);
            Assert.That(Campaigns.ContainsKey(key), Is.True);
            Assert.That(Campaigns[key].Key, Is.EqualTo(ICampaigns.CAMPAIGNS[key].Key));
            Assert.That(Campaigns[key].Name, Is.EqualTo(ICampaigns.CAMPAIGNS[key].Name));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CopyCampaignKeySetConstructorTest()
    {
        expectedCampaignKeys = ["Unknown Campaign", "Unknown Fantasy Campaign", "Unknown Western Campaign", "Unknown Pulp Fiction Campaign", "Unknown Modern Campaign", "Unknown Star Hero Campaign", "Unknown Champions Campaign", "Unknown Custom Campaign"];
        Assert.DoesNotThrow(() => CampaignKeySet = new(Original: new CampaignKeySet(ICampaigns.CAMPAIGNS, ref ICampaigns.CAMPAIGNS)));
        Assert.That(CampaignKeySet, Is.InstanceOf<CampaignKeySet>());
        Assert.That(CampaignKeySet, Is.Not.Null);
        Assert.That(CampaignKeySet, Is.InstanceOf<CampaignKeySet>());
        Assert.That(CampaignKeySet, Is.Not.Null);
        Assert.That(CampaignKeySet.Count, Is.EqualTo(expectedCampaignKeys.Length));
        for (int index = 0; index < CampaignKeySet.Count; index++)
        {
            Assert.That(CampaignKeySet.Keys[index], Is.EqualTo(expectedCampaignKeys[index]));
        }
    }
    [Test]
    public void CampaignsAccessorTest()
    {
        expectedCampaignCount = 8;
        expectedCampaignKeys = ["Unknown Campaign",
        "Unknown Fantasy Campaign",
        "Unknown Western Campaign",
        "Unknown Pulp Fiction Campaign",
        "Unknown Modern Campaign",
        "Unknown Star Hero Campaign",
        "Unknown Champions Campaign",
        "Unknown Custom Campaign"];
        expectedCampaignNames = new()
        {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Fantasy Campaign" },
            { expectedCampaignKeys[2], "Unknown Western Campaign" },
            { expectedCampaignKeys[3], "Unknown Pulp Fiction Campaign" },
            { expectedCampaignKeys[4], "Unknown Modern Campaign" },
            { expectedCampaignKeys[5], "Unknown Star Hero Campaign" },
            { expectedCampaignKeys[6], "Unknown Champions Campaign" },
            { expectedCampaignKeys[7], "Unknown Custom Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => CampaignKeySet = new(ICampaigns.CAMPAIGNS, ref ICampaigns.CAMPAIGNS));
        Assert.That(CampaignKeySet, Is.InstanceOf<CampaignKeySet>());
        Assert.That(CampaignKeySet, Is.Not.Null);
        Assert.DoesNotThrow(() => Campaigns = CampaignKeySet.Campaigns(ICampaigns.CAMPAIGNS));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void CampaignsAccessorWithMissingThrownTest()
    {
        expectedCampaignCount = 7;
        expectedCampaignKeys = ["Unknown Campaign",
        "Unknown Fantasy Campaign",
        "Unknown Western Campaign",
        "Unknown Pulp Fiction Campaign",
        "Unknown Modern Campaign",
        "Unknown Star Hero Campaign",
        "Unknown Champions Campaign"];
        expectedCampaignNames = new()
        {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Fantasy Campaign" },
            { expectedCampaignKeys[2], "Unknown Western Campaign" },
            { expectedCampaignKeys[3], "Unknown Pulp Fiction Campaign" },
            { expectedCampaignKeys[4], "Unknown Modern Campaign" },
            { expectedCampaignKeys[5], "Unknown Star Hero Campaign" },
            { expectedCampaignKeys[6], "Unknown Champions Campaign" } };
        Assert.DoesNotThrow(() => CampaignKeySet = new(ICampaigns.CAMPAIGNS, ref ICampaigns.CAMPAIGNS));
        Assert.That(CampaignKeySet, Is.InstanceOf<CampaignKeySet>());
        Assert.That(CampaignKeySet, Is.Not.Null);
        Campaigns missing = new(Original: ICampaigns.CAMPAIGNS);
        missing.Remove("Unknown Custom Campaign");
        Assert.Throws<ArgumentOutOfRangeException>(() => Campaigns = CampaignKeySet.Campaigns(missing));
    }
    [Test]
    public void CampaignsAccessorWithMissingNotThrownTest()
    {
        expectedCampaignCount = 7;
        expectedCampaignKeys = ["Unknown Campaign",
        "Unknown Fantasy Campaign",
        "Unknown Western Campaign",
        "Unknown Pulp Fiction Campaign",
        "Unknown Modern Campaign",
        "Unknown Star Hero Campaign",
        "Unknown Champions Campaign"];
        expectedCampaignNames = new()
        {
            { expectedCampaignKeys[0], "Unknown Campaign" },
            { expectedCampaignKeys[1], "Unknown Fantasy Campaign" },
            { expectedCampaignKeys[2], "Unknown Western Campaign" },
            { expectedCampaignKeys[3], "Unknown Pulp Fiction Campaign" },
            { expectedCampaignKeys[4], "Unknown Modern Campaign" },
            { expectedCampaignKeys[5], "Unknown Star Hero Campaign" },
            { expectedCampaignKeys[6], "Unknown Champions Campaign" } };
        Assert.That(heroes, Is.Not.Null);
        Assert.That(expectedPlayerKeys, Is.Not.Null);
        Assert.That(expectedGameMasterKeys, Is.Not.Null);
        Assert.DoesNotThrow(() => CampaignKeySet = new(ICampaigns.CAMPAIGNS, ref ICampaigns.CAMPAIGNS));
        Assert.That(CampaignKeySet, Is.InstanceOf<CampaignKeySet>());
        Assert.That(CampaignKeySet, Is.Not.Null);
        Campaigns missing = new(Original: ICampaigns.CAMPAIGNS);
        missing.Remove("Unknown Custom Campaign");
        Assert.DoesNotThrow(() => Campaigns = CampaignKeySet.Campaigns(missing, false));
        Assert.That(Campaigns, Is.InstanceOf<Campaigns>());
        Assert.That(Campaigns, Is.Not.Null);
        Assert.That(Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < Campaigns.Count; index++)
        {
            Assert.That(Campaigns.Keys.Contains(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns.ContainsKey(expectedCampaignKeys[index]), Is.True);
            Assert.That(Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[expectedCampaignKeys[index]]));
        }
        Assert.That(Campaigns.PlayerKeys(heroes).Count, Is.EqualTo(expectedPlayerKeys.Count));
        foreach (String key in Campaigns.PlayerKeys(heroes).Keys)
        {
            Assert.That(expectedPlayerKeys.Contains(key), Is.True);
        }
        Assert.That(Campaigns.GameMasterKeys(heroes).Count, Is.EqualTo(expectedGameMasterKeys.Count));
        foreach (String key in Campaigns.GameMasterKeys(heroes).Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
    [Test]
    public void KeysAccessorTest()
    {
        expectedCampaignCount = 1;
        expectedCampaignKeys = ["Campaign 1"];
        Assert.DoesNotThrow(() => CampaignKeySet = new(new(), ref ICampaigns.CAMPAIGNS));
        Assert.That(CampaignKeySet, Is.InstanceOf<CampaignKeySet>());
        Assert.That(CampaignKeySet, Is.Not.Null);
        Assert.That(CampaignKeySet.Keys.Count, Is.EqualTo(expectedCampaignCount));
        foreach (String key in CampaignKeySet.Keys)
        {
            Assert.That(expectedCampaignKeys.Contains(key), Is.True);
        }
    }
}