<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Entity.RoleEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加角色
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {%>
    <p>
        <label>
            角色名</label>
        <%: Html.TextBoxFor(model => model.RoleName) %>
    </p>
    <p>
        <input type="submit" value="添加" />
    </p>
    <% } %>
    <p>
        <%: Html.ActionLink("返回列表", "Index") %>
     </p>


</asp:Content>
