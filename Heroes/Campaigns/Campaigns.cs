namespace Heroes;

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic;

public class Campaigns : Dictionary<String, Campaign>, ICampaigns
{
    ICollection<string> IDictionary<string, ICampaign>.Keys => ICampaigns.KEYS(Campaigns: this);
    ICollection<ICampaign> IDictionary<string, ICampaign>.Values => ICampaigns.VALUES(Campaigns: this);
    public bool IsReadOnly => ICampaigns.IS_READ_ONLY(Campaigns: this);

    public Dictionary<string, string> Dictionary { get; }
    public object Array { get; }

    ICampaign IDictionary<string, ICampaign>.this[string key]
    {
        get => base[key];
        // ICampaigns.GET_CAMPAIGN(Campaigns: this, Key: key);
        set => base[key] = (Campaign)value;
        // ICampaigns.SET_CAMPAIGN(Campaigns: this, Key: key, Campaign: value);
    }
    public void Add(string key, ICampaign value)
    {
        if (base.ContainsKey(key: key))
            base[key] = (Campaign)value;
        else
            base.Add(key: key, value: (Campaign)value);
    }
    //=> ICampaigns.ADD(Campaigns: this, Key: key, Campaign: value);
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out ICampaign value)
    {
        ICampaign? CampaignValue;
        bool result = ICampaigns.TRY_GET_VALUE(Campaigns: this, Key: key, Value: out CampaignValue);
        value = CampaignValue;
        return result;
    }
    public void Add(KeyValuePair<string, ICampaign> item) => ICampaigns.ADD(Campaigns: this, Item: item);
    public bool Contains(KeyValuePair<string, ICampaign> item) => ICampaigns.CONTAINS(Campaigns: this, Item: item);
    public void CopyTo(KeyValuePair<string, ICampaign>[] array, int arrayIndex) => ICampaigns.COPY_TO(Campaigns: this, Array: array, ArrayIndex: arrayIndex);
    public bool Remove(KeyValuePair<string, ICampaign> item) => ICampaigns.REMOVE(Campaigns: this, Item: item);
    IEnumerator<KeyValuePair<string, ICampaign>> IEnumerable<KeyValuePair<string, ICampaign>>.GetEnumerator()
    {
        foreach (var kvp in this)
        {
            yield return new KeyValuePair<string, ICampaign>(kvp.Key, kvp.Value);
        }
    }
    // => ICampaigns.GET_ENUMERATOR(Campaigns: this);
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(int Count = 1) => Init(Count: Count);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(String Key, String Name) => Init(Key: Key, Name: Name);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(ICampaign Campaign) => Init(Campaign: Campaign);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(String Key, ICampaign Campaign) => Init(Key: Key, Campaign: Campaign);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(KeyValuePair<String, ICampaign> Campaign) => Init(Campaign: Campaign);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(ICampaign[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(KeyValuePair<String, ICampaign>[] Array) => Init(Array: Array);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(Dictionary<String, String> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(Dictionary<String, Campaign> Dictionary) => Init(Dictionary: Dictionary);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Campaigns(ICampaigns Original) => Init(Original: Original);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public void Init(int Count = 1) => ICampaigns.INIT(this, Count: Count);
    public void Init(String Key, String Name) => ICampaigns.INIT(this, Key: Key, Name: Name);
    public void Init(ICampaign Campaign) => ICampaigns.INIT(this, Campaign: Campaign);
    public void Init(String Key, ICampaign Campaign) => ICampaigns.INIT(this, Key: Key, Campaign: Campaign);
    public void Init(KeyValuePair<String, ICampaign> Campaign) => ICampaigns.INIT(this, Campaign: Campaign);
    public void Init(ICampaign[] Array) => ICampaigns.INIT(this, CampaignArray: Array);
    public void Init(KeyValuePair<String, ICampaign>[] Array) => ICampaigns.INIT(this, CampaignPairArray: Array);
    public void Init(Dictionary<String, String> Dictionary) => ICampaigns.INIT(this, Dictionary: Dictionary);
    public void Init(Dictionary<String, Campaign> Dictionary) => ICampaigns.INIT(this, Dictionary: Dictionary);
    public void Init(ICampaigns Original) => ICampaigns.INIT(this, Original: Original);
    public void Add(ICampaign Campaign) => ICampaigns.ADD(this, Campaign);
    public static implicit operator Dictionary<String, ICampaign>(Campaigns Campaigns) => ICampaigns.CONVERT_CAMPAIGNS_TO_DICTIONARY(Campaigns: Campaigns);
    public static explicit operator Campaigns(Dictionary<String, ICampaign> Dictionary) => (Campaigns)ICampaigns.CONVERT_DICTIONARY_TO_CAMPAIGNS(Dictionary: Dictionary);
}
