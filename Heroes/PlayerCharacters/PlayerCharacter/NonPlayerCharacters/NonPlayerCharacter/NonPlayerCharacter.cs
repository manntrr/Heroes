namespace Heroes;

public class NonPlayerCharacter : Character
{
    public NonPlayerCharacter(string Key, string CharacterName, GameMasters.GameMasters GameMasters, Campaigns.Campaigns Campaigns) : base(Key: Key, Name: CharacterName)
    {
        this.GameMasters = GameMasters;
        this.Campaigns = Campaigns;
    }
    public GameMasters.GameMasters GameMasters { get; }
    public Campaigns.Campaigns Campaigns { get; }
}
