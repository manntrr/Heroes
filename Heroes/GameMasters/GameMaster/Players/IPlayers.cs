using Heroes.Campaigns;
using Heroes.Campaigns.Campaign;
using Heroes.GameMasters.GameMaster.Players.Player;
using Heroes.Genres;

namespace Heroes.GameMasters.GameMaster.Players;

public interface IPlayers : IDictionary<String, Player.IPlayer>
{
    static public Players PLAYERS = (Players)CONVERT_DICTIONARY_TO_PLAYERS(new Dictionary<String, Player.IPlayer> {
        { "Unknown Player", new Player.Player(Key: "Unknown Player", Name: "Unknown Player") },
        { "Unknown Fantasy Player", new Player.Player(Key: "Unknown Fantasy Player", Name: "Unknown Fantasy Player") },
        { "Unknown Western Player", new Player.Player(Key: "Unknown Western Player", Name: "Unknown Western Player") },
        { "Unknown Pulp Fiction Player", new Player.Player(Key: "Unknown Pulp Fiction Player", Name: "Unknown Pulp Fiction Player") },
        { "Unknown Modern Player", new Player.Player(Key: "Unknown Modern Player", Name: "Unknown Modern Player") },
        { "Unknown Star Hero Player", new Player.Player(Key: "Unknown Star Hero Player", Name: "Unknown Star Hero Player") },
        { "Unknown Champions Player", new Player.Player(Key: "Unknown Champions Player", Name: "Unknown Champions Player") },
        { "Unknown Custom Player", new Player.Player(Key: "Unknown Custom Player", Name: "Unknown Custom Player") }
    });
    static public ICollection<string> KEYS(Dictionary<String, Player.IPlayer> Players)
    {
        return Players.Keys;
    }
    static public ICollection<Player.IPlayer> VALUES(Dictionary<String, Player.IPlayer> Players)
    {
        return Players.Values.Cast<Player.IPlayer>().ToList();
    }
    static public bool IS_READ_ONLY(IPlayers Players)
    {
        return false;
    }
    /*
    static public Player.IPlayer GET_PLAYER(IPlayers Players, String Key)
    {
        return Players[Key];
    }
    */
    /*
    static public void SET_PLAYER(IPlayers Players, String Key, Player.IPlayer Player)
    {
        Players[Key] = Player;
    }
    */
    /*
    static public void ADD(IPlayers Players, String Key, Player.IPlayer Player)
    {
        Player.Key = Key;
        if (((IDictionary<String, Player.IPlayer>)Players).ContainsKey(Key)) Players[Key] = Player;
        else ((IDictionary<String, Player.IPlayer>)Players).Add(key: Key, value: Player);
    }
    */
    static public bool TRY_GET_VALUE(IPlayers Players, String Key, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out Player.IPlayer Value)
    {
        Player.IPlayer? PlayerValue;
        bool result = Players.TryGetValue(Key, out PlayerValue);
        Value = result ? PlayerValue : null;
        return result;
    }
    static public void ADD(IPlayers Players, KeyValuePair<string, Player.IPlayer> Item)
    {
        if (Players.ContainsKey(Item.Key)) Players[Item.Key] = Item.Value;
        else Players.Add(Item.Key, Item.Value);
    }
    static public bool CONTAINS(IPlayers Players, KeyValuePair<string, Player.IPlayer> Item)
    {
        Player.IPlayer? PlayerValue;
        if (Players.TryGetValue(Item.Key, out PlayerValue))
        {
            return EqualityComparer<Player.IPlayer>.Default.Equals(PlayerValue, Item.Value);
        }
        return false;
    }
    static public void COPY_TO(IPlayers Players, KeyValuePair<string, Player.IPlayer>[] Array, int ArrayIndex)
    {
        Players.CopyTo(Array, ArrayIndex);
    }
    static public bool REMOVE(IPlayers Players, KeyValuePair<string, Player.IPlayer> Item)
    {
        return Players.Remove(Item);
    }
    /*
    static public IEnumerator<KeyValuePair<string, Player.IPlayer>> GET_ENUMERATOR(IPlayers Players)
    {
        return Players.GetEnumerator();
    }
    */
    static public Dictionary<String, Player.IPlayer> CONVERT_PLAYERS_TO_DICTIONARY(IPlayers Players)
    {
        Dictionary<String, Player.IPlayer> result = new();
        foreach (KeyValuePair<String, Player.IPlayer> Player in Players)
        {
            result.Add(Player.Key, Player.Value);
        }
        return result;
    }
    static public IPlayers CONVERT_DICTIONARY_TO_PLAYERS(Dictionary<String, Player.IPlayer> Dictionary)
    {
        IPlayers result = new Players();
        if (result.Count > 0)
            foreach (var key in result.Keys)
                result.Remove(key);
        foreach (KeyValuePair<String, Player.IPlayer> Player in Dictionary)
        {
            result.Add(Player);
        }
        return result;
    }
    static public void INIT(IPlayers Players, int Count = 1)
    {
        if (Players.Count > 0)
            foreach (var key in Players.Keys)
                Players.Remove(key);
        for (int index = 0; index < Count; index++)
            Players.Add(new Player.Player(Index: index + 1));
    }
    static public void INIT(IPlayers Players, String Key, String Name)
    {
        INIT(Players: Players, Player: new Player.Player(Key: Key, Name: Name));
    }
    static public void INIT(IPlayers Players, Player.IPlayer Player)
    {
        INIT(Players: Players, PlayerArray: [new Player.Player(Player: Player)]);
    }
    static public void INIT(IPlayers Players, String Key, Player.IPlayer Player)
    {
        INIT(Players: Players, Player: new Player.Player(Key: Key, Name: Player.Name));
    }
    static public void INIT(IPlayers Players, KeyValuePair<String, Player.IPlayer> Player)
    {
        INIT(Players: Players, Player: new Player.Player(Key: Player.Key, Name: Player.Value.Name));
    }
    static public void INIT(IPlayers Players, Player.IPlayer[] PlayerArray)
    {
        if (Players.Count > 0)
            foreach (var key in Players.Keys)
                Players.Remove(key);
        foreach (Player.IPlayer Player in PlayerArray)
        {
            Players.Add(Player);
        }
    }
    static public void INIT(IPlayers Players, KeyValuePair<String, Player.IPlayer>[] PlayerPairArray)
    {
        if (Players.Count > 0)
            foreach (var key in Players.Keys)
                Players.Remove(key);
        foreach (KeyValuePair<String, Player.IPlayer> Player in PlayerPairArray)
        {
            Players.Add(Player);
        }
    }
    static public void INIT(IPlayers Players, Dictionary<String, String> Dictionary)
    {
        if (Players.Count > 0)
            foreach (String key in Players.Keys)
                Players.Remove(key);
        foreach (String key in Dictionary.Keys)
            Players.Add(new Player.Player(Key: key, Name: Dictionary[key]));
    }
    static public void INIT(IPlayers Players, Dictionary<String, Player.Player> Dictionary)
    {
        if (Players.Count > 0)
            foreach (var key in Players.Keys)
                Players.Remove(key);
        foreach (String key in Dictionary.Keys)
            Players.Add(new Player.Player(Key: key, Name: Dictionary[key].Name));
    }
    static public void INIT(IPlayers Players, IPlayers Original)
    {
        if (Players.Count > 0)
            foreach (var key in Players.Keys)
                Players.Remove(key);
        foreach (KeyValuePair<String, Player.IPlayer> Player in Original)
        {
            Players.Add(Player);
        }
    }
    static public void ADD(IPlayers Players, Player.IPlayer Player)
    {
        if (Players.ContainsKey(Player.Key)) Players[Player.Key] = Player;
        else Players.Add(key: Player.Key, value: Player);
    }
    static public GenreKeySet GENRE_KEYS(IPlayers Players)
    {
        Genres.Genres temp = new();
        GenreKeySet genres = new(new(), ref temp);
        genres.Clear();
        foreach (KeyValuePair<string, IPlayer> pair in Players)
        {
            genres.Union(pair.Value.GenreKeys);
        }
        return genres;
    }
    static public CampaignKeySet CAMPAIGN_KEYS(IPlayers Players)
    {
        Campaigns.Campaigns temp = new();
        CampaignKeySet campaigns = new(new(), ref temp);
        campaigns.Clear();
        foreach (KeyValuePair<string, IPlayer> pair in Players)
        {
            campaigns.Union(pair.Value.CampaignKeys);
        }
        return campaigns;
    }
    static public GameMasterKeySet GAME_MASTER_KEYS(IPlayers Players, Heroes Heroes)
    {
        GameMasters temp = new();
        GameMasterKeySet gameMasters = new(new(), ref temp);
        gameMasters.Clear();
        foreach (KeyValuePair<string, IPlayer> pair in Players)
        {
            gameMasters.Union(pair.Value.GameMasterKeys(Heroes));
        }
        return gameMasters;
    }
    public void Init(int count = 1);
    public void Init(String Key, String Name);
    public void Init(Player.IPlayer Player);
    public void Init(String Key, Player.IPlayer Player);
    public void Init(KeyValuePair<String, Player.IPlayer> Player);
    public void Init(Player.IPlayer[] Players);
    public void Init(KeyValuePair<String, Player.IPlayer>[] Players);
    public void Init(Dictionary<String, String> Dictionary);
    public void Init(Dictionary<String, Player.Player> Dictionary);
    public void Init(IPlayers Original);
    public void Add(Player.IPlayer Player);
    public GenreKeySet GenreKeys { get; }
    public CampaignKeySet CampaignKeys { get; }
    public GameMasterKeySet GameMasterKeys(Heroes Heroes);
}