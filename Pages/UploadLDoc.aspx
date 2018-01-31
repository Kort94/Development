<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/MonyetlaDash.Master" AutoEventWireup="true" CodeBehind="UploadLDoc.aspx.cs" Inherits="Monyetla5Web.Pages.UploadLDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                   <div id="page-wrapper">

                       <div class="col-lg-12" style="margin-left: 115px; margin-top: 280px; position: relative">
                    <div class="panel panel-primary" >
                        <div class="panel-heading" style="font-weight: bold; text-align: center">
                            Upload Documents
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body" runat="server" style="background-color: #FFEFD5">
                            <form runat="server">
                                <div class="form-group">
                                    <label>ID Number</label>
                                    <asp:TextBox ID="txtIDnum" runat="server" class="form-control" placeholder="Enter ID Number" type="text" width="25%" readonly="true"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <label>First name</label>
                                    <asp:TextBox ID="txtFN" runat="server" class="form-control" placeholder="Enter First Name" type="text" width="30%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Surname</label>
                                    <asp:TextBox ID="txtSN" runat="server" class="form-control" placeholder="Enter Surname" type="text" width="30%" readonly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                            <label>File input</label>
                                            
                                        <asp:fileupload ID="FileUploadControl" name="FileUploadControl" runat="server"></asp:fileupload>
                                </div>

                                <div style="text-align:center; margin-bottom: 20px; margin-top: 5px">
                                
                        <asp:Label runat="server"  class="text-warning" id="lblEx" visible="true" text=""></asp:Label>
                        <asp:Label ID="lblUpState" runat="server" class="alert alert-success" Text="File uploaded successfully." visible="false" style="float:right"></asp:Label>
                                    <asp:Label ID="lblNFile" runat="server" class="text-warning" Text="Please select a file to upload." visible="false" style="float:right"></asp:Label>
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
