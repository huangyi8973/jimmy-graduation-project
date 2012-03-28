﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.RoleToResourceViewModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
编辑资源
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
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
                <td>列表<%:Html.CheckBoxFor(m=>m.CanView) %>&nbsp;&nbsp;
                查看<%:Html.CheckBoxFor(m=>m.CanDetail) %>&nbsp;&nbsp;
                添加<%:Html.CheckBoxFor(m=>m.CanAdd) %>&nbsp;&nbsp;
                修改<%:Html.CheckBoxFor(m=>m.CanEdit) %>&nbsp;&nbsp;
                删除<%:Html.CheckBoxFor(m=>m.CanDel) %>&nbsp;&nbsp;
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
