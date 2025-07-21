namespace Heroes;

public class Character
{
    public Character(string Key, string Name)
    {
        this.Key = Key;
        this.Name = Name;
    }
    public string Key { get; }
    public string Name { get; }

}