<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/MonyetlaDash.Master" AutoEventWireup="true" CodeBehind="EnrollLearner.aspx.cs" Inherits="Monyetla5Web.Pages.EnrollLearner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                   <div id="page-wrapper">

                       <div class="col-lg-12" style="margin-left: 115px; margin-top: 280px; position: relative">
                    <div class="panel panel-primary" >
                        <div class="panel-heading" style="font-weight: bold; text-align: center">
                            Enroll Learner to course
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body" runat="server" style="background-color: #FFEFD5">
                            <form runat="server">
                                <div class="form-group">
                                    <label>Course Name</label>
                                    <asp:DropDownList ID="drpName" runat="server" class="form-control" width="20%">
                                                                          
                                    </asp:DropDownList>
                                    
                                </div>
                                <div class="form-group">
                                    <label>Start Date</label>
                                    <asp:DropDownList ID="drpStartD" runat="server" class="form-control" width="25%">
                                                                          
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Learner ID no</label>
                                    <asp:DropDownList ID="drpSAID" runat="server" class="form-control" width="25%">
                                                                          
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Training Completion Status</label>
                                    <asp:DropDownList ID="drpCourseStat" runat="server" class="form-control" width="15%">
                                        
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Status Reason</label>
                                <textarea id="txtReason" class="form-control" cols="5" rows="2" name="txtReason"></textarea>
                                    </div>

                                <div style="text-align:center; margin-bottom: 20px; margin-top: 5px">
                                    <asp:Label runat="server"  class="text-warning" id="lblField" visible="false" text="Please enter all required fields."></asp:Label>
                        <asp:Label runat="server"  class="text-warning" id="lblID" visible="false" text="Please enter a valid SA ID."></asp:Label>
                        <asp:Label ID="lblAdState" runat="server" class="alert alert-success" Text="Learner has been enrolled to course successfully." visible="false" style="float:right"></asp:Label>
                                    </div>

                                <asp:Button ID="BtnEnroll" runat="server" Text="Enroll" class="btn btn-primary btn-lg" OnClick="BtnEnroll_Click" width="10%"/>

                                    </form>
                            
                                
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
               </div>

                       </div>
                       </div>

</asp:Content>
