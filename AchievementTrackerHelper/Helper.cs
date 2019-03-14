using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace AchievementTrackerHelper {
    public class Helper {
        private Dictionary<string, int[]> levels;

        public Dictionary<string, int[]> Levels {
            get {
                return this.levels;
            }
            set {

            }
        }

        public Helper() {
            levels = new Dictionary<string, int[]>() {
                { "Overall", new int[] { -1, 27, 0 } }, { "Attack", new int[] { -1, 1, 0 } }, { "Defence", new int[] { -1, 1, 0 } },
                { "Strength", new int[] { -1, 1, 0 } }, { "Constitution", new int[] { -1, 1, 0 } }, { "Ranged", new int[] { -1, 1, 0 } },
                { "Prayer", new int[] { -1, 1, 0 } }, { "Magic", new int[] { -1, 1, 0 } }, { "Cooking", new int[] { -1, 1, 0 } },
                { "Woodcutting", new int[] { -1, 1, 0 } }, { "Fletching", new int[] { -1, 1, 0 } }, { "Fishing", new int[] { -1, 1, 0 } },
                { "Firemaking", new int[] { -1, 1, 0 } }, { "Crafting", new int[] { -1, 1, 0 } }, { "Smithing", new int[] { -1, 1, 0 } },
                { "Mining", new int[] { -1, 1, 0 } }, { "Herblore", new int[] { -1, 1, 0 } }, { "Agility", new int[] { -1, 1, 0 } },
                { "Thieving", new int[] { -1, 1, 0 } }, { "Slayer", new int[] { -1, 1, 0 } }, { "Farming", new int[] { -1, 1, 0 } },
                { "Runecrafting", new int[] { -1, 1, 0 } }, { "Hunter", new int[] { -1, 1, 0 } }, { "Construction", new int[] { -1, 1, 0 } },
                { "Summoning", new int[] { -1, 1, 0 } }, { "Dungeoneering", new int[] { -1, 1, 0 } }, { "Divination", new int[] { -1, 1, 0 } },
                { "Invention", new int[] { -1, 1, 0 } }
            };
        }

        public string GetStats(string url) {
            WebClient webClient = new WebClient();
            string stats = webClient.DownloadString(url);

            return stats;
        }

        public void PopulateTable(string statsString) {
            // creates an array of strings that contain rank, level, experience
            // there will be 27 from the skills + overall
            int[][] jaggedRLX = new int[28][];

            // splits the string based on the whitespace (new line in this case) between each skills
            string[] stats = statsString.Split("\n".ToCharArray());
            
            // goes through the created list
            for (int i = 0; i < 28; i++) {
                // splits each of the string even more to separate rank, level, experience
                string[] rlxString = stats.ElementAt(i).Split(',');
                int[] rlxInt = rlxString.Select(int.Parse).ToArray();
                // adds the split string to a jagged array element (up to 28 because the rest of the string are activities in the game)
                jaggedRLX[i] = rlxInt;
            }

            CreateLevelsDict(jaggedRLX);
        }

        /*
         * Initializes the Levels from the given jagged array
         */
        public void CreateLevelsDict(int[][] stats) {
            // creates an array from the level dictionary's keys
            var keys = new List<string>(levels.Keys);
            int i = 0;
            // goes through each of the level's keys and initializes their values
            foreach (string key in keys) {
                levels[key] = stats[i++];
            }
            /*
            // used to output the value to the debugger
            foreach (KeyValuePair<string, int[]> kvp in levels) { 
                string text = string.Format("Key: {0}, Value: {1}", kvp.Key, kvp.Value.ElementAt(1));
                System.Diagnostics.Debug.Write(text + "\n");
            }*/
        }

        public string NumberFormat(int num) {
            return string.Format("{0:#,0}", num);
        }
    }
}
