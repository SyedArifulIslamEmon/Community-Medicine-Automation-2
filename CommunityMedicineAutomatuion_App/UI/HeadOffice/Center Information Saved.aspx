<%@ Page Title="" Language="C#" MasterPageFile="~/HeadOffice.Master" AutoEventWireup="true" CodeBehind="Center Information Saved.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.HeadOffice.Center_Information_Saved" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
 
    <center><div>
    
         
        &nbsp;Center Information Saved<br />
        <br />
        Code:
        <asp:Label ID="Code" runat="server"></asp:Label>
        <br />
        Password:
        <asp:Label ID="Password" runat="server"></asp:Label>
        <br />
        <br />
        Center Name:<asp:Label ID="CenterName" runat="server"></asp:Label>
        <br />
        Thana Name:
        <asp:Label ID="ThanaName" runat="server"></asp:Label>
        <br />
        District Name:
        <asp:Label ID="DistrictName" runat="server"></asp:Label>
    
         
        <br />
        <asp:Button ID="backButton" runat="server" OnClick="backButton_Click" Text="Back" />
    
         
    </div>
        </center>


</asp:Content>
