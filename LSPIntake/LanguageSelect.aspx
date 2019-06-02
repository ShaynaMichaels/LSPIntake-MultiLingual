<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LanguageSelect.aspx.cs" Inherits="LSPIntake.LanguageSelect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--DataTextField = what the user sees, DataValueField - what developer uses--%>
    <asp:RadioButtonList CssClass="LanguageSelectButtons" ID="rblLanguageSelect" runat="server" DataSourceID="datasrcLanguageSelect" DataTextField="LanguageDisplayName" DataValueField="Id" OnSelectedIndexChanged="rblLanguageSelect_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" align="center"></asp:RadioButtonList>

    <asp:Label ID="lblDebug" runat="server" Text="Label" Visible="false"></asp:Label>

    <asp:SqlDataSource ID="datasrcLanguageSelect" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="SELECT Id,LanguageDisplayName FROM Languages where id <> 5"></asp:SqlDataSource>


</asp:Content>
