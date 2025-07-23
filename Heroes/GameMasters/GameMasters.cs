using System.Diagnostics.CodeAnalysis;

namespace Heroes.GameMasters;

public class GameMasters : Dictionary<String, GameMaster.GameMaster>, IGameMasters
{
    ICollection<string> IDictionary<string, GameMaster.IGameMaster>.Keys => IGameMasters.KEYS(GameMasters: this);
    ICollection<GameMaster.IGameMaster> IDictionary<string, GameMaster.IGameMaster>.Values => IGameMasters.VALUES(GameMasters: this);
    public bool IsReadOnly => IGameMasters.IS_READ_ONLY(GameMasters: this);

    public Dictionary<string, string> Dictionary { get; }
    public object Array { get; }

    GameMaster.IGameMaster IDictionary<string, GameMaster.IGameMaster>.this[string key]
    {
        get => base[key];
        // IGameMasters.GET_GAME_MASTER(GameMasters: this, Key: key);
        set => base[key] = (GameMaster.GameMaster)value;
        // IGameMasters.SET_GAME_MASTER(GameMasters: this, Key: key, GameMaster: value);
    }
    public void Add(string key, GameMaster.IGameMaster value)
    {
        if (base.ContainsKey(key: key))
            base[key] = (GameMaster.GameMaster)value;
        else
            base.Add(key: key, value: (GameMaster.GameMaster)value);
    }
    //=> IGameMasters.ADD(GameMasters: this, Key: key, GameMaster: value);
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out GameMaster.IGameMaster value)
    {
        GameMaster.IGameMaster? GameMasterValue;
        bool result = IGameMasters.TRY_GET_VALUE(GameMasters: this, Key: key, Value: out GameMasterValue);
        value = GameMasterValue;
        return result;
    }
    public void Add(KeyValuePair<string, GameMaster.IGameMaster> item) => IGameMasters.ADD(GameMasters: this, Item: item);
    public bool Contains(KeyValuePair<string, GameMaster.IGameMaster> item) => IGameMasters.CONTAINS(GameMasters: this, Item: item);
    public void CopyTo(KeyValuePair<string, GameMaster.IGameMaster>[] array, int arrayIndex) => IGameMasters.COPY_TO(GameMasters: this, Array: array, ArrayIndex: arrayIndex);
    public bool Remove(KeyValuePair<string, GameMaster.IGameMaster> item) => IGameMasters.REMOVE(GameMasters: this, Item: item);
    IEnumerator<KeyValuePair<string, GameMaster.IGameMaster>> IEnumerable<KeyValuePair<string, GameMaster.IGameMaster>>.GetEnumerator()
    {
        foreach (var kvp in this)
        {
            yield return new KeyValuePair<string, GameMaster.IGameMaster>(kvp.Key, kvp.Value);
        }
    }
    // => IGameMasters.GET_ENUMERATOR(GameMasters: this);
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(int Count = 1) => Init(Count: Count);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(String Key, String Name) => Init(Key: Key, Name: Name);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(GameMaster.IGameMaster GameMaster) => Init(GameMaster: GameMaster);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(String Key, GameMaster.IGameMaster GameMaster) => Init(Key: Key, GameMaster: GameMaster);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(KeyValuePair<String, GameMaster.IGameMaster> GameMaster) => Init(GameMaster: GameMaster);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(GameMaster.IGameMaster[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(KeyValuePair<String, GameMaster.IGameMaster>[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(Dictionary<String, String> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(Dictionary<String, GameMaster.GameMaster> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GameMasters(IGameMasters Original) => Init(Original: Original);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public void Init(int Count = 1) => IGameMasters.INIT(this, Count: Count);
    public void Init(String Key, String Name) => IGameMasters.INIT(this, Key: Key, Name: Name);
    public void Init(GameMaster.IGameMaster GameMaster) => IGameMasters.INIT(this, GameMaster: GameMaster);
    public void Init(String Key, GameMaster.IGameMaster GameMaster) => IGameMasters.INIT(this, Key: Key, GameMaster: GameMaster);
    public void Init(KeyValuePair<String, GameMaster.IGameMaster> GameMaster) => IGameMasters.INIT(this, GameMaster: GameMaster);
    public void Init(GameMaster.IGameMaster[] Array) => IGameMasters.INIT(this, GameMasterArray: Array);
    public void Init(KeyValuePair<String, GameMaster.IGameMaster>[] Array) => IGameMasters.INIT(this, GameMasterPairArray: Array);
    public void Init(Dictionary<String, String> Dictionary) => IGameMasters.INIT(this, Dictionary: Dictionary);
    public void Init(Dictionary<String, GameMaster.GameMaster> Dictionary) => IGameMasters.INIT(this, Dictionary: Dictionary);
    public void Init(IGameMasters Original) => IGameMasters.INIT(this, Original: Original);
    public void Add(GameMaster.IGameMaster GameMaster) => IGameMasters.ADD(this, GameMaster);
    public static implicit operator Dictionary<String, GameMaster.IGameMaster>(GameMasters GameMasters) => IGameMasters.CONVERT_GAME_MASTERS_TO_DICTIONARY(GameMasters: GameMasters);
    public static explicit operator GameMasters(Dictionary<String, GameMaster.IGameMaster> Dictionary) => (GameMasters)IGameMasters.CONVERT_DICTIONARY_TO_GAME_MASTERS(Dictionary: Dictionary);
}
