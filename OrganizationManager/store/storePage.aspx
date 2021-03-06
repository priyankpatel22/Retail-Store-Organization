﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="storePage.aspx.cs" Inherits="OrganizationManager.storePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: xx-large;
            color: #FFFFFF;
            background-color: #391878;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            color: #FF3300;
            font-weight: 700;
            text-align: center;
        }
        .auto-style5 {
            width: 222px;
        }
        .auto-style6 {
            width: 222px;
            text-align: right;
        }
        .auto-style7 {
            text-align: center;
            width: 486px;
        }
        .auto-style8 {
            color: #FF3300;
        }
        .auto-style9 {
            width: 230px;
        }
        .auto-style10 {
            width: 230px;
            text-align: right;
        }
        .auto-style11 {
            text-align: center;
            color: #FF3300;
        }
        .auto-style12 {
            text-align: left;
        }
        .auto-style13 {
            width: 230px;
            text-align: right;
            color: #000066;
        }
        .auto-style15 {
            width: 225px;
            text-align: right;
        }
        .auto-style17 {
            width: 354px;
            text-align: right;
            color: #000066;
        }
        .auto-style19 {
            text-align: right;
            width: 252px;
        }
        .auto-style21 {
            text-align: right;
            width: 252px;
            color: #391878;
        }
        .auto-style22 {
            text-align: left;
            width: 243px;
        }
        .auto-style24 {
            width: 354px;
            text-align: right;
        }
        .auto-style25 {
            font-size: large;
        }
        .auto-style27 {
            width: 239px;
            text-align: right;
        }
        .auto-style28 {
            font-size: medium;
        }
    </style>
</head>


<body style="color: #000066">
 <form id="form2" runat="server">
    
    <div class="auto-style1">
    
        <strong>Welcome to Store Utility</strong></div>
    <p>
        &nbsp;</p>
    <p class="auto-style8">
        <span class="auto-style25"><strong>Welcome:</strong> 
        </span> 
        <asp:Label ID="loginNameDisplay" runat="server" CssClass="auto-style25"></asp:Label>
    </p>
        <p class="auto-style8">
            <span class="auto-style25"><strong>Location:</strong>
            </span>
            <asp:Label ID="personLocation" runat="server" CssClass="auto-style25"></asp:Label>
    </p>
      
     <br />
     <asp:Button ID="Button1" runat="server" OnClick="addProductPop_Click1" Text="Add New Item" Width="145px" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" style="font-weight: 700" CssClass="auto-style28" />
      
     &nbsp;<asp:Button ID="Button2" runat="server" Text="In-Stock Items" Width="127px" OnClick="Button2_Click" BackColor="White" BorderColor="White" BorderStyle="None" style="font-weight: 700; color: #391878" CssClass="auto-style28" />
      
     &nbsp;<asp:Button ID="Button18" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" OnClick="Button18_Click" style="font-weight: 700" Text="Add Inventory" Width="147px" CssClass="auto-style28" />
&nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Remove Product" Width="150px" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" style="font-weight: 700" CssClass="auto-style28" />
      
     <span class="auto-style28">&nbsp;
     </span>
     <asp:Button ID="Button5" runat="server" Text="Add Employee" Width="151px" OnClick="Button5_Click" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" style="font-weight: 700" CssClass="auto-style28" />
      
     <span class="auto-style28">&nbsp;
     </span>
     <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Remove Employee" Width="150px" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" style="font-weight: 700" CssClass="auto-style28" />
      
     <span class="auto-style28">&nbsp;
     </span>
     <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Search Item" Width="119px" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" style="font-weight: 700" CssClass="auto-style28" />
      
     <span class="auto-style28">&nbsp;&nbsp;</span><asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Employee Details" Width="150px" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" style="font-weight: 700" CssClass="auto-style28" />
      
     <span class="auto-style28">&nbsp;&nbsp;</span><asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="Change Price" Width="141px" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" style="font-weight: 700" CssClass="auto-style28" />
      
     &nbsp;<asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="Check Sales" Width="130px" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" style="font-weight: 700" CssClass="auto-style28" />
      
     <span class="auto-style28">&nbsp;&nbsp;
      
     </span>
      
     <asp:Button ID="Button17" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#391878" OnClick="Button17_Click" style="font-weight: 700" Text="Payroll" CssClass="auto-style28" />
      
     <br />
     <br />
     <br />
     <asp:Panel ID="Panel1" runat="server" style="margin: auto" Width="487px" Visible="false">
         <div class="auto-style7">
             <span class="auto-style3"><strong>Add New Product<br /> </strong></span><br />
         </div>
         <table class="auto-style2">
             <tr>
                 <td class="auto-style6">Product ID:</td>
                 <td>
                     <asp:TextBox ID="pId" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style6">Product Name:</td>
                 <td>
                     <asp:TextBox ID="pName" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style6">Price:</td>
                 <td>
                     <asp:TextBox ID="price" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style5">&nbsp;</td>
                 <td>
                     <asp:Button ID="addProductButon" runat="server" Text="Add" OnClick="addProductButon_Click" />
                 </td>
             </tr>
         </table>
     </asp:Panel>
     <asp:Panel ID="Panel2" runat="server" style="margin :auto" Width="487px" Visible="false">
         <div class="auto-style7">
             <span class="auto-style3">Products In-Stock<br /> </span>
         </div>
     </asp:Panel>
     <br />
     <asp:Panel ID="Panel3" runat="server" style="margin:auto" Width="486px" Visible="false">
         <div class="auto-style7">
             <span class="auto-style8"><strong>Delete Product<br /> </strong></span><br />
             <table class="auto-style2">
                 <tr>
                     <td class="auto-style10">Select Product:</td>
                     <td style="text-align: left">
                         <asp:DropDownList ID="DropDownList1" runat="server" style="text-align: left">
                             <asp:ListItem>Product</asp:ListItem>
                         </asp:DropDownList>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style9">&nbsp;</td>
                     <td style="text-align: left">
                         <asp:Button ID="Button3" runat="server" Text="Remove Product" OnClick="Button3_Click" />
                     </td>
                 </tr>
             </table>
         </div>
     </asp:Panel>
     <br />
     <asp:Panel ID="Panel4" runat="server" style="margin:auto" Width="481px" Visible="false">
         <div class="auto-style11">
             <strong>Add Employee<br />
             <br />
             </strong>
             <table class="auto-style2">
                 <tr>
                     <td class="auto-style13">SSN:</td>
                     <td class="auto-style12">
                         <asp:TextBox ID="essn" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style13">First Name:</td>
                     <td class="auto-style12">
                         <asp:TextBox ID="efname" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style13">Last Name:</td>
                     <td class="auto-style12">
                         <asp:TextBox ID="elname" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style13">Gender:</td>
                     <td class="auto-style12">
                         <asp:DropDownList ID="egender" runat="server">
                             <asp:ListItem>Male</asp:ListItem>
                             <asp:ListItem>Female</asp:ListItem>
                         </asp:DropDownList>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style13">Title:</td>
                     <td class="auto-style12">
                         <asp:TextBox ID="etitle" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style13">Password:</td>
                     <td class="auto-style12">
                         <asp:TextBox ID="epass" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style13">Salary:</td>
                     <td class="auto-style12">
                         <asp:TextBox ID="esalary" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style13">&nbsp;</td>
                     <td class="auto-style12">
                         <asp:Button ID="addEmployeeButton" runat="server" Text="Add" Width="135px" OnClick="addEmployeeButton_Click" />
                     </td>
                 </tr>
             </table>
         </div>
     </asp:Panel>
     <br />
     <asp:Panel ID="Panel5" runat="server" style="margin:auto" Width="475px" Visible="false">
         <div class="auto-style7">
             <span class="auto-style8"><strong>Remove Employee<br />
             <br />
             </strong>
             </span>
             <table class="auto-style2">
                 <tr>
                     <td class="auto-style15">Employee Name:</td>
                     <span class="auto-style8">
                     <td style="text-align: left">
                         <asp:DropDownList ID="DropDownList2" runat="server">
                             <asp:ListItem>Name</asp:ListItem>
                         </asp:DropDownList>
                     </td>
                     </span>
                 </tr>
                 <tr>
                     <td class="auto-style15">&nbsp;</td>
                     <td style="text-align: left">
                         <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Remove" />
                     </td>
                 </tr>
             </table>
             
         </div>
     </asp:Panel>
     <br />
     <asp:Panel ID="Panel6" runat="server" style="margin:auto" Width="470px" Visible="false">
         <div class="auto-style7">
             <span class="auto-style8"><strong>Search Item</strong></span><br />
             <br />
         </div>
         <table class="auto-style2">
             <tr>
                 <td class="auto-style6">Item Name:</td>
                 <td>
                     <asp:TextBox ID="prodSearchBox" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style6">&nbsp;</td>
                 <td>
                     <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Search" />
                 </td>
             </tr>
         </table>
         <br />
     </asp:Panel>
     <br />
     <asp:Panel ID="Panel7" runat="server" style="margin:auto" Width="700px" Visible="false">
         <div class="auto-style11">
             <strong>Employee Details<br />
             <br />
             </strong>
             <table class="auto-style2">
                 <tr>
                     <td class="auto-style17">Employee Name:</td>
                     <td class="auto-style12">
                         <asp:TextBox ID="nameSearchBox" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style24">&nbsp;</td>
                     <td class="auto-style12">
                         <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Search" />
                     </td>
                 </tr>
             </table>
         </div>
     </asp:Panel>
     <br />
     <asp:Panel ID="Panel8" runat="server" style="margin:auto" Width="476px" Visible ="false">
         <div class="auto-style11">
             <strong>Change Product Price<br />
             </strong>
             <table class="auto-style2">
                 <tr>
                     <td class="auto-style21">Select Product: </td>
                     <strong>
                     <td class="auto-style22">
                         <asp:DropDownList ID="priceListToUpdate" runat="server">
                         </asp:DropDownList>
                     </td>
                     </strong>
                 </tr>
                 <tr>
                     <td class="auto-style21">Enter New Price: </td>
                     <td class="auto-style22">
                         <asp:TextBox ID="newPrice" runat="server" Width="121px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style19">&nbsp;</td>
                     <td class="auto-style22">
                         <asp:Button ID="updatePrice" runat="server" OnClick="updatePrice_Click" Text="Update" />
                     </td>
                 </tr>
             </table>
             <br />
             <br />
             </strong>
         </div>
     </asp:Panel>
     <br />
     <asp:Panel ID="Panel9" runat="server" style="margin:auto" Width="476px" Visible="false">
         <div class="auto-style7">
             <span class="auto-style8"><strong>Check Sales Information<br />
             <br style="color: #000000" />
             </strong>
             <asp:Button ID="Button14" runat="server" OnClick="Button14_Click" Text="Today" Width="116px" />
             &nbsp;&nbsp;&nbsp; </span>
             <asp:Button ID="Button15" runat="server" OnClick="Button15_Click" Text="Last Week" />
             &nbsp;&nbsp;&nbsp;
             <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="Last Month" />
         </div>
     </asp:Panel>
     <br />
     <asp:Panel ID="Panel10" runat="server" style="margin:auto" Width="482px" Visible ="false">
         <div class="auto-style11">
             <strong>Total Payroll of this month<br />
             <br />
             </strong>
             <asp:Label ID="Label1" runat="server" style="color: #391878" Visible="false"></asp:Label>
             <br />
             <br />
         </div>
     </asp:Panel>
     <br />
     <asp:Panel ID="Panel11" runat="server" style="margin:auto" Width="480px" Visible="false">
         <div class="auto-style11">
             <strong>Add Inventory<br />
             <br />
             <table class="auto-style2">
                 <tr>
                     <td class="auto-style27">Product</td>
                     <td class="auto-style12">
                         <asp:DropDownList ID="productList" runat="server">
                         </asp:DropDownList>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style27">Counts: </td>
                     <td class="auto-style12">
                         <asp:TextBox ID="prodCount" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style27">&nbsp;</td>
                     <td class="auto-style12">
                         <asp:Button ID="addInventory" runat="server" Text="Add" OnClick="addInventory_Click" />
                     </td>
                 </tr>
             </table>
             <br />
             </strong>
         </div>
     </asp:Panel>
     <br />
     <br />
     <br />
      
    </form>
    </body>


</html>
