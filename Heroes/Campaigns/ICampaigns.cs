using Heroes.Campaigns.Campaign;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;

namespace Heroes.Campaigns;

public interface ICampaigns : IDictionary<String, Campaign.ICampaign>
{
    static public Campaigns CAMPAIGNS = (Campaigns)CONVERT_DICTIONARY_TO_CAMPAIGNS(new Dictionary<String, Campaign.ICampaign> {
        { "Unknown Campaign", new Campaign.Campaign(Key: "Unknown Campaign", Name: "Unknown Campaign") },
        { "Unknown Fantasy Campaign", new Campaign.Campaign(Key: "Unknown Fantasy Campaign", Name: "Unknown Fantasy Campaign") },
        { "Unknown Western Campaign", new Campaign.Campaign(Key: "Unknown Western Campaign", Name: "Unknown Western Campaign") },
        { "Unknown Pulp Fiction Campaign", new Campaign.Campaign(Key: "Unknown Pulp Fiction Campaign", Name: "Unknown Pulp Fiction Campaign") },
        { "Unknown Modern Campaign", new Campaign.Campaign(Key: "Unknown Modern Campaign", Name: "Unknown Modern Campaign") },
        { "Unknown Star Hero Campaign", new Campaign.Campaign(Key: "Unknown Star Hero Campaign", Name: "Unknown Star Hero Campaign") },
        { "Unknown Champions Campaign", new Campaign.Campaign(Key: "Unknown Champions Campaign", Name: "Unknown Champions Campaign") },
        { "Unknown Custom Campaign", new Campaign.Campaign(Key: "Unknown Custom Campaign", Name: "Unknown Custom Campaign") }
    });
    static public ICollection<string> KEYS(Dictionary<String, Campaign.ICampaign> Campaigns)
    {
        return Campaigns.Keys;
    }
    static public ICollection<Campaign.ICampaign> VALUES(Dictionary<String, Campaign.ICampaign> Campaigns)
    {
        return Campaigns.Values.Cast<Campaign.ICampaign>().ToList();
    }
    static public bool IS_READ_ONLY(ICampaigns Campaigns)
    {
        return false;
    }
    /*
    static public Campaign.ICampaign GET_CAMPAIGN(ICampaigns Campaigns, String Key)
    {
        return Campaigns[Key];
    }
    */
    /*
    static public void SET_CAMPAIGN(ICampaigns Campaigns, String Key, Campaign.ICampaign Campaign)
    {
        Campaigns[Key] = Campaign;
    }
    */
    /*
    static public void ADD(ICampaigns Campaigns, String Key, Campaign.ICampaign Campaign)
    {
        Campaign.Key = Key;
        if (((IDictionary<String, Campaign.ICampaign>)Campaigns).ContainsKey(Key)) Campaigns[Key] = Campaign;
        else ((IDictionary<String, Campaign.ICampaign>)Campaigns).Add(key: Key, value: Campaign);
    }
    */
    static public bool TRY_GET_VALUE(ICampaigns Campaigns, String Key, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out Campaign.ICampaign Value)
    {
        Campaign.ICampaign? CampaignValue;
        bool result = Campaigns.TryGetValue(Key, out CampaignValue);
        Value = result ? CampaignValue : null;
        return result;
    }
    static public void ADD(ICampaigns Campaigns, KeyValuePair<string, Campaign.ICampaign> Item)
    {
        if (Campaigns.ContainsKey(Item.Key)) Campaigns[Item.Key] = Item.Value;
        else Campaigns.Add(Item.Key, Item.Value);
    }
    static public bool CONTAINS(ICampaigns Campaigns, KeyValuePair<string, Campaign.ICampaign> Item)
    {
        Campaign.ICampaign? CampaignValue;
        if (Campaigns.TryGetValue(Item.Key, out CampaignValue))
        {
            return EqualityComparer<Campaign.ICampaign>.Default.Equals(CampaignValue, Item.Value);
        }
        return false;
    }
    static public void COPY_TO(ICampaigns Campaigns, KeyValuePair<string, Campaign.ICampaign>[] Array, int ArrayIndex)
    {
        Campaigns.CopyTo(Array, ArrayIndex);
    }
    static public bool REMOVE(ICampaigns Campaigns, KeyValuePair<string, Campaign.ICampaign> Item)
    {
        return Campaigns.Remove(Item);
    }
    /*
    static public IEnumerator<KeyValuePair<string, Campaign.ICampaign>> GET_ENUMERATOR(ICampaigns Campaigns)
    {
        return Campaigns.GetEnumerator();
    }
    */
    static public Dictionary<String, Campaign.ICampaign> CONVERT_CAMPAIGNS_TO_DICTIONARY(ICampaigns Campaigns)
    {
        Dictionary<String, Campaign.ICampaign> result = new();
        foreach (KeyValuePair<String, Campaign.ICampaign> Campaign in Campaigns)
        {
            result.Add(Campaign.Key, Campaign.Value);
        }
        return result;
    }
    static public ICampaigns CONVERT_DICTIONARY_TO_CAMPAIGNS(Dictionary<String, Campaign.ICampaign> Dictionary)
    {
        ICampaigns result = new Campaigns();
        if (result.Count > 0)
            foreach (var key in result.Keys)
                result.Remove(key);
        foreach (KeyValuePair<String, Campaign.ICampaign> Campaign in Dictionary)
        {
            result.Add(Campaign);
        }
        return result;
    }
    static public void INIT(ICampaigns Campaigns, int Count = 1)
    {
        if (Campaigns.Count > 0)
            foreach (var key in Campaigns.Keys)
                Campaigns.Remove(key);
        for (int index = 0; index < Count; index++)
            Campaigns.Add(new Campaign.Campaign(Index: index + 1));
    }
    static public void INIT(ICampaigns Campaigns, String Key, String Name)
    {
        INIT(Campaigns: Campaigns, Campaign: new Campaign.Campaign(Key: Key, Name: Name));
    }
    static public void INIT(ICampaigns Campaigns, Campaign.ICampaign Campaign)
    {
        INIT(Campaigns: Campaigns, CampaignArray: [new Campaign.Campaign(Campaign: Campaign)]);
    }
    static public void INIT(ICampaigns Campaigns, String Key, Campaign.ICampaign Campaign)
    {
        INIT(Campaigns: Campaigns, Campaign: new Campaign.Campaign(Key: Key, Name: Campaign.Name));
    }
    static public void INIT(ICampaigns Campaigns, KeyValuePair<String, Campaign.ICampaign> Campaign)
    {
        INIT(Campaigns: Campaigns, Campaign: new Campaign.Campaign(Key: Campaign.Key, Name: Campaign.Value.Name));
    }
    static public void INIT(ICampaigns Campaigns, Campaign.ICampaign[] CampaignArray)
    {
        if (Campaigns.Count > 0)
            foreach (var key in Campaigns.Keys)
                Campaigns.Remove(key);
        foreach (Campaign.ICampaign Campaign in CampaignArray)
        {
            Campaigns.Add(Campaign);
        }
    }
    static public void INIT(ICampaigns Campaigns, KeyValuePair<String, Campaign.ICampaign>[] CampaignPairArray)
    {
        if (Campaigns.Count > 0)
            foreach (var key in Campaigns.Keys)
                Campaigns.Remove(key);
        foreach (KeyValuePair<String, Campaign.ICampaign> Campaign in CampaignPairArray)
        {
            Campaigns.Add(Campaign);
        }
    }
    static public void INIT(ICampaigns Campaigns, Dictionary<String, String> Dictionary)
    {
        if (Campaigns.Count > 0)
            foreach (String key in Campaigns.Keys)
                Campaigns.Remove(key);
        foreach (String key in Dictionary.Keys)
            Campaigns.Add(new Campaign.Campaign(Key: key, Name: Dictionary[key]));
    }
    static public void INIT(ICampaigns Campaigns, Dictionary<String, Campaign.Campaign> Dictionary)
    {
        if (Campaigns.Count > 0)
            foreach (var key in Campaigns.Keys)
                Campaigns.Remove(key);
        foreach (String key in Dictionary.Keys)
            Campaigns.Add(new Campaign.Campaign(Key: key, Name: Dictionary[key].Name));
    }
    static public void INIT(ICampaigns Campaigns, ICampaigns Original)
    {
        if (Campaigns.Count > 0)
            foreach (var key in Campaigns.Keys)
                Campaigns.Remove(key);
        foreach (KeyValuePair<String, Campaign.ICampaign> Campaign in Original)
        {
            Campaigns.Add(Campaign);
        }
    }
    static public void ADD(ICampaigns Campaigns, Campaign.ICampaign Campaign)
    {
        if (Campaigns.ContainsKey(Campaign.Key)) Campaigns[Campaign.Key] = Campaign;
        else Campaigns.Add(key: Campaign.Key, value: Campaign);
    }
    static public PlayerKeySet PLAYER_KEYS(ICampaigns Campaigns, Heroes Heroes)
    {
        GameMasters.GameMaster.Players.Players temp = new();
        GameMasters.GameMaster.Players.PlayerKeySet players = new(new(), ref temp);
        players.Clear();
        foreach (KeyValuePair<string, ICampaign> pair in Campaigns)
        {
            players.Union(pair.Value.PlayerKeys(Heroes));
        }
        return players;
    }
    static public GameMasterKeySet GAME_MASTER_KEYS(ICampaigns Campaigns, Heroes Heroes)
    {
        GameMasters.GameMasters temp = new();
        GameMasters.GameMasterKeySet gameMasters = new(new(), ref temp);
        gameMasters.Clear();
        foreach (KeyValuePair<string, ICampaign> pair in Campaigns)
        {
            gameMasters.Union(pair.Value.GameMasterKeys(Heroes));
        }
        return gameMasters;
    }
    public void Init(int count = 1);
    public void Init(String Key, String Name);
    public void Init(Campaign.ICampaign Campaign);
    public void Init(String Key, Campaign.ICampaign Campaign);
    public void Init(KeyValuePair<String, Campaign.ICampaign> Campaign);
    public void Init(Campaign.ICampaign[] Campaigns);
    public void Init(KeyValuePair<String, Campaign.ICampaign>[] Campaigns);
    public void Init(Dictionary<String, String> Dictionary);
    public void Init(Dictionary<String, Campaign.Campaign> Dictionary);
    public void Init(ICampaigns Original);
    public void Add(Campaign.ICampaign Campaign);
    public PlayerKeySet PlayerKeys(Heroes Heroes);
    public GameMasterKeySet GameMasterKeys(Heroes Heroes);
}