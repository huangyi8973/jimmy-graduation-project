<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.UserViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    修改用户
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm())
      { %>
    <%:Html.HiddenFor(m=>m.UserId) %><%:Html.HiddenFor(m=>m.UserToRoleId) %>
    <p>
        <label>
            用户名</label>
        <%:Model.UserName%>
    </p>
    <p>
        <label>
            角色(请按住Ctrl键进行多选)</label>
        <%:Html.ListBoxFor(m => m.RoleIds, new SelectList(ViewData["RoleList"] as IEnumerable<SelectListItem>, "Value", "Text"))%>
    </p>
    <p>
        <input type="submit" value="保存" /></p>
    <%} %>
    <p>
        <%: Html.ActionLink("返回列表", "Index") %>
    </p>
</asp:Content>
