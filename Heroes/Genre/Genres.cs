using System.Diagnostics.CodeAnalysis;

namespace Heroes;

public class Genres : Dictionary<String, Genre>, IGenres
{
    ICollection<string> IDictionary<string, IGenre>.Keys => IGenres.KEYS(Genres: this);
    ICollection<IGenre> IDictionary<string, IGenre>.Values => IGenres.VALUES(Genres: this);
    public bool IsReadOnly => IGenres.IS_READ_ONLY(Genres: this);

    public Dictionary<string, string> Dictionary { get; }
    public object Array { get; }

    IGenre IDictionary<string, IGenre>.this[string key]
    {
        get => IGenres.GET_GENRE(Genres: this, Key: key);
        set => IGenres.SET_GENRE(Genres: this, Key: key, Genre: value);
    }
    public void Add(string key, IGenre value) => base.Add(key: key, value: (Genre)value);
    //=> IGenres.ADD(Genres: this, Key: key, Genre: value);
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out IGenre value)
    {
        IGenre? genreValue;
        bool result = IGenres.TRY_GET_VALUE(Genres: this, Key: key, Value: out genreValue);
        value = genreValue;
        return result;
    }
    public void Add(KeyValuePair<string, IGenre> item) => IGenres.ADD(Genres: this, Item: item);
    public bool Contains(KeyValuePair<string, IGenre> item) => IGenres.CONTAINS(Genres: this, Item: item);
    public void CopyTo(KeyValuePair<string, IGenre>[] array, int arrayIndex) => IGenres.COPY_TO(Genres: this, Array: array, ArrayIndex: arrayIndex);
    public bool Remove(KeyValuePair<string, IGenre> item) => IGenres.REMOVE(Genres: this, Item: item);
    IEnumerator<KeyValuePair<string, IGenre>> IEnumerable<KeyValuePair<string, IGenre>>.GetEnumerator()
    {
        foreach (var kvp in this)
        {
            yield return new KeyValuePair<string, IGenre>(kvp.Key, kvp.Value);
        }
    }
    // => IGenres.GET_ENUMERATOR(Genres: this);
    public Genres(int Count = 1) => Init(Count: Count);
    public Genres(String Key, String Name) => Init(Key: Key, Name: Name);
    public Genres(IGenre Genre) => Init(Genre: Genre);
    public Genres(String Key, IGenre Genre) => Init(Key: Key, Genre: Genre);
    public Genres(KeyValuePair<String, IGenre> Genre) => Init(Genre: Genre);
    public Genres(IGenre[] Array) => Init(Array: Array);
    public Genres(KeyValuePair<String, IGenre>[] Array) => Init(Array: Array);
    public Genres(Dictionary<String, String> Dictionary) => Init(Dictionary: Dictionary);
    public Genres(Dictionary<String, Genre> Dictionary) => Init(Dictionary: Dictionary);
    public Genres(IGenres Original) => Init(Original: Original);




    public void Init(int Count = 1) => IGenres.INIT(this, Count: Count);
    public void Init(String Key, String Name) => IGenres.INIT(this, Key: Key, Name: Name);
    public void Init(IGenre Genre) => IGenres.INIT(this, Genre: Genre);
    public void Init(String Key, IGenre Genre) => IGenres.INIT(this, Key: Key, Genre: Genre);
    public void Init(KeyValuePair<String, IGenre> Genre) => IGenres.INIT(this, Genre: Genre);
    public void Init(IGenre[] Array) => IGenres.INIT(this, GenreArray: Array);
    public void Init(KeyValuePair<String, IGenre>[] Array) => IGenres.INIT(this, GenrePairArray: Array);
    public void Init(Dictionary<String, String> Dictionary) => IGenres.INIT(this, Dictionary: Dictionary);
    public void Init(Dictionary<String, Genre> Dictionary) => IGenres.INIT(this, Dictionary: Dictionary);
    public void Init(IGenres Original) => IGenres.INIT(this, Original: Original);
    public void Add(IGenre genre) => IGenres.ADD(this, genre);
    public static implicit operator Dictionary<String, IGenre>(Genres Genres) => IGenres.CONVERT_GENRES_TO_DICTIONARY(Genres: Genres);
    public static explicit operator Genres(Dictionary<String, IGenre> Dictionary) => (Genres)IGenres.CONVERT_DICTIONARY_TO_GENRES(Dictionary: Dictionary);
}
