namespace Heroes;

public class Genre : IGenre
{
    public String Key { get; set; } = IGenre.DefaultKey;
    public String Name { get; set; } = IGenre.DefaultName;
    public Genre() => Init();
    public Genre(String Key, String? Name = null) => Init(Key: Key, Name: Name);
    public Genre(String Name) => Init(Name: Name);
    public Genre(int Index) => Init(Index: Index);
    public Genre(IGenre Genre) => Init(Genre: Genre);
    public Genre(Genre Genre) => Init(Genre: Genre);
    public void Init() => IGenre.INIT(Genre: this);
    public void Init(String Name) => IGenre.INIT(Genre: this, Name: Name);
    public void Init(String Key, String? Name = null) => IGenre.INIT(Genre: this, Key: Key, Name: Name);
    public void Init(int Index) => IGenre.INIT(Genre: this, Index: Index);
    public void Init(IGenre Genre) => IGenre.INIT(Genre: this, Original: Genre);
    public void Init(Genre Genre) => IGenre.INIT(Genre: this, Original: Genre);
}
