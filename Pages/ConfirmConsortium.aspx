<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/MonyetlaAdmin.Master" AutoEventWireup="true" CodeBehind="ConfirmConsortium.aspx.cs" Inherits="Monyetla5Web.Pages.ConfirmConsortium" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      
                   <div id="page-wrapper">

                       <div class="col-lg-12" style="margin-left: 115px; margin-top: 280px; position: relative">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="font-weight: bold; text-align: center">
                        Confirm Consortium 
                        
                    </div>
                    <div class="panel-body" style="background-color: #FFEFD5">
                        <form runat="server">
                            <div class="form-group">
                                    
                               <asp:DropDownList ID="drpChooseCon" runat="server" class="form-control" width="30%" style="float:left">
                                        
                                </asp:DropDownList>

                                <asp:Button runat="server" id="BtnView" type="button" class="btn btn-primary btn-sm" OnClick="BtnView_Click1" text="View" style="float: left; width: 5%"/>

                                </div>
                                <br/><br /><h3>Consortium</h3>
                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:TextBox runat="server" id="txtconsName" class="form-control" placeholder="" name="consName" type="text" width="30%" readonly="true"/>
                                </div>
                                <div class="form-group">
                                    <label>Registration number</label>
                                    <asp:TextBox runat="server" id="txtregNo" class="form-control" placeholder="" name="regNo" type="text" width="30%" readonly="true"/>
                                </div>
                                <div class="form-group">
                                    <label>Physical Address</label>
                                    <asp:TextBox runat="server" id="txtphysicalAd1" class="form-control" placeholder="" name="physicalAd1" type="text" width="35%" readonly="true"/>
                                </div>
                                <div class="form-group">
                                    
                                    <asp:TextBox runat="server" id="txtphysicalAd2" class="form-control" placeholder="" name="physicalAd2" type="text" width="35%" readonly="true"/>
                                </div>
                                <div class="form-group">
                                    
                                    <asp:TextBox runat="server" id="txtphysicalAd3" class="form-control" placeholder="" name="physicalAd3" type="text" width="35%" readonly="true"/>
                                </div>
                                <div class="form-group">
                                    <label>Postal Code</label>
                                    <asp:TextBox runat="server" id="txtpostalCode" class="form-control" placeholder="" name="postalCode" type="text" width="17%" readonly="true"/>
                                </div>
                                <div class="form-group">
                                    <label>Site Name</label>
                                    <asp:TextBox runat="server" id="txtsiteName" class="form-control" placeholder="" name="siteName" type="text" width="35%" readonly="true"/>
                                </div>
                                <div class="form-group">
                                    <label>Site Classification</label>
                                <asp:TextBox runat="server" id="txtSiteClass" class="form-control" placeholder="" name="siteName" type="text" width="25%" readonly="true"/>

                                </div>
                                <div class="form-group">
                                    <label>Province</label>
                               <asp:TextBox runat="server" id="txtProvince" class="form-control" placeholder="" name="siteName" type="text" width="25%" readonly="true"/>

                                </div>
                                <div class="form-group">
                                    <label>Magisterial District</label>
                                <asp:TextBox runat="server" id="txtMagDistr" class="form-control" placeholder="" name="siteName" type="text" width="25%" readonly="true"/>

                                </div>
              
                                
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
                                    <asp:TextBox runat="server" id="txtprojectManFirst" class="form-control" placeholder="" name="projectManFirst" type="text" width="95%" readonly="true"/>
                                </div>
                                        </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1FirstN" class="form-control" placeholder="" name="assist1FirstN" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2FirstN" class="form-control" placeholder="" name="assist2FirstN" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    </tr>
                                <tr>
                                    <td style="width: 10%">
                                        <label>Surname</label>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtprojectManSurn" class="form-control" placeholder="" name="projectManSurn" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1Surn" class="form-control" placeholder="" name="assist1Surn" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2Surn" class="form-control" placeholder="" name="assist2Surn" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                </tr>
                                 <tr>
                                     <td style="width: 10%">
                                        <label>Phone Number</label>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtprojectManPhone" class="form-control" placeholder="" name="projectManPhone" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1PhoneN" class="form-control" placeholder="" name="assist1PhoneN" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2PhoneN" class="form-control" placeholder="" name="assist2PhoneN" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                </tr>
                                 <tr>
                                     <td style="width: 10%">
                                        <label>Cell number</label>
                                    </td>
                                    <td>
                                    <div class="form-group">
                                    <asp:TextBox runat="server" id="txtprojectManCell" class="form-control" placeholder="" name="projectManCell" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1CellN" class="form-control" placeholder="" name="assist1CellN" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2CellN" class="form-control" placeholder="" name="assist2CellN" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                </tr>
                                 <tr>
                                     <td style="width: 10%">
                                        <label>Email</label>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtprojectManEmail" class="form-control" placeholder="" name="projectManEmail" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    <td>
                                    <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist1Email" class="form-control" placeholder="" name="assist1Email" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                    <asp:TextBox runat="server" id="txtassist2Email" class="form-control" placeholder="" name="assist2Email" type="text" width="95%" readonly="true"/>
                                </div>
                                    </td>
                                </tr>
                                
                                </table>
                            
                             <div style="text-align:center; margin-bottom: 20px; margin-top: 5px">
                            <asp:Label ID="lblApproved" runat="server" class="alert alert-success" Text="Consortium has been Approved" visible="false" ></asp:Label>
                            <asp:Label ID="lblRejected" runat="server" class="alert alert-success" Text="Consortium has been Rejected" visible="false"></asp:Label>
                                </div>
                              <div style="text-align:center">
                               <asp:Button runat="server" id="BtnApprove" type="button" class="btn btn-primary btn-lg" OnClick="BtnApprove_Click1" text="Approve" style="width: 15%"/>
                            <asp:Button runat="server" id="BtnReject" type="button" class="btn btn-primary btn-lg" OnClick="BtnReject_Click1" text="Reject" style="width: 15%"/>
                            </div>
                            
                           
                        </form>
                    </div>
                </div>
                </div>
            

                       </div>

</asp:Content>
