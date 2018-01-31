<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/MonyetlaDash.Master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="Monyetla5Web.Pages.AddCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                   <div id="page-wrapper">

                       <div class="col-lg-12" style="margin-left: 115px; margin-top: 280px; position: relative">
                    <div class="panel panel-primary" >
                        <div class="panel-heading" style="font-weight: bold; text-align: center">
                            Add new Course
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body" runat="server" style="background-color: #FFEFD5">
                            <form runat="server">
                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:TextBox ID="txtCN" runat="server" class="form-control" placeholder="Enter Course name" type="text" width="25%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Classification</label>
                                    <asp:TextBox ID="txtClass" runat="server" class="form-control" placeholder="Classify Course" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Training Programme</label>
                                    <asp:TextBox ID="txtTP" runat="server" class="form-control" placeholder="Enter programme name" type="text" width="30%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Course Status</label>
                                    <asp:DropDownList ID="drpCourseStat" runat="server" class="form-control" width="15%" readonly="true">
                                        
                                        
                                    </asp:DropDownList>
                                </div>
                                <div style="text-align:center; margin-bottom: 20px; margin-top: 5px">
                                     <asp:Label runat="server"  class="text-warning" id="lblField" visible="false" text="Please enter all required fields."></asp:Label>
                        <asp:Label runat="server"  class="text-warning" id="lblID" visible="false" text="Please enter a valid SA ID."></asp:Label>
                        <asp:Label ID="lblAdState" runat="server" class="alert alert-success" Text="Course has been added successfully." visible="false" style="float:right"></asp:Label>
                                    </div>

                                <asp:Button ID="BtnAdd" runat="server" Text="Add" class="btn btn-primary btn-lg" OnClick="BtnAdd_Click" width="10%"/>

                                    </form>
                                </div>
                               
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>

                       </div>

</asp:Content>
