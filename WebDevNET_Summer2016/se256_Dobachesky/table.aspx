<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="table.aspx.cs" Inherits="se256_Dobachesky.table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <fieldset>
                <legend>Table</legend>
                <div class="form-group">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"
                    placeholder="Name" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control"
                    placeholder="Desc"  />
                </div>
                    
                <asp:SqlDataSource ID="sdsSection" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="sections_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <div class="form-group">
                    <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control" DataSourceID="sdsSection" DataTextField="sect_name" DataValueField="sect_id" AppendDataBoundItems="true"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtSeatCount" runat="server" CssClass="form-control"
                    placeholder="Seat Count"  />
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

                <asp:RequiredFieldValidator ID="rfvSeatCount" runat="server" Display="None"  
                ErrorMessage="Seat Count required" ControlToValidate="txtSeatCount">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvSection" runat="server" Display="None"  
                ErrorMessage="Section required" ControlToValidate="ddlSection"
                InitialValue="Please choose section">
                </asp:RequiredFieldValidator>

                <asp:CompareValidator ID="cvSeatCount" runat="server"
                    ControlToValidate="txtSeatCount"
                    Operator="DataTypeCheck"
                    type="Integer"
                    ErrorMessage="Seat count must be a whole number"
                    Display="None"> 
                </asp:CompareValidator> 

                <asp:ValidationSummary ID="vsTableForm" runat="server"  />
            </div>
        </div>
    </div> 
</asp:Content>
