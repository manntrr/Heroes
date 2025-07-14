using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace Heroes;

public class Heroes
{
    public Heroes(int Genres = 1, int Campaigns = 1, int GameMasters = 1, int Players = 0, int NonPlayerCharacters = 0, int PlayerCharacters = 0)
    {
        for (int counter = 0; counter < Genres; counter++)
        {
            Genre genre = new(Key: "Genre " + (counter + 1).ToString(), Name: "Unknown");
            this.Genres.Add(genre.Key, genre);
        }
        for (int counter = 0; counter < Campaigns; counter++)
        {
            Genre genre = this.Genres["Genre " + ((counter % this.Genres.Count) + 1).ToString()];
            Genres genres = [];
            genres.Add(genre);
            Campaign campaign = new(Key: "Campaign " + (counter + 1).ToString(), CampaignGenres: genres, Name: "Unknown");
            this.Campaigns.Add(campaign.Key, campaign);
        }
        for (int counter = 0; counter < GameMasters; counter++)
        {
            Campaign campaign = this.Campaigns["Campaign " + ((counter % this.Campaigns.Count) + 1).ToString()];
            Campaigns campaigns = [];
            campaigns.Add(campaign);
            GameMaster gameMaster = new(Key: "Game Master " + (counter + 1).ToString(), Campaigns: campaigns, Name: "Unknown");
            this.Players.Add(gameMaster.Key, gameMaster);
        }
        for (int counter = 0; counter < NonPlayerCharacters; counter++)
        {
            GameMaster gameMaster = this.GameMasters["Game Master " + ((counter % this.GameMasters.Count) + 1).ToString()];
            GameMasters gameMasters = [];
            gameMasters.Add(gameMaster);
            Campaigns availableCampaigns = [];
            foreach (string campaignKey in gameMaster.Campaigns)
            {
                if (this.Campaigns.TryGetValue(campaignKey, out Campaign? value)) availableCampaigns.Add(value);
            }
            Campaign campaign = availableCampaigns[gameMaster.Campaigns.ElementAt(counter % gameMaster.Campaigns.Count)];
            Campaigns campaigns = [];
            campaigns.Add(campaign);
            NonPlayerCharacter character = new(Key: "NPC " + (counter + 1).ToString(), CharacterName: "Unknown", GameMasters: gameMasters, Campaigns: campaigns);
            this.NonPlayerCharacters.Add(character.Key, character);
        }
        if (PlayerCharacters > 0 && Players < 1) Players = 1;
        for (int counter = 0; counter < Players; counter++)
        {
            GameMaster gameMaster = this.GameMasters["Game Master " + ((counter % this.GameMasters.Count) + 1).ToString()];
            GameMasters gameMasters = [];
            gameMasters.Add(gameMaster);
            Campaigns availableCampaigns = [];
            foreach (string campaignKey in gameMaster.Campaigns)
            {
                if (this.Campaigns.TryGetValue(campaignKey, out Campaign? value)) availableCampaigns.Add(value);
            }
            Campaign campaign = availableCampaigns[gameMaster.Campaigns.ElementAt(counter % gameMaster.Campaigns.Count)];
            Campaigns campaigns = [];
            campaigns.Add(campaign);
            Player player = new(Key: "Player " + (counter + 1).ToString(), Name: "Unknown", GameMasters: gameMasters, Campaigns: campaigns);
            this.Players.Add(player.Key, player);
        }
        for (int counter = 0; counter < PlayerCharacters; counter++)
        {
            Player player = this.Players["Player " + ((counter % this.Players.Count) + 1).ToString()];
            GameMaster gameMaster = this.GameMasters["Game Master " + ((counter % this.GameMasters.Count) + 1).ToString()];
            GameMasters gameMasters = [];
            gameMasters.Add(gameMaster);
            Campaigns availableCampaigns = [];
            foreach (string campaignKey in gameMaster.Campaigns)
            {
                if (this.Campaigns.TryGetValue(campaignKey, out Campaign? value)) availableCampaigns.Add(value);
            }
            Campaign campaign = availableCampaigns[gameMaster.Campaigns.ElementAt(counter % gameMaster.Campaigns.Count)];
            Campaigns campaigns = [];
            campaigns.Add(campaign);
            PlayerCharacter character = new(Key: "Player " + (counter + 1).ToString(), CharacterName: "Unknown", Player: player, GameMasters: gameMasters, Campaigns: campaigns);
            this.PlayerCharacters.Add(character.Key, character);
        }
    }

    public Dictionary<string, Character> Characters
    {
        get
        {
            return NonPlayerCharacters
                .Select(kvp => new KeyValuePair<string, Character>(kvp.Key, kvp.Value as Character))
                .Concat(PlayerCharacters.Select(kvp => new KeyValuePair<string, Character>(kvp.Key, kvp.Value as Character)))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
    public Genres Genres { get; } = [];
    public Campaigns Campaigns { get; } = [];
    public GameMasters GameMasters
    {
        get
        {
            GameMasters gameMasters = [];
            foreach (KeyValuePair<String, Player> player in this.Players)
            {
                if (player.Value is GameMaster) gameMasters.Add(player.Key, (GameMaster)player.Value);
            }
            return gameMasters;
        }
    }
    public Dictionary<String, NonPlayerCharacter> NonPlayerCharacters { get; internal set; } = [];
    public Players Players { get; } = [];
    public Dictionary<String, PlayerCharacter> PlayerCharacters { get; internal set; } = [];
}
