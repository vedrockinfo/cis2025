<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admit.aspx.cs" Inherits="admit" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
        <!DOCTYPE html
            PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

        <html lang="en">

        <head id="Head1" runat="server">
            <!-- Required meta tags -->
            <meta charset="utf-8">
            <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

            <title>Admissions Registration Form for 2024-25</title>
            <!-- plugins:css -->
            <!-- <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
                integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"
                crossorigin="anonymous"> -->
            <link rel="icon" href="images/favicon.png" type="image/x-icon">
            <!-- StyleSheet CDN -->
            <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet">
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.0/animate.min.css">
            <!-- Bootstrap CSS  -->
            <link rel="stylesheet" href="assets/vendor/css/bootstrap.min.css">
            <!-- jQuery UI CSS -->
            <link rel="stylesheet" href="assets/vendor/css/jquery-ui.min.css">
            <!-- OwlCarousel CSS -->
            <link rel="stylesheet" href="assets/vendor/css/owl.carousel.min.css">
            <link rel="stylesheet" href="assets/vendor/css/owl.theme.default.css">
            <!-- THeme CSS -->
            <link rel="stylesheet" href="assets/css/main.min.css">
            <!-- Google CSS -->

            <style type="text/css">
                .fees-dir.d-lg-flex {
                    gap: 15px;
                    justify-content: flex-end;
                }

                #blur {
                    width: 100%;
                    position: fixed;
                    z-index: 99;
                    top: 0px;
                    left: 0px;
                    background-color: #FFFFFF;
                    width: 100%;
                    height: 100%;
                    filter: Alpha(Opacity=70);
                    opacity: 0.70;
                    -moz-opacity: 0.70;
                }

                #progress {
                    z-index: 500;
                    top: 60%;
                    left: 50%;
                    position: absolute;
                    padding: 5px 5px 5px 5px;
                    text-align: center;

                }

                label {
                    font-size: 12px;
                    color: #0463a8;
                }

                .santosh {
                    display: inline-block;
                    font-weight: normal;
                    line-height: 1.25;
                    text-align: center;
                    white-space: nowrap;
                    vertical-align: middle;
                    -webkit-user-select: none;
                    -moz-user-select: none;
                    -ms-user-select: none;
                    user-select: none;
                    border: 1px solid transparent;
                    padding: 1rem 2rem;
                    font-size: 14px;
                    border-radius: 0.25rem;
                    -webkit-transition: all 0.2s ease-in-out;
                    -o-transition: all 0.2s ease-in-out;
                    transition: all 0.2s ease-in-out;
                }

                label {
                    padding-top: 20px;
                }

                .drop {
                    display: block;
                    width: 100%;
                    height: 33px;

                    font-size: 12px;
                    line-height: 1.25;
                    color: #464a4c;
                    background-color: #fff;
                    background-image: none;
                    -webkit-background-clip: padding-box;
                    background-clip: padding-box;
                    border: 1px solid rgba(0, 0, 0, 0.15);
                    border-radius: 0.25rem;
                    -webkit-transition: border-color ease-in-out 0.15s, -webkit-box-shadow ease-in-out 0.15s;
                    transition: border-color ease-in-out 0.15s, -webkit-box-shadow ease-in-out 0.15s;
                    -o-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
                    transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
                    transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s, -webkit-box-shadow ease-in-out 0.15s;
                }
            </style>
            <style>
                .admissionFrom2025 {
                    display: grid;
                    grid-template-columns: 300px calc(100% - 300px);
                    border-radius: 1.6rem;
                    overflow: hidden;
                    box-shadow: 0 4px 12px #cfcccc;
                }

                .admissionFrom2025 .headingPrimary{
                    margin-bottom: 0;
                }
                .admissionFrom2025 .applyImage img {
                    height: 100%;
                    width: 100%;
                    object-fit: cover;
                    object-position: 25% 100%;
                }

                .admissionFrom2025 .applyForm {
                    padding: 2rem 4rem;
                }

                .applyImage .fees-dir {
                    position: absolute;
                    top: 50%;
                    transform: translate(-50%, -50%);
                    left: 50%;
                    text-align: center;
                    display: grid;
                    gap: 10px;
                }

                .applyImage {
                    position: relative;
                }

                .applyImage .fees-dir a {
                    background: #fff;
                    color: #19649c;
                    padding: 12px;
                    font-size: 1.4rem;
                    width: 21rem;
                    border-radius: 5px;
                    text-transform: uppercase;
                    display: inline-block;
                    font-weight: 600;
                    transition: all 0.4s;
                }

                .applyImage .fees-dir a:hover {
                    background: #19649c;
                    color: #fff;
                }

                .santosh{
                    background: #19649c;
                    color: #fff;
                    padding: 12px 25px;
                    font-size: 1.4rem;
                    width: 21rem;
                    border-radius: 5px;
                    text-transform: uppercase;
                    display: inline-block;
                    font-weight: 600;
                    transition: all 0.4s;
                }
                .sa {
                        margin-bottom: 20px;
                        text-align: right;
                    }
                    .sa a{
                        color: #19649c;
                        font-weight: bold;
                        text-transform: uppercase;
                        font-size: 14px;
                        text-decoration: underline;
                        text-underline-position: below;
                    }


                @media screen and (max-device-width: 640px) {
                    .download-offline {
                        text-align: center;
                    }

                    .sa {
                        margin-top: 20px;
                        text-align: center;
                        border-top: 1px solid #e5e2e2
                    }

                    .manish {
                        display: none;
                    }

                }
            </style>






        </head>

        <body>
            <form runat="server" id="form2">

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>


                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="container p-3">
                            <div class="admissionFrom2025">
                                <div class="applyImage">
                                    <img src="images/bg/social-videis-bg-01.jpg" alt="" class="img-fluid">
                                    <div class="fees-dir">
                                        <div class="download-offline"> <a href="fee-structure.html" target="_blank"
                                                class="btn">Fee Structure</a></div>
                                        <div class="download-offline"> <a
                                                href="pdf/CIS-Manas-City-Admission-Form.pdf"
                                                target="_blank" class="btn">Download, Print & Fill</a></div>
                                    </div>
                                </div>
                                <div class="applyForm order-first order-md-1">
                                    <div class="loginArea">
                                        <div class="sa"><a href="plogin.aspx">
                                                Already have Login? </a>
                                            New Registration, please fill here</div>

                                    </div>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <div class="col-md-12" style="text-align:right">

                                        </div>
                                        <h2 class="headingPrimary">
                                            Admission Form 2025-26
                                        </h2>
                                        <div class="row">

                                            <div class="col-sm-12">
                                                <label>
                                                    Prime Contact <asp:Label ID="Label1" runat="server" ForeColor="Red"
                                                        Text="*"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                                        runat="server" ControlToValidate="drpPrime"
                                                        ErrorMessage="Select Prime Contact" ForeColor="Red"
                                                        SetFocusOnError="True" InitialValue="0" ValidationGroup="aa">
                                                    </asp:RequiredFieldValidator>

                                                </label>

                                                <asp:DropDownList ID="drpPrime" runat="server" CssClass="drop">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem>Father</asp:ListItem>
                                                    <asp:ListItem>Mother</asp:ListItem>
                                                    <asp:ListItem>Guardian</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>





                                            <div class="col-sm-4">

                                                <label>
                                                    First Name<asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                        runat="server" ControlToValidate="txtFName" ErrorMessage="*"
                                                        ForeColor="Red" Display="None" SetFocusOnError="True"
                                                        ValidationGroup="aa"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*">
                                                    </asp:Label>
                                                </label>

                                                <asp:TextBox ID="txtFName" runat="server" CssClass="form-control">
                                                </asp:TextBox>


                                            </div>
                                            <div class="col-sm-4">

                                                <label>
                                                    Middle Name
                                                </label>

                                                <asp:TextBox ID="txtMName" runat="server" CssClass="form-control">
                                                </asp:TextBox>

                                            </div>
                                            <div class="col-sm-4">

                                                <label>
                                                    Last Name<asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                                        runat="server" ControlToValidate="txtLName" ErrorMessage="*"
                                                        ForeColor="Red" Display="None" SetFocusOnError="True"
                                                        ValidationGroup="aa"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="*">
                                                    </asp:Label>
                                                </label>

                                                <asp:TextBox ID="txtLName" runat="server" CssClass="form-control">
                                                </asp:TextBox>


                                            </div>


                                            <div class="col-md-4">

                                                <label>
                                                    Country
                                                </label>


                                                <asp:DropDownList ID="drpCountry" runat="server" CssClass="drop"
                                                    AutoPostBack="True"
                                                    onselectedindexchanged="drpCountry_SelectedIndexChanged"
                                                    ForeColor="Black" Enabled="False">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="drpCountry" ErrorMessage="Please Select Country"
                                                    ForeColor="Red" SetFocusOnError="True" Display="None"
                                                    ValidationGroup="aa" InitialValue="0"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="col-md-4">

                                                <label>
                                                    State
                                                </label>


                                                <asp:DropDownList ID="drpState" runat="server" CssClass="drop"
                                                    ForeColor="Black" AutoPostBack="True"
                                                    onselectedindexchanged="drpState_SelectedIndexChanged"
                                                    Enabled="False">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    ControlToValidate="drpState" ErrorMessage="Please Select State"
                                                    ForeColor="Red" SetFocusOnError="True" Display="None"
                                                    ValidationGroup="aa" InitialValue="0"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="col-md-4">

                                                <label>
                                                    City
                                                </label>

                                                <asp:DropDownList ID="drpCity" runat="server" CssClass="drop"
                                                    ForeColor="Black">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    ControlToValidate="drpCity" ErrorMessage="Please Select City"
                                                    ForeColor="Red" SetFocusOnError="True" Display="None"
                                                    ValidationGroup="aa" InitialValue="0"></asp:RequiredFieldValidator>


                                            </div>


                                            <div class="col-md-4">

                                                <label>
                                                    Email<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                        runat="server" ControlToValidate="txtEmail"
                                                        ErrorMessage="Please Enter email" ForeColor="Red"
                                                        SetFocusOnError="True" Display="None" ValidationGroup="aa">
                                                    </asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator91"
                                                        runat="server" ControlToValidate="txtEmail" Display="None"
                                                        ErrorMessage="Plese fill valid Email" SetFocusOnError="True"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        ValidationGroup="aa"></asp:RegularExpressionValidator>

                                                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*">
                                                    </asp:Label>
                                                </label>

                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                                                    placeHolder="Email"></asp:TextBox>

                                            </div>
                                            <div class="col-xs-2 col-md-2" style="display:none">

                                                <label>
                                                    Country Code
                                                </label>

                                                <asp:DropDownList ID="drpMobileCountry" runat="server"
                                                    CssClass="form-control" Height="33" Enabled="False">
                                                </asp:DropDownList>

                                            </div>

                                            <div class="col-xs-4 col-sm-4">
                                                <label>Mobile No.
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                        runat="server" ControlToValidate="txtMobile" ErrorMessage="*"
                                                        ForeColor="Red" Display="None" SetFocusOnError="True"
                                                        ValidationGroup="aa">
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:FilteredTextBoxExtender ID="txtContact_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="txtMobile"
                                                        ValidChars="0123456789">
                                                    </cc1:FilteredTextBoxExtender>

                                                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*">
                                                    </asp:Label>

                                                </label>
                                                <asp:TextBox ID="txtMobile" MaxLength="10" runat="server"
                                                    CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-md-4">

                                                <label>
                                                    Admission Sought For <span style="font-size:10px"> (Number of
                                                        Children)</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                        runat="server" ControlToValidate="txtNoOfChildren"
                                                        ErrorMessage="*" ForeColor="Red" Display="None"
                                                        SetFocusOnError="True" ValidationGroup="aa">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*">
                                                    </asp:Label>
                                                </label>

                                                <asp:TextBox ID="txtNoOfChildren" MaxLength="2" runat="server"
                                                    CssClass="form-control" AutoPostBack="True"
                                                    ontextchanged="txtNoOfChildren_TextChanged"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                    runat="server" Enabled="True" TargetControlID="txtNoOfChildren"
                                                    ValidChars="0123456789">
                                                </cc1:FilteredTextBoxExtender>



                                            </div>





                                            <div class="col-sm-12 table-responsive">
                                                <br />
                                                <div id="bb" runat="server">
                                                    <asp:GridView ID="GridView1" runat="server"
                                                        AutoGenerateColumns="False" Width="100%"
                                                        CssClass="table-bordered">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No."
                                                                ControlStyle-Width="10px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblsno" runat="server"
                                                                        Text='<%# Bind("sno") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ControlStyle />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="First Name*"
                                                                ControlStyle-Width="100%">
                                                                <ItemTemplate>

                                                                    <asp:TextBox ID="txtStuFName" runat="server"
                                                                        CssClass="form-control" ForeColor="Black">
                                                                    </asp:TextBox>
                                                                    <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator40" runat="server"
                                                                        ControlToValidate="txtStuFName" ErrorMessage="*"
                                                                        ForeColor="Red" Display="None"
                                                                        SetFocusOnError="True" ValidationGroup="aa">
                                                                    </asp:RequiredFieldValidator>

                                                                </ItemTemplate>
                                                                <ControlStyle />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Middle Name"
                                                                ControlStyle-Width="100px" Visible="False">
                                                                <ItemTemplate>

                                                                    <asp:TextBox ID="txtStuMName" runat="server"
                                                                        CssClass="form-control" ForeColor="Black">
                                                                    </asp:TextBox>

                                                                </ItemTemplate>
                                                                <ControlStyle />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Last Name"
                                                                ControlStyle-Width="100px" Visible="False">
                                                                <ItemTemplate>


                                                                    <asp:TextBox ID="txtStuLName" runat="server"
                                                                        CssClass="form-control" ForeColor="Black">
                                                                    </asp:TextBox>

                                                                </ItemTemplate>
                                                                <ControlStyle />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date of Birth*"
                                                                ControlStyle-Width="60px">
                                                                <ItemTemplate>

                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpYY"
                                                                                    runat="server" CssClass="drop"
                                                                                    ForeColor="Black"
                                                                                    AutoPostBack="True"
                                                                                    onselectedindexchanged="drpYY_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpMM"
                                                                                    runat="server" CssClass="drop"
                                                                                    ForeColor="Black"
                                                                                    AutoPostBack="True"
                                                                                    onselectedindexchanged="drpMM_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="drpDD"
                                                                                    runat="server" CssClass="drop">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>





                                                                </ItemTemplate>
                                                                <ControlStyle Width="60px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Class*#"
                                                                ControlStyle-Width="80px">
                                                                <FooterTemplate>
                                                                    &nbsp;
                                                                </FooterTemplate>
                                                                <ItemTemplate>


                                                                    <asp:DropDownList ID="drpClass" runat="server"
                                                                        CssClass="drop" ForeColor="Black">
                                                                        <asp:ListItem Value="0">--Select Class--
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000001">Playgroup
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000001">Montessori
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000001">Nursery
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000001">KG</asp:ListItem>
                                                                        <asp:ListItem Value="000002">Class 1
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000003">Class 2
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000004">Class 3
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000005">Class 4
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000006">Class 5
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000007">Class 6
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000008">Class 7
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000009">Class 8
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000010">Class 9
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000011">Class 10
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000012">Class 11
                                                                        </asp:ListItem>
                                                                        <asp:ListItem Value="000013">Class 12
                                                                        </asp:ListItem>

                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator31" runat="server"
                                                                        ControlToValidate="drpClass" ErrorMessage="*"
                                                                        ForeColor="Red" SetFocusOnError="True"
                                                                        Display="None" InitialValue="0"
                                                                        ValidationGroup="aa">
                                                                    </asp:RequiredFieldValidator>

                                                                </ItemTemplate>
                                                                <ControlStyle />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Gender*"
                                                                ControlStyle-Width="80px" Visible="False">
                                                                <ItemTemplate>

                                                                    <asp:DropDownList ID="ddlGender" runat="server"
                                                                        CssClass="drop" ForeColor="Black">
                                                                        <asp:ListItem>Gender</asp:ListItem>
                                                                        <asp:ListItem>Male</asp:ListItem>
                                                                        <asp:ListItem>Female</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator32" runat="server"
                                                                        ControlToValidate="ddlGender" ErrorMessage="*"
                                                                        ForeColor="Red" SetFocusOnError="True"
                                                                        Display="None" InitialValue="0"
                                                                        ValidationGroup="aa">
                                                                    </asp:RequiredFieldValidator>


                                                                </ItemTemplate>
                                                                <ControlStyle Width="80px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" #*"
                                                                ControlStyle-Width="40px" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label13" runat="server"
                                                                        Text="&#8377 700/-">
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                                <ControlStyle Width="40px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    &nbsp;<span style="font-size:12px">#Class for which admission is
                                                        sought &nbsp; #* Registration fee per child is &#8377 700.
                                                    </span>
                                                </div>
                                            </div>







                                            <div class="col-md-4">

                                                <label>
                                                    Campus Preference 1<asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator6" runat="server"
                                                        ControlToValidate="drpCampus1" ErrorMessage="*" ForeColor="Red"
                                                        InitialValue="0" SetFocusOnError="True" ValidationGroup="aa">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*">
                                                    </asp:Label>
                                                </label>

                                                <asp:DropDownList ID="drpCampus1" runat="server" CssClass="drop"
                                                    ForeColor="Black">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="000003">CIS Manas City, Indira Nagar (PG-12)
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="000050">CIS (Cambridge), Balaganj (PG-8)
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="000132">CIS Shakti Nagar (PG-8)</asp:ListItem>

                                                    <asp:ListItem Value="000131 ">CIS Gomti Nagar, Gomti Nagar Extension
                                                        (PG-5)</asp:ListItem>
                                                    <%-- <asp:ListItem Value="000142">CIS Mini Planet, Virat Khand,
                                                        Gomti Nagar (Toddlers, PG, LKG, UKG)</asp:ListItem>--%>
                                                        <asp:ListItem Value="000123">CIS Chandrahaas Palace, Hathondha,
                                                            Barabanki (PG-8)</asp:ListItem>
                                                        <asp:ListItem Value="000145">CIS Pratap Nagar Jaipur (PG-10)
                                                        </asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server"
                                                    ControlToValidate="drpCampus1" ErrorMessage="*" ForeColor="Red"
                                                    SetFocusOnError="True" Display="None" InitialValue="0"
                                                    ValidationGroup="aa">
                                                </asp:RequiredFieldValidator>

                                            </div>
                                            <div class="col-md-4">

                                                <label>
                                                    Campus Preference 2</label>
                                                <asp:DropDownList ID="drpCampus2" runat="server" CssClass="drop"
                                                    ForeColor="Black">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="000003">CIS Manas City, Indira Nagar (PG-12)
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="000050">CIS (Cambridge), Balaganj (PG-8)
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="000132">CIS Shakti Nagar (PG-8)</asp:ListItem>

                                                    <asp:ListItem Value="000131 ">CIS Gomti Nagar, Gomti Nagar Extension
                                                        (PG-5)</asp:ListItem>
                                                    <%-- <asp:ListItem Value="000142">CIS Mini Planet, Virat Khand,
                                                        Gomti Nagar (Toddlers, PG, LKG, UKG)</asp:ListItem>--%>
                                                        <asp:ListItem Value="000123">CIS Chandrahaas Palace, Hathondha,
                                                            Barabanki (PG-8)</asp:ListItem>
                                                        <asp:ListItem Value="000145">CIS Pratap Nagar Jaipur (PG-10)
                                                        </asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>


                                            <div class="col-md-4">

                                                <label>
                                                    Campus Preference 3

                                                </label>

                                                <asp:DropDownList ID="drpCampus3" runat="server" CssClass="drop"
                                                    ForeColor="Black">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="000003">CIS Manas City, Indira Nagar (PG-12)
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="000050">CIS (Cambridge), Balaganj (PG-8)
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="000132">CIS Shakti Nagar (PG-8)</asp:ListItem>
                                                    <asp:ListItem Value="000131 ">CIS Gomti Nagar, Gomti Nagar Extension
                                                        (PG-5)</asp:ListItem>
                                                    <%-- <asp:ListItem Value="000142">CIS Mini Planet, Virat Khand,
                                                        Gomti Nagar (Toddlers, PG, LKG, UKG)</asp:ListItem>--%>
                                                        <asp:ListItem Value="000123">CIS Chandrahaas Palace, Hathondha,
                                                            Barabanki (PG-8)</asp:ListItem>
                                                        <asp:ListItem Value="000145">CIS Pratap Nagar Jaipur (PG-10)
                                                        </asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>


                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <br />
                                                <asp:Label ID="lblscsid" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lblSurveyId" runat="server" Visible="False"></asp:Label>

                                                <asp:Button ID="Button2" runat="server" Text="Submit"
                                                    class="santosh btn-primary mb-2" ValidationGroup="aa"
                                                    onclick="Button2_Click" />
                                                <asp:Label ID="lbl_messageNext" runat="server" ForeColor="Chocolate">
                                                </asp:Label>
                                            </div>
                                        </div>
                                </div>





                                </asp:Panel>

                                <asp:Panel ID="Panel2" runat="server">
                                    <div class="content-wrapper">
                                        <div class="row">
                                            <div class="col-12 grid-margin">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="row">

                                                            <div class="col-md-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-12 col-form-label">
                                                                        &nbsp;&nbsp; Enter OTP
                                                                        <asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator12" runat="server"
                                                                            ControlToValidate="txtOTP" ErrorMessage="*"
                                                                            ForeColor="Red" Display="None"
                                                                            SetFocusOnError="True" ValidationGroup="bb">
                                                                        </asp:RequiredFieldValidator>
                                                                        <asp:Label ID="Label12" runat="server"
                                                                            ForeColor="Red" Text="*"> </asp:Label>
                                                                        <br />
                                                                    </label>
                                                                    <div class="col-sm-12">
                                                                        <asp:TextBox ID="txtOTP" runat="server"
                                                                            CssClass="form-control"
                                                                            Placeholder="Enter OTP"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <br />
                                                                        <asp:LinkButton ID="LinkButton1" runat="server"
                                                                            onclick="LinkButton1_Click"
                                                                            style="padding-left:10px;">Resend OTP
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <asp:Button ID="Button1" runat="server"
                                                                class="btn btn-primary mb-2" onclick="Button1_Click"
                                                                Text="Submit" ValidationGroup="aa" Width="100%" />
                                                            <br />
                                                            <asp:Label ID="lbl_message" runat="server"
                                                                ForeColor="chocolate"></asp:Label>
                                                            <asp:LinkButton ID="LinkButton2" runat="server"
                                                                style="padding-left:10px;" onclick="LinkButton2_Click">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;Back</asp:LinkButton>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="Panel3" runat="server">
                                    <div class="content-wrapper">
                                        <div class="row">
                                            <div class="col-12 grid-margin">
                                                <div class="card">
                                                    <div class="card-body">

                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="form-group row">
                                                                    <br />
                                                                    <label class="col-sm-12 col-form-label">
                                                                        <%--Payment Process--%><br />

                                                                            <br />
                                                                    </label>
                                                                    <div class="col-sm-1">

                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnPayment" runat="server"
                                                                            Text="&nbsp;&nbsp;Continue to pay registration fee of Rs 700 per child."
                                                                            class="btn btn-primary mb-2"
                                                                            onclick="btnPayment_Click" />
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                </asp:Panel>


                                <asp:Panel ID="Panel4" runat="server">
                                    <div class="content-wrapper">
                                        <div class="row">
                                            <div class="col-12 grid-margin">
                                                <div class="card">
                                                    <div class="card-body">

                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="form-group row">
                                                                    <br />

                                                                    <div class="col-sm-12">

                                                                        <asp:Label ID="lblMEss" runat="server"
                                                                            Text="Label"></asp:Label>
                                                                        <asp:Button ID="Button4" runat="server"
                                                                            Text="Home" class="santosh btn-primary mb-2"
                                                                            onclick="Button4_Click" />
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                </asp:Panel>

                            </div>

                        </div>







                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div id="blur">
                            &nbsp;</div>
                        <div id="progress">
                            <img alt="" src="images1/ajax-loader.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>



            </form>
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"
                integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM"
                crossorigin="anonymous"></script>
        </body>

        </html>