using Heroes.Campaigns;
using Heroes.Genres.Genre;

namespace NUnit.Framework.Constraints;

public class GenreCampaignKeysEqualConstraint : Constraint
{
    private readonly Heroes.Heroes _context;
    private readonly CampaignKeySet _expectedValue;
    public override string Description { get => $"Genre Campaign Keys Equal expected value: {_expectedValue}"; }
    public GenreCampaignKeysEqualConstraint(Heroes.Heroes context, CampaignKeySet expectedValue)
    {
        _context = context;
        _expectedValue = expectedValue;
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
            Assert.That(genre.CampaignKeys(_context).Count, Is.EqualTo(_expectedValue.Count));
            foreach (String key in genre.CampaignKeys(_context).Keys)
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
