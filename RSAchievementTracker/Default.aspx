<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RSAchievementTracker.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RS Achievement Tracker</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="row">
                <div class="input-group mb-3 col-sm-4">
                    <asp:TextBox ID="userNameTB" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="trackBtn" CssClass="btn btn-light" runat="server" OnClick="trackBtn_Click" Text="Track" />
                    </div>
                </div>
            </div>
            <asp:MultiView ID="MultiView" runat="server">
                <asp:View ID="InitialView" runat="server">
                    <div class="row">
                        <asp:Button ID="ShowStats" CssClass="btn btn-primary" runat="server" Text="Show Stats" OnClick="ShowStats_Click" />
                        <asp:Button ID="ShowQuests" CssClass="btn btn-primary" runat="server" Text="Show Quests" OnClick="ShowQuests_Click" />
                        <asp:Button ID="ShowAchievements" CssClass="btn btn-primary" runat="server" Text="Show Achievements" OnClick="ShowAchievements_Click" />
                    </div>

                </asp:View>
                <asp:View ID="StatsView" runat="server">
                    <h2>Stats</h2>
                    <div class="row">
                        <asp:Button ID="ShowQuestsFromStats" CssClass="btn btn-primary" runat="server" Text="Show Quests" OnClick="ShowQuests_Click" />
                        <asp:Button ID="ShowAchievementsFromStats" CssClass="btn btn-primary" runat="server" Text="Show Achievements" OnClick="ShowAchievements_Click" />
                    </div>
                    <div class="row">
                        <asp:Label ID="userStatsLbl" runat="server"></asp:Label>
                    </div>
                    <asp:GridView ID="statsGridView" CssClass="table table-sm table-striped" UseAccessibleHeader="true" runat="server">
                    </asp:GridView>
                </asp:View>
                <asp:View ID="QuestsView" runat="server">
                    <h2>Quests</h2>
                    <div class="row">
                        <asp:Button ID="ShowStatsFromQuests" CssClass="btn btn-primary" runat="server" Text="Show Stats" OnClick="ShowStats_Click" />
                        <asp:Button ID="ShowAchievementsFromQuests" CssClass="btn btn-primary" runat="server" Text="Show Achievements" OnClick="ShowAchievements_Click" />
                    </div>
                    <div class="row">
                        <asp:Label ID="userQuestsLbl" runat="server"></asp:Label>
                    </div>
                    <asp:GridView ID="questsGridView" CssClass="table table-sm table-striped" UseAccessibleHeader="true" runat="server">
                    </asp:GridView>
                </asp:View>
                <asp:View ID="AchievementsView" runat="server">
                    <h2>Achievements</h2>
                    <div class="row">
                        <asp:Button ID="ShowStatsFromAchievements" CssClass="btn btn-primary" runat="server" Text="Show Stats" OnClick="ShowStats_Click" />
                        <asp:Button ID="ShowQuestsFromAchievements" CssClass="btn btn-primary" runat="server" Text="Show Quests" OnClick="ShowQuests_Click" />
                    </div>
                    <div class="row">
                        <asp:Label ID="achievementsLbl" runat="server"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <div class="accordion" id="categories">
                                <div class="card">
                                    <div class="card-header" id="aSkills">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseSkills" aria-expanded="true" aria-controls="collapseSkills">
                                            <h4 class="text-center text-uppercase">
                                                Skills
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseSkills" aria-labelledby="aSkills" data-parent="#categories">
                                        <div class="card-body btn-group-vertical btn-group-sm">
                                            <button class="btn btn-primary" type="button">Agility</button>
                                            <button class="btn btn-primary" type="button">Cooking</button>
                                            <button class="btn btn-primary" type="button">Construction</button>
                                            <button class="btn btn-primary" type="button">Crafting</button>
                                            <button class="btn btn-primary" type="button">Dungeoneering</button>
                                            <button class="btn btn-primary" type="button">Diviniation</button>
                                            <button class="btn btn-primary" type="button">Farming</button>
                                            <button class="btn btn-primary" type="button">Fishing</button>
                                            <button class="btn btn-primary" type="button">Firemaking</button>
                                            <button class="btn btn-primary" type="button">Fletching</button>
                                            <button class="btn btn-primary" type="button">Herblore</button>
                                            <button class="btn btn-primary" type="button">Hunter</button>
                                            <button class="btn btn-primary" type="button">Invention</button>
                                            <button class="btn btn-primary" type="button">Mining</button>
                                            <button class="btn btn-primary" type="button">Prayer</button>
                                            <button class="btn btn-primary" type="button">Runecrafting</button>
                                            <button class="btn btn-primary" type="button">Smithing</button>
                                            <button class="btn btn-primary" type="button">Summoning</button>
                                            <button class="btn btn-primary" type="button">Thieving</button>
                                            <button class="btn btn-primary" type="button">Woodcutting</button>
                                            <button class="btn btn-primary" type="button">Skilling Pets</button>
                                        </div>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header" id="aExploration">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseExploration" aria-expanded="true" aria-controls="collapseExploration">
                                            <h4 class="text-center text-uppercase">
                                                Exploration
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseExploration" aria-labelledby="aExploration" data-parent="#categories">
                                        <div class="card-body btn-group-vertical btn-group-sm">
                                            <button class="btn btn-primary" type="button">Ardougne</button>
                                            <button class="btn btn-primary" type="button">Desert</button>
                                            <button class="btn btn-primary" type="button">Daemonheim</button>
                                            <button class="btn btn-primary" type="button">Falador</button>
                                            <button class="btn btn-primary" type="button">Fremennik</button>
                                            <button class="btn btn-primary" type="button">Karamja</button>
                                            <button class="btn btn-primary" type="button">Lodestone</button>
                                            <button class="btn btn-primary" type="button">Lumbridge</button>
                                            <button class="btn btn-primary" type="button">Menaphos</button>
                                            <button class="btn btn-primary" type="button">Morytania</button>
                                            <button class="btn btn-primary" type="button">Seers' Village</button>
                                            <button class="btn btn-primary" type="button">Tirannwn</button>
                                            <button class="btn btn-primary" type="button">Varrock</button>
                                            <button class="btn btn-primary" type="button">Wilderness</button>
                                            <button class="btn btn-primary" type="button">New Varrock</button>
                                            <button class="btn btn-primary" type="button">Wushanko: The Arc</button>
                                        </div>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header" id="aCombat">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseCombat" aria-expanded="true" aria-controls="collapseCombat">
                                            <h4 class="text-center text-uppercase">
                                                Combat
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseCombat" aria-labelledby="aCombat" data-parent="#categories">
                                        <div class="card-body btn-group-vertical btn-group-sm">
                                            <button class="btn btn-primary" type="button">Solo PvM</button>
                                            <button class="btn btn-primary" type="button">Group PvM</button>
                                            <button class="btn btn-primary" type="button">Boss Pets</button>
                                            <button class="btn btn-primary" type="button">Boss Kills</button>
                                            <button class="btn btn-primary" type="button">Raids</button>
                                            <button class="btn btn-primary" type="button">Elite Dungeons</button>
                                            <button class="btn btn-primary" type="button">General</button>
                                        </div>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header" id="aMinigames">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseMinigames" aria-expanded="true" aria-controls="collapseMinigames">
                                            <h4 class="text-center text-uppercase">
                                                Minigames
                                            </h4>
                                        </a>
                                        <asp:Button ID="MinigamesButton" runat="server" Text="Button" OnClick="MinigamesButton_Click" />
                                    </div>
                                    <div class="collapse" id="collapseMinigames" aria-labelledby="aMinigames" data-parent="#categories">
                                        <div class="card-body btn-group-vertical btn-group-sm">
                                            <button class="btn btn-primary" type="button">Treasure Trails</button>
                                            <button class="btn btn-primary" type="button">Player-Owned Port</button>
                                        </div>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header" id="aMiscellaneous">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseMiscellaneous" aria-expanded="true" aria-controls="collapseMiscellaneous">
                                            <h4 class="text-center text-uppercase">
                                                Miscellaneous
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseMiscellaneous" aria-labelledby="aMiscellaneous" data-parent="#categories">
                                        <div class="card-body btn-group-vertical btn-group-sm">
                                            <button class="btn btn-primary" type="button">Clans</button>
                                            <button class="btn btn-primary" type="button">Feats</button>
                                            <button class="btn btn-primary" type="button">Miniquests</button>
                                            <button class="btn btn-primary" type="button">Reputation</button>
                                        </div>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header" id="aCompletionist">
                                        <a data-toggle="collapse" data-parent="#categories" href="#collapseCompletionist" aria-expanded="true" aria-controls="collapseCompletionist">
                                            <h4 class="text-center text-uppercase">
                                                Completionist
                                            </h4>
                                        </a>
                                    </div>
                                    <div class="collapse" id="collapseCompletionist" aria-labelledby="aCompletionist" data-parent="#categories">
                                        <div class="card-body btn-group-vertical btn-group-sm">
                                            <button class="btn btn-primary" type="button">Comp</button>
                                            <button class="btn btn-primary" type="button">Comp(T)</button>
                                            <button class="btn btn-primary" type="button">Quest(M)</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </div>
                        <div class="col-8">
                            <asp:GridView ID="achievementsGridView" CssClass="table table-sm table-striped" runat="server">
                            </asp:GridView>
                        </div>
                    </div>
            </asp:View>
        </asp:MultiView>
    </form>
</div>

    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
