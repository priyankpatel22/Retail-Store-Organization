<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OrganizationManager.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 782px;
        }
        .auto-style3 {
            font-size: xx-large;
            color: #391878;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            width: 782px;
            color: #FF3300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div class="auto-style4">
    
        <br />
            <strong><span class="auto-style3">Employee Login Page</span></strong><br />
            <br />
            <br />
            <br />
        <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        <br />
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style5" style="text-align: right">LoginId:</td>
                <td>
                    <asp:TextBox ID="loginname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" style="text-align: right">Password:</td>
                <td>
                    <asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Enter Correct User ID and PAssword" Visible="false"></asp:Label>
                    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
