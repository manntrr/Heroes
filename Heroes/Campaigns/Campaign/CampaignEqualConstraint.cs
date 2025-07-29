using Heroes.Campaigns.Campaign;
using _Heroes = Heroes.Heroes;

namespace NUnit.Framework.Constraints;

public class CampaignEqualConstraint : Constraint
{
    private readonly _Heroes _context;
    private readonly Campaign _expectedValue;
    public override string Description { get => $"Campaign Equal expected value: {_expectedValue}"; }

    public CampaignEqualConstraint(_Heroes context, Campaign expectedValue)
    {
        _context = context;
        _expectedValue = expectedValue;
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
            Assert.That(genre, Is.CampaignKeyEqual(_expectedValue.Key));
            Assert.That(genre, Is.CampaignNameEqual(_expectedValue.Name));
            Assert.That(genre, Is.CampaignGenreKeysEqual(_context, _expectedValue.GenreKeys));
            Assert.That(genre, Is.CampaignPlayerKeysEqual(_context, _expectedValue.PlayerKeys(_context)));
            Assert.That(genre, Is.CampaignGameMasterKeysEqual(_context, _expectedValue.GameMasterKeys(_context)));
        }
        catch (Exception exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}