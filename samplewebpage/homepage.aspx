<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="samplewebpage.homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div style="text-align:center; margin-top:50px;background-color:#FF00FF">

        <table border="1" cellpadding="10" cellspacing="0"
               style="margin:auto; width:600px;background-color:#4cff00">

           
            <tr>
                <td colspan="2">
                    <h2>2400040120 - ASP.NET Web Forms Controls</h2>
                </td>
            </tr>
 	    <tr>
                <td>
                    Item
                </td>
		<td>
                    Control
                </td>
            </tr>
             	    <tr>
                <td>
                   
                    sessionhomepage</td>
		<td>
                    
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Session.aspx">session</asp:HyperLink>
                    
                </td>
            </tr>
             	    <tr>
                <td>
                    
                </td>
		<td>
                    
                </td>
            </tr>
        <tr>
            <td>Label</td>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="2400040120-Lokesh"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Text Box </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server">Visual Programming</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Button
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Click Me" OnClick="Button1_Click" />
            &nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td>Hyperlink
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://www.google.com/">Google</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Default.aspx">ASP Tutorial</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>Drop Down
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>VP</asp:ListItem>
                    <asp:ListItem>AVD</asp:ListItem>
                    <asp:ListItem>DTSP</asp:ListItem>
                    <asp:ListItem>OOPs</asp:ListItem>
                </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>Faluda</asp:ListItem>
                    <asp:ListItem>Samosa</asp:ListItem>
                    <asp:ListItem>Pani Puri</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Check Box
            </td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="VP" />
&nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Text="DTSP" />
                <asp:CheckBox ID="CheckBox3" runat="server" Text="OOPs" />
            </td>
        </tr>
        <tr>
            <td>
                Radio Button
            </td>
            <td>
                <asp:RadioButton ID="RadioButton1" runat="server" Text="UG" GroupName ="Academic" />
&nbsp;
                <asp:RadioButton ID="RadioButton2" runat="server" Text="PG" GroupName ="Academic" />
            </td>
        </tr>
        <tr>
            <td>
                 Image Control
            </td>
            <td>
                <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl="https://tse1.mm.bing.net/th/id/OIP.YTrPGd0QFrb8VSZAJgsKCgHaHa?r=0&amp;pid=Api&amp;h=220&amp;P=0" Width="275px" />
            </td>
        </tr>
        <tr>
            <td>
                Calender Control
            </td>
            <td>
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
                Response
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Fetch Value" OnClick="Button2_Click" />
                <br /><br />

                <asp:Label ID="Label2" runat="server"
                    Font-Bold="True">
                </asp:Label>
            </td>
        </tr>
    </table>
     </div>
</form>
</body>
</html>
