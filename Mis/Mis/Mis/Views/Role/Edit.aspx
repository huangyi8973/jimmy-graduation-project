<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.RoleViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    修改角色
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {%>
    <p>
        <label>
            角色ID</label>
        <%: Model.RoleId%>
        <%:Html.HiddenFor(m => m.RoleId)%>
    </p>
    <p>
        <label>
            角色名</label>
        <%: Html.TextBoxFor(model => model.RoleName) %>
    </p>
    <p>
        <input type="submit" value="保存" />
    </p>
    <% } %>
    <p>
        <%: Html.ActionLink("返回列表", "Index") %>
    </p>
</asp:Content>
