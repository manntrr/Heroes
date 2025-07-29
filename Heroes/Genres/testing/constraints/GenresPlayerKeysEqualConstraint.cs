using Heroes.GameMasters.GameMaster.Players;
using Heroes.Genres;
using Heroes.Genres.Genre;

namespace NUnit.Framework.Constraints;

public class GenresPlayerKeysEqualConstraint : Constraint
{
    private readonly Heroes.Heroes _context;
    private readonly PlayerKeySet _expectedValue;
    public override string Description { get => $"Genre Player Keys Equal expected value: {_expectedValue}"; }
    public GenresPlayerKeysEqualConstraint(Heroes.Heroes context, PlayerKeySet expectedValue)
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
            Assert.That(genres.PlayerKeys(_context).Count, Is.EqualTo(_expectedValue.Count));
            foreach (String key in genres.PlayerKeys(_context).Keys)
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
