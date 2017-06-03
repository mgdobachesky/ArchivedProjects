<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="se256_Dobachesky.users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" EmptyDataText="N/A" DataSourceID="sdsUsers" AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table">
                        <Columns>
                            <asp:HyperLinkField DataTextField="user_email" DataNavigateUrlFields="user_id" DataNavigateUrlFormatString="~/Admin/User/{0}" HeaderText="Email" SortExpression="user_email" />
                            <asp:BoundField DataField="user_first" HeaderText="First Name" SortExpression="user_first" />
                            <asp:BoundField DataField="user_last" HeaderText="Last Name" SortExpression="user_last" />
                            <asp:BoundField DataField="user_add1" HeaderText="Primary Address" SortExpression="user_add1" />
                            <asp:BoundField DataField="user_add2" HeaderText="Secondary Address" SortExpression="user_add2" />
                            <asp:BoundField DataField="user_city" HeaderText="City" SortExpression="user_city" />
                            <asp:BoundField DataField="state_id" HeaderText="State" SortExpression="state_id" />
                            <asp:BoundField DataField="user_zip" HeaderText="Zip Code" SortExpression="user_zip" />
                            <asp:BoundField DataField="user_phone" HeaderText="Phone Number" SortExpression="user_phone" />
                            <asp:BoundField DataField="user_active" HeaderText="Active" SortExpression="user_active" />
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" Position="Bottom" FirstPageText="<&nbsp;" LastPageText="&nbsp;>" PageButtonCount="5" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="users_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
