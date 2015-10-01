<%@ Page Title="" Language="C#" MasterPageFile="~/Center.Master" AutoEventWireup="true" CodeBehind="TreatmentGiven.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.Center.TreatmentGiven" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <h2>Treatment</h2>
        <br/>
        <table>
            <tr>
                <td class="auto-style1" style="width: 197px"> <asp:Label ID="Label1" runat="server" Text="Voter ID"></asp:Label> </td>  
                <td> <asp:TextBox ID="voterIdTextBox" runat="server" Width="150px"></asp:TextBox> </td>
                <td> <asp:Button ID="showButton" runat="server" Text="Show Details" Width="87px" OnClick="showButton_Click" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 197px">
                    Name</td>
               <td>
                   <asp:TextBox ID="nameTextBox1" runat="server" Width="150px"></asp:TextBox>
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
            </tr>
             <tr>
                <td class="auto-style1" style="width: 197px">
                    <asp:Label ID="Label5" runat="server" Text="Service Given"></asp:Label> </td>
               <td>
                   <asp:TextBox ID="serviceTimeTextBox" runat="server" Width="50px"></asp:TextBox>
                    </td>
                 <td>
                    <asp:Label ID="Label6" runat="server" Text="Times"></asp:Label> </td>
            </tr>
         <tr>
             <td class="auto-style1" style="width: 197px"></td>
         </tr>
             <tr>
                 
                <td class="auto-style1" style="width: 197px">
                    <asp:Label ID="Label7" runat="server" Text="Observation"></asp:Label> </td>
                <td>
                    <asp:TextBox ID="observationTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>  </td>
               <td><asp:Label ID="Label8" runat="server" Text="Date"></asp:Label></td>
                 <td>
                     <asp:Calendar ID="treatmentDate" runat="server" SelectedDate="2015-06-30"></asp:Calendar>
                 </td>
                 <td>

                 </td>
                 <td><asp:Label ID="Label9" runat="server" Text="Doctor"></asp:Label></td>
                 <td class="auto-style2">
                     <asp:DropDownList ID="doctorDropDownList" runat="server"></asp:DropDownList></td>

            </tr>
            <tr>
                <td class="auto-style3" style="width: 197px"><asp:Label ID="Label10" runat="server" Text="Disease"></asp:Label></td>
                 <td class="auto-style4">
                     <asp:DropDownList ID="diseaseDropDownList" runat="server"></asp:DropDownList></td>            
                 <td class="auto-style4"><asp:Label ID="Label11" runat="server" Text="Medicine"></asp:Label></td>
                 <td class="auto-style4">
                     <asp:DropDownList ID="medicineDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                 <td class="auto-style4"><asp:Label ID="Label12" runat="server" Text="Dose"></asp:Label></td>
                 <td class="auto-style4">
                     <asp:TextBox ID="doseTextBox" runat="server" Width="82px"></asp:TextBox>
                     </td>
                <td class="auto-style5">
                    <input type="radio" name="meal" id="afterMealRadioButton" runat="server" value="After Meal" /> After Meal<br />
                   <input type="radio" name="meal" id="beforeMealRadioButton" runat="server" value="Before Meal" /> Before Meal</td>
                
                <td class="auto-style4">
                     <td class="auto-style4"><asp:Label ID="Label13" runat="server" Text="Qty Given"></asp:Label></td>
                 <td class="auto-style4">
                     <asp:TextBox ID="qtyGivenTextBox" runat="server" Width="54px"></asp:TextBox></td>
                </td>
                 <td class="auto-style4">
                    <asp:Label ID="Label14" runat="server" Text="Note"></asp:Label> </td>
               <td class="auto-style4">
                   <asp:TextBox ID="noteTextBox" runat="server" Width="50px"></asp:TextBox>
                    </td>
                <td class="auto-style4"> <asp:Button ID="addButton" runat="server" Text="ADD" Width="87px" OnClick="addButton_Click"  />
                                     
            </tr>

            <tr>
                <td class="auto-style1" style="width: 197px"></td><td></td><td></td><td></td><td></td><td></td>
                <td class="auto-style2">
                    &nbsp;</td>
                     </tr>        
                         <tr>               
               <td class="auto-style1" style="width: 197px">                   
               </td>
                <td>                    
                    <asp:Label ID="labelNotification" runat="server"></asp:Label>
                </td>
                <td> 
                    &nbsp;</td>
                </tr>

        </table>
        <br />
            <asp:GridView ID="TreatmentGivenGridView" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None" Width="802px" AutoGenerateColumns="False" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="diseaseName" HeaderText="Disease" />
                    <asp:BoundField DataField="medicineName" HeaderText="Medicine" />
                    <asp:BoundField DataField="dose" HeaderText="Dose" />
                    <asp:BoundField DataField="mealCheck" HeaderText="Before/After Meal" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="note" HeaderText="Note" />
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
         <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" Width="88px" OnClick="saveButton_Click" /></td>
        
        
    &nbsp; 
                    <asp:Button ID="pdfButton" runat="server" Text="PDF" OnClick="pdfButton_Click" Width="76px" />
        
        
                    <asp:Button ID="resetButton" runat="server" Text="Reset" Width="88px" OnClick="resetButton_Click"  />
        
        
    </div>
   
    <script src="../../Scripts/jquery-2.1.4.min.js"></script>
    <script>
        $(document).ready(function () {
            if (document.getElementById('afterMealRadioButton').checked) {
                document.getElementById('beforeMealRadioButton').checked = false;

            } else {
                document.getElementById('afterMealRadioButton').checked =
                false;

            }

        });
    </script>
</asp:Content>
