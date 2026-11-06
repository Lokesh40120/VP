```aspx
<%@ Page Language="VB" %>

<script runat="server">

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Label1.Text = "Hello " & TextBox1.Text
    End Sub

</script>

<form id="form1" runat="server">

<div style="text-align:center; margin-top:50px;
            background-color:#FF00FF; padding:20px;">

    <table border="1" cellpadding="10" cellspacing="0"
           style="margin:auto; width:700px;
                  background-color:#4cff00;">

        <!-- Heading -->
        <tr>
            <td colspan="2">
                <h2>2400040029 - ASP.NET Web Forms Controls</h2>
            </td>
        </tr>

        <!-- Table Heading -->
        <tr>
            <th>Property Name</th>
            <th>Control</th>
        </tr>

        <!-- Label -->
        <tr>
            <td>Label</td>
            <td>
                <asp:Label ID="Label1"
                    runat="server"
                    Text="40120-Lokesh"></asp:Label>
            </td>
        </tr>

        <!-- TextBox -->
        <tr>
            <td>Text Box     <td>Text Box</td>
            <td>
                <asp:TextBox ID="TextBox1"
                    runat="server">
                    Hi
                </asp:TextBox>
            </td>
        </tr>

        <!-- Button -->
        <tr>
            <td>Button</td>
            <td>
                <asp:Button ID="Button1"
                    runat="server"
                    Text="Button"
                    OnClick="Button1_Click" />
            </td>
        </tr>

        <!-- HyperLink -->
        <tr>
            <td>HyperLink</td>
            <td>
                <asp:HyperLink ID="HyperLink1"
                    runat="server"
                    NavigateUrl="https://www.youtube.com/">
                    YouTube
                </asp:HyperLink>

                <br />

                <asp:HyperLink ID="HyperLink2"
                    runat="server"
                    NavigateUrl="~/Default.aspx">
                    ASP Tutorial
                </asp:HyperLink>
            </td>
        </tr>

        <!-- DropDownList -->
        <tr>DropDownList</td>
            <td>
                <asp:DropDownList ID="DropDownList1"
                    runat="server">

                    <asp:ListItem>40120</asp:ListItem>
                    <asp:ListItem>40133</asp:ListItem>
                    <asp:ListItem>40155</asp:ListItem>

                </asp:DropDownList>
            </td>
        </tr>

        <!-- CheckBox -->
        <tr>
            <td>CheckBox     <td>CheckBox</td>
            <td>
                <asp:CheckBox ID="CheckBox1"
                    runat="server"
                    Text="I Agree" />
            </td>
        </tr>

        <!-- RadioButton -->
        <tr>
            <td>RadioButton</td>
            <td>
                <asp:RadioButton ID="RadioButton1"
                    runat="server"
                    GroupName="Gender"
                    Text="Male" />

                <asp:RadioButton ID="RadioButton2"
                    runat="server"
                    GroupName="Gender"
                    Text="Female" />
            </td>
        </tr>

        <!-- ListBox -->
        <tr>ListBox</td>
            <td>
                <asp:ListBox ID="ListBox1"
                    runat="server">

                    <asp:ListItem>AVD</asp:ListItem>
                    <asp:ListItem>ISDA</asp:ListItem>
                    <asp:ListItem>DTSP</asp:ListItem>
                    <asp:ListItem>VP</asp:ListItem>

                </asp:ListBox>
            </td>
        </tr>

        <!-- Calendar -->
        <tr>
            <td>Calendarr     <td>Calendar</td>
            <td>
                <asp:Calendar ID="Calendar1"
                    runat="server">
                </asp:Calendar>
            </td>
        </tr>

        <!-- FileUpload -->
        <tr>
            <td>FileUpload</td>
            <td>
                <asp:FileUpload ID="FileUpload1"
                    runat="server" />
            </td>
        </tr>

        <!-- Image -->
        <tr>
            <td>Image</td>
            <td>
                <asp:Image ID="Image1"
                    runat="server"
                    ImageUrl="~/image.jpg"
                    Width="100px" />
            </td>
        </tr>

    </table>

</div>

</form>
```