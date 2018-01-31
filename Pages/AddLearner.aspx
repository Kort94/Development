<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/MonyetlaDash.Master" AutoEventWireup="true" CodeBehind="AddLearner.aspx.cs" Inherits="Monyetla5Web.Pages.AddLearner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                   <div id="page-wrapper">

                       <div class="col-lg-12" style="margin-left: 115px; margin-top: 280px; position: relative">
                    <div class="panel panel-primary" >
                        <div class="panel-heading" style="font-weight: bold; text-align: center">
                            Add new learner
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body" runat="server" style="background-color: #FFEFD5">
                            <form runat="server">
                                <div class="form-group">
                                    <label>ID Number</label>
                                    <asp:TextBox ID="txtIDnum" runat="server" class="form-control" placeholder="Enter ID Number" type="text" width="25%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>First name</label>
                                    <asp:TextBox ID="txtFN" runat="server" class="form-control" placeholder="Enter First Name" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Surname</label>
                                    <asp:TextBox ID="txtSN" runat="server" class="form-control" placeholder="Enter Surname" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Date of Birth</label>
                                    <asp:TextBox ID="txtDOB" runat="server" class="form-control" placeholder="Enter Date of Birth (YYYY-MM-DD)" type="text" width="23%"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <label>Gender</label>
                                    <asp:DropDownList ID="drpGender" runat="server" class="form-control" width="15%">
                                        <asp:ListItem Text="--Select Gender--" Value="0" />
                                        <asp:ListItem Text="Male" Value="M" />
                                        <asp:ListItem Text="Female" Value="F" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Population group</label>
                                    <asp:DropDownList ID="drpPopG" runat="server" class="form-control" width="25%">
                                        <asp:ListItem Text="--Select Race--" Value="0" />
                                        <asp:ListItem Text="African" Value="A" />
                                        <asp:ListItem Text="White" Value="W" />
                                        <asp:ListItem Text="Coloured" Value="C" />
                                        <asp:ListItem Text="Indian" Value="I" />
                                        <asp:ListItem Text="Other" Value="O" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Disability Status</label>
                                    <asp:DropDownList ID="drpDisSt" runat="server" class="form-control" width="25%">
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Home Language</label>
                                    <asp:DropDownList ID="drpHmeLang" runat="server" class="form-control" width="25%">
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Phone number</label>
                                    <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="Enter phone number" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter email address" type="email" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Physical Address</label>
                                    <asp:TextBox ID="txtPhysAd1" runat="server" class="form-control" placeholder="Line 1" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    
                                    <asp:TextBox ID="txtPhysAd2" runat="server" class="form-control" placeholder="Line 2" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    
                                    <asp:TextBox ID="txtPhysAd3" runat="server" class="form-control" placeholder="Line 3" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Postal Code</label>
                                    <asp:TextBox ID="txtPostalC" runat="server" class="form-control" placeholder="Enter Postal Code" type="text" width="12%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Province</label>
                                    <asp:DropDownList ID="drpProv" runat="server" class="form-control" width="25%">
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Magisterial District</label>
                                    <asp:DropDownList ID="drpMagDist" runat="server" class="form-control" width="25%">
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Address Classification</label>
                                    <asp:DropDownList ID="drpAdClass" runat="server" class="form-control" width="25%">
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Highest Qualification</label>
                                    <asp:DropDownList ID="drpHighQual" runat="server" class="form-control" width="25%">
                                        
                                    </asp:DropDownList>
                                </div>
                                 <div class="form-group">
                                    <label>Year Obtained</label>
                                    <asp:TextBox ID="txtYearObt" runat="server" class="form-control" placeholder="Enter Year (YYYY)" type="text" width="15%"></asp:TextBox>
                                </div>

                                <div style="text-align:center; margin-bottom: 20px; margin-top: 5px">
                                <asp:Label runat="server"  class="text-warning" id="lblField" visible="false" text="Please enter all required fields."></asp:Label>
                        <asp:Label runat="server"  class="text-warning" id="lblID" visible="false" text="Please enter a valid SA ID."></asp:Label>
                        <asp:Label ID="lblAdState" runat="server" class="alert alert-success" Text="Learner has been added successfully." visible="false" style="float:right"></asp:Label>
                                </div>
                                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" class="btn btn-primary btn-lg" OnClick="BtnSubmit_Click" width="10%"/>
                                    </form>
                                </div>
                                
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>

                       </div>

</asp:Content>
