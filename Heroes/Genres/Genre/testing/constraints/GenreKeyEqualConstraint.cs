using Heroes.Genres.Genre;

namespace NUnit.Framework.Constraints;

public class GenreKeyEqualConstraint : Constraint
{
    private readonly string _expectedValue;
    public override string Description { get => $"Genre Key Equal expected value: {_expectedValue}"; }
    public GenreKeyEqualConstraint(string expectedValue)
    {
        _expectedValue = expectedValue;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        Assert.That(actual, Is.InstanceOf<IGenre>());
        Assert.That(actual, Is.Not.Null);
        var genre = actual as IGenre;
        Assert.That(genre, Is.Not.Null);
        bool isMatch = genre != null && (genre.Key.CompareTo(_expectedValue) == 0); // Example: simple equality check
        return new ConstraintResult(this, actual, isMatch);
    }
}
