<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="section.aspx.cs" Inherits="se256_Dobachesky.section" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <fieldset>
                <legend>Section</legend>
                <div class="form-group">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"
                    placeholder="Name" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control"
                    placeholder="Desc"  />
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
                <asp:RequiredFieldValidator ID="rfvName" runat="server" Display="None" 
                ErrorMessage="Name required" ControlToValidate="txtName">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvDesc" runat="server" Display="None"  
                ErrorMessage="Desc required" ControlToValidate="txtDesc">
                </asp:RequiredFieldValidator>

                <asp:ValidationSummary ID="vsSectionForm" runat="server"  />
            </div>
        </div>
    </div> 
</asp:Content>
