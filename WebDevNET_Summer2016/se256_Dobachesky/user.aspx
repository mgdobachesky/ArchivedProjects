<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="se256_Dobachesky.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <fieldset>
                <legend>User</legend>

                    <div class="form-group">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"
                        placeholder="First Name" />
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtLastName" runat="server" 
                        CssClass="form-control" 
                        placeholder="Last Name" />
                    </div>

                     <div class="form-group">
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control"
                        placeholder="Address 1" />
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control" 
                        placeholder="Address 2" />
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" 
                        placeholder="City" />
                    </div>

                    <asp:SqlDataSource ID="sdsState" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="states_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" DataSourceID="sdsState" DataTextField="state_display" DataValueField="state_id" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="TxtZip" runat="server" CssClass="form-control" 
                        placeholder="Zip" />
                    </div>

                      <div class="form-group">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"
                        placeholder="Password" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtConfirmPassword" runat="server"  TextMode="Password" 
                        CssClass="form-control" placeholder="Confirm Password" />
                    </div>

                     <div class="form-group">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                        placeholder="Email" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtConfirmEmail" runat="server" 
                        CssClass="form-control" placeholder="Confirm Email" />
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtPhone" runat="server" 
                        CssClass="form-control" placeholder="Phone" />
                    </div>

                    <div class="checkbox">
                        <label><asp:CheckBox ID="chkIsActive" runat="server" />Is Active</label>
                    </div>
                
                    <div class="form-group">
                        <asp:Button ID="btnAddUpdate" runat="server" 
                        CssClass="btn btn-default" OnClick="btnAddUpdate_Click" />

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                        CssClass="btn btn-default" 
                        CausesValidation="false" OnClick="btnCancel_Click" />
                    </div>
                </fieldset>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>

            <div class="col-sm-8">
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" Display="None" 
                ErrorMessage="First name required" ControlToValidate="txtFirstName">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" Display="None"  
                ErrorMessage="Last name required" ControlToValidate="txtLastName">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" Display="None" 
                ErrorMessage="Address 1 required" ControlToValidate="txtAddress1">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvCity" runat="server" Display="None"  
                ErrorMessage="City required" ControlToValidate="txtCity">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvState" runat="server" Display="None"  
                ErrorMessage="State required" ControlToValidate="ddlState"
                InitialValue="Please choose state">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvZip" runat="server" Display="None"  
                ErrorMessage="Zip required" ControlToValidate="txtZip">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="None" 
                ErrorMessage="Password required" ControlToValidate="txtPassword">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" Display="None"  
                ErrorMessage="Password retyped incorrectly" ControlToValidate="txtConfirmPassword">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" 
                ErrorMessage="Email required" ControlToValidate="txtEmail">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" Display="None"  
                ErrorMessage="Email retyped incorrectly" ControlToValidate="txtConfirmEmail">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" Display="None"  
                ErrorMessage="Phone required" ControlToValidate="txtPhone">
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

                <asp:RegularExpressionValidator ID="revZip" runat="server" 
                    ControlToValidate="txtZip"       
                    ValidationExpression="^\d{5}(?:[-\s]\d{4})?$"      
                    ErrorMessage="Must enter a valid zip"
                    Display="None"> 
                </asp:RegularExpressionValidator> 
                
                <asp:RegularExpressionValidator ID="revPhone" runat="server" 
                    ControlToValidate="txtPhone"       
                    ValidationExpression="^[0-9]{10}|[0-9]{7}$"      
                    ErrorMessage="Must enter a valid phone number"
                    Display="None"> 
                </asp:RegularExpressionValidator>

                <asp:ValidationSummary ID="vsUserForm" runat="server"  />
            </div>
        </div>
    </div> 
</asp:Content>
