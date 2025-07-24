using Heroes.Genres.Genre;

namespace NUnit.Framework.Constraints;

public class GenreNameEqualConstraint : Constraint
{
    private readonly string _expectedValue;
    public override string Description { get => $"Genre Name Equal expected value: {_expectedValue}"; }
    public GenreNameEqualConstraint(string expectedValue)
    {
        _expectedValue = expectedValue;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        Assert.That(actual, Is.InstanceOf<IGenre>());
        Assert.That(actual, Is.Not.Null);
        var genre = actual as IGenre;
        Assert.That(genre, Is.Not.Null);
        bool isMatch = genre != null && (genre.Name.CompareTo(_expectedValue) == 0); // Example: simple equality check
        return new ConstraintResult(this, actual, isMatch);
    }
}
