using System.Diagnostics.CodeAnalysis;
using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres.Genre;
using Microsoft.VisualBasic;

namespace Heroes.Genres;

public class Genres : Dictionary<String, Genre.Genre>, IGenres
{
    ICollection<string> IDictionary<string, IGenre>.Keys => IGenres.KEYS(Genres: this);
    ICollection<IGenre> IDictionary<string, IGenre>.Values => IGenres.VALUES(Genres: this);
    public bool IsReadOnly => IGenres.IS_READ_ONLY(Genres: this);

    public Dictionary<string, string> Dictionary { get; }
    public object Array { get; }

    IGenre IDictionary<string, IGenre>.this[string key]
    {
        get => base[key];
        // IGenres.GET_GENRE(Genres: this, Key: key);
        set => base[key] = (Genre.Genre)value;
        // IGenres.SET_GENRE(Genres: this, Key: key, Genre: value);
    }
    public void Add(string key, IGenre value)
    {
        if (base.ContainsKey(key: key))
            base[key] = (Genre.Genre)value;
        else
            base.Add(key: key, value: (Genre.Genre)value);
    }
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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(int Count = 1) => Init(Count: Count);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(String Key, String Name) => Init(Key: Key, Name: Name);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(IGenre Genre) => Init(Genre: Genre);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(String Key, IGenre Genre) => Init(Key: Key, Genre: Genre);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(KeyValuePair<String, IGenre> Genre) => Init(Genre: Genre);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(IGenre[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(KeyValuePair<String, IGenre>[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(Dictionary<String, String> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(Dictionary<String, Genre.Genre> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(IGenres Original) => Init(Original: Original);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public void Init(int Count = 1) => IGenres.INIT(this, Count: Count);
    public void Init(String Key, String Name) => IGenres.INIT(this, Key: Key, Name: Name);
    public void Init(IGenre Genre) => IGenres.INIT(this, Genre: Genre);
    public void Init(String Key, IGenre Genre) => IGenres.INIT(this, Key: Key, Genre: Genre);
    public void Init(KeyValuePair<String, IGenre> Genre) => IGenres.INIT(this, Genre: Genre);
    public void Init(IGenre[] Array) => IGenres.INIT(this, GenreArray: Array);
    public void Init(KeyValuePair<String, IGenre>[] Array) => IGenres.INIT(this, GenrePairArray: Array);
    public void Init(Dictionary<String, String> Dictionary) => IGenres.INIT(this, Dictionary: Dictionary);
    public void Init(Dictionary<String, Genre.Genre> Dictionary) => IGenres.INIT(this, Dictionary: Dictionary);
    public void Init(IGenres Original) => IGenres.INIT(this, Original: Original);
    public void Add(IGenre genre) => IGenres.ADD(this, genre);
    public CampaignKeySet CampaignKeys(Heroes Heroes) => IGenres.CAMPAIGN_KEYS(this, Heroes);
    public PlayerKeySet PlayerKeys(Heroes Heroes) => IGenres.PLAYER_KEYS(this, Heroes);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes) => IGenres.GAME_MASTER_KEYS(this, Heroes);
    public static implicit operator Dictionary<String, IGenre>(Genres Genres) => IGenres.CONVERT_GENRES_TO_DICTIONARY(Genres: Genres);
    public static explicit operator Genres(Dictionary<String, IGenre> Dictionary) => (Genres)IGenres.CONVERT_DICTIONARY_TO_GENRES(Dictionary: Dictionary);
}
