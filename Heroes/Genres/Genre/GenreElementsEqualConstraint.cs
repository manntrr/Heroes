using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using _Heroes = Heroes.Heroes;
using Heroes.Genres.Genre;

namespace NUnit.Framework.Constraints;

public class GenreElementsEqualConstraint : Constraint
{
    private readonly _Heroes _context;
    private readonly string _expectedKey;
    private readonly string _expectedName;
    private readonly CampaignKeySet _expectedCampaignKeys;
    private readonly PlayerKeySet _expectedPlayerKeys;
    private readonly GameMasterKeySet _expectedGameMasterKeys;
    public override string Description { get => $"Genre Equal expected value: {_expectedKey}, {_expectedName}, {_expectedCampaignKeys}, {_expectedPlayerKeys}, {_expectedGameMasterKeys}"; }

    public GenreElementsEqualConstraint(_Heroes context, string expectedKey, string expectedName, CampaignKeySet expectedCampaignKeys, PlayerKeySet expectedPlayerKeys, GameMasterKeySet expectedGameMasterKeys)
    {
        _context = context;
        _expectedKey = expectedKey;
        _expectedName = expectedName;
        _expectedCampaignKeys = expectedCampaignKeys;
        _expectedPlayerKeys = expectedPlayerKeys;
        _expectedGameMasterKeys = expectedGameMasterKeys;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        bool isMatch = true;
        try
        {
            Assert.That(actual, Is.InstanceOf<IGenre>());
            Assert.That(actual, Is.Not.Null);
            var genre = actual as IGenre;
            Assert.That(genre, Is.Not.Null);
            Assert.That(genre, Is.InstanceOf<Genre>());
            Assert.That(genre, Is.GenreKeyEqual(_expectedKey));
            Assert.That(genre, Is.GenreNameEqual(_expectedName));
            Assert.That(genre, Is.GenreCampaignKeysEqual(_context, _expectedCampaignKeys));
            Assert.That(genre, Is.GenrePlayerKeysEqual(_context, _expectedPlayerKeys));
            Assert.That(genre, Is.GenreGameMasterKeysEqual(_context, _expectedGameMasterKeys));
        }
        catch (Exception exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}
