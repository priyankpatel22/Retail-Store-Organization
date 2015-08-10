<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OrganizationManager.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            height: 91px;
            text-align: center;
            background-color: #391878;
        }
        .auto-style2 {
            font-size: x-large;
            background-color: #391878;
        }
        .auto-style3 {
            text-align: right;
            margin-top: 0px;
        }
        .auto-style4 {
            font-size: large;
        }
        .auto-style5 {
            font-size: x-large;
            font-family:'Brush Script MT';
        }
        #form1 {
            height: 838px;
        }
        .auto-style6 {
            width: 100%;
        }
        .auto-style9 {
            text-align: center;
        }
        .auto-style10 {
            color: #391878;
            font-size: large;
        }
        .auto-style11 {
            width: 391px;
            text-align: right;
        }
        .auto-style14 {
            text-align: center;
            color: #391878;
            font-size: large;
        }
        .auto-style15 {
            width: 381px;
            text-align: right;
            font-size: medium;
        }
        .auto-style16 {
            width: 136px;
        }
        .auto-style17 {
            color: #391878;
        }
        .auto-style18 {
            width: 1106px;
            height: 400px;
        }
    </style>
</head>
<body style="height: 854px">
    <form id="form1" runat="server">
    <div style="height: 101px">
    
        <asp:Panel ID="Panel1" runat="server" Height="92px">
            <div class="auto-style1">
                <br />
                <strong><span class="auto-style2">Welcome to Super Retail Stores</span></strong>
                <br />
                <span class =auto-style5>An Online Super Market</span> 
            </div>
        </asp:Panel>
    
    </div>
        <asp:Panel ID="Panel2" runat="server" Height="50px" style="margin-top: 10px">
            <div class="auto-style3">
                <br />
                <strong><a href="Login.aspx"><span class="auto-style4">Employee Login</span>
                </a></strong></div>
        </asp:Panel>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img alt="hv" class="auto-style18" src="234190572_13.jpg" /><br />
        <br />
        </br>
        <asp:Panel ID="Panel3" runat="server" style="margin-top: 40px; margin:auto;" Width="791px">
            <div class="auto-style9">
                <span class="auto-style10"><strong>Choose a nearest store to you..</strong></span><br class="auto-style4" />
            </div>
            
            
            <br />
            <table class="auto-style6">
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label1" runat="server" Text="Choose Your State:" CssClass="auto-style17"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label2" runat="server" Text="Choose Your County:" Visible ="false" CssClass="auto-style17"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:DropDownList ID="DropDownList2" runat="server" Visible="false">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Submit" Visible ="false" OnClick="Button2_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label3" runat="server" Text="Choose Your Region:" Visible ="false" CssClass="auto-style17"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:DropDownList ID="DropDownList3" runat="server" Visible ="false">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Submit" Visible ="false" OnClick="Button3_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label4" runat="server" Text="Choose Nearest Store:" Visible ="false" CssClass="auto-style17"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:DropDownList ID="DropDownList4" runat="server" Visible="false">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style16">
                        <asp:Button ID="Button5" runat="server" Text="Start Shopping" Width="125px" Visible ="false" OnClick="Button5_Click"/>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
                </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" Visible="false" style="margin:auto" Width="790px">
            <div class="auto-style14">
                <strong>Select a product you want to buy..<br />
                <br />
                </strong>
                <table class="auto-style6">
                    <tr>
                        <td class="auto-style15">Product:&nbsp; </td>
                        <strong>
                        <td style="text-align: left">
                            <asp:DropDownList ID="productList" runat="server">
                            </asp:DropDownList>
                        </td>
                        </strong>
                    </tr>
                    <tr>
                        <td class="auto-style15">Quantity: </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox1" runat="server" Width="110px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Buy" />
                        </td>
                    </tr>
                </table>
                <br />
                </strong>&nbsp;
                <br />
                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="No products available at the store.." Visible="false"></asp:Label>
                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="Label" Visible="false"></asp:Label>
                <br />
                <br />
                <asp:Panel ID="Panel5" runat="server">
                    <asp:Label ID="Label7" runat="server" style="font-weight: 700" Visible="false" Text="Your Cart"></asp:Label>
                    <br />
                    <br />
                    <br />
                </asp:Panel>
                <asp:Button ID="Button7" runat="server" OnClick="Button7_Click1" Text="Checkout" Visible="false" />
                <br />
                <br />
            </div>
            </asp:Panel>
    </form>
</body>
</html>
