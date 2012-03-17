<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.ResourceViewModel>" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       {%>
    <%:Html.ValidationSummary(true)%>
    <%:Html.HiddenFor(model=>model.ResourceId) %>
    <p>
    <label>资源ID</label>
    <%:Model.ResourceId %>
    </p>
    <p>
        <label>资源名称</label>
         <%:Html.TextBoxFor(model => model.ResourceName)%>
    </p>
<p>
    <label>资源地址</label>
    <%:Html.TextBoxFor(model => model.Uri)%>
</p>
<p>
    <label>在导航栏中显示</label>
    <%:Html.CheckBoxFor(model=>model.CanShowInNav) %>
</p>
        
        <p>
            <input type="submit" class="button" value="保存" />
        </p>
    <%
       }%>
    <p>
        <%: Html.ActionLink("返回列表", "Index") %>
    </p>
</asp:Content>
