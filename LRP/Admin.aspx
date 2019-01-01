<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="AddUser" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        <br />
        &nbsp;
        <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
        &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Remove User" /><br />
        <br />
        <br />
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Whoose"></asp:Label>
        &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label3" runat="server" Text="Whome"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button3" runat="server" Text="Assign" OnClick="Button3_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="Button4" runat="server" Text="Remove" OnClick="Button4_Click" />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
        <br />
        &nbsp;<br />
        <asp:Button ID="Button5" runat="server" Text="GetTransaction" OnClick="Button5_Click" />
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="Button6" runat="server" Text="Reverse" OnClick="Button6_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label4" runat="server" Text="User"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
