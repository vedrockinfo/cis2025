<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Plogin.aspx.cs" Inherits="Plogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
  
<head>
<meta charset="utf-8"><link rel="shortcut icon" href="favicon.png"><link rel="shortcut icon" href="favicon.png">
    <title>Online CIS Admission Form</title>

	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes"> 
    
<link href="admissionCSS/css/bootstrap.min.css" rel="stylesheet" type="text/css" />


<link href="admissionCSS/css/font-awesome.css" rel="stylesheet">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet">
    

<link href="admissionCSS/css/pages/signin.css" rel="stylesheet" type="text/css">
		<style>
	    .a hover { text-decoration:none;
	    }
	</style>
</head>

<body>
<p>&nbsp;</p><p>&nbsp;</p>
<div class="account-container">
	
	<div class="content clearfix">
		
			<a class="brand" href="OnlineAdmission1.aspx">
				
                <asp:Image ID="Image1" runat="server" ImageUrl="~/admissionCSS/img/Logo.png"/><br />
               <h2 style="text-decoration:none; color:#000">Online CIS Admission Form	</h2> 			
			</a>

		<hr />


		<form id="aa" runat="server">
		
			<h1 style="text-align:center; line-height:20px">Parent Login</h1>		
			<p  style="text-align:center">Please provide your details</p>
			<br />
			<div class="login-fields">
				
				 <asp:Label ID="lblError" runat="server" style="color: #FF0000" ></asp:Label>
				
				<div class="field">
					<label for="username">Username</label>
					
                    <asp:TextBox ID="txtLogin" runat="server" placeholder="Username" class="login username-field"></asp:TextBox>
				</div> <!-- /field -->
				
				<div class="field">
					<label for="password">Password:</label>
					
                    <asp:TextBox ID="txtPass" runat="server" placeholder="Password" 
                        class="login password-field" TextMode="Password"></asp:TextBox>

				</div> <!-- /password -->
				
			</div> <!-- /login-fields -->
			
			<div class="login-actions">
				
				
               
				
                <asp:Button ID="Button1" runat="server" Text="Sign In" 
                    class="button btn btn-primary btn-large" onclick="Button1_Click" />
									
              
				
			</div> <!-- .actions -->
			
			
			
		</form>
	
	</div> <!-- /content -->
	<hr />
		<div  style="text-align:center;">
								
						<a href="admit.aspx" class="">
							Don't have an account?
						</a>
						
			<br />	<a href="admit.aspx" class="">
							<i class="icon-chevron-left"></i>
							Back to Homepage
						</a>
					
						<br /><br />			
					
						
					
			</div>
</div> <!-- /account-container -->






<script src="admissionCSS/js/jquery-1.7.2.min.js"></script>
<script src="admissionCSS/js/bootstrap.js"></script>

<script src="admissionCSS/js/signin.js"></script>

</body>

</html>