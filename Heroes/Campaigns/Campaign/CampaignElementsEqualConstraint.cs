using Heroes.Campaigns;
using Heroes.GameMasters;
using Heroes.GameMasters.GameMaster.Players;
using _Heroes = Heroes.Heroes;
using Heroes.Campaigns.Campaign;
using GenreKeySet = Heroes.Genres.GenreKeySet;

namespace NUnit.Framework.Constraints;

public class CampaignElementsEqualConstraint : Constraint
{
    private readonly _Heroes _context;
    private readonly string _expectedKey;
    private readonly string _expectedName;
    private readonly GenreKeySet _expectedGenreKeys;
    private readonly PlayerKeySet _expectedPlayerKeys;
    private readonly GameMasterKeySet _expectedGameMasterKeys;
    public override string Description { get => $"Campaign Equal expected value: {_expectedKey}, {_expectedName}, {_expectedGenreKeys}, {_expectedPlayerKeys}, {_expectedGameMasterKeys}"; }

    public CampaignElementsEqualConstraint(_Heroes context, string expectedKey, string expectedName, GenreKeySet expectedGenreKeys, PlayerKeySet expectedPlayerKeys, GameMasterKeySet expectedGameMasterKeys)
    {
        _context = context;
        _expectedKey = expectedKey;
        _expectedName = expectedName;
        _expectedGenreKeys = expectedGenreKeys;
        _expectedPlayerKeys = expectedPlayerKeys;
        _expectedGameMasterKeys = expectedGameMasterKeys;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        bool isMatch = true;
        try
        {
            Assert.That(actual, Is.InstanceOf<ICampaign>());
            Assert.That(actual, Is.Not.Null);
            var genre = actual as ICampaign;
            Assert.That(genre, Is.Not.Null);
            Assert.That(genre, Is.InstanceOf<Campaign>());
            Assert.That(genre, Is.CampaignKeyEqual(_expectedKey));
            Assert.That(genre, Is.CampaignNameEqual(_expectedName));
            Assert.That(genre, Is.CampaignGenreKeysEqual(_context, _expectedGenreKeys));
            Assert.That(genre, Is.CampaignGenreKeysEqual(_context, _expectedGenreKeys));
            Assert.That(genre, Is.CampaignPlayerKeysEqual(_context, _expectedPlayerKeys));
            Assert.That(genre, Is.CampaignGameMasterKeysEqual(_context, _expectedGameMasterKeys));
        }
        catch (Exception exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}
