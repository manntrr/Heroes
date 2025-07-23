using Heroes.Campaigns;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.GameMasters.GameMaster.Players.Player;
using Heroes.Genres;

namespace Heroes.GameMasters.GameMaster;

public class GameMaster : Players.Player.Player, IGameMaster
{
    public new String Key { get => base.Key; set => base.Key = value; }
    // = IGameMaster.DefaultKey;
    public new String Name { get => base.Name; set => base.Name = value; }
    // = IGameMaster.DefaultName;
    public new CampaignKeySet CampaignKeys { get => base.CampaignKeys; set => base.CampaignKeys = value; }
    // = IGameMaster.DefaultCampaignKeys;
    public new GenreKeySet GenreKeys { get => base.GenreKeys; set => base.GenreKeys = value; }
    // = IGameMaster.DefaultGenreKeys;
    public PlayerKeySet PlayerKeys { get; set; } = IGameMaster.DefaultPlayerKeys;
    public GameMaster() => Init();
    public GameMaster(String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null) => Init(Key: Key, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    public GameMaster(String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null, PlayerKeySet? PlayerKeys = null) => Init(Key: Key, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys, PlayerKeys: PlayerKeys);
    public GameMaster(String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null, PlayerKeySet? PlayerKeys = null) => Init(Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys, PlayerKeys: PlayerKeys);
    public GameMaster(String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null) => Init(Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    public GameMaster(int Index) => Init(Index: Index);
    public GameMaster(IGameMaster GameMaster) => Init(GameMaster: GameMaster);
    public GameMaster(GameMaster GameMaster) => Init(GameMaster: GameMaster);
    public new void Init() => IGameMaster.INIT(GameMaster: this);
    public new void Init(String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null) => IGameMaster.INIT(GameMaster: this, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    public void Init(String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null, PlayerKeySet? PlayerKeys = null) => IGameMaster.INIT(GameMaster: this, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys, PlayerKeys: PlayerKeys);
    public new void Init(String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null) => IGameMaster.INIT(GameMaster: this, Key: Key, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    public void Init(String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null, PlayerKeySet? PlayerKeys = null) => IGameMaster.INIT(GameMaster: this, Key: Key, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys, PlayerKeys: PlayerKeys);
    public new void Init(int Index) => IGameMaster.INIT(GameMaster: this, Index: Index);
    public void Init(IGameMaster GameMaster) => IGameMaster.INIT(GameMaster: this, Original: GameMaster);
    public void Init(GameMaster GameMaster) => IGameMaster.INIT(GameMaster: this, Original: GameMaster);
}
