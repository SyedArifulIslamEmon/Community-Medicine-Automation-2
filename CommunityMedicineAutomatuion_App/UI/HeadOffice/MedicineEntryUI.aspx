<%@ Page Title="" Language="C#" MasterPageFile="~/HeadOffice.Master" AutoEventWireup="true" CodeBehind="MedicineEntryUI.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.HeadOffice.MedicineEntryUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

        <center>
        > <div>
    <h2> Add New Medicine </h2>
        <br/>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Name Of Medicine with Mg/Ml"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="medicineNameCreateTextBox" runat="server"></asp:TextBox></td>
            </tr>           
        </table>
        <br/>
        <asp:Button ID="SaveMedicineButton" runat="server" Text="Save" Width="98px" OnClick="SaveMedicineButton_Click" style="margin-left: 246px" />
                <br />
        <br/>
        <asp:GridView ID="MedicineGridView" runat="server" AllowPaging="True" PageSize="5" OnPageIndexChanging="MedicineGridView_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="451px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    
        <asp:Label ID="saveSuccessResult" runat="server" Text=""></asp:Label>
        <br />
    </div>
            </center>
   
</asp:Content>
