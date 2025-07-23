using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres;

namespace Heroes.Campaigns.Campaign;

public class Campaign : ICampaign
{
    public String Key { get; set; } = ICampaign.DefaultKey;
    public String Name { get; set; } = ICampaign.DefaultName;
    public GenreKeySet GenreKeys { get; set; } = ICampaign.DefaultGenreKeys;
    public Campaign() => Init();
    public Campaign(String Key, String? Name = null, GenreKeySet? GenreKeys = null) => Init(Key: Key, Name: Name, GenreKeys: GenreKeys);
    public Campaign(String Name, GenreKeySet? GenreKeys = null) => Init(Name: Name, GenreKeys: GenreKeys);
    public Campaign(int Index) => Init(Index: Index);
    public Campaign(ICampaign Campaign) => Init(Campaign: Campaign);
    public Campaign(Campaign Campaign) => Init(Campaign: Campaign);
    public void Init() => ICampaign.INIT(Campaign: this);
    public void Init(String Name, GenreKeySet? GenreKeys = null) => ICampaign.INIT(Campaign: this, Name: Name, GenreKeys: GenreKeys);
    public void Init(String Key, String? Name = null, GenreKeySet? GenreKeys = null) => ICampaign.INIT(Campaign: this, Key: Key, Name: Name, GenreKeys: GenreKeys);
    public void Init(int Index) => ICampaign.INIT(Campaign: this, Index: Index);
    public void Init(ICampaign Campaign) => ICampaign.INIT(Campaign: this, Original: Campaign);
    public void Init(Campaign Campaign) => ICampaign.INIT(Campaign: this, Original: Campaign);
    public PlayerKeySet PlayerKeys(Heroes Heroes) => ICampaign.PLAYER_KEYS(this, Heroes);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes) => ICampaign.GAME_MASTER_KEYS(this, Heroes);
}
