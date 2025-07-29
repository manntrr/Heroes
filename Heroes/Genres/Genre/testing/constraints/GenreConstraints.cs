using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres.Genre;
using _Heroes = Heroes.Heroes;

namespace NUnit.Framework.Constraints;

public static class GenreConstraints
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
    public static GenreCampaignKeysEqualConstraint GenreCampaignKeysEqual(Heroes.Heroes context, CampaignKeySet expected)
    {
        return new GenreCampaignKeysEqualConstraint(context, expected);
    }
    public static GenrePlayerKeysEqualConstraint GenrePlayerKeysEqual(Heroes.Heroes context, PlayerKeySet expected)
    {
        return new GenrePlayerKeysEqualConstraint(context, expected);
    }
    public static GenreGameMasterKeysEqualConstraint GenreGameMasterKeysEqual(Heroes.Heroes context, GameMasterKeySet expected)
    {
        return new GenreGameMasterKeysEqualConstraint(context, expected);
    }
}
