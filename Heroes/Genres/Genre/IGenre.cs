namespace Heroes.Genres.Genre;

public interface IGenre
{
    static public String GenreString = "Genre";
    static public String KeyString = "Key";
    static public String UnknownString = "Unknown";
    static public String DefaultKey = UnknownString + " " + GenreString + " " + KeyString;
    static public String DefaultName = UnknownString + " " + GenreString;
    static public void INIT(IGenre Genre)
    {
        Genre.Key = DefaultKey;
        Genre.Name = DefaultName;
    }
    static public void INIT(IGenre Genre, String Name)
    {
        INIT(Genre: Genre, Key: Name + " " + KeyString, Name: Name);
    }
    static public void INIT(IGenre Genre, String Key, String? Name = null)
    {
        Genre.Key = Key;
        if (Name is not null) Genre.Name = Name;
    }
    static public void INIT(IGenre Genre, int Index)
    {
        INIT(Genre: Genre, Key: GenreString + " " + Index.ToString(), Name: DefaultName + " " + Index.ToString());
    }
    static public void INIT(IGenre Genre, IGenre Original)
    {
        INIT(Genre: Genre, Key: Original.Key, Name: Original.Name);
    }
    public String Key { get; set; }
    public String Name { get; set; }
    public void Init();
    public void Init(String Name);
    public void Init(String Key, String? Name = null);
    public void Init(int Index);
    public void Init(IGenre Genre);
    public void Init(Genre Genre);
}