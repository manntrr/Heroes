using Heroes.GameMasters;
using Heroes.Genres.Genre;

namespace NUnit.Framework.Constraints;

public class GenreGameMasterKeysEqualConstraint : Constraint
{
    private readonly Heroes.Heroes _context;
    private readonly GameMasterKeySet _expectedValue;
    public override string Description { get => $"Genre Game Master Keys Equal expected value: {_expectedValue}"; }
    public GenreGameMasterKeysEqualConstraint(Heroes.Heroes context, GameMasterKeySet expectedValue)
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
            Assert.That(genre.GameMasterKeys(_context).Count, Is.EqualTo(_expectedValue.Count));
            foreach (String key in genre.GameMasterKeys(_context).Keys)
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
