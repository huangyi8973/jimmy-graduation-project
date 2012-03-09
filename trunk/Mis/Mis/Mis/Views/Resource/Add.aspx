<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.ResourceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
添加资源
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm())
       {%>
       <p>
            <label>资源名称</label>
            <%: Html.TextBoxFor(model => model.ResourceName)%>
       </p>
       <p>
            <label>资源地址</label>
            <%: Html.TextBoxFor(model => model.Uri)%>
       </p>
       <p>
        <label>在导航栏中显示</label>
        <%:Html.CheckBoxFor(model=>model.CanShowInNav) %>
       </p>
        <p>
            <input type="submit" value="保存" class="button" />
        </p>
    <% } %>
    <p>
        <%: Html.ActionLink("返回列表", "Index") %>
    </p>
</asp:Content>
