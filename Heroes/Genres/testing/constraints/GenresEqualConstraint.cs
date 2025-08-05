using System.Collections.Generic;
using Heroes.Genres;
using Heroes.Genres.Genre;
using _Heroes = Heroes.Heroes;

namespace NUnit.Framework.Constraints;

public class GenresEqualConstraint : Constraint
{
    private readonly _Heroes _context;
    private readonly Genres _expectedValue;
    public override string Description { get => $"Genre Equal expected value: {_expectedValue}"; }

    public GenresEqualConstraint(_Heroes context, Genres expectedValue)
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
            Assert.That(genres, Is.GenresCountEqual(_expectedValue.Count));
            foreach (KeyValuePair<string, Genre> _genre in _expectedValue)
            {
                Assert.That(genres, Is.GenresContainGenre(_context, _genre.Value));
            }
        }
        catch (Exception exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}