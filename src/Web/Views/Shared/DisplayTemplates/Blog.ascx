<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Blog>" %>

<div>
<%=Html.LabelFor(m=>m.Title) %>
<%=Html.DisplayFor(m=>m.Title) %>
</div>
<div>
<%=Html.LabelFor(m=>m.Body) %>
<%=Html.DisplayFor(m=>m.Body) %>
</div>

