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
                        <asp:Button ID="TrackBtn" CssClass="btn btn-light" runat="server" OnClick="TrackBtn_Click" Text="Track" />
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:Label ID="UsernameLbl" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="WebErrorLbl" runat="server" Text=""></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
