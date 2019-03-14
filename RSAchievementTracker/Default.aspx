<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RSAchievementTracker.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RS Achievement Tracker</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid">
        <form id="form1" runat="server">
            <div class="row">
                <div class="input-group mb-3 col-sm-4">
                    <asp:TextBox ID="userNameTB" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="trackBtn" CssClass="btn btn-light" runat="server" OnClick="trackBtn_Click" Text="Track" />
                </div>
            </div>
            </div>
            
            <div class="row">
                <div class="col-4">
                    <h2>Stats</h2>
                    <asp:Label ID="userStatsLbl" runat="server"></asp:Label>
                    <asp:GridView ID="statsGridView" CssClass="table table-sm table-striped" UseAccessibleHeader="true" runat="server">
                    </asp:GridView>
                </div>
                <div class="col-8">
                    <h2>Quests</h2>
                    <asp:Label ID="userQuestsLbl" runat="server"></asp:Label>
                    <asp:GridView ID="questsGridView" CssClass="table table-sm table-striped" UseAccessibleHeader="true" runat="server">
                    </asp:GridView>
                </div>
            </div>
            
            
        </form>
    </div>
</body>
</html>
