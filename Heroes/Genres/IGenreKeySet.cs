namespace Heroes.Genres;

internal interface IGenreKeySet : ISet<string>
{
    static public GenreKeySet DefaultGenreKeys = new(Genres: new Genres(Original: IGenres.GENRES), ref IGenres.GENRES);
    public string[] Keys { get; set; }
    public static string[] GET_KEYS(IGenreKeySet genresKeySet)
    {
        return [.. genresKeySet];
    }
    public static void SET_KEYS(IGenreKeySet genresKeySet, string[] value)
    {
        genresKeySet.Clear();
        genresKeySet.UnionWith(value);
    }
    public static void INIT(IGenreKeySet genresKeySet, Genres genres, ref Genres masterGenres)
    {
        genresKeySet.Clear();
        genresKeySet.UnionWith(genres.Keys);
        foreach (string key in genresKeySet.Except(masterGenres.Keys))
        {
            masterGenres.Add(key, genres[key]);
        }
    }
    public static void INIT(IGenreKeySet genresKeySet, IEnumerable<string> GenreKeys)
    {
        genresKeySet.Clear();
        foreach (string key in GenreKeys)
        {
            genresKeySet.Add(key);
        }
    }
    public static void INIT(IGenreKeySet genresKeySet, GenreKeySet Original)
    {
        genresKeySet.Clear();
        foreach (string key in Original)
        {
            genresKeySet.Add(key);
        }
    }
    public static Genres GENRES(IGenreKeySet genresKeySet, Genres masterGenres, bool throwIfMissingInMaster = true)
    {
        Genres result = [];
        GenreKeySet masterKeySet = new(masterGenres, ref masterGenres);
        GenreKeySet missingKeySet = new([.. genresKeySet.Except(masterKeySet)]);
        if (missingKeySet.Count > 0 && throwIfMissingInMaster) throw new ArgumentOutOfRangeException(nameof(masterGenres), missingKeySet, "Missing keys in the Master list!");
        Genres intersectedGenres = [];
        intersectedGenres.Clear();
        foreach (var key in masterKeySet.Intersect(genresKeySet))
        {
            intersectedGenres.Add(key, masterGenres[key]);
        }
        result.Clear();
        GenreKeySet resultKeySet = new(intersectedGenres, ref masterGenres);
        foreach (string key in resultKeySet)
        {
            result.Add(masterGenres[key]);
        }
        return result;
    }
    public static Dictionary<string, Genre.Genre>.KeyCollection CONVERT_GENRE_KEY_SET_TO_DICTIONARY_KEY_COLLECTION(GenreKeySet KeySet)
    {
        Dictionary<string, Genre.Genre>.KeyCollection collection = new([]);
        foreach (string key in KeySet)
        {
            collection.Append(key);
        }
        return collection;
    }
    public static GenreKeySet CONVERT_DICTIONARY_KEY_COLLECTION_TO_GENRE_KEY_SET(Dictionary<string, Genre.Genre>.KeyCollection KeyCollection)
    {
        HashSet<string> set = [];
        foreach (string key in KeyCollection)
        {
            set.Add(key);
        }
        GenreKeySet keySet = new(set);
        return keySet;
    }
    public void Init(Genres Genres, ref Genres MasterGenres);
    public void Init(IEnumerable<string> GenreKeys);
    public void Init(GenreKeySet Original);
    public string[] GetKeys();
    public Genres Genres(Genres MasterGenres, bool throwIfMissingInMaster = true);
}