<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RSAchievementTracker.Presentation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RS Achievement Tracker</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/achtracker.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="row">
                <div class="input-group mb-3 col-sm-4">
                    <asp:textbox id="userNameTB" cssclass="form-control" placeholder="Username" runat="server"></asp:textbox>
                    <div class="input-group-append">
                        <asp:button id="TrackBtn" cssclass="btn btn-light" runat="server" onclick="TrackBtn_Click" text="Track" />
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:label id="UsernameLbl" runat="server" text=""></asp:label>
                <br />
                <asp:label id="WebErrorLbl" runat="server" text=""></asp:label>
            </div>
        </form>
    </div>
</body>
</html>