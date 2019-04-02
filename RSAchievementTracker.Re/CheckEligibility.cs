using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSAchievementTracker.Persistence;
using RSAchievementTracker.DTO;
using System.Text.RegularExpressions;

namespace RSAchievementTracker.Domain
{
    public class CheckEligibility
    {
        public static List<AchievementObject> Eligibility(User currentUser, List<AchievementObject> achievementsList)
        {
            foreach (var achievement in achievementsList)
            {
                bool eligible = CompareQuests(currentUser, achievement) && CompareSkillLevels(currentUser, achievement);

                achievement.AEligible = eligible;
            }

            return achievementsList;
        }

        private static bool CompareQuests(User currentUser, AchievementObject achievement)
        {
            List<string> aQuestReqs = achievement.AQuestReqs;
            List<string> usersQuests = new List<string>();
            foreach (var uq in currentUser.Quests)
            {
                // if user completed that quest, add it to completed quest list
                if (uq.Status == "COMPLETED")
                    usersQuests.Add(uq.Title);
            }

            // if users completed quest list doesn't contain a quest requirement, false
            foreach (var aQuestReq in aQuestReqs)
            {
                string replacedString = aQuestReq;

                if (Regex.IsMatch(aQuestReq, @"\(.*\)"))
                    replacedString = Regex.Replace(aQuestReq, @"\s+\(.*\)", string.Empty);

                if (!usersQuests.Any(s => s.Equals(replacedString, StringComparison.OrdinalIgnoreCase)))
                    return false;
            }

            return true;
        }
        
        private static bool CompareSkillLevels(User currentUser, AchievementObject achievement)
        {
            List<Tuple<string, int>> aSkillReqs = achievement.ASkillReqs;
            Dictionary<string, long[]> usersSkills = currentUser.Levels;

            foreach (var aSkillReq in aSkillReqs)
            {
                if (usersSkills.ContainsKey(aSkillReq.Item1))
                {
                    int i = (int)usersSkills[aSkillReq.Item1].ElementAt(1);
                    if (i < aSkillReq.Item2)
                        return false;
                }
                else
                    return false;
                
            }
            return true;
        }
    }
}
