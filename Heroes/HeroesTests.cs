using NUnit.Framework;

namespace Heroes;

public class HeroesTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NullConstructorTest()
    {
        int expectedGenreCount = 1;
        int expectedCampaignCount = 1;
        int expectedGameMasterCount = 1;
        int expectedStraightPlayerCount = 0;
        int expectedPlayerCount = expectedGameMasterCount + expectedStraightPlayerCount;
        int expectedNonPlayerCharacterCount = 0;
        int expectedPlayerCharacterCount = 0;
        int expectedCharacterCount = expectedNonPlayerCharacterCount + expectedPlayerCharacterCount;
        Heroes heroes = new();
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.That(heroes, Is.Not.Null);
        Assert.That(heroes.Genres.Count, Is.EqualTo(expectedGenreCount));
        Assert.That(heroes.Genres.Keys.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.Genres["Genre 1"].Key, Is.EqualTo("Genre 1"));
        Assert.That(heroes.Genres["Genre 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        Assert.That(heroes.Campaigns["Campaign 1"].Key, Is.EqualTo("Campaign 1"));
        Assert.That(heroes.Campaigns["Campaign 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Campaigns["Campaign 1"].GenreKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.Campaigns["Campaign 1"].GenreKeys.Keys.Contains("Unknown"), Is.True);
        Assert.That(heroes.Campaigns["Campaign 1"].GenreKeys.Genres(heroes.Genres)["Unknown"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Campaigns["Campaign 1"].GameMasterKeys(heroes), Is.Null);
        Assert.That(heroes.GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        Assert.That(heroes.GameMasters["Game Master 1"].Key, Is.EqualTo("Game Master 1"));
        Assert.That(heroes.GameMasters["Game Master 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.GameMasters["Game Master 1"].GenreKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.GameMasters["Game Master 1"].GenreKeys.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.GameMasters["Game Master 1"].GameMasters, Is.Null);
        Assert.That(heroes.GameMasters["Game Master 1"].CampaignKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.GameMasters["Game Master 1"].CampaignKeys.Keys.ElementAt(0), Is.EqualTo("Campaign 1"));
        Assert.That(heroes.NonPlayerCharacters.Count, Is.EqualTo(expectedNonPlayerCharacterCount));
        Assert.That(heroes.Players.Count, Is.EqualTo(expectedPlayerCount));
        Assert.That(heroes.Players["Player 1"].Key, Is.EqualTo("Player 1"));
        Assert.That(heroes.Players["Player 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Players["Player 1"].GenreKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.Players["Player 1"].GenreKeys.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.Players["Player 1"].GameMasters, Is.Null);
        Assert.That(heroes.Players["Player 1"].CampaignKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.Players["Player 1"].CampaignKeys.Keys.ElementAt(0), Is.EqualTo("Campaign 1"));
        Assert.That(heroes.PlayerCharacters.Count, Is.EqualTo(expectedPlayerCharacterCount));
        Assert.That(heroes.Characters.Count, Is.EqualTo(expectedCharacterCount));
    }
    [Test]
    public void GeneratedSingleNonPlayerCharacterConstructorTest()
    {
        int expectedGenreCount = 1;
        string[] expectedGenreKeys = ["Genre 1"];
        string[] expectedGenreNames = ["Unknown"];
        int expectedCampaignCount = 1;
        string[] expectedCampaignKeys = ["Campaign 1"];
        string[] expectedCampaignNames = ["Unknown"];
        int[] expectedCampaignGenreCounts = [1];
        Dictionary<String, String>[] expectedCampaignGenreKeys = [new() { { expectedGenreKeys[0], expectedGenreNames[0] } }];
        int expectedGameMasterCount = 1;
        int expectedStraightPlayerCount = 0;
        int expectedPlayerCount = expectedGameMasterCount + expectedStraightPlayerCount;
        int expectedNonPlayerCharacterCount = 1;
        int expectedPlayerCharacterCount = 0;
        int expectedCharacterCount = expectedNonPlayerCharacterCount + expectedPlayerCharacterCount;
        Heroes heroes = new(NonPlayerCharacters: expectedNonPlayerCharacterCount);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.That(heroes, Is.Not.Null);
        Assert.That(heroes.Genres.Count, Is.EqualTo(expectedGenreCount));
        for (int index = 0; index < heroes.Genres.Count; index++)
        {
            Assert.That(heroes.Genres.Keys.ElementAt(index), Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(heroes.Genres[expectedGenreKeys[index]].Key, Is.EqualTo(expectedGenreKeys[index]));
            Assert.That(heroes.Genres[expectedGenreKeys[index]].Name, Is.EqualTo(expectedGenreNames[index]));
        }
        Assert.That(heroes.Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        for (int index = 0; index < heroes.Campaigns.Count; index++)
        {
            Assert.That(heroes.Campaigns[expectedCampaignKeys[index]].Key, Is.EqualTo(expectedCampaignKeys[index]));
            Assert.That(heroes.Campaigns[expectedCampaignKeys[index]].Name, Is.EqualTo(expectedCampaignNames[index]));
            Assert.That(heroes.Campaigns[expectedCampaignKeys[index]].GenreKeys.Count, Is.EqualTo(expectedCampaignGenreCounts[index]));
            foreach (string key in heroes.Campaigns[expectedCampaignKeys[index]].GenreKeys.Keys)
            {
                Assert.That(heroes.Campaigns[expectedCampaignKeys[index]].GenreKeys.Genres(heroes.Genres)[key].Name, Is.EqualTo(expectedCampaignGenreKeys[index][key]));
            }
            Assert.That(heroes.Campaigns[expectedCampaignKeys[index]].GameMasterKeys(heroes), Is.Null);
        }
        Assert.That(heroes.GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        Assert.That(heroes.GameMasters["Game Master 1"].Key, Is.EqualTo("Game Master 1"));
        Assert.That(heroes.GameMasters["Game Master 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.GameMasters["Game Master 1"].GenreKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.GameMasters["Game Master 1"].GenreKeys.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.GameMasters["Game Master 1"].GameMasters, Is.Null);
        Assert.That(heroes.GameMasters["Game Master 1"].CampaignKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.GameMasters["Game Master 1"].CampaignKeys.Keys.ElementAt(0), Is.EqualTo("Campaign 1"));
        Assert.That(heroes.NonPlayerCharacters.Count, Is.EqualTo(expectedNonPlayerCharacterCount));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Key, Is.EqualTo("NPC 1"));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.Key, Is.EqualTo("NPC 1"));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.Name, Is.EqualTo("Unknown"));
        //Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.Genres.Count, Is.EqualTo(1));
        //Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.Genres.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.GameMasters.Count, Is.EqualTo(1));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.GameMasters["Game Master 1"].Key, Is.EqualTo("Game Master 1"));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.GameMasters["Game Master 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.GameMasters["Game Master 1"].GenreKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.GameMasters["Game Master 1"].GenreKeys.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.GameMasters["Game Master 1"].CampaignKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.GameMasters["Game Master 1"].CampaignKeys.Keys.ElementAt(0), Is.EqualTo("Campaign 1"));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.GameMasters["Game Master 1"].GameMasters, Is.Null);
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.Campaigns.Count, Is.EqualTo(1));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.Campaigns["Campaign 1"].Key, Is.EqualTo("Campaign 1"));
        Assert.That(heroes.NonPlayerCharacters.ElementAt(0).Value.Campaigns["Campaign 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Players.Count, Is.EqualTo(expectedPlayerCount));
        Assert.That(heroes.PlayerCharacters.Count, Is.EqualTo(expectedPlayerCharacterCount));
        Assert.That(heroes.Characters.Count, Is.EqualTo(expectedCharacterCount));
    }
    [Test]
    public void GeneratedSinglePlayerCharacterConstructorTest()
    {
        int expectedGenreCount = 1;
        int expectedCampaignCount = 1;
        int expectedGameMasterCount = 1;
        int expectedStraightPlayerCount = 1;
        int expectedPlayerCount = expectedGameMasterCount + expectedStraightPlayerCount;
        int expectedNonPlayerCharacterCount = 0;
        int expectedPlayerCharacterCount = 1;
        int expectedCharacterCount = expectedNonPlayerCharacterCount + expectedPlayerCharacterCount;
        Heroes heroes = new(PlayerCharacters: expectedPlayerCharacterCount);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.That(heroes, Is.Not.Null);
        Assert.That(heroes.Genres.Count, Is.EqualTo(expectedGenreCount));
        Assert.That(heroes.Genres.Keys.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.Genres["Genre 1"].Key, Is.EqualTo("Genre 1"));
        Assert.That(heroes.Genres["Genre 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        Assert.That(heroes.Campaigns["Campaign 1"].Key, Is.EqualTo("Campaign 1"));
        Assert.That(heroes.Campaigns["Campaign 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Campaigns["Campaign 1"].GenreKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.Campaigns["Campaign 1"].GenreKeys.Keys.Contains("Unknown"), Is.True);
        Assert.That(heroes.Campaigns["Campaign 1"].GenreKeys.Genres(heroes.Genres)["Unknown"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Campaigns["Campaign 1"].GameMasterKeys(heroes), Is.Null);
        Assert.That(heroes.GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        Assert.That(heroes.GameMasters["Game Master 1"].Key, Is.EqualTo("Game Master 1"));
        Assert.That(heroes.GameMasters["Game Master 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.GameMasters["Game Master 1"].GenreKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.GameMasters["Game Master 1"].GenreKeys.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.GameMasters["Game Master 1"].GameMasters, Is.Null);
        Assert.That(heroes.GameMasters["Game Master 1"].CampaignKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.GameMasters["Game Master 1"].CampaignKeys.Keys.ElementAt(0), Is.EqualTo("Campaign 1"));
        Assert.That(heroes.NonPlayerCharacters.Count, Is.EqualTo(expectedNonPlayerCharacterCount));
        Assert.That(heroes.Players.Count, Is.EqualTo(expectedPlayerCount));
        Assert.That(heroes.PlayerCharacters.Count, Is.EqualTo(expectedPlayerCharacterCount));
        Assert.That(heroes.Characters.Count, Is.EqualTo(expectedCharacterCount));
    }
    [Test]
    public void GeneratedSingleNonPlayerCharacterAndSinglePlayerCharacterConstructorTest()
    {
        int expectedGenreCount = 1;
        int expectedCampaignCount = 1;
        int expectedGameMasterCount = 1;
        int expectedStraightPlayerCount = 1;
        int expectedPlayerCount = expectedGameMasterCount + expectedStraightPlayerCount;
        int expectedNonPlayerCharacterCount = 1;
        int expectedPlayerCharacterCount = 1;
        int expectedCharacterCount = expectedNonPlayerCharacterCount + expectedPlayerCharacterCount;
        Heroes heroes = new(NonPlayerCharacters: expectedNonPlayerCharacterCount, PlayerCharacters: expectedPlayerCharacterCount);
        Assert.That(heroes, Is.InstanceOf<Heroes>());
        Assert.That(heroes, Is.Not.Null);
        Assert.That(heroes.Genres.Count, Is.EqualTo(expectedGenreCount));
        Assert.That(heroes.Genres.Keys.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.Genres["Genre 1"].Key, Is.EqualTo("Genre 1"));
        Assert.That(heroes.Genres["Genre 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Campaigns.Count, Is.EqualTo(expectedCampaignCount));
        Assert.That(heroes.Campaigns["Campaign 1"].Key, Is.EqualTo("Campaign 1"));
        Assert.That(heroes.Campaigns["Campaign 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Campaigns["Campaign 1"].GenreKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.Campaigns["Campaign 1"].GenreKeys.Keys.Contains("Unknown"), Is.True);
        Assert.That(heroes.Campaigns["Campaign 1"].GenreKeys.Genres(heroes.Genres)["Unknown"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.Campaigns["Campaign 1"].GameMasterKeys(heroes), Is.Null);
        Assert.That(heroes.GameMasters.Count, Is.EqualTo(expectedGameMasterCount));
        Assert.That(heroes.GameMasters["Game Master 1"].Key, Is.EqualTo("Game Master 1"));
        Assert.That(heroes.GameMasters["Game Master 1"].Name, Is.EqualTo("Unknown"));
        Assert.That(heroes.GameMasters["Game Master 1"].GenreKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.GameMasters["Game Master 1"].GenreKeys.ElementAt(0), Is.EqualTo("Genre 1"));
        Assert.That(heroes.GameMasters["Game Master 1"].GameMasters, Is.Null);
        Assert.That(heroes.GameMasters["Game Master 1"].CampaignKeys.Count, Is.EqualTo(1));
        Assert.That(heroes.GameMasters["Game Master 1"].CampaignKeys.Keys.ElementAt(0), Is.EqualTo("Campaign 1"));
        Assert.That(heroes.NonPlayerCharacters.Count, Is.EqualTo(expectedNonPlayerCharacterCount));
        Assert.That(heroes.Players.Count, Is.EqualTo(expectedPlayerCount));
        Assert.That(heroes.PlayerCharacters.Count, Is.EqualTo(expectedPlayerCharacterCount));
        Assert.That(heroes.Characters.Count, Is.EqualTo(expectedCharacterCount));
    }
}
