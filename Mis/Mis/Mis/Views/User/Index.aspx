<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.UserViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    用户管理
</asp:Content>
<%@ Import Namespace="Mis.Core.Model" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                    <%:user.RoleName %>
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
                </td>
            </tr>
            <%
                } %>
        </tbody>
    </table>
</asp:Content>
