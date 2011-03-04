<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Blog>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Create</title>
</head>
<body>
    <div>
    <%using(Html.BeginForm()){%>
    <div>
    <fieldset>
    <%=Html.HiddenFor(m=>m.Id) %>
    <div class="editor-label">
       <%=Html.LabelFor(m=>m.Title) %>:
    </div>
    <div class="editor-field">
      <%=Html.TextBoxFor(m=>m.Title) %>
    </div>
    <div class="editor-label">
	    <%=Html.LabelFor(m=>m.Body) %>:
    </div>
    <div class="editor-field">
	   <%=Html.TextBoxFor(m=>m.Body) %>
    </div>
    <input type="submit" value="Send" />
    </fieldset>
    </div>
 
    <%}%>
    </div>
</body>
</html>
