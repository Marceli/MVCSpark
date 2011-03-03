<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Core.Entities.Comment>" %>
<p>
<%=Html.LabelFor(m=>m.Body)%>
</p>
<p>
<%=Html.DisplayFor(m => m.Body)%>
</p>
