<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/MonyetlaDash.Master" AutoEventWireup="true" CodeBehind="LearnerDetails.aspx.cs" Inherits="Monyetla5Web.Pages.LearnerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                   <div id="page-wrapper">

                       <div class="col-lg-12" style="margin-left: 115px; margin-top: 280px; position: relative">
                    <div class="panel panel-primary" >
                        <div class="panel-heading" style="font-weight: bold; text-align: center">
                            Learner Details
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body" runat="server" style="background-color: #FFEFD5">
                            <form runat="server">
                                <div class="form-group">
                                    
                                    <asp:DropDownList ID="drpIDnum" runat="server" class="form-control" width="30%" style="float:left">
                                        
                                    </asp:DropDownList>

                                    <asp:Button runat="server" id="BtnView" type="button" class="btn btn-primary btn-sm" OnClick="BtnView_Click1" text="View" style="float: left; width: 5%"/>

                                </div>
                                <br /><br /><br /><div class="form-group">
                                    <label>First name</label>
                                    <asp:TextBox ID="txtFN" runat="server" class="form-control" placeholder="" type="text" width="30%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Surname</label>
                                    <asp:TextBox ID="txtSN" runat="server" class="form-control" placeholder="" type="text" width="30%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Date of Birth</label>
                                    <asp:TextBox ID="txtDOB" runat="server" class="form-control" placeholder="" type="text" width="23%" readonly="true"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <label>Gender</label>
                                    <asp:TextBox ID="txtGender" runat="server" class="form-control" placeholder="" type="text" width="18%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Population group</label>
                                    <asp:TextBox ID="txtPopG" runat="server" class="form-control" placeholder="" type="text" width="20%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Disability Status</label>
                                    <asp:TextBox ID="txtDisStat" runat="server" class="form-control" placeholder="" type="text" width="25%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Home Language</label>
                                    <asp:TextBox ID="txtHmeLang" runat="server" class="form-control" placeholder="" type="text" width="25%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Phone number</label>
                                    <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="" type="text" width="30%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="" type="email" width="30%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Physical Address</label>
                                    <asp:TextBox ID="txtPhysAd1" runat="server" class="form-control" placeholder="" type="text" width="30%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    
                                    <asp:TextBox ID="txtPhysAd2" runat="server" class="form-control" placeholder="" type="text" width="30%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    
                                    <asp:TextBox ID="txtPhysAd3" runat="server" class="form-control" placeholder="" type="text" width="30%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Postal Code</label>
                                    <asp:TextBox ID="txtPostalC" runat="server" class="form-control" placeholder="" type="text" width="12%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Province</label>
                                    <asp:TextBox ID="txtProv" runat="server" class="form-control" placeholder="" type="text" width="25%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Magisterial District</label>
                                    <asp:TextBox ID="txtMagDist" runat="server" class="form-control" placeholder="" type="text" width="25%" readonly="true"></asp:TextBox>
                                </div>
                               
                                <div class="form-group">
                                    <label>Highest Qualification</label>
                                    <asp:TextBox ID="txtHQual" runat="server" class="form-control" placeholder="" type="text" width="25%" readonly="true"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                    <label>Year Obtained</label>
                                    <asp:TextBox ID="txtYearObt" runat="server" class="form-control" placeholder="" type="text" width="15%" readonly="true"></asp:TextBox>
                                </div>
                                <asp:Button ID="BtnUpload" runat="server" Text="Upload Docs" class="btn btn-primary btn-lg" OnClick="BtnUploadDoc_Click" width="15%"/>
                                    </form>
                                </div>
                                
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>

                       </div>

</asp:Content>
