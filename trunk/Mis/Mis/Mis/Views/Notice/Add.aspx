<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.NoticeViewModel>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    添加公告
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm())
      {%>
    <p>
        <label>
            标题</label>
        <%:Html.TextBoxFor(m=>m.Title) %>
    </p>
    <p>
        <label>
            内容</label>
        <%:Html.TextAreaFor(m =>m.Content, new { @rows = "10" })%>
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
