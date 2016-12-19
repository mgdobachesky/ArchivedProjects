<%@ Page Title="" Language="C#" MasterPageFile="~/resturant.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="se256_Dobachesky.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <fieldset>
                <legend>Login</legend>
                <div class="form-group">
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"
                    placeholder="Email" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtPassword" type="password" runat="server" placeholder="Password" 
                    CssClass="form-control"  />
                </div>

                <div class="form-group">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="btnSubmit_Click" />

                    <asp:LinkButton ID="lbtnForgotPassword" runat="server" Text="Forgot password" CssClass="btn btn-default"
                    CausesValidation="false" OnClick="lbtnForgotPassword_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
                </fieldset>
            </div>
            
            <div class="col-sm-8">
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" Display="None" 
                ErrorMessage="UserName required" ControlToValidate="txtUserName">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="None"  
                ErrorMessage="Password required" ControlToValidate="txtPassword">
                </asp:RequiredFieldValidator>

                <asp:ValidationSummary ID="vsLoginForm" runat="server"  />
            </div>
        </div>
    </div> 
</asp:Content>
