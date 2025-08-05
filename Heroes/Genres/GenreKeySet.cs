namespace Heroes.Genres;

public class GenreKeySet : HashSet<string>, IGenreKeySet
{
    public string[] Keys { get => GetKeys(); set => SetKeys(value); }
    public GenreKeySet(Genres Genres, ref Genres MasterGenres) => Init(Genres, ref MasterGenres);
    public GenreKeySet(IEnumerable<string> GenreKeys) => Init(GenreKeys);
    public GenreKeySet(GenreKeySet Original) => Init(Original);
    public void Init(Genres Genres, ref Genres MasterGenres) => IGenreKeySet.INIT(this, Genres, ref MasterGenres);
    public void Init(IEnumerable<string> GenreKeys) => IGenreKeySet.INIT(this, GenreKeys);
    public void Init(GenreKeySet Original) => IGenreKeySet.INIT(this, Original);
    public string[] GetKeys() => IGenreKeySet.GET_KEYS(this);
    public void SetKeys(string[] value) => IGenreKeySet.SET_KEYS(this, value);
    public Genres Genres(Genres MasterGenres, bool throwIfMissingInMaster = true) => IGenreKeySet.GENRES(this, MasterGenres, throwIfMissingInMaster);
}
