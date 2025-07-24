using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres.Genre;
using _Heroes = Heroes.Heroes;

namespace NUnit.Framework.Constraints;

public static class GenreConstraintExtensions
{
    public static GenreEqualConstraint GenreEqual(this ConstraintExpression expression, _Heroes context, Genre expected)
    {
        var constraint = new GenreEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenreElementsEqualConstraint GenreElementsEqual(this ConstraintExpression expression, _Heroes context, string expectedKey, string expectedName, CampaignKeySet expectedCampaignKeys, PlayerKeySet expectedPlayerKeys, GameMasterKeySet expectedGameMasterKeys)
    {
        var constraint = new GenreElementsEqualConstraint(context, expectedKey, expectedName, expectedCampaignKeys, expectedPlayerKeys, expectedGameMasterKeys);
        expression.Append(constraint);
        return constraint;
    }
    public static GenreKeyEqualConstraint GenreKeyEqual(this ConstraintExpression expression, string expected)
    {
        var constraint = new GenreKeyEqualConstraint(expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenreNameEqualConstraint GenreNameEqual(this ConstraintExpression expression, string expected)
    {
        var constraint = new GenreNameEqualConstraint(expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenreCampaignKeysEqualConstraint GenreCampaignKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, CampaignKeySet expected)
    {
        var constraint = new GenreCampaignKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenrePlayerKeysEqualConstraint GenrePlayerKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, PlayerKeySet expected)
    {
        var constraint = new GenrePlayerKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenreGameMasterKeysEqualConstraint GenreGameMasterKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, GameMasterKeySet expected)
    {
        var constraint = new GenreGameMasterKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
}