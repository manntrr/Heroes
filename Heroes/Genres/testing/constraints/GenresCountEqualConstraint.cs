using Heroes.Genres;

namespace NUnit.Framework.Constraints;

public class GenresCountEqualConstraint : Constraint
{
    private readonly int _expectedValue;
    public override string Description { get => $"Genre Equal expected value: {_expectedValue}"; }

    public GenresCountEqualConstraint(int expectedValue)
    {
        _expectedValue = expectedValue;
    }
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        bool isMatch = true;
        try
        {
            Assert.That(actual, Is.InstanceOf<IGenres>());
            Assert.That(actual, Is.Not.Null);
            var genres = actual as IGenres;
            Assert.That(genres, Is.Not.Null);
            Assert.That(genres, Is.InstanceOf<Genres>());
            Assert.That(genres.Count, Is.EqualTo(_expectedValue));
        }
        catch (Exception exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}