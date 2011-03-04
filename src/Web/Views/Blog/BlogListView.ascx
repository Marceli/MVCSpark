<%@ Control Language="C#" Inherits="ViewUserControl<Blog>" %>
<p>
<%=Html.ActionLink("Edit","Edit",new{Id=Model.Id}) %>
<%=Html.ActionLink(Model.Title,"Details",new{Id=Model.Id}) %>
</p>
<p>
<%=Html.DisplayFor(m=>m.Body) %>
</p>