using Heroes.Genres;

namespace Heroes.Campaigns.Campaign;

public class Campaign : ICampaign
{
    public String Key { get; set; } = ICampaign.DefaultKey;
    public String Name { get; set; } = ICampaign.DefaultName;
    public GenreKeySet GenreKeys { get; set; } = ICampaign.DefaultGenreKeys;
    //TODO: change to GameMasterKeys
    public GameMasters.GameMasters GameMasters { get; set; } = ICampaign.DefaultGameMasters;
    public Campaign() => Init();
    public Campaign(String Key, String? Name = null, GenreKeySet? GenreKeys = null, GameMasters.GameMasters? GameMasters = null) => Init(Key: Key, Name: Name, GenreKeys: GenreKeys, GameMasters: GameMasters);
    public Campaign(String Name, GenreKeySet? GenreKeys = null, GameMasters.GameMasters? GameMasters = null) => Init(Name: Name, GenreKeys: GenreKeys, GameMasters: GameMasters);
    public Campaign(int Index) => Init(Index: Index);
    public Campaign(ICampaign Campaign) => Init(Campaign: Campaign);
    public Campaign(Campaign Campaign) => Init(Campaign: Campaign);
    public void Init() => ICampaign.INIT(Campaign: this);
    public void Init(String Name, GenreKeySet? GenreKeys = null, GameMasters.GameMasters? GameMasters = null) => ICampaign.INIT(Campaign: this, Name: Name, GenreKeys: GenreKeys, GameMasters: GameMasters);
    public void Init(String Key, String? Name = null, GenreKeySet? GenreKeys = null, GameMasters.GameMasters? GameMasters = null) => ICampaign.INIT(Campaign: this, Key: Key, Name: Name, GenreKeys: GenreKeys, GameMasters: GameMasters);
    public void Init(int Index) => ICampaign.INIT(Campaign: this, Index: Index);
    public void Init(ICampaign Campaign) => ICampaign.INIT(Campaign: this, Original: Campaign);
    public void Init(Campaign Campaign) => ICampaign.INIT(Campaign: this, Original: Campaign);
}
