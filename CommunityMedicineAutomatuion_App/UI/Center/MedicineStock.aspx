<%@ Page Title="" Language="C#" MasterPageFile="~/Center.Master" AutoEventWireup="true" CodeBehind="MedicineStock.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.Center.MedicineStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">

    <div>
    
        <h3>Medicine Stock of 
        <asp:Label ID="centerName" runat="server" Text=""></asp:Label></h3>
      
        <br />
        <asp:GridView ID="medicineStockDataGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="365px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="MedicineName" HeaderText="Medicine Name" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            </Columns>
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
      
        <br />
    
    </div>
   
</asp:Content>
