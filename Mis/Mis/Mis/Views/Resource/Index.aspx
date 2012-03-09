<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.ResourceViewModel>" %>

<%@ Import Namespace="Mis.Core.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加资源
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%var premission = ViewData["UserPremission"] as ResourceCacheModel; %>
    <table>
        <thead>
            <tr>
                <th>
                    资源名称
                </th>
                <th>
                    资源路径
                </th>
                <th>
                    是否显示在导航栏
                </th>
                <th>
                    操作
                </th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <td colspan="4">
                    <%if (premission.CanAdd)
                      { %>
                    <%:Html.ActionLink("添加", "Add", null, new {@class = "button"})%>
                    <% } %>
                </td>
            </tr>
        </tfoot>
        <tbody>
            <% foreach (var entity in (IEnumerable<ResourceViewModel>)ViewData["ResourceList"])
               {
            %>
            <tr>
                <td>
                    <%:entity.ResourceName%>
                </td>
                <td>
                    <%:entity.Uri%>
                </td>
                <td>
                    <%:entity.CanShowInNav?"√":"×" %>
                </td>
                <td>
                    <%
                        if (premission.CanEdit)
                        {
                    %>
                    <%:Html.ActionLink("编辑", "Edit", new { id=entity.ResourceId })%>
                    <%
                        }
                    %>
                    &nbsp;&nbsp;
                    <%
                        if (premission.CanDel)
                        {
                    %>
                    <%:Html.ActionLink("删除", "Del", new { id = entity.ResourceId })%>
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
