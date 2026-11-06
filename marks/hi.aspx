<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hi.aspx.cs" Inherits="marks.hi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <h1>  40120  </h1>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1">
                <tr>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" Height="37px" Width="325px" />
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Height="48px" Text="Upload" Width="180px" OnClick="Button1_Click" />
                    </td>
                </tr>
                 <tr>
                     <td>
                         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                     </td>
                     <td>
                         <asp:Image ID="Image1" runat="server" Height="254px" Width="340px" />
                     </td>
                 </tr>
            </table>
        </div>
    </form>
</body>
</html>
