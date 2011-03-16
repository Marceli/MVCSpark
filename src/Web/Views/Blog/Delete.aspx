<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Core.Entities.Blog>" MasterPageFile="~/Content/Master.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%=Html.DisplayForModel() %>    
</asp:Content>