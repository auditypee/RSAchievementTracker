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
                <asp:GridView ID="achievementsGridView" CssClass="table table-sm table-striped" runat="server">

                </asp:GridView>
            </asp:View>
        </asp:MultiView>
    </form>
</div>
</body>
</html>
