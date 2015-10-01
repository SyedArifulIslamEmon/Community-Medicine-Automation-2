<%@ Page Title="" Language="C#" MasterPageFile="~/HeadOffice.Master" AutoEventWireup="true" CodeBehind="SendMedicineUI.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.HeadOffice.SendMedicineUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
   
    <div>
    <h2>Send Medicine to a Center</h2>
        <table>
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="District"></asp:Label> </td>
                <td> <asp:DropDownList ID="districtMedicineDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="districtMedicineDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Thana"></asp:Label> </td>
                <td> <asp:DropDownList ID="thanaMedicineDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="thanaMedicineDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Center"></asp:Label> </td>
                <td> <asp:DropDownList ID="centerDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList></td>
            </tr>

        </table>
        <br/>
        <br/>
        <h4> Add Medicine        </h4>
       
        <asp:Label ID="Label4" runat="server" Text="Select Medicine"></asp:Label>

        <asp:DropDownList ID="medicineDropDownList" runat="server" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Quantity"></asp:Label>
        <asp:TextBox ID="quantityMedicineTextBox" runat="server" Width="87px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="addMedicineToSendButton" runat="server" Text="Add" Width="66px"  style="height: 26px" OnClick="addMedicineToSendButton_Click" />
        <br />
        <br />
        <asp:Label ID="medicineAddNotification" runat="server"></asp:Label>
        <br />
        <br />
        
    </div>
        <asp:GridView ID="medicineListGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="slNo" HeaderText="Serial No" />
                <asp:BoundField DataField="medicineName" HeaderText="Medicine Name" />
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
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
        <asp:Button ID="resetButton" runat="server" OnClick="resetButton_Click" Text="Reset" />
    &nbsp;<br />
        <br />
        <h3><asp:Label ID="notificationText" runat="server"></asp:Label></h3>

</asp:Content>
