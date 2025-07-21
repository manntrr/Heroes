using System.Diagnostics.CodeAnalysis;

namespace Heroes.GameMasters.GameMaster.Players;

public class Players : Dictionary<String, Player.Player>, IPlayers
{
    ICollection<string> IDictionary<string, Player.IPlayer>.Keys => IPlayers.KEYS(Players: this);
    ICollection<Player.IPlayer> IDictionary<string, Player.IPlayer>.Values => IPlayers.VALUES(Players: this);
    public bool IsReadOnly => IPlayers.IS_READ_ONLY(Players: this);

    public Dictionary<string, string> Dictionary { get; }
    public object Array { get; }

    Player.IPlayer IDictionary<string, Player.IPlayer>.this[string key]
    {
        get => base[key];
        // IPlayers.GET_PLAYER(Players: this, Key: key);
        set => base[key] = (Player.Player)value;
        // IPlayers.SET_PLAYER(Players: this, Key: key, Player: value);
    }
    public void Add(string key, Player.IPlayer value)
    {
        if (base.ContainsKey(key: key))
            base[key] = (Player.Player)value;
        else
            base.Add(key: key, value: (Player.Player)value);
    }
    //=> IPlayers.ADD(Players: this, Key: key, Player: value);
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out Player.IPlayer value)
    {
        Player.IPlayer? PlayerValue;
        bool result = IPlayers.TRY_GET_VALUE(Players: this, Key: key, Value: out PlayerValue);
        value = PlayerValue;
        return result;
    }
    public void Add(KeyValuePair<string, Player.IPlayer> item) => IPlayers.ADD(Players: this, Item: item);
    public bool Contains(KeyValuePair<string, Player.IPlayer> item) => IPlayers.CONTAINS(Players: this, Item: item);
    public void CopyTo(KeyValuePair<string, Player.IPlayer>[] array, int arrayIndex) => IPlayers.COPY_TO(Players: this, Array: array, ArrayIndex: arrayIndex);
    public bool Remove(KeyValuePair<string, Player.IPlayer> item) => IPlayers.REMOVE(Players: this, Item: item);
    IEnumerator<KeyValuePair<string, Player.IPlayer>> IEnumerable<KeyValuePair<string, Player.IPlayer>>.GetEnumerator()
    {
        foreach (var kvp in this)
        {
            yield return new KeyValuePair<string, Player.IPlayer>(kvp.Key, kvp.Value);
        }
    }
    // => IPlayers.GET_ENUMERATOR(Players: this);
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(int Count = 1) => Init(Count: Count);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(String Key, String Name) => Init(Key: Key, Name: Name);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(Player.IPlayer Player) => Init(Player: Player);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(String Key, Player.IPlayer Player) => Init(Key: Key, Player: Player);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(KeyValuePair<String, Player.IPlayer> Player) => Init(Player: Player);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(Player.IPlayer[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(KeyValuePair<String, Player.IPlayer>[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(Dictionary<String, String> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(Dictionary<String, Player.Player> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Players(IPlayers Original) => Init(Original: Original);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public void Init(int Count = 1) => IPlayers.INIT(this, Count: Count);
    public void Init(String Key, String Name) => IPlayers.INIT(this, Key: Key, Name: Name);
    public void Init(Player.IPlayer Player) => IPlayers.INIT(this, Player: Player);
    public void Init(String Key, Player.IPlayer Player) => IPlayers.INIT(this, Key: Key, Player: Player);
    public void Init(KeyValuePair<String, Player.IPlayer> Player) => IPlayers.INIT(this, Player: Player);
    public void Init(Player.IPlayer[] Array) => IPlayers.INIT(this, PlayerArray: Array);
    public void Init(KeyValuePair<String, Player.IPlayer>[] Array) => IPlayers.INIT(this, PlayerPairArray: Array);
    public void Init(Dictionary<String, String> Dictionary) => IPlayers.INIT(this, Dictionary: Dictionary);
    public void Init(Dictionary<String, Player.Player> Dictionary) => IPlayers.INIT(this, Dictionary: Dictionary);
    public void Init(IPlayers Original) => IPlayers.INIT(this, Original: Original);
    public void Add(Player.IPlayer Player) => IPlayers.ADD(this, Player);
    public static implicit operator Dictionary<String, Player.IPlayer>(Players Players) => IPlayers.CONVERT_PLAYERS_TO_DICTIONARY(Players: Players);
    public static explicit operator Players(Dictionary<String, Player.IPlayer> Dictionary) => (Players)IPlayers.CONVERT_DICTIONARY_TO_PLAYERS(Dictionary: Dictionary);
}
