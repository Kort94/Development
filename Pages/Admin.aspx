<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/MonyetlaAdmin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Monyetla5Web.Pages.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                   <div id="page-wrapper">
             
                <div class="col-lg-12" style="margin-left: 115px; margin-top: 280px; position: relative">
                    <div class="panel panel-primary">
                        <div class="panel-heading" style="font-weight: bold; text-align: center">
                            Active Consortia
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body" id="ViewConsortiumData" runat="server" style="background-color: #FFEFD5">
                            </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                
            </div>
</asp:Content>
