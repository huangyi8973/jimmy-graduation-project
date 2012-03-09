<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.NoticeViewModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    公告
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        <%:Model.Title %></h3>
    <p>
        <%:Model.UserName %>&nbsp;&nbsp;&nbsp;<%:Model.CreateTime %></p>
    <p>
        <%:Model.Content %></p>
                  <p>
        <%: Html.ActionLink("返回列表", "Index") %>
    </p>
</asp:Content>
