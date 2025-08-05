using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using GenresObject = Heroes.Genres.Genres;
using GenresInterfaceObject = Heroes.Genres.IGenres;
using GenreObject = Heroes.Genres.Genre.Genre;
using GenreInterfaceObject = Heroes.Genres.Genre.IGenre;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Genres;

public class Genres : Dictionary<string, GenreObject>, GenresInterfaceObject
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(int Count = 1) => Init(Count: Count);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(string Key, string Name) => Init(Key: Key, Name: Name);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(GenreObject Genre) => Init(Genre: Genre);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(string Key, GenreObject Genre) => Init(Key: Key, Genre: Genre);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(KeyValuePair<string, string> GenreKeyNamePair) => Init(GenreKeyNamePair: GenreKeyNamePair);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(KeyValuePair<string, GenreObject> Genre) => Init(Genre: Genre);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(GenreObject[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(KeyValuePair<string, string>[] GenreKeyNamePairArray) => Init(GenreKeyNamePairArray: GenreKeyNamePairArray);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(KeyValuePair<string, GenreObject>[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(Dictionary<string, string> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(Dictionary<string, GenreObject> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(GenresInterfaceObject Original) => Init(Original: Original);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Genres(GenresObject Original) => Init(Original: Original);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public void Init(int Count = 1) => GenresInterfaceObject.INIT(this, Count: Count);
    public void Init(string Key, string Name) => GenresInterfaceObject.INIT(this, Key: Key, Name: Name);
    public void Init(GenreObject Genre) => GenresInterfaceObject.INIT(this, Genre: Genre);
    public void Init(string Key, GenreObject Genre) => GenresInterfaceObject.INIT(this, Key: Key, Genre: Genre);
    public void Init(KeyValuePair<string, string> GenreKeyNamePair) => GenresInterfaceObject.INIT(this, GenreKeyNamePair: GenreKeyNamePair);
    public void Init(KeyValuePair<string, GenreObject> Genre) => GenresInterfaceObject.INIT(this, Genre: Genre);
    public void Init(GenreObject[] Array) => GenresInterfaceObject.INIT(this, GenreArray: Array);
    public void Init(KeyValuePair<string, string>[] GenreKeyNamePairArray) => GenresInterfaceObject.INIT(this, GenreKeyNamePairArray: GenreKeyNamePairArray);
    public void Init(KeyValuePair<string, GenreObject>[] Array) => GenresInterfaceObject.INIT(this, GenrePairArray: Array);
    public void Init(Dictionary<string, string> Dictionary) => GenresInterfaceObject.INIT(this, Dictionary: Dictionary);
    public void Init(Dictionary<string, GenreObject> Dictionary) => GenresInterfaceObject.INIT(this, Dictionary: Dictionary);
    public void Init(GenresInterfaceObject Original) => GenresInterfaceObject.INIT(this, Original: Original);
    public void Init(GenresObject Original) => GenresInterfaceObject.INIT(this, Original: Original);
    public GenreObject GetGenre(string Key) => GenresInterfaceObject.GET_GENRE(Genres: this, Key: Key);
    public void SetGenre(string Key, GenreObject Genre) => GenresInterfaceObject.SET_GENRE(Genres: this, Key: Key, Genre: Genre);
    public new void Add(string key, GenreObject value) => GenresInterfaceObject.ADD(Genres: this, Key: key, Genre: (GenreObject)value);
    public void Add(KeyValuePair<string, GenreObject> item) => GenresInterfaceObject.ADD(Genres: this, Item: item);
    public void Add(GenreObject genre) => GenresInterfaceObject.ADD(this, genre);
    ICollection<string> IDictionary<string, GenreObject>.Keys => GenresInterfaceObject.KEYS(Genres: this);
    ICollection<GenreObject> IDictionary<string, GenreObject>.Values => GenresInterfaceObject.VALUES(Genres: this);
    public bool IsReadOnly => GenresInterfaceObject.IS_READ_ONLY(Genres: this);
    GenreObject IDictionary<string, GenreObject>.this[string key]
    {
        get => GenresInterfaceObject.GET_GENRE(Genres: this, Key: key);
        set => GenresInterfaceObject.SET_GENRE(Genres: this, Key: key, Genre: value);
    }
    public new bool TryGetValue(string key, [MaybeNullWhen(false)] out GenreObject value)
    {
        GenreObject? genreValue;
        bool result = GenresInterfaceObject.TRY_GET_VALUE(Genres: this, Key: key, Value: out genreValue);
        value = genreValue;
        return result;
    }
    IEnumerator<KeyValuePair<string, GenreObject>> IEnumerable<KeyValuePair<string, GenreObject>>.GetEnumerator() => (IEnumerator<KeyValuePair<string, GenreObject>>)GenresInterfaceObject.GET_ENUMERATOR(Genres: this);
    public new IEnumerator<KeyValuePair<string, GenreObject>> GetEnumerator() => (IEnumerator<KeyValuePair<string, GenreObject>>)GenresInterfaceObject.GET_ENUMERATOR(Genres: this);
    public bool Contains(KeyValuePair<string, GenreObject> item) => GenresInterfaceObject.CONTAINS(Genres: this, Item: item);
    public void CopyTo(KeyValuePair<string, GenreObject>[] array, int arrayIndex) => GenresInterfaceObject.COPY_TO(Genres: this, Array: array, ArrayIndex: arrayIndex);
    public bool Remove(KeyValuePair<string, GenreObject> item) => GenresInterfaceObject.REMOVE(Genres: this, Item: item);
    public CampaignKeySet CampaignKeys(Heroes Heroes) => GenresInterfaceObject.CAMPAIGN_KEYS(this, Heroes);
    public PlayerKeySet PlayerKeys(Heroes Heroes) => GenresInterfaceObject.PLAYER_KEYS(this, Heroes);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes) => GenresInterfaceObject.GAME_MASTER_KEYS(this, Heroes);
    public static implicit operator Dictionary<string, GenreInterfaceObject>(GenresObject Genres) => GenresInterfaceObject.CONVERT_GENRES_TO_DICTIONARY(Genres: Genres);
    public static explicit operator GenresObject(Dictionary<string, GenreInterfaceObject> Dictionary) => (GenresObject)GenresInterfaceObject.CONVERT_DICTIONARY_TO_GENRES(Dictionary: Dictionary);
}
