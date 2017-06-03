<%@ Page Title="" Language="C#" MasterPageFile="~/midterm.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="midterm_MichaelDobachesky._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <fieldset>
                <legend>Midterm Exam Form</legend>

                <div class="form-group">
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control">
                        <asp:ListItem>Comments</asp:ListItem>
                        <asp:ListItem>Requests</asp:ListItem>
                        <asp:ListItem>Complaints</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"
                    placeholder="Name" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                    placeholder="Email" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtConfirmEmail" runat="server" CssClass="form-control"
                    placeholder="Confirm Email" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control"
                    placeholder="Message"
                    TextMode="MultiLine" Rows="5" />
                </div>

                <div class="form-group">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-default" />

                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    CssClass="btn btn-default" 
                    CausesValidation="false" OnClick="btnCancel_Click" />
                </div>
                </fieldset>
            </div>
            
            <div class="col-sm-8">
                <br />
                <br />
                <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" Display="None"  
                ErrorMessage="Department required" ControlToValidate="ddlDepartment"
                InitialValue="Please choose department">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvName" runat="server" Display="None" 
                ErrorMessage="Name required" ControlToValidate="txtName">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" 
                ErrorMessage="Email required" ControlToValidate="txtEmail">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" Display="None" 
                ErrorMessage="Email retyped incorrectly" ControlToValidate="txtConfirmEmail">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvMessage" runat="server" Display="None" 
                ErrorMessage="Message required" ControlToValidate="txtMessage">
                </asp:RequiredFieldValidator>

                <asp:CompareValidator ID="cvEmail" runat="server"
                    ControlToValidate="txtConfirmEmail"
                    ControlToCompare="txtEmail"
                    ErrorMessage="Email retyped incorrectly"
                    Display="None"> 
                </asp:CompareValidator> 

                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                    ControlToValidate="txtEmail"       
                    ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"      
                    ErrorMessage="Valid email required"
                    Display="None"> 
                </asp:RegularExpressionValidator> 

                <asp:ValidationSummary ID="vsForm" runat="server"  />
            </div>

        </div>
    </div> 
</asp:Content>
