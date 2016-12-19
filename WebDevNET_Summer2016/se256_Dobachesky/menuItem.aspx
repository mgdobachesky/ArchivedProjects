<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="menuItem.aspx.cs" Inherits="se256_Dobachesky.menuItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <fieldset>
                <legend>Menu Item</legend>

                    <div class="form-group">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"
                        placeholder="Name" />
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"
                        placeholder="Description" />
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtAllergens" runat="server" CssClass="form-control"
                        placeholder="Allergens" />
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"
                        placeholder="Price" />
                    </div>

                    <asp:SqlDataSource ID="sdsMenu" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlMenu" runat="server" CssClass="form-control" DataSourceID="sdsMenu" DataTextField="menu_name" DataValueField="menu_id" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    </div>

                    <asp:SqlDataSource ID="sdsMenuCategory" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_categories_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" DataSourceID="sdsMenuCategory" DataTextField="cat_name" DataValueField="cat_id" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    </div>

                    <div class="checkbox">
                        <label><asp:CheckBox ID="chkGlutenFree" runat="server" />Gluten Free</label>
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

                <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Display="None"  
                ErrorMessage="Description required" ControlToValidate="txtDescription">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" Display="None"  
                ErrorMessage="Price required" ControlToValidate="txtPrice">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvMenu" runat="server" Display="None"  
                ErrorMessage="Menu required" ControlToValidate="ddlMenu"
                InitialValue="Please choose menu">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" Display="None"  
                ErrorMessage="Category required" ControlToValidate="ddlCategory"
                InitialValue="Please choose category">
                </asp:RequiredFieldValidator>

                <asp:CompareValidator ID="cvPrice" runat="server"
                    ControlToValidate="txtPrice"
                    Operator="DataTypeCheck"
                    type="Currency"
                    ErrorMessage="Price must be a currency"
                    Display="None"> 
                </asp:CompareValidator> 

                <asp:ValidationSummary ID="vsMenuItemForm" runat="server"  />
            </div>
        </div>
    </div>
</asp:Content>
