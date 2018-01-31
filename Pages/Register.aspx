<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/MonyetlaTwo.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Monyetla5Web.Pages.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
            <div class="col-lg-12"style="margin-left: 380px; margin-top: 280px; position: relative; width: 70%">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="font-weight: bold; text-align: center">
                        <h1 class="panel-title">Consortium Registration </h1>
                        <small>Please fill in your Consortium details below</small>
                    </div>
                    <div class="panel-body" style="background-color: #FFEFD5">
                        <form runat="server">
                            
                                <h3>Consortium</h3>
                            <table style="width:100%">
                                <tr>
                                    <td style="width: 15%"><label>Name</label></td>
                                    <td>
                                    <div class="form-group">
                                    <asp:TextBox runat="server" id="txtconsName" class="form-control" placeholder="Enter Consortium Name" name="consName" type="text" width="40%"/>
                                    </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%"><label>Registration number</label></td>
                                    <td>

                                        <div class="form-group">
                                    
                                    <asp:TextBox runat="server" id="txtregNo" class="form-control" placeholder="Enter Registration no" name="regNo" type="text" width="40%"/>
                                </div>

                                    </td>
                                </tr>
                                <tr>

                                    <td style="width: 15%"><label>Physical Address</label></td>
                                    <td>

                                        <div class="form-group">
                                    
                                    <asp:TextBox runat="server" id="txtphysicalAd1" class="form-control" placeholder="Line 1" name="physicalAd1" type="text" width="45%"/>
                                </div>

                                    </td>

                                </tr>
                                <tr>

                                    <td style="width: 15%"> </td>
                                    <td>
                                        <div class="form-group">
                                    
                                    <asp:TextBox runat="server" id="txtphysicalAd2" class="form-control" placeholder="Line 2" name="physicalAd2" type="text" width="45%"/>
                                </div>

                                    </td>
                                </tr>
                                <tr>

                                    <td style="width: 15%"> </td>
                                    <td>
                                    <div class="form-group">
                                    
                                    <asp:TextBox runat="server" id="txtphysicalAd3" class="form-control" placeholder="Line 3" name="physicalAd3" type="text" width="45%"/>
                                </div>

                                    </td>
                                </tr>
                                <tr>

                                    <td style="width: 15%"><label>Postal Code</label></td>
                                    <td>
                                        <div class="form-group">
                                    
                                    <asp:TextBox runat="server" id="txtpostalCode" class="form-control" placeholder="Enter Postal Code" name="postalCode" type="text" width="27%"/>
                                </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%"><label>Site Name</label></td>
                                    <td>
                                        <div class="form-group">
                                    
                                    <asp:TextBox runat="server" id="txtsiteName" class="form-control" placeholder="Enter Site Name" name="siteName" type="text" width="45%"/>
                                </div>

                                    </td>
                                </tr>
                                <tr>

                                    <td style="width: 15%"><label>Site Classification</label></td>
                                    <td>
                                        <div class="form-group">
                                    
                                <asp:DropDownList ID="drpSiteClass" runat="server" class="form-control" width="35%">
                                        
                                </asp:DropDownList>

                                </div>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%"><label>Province</label></td>
                                    <td>
                                <div class="form-group">
                                    
                               <asp:DropDownList ID="drpProvCode" runat="server" class="form-control" width="35%">
                                        
                                </asp:DropDownList>

                                </div>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%"><label>Magisterial District</label></td>
                                    <td>
                                <div class="form-group">
                                    
                                <asp:DropDownList ID="drpMagDist" runat="server" class="form-control" width="35%">
                                        
                                </asp:DropDownList>

                                </div>

                                    </td>
                                </tr>
                                

                                </table>

                               
                                
                            <table style="width:100%">
                                <tr>
                                    <th></th>
                                    <th><h3>Project Manager</h3></th>
                                    <th><h3>Assistant 1</h3></th>
                                    <th><h3>Assistant 2</h3></th>
                                </tr>
                                <tr>
                                    <td style="width: 10%">
                                        <label>First Name</label>
                                    </td>
                                    <td>
                                <div class="form-group">
                                    <asp:TextBox runat="server" id="txtprojectManFirst" class="form-control" placeholder="Enter PM Firstname" name="projectManFirst" type="text" width="95%"/>
                                </div>
                                        </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1FirstN" class="form-control" placeholder="Enter Assistant 1 Firstname" name="assist1FirstN" type="text" width="95%"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2FirstN" class="form-control" placeholder="Enter Assistant 2 Firstname" name="assist2FirstN" type="text" width="95%"/>
                                </div>
                                    </td>
                                    </tr>
                                <tr>
                                    <td style="width: 10%">
                                        <label>Surname</label>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtprojectManSurn" class="form-control" placeholder="Enter PM Surname" name="projectManSurn" type="text" width="95%"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1Surn" class="form-control" placeholder="Enter Assistant 1 Surname" name="assist1Surn" type="text" width="95%"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2Surn" class="form-control" placeholder="Enter Assistant 2 Surname" name="assist2Surn" type="text" width="95%"/>
                                </div>
                                    </td>
                                </tr>
                                 <tr>
                                     <td style="width: 10%">
                                        <label>Phone Number</label>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtprojectManPhone" class="form-control" placeholder="Enter PM Phone No" name="projectManPhone" type="text" width="95%"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1PhoneN" class="form-control" placeholder="Enter Assistant 1 Phone No" name="assist1PhoneN" type="text" width="95%"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2PhoneN" class="form-control" placeholder="Enter Assistant 2 Phone No" name="assist2PhoneN" type="text" width="95%"/>
                                </div>
                                    </td>
                                </tr>
                                 <tr>
                                     <td style="width: 10%">
                                        <label>Cell number</label>
                                    </td>
                                    <td>
                                    <div class="form-group">
                                    <asp:TextBox runat="server" id="txtprojectManCell" class="form-control" placeholder="Enter PM Cell no" name="projectManCell" type="text" width="95%"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1CellN" class="form-control" placeholder="Enter Assistant 1 Cell No" name="assist1CellN" type="text" width="95%"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2CellN" class="form-control" placeholder="Enter Assistant 2 Cell No" name="assist2CellN" type="text" width="95%"/>
                                </div>
                                    </td>
                                </tr>
                                 <tr>
                                     <td style="width: 10%">
                                        <label>Email</label>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtprojectManEmail" class="form-control" placeholder="Enter PM Email" name="projectManEmail" type="text" width="95%"/>
                                </div>
                                    </td>
                                    <td>
                                    <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1Email" class="form-control" placeholder="Enter Assistant 1 Email" name="assist1Email" type="text" width="95%"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2Email" class="form-control" placeholder="Enter Assistant 2 Email" name="assist2Email" type="text" width="95%"/>
                                </div>
                                    </td>
                                </tr>
                                
                                </table>
                            <div style="text-align:center; margin-bottom: 20px; margin-top: 5px">
                                <asp:Label runat="server" class="text-warning" ID="lblPMFirstN" Visible="false" Text="Please enter PM First Name"></asp:Label>
                                <asp:Label runat="server" class="text-warning" ID="lblPMSurname" Visible="false" Text="Please enter PM Surname"></asp:Label>
                                <asp:Label runat="server" class="text-warning" ID="lblPMPhoneNum" Visible="false" Text="Please enter PM Phone number"></asp:Label>
                                <asp:Label runat="server" class="text-warning" ID="lblPMCellNum" Visible="false" Text="Please enter PM Cell number"></asp:Label>
                                <asp:Label runat="server" class="text-warning" ID="lblPMemail" Visible="false" Text="Please enter PM email address"></asp:Label>
                                 <asp:Label runat="server"  class="text-warning" id="lblConsN" visible="false" text="Please enter Consortium Name."></asp:Label>
                                <asp:Label runat="server"  class="text-warning" id="lblAddress" visible="false" text="Please enter Address"></asp:Label>
                                <asp:Label runat="server"  class="text-warning" id="lblPostalC" visible="false" text="Please choose a Postal Code"></asp:Label>
                                <asp:Label runat="server"  class="text-warning" id="lblSiteC" visible="false" text="Please choose a Site Classification"></asp:Label>
                                <asp:Label runat="server"  class="text-warning" id="lblMagNum" visible="false" text="Please choose a Magistarial number"></asp:Label>
                                <asp:Label runat="server"  class="text-warning" id="lblProvinceC" visible="false" text="Please choose a Province code"></asp:Label>
                                <asp:Label ID="lblRegAppr" runat="server" class="alert alert-success" Text="Your registration has been sent for approval." visible="false"></asp:Label>
                            </div>
                               
                            <asp:Button runat="server" id="BtnRegister" type="button" class="btn btn-primary btn-lg" OnClick="BtnRegister_Click1" text="Register" style="float: right; width: 20%"/>
                            <p style="float: right; margin-top: 20px">Already have an account? Click <a href="Index.aspx">here </a>to log in.</p> 
                            
                        </form>
                    </div>
                </div>
                </div>
            
     
       
  
    
    
                           
</asp:Content>
