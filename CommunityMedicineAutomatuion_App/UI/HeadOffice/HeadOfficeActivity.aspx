<%@ Page Title="" Language="C#" MasterPageFile="~/HeadOffice.Master" AutoEventWireup="true" CodeBehind="HeadOfficeActivity.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.UI.HeadOffice.HeadOfficeActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    
          
       <div id="adbox">
           <div class="clearfix">
               
                <h3>Head Office Activity</h3>
               <br/>
               <p>
					Head office can create new enrty of Center, New Medicine, Disease and Send Medicine to a Center 
				</p>
               <br/>
               
        <span><a href="CreateDiseaseEntryUI.aspx" class="btn">Disease Entry</a></span> 
       
        <span><a href="CreateNewCenterUI.aspx" class="btn">Center Entry</a></span>
             
        <span><a href="MedicineEntryUI.aspx" class="btn">New Medicine Entry</a></span>
                       
       <span><a href="SendMedicineUI.aspx" class="btn">Send Medicine</a></span>
       <span><a href="AllDiseaseBarChart.aspx" class="btn">All Disease Bar Chart</a></span>
                                          
       
            
             </div>   
        </div>     
      
    
   
              
   
</asp:Content>
