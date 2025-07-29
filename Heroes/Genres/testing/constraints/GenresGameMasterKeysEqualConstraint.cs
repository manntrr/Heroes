using Heroes.GameMasters;
using Heroes.Genres;
using Heroes.Genres.Genre;

namespace NUnit.Framework.Constraints;

public class GenresGameMasterKeysEqualConstraint : Constraint
{
    private readonly Heroes.Heroes _context;
    private readonly GameMasterKeySet _expectedValue;
    public override string Description { get => $"Genre Game Master Keys Equal expected value: {_expectedValue}"; }
    public GenresGameMasterKeysEqualConstraint(Heroes.Heroes context, GameMasterKeySet expectedValue)
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
            Assert.That(genres.GameMasterKeys(_context).Count, Is.EqualTo(_expectedValue.Count));
            foreach (String key in genres.GameMasterKeys(_context).Keys)
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
