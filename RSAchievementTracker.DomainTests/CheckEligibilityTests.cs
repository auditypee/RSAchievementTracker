using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSAchievementTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSAchievementTracker.DTO;

namespace RSAchievementTracker.Domain.UnitTests
{
    [TestClass()]
    public class CheckEligibilityTests
    {
        [TestMethod()]
        public void EligibilityTest()
        {
            List<AchievementObject> achievementObjects = new List<AchievementObject>
            {
                new AchievementObject(
                "Advanced Sweeping",
                "Fully enchant your broomstick after the 'Swept Away' quest.",
                15,
                "Yes",
                new List<string> { "Completionist" },
                new List<string> { "Master Quest Cape", "Trimmed Completionist Cape" },
                new List<string> { "Swept Away", "Diamond in the Rough", "Lunar Diplomacy", "Underground Pass" },
                new List<Tuple<string, int>>()
                )
            };

            Assert.Fail();
        }
    }
}