using System.Collections.Immutable;

namespace Heroes.Campaigns;

public class CampaignKeySet : HashSet<String>
{
    public String[] Keys { get => this.ToArray<String>(); }
    public CampaignKeySet(Campaigns Campaigns, ref Campaigns MasterCampaigns)
    {
        base.UnionWith(Campaigns.Keys);
        foreach (String key in this.Except(MasterCampaigns.Keys))
        {
            MasterCampaigns.Add(key, Campaigns[key]);
        }
    }
    public CampaignKeySet(CampaignKeySet Original)
    {
        foreach (String key in Original)
        {
            base.Add(key);
        }
    }
    public Campaigns Campaigns(Campaigns MasterCampaigns, bool throwIfMissingInMaster = true)
    {
        Campaigns result = [];
        CampaignKeySet masterKeySet = new(MasterCampaigns, ref MasterCampaigns);
        CampaignKeySet missingKeySet = new CampaignKeySet(MasterCampaigns, ref MasterCampaigns);
        missingKeySet.Clear();
        missingKeySet.UnionWith(this.Except(masterKeySet));
        if (missingKeySet.Count > 0 && throwIfMissingInMaster) throw new ArgumentOutOfRangeException(nameof(MasterCampaigns), missingKeySet, "Missing keys in the Master list!");
        Campaigns intersectedCampaigns = new Campaigns();
        intersectedCampaigns.Clear();
        foreach (var key in masterKeySet.Intersect(this))
        {
            intersectedCampaigns.Add(key, MasterCampaigns[key]);
        }
        result.Clear();
        CampaignKeySet resultKeySet = new CampaignKeySet(intersectedCampaigns, ref MasterCampaigns);
        foreach (String key in resultKeySet)
        {
            result.Add(MasterCampaigns[key]);
        }
        return result;
    }
}
