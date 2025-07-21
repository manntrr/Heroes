using System.Collections.Immutable;

namespace Heroes.GameMasters;

public class GameMasterKeySet : HashSet<String>
{
    public String[] Keys { get => this.ToArray<String>(); }
    public GameMasterKeySet(GameMasters GameMasters, ref GameMasters MasterGameMasters)
    {
        base.UnionWith(GameMasters.Keys);
        foreach (String key in this.Except(MasterGameMasters.Keys))
        {
            MasterGameMasters.Add(key, GameMasters[key]);
        }
    }
    public GameMasterKeySet(GameMasterKeySet Original)
    {
        foreach (String key in Original)
        {
            base.Add(key);
        }
    }
    public GameMasters GameMasters(GameMasters MasterGameMasters, bool throwIfMissingInMaster = true)
    {
        GameMasters result = [];
        GameMasterKeySet masterKeySet = new(MasterGameMasters, ref MasterGameMasters);
        GameMasterKeySet missingKeySet = new GameMasterKeySet(MasterGameMasters, ref MasterGameMasters);
        missingKeySet.Clear();
        missingKeySet.UnionWith(this.Except(masterKeySet));
        if (missingKeySet.Count > 0 && throwIfMissingInMaster) throw new ArgumentOutOfRangeException(nameof(MasterGameMasters), missingKeySet, "Missing keys in the Master list!");
        GameMasters intersectedGameMasters = new GameMasters();
        intersectedGameMasters.Clear();
        foreach (var key in masterKeySet.Intersect(this))
        {
            intersectedGameMasters.Add(key, MasterGameMasters[key]);
        }
        result.Clear();
        GameMasterKeySet resultKeySet = new GameMasterKeySet(intersectedGameMasters, ref MasterGameMasters);
        foreach (String key in resultKeySet)
        {
            result.Add(MasterGameMasters[key]);
        }
        return result;
    }
}
