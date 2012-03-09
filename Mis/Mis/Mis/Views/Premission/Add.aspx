<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.RoleToResourceViewModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
添加资源
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var canView = $("#CanView");
            var canDetail = $("#CanDetail");
            var canAdd = $("#CanAdd");
            var canEdit = $("#CanEdit");
            var canDel = $("#CanDel");

            canView.click(function () {
                if ($(this).attr("checked") == false) {
                    canDetail.attr("checked", false);
                    canAdd.attr("checked", false);
                    canEdit.attr("checked", false);
                    canDel.attr("checked", false);
                }
            });

            canDetail.click(function () {
                if ($(this).attr("checked") == true) {
                    canView.attr("checked", true);
                }
            });
            canAdd.click(function () {
                if ($(this).attr("checked") == true) {
                    canView.attr("checked", true);
                }
            });
            canEdit.click(function () {
                if ($(this).attr("checked") == true) {
                    canView.attr("checked", true);
                }
            });
            canDel.click(function () {
                if ($(this).attr("checked") == true) {
                    canView.attr("checked", true);
                }
            });
        });
    </script>
   
    <%using (Html.BeginForm())
      {%>
    <%:Html.HiddenFor(m=>m.RoleId) %>
    <table>
        <tbody>
            <tr>
                <td>
                    资源
                </td>
                <td>
                    <%:Html.DropDownListFor(m => m.ResourceId,
                                                 (IEnumerable<SelectListItem>) ViewData["ResourceItems"])%>
                </td>
            </tr>
            <tr>
                <td>
                    权限
                </td>
                <td>
                    列表<%:Html.CheckBoxFor(m=>m.CanView) %>&nbsp;&nbsp; 查看<%:Html.CheckBoxFor(m=>m.CanDetail) %>&nbsp;&nbsp;
                    添加<%:Html.CheckBoxFor(m=>m.CanAdd) %>&nbsp;&nbsp; 修改<%:Html.CheckBoxFor(m=>m.CanEdit) %>&nbsp;&nbsp;
                    删除<%:Html.CheckBoxFor(m=>m.CanDel) %>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <input type="submit" class="button" value="添加" />
                </td>
            </tr>
        </tbody>
    </table>
    <%
      }%>
         <p>
        <%: Html.ActionLink("返回列表", "Index",new{roleId=Model.RoleId}) %>
    </p>
</asp:Content>
