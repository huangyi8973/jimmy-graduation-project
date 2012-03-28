<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.ResourceViewModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%:Html.ValidationSummary(true)%>
    <%:Html.HiddenFor(model=>model.ResourceId) %>
    <p>
        <label>
            资源ID</label>
        <%:Model.ResourceId %>
    </p>
    <p>
        <label>
            资源名称</label>
        <%:Html.TextBoxFor(model => model.ResourceName)%>
    </p>
    <p>
        <label>
            资源地址</label>
        <%:Html.TextBoxFor(model => model.Uri)%>
    </p>
    <p>
        <label>
            在导航栏中显示</label>
        <%:Html.CheckBoxFor(model=>model.CanShowInNav) %>
    </p>
    <p>
        <label>
            所拥有的操作</label>
        列表<%:Html.CheckBoxFor(m=>m.CanView) %>&nbsp;&nbsp; 查看<%:Html.CheckBoxFor(m=>m.CanDetail) %>&nbsp;&nbsp;
        添加<%:Html.CheckBoxFor(m=>m.CanAdd) %>&nbsp;&nbsp; 修改<%:Html.CheckBoxFor(m=>m.CanEdit) %>&nbsp;&nbsp;
        删除<%:Html.CheckBoxFor(m=>m.CanDel) %>&nbsp;&nbsp;
    </p>
    <p>
        <input type="submit" class="button" value="保存" />
    </p>
    <%
        }%>
    <p>
        <%: Html.ActionLink("返回列表", "Index") %>
    </p>
    <script type="text/javascript">
        PremissionOperate();
    </script>
</asp:Content>
