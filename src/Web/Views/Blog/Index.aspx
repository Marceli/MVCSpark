<%@ Page Language="C#" Inherits="ViewPage<IEnumerable<Blog>>" MasterPageFile="~/Content/Master.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%=Html.ActionLink("Add new", "Create")%>
<%
	var enumerator = Model.GetEnumerator();
	while(enumerator.MoveNext())
 {
 	Html.RenderPartial("BlogListView",enumerator.Current);
 }%>
</asp:Content>