using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Campaigns.Campaign;
using _Heroes = Heroes.Heroes;
using GenreKeySet = Heroes.Genres.GenreKeySet;

namespace NUnit.Framework.Constraints;

public static class CampaignConstraints
{
    public static CampaignEqualConstraint CampaignEqual(_Heroes context, Campaign expected)
    {
        return new CampaignEqualConstraint(context, expected);
    }
    public static CampaignElementsEqualConstraint CampaignElementsEqual(_Heroes context, string expectedKey, string expectedName, GenreKeySet expectedGenreKeys, PlayerKeySet expectedPlayerKeys, GameMasterKeySet expectedGameMasterKeys)
    {
        return new CampaignElementsEqualConstraint(context, expectedKey, expectedName, expectedGenreKeys, expectedPlayerKeys, expectedGameMasterKeys);
    }
    public static CampaignKeyEqualConstraint CampaignKeyEqual(string expected)
    {
        return new CampaignKeyEqualConstraint(expected);
    }
    public static CampaignNameEqualConstraint CampaignNameEqual(string expected)
    {
        return new CampaignNameEqualConstraint(expected);
    }
    public static CampaignGenreKeysEqualConstraint CampaignGenreKeysEqual(Heroes.Heroes context, GenreKeySet expected)
    {
        return new CampaignGenreKeysEqualConstraint(context, expected);
    }
    public static CampaignPlayerKeysEqualConstraint CampaignPlayerKeysEqual(Heroes.Heroes context, PlayerKeySet expected)
    {
        return new CampaignPlayerKeysEqualConstraint(context, expected);
    }
    public static CampaignGameMasterKeysEqualConstraint CampaignGameMasterKeysEqual(Heroes.Heroes context, GameMasterKeySet expected)
    {
        return new CampaignGameMasterKeysEqualConstraint(context, expected);
    }
}
