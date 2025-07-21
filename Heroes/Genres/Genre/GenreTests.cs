using NUnit.Framework;

namespace Heroes.Genres.Genre;

public class GenreTests
{
    Genre? genre = null;
    int? givenIndex = null;
    String? expectedGenreKey = null;
    String? expectedGenreName = null;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NullConstructorTest()
    {
        expectedGenreKey = IGenre.DefaultKey;
        expectedGenreName = IGenre.DefaultName;
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void NullInitializorTest()
    {
        expectedGenreKey = IGenre.DefaultKey;
        expectedGenreName = IGenre.DefaultName;
        Assert.DoesNotThrow(() => genre = new(Index: 1));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void KeyConstructorTest()
    {
        expectedGenreKey = "Custom Genre Key";
        expectedGenreName = IGenre.DefaultName;
        Assert.DoesNotThrow(() => genre = new(Key: expectedGenreKey));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void KeyInitializorTest()
    {
        expectedGenreKey = "Custom Genre Key";
        expectedGenreName = IGenre.DefaultName;
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.DoesNotThrow(() => genre.Init(Key: expectedGenreKey));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void NameConstructorTest()
    {
        expectedGenreKey = "Custom Genre Key";
        expectedGenreName = "Custom Genre";
        Assert.DoesNotThrow(() => genre = new(Name: expectedGenreName));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void NameInitializorTest()
    {
        expectedGenreKey = "Custom Genre Key";
        expectedGenreName = "Custom Genre";
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init(Name: expectedGenreName));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void KeyNameConstructorTest()
    {
        expectedGenreKey = "Alternate Custom Genre Key";
        expectedGenreName = "Custom Genre";
        Assert.DoesNotThrow(() => genre = new(Key: expectedGenreKey, Name: expectedGenreName));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void KeyNameInitializorTest()
    {
        String expectedGenreKey = "Alternate Custom Genre Key";
        String expectedGenreName = "Custom Genre";
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init(Key: expectedGenreKey, Name: expectedGenreName));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void IndexConstructorTest()
    {
        givenIndex = 1;
        expectedGenreKey = "Genre 1";
        expectedGenreName = "Unknown Genre 1";
        Assert.DoesNotThrow(() => genre = new(Index: (int)givenIndex));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void IndexInitializorTest()
    {
        givenIndex = 1;
        expectedGenreKey = "Genre 1";
        expectedGenreName = "Unknown Genre 1";
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init(Index: (int)givenIndex));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void CopyConstructorTest()
    {
        givenIndex = 1;
        expectedGenreKey = "Genre 1";
        expectedGenreName = "Unknown Genre 1";
        Assert.DoesNotThrow(() => genre = new(Genre: new(Index: (int)givenIndex)));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void CopyInitializorTest()
    {
        givenIndex = 1;
        expectedGenreKey = "Genre 1";
        expectedGenreName = "Unknown Genre 1";
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Init(Genre: new(Index: (int)givenIndex)));
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void GetKeyAccessorTest()
    {
        expectedGenreKey = IGenre.DefaultKey;
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
    }
    [Test]
    public void SetKeyAccessorTest()
    {
        expectedGenreKey = "Genre 1";
        expectedGenreName = IGenre.DefaultName;
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.Not.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Key = expectedGenreKey);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void GetNameAccessorTest()
    {
        expectedGenreName = IGenre.DefaultName;
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void SetNameAccessorTest()
    {
        expectedGenreKey = IGenre.DefaultKey;
        expectedGenreName = "Unknown Genre 1";
        Assert.DoesNotThrow(() => genre = new());
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.Not.EqualTo(expectedGenreName));
        Assert.DoesNotThrow(() => genre.Name = expectedGenreName);
        Assert.That(genre, Is.InstanceOf<Genre>());
        Assert.That(genre, Is.Not.Null);
        Assert.That(genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(genre.Name, Is.EqualTo(expectedGenreName));
    }
}
