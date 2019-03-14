using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Globalization;

namespace AchievementTrackerHelper
{
    public class Helper
    {
        public User CurrentUser { get; private set; }

        public Helper()
        {
            // initializes the levels variable to default
            CurrentUser = new User();
        }

        // get the user's information (stats from hiscores and quests from quests api)
        public string GetUserInfo(string url)
        {
            string info = "";
            using (WebClient webClient = new WebClient())
            {
                info = webClient.DownloadString(url);
            }

            return info;
        }

        public void PopulateStatsData(string statsString)
        {
            // creates an array of strings that contain rank, level, experience
            // there will be 27 from the skills + overall
            long[][] jaggedRLX = new long[28][];

            // splits the string based on the whitespace (new line in this case) between each skills
            string[] stats = statsString.Split("\n".ToCharArray());

            // goes through the created list
            for (int i = 0; i < 28; i++)
            {
                List<long> rlxInt = new List<long>();
                // splits each of the string even more to separate rank, level, experience
                string[] rlxString = stats.ElementAt(i).Split(',');
                foreach (var val in rlxString)
                {
                    if (long.TryParse(val, out long x))
                    {
                        rlxInt.Add(x);
                    }
                }

                //int[] rlxInt = rlxString.Select(int.Parse).ToArray();
                // adds the split string to a jagged array element (up to 28 because the rest of the string are activities in the game)
                jaggedRLX[i] = rlxInt.ToArray();
            }

            CreateLevelsDict(jaggedRLX);
        }

        /*
         * Initializes the CurrentUser.Levels from the given jagged array
         */
        public void CreateLevelsDict(long[][] stats)
        {
            var levels = CurrentUser.Levels;
            // creates an array from the level dictionary's keys
            var keys = new List<string>(levels.Keys);
            int i = 0;
            // goes through each of the level's keys and initializes their values
            foreach (string key in keys)
            {
                levels[key] = stats[i++];
            }
        }

        /*
         * Deserializes the json string to convert to quest object and sets CurrentUser.Quests to that list
         */
        public void PopulateQuestsData(string questsJson)
        {
            var quests = JsonConvert.DeserializeObject<Quests>(questsJson);

            CurrentUser.Quests = quests.ListOfQuests.ToList();
        }
        
        /// <summary>
        ///    Formats the given number to include commas between the nth's place
        /// </summary>
        /// <param name="num">the number to format</param>
        /// <returns>the formatted number (x,xxx,xxx)</returns>
        public string NumberFormat(long num)
        {
            return string.Format("{0:#,0}", num);
        }

        /// <summary>
        ///    Converts the numbered difficulty to its corresponding string format
        /// </summary>
        /// <param name="difficultyNum">The numbered difficulty is changed to a string</param>
        /// <returns>the converted difficulty string</returns>
        public string ConvertDifficulty(int difficultyNum)
        {
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
        
        /// <summary>
        ///     Converts the quest status to its corresponding string format
        /// </summary>
        /// <param name="status">the current state the user is in during the quest</param>
        /// <param name="userEligible">if the user is currently able to do this quest or not</param>
        /// <returns>title case version of the string status (or Not Eligible depending on the boolean)</returns>
        public string ConvertStatus(string status, bool userEligible)
        {
            if (!userEligible)
                return "Not Eligible";
            
            // changes status to Title Case and removes underscore
            return new CultureInfo("en-US", false).TextInfo.ToTitleCase(status.ToLower().Replace("_", " "));
        }
    }
}
