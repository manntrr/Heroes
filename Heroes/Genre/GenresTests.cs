using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Heroes;

public class GenresTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NullConstructorTest()
    {
        int expectedGenreCount = 1;
        String[] expectedGenreKeys = ["Genre 1"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> { { expectedGenreKeys[0], "Unknown" } };
        Genres Genres = new();
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
    [Test]
    public void GeneratedCountConstructorTest()
    {
        int expectedGenreCount = 2;
        String[] expectedGenreKeys = ["Genre 1", "Genre 2"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Genres Genres = new(Count: expectedGenreCount);
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
    [Test]
    public void GenreElementsConstructorTest()
    {
        int expectedGenreCount = 1;
        String[] expectedGenreKeys = ["Genre 1"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Genres Genres = new(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]]);
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
    [Test]
    public void GenreKeyValuePairConstructorTest()
    {
        int expectedGenreCount = 1;
        String[] expectedGenreKeys = ["Genre 1"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        KeyValuePair<String, IGenre> Genre = new(key: expectedGenreKeys[0], value: new Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]]));
        Genres Genres = new(Genre: Genre);
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
    [Test]
    public void GenreElementsDictionaryConstructorTest()
    {
        int expectedGenreCount = 2;
        String[] expectedGenreKeys = ["Genre 1", "Genre 2"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Genres Genres = new(Dictionary: new Dictionary<string, string> {
            { expectedGenreKeys[0], expectedGenreNames[expectedGenreKeys[0]]},
            { expectedGenreKeys[1], expectedGenreNames[expectedGenreKeys[1]]}
        });
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
    [Test]
    public void GenreConstructorTest()
    {
        int expectedGenreCount = 1;
        String[] expectedGenreKeys = ["Genre 1"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Genres Genres = new(Genre: new Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]]));
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
    [Test]
    public void GenreArrayConstructorTest()
    {
        int expectedGenreCount = 2;
        String[] expectedGenreKeys = ["Genre 1", "Genre 2"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Genres Genres = new(Array: [
            new Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]]),
            new Genre(Key: expectedGenreKeys[1], Name: expectedGenreNames[expectedGenreKeys[1]])]);
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
    [Test]
    public void GenreKeyValuePairArrayConstructorTest()
    {
        int expectedGenreCount = 2;
        String[] expectedGenreKeys = ["Genre 1", "Genre 2"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Genres Genres = new(Array: new KeyValuePair<string, IGenre>[] {
            new KeyValuePair<string, IGenre>(
                key: expectedGenreKeys[0],
                value: new Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])
                ),
            new KeyValuePair<string, IGenre>(
                key: expectedGenreKeys[1],
                value: new Genre(Key: expectedGenreKeys[1], Name: expectedGenreNames[expectedGenreKeys[1]])
                )});
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }

    [Test]
    public void GenreDictionaryConstructorTest()
    {
        int expectedGenreCount = 2;
        String[] expectedGenreKeys = ["Genre 1", "Genre 2"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" },
            { expectedGenreKeys[1], "Unknown Genre" } };
        Genres Genres = new(Dictionary: new Dictionary<string, Genre> {
            { expectedGenreKeys[0], new Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]])},
            { expectedGenreKeys[1], new Genre(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[1]])}
        });
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
    [Test]
    public void CopyConstructorTest()
    {
        int expectedGenreCount = 1;
        String[] expectedGenreKeys = ["Genre 1"];
        Dictionary<String, String> expectedGenreNames = new Dictionary<String, String> {
            { expectedGenreKeys[0], "Unknown Genre" } };
        Genres Genres = new(Original: new Genres(Key: expectedGenreKeys[0], Name: expectedGenreNames[expectedGenreKeys[0]]));
        Assert.That(Genres, Is.InstanceOf<Genres>());
        Assert.That(Genres, Is.Not.Null);
        Assert.That(Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < Genres.Count; index++)
        {
            Assert.That(Genres.Keys.Contains(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres.ContainsKey(expectedGenreKeys[index]), Is.True);
            Assert.That(Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[expectedGenreKeys[index]]));
        }
    }
}
