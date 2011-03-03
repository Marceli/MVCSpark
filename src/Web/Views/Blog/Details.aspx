<%@ Page Language="C#" Inherits="ViewPage<Blog>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Details</title>
</head>
<body>
    <div>
    <%=Html.DisplayForModel() %>
    
    </div>
    <p>
    <%foreach(var comment in Model.Comments)
	{
		Html.RenderPartial("CommentVew", comment);
	} 
    %>
    </p>
    <%=Html.ActionLink("Back","Index") %>
</body>
</html>
