<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<Mis.Core.Model.LoginModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>权限管理框架</title>
<link rel="stylesheet" href="<%:Url.Content("~/Content/css/reset.css") %>" type="text/css" media="screen" />
<link rel="stylesheet" href="<%:Url.Content("~/Content/css/style.css") %>" type="text/css" media="screen" />
<link rel="stylesheet" href="<%:Url.Content("~/Content/css/invalid.css") %>" type="text/css" media="screen" />
 <script type="text/javascript" src="<%:Url.Content("~/Scripts/jquery-1.4.1.js") %>"></script>	
<script type="text/javascript">
    $(document).ready(function () {
        $("#UserName")[0].focus();
    });
</script>
</head>

<body id="login">
		
		<div id="login-wrapper" class="png_bg">
			<div id="login-top">
			
				<h1>人事信息管理系统</h1>
				<!-- Logo (221px width) -->
				<img id="logo" src="<%:Url.Content("~/Content/images/logo.png") %>" alt="人事信息管理系统" />
			</div> <!-- End #logn-top -->
			
			<div id="login-content">
				
				<%using (Html.BeginForm())
                {
                %>
				
					<div class="notification information png_bg">
						<div>
							放提示信息
						</div>
					</div>
					
					<p>
						<label>用户名</label>
						<%:Html.TextBoxFor(m => m.UserName)%>
					</p>
					<div class="clear"></div>
					<p>
						<label>密码</label>
						<%:Html.PasswordFor(m => m.Password)%>
					</p>
					<div class="clear"></div>
					
					<div class="clear"></div>
					<p>
						<input class="button" type="submit" value="登录" />
					</p>
					
				<% }%>
			</div> <!-- End #login-content -->
			
		</div> <!-- End #login-wrapper -->

  </body>
</html>

