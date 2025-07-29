namespace Heroes.Genres;

public class GenreKeySet : HashSet<String>, IGenreKeySet
{
    public String[] Keys { get => GetKeys(); set => SetKeys(value); }
    public GenreKeySet(Genres Genres, ref Genres MasterGenres) => Init(Genres, ref MasterGenres);
    public GenreKeySet(IEnumerable<string> GenreKeys) => Init(GenreKeys);
    public GenreKeySet(GenreKeySet Original) => Init(Original);
    public void Init(Genres Genres, ref Genres MasterGenres) => IGenreKeySet.INIT(this, Genres, ref MasterGenres);
    public void Init(IEnumerable<string> GenreKeys) => IGenreKeySet.INIT(this, GenreKeys);
    public void Init(GenreKeySet Original) => IGenreKeySet.INIT(this, Original);
    public String[] GetKeys() => IGenreKeySet.GET_KEYS(this);
    public void SetKeys(String[] value) => IGenreKeySet.SET_KEYS(this, value);
    public Genres Genres(Genres MasterGenres, bool throwIfMissingInMaster = true) => IGenreKeySet.GENRES(this, MasterGenres, throwIfMissingInMaster);
}
