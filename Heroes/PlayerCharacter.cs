namespace Heroes;

public class PlayerCharacter : NonPlayerCharacter
{
    public PlayerCharacter(string Key, string CharacterName, Player Player, GameMasters GameMasters, Campaigns Campaigns) : base(Key: Key, CharacterName: CharacterName, GameMasters: GameMasters, Campaigns: Campaigns)
    {
        this.Player = Player;
    }
    public Player Player { get; }
}