<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="Mis.Core.Model" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    添加公告
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%var premission = ViewData["UserPremission"] as ResourceCacheModel; %>
    <table>
        <thead>
            <tr>
                <th>
                    标题
                </th>
                <th>
                    创建者
                </th>
                <th>
                    创建时间
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
            <% foreach (var entity in (IEnumerable<NoticeViewModel>)ViewData["NoticeList"])
               {
            %>
            <tr>
                <td>
                    <%if (premission.CanDetail)
                      {%>
                    <%:Html.ActionLink(entity.Title, "Detail", new { id = entity.Id })%>
                    <%
                        }
                      else
                      {%>
                    <%:entity.Title%>
                    <%
                        }%>
                </td>
                <td>
                    <%:entity.UserName %>
                </td>
                <td>
                    <%:entity.CreateTime %>
                </td>
                <td>
                    <%
                        if (premission.CanDel)
                        {
                    %>
                    <%:Html.ActionLink("删除", "Del", new { id = entity.Id })%>
                    <%
                        }%>
                </td>
            </tr>
            <%
                } %>
        </tbody>
    </table>
</asp:Content>
