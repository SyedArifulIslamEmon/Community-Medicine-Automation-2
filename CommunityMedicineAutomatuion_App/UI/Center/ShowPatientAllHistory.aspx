<%@ Page Title="" Language="C#" MasterPageFile="~/Center.Master" AutoEventWireup="true" CodeBehind="ShowPatientAllHistory.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.Center.ShowPatientAllHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
   
    <table style="width: 100%; height: 144px;">
        <tr>
        <td class="auto-style1" style="width: 197px"> <asp:Label ID="Label1" runat="server" Text="Voter ID"></asp:Label> </td>  
                <td> <asp:TextBox ID="voterIdTextBox" runat="server" Width="150px"></asp:TextBox> <asp:Button ID="show" runat="server" Text="Show" Width="87px" OnClick="show_Click" />
                    <asp:Button ID="Pdf" runat="server" Text="Pdf" Width="87px" OnClick="Pdf_Click" />
            </td>
                <td> &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 197px">
                    Name</td>
               <td>
                   <asp:TextBox ID="nameTextBox" runat="server" Width="150px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 197px">
                    <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label> </td>
                <td>
                    <asp:TextBox ID="addressTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>  </td>
               
            </tr>
            <tr>
                <td class="auto-style1" style="width: 197px">
                    Date of Birth</td>
               <td>
                   <asp:TextBox ID="ageTextBox" runat="server" Width="150px"></asp:TextBox>
                    </td>
             
    </table>
    <div id="Content" runat="server">
        
    </div>
   
</asp:Content>
