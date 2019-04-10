<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="RSAchievementTracker.Presentation.UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .btn-light {
            color: #fff;
            background-color: #1B2C34;
            border-color: #1B2C34;
            text-align: left;
        }

            .btn-light:hover {
                color: #fff;
                background-color: #1C3B40;
                border-color: #1C3B40;
            }

        .btn-dark {
            color: #fff;
            background-color: #071820;
            border-color: #071820;
            text-align: left;
        }

            .btn-dark:hover {
                color: #fff;
                background-color: #03282E;
                border-color: #03282E;
            }
    </style>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <asp:Label ID="UsernameHeader" runat="server" CssClass="display-1" Text=""></asp:Label>
            </div>
            <div class="row">
                <asp:Button ID="ShowStats" CssClass="btn btn-primary" runat="server" Text="Show Stats" OnClick="ShowStats_Click" />
                <asp:Button ID="ShowQuests" CssClass="btn btn-primary" runat="server" Text="Show Quests" OnClick="ShowQuests_Click" />
                <asp:Button ID="ShowAchievements" CssClass="btn btn-primary" runat="server" Text="Show Achievements" OnClick="ShowAchievements_Click" />
            </div>
            <asp:MultiView ID="MultiView" runat="server">
                <asp:View ID="InitialView" runat="server"></asp:View>
                <asp:View ID="StatsView" runat="server">
                    <h2>Stats</h2>
                    <asp:Label ID="userStatsLbl" runat="server"></asp:Label>
                    <asp:GridView ID="statsGridView" CssClass="table table-sm table-striped" UseAccessibleHeader="true" runat="server">
                    </asp:GridView>
                </asp:View>
                <asp:View ID="QuestsView" runat="server">
                    <h2>Quests</h2>
                    <asp:Label ID="userQuestsLbl" runat="server"></asp:Label>
                    <asp:GridView ID="questsGridView" CssClass="table table-sm table-striped" UseAccessibleHeader="true" runat="server">
                    </asp:GridView>
                </asp:View>
                <asp:View ID="AchievementsView" runat="server">
                    <h2>Achievements</h2>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div class="row">
                        <div class="col-2">
                            <div class="accordion" id="categories">
                                <div class="card text-center">
                                    <div class="card-header" id="aSkills">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseSkills" aria-expanded="true" aria-controls="collapseSkills">
                                            <h4 class="text-center text-uppercase">Skills
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseSkills" aria-labelledby="aSkills" data-parent="#categories">
                                        <asp:UpdatePanel ID="SkillsUpdatePanel" runat="server">
                                            <ContentTemplate>
                                                <div class="btn-group-vertical btn-group-sm btn-block">
                                                    <asp:Button ID="Skills" CssClass="btn btn-light" runat="server" Text="All" OnClick="CategoriesBtn_Click" OnPreRender="PreRenderBtnTrigger" />
                                                    <asp:Button ID="AgilityBtn" CssClass="btn btn-dark" runat="server" Text="Agility" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="CookingBtn" CssClass="btn btn-light" runat="server" Text="Cooking" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="ConstructionBtn" CssClass="btn btn-dark" runat="server" Text="Construction" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="CraftingBtn" CssClass="btn btn-light" runat="server" Text="Crafting" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="DungeoneeringBtn" CssClass="btn btn-dark" runat="server" Text="Dungeoneering" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="DivinationBtn" CssClass="btn btn-light" runat="server" Text="Divination" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="FarmingBtn" CssClass="btn btn-dark" runat="server" Text="Farming" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="FishingBtn" CssClass="btn btn-light" runat="server" Text="Fishing" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="FiremakingBtn" CssClass="btn btn-dark" runat="server" Text="Firemaking" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="FletchingBtn" CssClass="btn btn-light" runat="server" Text="Fletching" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="HerbloreBtn" CssClass="btn btn-dark" runat="server" Text="Herblore" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="HunterBtn" CssClass="btn btn-light" runat="server" Text="Hunter" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="InventionBtn" CssClass="btn btn-dark" runat="server" Text="Invention" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="MiningBtn" CssClass="btn btn-light" runat="server" Text="Mining" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="PrayerBtn" CssClass="btn btn-dark" runat="server" Text="Prayer" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="RunecraftingBtn" CssClass="btn btn-light" runat="server" Text="Runecrafting" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="SmithingBtn" CssClass="btn btn-dark" runat="server" Text="Smithing" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="SummoningBtn" CssClass="btn btn-light" runat="server" Text="Summoning" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="ThievingBtn" CssClass="btn btn-dark" runat="server" Text="Thieving" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="WoodcuttingBtn" CssClass="btn btn-light" runat="server" Text="Woodcutting" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="SkillingPetsBtn" CssClass="btn btn-dark" runat="server" Text="Skilling Pets" OnClick="SubcategoriesBtn_Click" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="card text-center">
                                    <div class="card-header" id="aExploration">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseExploration" aria-expanded="true" aria-controls="collapseExploration">
                                            <h4 class="text-center text-uppercase">Exploration
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseExploration" aria-labelledby="aExploration" data-parent="#categories">
                                        <asp:UpdatePanel ID="ExplorationUpdatePanel" runat="server">
                                            <ContentTemplate>
                                                <div class="btn-group-vertical btn-group-sm btn-block">
                                                    <asp:Button ID="Exploration" CssClass="btn btn-light" runat="server" Text="All" OnClick="CategoriesBtn_Click" />
                                                    <asp:Button ID="ArdougneBtn" CssClass="btn btn-dark" runat="server" Text="Ardougne" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="DesertBtn" CssClass="btn btn-light" runat="server" Text="Desert" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="DaemonheimBtn" CssClass="btn btn-dark" runat="server" Text="Daemonheim" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="FaladorBtn" CssClass="btn btn-light" runat="server" Text="Falador" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="FremennikBtn" CssClass="btn btn-dark" runat="server" Text="Fremennik" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="KaramjaBtn" CssClass="btn btn-light" runat="server" Text="Karamja" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="LodestoneBtn" CssClass="btn btn-dark" runat="server" Text="Lodestone" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="LumbridgeBtn" CssClass="btn btn-light" runat="server" Text="Lumbridge" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="MenaphosBtn" CssClass="btn btn-dark" runat="server" Text="Menaphos" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="MorytaniaBtn" CssClass="btn btn-light" runat="server" Text="Morytania" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="SeersVillageBtn" CssClass="btn btn-dark" runat="server" Text="Seers' Village" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="TirannwnBtn" CssClass="btn btn-light" runat="server" Text="Tirannwn" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="VarrockBtn" CssClass="btn btn-dark" runat="server" Text="Varrock" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="WildernessBtn" CssClass="btn btn-light" runat="server" Text="Wilderness" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="NewVarrockBtn" CssClass="btn btn-dark" runat="server" Text="New Varrock" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="WushankoArcBtn" CssClass="btn btn-light" runat="server" Text="Wushanko: The Arc" OnClick="SubcategoriesBtn_Click" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="card text-center">
                                    <div class="card-header" id="aCombat">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseCombat" aria-expanded="true" aria-controls="collapseCombat">
                                            <h4 class="text-center text-uppercase">Combat
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseCombat" aria-labelledby="aCombat" data-parent="#categories">
                                        <asp:UpdatePanel ID="CombatUpdatePanel" runat="server">
                                            <ContentTemplate>
                                                <div class="btn-group-vertical btn-group-sm btn-block">
                                                    <asp:Button ID="Combat" CssClass="btn btn-light" runat="server" Text="All" OnClick="CategoriesBtn_Click" />
                                                    <asp:Button ID="SoloPvMBtn" CssClass="btn btn-dark" runat="server" Text="Solo PvM" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="GroupPvMBtn" CssClass="btn btn-light" runat="server" Text="Group PvM" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="BossPetsBtn" CssClass="btn btn-dark" runat="server" Text="Boss Pets" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="BossKillsBtn" CssClass="btn btn-light" runat="server" Text="Boss Kills" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="RaidsBtn" CssClass="btn btn-dark" runat="server" Text="Raids" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="EliteDungeonsBtn" CssClass="btn btn-light" runat="server" Text="Elite Dungeons" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="GeneralBtn" CssClass="btn btn-dark" runat="server" Text="General" OnClick="SubcategoriesBtn_Click" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="card text-center">
                                    <div class="card-header" id="aMinigames">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseMinigames" aria-expanded="true" aria-controls="collapseMinigames">
                                            <h4 class="text-center text-uppercase">Minigames
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseMinigames" aria-labelledby="aMinigames" data-parent="#categories">
                                        <asp:UpdatePanel ID="MinigamesUpdatePanel" runat="server">
                                            <ContentTemplate>
                                                <div class="btn-group-vertical btn-group-sm btn-block">
                                                    <asp:Button ID="Minigames" CssClass="btn btn-light" runat="server" Text="All" OnClick="CategoriesBtn_Click" />
                                                    <asp:Button ID="TreasureTrailsBtn" CssClass="btn btn-dark" runat="server" Text="Treasure Trails" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="PoPBtn" CssClass="btn btn-light" runat="server" Text="Player-Owned Port" OnClick="SubcategoriesBtn_Click" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="card text-center">
                                    <div class="card-header" id="aMiscellaneous">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseMiscellaneous" aria-expanded="true" aria-controls="collapseMiscellaneous">
                                            <h4 class="text-center text-uppercase">Miscellaneous
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseMiscellaneous" aria-labelledby="aMiscellaneous" data-parent="#categories">
                                        <asp:UpdatePanel ID="ClansUpdatePanel" runat="server">
                                            <ContentTemplate>
                                                <div class="btn-group-vertical btn-group-sm btn-block">
                                                    <asp:Button ID="Miscellaneous" CssClass="btn btn-light" runat="server" Text="All" OnClick="CategoriesBtn_Click" />
                                                    <asp:Button ID="ClansBtn" CssClass="btn btn-dark" runat="server" Text="Clans" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="FeatsBtn" CssClass="btn btn-dark" runat="server" Text="Feats" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="MiniquestsBtn" CssClass="btn btn-light" runat="server" Text="Miniquests" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="ReputationBtn" CssClass="btn btn-dark" runat="server" Text="Reputation" OnClick="SubcategoriesBtn_Click" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="card text-center">
                                    <div class="card-header" id="aCompletionist">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseCompletionist" aria-expanded="true" aria-controls="collapseCompletionist">
                                            <h4 class="text-center text-uppercase">Completionist
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseCompletionist" aria-labelledby="aCompletionist" data-parent="#categories">
                                        <asp:UpdatePanel ID="CompletionistUpdatePanel" runat="server">
                                            <ContentTemplate>
                                                <div class="btn-group-vertical btn-group-sm btn-block">
                                                    <asp:Button ID="Completionist" CssClass="btn btn-light" runat="server" Text="All" OnClick="CategoriesBtn_Click" />
                                                    <asp:Button ID="CompBtn" CssClass="btn btn-dark" runat="server" Text="Completionist Cape" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="TrimmedCompBtn" CssClass="btn btn-light" runat="server" Text="Trimmed Completionist Cape" OnClick="SubcategoriesBtn_Click" />
                                                    <asp:Button ID="MQCBtn" CssClass="btn btn-dark" runat="server" Text="Master Quest Cape" OnClick="SubcategoriesBtn_Click" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <asp:UpdatePanel ID="AchievementsUpdatePanel" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Skills" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="Exploration" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:Repeater ID="AchievementsRepeater" runat="server"
                                        OnItemDataBound="AchievementsRepeater_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-sm-1">
                                                    <asp:Label ID="RuScLbl" runat="server" Text='<%# Eval("AchRunescore") %>'></asp:Label>
                                                </div>
                                                <div class="col">
                                                    <asp:Label ID="NameLbl" runat="server" Text='<%# Eval("AchName") %>'></asp:Label>
                                                    <br />
                                                    <asp:Label ID="DescLbl" runat="server" Text='<%# Eval("AchDescription") %>'></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <asp:Repeater ID="AchQuestReqRepeater" runat="server">
                                                        <ItemTemplate>
                                                            <asp:Label ID="AchQuestReqLbl" runat="server" Text='<%# Eval("Quest") %>'></asp:Label>
                                                            <asp:CheckBox ID="QuestReqChk" runat="server" Enabled="false" Checked='<%# Eval("CanComplete") %>'/>
                                                            <br />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <div class="col">
                                                    <asp:Repeater ID="AchSkillReqRepeater" runat="server">
                                                        <ItemTemplate>
                                                            <asp:Label ID="AchSkillReqLbl" runat="server" Text='<%# Eval("LevelSkill") %>'></asp:Label>
                                                            <asp:CheckBox ID="SkillReqChk" runat="server" Enabled="false" Checked='<%# Eval("CanComplete") %>'/>
                                                            <br />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                        <SeparatorTemplate>
                                            <p>----</p>
                                        </SeparatorTemplate>
                                    </asp:Repeater>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
