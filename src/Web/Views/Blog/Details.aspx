<%@ Page Language="C#" Inherits="ViewPage<Blog>" MasterPageFile="~/Content/Master.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    hello from details.aspx
    <%=Html.DisplayForModel() %>
    
    </div>
    
    <%=Html.ActionLink("Back","Index") %>
</asp:Content>