using Heroes.Campaigns;
using Heroes.GameMasters.GameMaster.Players.Player;

namespace Heroes.GameMasters.GameMaster;

public class GameMaster : Players.Player.Player
{
    public GameMaster(string Key, string Name, CampaignKeySet CampaignKeys, Genres.GenreKeySet? Genres = null) : base(Key: Key, Name: Name, GenreKeys: Genres, CampaignKeys: CampaignKeys)
    {
    }
}
