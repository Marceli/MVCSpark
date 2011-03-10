<%@ Page Language="C#" Inherits="ViewPage<Blog>" MasterPageFile="~/Content/Master.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
</asp:Content>