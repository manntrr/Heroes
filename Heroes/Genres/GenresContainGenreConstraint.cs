using Heroes.Genres;
using Heroes.Genres.Genre;
using _Heroes = Heroes.Heroes;

namespace NUnit.Framework.Constraints;

public class GenresContainGenreConstraint : Constraint
{
    private readonly _Heroes _context;
    private readonly Genre _expectedValue;
    public override string Description { get => $"Genre Equal expected value: {_expectedValue}"; }

    public GenresContainGenreConstraint(_Heroes context, Genre expectedValue)
    {
        _context = context;
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
            Assert.That(genres.ContainsKey(_expectedValue.Key), Is.True);
            Assert.That(genres[_expectedValue.Key], Is.GenreEqual(_context, _expectedValue));
        }
        catch (Exception exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}