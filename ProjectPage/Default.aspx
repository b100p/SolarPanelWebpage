<%@ Page Title="LoginPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjectPage._Default"  %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .mybtn {
    background-color: #121111;
    color: #94bbd5;
}
    div.form
{
    display: block;
    text-align: center;
}
.form
{
    display: inline-block;
    margin-left: auto;
    margin-right: auto;
    text-align: left;
}
.w3-input
{
    display: inline-block;
    margin-left: auto;
    margin-right: auto;
    text-align: left;
    padding:8px;
    border:none;
    border-bottom:1px solid #ccc;
    width:100%

}
.w3-blue-grey,.w3-hover-blue-grey:hover,.w3-blue-gray,.w3-hover-blue-gray:hover
{
    color:#fff!important;
    background-color:#607d8b!important;

}
.w3-btn
{
    border:none;
    display:inline-block;
    padding:8px 16px;
    vertical-align:middle;
    overflow:hidden;
    text-decoration:none;
    color:inherit;
    background-color:inherit;
    text-align:center;
    cursor:pointer;
    white-space:nowrap}
</style>
    
    <div class="jumbotron">
        <%--LOGIN--%>
        <div class="form">
        <label >Username</label>
            <br />
            <br />   
        <asp:TextBox ID="username"  class="w3-input" runat="server"></asp:TextBox>
        <br />
            <br />
        <label >Password</label>
            <br />
            <br />
        <asp:TextBox ID="pswd" type="Password"  class="w3-input"  runat="server"> </asp:TextBox>
        <br />
            <br />
        <asp:Button class="mybtn w3-btn w3-blue-grey" ID="btnlogin" runat="server" Text="login" Width="90px" OnClick="btnlogin_Click" />
            </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <center><a href="Request.aspx">Request access</a></center>
        </div>
    </div>

</asp:Content>
