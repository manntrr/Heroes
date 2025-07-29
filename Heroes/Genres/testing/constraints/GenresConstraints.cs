using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres;
using Heroes.Genres.Genre;
using _Heroes = Heroes.Heroes;

namespace NUnit.Framework.Constraints;

public static class GenresConstraints
{
    public static GenresEqualConstraint GenresEqual(_Heroes context, Genres expected)
    {
        return new GenresEqualConstraint(context, expected);
    }
    public static GenresContainGenreConstraint GenresContainGenre(_Heroes context, Genre expected)
    {
        return new GenresContainGenreConstraint(context, expected);
    }
    public static GenresCountEqualConstraint GenresCountEqual(int expected)
    {
        return new GenresCountEqualConstraint(expected);
    }
    public static GenresCampaignKeysEqualConstraint GenresCampaignKeysEqual(Heroes.Heroes context, CampaignKeySet expected)
    {
        return new GenresCampaignKeysEqualConstraint(context, expected);
    }
    public static GenresPlayerKeysEqualConstraint GenresPlayerKeysEqual(Heroes.Heroes context, PlayerKeySet expected)
    {
        return new GenresPlayerKeysEqualConstraint(context, expected);
    }
    public static GenresGameMasterKeysEqualConstraint GenresGameMasterKeysEqual(Heroes.Heroes context, GameMasterKeySet expected)
    {
        return new GenresGameMasterKeysEqualConstraint(context, expected);
    }
}
