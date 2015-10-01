<%@ Page Title="" Language="C#" MasterPageFile="~/HeadOffice.Master" AutoEventWireup="true" CodeBehind="CreateDiseaseEntryUI.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.HeadOffice.CreateDiseaseEntryUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    
    <center><div>
        <h2>Enter New Disease Information</h2>
        <br/>
        <table>
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label> </td>  
                <td> <asp:TextBox ID="nameTextBox" runat="server" Width="168px" style="margin-left: 0px"></asp:TextBox> </td>
                <br />
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label> </td>
               <td>
                   <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine"></asp:TextBox> </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Treatment Procedure"></asp:Label> </td>
                <td>
                    <asp:TextBox ID="treatmentProcedureTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>  </td>
                <td> <asp:Button ID="saveDiseaseButton" runat="server" Text="Save" Width="87px" OnClick="saveDiseaseButton_Click" /></td>
            </tr>
        </table>
        <asp:Label ID="notificationText" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="DiseaseGridView" runat="server" AllowPaging="True" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None" EnableViewState="False" OnPageIndexChanging="DiseaseGridView_PageIndexChanging" Width="863px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
        </center>

</asp:Content>
