namespace Heroes;

public class NonPlayerCharacter : Character
{
    public NonPlayerCharacter(string Key, string CharacterName, GameMasters GameMasters, Campaigns Campaigns) : base(Key: Key, Name: CharacterName)
    {
        this.GameMasters = GameMasters;
        this.Campaigns = Campaigns;
    }
    public GameMasters GameMasters { get; }
    public Campaigns Campaigns { get; }
}
