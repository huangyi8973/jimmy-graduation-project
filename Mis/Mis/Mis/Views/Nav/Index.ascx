<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Mis.Core.Model.UserCacheModel>" %>

<div id="sidebar">
        <div id="sidebar-wrapper">
            <!-- Sidebar with logo and menu -->
            <%--<h1 id="sidebar-title">--%>
            <!-- Logo (221px wide) -->
            <a href="/home" target="right">
                <img id="logo" src="<%:Url.Content("~/Content/images/logo.png") %>" /></a>
            <!-- Sidebar Profile links -->
            <div id="profile-links">
                您好,
                <%:Model.UserName %><br />
                您的身份是：<%:Model.Role.RoleName %>
                <br />
                <br />
                <%:Html.ActionLink("注销","Logout","Gateway") %>
            </div>
            <ul id="main-nav">
                <li><%:Html.ActionLink("首页", "Index", "Home", null, new { @class = "nav-top-item no-submenu" })%></li>
                <%
                        foreach (var n in Model.PremissionList)
                        {
                            if (n.CanShowInNav)
                            {
                %>
                <li>
                    <%:Html.ActionLink(n.ResourceName, "Index", n.Controller, null, new { @class = "nav-top-item no-submenu" })%></li>
                <% }%>
                <%
                    }
                %>
            </ul>
        </div>
    </div>