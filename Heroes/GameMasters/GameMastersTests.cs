using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Heroes.GameMasters;

public class GameMastersTests
{
    KeyValuePair<String, GameMaster.IGameMaster>? GameMasterPair = null;
    GameMasters? GameMasters = null;
    GameMasterKeySet? GameMasterKeySet = null;
    int? expectedSetupGameMasterCount = null;
    String[]? expectedSetupGameMasterKeys = null;
    Dictionary<String, String>? expectedSetupGameMasterNames = null;
    int? expectedGameMasterCount = null;
    String[]? expectedGameMasterKeys = null;
    Dictionary<String, String>? expectedGameMasterNames = null;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NullConstructorTest()
    {
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> { { expectedGameMasterKeys[0], "Unknown GameMaster 1" } };
        Assert.DoesNotThrow(() => GameMasters = new());
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedSetupGameMasterCount = 2;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" } };
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> { { expectedGameMasterKeys[0], "Unknown Game Master 1" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasters.Init());
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GeneratedCountConstructorTest()
    {
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedGameMasterKeys[1], "Unknown Game Master 2" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GeneratedCountInitializorTest()
    {
        expectedSetupGameMasterCount = 3;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2", "Game Master 3"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" },
            { expectedSetupGameMasterKeys[2], "Unknown Game Master 3" } };
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedGameMasterKeys[1], "Unknown Game Master 2" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasters.Init(Count: (int)expectedGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterElementsConstructorTest()
    {
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]]));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterElementsInitializorTest()
    {
        expectedSetupGameMasterCount = 2;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" } };
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasters.Init(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]]));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterKeyValuePairConstructorTest()
    {
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasterPair = new(key: expectedGameMasterKeys[0], value: new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null)));
        Assert.That(GameMasterPair, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMasters = new(GameMaster: (KeyValuePair<String, GameMaster.IGameMaster>)GameMasterPair));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterKeyValuePairInitializorTest()
    {
        expectedSetupGameMasterCount = 2;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" } };
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasterPair = new(key: expectedGameMasterKeys[0], value: new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null)));
        Assert.That(GameMasterPair, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMasters.Init(GameMaster: (KeyValuePair<String, GameMaster.IGameMaster>)GameMasterPair));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterElementsDictionaryConstructorTest()
    {
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Dictionary: new Dictionary<string, string> {
            { expectedGameMasterKeys[0], expectedGameMasterNames[expectedGameMasterKeys[0]]},
            { expectedGameMasterKeys[1], expectedGameMasterNames[expectedGameMasterKeys[1]]}
        }));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterElementsDictionaryInitializorTest()
    {
        expectedSetupGameMasterCount = 3;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2", "Game Master 3"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" },
            { expectedSetupGameMasterKeys[2], "Unknown Game Master 3" } };
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasters.Init(Dictionary: new Dictionary<string, string> {
            { expectedGameMasterKeys[0], expectedGameMasterNames[expectedGameMasterKeys[0]]},
            { expectedGameMasterKeys[1], expectedGameMasterNames[expectedGameMasterKeys[1]]}
        }));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterConstructorTest()
    {
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(GameMaster: new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null)));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterInitializorTest()
    {
        expectedSetupGameMasterCount = 2;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" } };
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasters.Init(GameMaster: new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null)));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterArrayConstructorTest()
    {
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Array: [
            new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null),
            new GameMaster.GameMaster(Key: expectedGameMasterKeys[1], Name: expectedGameMasterNames[expectedGameMasterKeys[1]], null, null)]));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterArrayInitializorTest()
    {
        expectedSetupGameMasterCount = 3;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2", "Game Master 3"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" },
            { expectedSetupGameMasterKeys[2], "Unknown Game Master 3" } };
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasters.Init(Array: [
            new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null),
            new GameMaster.GameMaster(Key: expectedGameMasterKeys[1], Name: expectedGameMasterNames[expectedGameMasterKeys[1]], null, null)]));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterKeyValuePairArrayConstructorTest()
    {
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Array: new KeyValuePair<string, GameMaster.IGameMaster>[] {
            new KeyValuePair<string, GameMaster.IGameMaster>(
                key: expectedGameMasterKeys[0],
                value: new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null)
                ),
            new KeyValuePair<string, GameMaster.IGameMaster>(
                key: expectedGameMasterKeys[1],
                value: new GameMaster.GameMaster(Key: expectedGameMasterKeys[1], Name: expectedGameMasterNames[expectedGameMasterKeys[1]], null, null)
                )}));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterKeyValuePairArrayInitializorTest()
    {
        expectedSetupGameMasterCount = 3;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2", "Game Master 3"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" },
            { expectedSetupGameMasterKeys[2], "Unknown Game Master 3" } };
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasters.Init(Array: new KeyValuePair<string, GameMaster.IGameMaster>[] {
            new KeyValuePair<string, GameMaster.IGameMaster>(
                key: expectedGameMasterKeys[0],
                value: new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null)
                ),
            new KeyValuePair<string, GameMaster.IGameMaster>(
                key: expectedGameMasterKeys[1],
                value: new GameMaster.GameMaster(Key: expectedGameMasterKeys[1], Name: expectedGameMasterNames[expectedGameMasterKeys[1]], null, null)
                )}));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterDictionaryConstructorTest()
    {
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Dictionary: new Dictionary<string, GameMaster.GameMaster> {
            { expectedGameMasterKeys[0], new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null)},
            { expectedGameMasterKeys[1], new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[1]], null, null)}
        }));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterDictionaryInitializorTest()
    {
        expectedSetupGameMasterCount = 3;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2", "Game Master 3"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" },
            { expectedSetupGameMasterKeys[2], "Unknown Game Master 3" } };
        expectedGameMasterCount = 2;
        expectedGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasters.Init(Dictionary: new Dictionary<string, GameMaster.GameMaster> {
            { expectedGameMasterKeys[0], new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]], null, null)},
            { expectedGameMasterKeys[1], new GameMaster.GameMaster(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[1]], null, null)}
        }));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Original: new GameMasters(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]])));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void CopyInitializorTest()
    {
        expectedSetupGameMasterCount = 2;
        expectedSetupGameMasterKeys = ["Game Master 1", "Game Master 2"];
        expectedSetupGameMasterNames = new Dictionary<String, String> {
            { expectedSetupGameMasterKeys[0], "Unknown Game Master 1" },
            { expectedSetupGameMasterKeys[1], "Unknown Game Master 2" } };
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        expectedGameMasterNames = new Dictionary<String, String> {
            { expectedGameMasterKeys[0], "Unknown Game Master" } };
        Assert.DoesNotThrow(() => GameMasters = new(Count: (int)expectedSetupGameMasterCount));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedSetupGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedSetupGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Key, Is.EqualTo(expectedSetupGameMasterKeys[index]));
            Assert.That(GameMasters[expectedSetupGameMasterKeys[index]].Name, Is.EqualTo(expectedSetupGameMasterNames[expectedSetupGameMasterKeys[index]]));
        }
        Assert.DoesNotThrow(() => GameMasters.Init(Original: new GameMasters(Key: expectedGameMasterKeys[0], Name: expectedGameMasterNames[expectedGameMasterKeys[0]])));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void DefaultGameMastersCollectionTest()
    {
        expectedGameMasterCount = 8;
        expectedGameMasterKeys = ["Unknown Game Master",
        "Unknown Fantasy Game Master",
        "Unknown Western Game Master",
        "Unknown Pulp Fiction Game Master",
        "Unknown Modern Game Master",
        "Unknown Star Hero Game Master",
        "Unknown Champions Game Master",
        "Unknown Custom Game Master"];
        expectedGameMasterNames = new()
        {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Fantasy Game Master" },
            { expectedGameMasterKeys[2], "Unknown Western Game Master" },
            { expectedGameMasterKeys[3], "Unknown Pulp Fiction Game Master" },
            { expectedGameMasterKeys[4], "Unknown Modern Game Master" },
            { expectedGameMasterKeys[5], "Unknown Star Hero Game Master" },
            { expectedGameMasterKeys[6], "Unknown Champions Game Master" },
            { expectedGameMasterKeys[7], "Unknown Custom Game Master" } };
        Assert.That(IGameMasters.GAME_MASTERS, Is.InstanceOf<GameMasters>());
        Assert.That(IGameMasters.GAME_MASTERS, Is.Not.Null);
        Assert.That(IGameMasters.GAME_MASTERS.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < IGameMasters.GAME_MASTERS.Count; index++)
        {
            Assert.That(IGameMasters.GAME_MASTERS.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(IGameMasters.GAME_MASTERS.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(IGameMasters.GAME_MASTERS[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(IGameMasters.GAME_MASTERS[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMasterKeySetConstructorTest()
    {
        expectedGameMasterKeys = ["Unknown Game Master", "Unknown Fantasy Game Master", "Unknown Western Game Master", "Unknown Pulp Fiction Game Master", "Unknown Modern Game Master", "Unknown Star Hero Game Master", "Unknown Champions Game Master", "Unknown Custom Game Master"];
        Assert.DoesNotThrow(() => GameMasterKeySet = new(IGameMasters.GAME_MASTERS, ref IGameMasters.GAME_MASTERS));
        Assert.That(GameMasterKeySet, Is.InstanceOf<GameMasterKeySet>());
        Assert.That(GameMasterKeySet, Is.Not.Null);
        Assert.That(GameMasterKeySet.Count, Is.EqualTo(expectedGameMasterKeys.Length));
        for (int index = 0; index < GameMasterKeySet.Count; index++)
        {
            Assert.That(GameMasterKeySet.Keys[index], Is.EqualTo(expectedGameMasterKeys[index]));
        }
    }
    [Test]
    public void GameMasterKeySetConstructorReturnTest()
    {
        expectedGameMasterKeys = ["Unknown Game Master", "Unknown Fantasy Game Master", "Unknown Western Game Master", "Unknown Pulp Fiction Game Master", "Unknown Modern Game Master", "Unknown Star Hero Game Master", "Unknown Champions Game Master", "Unknown Custom Game Master"];
        Assert.DoesNotThrow(() => GameMasters = new());
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMasters.Clear());
        Assert.DoesNotThrow(() => GameMasterKeySet = new(IGameMasters.GAME_MASTERS, ref GameMasters));
        Assert.That(GameMasterKeySet, Is.InstanceOf<GameMasterKeySet>());
        Assert.That(GameMasterKeySet, Is.Not.Null);
        Assert.That(GameMasterKeySet.Count, Is.EqualTo(expectedGameMasterKeys.Length));
        for (int index = 0; index < GameMasterKeySet.Count; index++)
        {
            Assert.That(GameMasterKeySet.Keys[index], Is.EqualTo(expectedGameMasterKeys[index]));
        }
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(IGameMasters.GAME_MASTERS.Count));
        Assert.That(GameMasterKeySet.Count, Is.EqualTo(IGameMasters.GAME_MASTERS.Count));
        foreach (String key in IGameMasters.GAME_MASTERS.Keys)
        {
            Assert.That(GameMasterKeySet.Keys.Contains(key), Is.True);
            Assert.That(GameMasters.ContainsKey(key), Is.True);
            Assert.That(GameMasters[key].Key, Is.EqualTo(IGameMasters.GAME_MASTERS[key].Key));
            Assert.That(GameMasters[key].Name, Is.EqualTo(IGameMasters.GAME_MASTERS[key].Name));
        }
    }
    [Test]
    public void CopyGameMasterKeySetConstructorTest()
    {
        expectedGameMasterKeys = ["Unknown Game Master", "Unknown Fantasy Game Master", "Unknown Western Game Master", "Unknown Pulp Fiction Game Master", "Unknown Modern Game Master", "Unknown Star Hero Game Master", "Unknown Champions Game Master", "Unknown Custom Game Master"];
        Assert.DoesNotThrow(() => GameMasterKeySet = new(Original: new GameMasterKeySet(IGameMasters.GAME_MASTERS, ref IGameMasters.GAME_MASTERS)));
        Assert.That(GameMasterKeySet, Is.InstanceOf<GameMasterKeySet>());
        Assert.That(GameMasterKeySet, Is.Not.Null);
        Assert.That(GameMasterKeySet, Is.InstanceOf<GameMasterKeySet>());
        Assert.That(GameMasterKeySet, Is.Not.Null);
        Assert.That(GameMasterKeySet.Count, Is.EqualTo(expectedGameMasterKeys.Length));
        for (int index = 0; index < GameMasterKeySet.Count; index++)
        {
            Assert.That(GameMasterKeySet.Keys[index], Is.EqualTo(expectedGameMasterKeys[index]));
        }
    }
    [Test]
    public void GameMastersAccessorTest()
    {
        expectedGameMasterCount = 8;
        expectedGameMasterKeys = ["Unknown Game Master",
        "Unknown Fantasy Game Master",
        "Unknown Western Game Master",
        "Unknown Pulp Fiction Game Master",
        "Unknown Modern Game Master",
        "Unknown Star Hero Game Master",
        "Unknown Champions Game Master",
        "Unknown Custom Game Master"];
        expectedGameMasterNames = new()
        {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Fantasy Game Master" },
            { expectedGameMasterKeys[2], "Unknown Western Game Master" },
            { expectedGameMasterKeys[3], "Unknown Pulp Fiction Game Master" },
            { expectedGameMasterKeys[4], "Unknown Modern Game Master" },
            { expectedGameMasterKeys[5], "Unknown Star Hero Game Master" },
            { expectedGameMasterKeys[6], "Unknown Champions Game Master" },
            { expectedGameMasterKeys[7], "Unknown Custom Game Master" } };
        Assert.DoesNotThrow(() => GameMasterKeySet = new(IGameMasters.GAME_MASTERS, ref IGameMasters.GAME_MASTERS));
        Assert.That(GameMasterKeySet, Is.InstanceOf<GameMasterKeySet>());
        Assert.That(GameMasterKeySet, Is.Not.Null);
        Assert.DoesNotThrow(() => GameMasters = GameMasterKeySet.GameMasters(IGameMasters.GAME_MASTERS));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void GameMastersAccessorWithMissingThrownTest()
    {
        expectedGameMasterCount = 7;
        expectedGameMasterKeys = ["Unknown Game Master",
        "Unknown Fantasy Game Master",
        "Unknown Western Game Master",
        "Unknown Pulp Fiction Game Master",
        "Unknown Modern Game Master",
        "Unknown Star Hero Game Master",
        "Unknown Champions Game Master"];
        expectedGameMasterNames = new()
        {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Fantasy Game Master" },
            { expectedGameMasterKeys[2], "Unknown Western Game Master" },
            { expectedGameMasterKeys[3], "Unknown Pulp Fiction Game Master" },
            { expectedGameMasterKeys[4], "Unknown Modern Game Master" },
            { expectedGameMasterKeys[5], "Unknown Star Hero Game Master" },
            { expectedGameMasterKeys[6], "Unknown Champions Game Master" } };
        Assert.DoesNotThrow(() => GameMasterKeySet = new(IGameMasters.GAME_MASTERS, ref IGameMasters.GAME_MASTERS));
        Assert.That(GameMasterKeySet, Is.InstanceOf<GameMasterKeySet>());
        Assert.That(GameMasterKeySet, Is.Not.Null);
        GameMasters missing = new(Original: IGameMasters.GAME_MASTERS);
        missing.Remove("Unknown Custom Game Master");
        Assert.Throws<ArgumentOutOfRangeException>(() => GameMasters = GameMasterKeySet.GameMasters(missing));
    }
    [Test]
    public void GameMastersAccessorWithMissingNotThrownTest()
    {
        expectedGameMasterCount = 7;
        expectedGameMasterKeys = ["Unknown Game Master",
        "Unknown Fantasy Game Master",
        "Unknown Western Game Master",
        "Unknown Pulp Fiction Game Master",
        "Unknown Modern Game Master",
        "Unknown Star Hero Game Master",
        "Unknown Champions Game Master"];
        expectedGameMasterNames = new()
        {
            { expectedGameMasterKeys[0], "Unknown Game Master" },
            { expectedGameMasterKeys[1], "Unknown Fantasy Game Master" },
            { expectedGameMasterKeys[2], "Unknown Western Game Master" },
            { expectedGameMasterKeys[3], "Unknown Pulp Fiction Game Master" },
            { expectedGameMasterKeys[4], "Unknown Modern Game Master" },
            { expectedGameMasterKeys[5], "Unknown Star Hero Game Master" },
            { expectedGameMasterKeys[6], "Unknown Champions Game Master" } };
        Assert.DoesNotThrow(() => GameMasterKeySet = new(IGameMasters.GAME_MASTERS, ref IGameMasters.GAME_MASTERS));
        Assert.That(GameMasterKeySet, Is.InstanceOf<GameMasterKeySet>());
        Assert.That(GameMasterKeySet, Is.Not.Null);
        GameMasters missing = new(Original: IGameMasters.GAME_MASTERS);
        missing.Remove("Unknown Custom Game Master");
        Assert.DoesNotThrow(() => GameMasters = GameMasterKeySet.GameMasters(missing, false));
        Assert.That(GameMasters, Is.InstanceOf<GameMasters>());
        Assert.That(GameMasters, Is.Not.Null);
        Assert.That(GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        for (int index = 0; index < GameMasters.Count; index++)
        {
            Assert.That(GameMasters.Keys.Contains(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters.ContainsKey(expectedGameMasterKeys[index]), Is.True);
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Key, Is.EqualTo(expectedGameMasterKeys[index]));
            Assert.That(GameMasters[expectedGameMasterKeys[index]].Name, Is.EqualTo(expectedGameMasterNames[expectedGameMasterKeys[index]]));
        }
    }
    [Test]
    public void KeysAccessorTest()
    {
        expectedGameMasterCount = 1;
        expectedGameMasterKeys = ["Game Master 1"];
        Assert.DoesNotThrow(() => GameMasterKeySet = new(new(), ref IGameMasters.GAME_MASTERS));
        Assert.That(GameMasterKeySet, Is.InstanceOf<GameMasterKeySet>());
        Assert.That(GameMasterKeySet, Is.Not.Null);
        Assert.That(GameMasterKeySet.Keys.Count, Is.EqualTo(expectedGameMasterCount));
        foreach (String key in GameMasterKeySet.Keys)
        {
            Assert.That(expectedGameMasterKeys.Contains(key), Is.True);
        }
    }
}