<%@ Page Language="C#" Title="Manage" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ProjectPage.Manage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .Center {
           border-left:150px;

        }
        .auto-style1 {
            height: 20px;
        }
    </style>
     <div class="jumbotron">

         <asp:DropDownList ID="DropDownList1" class="Center"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="dropup">
         </asp:DropDownList>
         <br />
         <table style="width:50%;">
             <tr>
                 <td><asp:Label ID="Label2" runat="server" Text="ID: "></asp:Label></td>
                 <td> <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox></td>
             </tr>
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
             <tr>
                 <td>  <asp:Label ID="Label5" runat="server" Text="Password: "></asp:Label></td>
                 <td>  <asp:TextBox ID="TextBox3" type="password" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" Enabled="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>

             </tr>
             <tr>
                 <td>          <asp:CheckBox ID="CheckBox1" runat="server" />       </td>
                 <td>         <asp:Label ID="admin" runat="server" Text="Admin"></asp:Label></td>
             </tr>
         </table>
                  <div class="Center">
                      <asp:Button ID="btnadd"  runat="server" OnClick="btnadd_Click" Text="New" />
                      <asp:Button ID="btnedit" runat="server" Text="Edit" Visible="False" OnClick="btnedit_Click" />
                      <asp:Button ID="btndelete" runat="server" Text="Delete" Visible="False" OnClick="btndelete_Click" />
                      <asp:Button ID="reset" runat="server" Text="Reset" OnClick="reset_Click" />

                  </div>
         </div>
   
</asp:Content>