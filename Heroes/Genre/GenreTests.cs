using NUnit.Framework;

namespace Heroes;

public class GenreTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NullConstructorTest()
    {
        String expectedGenreKey = IGenre.DefaultKey;
        String expectedGenreName = IGenre.DefaultName;
        Genre Genre = new();
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void NullInitializorTest()
    {
        String expectedGenreKey = IGenre.DefaultKey;
        String expectedGenreName = IGenre.DefaultName;
        Genre Genre = new(1);
        Genre.Init();
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void KeyConstructorTest()
    {
        String expectedGenreKey = "Custom Genre Key";
        String expectedGenreName = IGenre.DefaultName;
        Genre Genre = new(Key: expectedGenreKey);
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void KeyInitializorTest()
    {
        String expectedGenreKey = "Custom Genre Key";
        String expectedGenreName = IGenre.DefaultName;
        Genre Genre = new();
        Genre.Init(Key: expectedGenreKey);
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void NameConstructorTest()
    {
        String expectedGenreKey = "Custom Genre Key";
        String expectedGenreName = "Custom Genre";
        Genre Genre = new(Name: expectedGenreName);
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void NameInitializorTest()
    {
        String expectedGenreKey = "Custom Genre Key";
        String expectedGenreName = "Custom Genre";
        Genre Genre = new();
        Genre.Init(Name: expectedGenreName);
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void KeyNameConstructorTest()
    {
        String expectedGenreKey = "Custom Genre Key";
        String expectedGenreName = "Custom Genre";
        Genre Genre = new(Key: expectedGenreKey, Name: expectedGenreName);
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void KeyNameInitializorTest()
    {
        String expectedGenreKey = "Custom Genre Key";
        String expectedGenreName = "Custom Genre";
        Genre Genre = new();
        Genre.Init(Key: expectedGenreKey, Name: expectedGenreName);
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void IndexConstructorTest()
    {
        int givenIndex = 1;
        String expectedGenreKey = "Genre 1";
        String expectedGenreName = "Unknown Genre 1";
        Genre Genre = new(givenIndex);
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void IndexInitializorTest()
    {
        int givenIndex = 1;
        String expectedGenreKey = "Genre 1";
        String expectedGenreName = "Unknown Genre 1";
        Genre Genre = new();
        Genre.Init(givenIndex);
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void CopyConstructorTest()
    {
        int givenIndex = 1;
        String expectedGenreKey = "Genre 1";
        String expectedGenreName = "Unknown Genre 1";
        Genre Genre = new(Genre: new(Index: givenIndex));
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
    [Test]
    public void CopyInitializorTest()
    {
        int givenIndex = 1;
        String expectedGenreKey = "Genre 1";
        String expectedGenreName = "Unknown Genre 1";
        Genre Genre = new(Index: givenIndex);
        Genre.Init(Genre: Genre);
        Assert.That(Genre, Is.InstanceOf<Genre>());
        Assert.That(Genre, Is.Not.Null);
        Assert.That(Genre.Key, Is.EqualTo(expectedGenreKey));
        Assert.That(Genre.Name, Is.EqualTo(expectedGenreName));
    }
}
