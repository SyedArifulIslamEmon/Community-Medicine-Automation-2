<%@ Page Title="" Language="C#" MasterPageFile="~/HeadOffice.Master" AutoEventWireup="true" CodeBehind="CreateNewCenterUI.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.HeadOffice.CreateNewCenterUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
  
    <center><div>
    <h2>
        <asp:Label ID="Label1" runat="server" Text="Create New Center"></asp:Label>
    </h2> 
        <br/>
        <table>
            <tr>
                <td> <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label> </td>
                <td> <asp:TextBox ID="createCenterNameTextBox" runat="server"></asp:TextBox> </td>
            </tr>
            <tr>
                <td> <asp:Label ID="Label3" runat="server" Text="District"></asp:Label> </td>
                <td> <asp:DropDownList ID="createCenterDistrictDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="createCenterDistrictDropDownList_SelectedIndexChanged"></asp:DropDownList> </td>

            </tr>
            <tr>
                <td> <asp:Label ID="Label4" runat="server" Text="Thana"></asp:Label> </td>
                <td> <asp:DropDownList ID="createCentreThanaDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="createCentreThanaDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>

        </table>
        <br/>
        <asp:Button ID="createCenterSaveButton" runat="server" Text="Save" Width="104px" OnClick="createCenterSaveButton_Click" />

        <br />

        <asp:Label ID="labelNotification" runat="server"></asp:Label>

        <br />

        <br />

    </div>
        </center>
   
</asp:Content>
