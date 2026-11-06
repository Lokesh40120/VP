<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sessionhome.aspx.cs" Inherits="sample.Sessionhome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to Session Home Page</h1>
            <table border="2">
                <tr>
                    <td>
                        User Name
                    </td>
                    <td>

                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                    </td>
                </tr>
                                <tr>
                    <td>

                        Role</td>
                    <td>

                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                    </td>
                </tr>
                                <tr>
                    <td>

                        Save session</td>
                    <td>

                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save session" Width="158px" />

                    </td>
                </tr>
                                <tr>
                    <td>

                        Clear Session</td>
                    <td>

                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Clear session" Width="158px" />

                    </td>
                                                    <tr>
                    <td>

                        Session Page</td>
                    <td>

                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Sessionpage1.aspx">Sessionpage1</asp:HyperLink>

                    </td>
                                                                        <tr>
                    <td>

                    </td>
                    <td>

                    </td>
                </tr>
                </tr>
                </tr>
                                                                        <tr>
    <td>

        Clear Name</td>
    <td>

        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" Width="152px" />

    </td>
</tr>
                                                           <tr>
    <td>

        Clear role</td>
    <td>

        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" Width="152px" />

    </td>
</tr>
            </table>
        </div>
    </form>
</body>
</html>