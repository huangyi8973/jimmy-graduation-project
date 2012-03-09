<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="Mis.Core.Model" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    <%var role = ViewData["RoleInfo"] as RoleViewModel; %>
    角色资源配置（权限管理）--<%:role.RoleName %>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%var role = ViewData["RoleInfo"] as RoleViewModel; %>
    <%var premission = ViewData["UserPremission"] as ResourceCacheModel; %>
    <table>
        <thead>
            <tr>
                <th>
                    资源名称
                </th>
                <th>
                    权限值
                </th>
                <th>
                    列表
                </th>
                <th>
                    查看
                </th>
                <th>
                    添加
                </th>
                <th>
                    修改
                </th>
                <th>
                    删除
                </th>
                <th>
                    操作
                </th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <td colspan="7">
                <%if (premission.CanAdd)
                  {%>
                    <%:Html.ActionLink("添加", "Add", new {Id = role.RoleId}, new {@class = "button"})%>
                    <% } %>
                </td>
            </tr>
        </tfoot>
        <tbody>
            
            <% foreach (var entity in (IEnumerable<RoleToResourceViewModel>)ViewData["PremissionList"])
               {
            %>
            <tr>
                <td>
                    <%:entity.ResourceName%>
                </td>
                <td>
                    <%:entity.Value%>
                </td>
                <td>
                    <%:entity.CanView?"√":"×" %>
                </td>
                <td>
                    <%:entity.CanDetail?"√":"×" %>
                </td>
                <td>
                    <%:entity.CanAdd?"√":"×" %>
                </td>
                <td>
                    <%:entity.CanEdit?"√":"×" %>
                </td>
                <td>
                    <%:entity.CanDel?"√":"×" %>
                </td>
                <td>
                    <%
                        if (premission.CanEdit)
                        {
                    %>
                    <%:Html.ActionLink("编辑", "Edit", new { id=entity.Id })%>
                    <%
                        }
                    %>
                    &nbsp;&nbsp;
                    <%
                        if (premission.CanDel)
                        {
                    %>
                    <%:Html.ActionLink("删除", "Del", new { id = entity.Id })%>
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
