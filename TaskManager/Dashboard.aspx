<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TaskManager.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Dashboard</h1>
            <h1>CRUD Operations</h1>
        </div>
        <asp:Button ID="Button1" runat="server" Height="33px" OnClick="Button1_Click" Text="Get All Students" Width="167px" />
        <asp:TextBox ID="TextBox1" runat="server" style="margin-top: 0px" Width="98px"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Height="33px" OnClick="Button2_Click" Text="Get Student Details by ID" Width="191px" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
