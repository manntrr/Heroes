using GenreInterfaceObject = Heroes.Genres.Genre.IGenre;
using GenreObject = Heroes.Genres.Genre.Genre;
using GenresInterfaceObject = Heroes.Genres.IGenres;
using GenresObject = Heroes.Genres.Genres;
using CampaignsObject = Heroes.Campaigns.Campaigns;
using CampaignKeySetObject = Heroes.Campaigns.CampaignKeySet;
using PlayersObject = Heroes.GameMasters.GameMaster.Players.Players;
using PlayerKeySetObject = Heroes.GameMasters.GameMaster.Players.PlayerKeySet;
using GameMastersObject = Heroes.GameMasters.GameMasters;
using GameMasterKeySetObject = Heroes.GameMasters.GameMasterKeySet;

using CampaignKeySet = Heroes.Campaigns.CampaignKeySet;
using CampaignObject = Heroes.Campaigns.Campaign.Campaign;
using GameMasterKeySet = Heroes.GameMasters.GameMasterKeySet;
//using GameMasterObject = Heroes.GameMasters.GameMaster.GameMaster;
using PlayerKeySet = Heroes.GameMasters.GameMaster.Players.PlayerKeySet;
//using PlayerObject = Heroes.GameMasters.GameMaster.Players.Player.Player;
using TCDD = NUnit.Framework.TestCaseDataDictionary;
using Heroes.Genres.Genre;
using System.Reflection.Metadata.Ecma335;


namespace Heroes.Genres;

public interface IGenres : IDictionary<string, GenreObject>
{
    static public void INIT(GenresInterfaceObject Genres, int Count = 1)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        for (int index = 0; index < Count; index++)
            Genres.Add(new GenreObject(Index: index + 1));
    }
    static public void INIT(GenresInterfaceObject Genres, string Key, string Name)
    {
        INIT(Genres: Genres, Genre: new GenreObject(Key: Key, Name: Name));
    }
    static public void INIT(GenresInterfaceObject Genres, GenreObject Genre)
    {
        INIT(Genres: Genres, GenreArray: [new GenreObject(Genre: Genre)]);
    }
    static public void INIT(GenresInterfaceObject Genres, string Key, GenreObject Genre)
    {
        INIT(Genres: Genres, Genre: new GenreObject(Key: Key, Name: Genre.Name));
    }
    static public void INIT(GenresInterfaceObject Genres, KeyValuePair<string, string> GenreKeyNamePair)
    {
        INIT(Genres: Genres, Genre: new GenreObject(Key: GenreKeyNamePair.Key, Name: GenreKeyNamePair.Value));
    }
    static public void INIT(GenresInterfaceObject Genres, KeyValuePair<string, GenreObject> Genre)
    {
        INIT(Genres: Genres, Genre: new GenreObject(Key: Genre.Key, Name: Genre.Value.Name));
    }
    static public void INIT(GenresInterfaceObject Genres, GenreObject[] GenreArray)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (GenreObject genre in GenreArray)
        {
            Genres.Add(genre);
        }
    }
    static public void INIT(GenresInterfaceObject Genres, KeyValuePair<string, string>[] GenreKeyNamePairArray)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (KeyValuePair<string, string> pair in GenreKeyNamePairArray)
        {
            Genres.Add(key: pair.Key, value: new GenreObject(Key: pair.Key, Name: pair.Value));
        }
    }
    static public void INIT(GenresInterfaceObject Genres, KeyValuePair<string, GenreObject>[] GenrePairArray)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (KeyValuePair<string, GenreObject> genre in GenrePairArray)
        {
            Genres.Add(genre);
        }
    }
    static public void INIT(GenresInterfaceObject Genres, Dictionary<string, string> Dictionary)
    {
        if (Genres.Count > 0)
            foreach (string key in Genres.Keys)
                Genres.Remove(key);
        foreach (string key in Dictionary.Keys)
            Genres.Add(new GenreObject(Key: key, Name: Dictionary[key]));
    }
    static public void INIT(GenresInterfaceObject Genres, Dictionary<string, GenreObject> Dictionary)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (string key in Dictionary.Keys)
            Genres.Add(new GenreObject(Key: key, Name: Dictionary[key].Name));
    }
    static public void INIT(GenresInterfaceObject Genres, GenresObject Original)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (KeyValuePair<string, GenreObject> genre in Original)
        {
            Genres.Add(genre);
        }
    }
    static public void INIT(GenresInterfaceObject Genres, GenresInterfaceObject Original)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (KeyValuePair<string, GenreObject> genre in ((IDictionary<string, GenreObject>)Original))
        {
            Genres.Add(genre);
        }
    }

    static public IEnumerator<KeyValuePair<string, GenreObject>> GET_ENUMERATOR(Genres Genres)
    {
        List<KeyValuePair<string, GenreObject>> genrePairs = new();
        foreach (String key in Genres.Keys)
        {
            genrePairs.Add(new(key, Genres[key]));
        }
        foreach (KeyValuePair<string, GenreObject> kvp in genrePairs)
        {
            yield return kvp;
        }
        /*
            /// <summary>
            /// Yields all values in the collection
            /// </summary>
            IEnumerator IEnumerable.GetEnumerator()
            {
                // call the generic version of the method
                return GetEnumerator();
            }
        /**/
    }
    static public ICollection<string> KEYS(Dictionary<string, GenreObject> Genres)
    {
        return Genres.Keys;
    }
    static public ICollection<GenreObject> VALUES(Dictionary<string, GenreObject> Genres)
    {
        return Genres.Values.Cast<GenreObject>().ToList();
    }
    static public GenreObject GET_GENRE(GenresInterfaceObject Genres, string Key)
    {
        return ((Dictionary<string, GenreObject>)Genres)[Key];
    }
    static public void SET_GENRE(GenresInterfaceObject Genres, string Key, GenreObject Genre)
    {
        ((Dictionary<string, GenreObject>)Genres)[Key] = (GenreObject)Genre;
    }
    static public void ADD(GenresInterfaceObject Genres, string Key, GenreObject Genre)
    {
        if (((Dictionary<string, GenreObject>)Genres).ContainsKey(key: Key))
            ((Dictionary<string, GenreObject>)Genres)[Key] = (GenreObject)Genre;
        else
            ((Dictionary<string, GenreObject>)Genres).Add(key: Key, value: (GenreObject)Genre);
    }
    static public void ADD(GenresInterfaceObject Genres, KeyValuePair<string, GenreObject> Item)
    {
        if (Genres.ContainsKey(Item.Key)) Genres[Item.Key] = Item.Value;
        else Genres.Add(Item.Key, Item.Value);
    }
    static public void ADD(GenresInterfaceObject Genres, GenreObject genre)
    {
        if (Genres.ContainsKey(genre.Key)) Genres[genre.Key] = genre;
        else Genres.Add(key: genre.Key, value: genre);
    }
    static public bool IS_READ_ONLY(GenresInterfaceObject Genres)
    {
        return false;
    }
    static public bool TRY_GET_VALUE(GenresInterfaceObject Genres, string Key, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out GenreObject Value)
    {
        GenreObject? genreValue;
        bool result = Genres.TryGetValue(Key, out genreValue);
        Value = result ? genreValue : null;
        return result;
    }
    static public bool CONTAINS(GenresInterfaceObject Genres, KeyValuePair<string, GenreObject> Item)
    {
        GenreObject? genreValue;
        if (Genres.TryGetValue(Item.Key, out genreValue))
        {
            return EqualityComparer<GenreObject>.Default.Equals(genreValue, Item.Value);
        }
        return false;
    }
    static public void COPY_TO(GenresInterfaceObject Genres, KeyValuePair<string, GenreObject>[] Array, int ArrayIndex)
    {
        Genres.CopyTo(Array, ArrayIndex);
    }
    static public bool REMOVE(GenresInterfaceObject Genres, KeyValuePair<string, GenreObject> Item)
    {
        return Genres.Remove(Item);
    }
    static public Dictionary<string, GenreInterfaceObject> CONVERT_GENRES_TO_DICTIONARY(GenresInterfaceObject Genres)
    {
        Dictionary<string, GenreInterfaceObject> result = [];
        foreach (KeyValuePair<string, GenreObject> genre in Genres)
        {
            result.Add(genre.Key, genre.Value);
        }
        return result;
    }
    static public GenresInterfaceObject CONVERT_DICTIONARY_TO_GENRES(Dictionary<string, GenreInterfaceObject> Dictionary)
    {
        GenresInterfaceObject result = new GenresObject();
        if (result.Count > 0)
            foreach (var key in result.Keys)
                result.Remove(key);
        foreach (KeyValuePair<string, GenreInterfaceObject> genre in Dictionary)
        {
            result.Add((GenreObject)genre.Value);
        }
        return result;
    }
    public static GenreKeySet CONVERT_GENRES_TO_GENRE_KEY_SET(GenresObject Genres)
    {
        return (GenreKeySet)Genres.Keys;
    }
    public static GenresObject CONVERT_GENRE_KEY_SET_TO_GENRES(GenreKeySet KeySet, GenresObject MasterList, bool ThrowIfMissing = true)
    {
        throw new NotImplementedException();
    }
    public static GenreObject[] CONVERT_GENRES_TO_GENRE_ARRAY(GenresObject Genres)
    {
        List<GenreObject> list = [];
        foreach (string key in Genres.Keys)
        {
            list.Add(Genres[key]);
        }
        return list.ToArray<GenreObject>();
    }
    public static GenresObject CONVERT_GENRE_ARRAY_TO_GENRES(GenreObject[] GenreArray)
    {
        GenresObject result = [];
        foreach (GenreObject genre in GenreArray)
        {
            result.Add(genre);
        }
        return result;
    }
    public static KeyValuePair<string, string>[] CONVERT_GENRES_TO_GENRE_KEY_NAME_PAIR_ARRAY(GenresObject Genres)
    {
        List<KeyValuePair<string, string>> list = [];
        foreach (string key in Genres.Keys)
        {
            list.Add(new(key, Genres[key].Name));
        }
        return list.ToArray<KeyValuePair<string, string>>();
    }
    public static GenresObject CONVERT_GENRE_KEY_NAME_PAIR_ARRAY_TO_GENRES(KeyValuePair<string, string>[] GenreKeyNamePairArray)
    {
        GenresObject result = [];
        foreach (KeyValuePair<string, string> pair in GenreKeyNamePairArray)
        {
            result.Add(new GenreObject(pair.Key, pair.Value));
        }
        return result;
    }
    public static KeyValuePair<string, GenreObject>[] CONVERT_GENRES_TO_GENRE_KEY_PAIR_ARRAY(GenresObject Genres)
    {
        List<KeyValuePair<string, GenreObject>> list = [];
        foreach (string key in Genres.Keys)
        {
            list.Add(new(key, Genres[key]));
        }
        return list.ToArray<KeyValuePair<string, GenreObject>>();
    }
    public static GenresObject CONVERT_GENRE_KEY_PAIR_ARRAY_TO_GENRES(KeyValuePair<string, GenreObject>[] GenreKeyPairArray)
    {
        GenresObject result = [];
        foreach (KeyValuePair<string, GenreObject> pair in GenreKeyPairArray)
        {
            result.Add(pair.Key, pair.Value);
        }
        return result;
    }
    public static Dictionary<string, string> CONVERT_GENRES_TO_GENRE_KEY_NAME_DICTIONARY(GenresObject Genres)
    {
        Dictionary<string, string> result = [];
        foreach (string key in Genres.Keys)
        {
            result.Add(key, Genres[key].Name);
        }
        return result;
    }
    public static GenresObject CONVERT_GENRE_KEY_NAME_DICTIONARY_TO_GENRES(Dictionary<string, string> GenreKeyNameDictionary)
    {
        GenresObject result = [];
        foreach (string key in GenreKeyNameDictionary.Keys)
        {
            result.Add(new GenreObject(Key: key, Name: GenreKeyNameDictionary[key]));
        }
        return result;
    }
    static public CampaignKeySetObject CAMPAIGN_KEYS(GenresInterfaceObject Genres, Heroes Heroes)
    {
        CampaignsObject temp = [];
        CampaignKeySetObject campaigns = new([], ref temp);
        campaigns.Clear();
        foreach (KeyValuePair<string, GenreObject> pair in Genres)
        {
            campaigns.Union(pair.Value.CampaignKeys(Heroes));
        }
        return campaigns;
    }
    static public PlayerKeySetObject PLAYER_KEYS(GenresInterfaceObject Genres, Heroes Heroes)
    {
        PlayersObject temp = [];
        PlayerKeySetObject players = new([], ref temp);
        players.Clear();
        foreach (KeyValuePair<string, GenreObject> pair in Genres)
        {
            players.Union(pair.Value.PlayerKeys(Heroes));
        }
        return players;
    }
    static public GameMasterKeySetObject GAME_MASTER_KEYS(GenresInterfaceObject Genres, Heroes Heroes)
    {
        GameMastersObject temp = [];
        GameMasterKeySetObject gameMasters = new([], ref temp);
        gameMasters.Clear();
        foreach (KeyValuePair<string, GenreObject> pair in Genres)
        {
            gameMasters.Union(pair.Value.GameMasterKeys(Heroes));
        }
        return gameMasters;
    }
    static public Genres GENRES = (Genres)CONVERT_DICTIONARY_TO_GENRES(new Dictionary<string, GenreInterfaceObject> {
        { "Unknown", new GenreObject(Key: "Unknown", Name: "Unknown") },
        { "Fantasy", new GenreObject(Key: "Fantasy", Name: "Fantasy") },
        { "Western", new GenreObject(Key: "Western", Name: "Western") },
        { "Pulp Fiction", new GenreObject(Key: "Pulp Fiction", Name: "Pulp Fiction") },
        { "Modern", new GenreObject(Key: "Modern", Name: "Modern") },
        { "Star Hero", new GenreObject(Key: "Star Hero", Name: "Star Hero") },
        { "Champions", new GenreObject(Key: "Champions", Name: "Champions") },
        { "Custom", new GenreObject(Key: "Custom", Name: "Custom") }
    });
    public void Init(int count = 1);
    public void Init(string Key, string Name);
    public void Init(GenreObject Genre);
    public void Init(string Key, GenreObject Genre);
    public void Init(KeyValuePair<string, string> GenreKeyNamePair);
    public void Init(KeyValuePair<string, GenreObject> Genre);
    public void Init(GenreObject[] Genres);
    public void Init(KeyValuePair<string, string>[] GenreKeyNamePairArray);
    public void Init(KeyValuePair<string, GenreObject>[] Genres);
    public void Init(Dictionary<string, string> Dictionary);
    public void Init(Dictionary<string, GenreObject> Dictionary);
    public void Init(GenresObject Genres);
    public void Init(GenresInterfaceObject Genres);
    public new IEnumerator<KeyValuePair<string, GenreObject>> GetEnumerator();
    public GenreObject GetGenre(string Key);
    public void SetGenre(string Key, GenreObject Genre);
    public new void Add(string Key, GenreObject Genre);
    public void Add(GenreObject genre);
    public CampaignKeySetObject CampaignKeys(Heroes Heroes);
    public PlayerKeySetObject PlayerKeys(Heroes Heroes);
    public GameMasterKeySetObject GameMasterKeys(Heroes Heroes);
    private static readonly Heroes heroes = new();
    private static CampaignsObject campaigns = heroes.Campaigns;
    private static PlayersObject players = heroes.Players;
    private static GameMastersObject gameMasters = heroes.GameMasters;
    private static int counter = 0;
    static readonly TestCasesDataDictionary TEST_CASE_DATA = new([
        new(nameof(GenresTests.NullConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Genre 1", Name:  "Unknown Genre 1")]),
                    //new CampaignKeySet(Campaigns: new([ICampaigns.CAMPAIGNS["Unknown Campaign"]]), MasterCampaigns: ref ICampaigns.CAMPAIGNS);
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    //new PlayerKeySet(Players: new([IPlayers.PLAYERS["Unknown Player"]]), MasterPlayers: ref IPlayers.PLAYERS);
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    //new GameMasterKeySet(GameMasters: new([IGameMasters.GAME_MASTERS["Unknown Game Master"]]), MasterGameMasters: ref IGameMasters.GAME_MASTERS);
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenresTests.NullInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1")]),
                    new GenresObject([new GenreObject(Key: "Genre 1", Name:  "Unknown Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)
                    )
            ])),
        new(nameof(GenresTests.GeneratedCountConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    0, new GenresObject(new GenreObject[0]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    1, new GenresObject([new GenreObject(Key: "Genre 1", Name:  "Unknown Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    2, new GenresObject([new GenreObject(Key: "Genre 1", Name:  "Unknown Genre 1"), new GenreObject(Key: "Genre 2", Name:  "Unknown Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GeneratedCountInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    0, new GenresObject(new GenreObject[0]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    1, new GenresObject([new GenreObject(Key: "Genre 1", Name:  "Unknown Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    2, new GenresObject([new GenreObject(Key: "Genre 1", Name:  "Unknown Genre 1"), new GenreObject(Key: "Genre 2", Name:  "Unknown Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreElementsConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    "Custom Genre 1 Key", "Custom Genre 1", new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    "Custom Genre 2 Key", "Custom Genre 2", new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreElementsInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    "Custom Genre 1 Key", "Custom Genre 1", new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    "Custom Genre 2 Key", "Custom Genre 2", new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.KeyNameKeyValuePairConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new KeyValuePair<string,string>(key: "Custom Genre 1 Key", value: "Custom Genre 1"), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new KeyValuePair<string,string>(key: "Custom Genre 2 Key", value: "Custom Genre 2"), new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.KeyNameKeyValuePairInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new KeyValuePair<string,string>(key: "Custom Genre 1 Key", value: "Custom Genre 1"), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new KeyValuePair<string,string>(key: "Custom Genre 2 Key", value: "Custom Genre 2"), new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreKeyValuePairConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new KeyValuePair<string,GenreObject>(key: "Custom Genre 1 Key", value: new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new KeyValuePair<string,GenreObject>(key: "Custom Genre 2 Key", value: new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")), new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreKeyValuePairInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new KeyValuePair<string,GenreObject>(key: "Custom Genre 1 Key", value: new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new KeyValuePair<string,GenreObject>(key: "Custom Genre 2 Key", value: new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")), new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreElementsDictionaryConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new Dictionary<string, string> { { "Custom Genre 1 Key", "Custom Genre 1"}, { "Custom Genre 2 Key", "Custom Genre 2"} },
                    new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new Dictionary<string, string> { { "Custom Genre 2 Key", "Custom Genre 2"} },
                    new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreElementsDictionaryInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new Dictionary<string, string> { { "Custom Genre 1 Key", "Custom Genre 1"}, { "Custom Genre 2 Key", "Custom Genre 2"} },
                    new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new Dictionary<string, string> { { "Custom Genre 2 Key", "Custom Genre 2"} },
                    new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2"), new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2"), new GenresObject([new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreArrayConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenreObject[] { new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1") }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenreObject[] { new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2") }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreArrayInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new GenreObject[] { new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1") }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new GenreObject[] { new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2") }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.KeyNameKeyValuePairArrayConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(key: "Custom Genre 1 Key", value:  "Custom Genre 1") }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(key: "Custom Genre 1 Key", value:  "Custom Genre 1"), new KeyValuePair<string, string>(key: "Custom Genre 2 Key", value:  "Custom Genre 2") }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.KeyNameKeyValuePairArrayInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(key: "Custom Genre 1 Key", value:  "Custom Genre 1") }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(key: "Custom Genre 1 Key", value:  "Custom Genre 1"), new KeyValuePair<string, string>(key: "Custom Genre 2 Key", value:  "Custom Genre 2") }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreKeyValuePairArrayConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new KeyValuePair<string, GenreObject>[] { new KeyValuePair<string, GenreObject>(key: "Custom Genre 1 Key", value:  new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")) }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new KeyValuePair<string, GenreObject>[] { new KeyValuePair<string, GenreObject>(key: "Custom Genre 1 Key", value:  new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")), new KeyValuePair<string, GenreObject>(key: "Custom Genre 2 Key", value:  new GenreObject(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")) }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreKeyValuePairArrayInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new KeyValuePair<string, GenreObject>[] { new KeyValuePair<string, GenreObject>(key: "Custom Genre 1 Key", value:  new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")) }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new KeyValuePair<string, GenreObject>[] { new KeyValuePair<string, GenreObject>(key: "Custom Genre 1 Key", value:  new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")), new KeyValuePair<string, GenreObject>(key: "Custom Genre 2 Key", value:  new GenreObject(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")) }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreDictionaryConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new Dictionary<string, GenreObject> { { "Custom Genre 1 Key", new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")} }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new Dictionary<string, GenreObject> { { "Custom Genre 1 Key", new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")}, { "Custom Genre 2 Key", new GenreObject(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")} }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.GenreDictionaryInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new Dictionary<string, GenreObject> { { "Custom Genre 1 Key", new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")} }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new Dictionary<string, GenreObject> { { "Custom Genre 1 Key", new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")}, { "Custom Genre 2 Key", new GenreObject(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")} }, new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.CopyConstructorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.ConstructorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject(Dictionary: new Dictionary<string, GenreObject> { { "Custom Genre 1 Key", new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")} }), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject(Dictionary: new Dictionary<string, GenreObject> { { "Custom Genre 1 Key", new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")}, { "Custom Genre 2 Key", new GenreObject(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")} }), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.CopyInitializorTest), new(
            TestCaseDescriptions: [TCDD.EmptyString, TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.InitializorString],
            TestCaseIds: [counter++.ToString(),counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new GenresObject(Dictionary: new Dictionary<string, GenreObject> { { "Custom Genre 1 Key", new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")} }), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters)),
                new(
                    new GenresObject([new GenreObject(Key: "Custom Genre 1", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2", Name:  "Custom Genre 2"), new GenreObject(Key: "Custom Genre 3", Name:  "Custom Genre 3")]),
                    new GenresObject(Dictionary: new Dictionary<string, GenreObject> { { "Custom Genre 1 Key", new GenreObject(Key: "Custom Genre 1 Key", Name: "Custom Genre 1")}, { "Custom Genre 2 Key", new GenreObject(Key: "Custom Genre 2 Key", Name: "Custom Genre 2")} }), new GenresObject([new GenreObject(Key: "Custom Genre 1 Key", Name:  "Custom Genre 1"), new GenreObject(Key: "Custom Genre 2 Key", Name:  "Custom Genre 2")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ])),
        new(nameof(GenresTests.DefaultGenresCollectionTest), new(
            TestCaseDescriptions: [TCDD.EmptyString],
            TestCaseCategories: [TestCaseDataDictionary.AccessorString],
            TestCaseIds: [counter++.ToString()],
            TestCaseData: [
                new(
                    new GenresObject([new GenreObject(Key: "Unknown", Name:  "Unknown"), new GenreObject(Key: "Fantasy", Name:  "Fantasy"), new GenreObject(Key: "Western", Name:  "Western"), new GenreObject(Key: "Pulp Fiction", Name:  "Pulp Fiction"), new GenreObject(Key: "Modern", Name:  "Modern"), new GenreObject(Key: "Star Hero", Name:  "Star Hero"), new GenreObject(Key: "Champions", Name:  "Champions"), new GenreObject(Key: "Custom", Name:  "Custom")]),
                    new CampaignKeySet(Campaigns: new(Count: 0), MasterCampaigns: ref campaigns),
                    new PlayerKeySet(Players: new(Count: 0), MasterPlayers: ref players),
                    new GameMasterKeySet(GameMasters: new(Count: 0), MasterGameMasters: ref gameMasters))
                    ]))]);
}