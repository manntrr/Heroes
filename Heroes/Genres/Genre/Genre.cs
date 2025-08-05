using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using GenreObject = Heroes.Genres.Genre.Genre;
using GenreInterface = Heroes.Genres.Genre.IGenre;

namespace Heroes.Genres.Genre;

public class Genre : GenreInterface
{
    public string Key { get; set; } = GenreInterface.DefaultKey;
    public string Name { get; set; } = GenreInterface.DefaultName;
    public Genre() => Init();
    public Genre(string Key, string? Name = null) => Init(Key: Key, Name: Name);
    public Genre(string Name) => Init(Name: Name);
    public Genre(int Index) => Init(Index: Index);
    public Genre(GenreInterface Genre) => Init(Genre: Genre);
    public Genre(GenreObject Genre) => Init(Genre: Genre);
    public void Init() => GenreInterface.INIT(Genre: this);
    public void Init(string Name) => GenreInterface.INIT(Genre: this, Name: Name);
    public void Init(string Key, string? Name = null) => GenreInterface.INIT(Genre: this, Key: Key, Name: Name);
    public void Init(int Index) => GenreInterface.INIT(Genre: this, Index: Index);
    public void Init(GenreInterface Genre) => GenreInterface.INIT(Genre: this, Original: Genre);
    public void Init(GenreObject Genre) => GenreInterface.INIT(Genre: this, Original: Genre);
    public CampaignKeySet CampaignKeys(Heroes Heroes) => GenreInterface.CAMPAIGN_KEYS(this, Heroes);
    public PlayerKeySet PlayerKeys(Heroes Heroes) => GenreInterface.PLAYER_KEYS(this, Heroes);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes) => GenreInterface.GAME_MASTER_KEYS(this, Heroes);
}
