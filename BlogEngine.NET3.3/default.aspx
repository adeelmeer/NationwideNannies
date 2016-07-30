<%@ Page Language="C#" AutoEventWireup="true" Inherits="_default" CodeBehind="default.aspx.cs" %>

<%@ Register Src="Custom/Controls/PostList.ascx" TagName="PostList" TagPrefix="uc1" %>
<asp:content id="Content1" contentplaceholderid="cphBody" runat="Server">

    <%
        System.Web.HttpContext.Current.Response.Redirect("/admin");
     %>

  <div id="divError" runat="Server" />
  <uc1:PostList ID="PostList1" runat="server" />
  <blog:PostCalendar runat="server" ID="calendar" 
    EnableViewState="false"
    ShowPostTitles="true" 
    BorderWidth="0"
    NextPrevStyle-CssClass="header"
    CssClass="calendar" 
    WeekendDayStyle-CssClass="weekend" 
    OtherMonthDayStyle-CssClass="other" 
    UseAccessibleHeader="true" 
    Visible="false" 
    Width="100%" />

    

</asp:content>

