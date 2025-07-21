using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using Heroes.Campaigns;
using Heroes.Campaigns.Campaign;
using Heroes.GameMasters.GameMaster.Players.Player;
using Heroes.Genres;
using Heroes.Genres.Genre;

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
            Genres.Genres genres = [];
            genres.Add(genre);
            Genres.Genres temp = this.Genres;
            Campaign campaign = new(Key: "Campaign " + (counter + 1).ToString(), GenreKeys: new GenreKeySet(genres, ref temp), Name: "Unknown");
            this.Campaigns.Add(campaign.Key, campaign);
        }
        for (int counter = 0; counter < GameMasters; counter++)
        {
            Campaign campaign = this.Campaigns["Campaign " + ((counter % this.Campaigns.Count) + 1).ToString()];
            Campaigns.Campaigns campaigns = [];
            campaigns.Add(campaign);
            Campaigns.Campaigns temp = this.Campaigns;
            GameMasters.GameMaster.GameMaster gameMaster = new(Key: "Game Master " + (counter + 1).ToString(), CampaignKeys: new CampaignKeySet(campaigns, ref temp), Name: "Unknown");
            this.Players.Add(gameMaster.Key, gameMaster);
        }
        for (int counter = 0; counter < NonPlayerCharacters; counter++)
        {
            GameMasters.GameMaster.GameMaster gameMaster = this.GameMasters["Game Master " + ((counter % this.GameMasters.Count) + 1).ToString()];
            GameMasters.GameMasters gameMasters = [];
            gameMasters.Add(gameMaster);
            Campaigns.Campaigns availableCampaigns = [];
            foreach (string campaignKey in gameMaster.CampaignKeys.Keys)
            {
                if (this.Campaigns.TryGetValue(campaignKey, out Campaign? value)) availableCampaigns.Add(value);
            }
            Campaign campaign = availableCampaigns[gameMaster.CampaignKeys.Keys.ElementAt(counter % gameMaster.CampaignKeys.Count)];
            Campaigns.Campaigns campaigns = [];
            campaigns.Add(campaign);
            NonPlayerCharacter character = new(Key: "NPC " + (counter + 1).ToString(), CharacterName: "Unknown", GameMasters: gameMasters, Campaigns: campaigns);
            this.NonPlayerCharacters.Add(character.Key, character);
        }
        if (PlayerCharacters > 0 && Players < 1) Players = 1;
        for (int counter = 0; counter < Players; counter++)
        {
            GameMasters.GameMaster.GameMaster gameMaster = this.GameMasters["Game Master " + ((counter % this.GameMasters.Count) + 1).ToString()];
            GameMasters.GameMasters gameMasters = [];
            gameMasters.Add(gameMaster);
            Campaigns.Campaigns availableCampaigns = [];
            foreach (string campaignKey in gameMaster.CampaignKeys.Keys)
            {
                if (this.Campaigns.TryGetValue(campaignKey, out Campaign? value)) availableCampaigns.Add(value);
            }
            Campaign campaign = availableCampaigns[gameMaster.CampaignKeys.Keys.ElementAt(counter % gameMaster.CampaignKeys.Count)];
            Campaigns.Campaigns campaigns = [];
            campaigns.Add(campaign);
            Campaigns.Campaigns temp = this.Campaigns;
            GameMasters.GameMaster.Players.Player.Player player = new(Key: "Player " + (counter + 1).ToString(), Name: "Unknown", GameMasters: gameMasters, CampaignKeys: new CampaignKeySet(campaigns, ref temp));
            this.Players.Add(player.Key, player);
        }
        for (int counter = 0; counter < PlayerCharacters; counter++)
        {
            GameMasters.GameMaster.Players.Player.Player player = this.Players["Player " + ((counter % this.Players.Count) + 1).ToString()];
            GameMasters.GameMaster.GameMaster gameMaster = this.GameMasters["Game Master " + ((counter % this.GameMasters.Count) + 1).ToString()];
            GameMasters.GameMasters gameMasters = [];
            gameMasters.Add(gameMaster);
            Campaigns.Campaigns availableCampaigns = [];
            foreach (string campaignKey in gameMaster.CampaignKeys.Keys)
            {
                if (this.Campaigns.TryGetValue(campaignKey, out Campaign? value)) availableCampaigns.Add(value);
            }
            Campaign campaign = availableCampaigns[gameMaster.CampaignKeys.Keys.ElementAt(counter % gameMaster.CampaignKeys.Count)];
            Campaigns.Campaigns campaigns = [];
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
    public Genres.Genres Genres { get; } = [];
    public Campaigns.Campaigns Campaigns { get; } = [];
    public GameMasters.GameMasters GameMasters
    {
        get
        {
            GameMasters.GameMasters gameMasters = [];
            foreach (KeyValuePair<String, GameMasters.GameMaster.Players.Player.Player> player in this.Players)
            {
                if (player.Value is GameMasters.GameMaster.GameMaster) gameMasters.Add(player.Key, (GameMasters.GameMaster.GameMaster)player.Value);
            }
            return gameMasters;
        }
    }
    public Dictionary<String, NonPlayerCharacter> NonPlayerCharacters { get; internal set; } = [];
    public GameMasters.GameMaster.Players.Players Players { get; } = [];
    public Dictionary<String, PlayerCharacter> PlayerCharacters { get; internal set; } = [];
}
