namespace Heroes;

public class Campaigns : Dictionary<String, Campaign>
{
    public void Add(Campaign campaign)
    {
        this.Add(campaign.Key, campaign);
    }
}
