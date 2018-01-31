<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Monyetla.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Monyetla5Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container" style="background-color: white; width:97%">
        <div class="row">
            <div class="col-md-4 col-md-offset-4" style="margin-top: 12%; margin-left: 44%; width:30%">
                <div class="login-panel panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                        <form role="form" runat="server">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="E-mail" name="txtEmail" type="email" value=""/>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" name="password" type="password" value=""/>
                                </div>
                                <p>Don't have an account? Click <a href="Register.aspx">here</a> to register your Consortium.</p>

                               <asp:Label runat="server" class="text-warning" ID="lblemail" Visible="false" Text="Please type your Email address"></asp:Label>
                               <asp:Label runat="server" class="text-warning" ID="lblpass" Visible="false" Text="Please type your password"></asp:Label>
                               <asp:Label runat="server" class="text-warning" ID="lblwrong" Visible="false" Text="You have typed in a wrong Email/Password"></asp:Label>
                                
                                <asp:Button runat="server" id="BtnLogOn" type="button" class="btn btn-primary btn-lg btn-block" OnClick="BtnLogOn_Click1" text="Log On"/>

                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
  
</asp:Content>
