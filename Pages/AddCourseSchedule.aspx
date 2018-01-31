<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/MonyetlaDash.Master" AutoEventWireup="true" CodeBehind="AddCourseSchedule.aspx.cs" Inherits="Monyetla5Web.Pages.AddCourseSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                   <div id="page-wrapper">

                       <div class="col-lg-12" style="margin-left: 115px; margin-top: 280px; position: relative">
                    <div class="panel panel-primary" >
                        <div class="panel-heading" style="font-weight: bold; text-align: center">
                            Add Course Schedule
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body" runat="server" style="background-color: #FFEFD5">
                            <form runat="server">
                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:DropDownList ID="drpName" runat="server" class="form-control" width="20%">
                                                                          
                                    </asp:DropDownList>
                                    
                                </div>
                                <div class="form-group">
                                    <label>Start Date</label>
                                    <asp:TextBox ID="txtSTD" runat="server" class="form-control" placeholder="Enter Start Date (YYYY/MM/DD)" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>End Date</label>
                                    <asp:TextBox ID="txtED" runat="server" class="form-control" placeholder="Enter End Date (YYYY/MM/DD)" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Schedule Status</label>
                                    <asp:DropDownList ID="drpShedStat" runat="server" class="form-control" width="15%">
                                        
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Consortium Site</label>
                                    <asp:DropDownList ID="drpConsSite" runat="server" class="form-control" width="15%">
                                        
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Instructor First name</label>
                                    <asp:TextBox ID="txtIFN" runat="server" class="form-control" placeholder="Enter First name" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Instructor Surname</label>
                                    <asp:TextBox ID="txtISN" runat="server" class="form-control" placeholder="Enter Surname" type="text" width="30%"></asp:TextBox>
                                </div>

                                <div style="text-align:center; margin-bottom: 20px; margin-top: 5px">
                                    <asp:Label runat="server"  class="text-warning" id="lblField" visible="false" text="Please enter all required fields."></asp:Label>
                        <asp:Label runat="server"  class="text-warning" id="lblID" visible="false" text="Please enter a valid SA ID."></asp:Label>
                        <asp:Label ID="lblAdState" runat="server" class="alert alert-success" Text="Course has been scheduled successfully." visible="false" style="float:right"></asp:Label>
                                    </div>

                                <asp:Button ID="BtnSchedule" runat="server" Text="Schedule" class="btn btn-primary btn-lg" OnClick="BtnSchedule_Click" width="10%"/>

                                    </form>
                                </div>
                                
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>

                       </div>

</asp:Content>
