<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CenterLoginUI.aspx.cs" Inherits="CommunityMedicineAutomatuion_App.CenterLoginUI" %>


<!DOCTYPE HTML>
<!-- Website template by freewebsitetemplates.com -->
<html>
<head>
	<meta charset="UTF-8">
	<title>Community Medicine Automation</title>   
	<link rel="stylesheet" href="css/style.css" type="text/css">
</head>
<body>
	<form id="form1" runat="server">
	<div id="header">
		<div>
			<div class="logo">
				<a href="index.aspx">Community Medicine </a>
			</div>
			<ul id="navigation">
				<li class="active">
					<a href="index.aspx">Home</a>
				</li>
				<li>
					<a href="UI/HeadOffice/HeadOfficeActivity.aspx">Head Office Activity</a>
				</li>
				<li>
					<a href="UI/Center/CenterActivity.aspx">Center Activity</a>
				</li>
				
				
			</ul>
		</div>
	</div>
	<div id="adbox">
		<div class="clearfix">
			<img src="images/treatment.PNG" alt="Img" height="342" width="368">
			<div>
				<h1>Center Login</h1>
				<br/>
				 <div>
    <h2>&nbsp;</h2>
        <p>
            Center Code
        &nbsp;<asp:TextBox ID="codeTextBox" runat="server"></asp:TextBox>
        
        </p>
                     <p>
                         &nbsp;</p>
        <p>
            &nbsp;Password&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        </p>
                     <p>
                         &nbsp;</p>
        <p>
            <asp:Button ID="loginButton" runat="server" Text="Log In" OnClick="loginButton_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="backButton" runat="server"  Text="Back" OnClick="backButton_Click" />
    <asp:Label ID="labelAuthentication" runat="server"></asp:Label>
        </p>
        
    </div><br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
			</div>
		</div>
	</div>
	
	<div id="footer">
		<div class="clearfix">
			
			<p>
				© TourisT. All Rights Reserved.
			</p>
		</div>
	</div>
    </form>
</body>
</html>
