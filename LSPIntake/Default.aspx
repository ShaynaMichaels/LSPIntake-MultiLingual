<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LSPIntake.redirecter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblDebugtext" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="gvAuthInfo" runat="server" AutoGenerateColumns="False" DataSourceID="datasrcAuthorization">
            <Columns>
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="RandomId" HeaderText="RandomId" SortExpression="RandomId" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="datasrcAuthorization" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="SELECT [email], [RandomId] FROM [Auth0Claims] WHERE ([nameidentifier] = @nameidentifier)">
            <SelectParameters>
                <asp:QueryStringParameter Name="nameidentifier" QueryStringField="nameidentifier" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
