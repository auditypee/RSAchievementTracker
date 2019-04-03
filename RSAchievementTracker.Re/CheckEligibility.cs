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
                achievement.AEligible = CompareQuests(currentUser, achievement) && CompareSkillLevels(currentUser, achievement);

            return achievementsList;
        }

        private static bool CompareQuests(User currentUser, AchievementObject achievement)
        {
            bool eligible = true;
            List<AQuestReq> aQuestReqs = achievement.AQuestReqs;
            List<string> usersQuests = new List<string>();
            foreach (var uq in currentUser.Quests)
            {
                // if user completed that quest, add it to completed quest list
                if (uq.Status == "COMPLETED")
                    usersQuests.Add(uq.Title);
            }

            // if user's completed quest list doesn't contain a quest requirement, false
            foreach (var aQuestReq in aQuestReqs)
            {
                string replacedString = aQuestReq.Quest;

                if (Regex.IsMatch(aQuestReq.Quest, @"\(.*\)"))
                    replacedString = Regex.Replace(aQuestReq.Quest, @"\s+\(.*\)", string.Empty);

                if (usersQuests.Any(s => s.Equals(replacedString, StringComparison.OrdinalIgnoreCase)))
                    aQuestReq.CanComplete = true;
                else
                    eligible = false;
            }

            return eligible;
        }
        
        private static bool CompareSkillLevels(User currentUser, AchievementObject achievement)
        {
            bool eligible = true;
            List<ASkillReq> aSkillReqs = achievement.ASkillReqs;
            Dictionary<string, long[]> usersSkills = currentUser.Levels;

            foreach (var aSkillReq in aSkillReqs)
            {
                // if requirements has a certain skill, determine if user's level is greater than that skill
                if (usersSkills.ContainsKey(aSkillReq.Skill))
                {
                    int i = (int)usersSkills[aSkillReq.Skill].ElementAt(1);
                    if (i >= aSkillReq.Level)
                        aSkillReq.CanComplete = true;
                    else
                        eligible = false;
                }
                else
                    eligible = false;
                
            }
            return eligible;
        }
    }
}
