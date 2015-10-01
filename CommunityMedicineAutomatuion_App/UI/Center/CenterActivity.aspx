<%@ Page Title="" Language="C#" MasterPageFile="~/Center.Master" AutoEventWireup="true" CodeBehind="CenterActivity.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.Center.CenterActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
 
    <div>
    
    <center> <h3 text-align="center">   &nbsp; Welcome to
        <asp:Label ID="centerName" runat="server"></asp:Label>
&nbsp;Center
         </h3></center>
        <p >   &nbsp;</p>
        <br />
       <div class="Menu" style="height: 135px">
       <%-- <a class="btn"  style="margin: 0px 0px 0px 74px;" href="PatientRegistration.aspx">Patient Registration</a>--%>
        <a  style="margin: 0px 0px 0px 74px;" class="btn" href="DoctorEntryUI.aspx">Doctor Entry</a>
        <a  style="margin: 0px 0px 0px 74px;" class="btn" href="MedicineStock.aspx">Medicine Stock</a>
        <a  style="margin: 0px 0px 0px 74px;" class="btn" href="TreatmentGiven.aspx">Treatment Given</a>
        <a  style="margin: 0px 0px 0px 74px;" class="btn" href="ShowPatientAllHistory.aspx">Show Patient All History</a></div><br />
        <br />
        <br />
    
    </div>
  
</asp:Content>
