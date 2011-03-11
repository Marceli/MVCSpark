<%@ Control Language="C#" Inherits="ViewUserControl<Comment>" %>
<p>
<%=Html.LabelFor(m=>m.Body)%>
</p>
<p>
<%=Html.DisplayFor(m => m.Body)%>
</p>
