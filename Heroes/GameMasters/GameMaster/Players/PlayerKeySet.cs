using System.Collections.Immutable;

namespace Heroes.GameMasters.GameMaster.Players;

public class PlayerKeySet : HashSet<String>
{
    public String[] Keys { get => this.ToArray<String>(); }
    public PlayerKeySet(Players Players, ref Players MasterPlayers)
    {
        base.UnionWith(Players.Keys);
        foreach (String key in this.Except(MasterPlayers.Keys))
        {
            MasterPlayers.Add(key, Players[key]);
        }
    }
    public PlayerKeySet(PlayerKeySet Original)
    {
        foreach (String key in Original)
        {
            base.Add(key);
        }
    }
    public Players Players(Players MasterPlayers, bool throwIfMissingInMaster = true)
    {
        Players result = [];
        PlayerKeySet masterKeySet = new(MasterPlayers, ref MasterPlayers);
        PlayerKeySet missingKeySet = new PlayerKeySet(MasterPlayers, ref MasterPlayers);
        missingKeySet.Clear();
        missingKeySet.UnionWith(this.Except(masterKeySet));
        if (missingKeySet.Count > 0 && throwIfMissingInMaster) throw new ArgumentOutOfRangeException(nameof(MasterPlayers), missingKeySet, "Missing keys in the Master list!");
        Players intersectedPlayers = new Players();
        intersectedPlayers.Clear();
        foreach (var key in masterKeySet.Intersect(this))
        {
            intersectedPlayers.Add(key, MasterPlayers[key]);
        }
        result.Clear();
        PlayerKeySet resultKeySet = new PlayerKeySet(intersectedPlayers, ref MasterPlayers);
        foreach (String key in resultKeySet)
        {
            result.Add(MasterPlayers[key]);
        }
        return result;
    }
}
