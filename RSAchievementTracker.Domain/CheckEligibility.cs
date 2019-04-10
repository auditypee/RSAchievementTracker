using RSAchievementTracker.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if (Regex.IsMatch(aSkillReq.LevelSkill, @" or "))
                {
                    var levelSkills = SeparateSkills(aSkillReq.LevelSkill);
                    bool canComplete = aSkillReq.CanComplete;
                    foreach (var levelSkill in levelSkills)
                    {
                        if (usersSkills.ContainsKey(levelSkill.Item2))
                        {
                            int i = (int)usersSkills[levelSkill.Item2].ElementAt(1);
                            if (i >= levelSkill.Item1)
                                canComplete = true;
                            else
                                eligible = false;
                        }
                    }
                    aSkillReq.CanComplete = canComplete;
                }
                else
                {
                    var levelSkill = SplitLevelSkill(aSkillReq.LevelSkill);

                    if (usersSkills.ContainsKey(levelSkill.Item2))
                    {
                        int i = (int)usersSkills[levelSkill.Item2].ElementAt(1);
                        if (i >= levelSkill.Item1)
                            aSkillReq.CanComplete = true;
                        else
                            eligible = false;
                    }
                }
            }
            return eligible;
        }

        private static List<Tuple<int, string>> SeparateSkills(string orSkills)
        {
            List<Tuple<int, string>> listOfSkills = new List<Tuple<int, string>>();
            List<string> levelSkills = orSkills.Split(new string[] { " or " }, StringSplitOptions.None).ToList();
            foreach (var levelSkill in levelSkills)
            {
                listOfSkills.Add(SplitLevelSkill(levelSkill));
            }

            return listOfSkills;
        }

        private static Tuple<int, string> SplitLevelSkill(string levelSkill)
        {
            int level = int.Parse(Regex.Match(levelSkill, @"\d+").Value);
            string skill = Regex.Match(levelSkill, @"[A-Za-z]+\s*[A-Za-z]*").Value;

            Tuple<int, string> result = new Tuple<int, string>(level, skill);

            return result;
        }
    }
}