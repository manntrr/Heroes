using Heroes.GameMasters.GameMaster;
using Heroes.GameMasters.GameMaster.Players;

namespace Heroes;

public class PlayerCharacter : NonPlayerCharacter
{
    public PlayerCharacter(string Key, string CharacterName, GameMasters.GameMaster.Players.Player.Player Player, GameMasters.GameMasters GameMasters, Campaigns.Campaigns Campaigns) : base(Key: Key, CharacterName: CharacterName, GameMasters: GameMasters, Campaigns: Campaigns)
    {
        this.Player = Player;
    }
    public GameMasters.GameMaster.Players.Player.Player Player { get; }
}