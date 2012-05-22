<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.UserViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    用户管理
</asp:Content>
<%@ Import Namespace="Mis.Core.Model" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function initUserPassword(userId) {

        $.ajax({
            url: '<%:Url.Action("InitUserPassword") %>',
            type: "post",
            data: "userId=" + userId,
            datatype: "json",
            success: function (msg) {
                alert(msg);
            },
            error: function (err) { alert(err); }
        });

    }
</script>
    <%var premission = ViewData["UserPremission"] as ResourceCacheModel; %>
    <table>
        <thead>
            <tr>
                <th>
                    用户名
                </th>
                <th>
                    角色名
                </th>
                <th>
                    操作
                </th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <td colspan="3">
                    <%if (premission.CanAdd)
                      { %>
                    <%:Html.ActionLink("添加", "Add", null, new {@class = "button"})%>
                    <% } %>
                </td>
            </tr>
        </tfoot>
        <tbody>
            <% foreach (UserViewModel user in (IEnumerable<UserViewModel>)ViewData["UserList"])
               {
            %>
            <tr>
                <td>
                    <%:user.UserName %>
                </td>
                <td>
                    <%
                        string roleNames = "";
                        foreach (string roleName in user.RoleNames)
                        {
                            roleNames += roleName + "，";
                        }
                        roleNames=roleNames.Remove(roleNames.Length - 1, 1);
                    %>
                    <%:roleNames %>
                </td>
                <td>
                    <%
                        if (premission.CanEdit)
                        {
                    %>
                    <%:Html.ActionLink("编辑","Edit",new{id=user.UserId}) %>
                    <%
                        }
                    %>
                    &nbsp;&nbsp;
                    <%
                        if (premission.CanDel)
                        {
                    %>
                    <%:Html.ActionLink("删除","Del",new{userId=user.UserId}) %>
                    <%
                        }
                    %>
                    &nbsp;&nbsp;
                    <a href="javascript:initUserPassword(<%:user.UserId %>);">初始化密码</a>
                </td>
            </tr>
            <%
                } %>
        </tbody>
    </table>
</asp:Content>
