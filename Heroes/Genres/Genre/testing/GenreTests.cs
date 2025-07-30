using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Is = NUnit.Framework.Constraints.Is;
using NUnit.Framework.Constraints;

namespace Heroes.Genres.Genre;

public class GenreTests
{
    static readonly Heroes heroes = new();
    Genre? genre = null;
    [SetUp]
    public void Setup()
    {
    }
    static readonly TestCaseData[] NullConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullConstructorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NullConstructorTestCases))]
    public void NullConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedKey, Is.Not.Null);
            Assert.That(caseExpectedName, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] NullInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NullInitializorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NullInitializorTestCases))]
    public void NullInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.Multiple(() =>
        {
            Assert.That(heroes, Is.Not.Null);
            Assert.That(caseExpectedKey, Is.Not.Null);
            Assert.That(caseExpectedName, Is.Not.Null);
            Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
            Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
            Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        });
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.Multiple(() =>
        {
            Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
            Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
            //Assert.That(genre, Is.Not.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
            Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
            Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        });
        Assert.DoesNotThrow(() => genre.Init());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] KeyConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KeyConstructorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KeyConstructorTestCases))]
    public void KeyConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] KeyInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KeyInitializorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KeyInitializorTestCases))]
    public void KeyInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] NameConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NameConstructorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NameConstructorTestCases))]
    public void NameConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Name: caseExpectedName));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] NameInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(NameInitializorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(NameInitializorTestCases))]
    public void NameInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Name: caseExpectedName));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] KeyNameConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KeyNameConstructorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KeyNameConstructorTestCases))]
    public void KeyNameConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey, Name: caseExpectedName));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] KeyNameInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(KeyNameInitializorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(KeyNameInitializorTestCases))]
    public void KeyNameInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Key: caseExpectedKey, Name: caseExpectedName));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] IndexConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(IndexConstructorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(IndexConstructorTestCases))]
    public void IndexConstructorTest(int givenIndex, string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: givenIndex));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] IndexInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(IndexInitializorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(IndexInitializorTestCases))]
    public void IndexInitializorTest(int givenIndex, string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Index: givenIndex));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] CopyConstructorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyConstructorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyConstructorTestCases))]
    public void CopyConstructorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Genre: new(Key: caseExpectedKey, Name: caseExpectedName)));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] CopyInitializorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(CopyInitializorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(CopyInitializorTestCases))]
    public void CopyInitializorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Init(Genre: new(Key: caseExpectedKey, Name: caseExpectedName)));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] GetKeyAccessorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetKeyAccessorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetKeyAccessorTestCases))]
    public void GetKeyAccessorTest(string caseExpectedKey)
    {
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
    }
    static readonly TestCaseData[] SetKeyAccessorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(SetKeyAccessorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(SetKeyAccessorTestCases))]
    public void SetKeyAccessorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Key = caseExpectedKey);
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] GetNameAccessorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetNameAccessorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetNameAccessorTestCases))]
    public void GetNameAccessorTest(string caseExpectedName)
    {
        Assert.That(caseExpectedName, Is.Not.Null);
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreNameEqual(caseExpectedName));
    }
    static readonly TestCaseData[] SetNameAccessorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(SetNameAccessorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(SetNameAccessorTestCases))]
    public void SetNameAccessorTest(string caseExpectedKey, string caseExpectedName, CampaignKeySet caseExpectedCampaignKeys, PlayerKeySet caseExpectedPlayerKeys, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.Not.GenreNameEqual(caseExpectedName));
        //Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
        Assert.DoesNotThrow(() => genre.Name = caseExpectedName);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreElementsEqual(heroes, caseExpectedKey, caseExpectedName, caseExpectedCampaignKeys, caseExpectedPlayerKeys, caseExpectedGameMasterKeys));
    }
    static readonly TestCaseData[] GetCampaignKeysAccessorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetCampaignKeysAccessorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetCampaignKeysAccessorTestCases))]
    public void GetCampaignKeysAccessorTest(string caseExpectedKey, CampaignKeySet caseExpectedCampaignKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedCampaignKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.GenreCampaignKeysEqual(heroes, caseExpectedCampaignKeys));
    }
    static readonly TestCaseData[] GetPlayerKeysAccessorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetPlayerKeysAccessorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetPlayerKeysAccessorTestCases))]
    public void GetPlayerKeysAccessorTest(string caseExpectedKey, PlayerKeySet caseExpectedPlayerKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedPlayerKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.GenrePlayerKeysEqual(heroes, caseExpectedPlayerKeys));
    }
    static readonly TestCaseData[] GetGameMasterKeysAccessorTestCases = TestCasesDataDictionary.TestCaseDataArray(nameof(GetGameMasterKeysAccessorTest), IGenre.TEST_CASE_DATA);
    [Test]
    [TestCaseSource(nameof(GetGameMasterKeysAccessorTestCases))]
    public void GetGameMasterKeysAccessorTest(string caseExpectedKey, GameMasterKeySet caseExpectedGameMasterKeys)
    {
        Assert.That(heroes, Is.Not.Null);
        Assert.That(caseExpectedKey, Is.Not.Null);
        Assert.That(caseExpectedGameMasterKeys, Is.Not.Null);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.DoesNotThrow(() => genre = new(Key: caseExpectedKey));
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.GenreKeyEqual(caseExpectedKey));
        Assert.That(genre, Is.GenreGameMasterKeysEqual(heroes, caseExpectedGameMasterKeys));
    }
}
