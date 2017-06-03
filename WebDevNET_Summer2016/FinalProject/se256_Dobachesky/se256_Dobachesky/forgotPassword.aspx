<%@ Page Title="" Language="C#" MasterPageFile="~/resturant.Master" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="se256_Dobachesky.forgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
            <fieldset>
            <legend>Forgot Password</legend>
                <div class="form-group">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                    placeholder="Email" />
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtConfirmEmail" runat="server" 
                    CssClass="form-control" placeholder="Confirm Email" />
                </div>

                 <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"
                    placeholder="Password" />
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" 
                    CssClass="form-control" placeholder="Confirm Password" />
                </div>

                <div class="form-group">
                    <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" 
                    CssClass="btn btn-default" />
                </div>
                </fieldset>
            </div>

            <div class="col-sm-8">
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" 
                ErrorMessage="Email required" ControlToValidate="txtEmail">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" Display="None"  
                ErrorMessage="Email retyped incorrectly" ControlToValidate="txtConfirmEmail">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="None" 
                ErrorMessage="Password required" ControlToValidate="txtPassword">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" Display="None"  
                ErrorMessage="Password retyped incorrectly" ControlToValidate="txtConfirmPassword">
                </asp:RequiredFieldValidator>

                <asp:CompareValidator ID="cvEmail" runat="server"
                    ControlToValidate="txtConfirmEmail"
                    ControlToCompare="txtEmail"
                    ErrorMessage="Retyped email must match"
                    Display="None"> 
                </asp:CompareValidator> 

                <asp:CompareValidator ID="cvPassword" runat="server"
                    ControlToValidate="txtConfirmPassword"
                    ControlToCompare="txtPassword"
                    ErrorMessage="Retyped password must match"
                    Display="None"> 
                </asp:CompareValidator> 

                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                    ControlToValidate="txtEmail"       
                    ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"      
                    ErrorMessage="Must enter a valid email"
                    Display="None"> 
                </asp:RegularExpressionValidator> 

                <asp:ValidationSummary ID="vsForgotPasswordForm" runat="server"  />
            </div>
        </div>
    </div> 
</asp:Content>
