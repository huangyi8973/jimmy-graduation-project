<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Error.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2 style="color: Red;">
            系统出错啦 T_T</h2>
        <p>
            <%:ViewData["ErrorMessage"] %></p>
    </div>
</asp:Content>
