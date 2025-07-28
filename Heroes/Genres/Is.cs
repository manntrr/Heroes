using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres;
using Heroes.Genres.Genre;
using _Heroes = Heroes.Heroes;

namespace NUnit.Framework.Constraints;

public class Is : NUnit.Framework.Is
{
    public static GenreEqualConstraint GenreEqual(_Heroes context, Genre expected)
    {
        return new GenreEqualConstraint(context, expected);
    }
    public static GenreElementsEqualConstraint GenreElementsEqual(_Heroes context, string expectedKey, string expectedName, CampaignKeySet expectedCampaignKeys, PlayerKeySet expectedPlayerKeys, GameMasterKeySet expectedGameMasterKeys)
    {
        return new GenreElementsEqualConstraint(context, expectedKey, expectedName, expectedCampaignKeys, expectedPlayerKeys, expectedGameMasterKeys);
    }
    public static GenreKeyEqualConstraint GenreKeyEqual(string expected)
    {
        return new GenreKeyEqualConstraint(expected);
    }
    public static GenreNameEqualConstraint GenreNameEqual(string expected)
    {
        return new GenreNameEqualConstraint(expected);
    }
    public static GenreCampaignKeysEqualConstraint GenreCampaignKeysEqual(_Heroes context, CampaignKeySet expected)
    {
        return new GenreCampaignKeysEqualConstraint(context, expected);
    }
    public static GenrePlayerKeysEqualConstraint GenrePlayerKeysEqual(_Heroes context, PlayerKeySet expected)
    {
        return new GenrePlayerKeysEqualConstraint(context, expected);
    }
    public static GenreGameMasterKeysEqualConstraint GenreGameMasterKeysEqual(_Heroes context, GameMasterKeySet expected)
    {
        return new GenreGameMasterKeysEqualConstraint(context, expected);
    }
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
