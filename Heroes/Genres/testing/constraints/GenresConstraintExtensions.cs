using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres;
using Heroes.Genres.Genre;
using _Heroes = Heroes.Heroes;

namespace NUnit.Framework.Constraints;

public static class GenresConstraintExtensions
{
    public static GenresEqualConstraint GenresEqual(this ConstraintExpression expression, _Heroes context, Genres expected)
    {
        var constraint = new GenresEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenresContainGenreConstraint GenresContainGenre(this ConstraintExpression expression, _Heroes context, Genre expected)
    {
        var constraint = new GenresContainGenreConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenresCountEqualConstraint GenresCountEqual(this ConstraintExpression expression, int expected)
    {
        var constraint = new GenresCountEqualConstraint(expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenresCampaignKeysEqualConstraint GenresCampaignKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, CampaignKeySet expected)
    {
        var constraint = new GenresCampaignKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenresPlayerKeysEqualConstraint GenresPlayerKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, PlayerKeySet expected)
    {
        var constraint = new GenresPlayerKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
    public static GenresGameMasterKeysEqualConstraint GenresGameMasterKeysEqual(this ConstraintExpression expression, Heroes.Heroes context, GameMasterKeySet expected)
    {
        var constraint = new GenresGameMasterKeysEqualConstraint(context, expected);
        expression.Append(constraint);
        return constraint;
    }
}