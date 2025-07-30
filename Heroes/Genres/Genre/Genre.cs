using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;

namespace Heroes.Genres.Genre;

public class Genre : IGenre
{
    public string Key { get; set; } = IGenre.DefaultKey;
    public string Name { get; set; } = IGenre.DefaultName;
    public Genre() => Init();
    public Genre(string Key, string? Name = null) => Init(Key: Key, Name: Name);
    public Genre(string Name) => Init(Name: Name);
    public Genre(int Index) => Init(Index: Index);
    public Genre(IGenre Genre) => Init(Genre: Genre);
    public Genre(Genre Genre) => Init(Genre: Genre);
    public void Init() => IGenre.INIT(Genre: this);
    public void Init(string Name) => IGenre.INIT(Genre: this, Name: Name);
    public void Init(string Key, string? Name = null) => IGenre.INIT(Genre: this, Key: Key, Name: Name);
    public void Init(int Index) => IGenre.INIT(Genre: this, Index: Index);
    public void Init(IGenre Genre) => IGenre.INIT(Genre: this, Original: Genre);
    public void Init(Genre Genre) => IGenre.INIT(Genre: this, Original: Genre);
    public CampaignKeySet CampaignKeys(Heroes Heroes) => IGenre.CAMPAIGN_KEYS(this, Heroes);
    public PlayerKeySet PlayerKeys(Heroes Heroes) => IGenre.PLAYER_KEYS(this, Heroes);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes) => IGenre.GAME_MASTER_KEYS(this, Heroes);
}
