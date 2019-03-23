using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;

// TODO: - Should add a "Quest Points" total in Levels
namespace RSAchievementTracker.DTO
{
    [Serializable]
    public class User
    {
        public Dictionary<string, long[]> Levels { get; private set; }
        public List<Quest> Quests { get; set; }

        public User()
        {
            Levels = new Dictionary<string, long[]>() {
                { "Overall", new long[] { -1, 27, 0 } }, { "Attack", new long[] { -1, 1, 0 } }, { "Defence", new long[] { -1, 1, 0 } },
                { "Strength", new long[] { -1, 1, 0 } }, { "Constitution", new long[] { -1, 1, 0 } }, { "Ranged", new long[] { -1, 1, 0 } },
                { "Prayer", new long[] { -1, 1, 0 } }, { "Magic", new long[] { -1, 1, 0 } }, { "Cooking", new long[] { -1, 1, 0 } },
                { "Woodcutting", new long[] { -1, 1, 0 } }, { "Fletching", new long[] { -1, 1, 0 } }, { "Fishing", new long[] { -1, 1, 0 } },
                { "Firemaking", new long[] { -1, 1, 0 } }, { "Crafting", new long[] { -1, 1, 0 } }, { "Smithing", new long[] { -1, 1, 0 } },
                { "Mining", new long[] { -1, 1, 0 } }, { "Herblore", new long[] { -1, 1, 0 } }, { "Agility", new long[] { -1, 1, 0 } },
                { "Thieving", new long[] { -1, 1, 0 } }, { "Slayer", new long[] { -1, 1, 0 } }, { "Farming", new long[] { -1, 1, 0 } },
                { "Runecrafting", new long[] { -1, 1, 0 } }, { "Hunter", new long[] { -1, 1, 0 } }, { "Construction", new long[] { -1, 1, 0 } },
                { "Summoning", new long[] { -1, 1, 0 } }, { "Dungeoneering", new long[] { -1, 1, 0 } }, { "Divination", new long[] { -1, 1, 0 } },
                { "Invention", new long[] { -1, 1, 0 } }
            };

            Quests = new List<Quest>();
        }
    }

    [Serializable]
    public struct Quests
    {
        [JsonProperty(PropertyName = "quests")]
        public Quest[] ListOfQuests { get; set; }
    }
    
    public struct Quest
    {
        // PropertyName assures json is being read correctly
        [JsonProperty(PropertyName = "title")]
        public string Title { get; private set; }

        [JsonProperty(PropertyName = "difficulty")]
        private int Difficulty { get; set; }

        [JsonProperty(PropertyName = "questPoints")]
        public int QuestPoints { get; private set; }

        [JsonProperty(PropertyName = "members")]
        public bool Members { get; private set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        [JsonProperty(PropertyName = "userEligible")]
        public bool Eligible { get; private set; }
        
        // converts difficulty into a readable string
        public string DifficultyString()
        {
            int difficultyNum = Difficulty;
            string difficultyString = "";
            switch (difficultyNum)
            {
                case 0:
                    difficultyString = "Novice";
                    break;
                case 1:
                    difficultyString = "Intermediate";
                    break;
                case 2:
                    difficultyString = "Experienced";
                    break;
                case 3:
                    difficultyString = "Master";
                    break;
                case 4:
                    difficultyString = "Grandmaster";
                    break;
                case 250:
                    difficultyString = "Special";
                    break;
            }

            return difficultyString;
        }

        public string StatusString()
        {
            if (!Eligible)
                return "Not Eligible";

            // changes status to Title Case and removes underscore
            return new CultureInfo("en-US", false).TextInfo.ToTitleCase(Status.ToLower().Replace("_", " "));
        }
    }
}
