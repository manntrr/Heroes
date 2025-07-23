using Heroes.Genres;
using Heroes.GameMasters;
using Heroes.Campaigns;
using Heroes.Campaigns.Campaign;

namespace Heroes.GameMasters.GameMaster.Players.Player;

public class Player : IPlayer
{
    public String Key { get; set; } = IPlayer.DefaultKey;
    public String Name { get; set; } = IPlayer.DefaultName;
    public CampaignKeySet CampaignKeys { get; set; } = IPlayer.DefaultCampaignKeys;
    public GenreKeySet GenreKeys { get; set; } = IPlayer.DefaultGenreKeys;
    public Player() => Init();
    public Player(String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null) => Init(Key: Key, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    public Player(String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null) => Init(Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    public Player(int Index) => Init(Index: Index);
    public Player(IPlayer Player) => Init(Player: Player);
    public Player(Player Player) => Init(Player: Player);
    public void Init() => IPlayer.INIT(Player: this);
    public void Init(String Name, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null) => IPlayer.INIT(Player: this, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    public void Init(String Key, String? Name = null, CampaignKeySet? CampaignKeys = null, GenreKeySet? GenreKeys = null) => IPlayer.INIT(Player: this, Key: Key, Name: Name, CampaignKeys: CampaignKeys, GenreKeys: GenreKeys);
    public void Init(int Index) => IPlayer.INIT(Player: this, Index: Index);
    public void Init(IPlayer Player) => IPlayer.INIT(Player: this, Original: Player);
    public void Init(Player Player) => IPlayer.INIT(Player: this, Original: Player);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes) => IPlayer.GAME_MASTER_KEYS(this, Heroes);
}
