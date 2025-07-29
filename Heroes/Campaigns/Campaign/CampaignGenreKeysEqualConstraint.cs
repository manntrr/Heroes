using Heroes.Campaigns;
using Heroes.Campaigns.Campaign;
using GenreKeySet = Heroes.Genres.GenreKeySet;

namespace NUnit.Framework.Constraints;

public class CampaignGenreKeysEqualConstraint : Constraint
{
    private readonly Heroes.Heroes _context;
    private readonly GenreKeySet _expectedValue;
    public override string Description { get => $"Campaign Genre Keys Equal expected value: {_expectedValue}"; }
    public CampaignGenreKeysEqualConstraint(Heroes.Heroes context, GenreKeySet expectedValue)
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
            Assert.That(genre.GenreKeys.Count, Is.EqualTo(_expectedValue.Count));
            foreach (String key in genre.GenreKeys.Keys)
            {
                Assert.That(_expectedValue.Contains(key), Is.True);
            }
        }
        catch (Exception exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}
