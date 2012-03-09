<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" %>

<%@ Import Namespace="Mis.Core.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    角色管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%var premission = ViewData["UserPremission"] as ResourceCacheModel; %>
    <%var rrpremission = ViewData["RRPremission"] as ResourceCacheModel; %>
    <table>
        <thead>
            <tr>
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
                <td colspan="2">
                    <%if (premission.CanAdd)
                      { %>
                    <%:Html.ActionLink("添加", "Add", null, new {@class = "button"})%>
                    <% } %>
                </td>
            </tr>
        </tfoot>
        <tbody>
            <% foreach (var entity in (IEnumerable<RoleViewModel>)ViewData["RoleList"])
               {
            %>
            <tr>
                <td>
                    <%:entity.RoleName%>
                </td>
                <td>
                    <%
                        if (premission.CanEdit)
                        {
                    %>
                    <%:Html.ActionLink("编辑","Edit",new{id=entity.RoleId}) %>
                    <%
                        }
                    %>
                    &nbsp;&nbsp;
                    <%
                        if (premission.CanDel)
                        {
                    %>
                    <%:Html.ActionLink("删除", "Del", new { id = entity.RoleId })%>
                    <%
                        }
                    %>
                    &nbsp;&nbsp;
                    <%
                        if (rrpremission.CanView)
                        {
                    %>
                    <%:Html.ActionLink("权限","Index","Premission",new{roleId=entity.RoleId},null) %>
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
