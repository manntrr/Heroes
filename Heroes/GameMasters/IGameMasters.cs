using Heroes.Campaigns.Campaign;

namespace Heroes.GameMasters;

public interface IGameMasters : IDictionary<String, GameMaster.IGameMaster>
{
    static public GameMasters GAME_MASTERS = (GameMasters)CONVERT_DICTIONARY_TO_GAME_MASTERS(new Dictionary<String, GameMaster.IGameMaster> {
        { "Unknown Game Master", new GameMaster.GameMaster(Key: "Unknown Game Master", Name: "Unknown Game Master") },
        { "Unknown Fantasy Game Master", new GameMaster.GameMaster(Key: "Unknown Fantasy Game Master", Name: "Unknown Fantasy Game Master") },
        { "Unknown Western Game Master", new GameMaster.GameMaster(Key: "Unknown Western Game Master", Name: "Unknown Western Game Master") },
        { "Unknown Pulp Fiction Game Master", new GameMaster.GameMaster(Key: "Unknown Pulp Fiction Game Master", Name: "Unknown Pulp Fiction Game Master") },
        { "Unknown Modern Game Master", new GameMaster.GameMaster(Key: "Unknown Modern Game Master", Name: "Unknown Modern Game Master") },
        { "Unknown Star Hero Game Master", new GameMaster.GameMaster(Key: "Unknown Star Hero Game Master", Name: "Unknown Star Hero Game Master") },
        { "Unknown Champions Game Master", new GameMaster.GameMaster(Key: "Unknown Champions Game Master", Name: "Unknown Champions Game Master") },
        { "Unknown Custom Game Master", new GameMaster.GameMaster(Key: "Unknown Custom Game Master", Name: "Unknown Custom Game Master") }
    });
    static public ICollection<string> KEYS(Dictionary<String, GameMaster.IGameMaster> GameMasters)
    {
        return GameMasters.Keys;
    }
    static public ICollection<GameMaster.IGameMaster> VALUES(Dictionary<String, GameMaster.IGameMaster> GameMasters)
    {
        return GameMasters.Values.Cast<GameMaster.IGameMaster>().ToList();
    }
    static public bool IS_READ_ONLY(IGameMasters GameMasters)
    {
        return false;
    }
    /*
    static public GameMaster.IGameMaster GET_GAME_MASTER(IGameMasters GameMasters, String Key)
    {
        return GameMasters[Key];
    }
    */
    /*
    static public void SET_GAME_MASTER(IGameMasters GameMasters, String Key, GameMaster.IGameMaster GameMaster)
    {
        GameMasters[Key] = GameMaster;
    }
    */
    /*
    static public void ADD(IGameMasters GameMasters, String Key, GameMaster.IGameMaster GameMaster)
    {
        GameMaster.Key = Key;
        if (((IDictionary<String, GameMaster.IGameMaster>)GameMasters).ContainsKey(Key)) GameMasters[Key] = GameMaster;
        else ((IDictionary<String, GameMaster.IGameMaster>)GameMasters).Add(key: Key, value: GameMaster);
    }
    */
    static public bool TRY_GET_VALUE(IGameMasters GameMasters, String Key, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out GameMaster.IGameMaster Value)
    {
        GameMaster.IGameMaster? GameMasterValue;
        bool result = GameMasters.TryGetValue(Key, out GameMasterValue);
        Value = result ? GameMasterValue : null;
        return result;
    }
    static public void ADD(IGameMasters GameMasters, KeyValuePair<string, GameMaster.IGameMaster> Item)
    {
        if (GameMasters.ContainsKey(Item.Key)) GameMasters[Item.Key] = Item.Value;
        else GameMasters.Add(Item.Key, Item.Value);
    }
    static public bool CONTAINS(IGameMasters GameMasters, KeyValuePair<string, GameMaster.IGameMaster> Item)
    {
        GameMaster.IGameMaster? GameMasterValue;
        if (GameMasters.TryGetValue(Item.Key, out GameMasterValue))
        {
            return EqualityComparer<GameMaster.IGameMaster>.Default.Equals(GameMasterValue, Item.Value);
        }
        return false;
    }
    static public void COPY_TO(IGameMasters GameMasters, KeyValuePair<string, GameMaster.IGameMaster>[] Array, int ArrayIndex)
    {
        GameMasters.CopyTo(Array, ArrayIndex);
    }
    static public bool REMOVE(IGameMasters GameMasters, KeyValuePair<string, GameMaster.IGameMaster> Item)
    {
        return GameMasters.Remove(Item);
    }
    /*
    static public IEnumerator<KeyValuePair<string, GameMaster.IGameMaster>> GET_ENUMERATOR(IGameMasters GameMasters)
    {
        return GameMasters.GetEnumerator();
    }
    */
    static public Dictionary<String, GameMaster.IGameMaster> CONVERT_GAME_MASTERS_TO_DICTIONARY(IGameMasters GameMasters)
    {
        Dictionary<String, GameMaster.IGameMaster> result = new();
        foreach (KeyValuePair<String, GameMaster.IGameMaster> GameMaster in GameMasters)
        {
            result.Add(GameMaster.Key, GameMaster.Value);
        }
        return result;
    }
    static public IGameMasters CONVERT_DICTIONARY_TO_GAME_MASTERS(Dictionary<String, GameMaster.IGameMaster> Dictionary)
    {
        IGameMasters result = new GameMasters();
        if (result.Count > 0)
            foreach (var key in result.Keys)
                result.Remove(key);
        foreach (KeyValuePair<String, GameMaster.IGameMaster> GameMaster in Dictionary)
        {
            result.Add(GameMaster);
        }
        return result;
    }
    static public void INIT(IGameMasters GameMasters, int Count = 1)
    {
        if (GameMasters.Count > 0)
            foreach (var key in GameMasters.Keys)
                GameMasters.Remove(key);
        for (int index = 0; index < Count; index++)
            GameMasters.Add(new GameMaster.GameMaster(Index: index + 1));
    }
    static public void INIT(IGameMasters GameMasters, String Key, String Name)
    {
        INIT(GameMasters: GameMasters, GameMaster: new GameMaster.GameMaster(Key: Key, Name: Name));
    }
    static public void INIT(IGameMasters GameMasters, GameMaster.IGameMaster GameMaster)
    {
        INIT(GameMasters: GameMasters, GameMasterArray: [new GameMaster.GameMaster(GameMaster: GameMaster)]);
    }
    static public void INIT(IGameMasters GameMasters, String Key, GameMaster.IGameMaster GameMaster)
    {
        INIT(GameMasters: GameMasters, GameMaster: new GameMaster.GameMaster(Key: Key, Name: GameMaster.Name));
    }
    static public void INIT(IGameMasters GameMasters, KeyValuePair<String, GameMaster.IGameMaster> GameMaster)
    {
        INIT(GameMasters: GameMasters, GameMaster: new GameMaster.GameMaster(Key: GameMaster.Key, Name: GameMaster.Value.Name));
    }
    static public void INIT(IGameMasters GameMasters, GameMaster.IGameMaster[] GameMasterArray)
    {
        if (GameMasters.Count > 0)
            foreach (var key in GameMasters.Keys)
                GameMasters.Remove(key);
        foreach (GameMaster.IGameMaster GameMaster in GameMasterArray)
        {
            GameMasters.Add(GameMaster);
        }
    }
    static public void INIT(IGameMasters GameMasters, KeyValuePair<String, GameMaster.IGameMaster>[] GameMasterPairArray)
    {
        if (GameMasters.Count > 0)
            foreach (var key in GameMasters.Keys)
                GameMasters.Remove(key);
        foreach (KeyValuePair<String, GameMaster.IGameMaster> GameMaster in GameMasterPairArray)
        {
            GameMasters.Add(GameMaster);
        }
    }
    static public void INIT(IGameMasters GameMasters, Dictionary<String, String> Dictionary)
    {
        if (GameMasters.Count > 0)
            foreach (String key in GameMasters.Keys)
                GameMasters.Remove(key);
        foreach (String key in Dictionary.Keys)
            GameMasters.Add(new GameMaster.GameMaster(Key: key, Name: Dictionary[key]));
    }
    static public void INIT(IGameMasters GameMasters, Dictionary<String, GameMaster.GameMaster> Dictionary)
    {
        if (GameMasters.Count > 0)
            foreach (var key in GameMasters.Keys)
                GameMasters.Remove(key);
        foreach (String key in Dictionary.Keys)
            GameMasters.Add(new GameMaster.GameMaster(Key: key, Name: Dictionary[key].Name));
    }
    static public void INIT(IGameMasters GameMasters, IGameMasters Original)
    {
        if (GameMasters.Count > 0)
            foreach (var key in GameMasters.Keys)
                GameMasters.Remove(key);
        foreach (KeyValuePair<String, GameMaster.IGameMaster> GameMaster in Original)
        {
            GameMasters.Add(GameMaster);
        }
    }
    static public void ADD(IGameMasters GameMasters, GameMaster.IGameMaster GameMaster)
    {
        if (GameMasters.ContainsKey(GameMaster.Key)) GameMasters[GameMaster.Key] = GameMaster;
        else GameMasters.Add(key: GameMaster.Key, value: GameMaster);
    }
    public void Init(int count = 1);
    public void Init(String Key, String Name);
    public void Init(GameMaster.IGameMaster GameMaster);
    public void Init(String Key, GameMaster.IGameMaster GameMaster);
    public void Init(KeyValuePair<String, GameMaster.IGameMaster> GameMaster);
    public void Init(GameMaster.IGameMaster[] GameMasters);
    public void Init(KeyValuePair<String, GameMaster.IGameMaster>[] GameMasters);
    public void Init(Dictionary<String, String> Dictionary);
    public void Init(Dictionary<String, GameMaster.GameMaster> Dictionary);
    public void Init(IGameMasters Original);
    public void Add(GameMaster.IGameMaster GameMaster);
}