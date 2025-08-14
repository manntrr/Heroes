namespace Heroes.Genres;

using GenresObject = Genres;
using GenreKeySetInterfaceObject = IGenreKeySet;
using GenreKeySetObject = GenreKeySet;
public class GenreKeySet : HashSet<string>, GenreKeySetInterfaceObject
{
    public string[] Keys { get => GetKeys(); set => SetKeys(value); }
    public GenreKeySet(GenresObject Genres, ref GenresObject MasterGenres) => Init(Genres, ref MasterGenres);
    public GenreKeySet(IEnumerable<string> GenreKeys) => Init(GenreKeys);
    public GenreKeySet(GenreKeySetObject Original) => Init(Original);
    public void Init(GenresObject Genres, ref GenresObject MasterGenres) => GenreKeySetInterfaceObject.INIT(this, Genres, ref MasterGenres);
    public void Init(IEnumerable<string> GenreKeys) => GenreKeySetInterfaceObject.INIT(this, GenreKeys);
    public void Init(GenreKeySetObject Original) => GenreKeySetInterfaceObject.INIT(this, Original);
    public string[] GetKeys() => GenreKeySetInterfaceObject.GET_KEYS(this);
    public void SetKeys(string[] value) => GenreKeySetInterfaceObject.SET_KEYS(this, value);

    public static implicit operator Dictionary<string, Genre.Genre>.KeyCollection(GenreKeySetObject KeySet) => GenreKeySetInterfaceObject.CONVERT_GENRE_KEY_SET_TO_DICTIONARY_KEY_COLLECTION(KeySet: KeySet);
    public static explicit operator GenreKeySetObject(Dictionary<string, Genre.Genre>.KeyCollection KeyCollection) => GenreKeySetInterfaceObject.CONVERT_DICTIONARY_KEY_COLLECTION_TO_GENRE_KEY_SET(KeyCollection: KeyCollection);

    public GenresObject Genres(GenresObject MasterGenres, bool throwIfMissingInMaster = true) => GenreKeySetInterfaceObject.GENRES(this, MasterGenres, throwIfMissingInMaster);
}
