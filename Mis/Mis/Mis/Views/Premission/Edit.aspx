<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.RoleToResourceViewModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
编辑资源
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            CheckBoxOperation('<%:Model.Value %>');
        });
        
        function CheckBoxOperation(value) {
            //获得checkbox所在的div
            var div_view = $("#div_view");
            var div_detail = $("#div_detail");
            var div_add = $("#div_add");
            var div_edit = $("#div_edit");
            var div_del = $("#div_del");

            if ((value & 1) == 1) {
                div_view.removeAttr("style");
            }
            else {
                div_view.attr("style", "display:none");
            }

            if ((value & 2) == 2) {
                div_add.removeAttr("style");
            }
            else {
                div_add.attr("style", "display:none");
            }

            if ((value & 4) == 4) {
                div_edit.removeAttr("style");
            }
            else {
                div_edit.attr("style", "display:none");
            }

            if ((value & 8) == 8) {
                div_del.removeAttr("style");
            }
            else {
                div_del.attr("style", "display:none");
            }

            if ((value & 16) == 16) {
                div_detail.removeAttr("style");
            }
            else {
                div_detail.attr("style", "display:none");
            }
        }
</script>
    <%using (Html.BeginForm())
      {%>
      <%:Html.HiddenFor(m=>m.Id) %>
      <%:Html.HiddenFor(m=>m.RoleId) %>
    <table>
        <tbody>
            <tr>
                <td>资源</td>
                <td><%:Model.ResourceName %></td>
            </tr>
            <tr>
                <td>权限</td>
                <td><ul id="premission_controller">
                        <li id="div_view">列表<%:Html.CheckBoxFor(m=>m.CanView) %>&nbsp;&nbsp;</li>
                        <li id="div_detail">查看<%:Html.CheckBoxFor(m=>m.CanDetail) %>&nbsp;&nbsp;</li>
                        <li id="div_add">添加<%:Html.CheckBoxFor(m=>m.CanAdd) %>&nbsp;&nbsp;</li>
                        <li id="div_edit">修改<%:Html.CheckBoxFor(m=>m.CanEdit) %>&nbsp;&nbsp;</li>
                        <li id="div_del">删除<%:Html.CheckBoxFor(m=>m.CanDel) %>&nbsp;&nbsp;</li>
                    </ul>  
                </td>
            </tr>
            <tr>
                <td></td>
                <td><input type="submit" class="button" value="保存" /></td>
            </tr>
        </tbody>
    </table>
    <%
      }%>
               <p>
        <%: Html.ActionLink("返回列表", "Index",new{roleId=Model.RoleId}) %>
    </p>
    <script type="text/javascript">
        PremissionOperate();
    </script>
</asp:Content>
