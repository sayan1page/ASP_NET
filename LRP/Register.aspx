<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="User Name"></asp:Label>
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Password"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="City"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="State"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Role: ( Pls Select)"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem>Merchant</asp:ListItem>
            <asp:ListItem>Consumer</asp:ListItem>
            <asp:ListItem>Candidate</asp:ListItem>
        </asp:CheckBoxList></div>
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />&nbsp;
    </form>
</body>
</html>
