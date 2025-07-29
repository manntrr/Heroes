using Heroes.Genres.Genre;
using _Heroes = Heroes.Heroes;

namespace NUnit.Framework.Constraints;

public class GenreEqualConstraint : Constraint
{
    private readonly _Heroes _context;
    private readonly Genre _expectedValue;
    public override string Description { get => $"Genre Equal expected value: {_expectedValue}"; }

    public GenreEqualConstraint(_Heroes context, Genre expectedValue)
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
            Assert.That(genre, Is.InstanceOf<Genre>());
            Assert.That(genre, Is.GenreKeyEqual(_expectedValue.Key));
            Assert.That(genre, Is.GenreNameEqual(_expectedValue.Name));
            Assert.That(genre, Is.GenreCampaignKeysEqual(_context, _expectedValue.CampaignKeys(_context)));
            Assert.That(genre, Is.GenrePlayerKeysEqual(_context, _expectedValue.PlayerKeys(_context)));
            Assert.That(genre, Is.GenreGameMasterKeysEqual(_context, _expectedValue.GameMasterKeys(_context)));
        }
        catch (Exception exception)
        {
            isMatch = false;
        }
        return new ConstraintResult(this, actual, isMatch);
    }
}