using Heroes.Campaigns.Campaign;

namespace NUnit.Framework.Constraints;

public class CampaignKeyEqualConstraint : Constraint
{
    private readonly string _expectedValue;
    public override string Description { get => $"Campaign Key Equal expected value: {_expectedValue}"; }
    public CampaignKeyEqualConstraint(string expectedValue)
    {
        _expectedValue = expectedValue;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        Assert.That(actual, Is.InstanceOf<ICampaign>());
        Assert.That(actual, Is.Not.Null);
        var genre = actual as ICampaign;
        Assert.That(genre, Is.Not.Null);
        bool isMatch = genre != null && (genre.Key.CompareTo(_expectedValue) == 0); // Example: simple equality check
        return new ConstraintResult(this, actual, isMatch);
    }
}
