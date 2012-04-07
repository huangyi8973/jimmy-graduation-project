<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.RoleToResourceViewModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
添加资源
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        OperateBind();
        $("#ResourceId").bind("change",OperateBind);
    });
    function OperateBind() {
        var value = 0;
        if($("#ResourceId").val()!='0')
        {
            $.ajax({
                url: '<%:Url.Action("GetResourceActionByResourceId") %>',
                type: "post",
                data: "id=" + $("#ResourceId").val(),
                datatype: "json",
                success: function (msg) {
                    value = msg['Value'];
                    CheckBoxOperation(value);
                },
                error: function (err) { alert(err); }
            });
        }
        else {
            CheckBoxOperation(0);
        }

    }
    function CheckBoxOperation(value) {
        var canView = $("#CanView");
        var canDetail = $("#CanDetail");
        var canAdd = $("#CanAdd");
        var canEdit = $("#CanEdit");
        var canDel = $("#CanDel");


        //去除所有勾选
        canView.attr("checked", false);
        canDetail.attr("checked", false);
        canAdd.attr("checked", false);
        canEdit.attr("checked", false);
        canDel.attr("checked", false);


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
    <%:Html.HiddenFor(m=>m.RoleId) %>
    <table>
        <tbody>
            <tr>
                <td style="width: 50px">
                    资源
                </td>
                <td>
                    <%:Html.DropDownListFor(m => m.ResourceId,
                                                 (IEnumerable<SelectListItem>) ViewData["ResourceItems"])%>
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
                    权限
                </td>
                <td>
                    <ul id="premission_controller">
                        <li id="div_view">列表<%:Html.CheckBoxFor(m=>m.CanView) %>&nbsp;&nbsp;</li>
                        <li id="div_detail">查看<%:Html.CheckBoxFor(m=>m.CanDetail) %>&nbsp;&nbsp;</li>
                        <li id="div_add">添加<%:Html.CheckBoxFor(m=>m.CanAdd) %>&nbsp;&nbsp;</li>
                        <li id="div_edit">修改<%:Html.CheckBoxFor(m=>m.CanEdit) %>&nbsp;&nbsp;</li>
                        <li id="div_del">删除<%:Html.CheckBoxFor(m=>m.CanDel) %>&nbsp;&nbsp;</li>
                    </ul>                    
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
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
    <script type="text/javascript">
        PremissionOperate();
    </script>
</asp:Content>
