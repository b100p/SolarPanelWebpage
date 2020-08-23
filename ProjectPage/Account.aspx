<%@ Page Language="C#" Title="Account" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="ProjectPage.Account" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
<table style="width:50%;">

             <tr>
                 <td class="auto-style1"> <asp:Label ID="Label3"  runat="server" Text="Email: "></asp:Label></td>
                 <td class="auto-style1"><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" Enabled="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
             </tr>
             <tr>
                 <td>   <asp:Label ID="Label4"  runat="server" Text="Username: "></asp:Label></td>
                 <td> <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox4" Enabled="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
             </tr>
             <tr id="passwd1" runat="server" visible="false">
                 <td>  <asp:Label ID="Label5" runat="server" Text="Old Password: "></asp:Label></td>
                 <td>  <asp:TextBox ID="TextBox3" type="password" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" Enabled="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>

             </tr>
            <tr id="passwd2" runat="server" visible="false">
                 <td style="height: 25px">  <asp:Label ID="Label1" runat="server" Text="New Password: "></asp:Label></td>
                 <td style="height: 25px">  <asp:TextBox ID="TextBox1" type="password" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3" Enabled="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>

             </tr>
             <tr id="passwd3" runat="server" visible="false">
                 <td>  <asp:Label ID="Label2" runat="server" Text="Confirm Password: "></asp:Label></td>
                 <td>  <asp:TextBox ID="TextBox5" type="password" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3" Enabled="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox1" ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="Red"></asp:CompareValidator>
                 </td>

             </tr>
    <tr>
                 <td>          <asp:CheckBox ID="CheckBox1" runat="server" />       </td>
                 <td>         <asp:Label ID="admin" runat="server" Text="Admin"></asp:Label></td>
             </tr>
         </table>
    <asp:Button runat="server" Text="Change Password" ID="changepswd" OnClick="changepswd_Click" />

         </div>
    </asp:Content>