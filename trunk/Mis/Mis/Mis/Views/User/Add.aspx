<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Page.Master" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.UserViewModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
添加用户
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm())
              {%>
              <p>
                <label>用户名</label>
                <%:Html.TextBoxFor(m=>m.UserName) %>
              </p>
              <p>
                <label>密码</label>
                <%:Html.PasswordFor(m=>m.Password) %>
              </p>
              <p>
                <label>角色(请按住Ctrl键进行多选)</label>
                <%:Html.ListBoxFor(m => m.RoleIds, new SelectList(ViewData["RoleList"] as IEnumerable<SelectListItem>, "Value", "Text"))%>
                <%--<%:Html.DropDownListFor(m=>m.RoleId,ViewData["RoleList"] as IEnumerable<SelectListItem>) %>--%>
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
