<%@ Page Language="C#" Title="Home" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MainPage.aspx.cs" Inherits="ProjectPage.MainPage" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>

        .chart{
            width=100%;
        }
    </style>
     <div class="jumbotron" draggable="true">
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
         </asp:DropDownList>
         &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
         </asp:DropDownList>
         &nbsp;<asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
         </asp:DropDownList>
         <br />
         <br />
         <asp:Chart ID="Chart1" Class="chart" runat="server" Height="500px" Width="1066px" BackColor="MistyRose" BackImageAlignment="Top" >
             <series>
                 <asp:Series Name="Series1" ChartArea="ChartArea1">
                 </asp:Series>
             </series>
             <chartareas>
                 <asp:ChartArea Name="ChartArea1">
                 </asp:ChartArea>
             </chartareas>
         </asp:Chart>
         <br />
         </div>
</asp:Content>