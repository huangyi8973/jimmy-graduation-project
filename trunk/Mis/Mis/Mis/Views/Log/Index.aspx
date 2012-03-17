<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Mis.Core.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	日志
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%var premission = ViewData["UserPremission"] as ResourceCacheModel; %>
    <table>
        <thead>
            <tr>
                <th>
                    用户名
                </th>
                <th>
                    日志
                </th>
                <th>
                    事件
                </th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <td colspan="3">
                <%if(premission.CanDel)
                  {
                      %>
                      <%:Html.ActionLink("清空日志", "Del", null, new {@class = "button"})%>
                      <%
                  } %>
                </td>
            </tr>
        </tfoot>
        <tbody>
            <% foreach (LogViewModel log in (IEnumerable<LogViewModel>)ViewData["LogList"])
               {
            %>
            <tr>
                <td>
                    <%:log.UserName %>
                </td>
                <td>
                    <%:log.Message %>
                </td>
                <td>
                    <%:log.LogTime %>
                </td>
            </tr>
            <%
                } %>
        </tbody>
    </table>

</asp:Content>
