<%@ Page Language="C#" Inherits="ViewPage<IList<Blog>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<%
	
	for (var i = 0; i < Model.Count;i++ )
	{ %>
	<p>
	<%=Html.ActionLink(Model[i].Title,"Details",new{id=Model[i].Id}) %>
	</p>
	<p>
	<%=Html.DisplayFor(l => l[i].Body)%>
	</p>
<hr />
<%}%>
</body>
</html>
