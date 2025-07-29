using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Campaigns.Campaign;
using _Heroes = Heroes.Heroes;
using GenreKeySet = Heroes.Genres.GenreKeySet;

namespace NUnit.Framework.Constraints;

public static class CampaignConstraintExtensions
{
    public static CampaignEqualConstraint CampaignEqual(this ConstraintExpression expression, _Heroes context, Campaign expected)
    {
        var constraint = new CampaignEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static CampaignElementsEqualConstraint CampaignElementsEqual(this ConstraintExpression expression, _Heroes context, string expectedKey, string expectedName, GenreKeySet expectedGenreKeys, PlayerKeySet expectedPlayerKeys, GameMasterKeySet expectedGameMasterKeys)
    {
        var constraint = new CampaignElementsEqualConstraint(context, expectedKey, expectedName, expectedGenreKeys, expectedPlayerKeys, expectedGameMasterKeys);
        expression.Append(constraint);
        return constraint;
    }
    public static CampaignKeyEqualConstraint CampaignKeyEqual(this ConstraintExpression expression, string expected)
    {
        var constraint = new CampaignKeyEqualConstraint(expected);
        expression.Append(constraint);
        return constraint;
    }
    public static CampaignNameEqualConstraint CampaignNameEqual(this ConstraintExpression expression, string expected)
    {
        var constraint = new CampaignNameEqualConstraint(expected);
        expression.Append(constraint);
        return constraint;
    }
    public static CampaignGenreKeysEqualConstraint CampaignGenreKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, GenreKeySet expected)
    {
        var constraint = new CampaignGenreKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static CampaignPlayerKeysEqualConstraint CampaignPlayerKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, PlayerKeySet expected)
    {
        var constraint = new CampaignPlayerKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static CampaignGameMasterKeysEqualConstraint CampaignGameMasterKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, GameMasterKeySet expected)
    {
        var constraint = new CampaignGameMasterKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
}