<%@ Control Language="C#" Inherits="ViewUserControl<Blog>" %>
<p>
<%=Html.ActionLink("Edit","Edit",new{Model.Id}) %>
<%=Html.ActionLink(Model.Title,"Details",new{Model.Id}) %>
<%=Html.ActionLink("Delete","Delete",new{Model.Id}) %>
</p>
<p>
<%=Html.DisplayFor(m=>m.Body) %>
</p>