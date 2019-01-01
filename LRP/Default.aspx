<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[


// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: olive">
        &nbsp;
        &nbsp;<img src="http://localhost/FairFest/Fairfest/Fairfest/images/fairfestLogo.gif" alt="Fairfest Logo" /><br />
        <br />
        <asp:Label ID="Label_logIn" runat="server" Font-Bold="True" Font-Size="Larger" Font-Strikeout="False"
            Text="LogIn"></asp:Label>
        &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label_psw" runat="server" Font-Bold="True" Font-Size="Larger" Font-Strikeout="False"
            Text="Password"></asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp;
        <asp:Button ID="Button_register" runat="server" Font-Bold="True" OnClick="Button2_Click"
            Text="Register" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button
            ID="Button_OK" runat="server" Font-Bold="True" OnClick="Button_OK_Click" Text="OK" /><br />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
