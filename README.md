# RSAchievementTracker
Tracks a user's stats and quests to determine if they are able to complete an achievement.

Input your Runescape username to track your stats. (Only tracks RS3 stats)

Don't have one? Try these usernames:
```
Zezima
Page 404
Kyouko
Godzilla
As h
March2019
```

### Show Stats
Shows each of your skills and their levels.

### Show Quests
Shows the progress in each of your quests.

### Show Achievements
- Each achievement is placed in their respective category and subcategory.
- The quest and skill requirements are shown below an achievement.
  - A checkmark is shown on whether or not the user has that requirement.

## How it Works
The Achievements Database is scraped from [RSWiki](https://runescape.wiki/w/List_of_achievements) using [AchievementScraper](https://github.com/auditypee/AchievementScraper) that I created.

Clicking "Track" with a valid username pulls data from RS3's API and populates the Quests and Stats Table with the user's.

The Quests and Stats are compared to the requirements of an achievement and changes the eligibility for a user accordingly.
