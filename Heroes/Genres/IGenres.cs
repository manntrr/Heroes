namespace Heroes;

public interface IGenres : IDictionary<String, IGenre>
{
    static public Genres GENRES = (Genres)CONVERT_DICTIONARY_TO_GENRES(new Dictionary<String, IGenre> {
        { "Unknown", new Genre(Key: "Unknown", Name: "Unknown") },
        { "Fantasy", new Genre(Key: "Fantasy", Name: "Fantasy") },
        { "Western", new Genre(Key: "Western", Name: "Western") },
        { "Pulp Fiction", new Genre(Key: "Pulp Fiction", Name: "Pulp Fiction") },
        { "Modern", new Genre(Key: "Modern", Name: "Modern") },
        { "Star Hero", new Genre(Key: "Star Hero", Name: "Star Hero") },
        { "Champions", new Genre(Key: "Champions", Name: "Champions") },
        { "Custom", new Genre(Key: "Custom", Name: "Custom") }
    });
    static public ICollection<string> KEYS(Dictionary<String, IGenre> Genres)
    {
        return Genres.Keys;
    }
    static public ICollection<IGenre> VALUES(Dictionary<String, IGenre> Genres)
    {
        return Genres.Values.Cast<IGenre>().ToList();
    }
    static public bool IS_READ_ONLY(IGenres Genres)
    {
        return false;
    }
    /*
    static public IGenre GET_GENRE(IGenres Genres, String Key)
    {
        return Genres[Key];
    }
    */
    /*
    static public void SET_GENRE(IGenres Genres, String Key, IGenre Genre)
    {
        Genres[Key] = Genre;
    }
    */
    /*
    static public void ADD(IGenres Genres, String Key, IGenre Genre)
    {
        Genre.Key = Key;
        if (((IDictionary<String, IGenre>)Genres).ContainsKey(Key)) Genres[Key] = Genre;
        else ((IDictionary<String, IGenre>)Genres).Add(key: Key, value: Genre);
    }
    */
    static public bool TRY_GET_VALUE(IGenres Genres, String Key, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out IGenre Value)
    {
        IGenre? genreValue;
        bool result = Genres.TryGetValue(Key, out genreValue);
        Value = result ? genreValue : null;
        return result;
    }
    static public void ADD(IGenres Genres, KeyValuePair<string, IGenre> Item)
    {
        if (Genres.ContainsKey(Item.Key)) Genres[Item.Key] = Item.Value;
        else Genres.Add(Item.Key, Item.Value);
    }
    static public bool CONTAINS(IGenres Genres, KeyValuePair<string, IGenre> Item)
    {
        IGenre? genreValue;
        if (Genres.TryGetValue(Item.Key, out genreValue))
        {
            return EqualityComparer<IGenre>.Default.Equals(genreValue, Item.Value);
        }
        return false;
    }
    static public void COPY_TO(IGenres Genres, KeyValuePair<string, IGenre>[] Array, int ArrayIndex)
    {
        Genres.CopyTo(Array, ArrayIndex);
    }
    static public bool REMOVE(IGenres Genres, KeyValuePair<string, IGenre> Item)
    {
        return Genres.Remove(Item);
    }
    /*
    static public IEnumerator<KeyValuePair<string, IGenre>> GET_ENUMERATOR(IGenres Genres)
    {
        return Genres.GetEnumerator();
    }
    */
    static public Dictionary<String, IGenre> CONVERT_GENRES_TO_DICTIONARY(IGenres Genres)
    {
        Dictionary<String, IGenre> result = new();
        foreach (KeyValuePair<String, IGenre> genre in Genres)
        {
            result.Add(genre.Key, genre.Value);
        }
        return result;
    }
    static public IGenres CONVERT_DICTIONARY_TO_GENRES(Dictionary<String, IGenre> Dictionary)
    {
        IGenres result = new Genres();
        if (result.Count > 0)
            foreach (var key in result.Keys)
                result.Remove(key);
        foreach (KeyValuePair<String, IGenre> genre in Dictionary)
        {
            result.Add(genre);
        }
        return result;
    }
    static public void INIT(IGenres Genres, int Count = 1)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        for (int index = 0; index < Count; index++)
            Genres.Add(new Genre(Index: index + 1));
    }
    static public void INIT(IGenres Genres, String Key, String Name)
    {
        INIT(Genres: Genres, Genre: new Genre(Key: Key, Name: Name));
    }
    static public void INIT(IGenres Genres, IGenre Genre)
    {
        INIT(Genres: Genres, GenreArray: [new Genre(Genre: Genre)]);
    }
    static public void INIT(IGenres Genres, String Key, IGenre Genre)
    {
        INIT(Genres: Genres, Genre: new Genre(Key: Key, Name: Genre.Name));
    }
    static public void INIT(IGenres Genres, KeyValuePair<String, IGenre> Genre)
    {
        INIT(Genres: Genres, Genre: new Genre(Key: Genre.Key, Name: Genre.Value.Name));
    }
    static public void INIT(IGenres Genres, IGenre[] GenreArray)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (IGenre genre in GenreArray)
        {
            Genres.Add(genre);
        }
    }
    static public void INIT(IGenres Genres, KeyValuePair<String, IGenre>[] GenrePairArray)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (KeyValuePair<String, IGenre> genre in GenrePairArray)
        {
            Genres.Add(genre);
        }
    }
    static public void INIT(IGenres Genres, Dictionary<String, String> Dictionary)
    {
        if (Genres.Count > 0)
            foreach (String key in Genres.Keys)
                Genres.Remove(key);
        foreach (String key in Dictionary.Keys)
            Genres.Add(new Genre(Key: key, Name: Dictionary[key]));
    }
    static public void INIT(IGenres Genres, Dictionary<String, Genre> Dictionary)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (String key in Dictionary.Keys)
            Genres.Add(new Genre(Key: key, Name: Dictionary[key].Name));
    }
    static public void INIT(IGenres Genres, IGenres Original)
    {
        if (Genres.Count > 0)
            foreach (var key in Genres.Keys)
                Genres.Remove(key);
        foreach (KeyValuePair<String, IGenre> genre in Original)
        {
            Genres.Add(genre);
        }
    }
    static public void ADD(IGenres Genres, IGenre genre)
    {
        if (Genres.ContainsKey(genre.Key)) Genres[genre.Key] = genre;
        else Genres.Add(key: genre.Key, value: genre);
    }
    public void Init(int count = 1);
    public void Init(String Key, String Name);
    public void Init(IGenre Genre);
    public void Init(String Key, IGenre Genre);
    public void Init(KeyValuePair<String, IGenre> Genre);
    public void Init(IGenre[] Genres);
    public void Init(KeyValuePair<String, IGenre>[] Genres);
    public void Init(Dictionary<String, String> Dictionary);
    public void Init(Dictionary<String, Genre> Dictionary);
    public void Init(IGenres Genres);
    public void Add(IGenre genre);
}