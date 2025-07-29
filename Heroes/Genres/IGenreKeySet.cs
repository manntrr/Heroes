namespace Heroes.Genres;

internal interface IGenreKeySet : ISet<String>
{
    public String[] Keys { get; set; }
    public static String[] GET_KEYS(IGenreKeySet genresKeySet)
    {
        return [.. genresKeySet];
    }
    public static void SET_KEYS(IGenreKeySet genresKeySet, String[] value)
    {
        genresKeySet.Clear();
        genresKeySet.UnionWith(value);
    }
    public static void INIT(IGenreKeySet genresKeySet, Genres genres, ref Genres masterGenres)
    {
        genresKeySet.Clear();
        genresKeySet.UnionWith(genres.Keys);
        foreach (String key in genresKeySet.Except(masterGenres.Keys))
        {
            masterGenres.Add(key, genres[key]);
        }
    }
    public static void INIT(IGenreKeySet genresKeySet, IEnumerable<string> GenreKeys)
    {
        genresKeySet.Clear();
        foreach (String key in GenreKeys)
        {
            genresKeySet.Add(key);
        }
    }
    public static void INIT(IGenreKeySet genresKeySet, GenreKeySet Original)
    {
        genresKeySet.Clear();
        foreach (String key in Original)
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
        foreach (String key in resultKeySet)
        {
            result.Add(masterGenres[key]);
        }
        return result;
    }
    public void Init(Genres Genres, ref Genres MasterGenres);
    public void Init(IEnumerable<string> GenreKeys);
    public void Init(GenreKeySet Original);
    public String[] GetKeys();
    public Genres Genres(Genres MasterGenres, bool throwIfMissingInMaster = true);
}