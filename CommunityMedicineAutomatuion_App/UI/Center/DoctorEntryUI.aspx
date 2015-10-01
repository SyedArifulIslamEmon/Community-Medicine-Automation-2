<%@ Page Title="" Language="C#" MasterPageFile="~/Center.Master" AutoEventWireup="true" CodeBehind="DoctorEntryUI.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.Center.DoctorEntryUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
   
    <div>
    <h2>Doctor Entry</h2>
        <br/>
        <table>
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label></td>
                <td> <asp:TextBox ID="nameOfDoctorTextBox" runat="server" Width="173px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Degree"></asp:Label> </td>
                <td> <asp:TextBox ID="degreeOfDoctorTextBox" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td> <asp:Label ID="Label3" runat="server" Text="Specialization"></asp:Label></td>
                <td> <asp:TextBox ID="specializationOfDoctorTextBox" runat="server" Width="172px"></asp:TextBox></td>
            </tr>
        </table>
        <br/>
        
        <asp:Button ID="saveDoctorButton" runat="server" Text="Save" Width="123px" OnClick="saveDoctorButton_Click" style="margin-left: 131px" />

        <br />
        <asp:Label ID="labelNotification" runat="server"></asp:Label>
        <br/>


    </div>
  
</asp:Content>
