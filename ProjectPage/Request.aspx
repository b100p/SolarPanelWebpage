<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Request.aspx.cs" Inherits="ProjectPage.Request" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="jumbotron">
    <center><table style="width:30%;">

             <tr>
                 <td class="auto-style1"> <asp:Label ID="Label3"  runat="server" Text="Email: "></asp:Label></td>
                 <td class="auto-style1"><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" Enabled="False" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
             </tr>
        <tr>
            <td colspan="2"><asp:Button id="req" Text="Resuest Access" runat="server" Width="153px" OnClick="req_Click"/></td>
        </tr>
         </table></center>
</div>
</asp:Content>