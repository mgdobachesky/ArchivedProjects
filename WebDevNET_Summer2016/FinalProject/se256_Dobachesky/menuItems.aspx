<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="menuItems.aspx.cs" Inherits="se256_Dobachesky.menuItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="false" EmptyDataText="N/A" DataSourceID="sdsMenuItems" AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table">
                        <Columns>
                            <asp:HyperLinkField DataTextField="item_name" DataNavigateUrlFields="item_id" DataNavigateUrlFormatString="~/Admin/Menu-Item/{0}" HeaderText="Item Name" SortExpression="item_name" />
                            <asp:BoundField DataField="menu_name" HeaderText="Menu Name" SortExpression="menu_name" />
                            <asp:BoundField DataField="cat_name" HeaderText="Category Name" SortExpression="cat_name" />
                            <asp:BoundField DataField="item_desc" HeaderText="Item Description" SortExpression="item_desc" />
                            <asp:BoundField DataField="item_allergens" HeaderText="Item Allergens" SortExpression="item_allergens" />
                            <asp:BoundField DataField="item_price" HeaderText="Item Price" SortExpression="item_price" />
                            <asp:BoundField DataField="item_gluten_free" HeaderText="Item Gluten Free" SortExpression="item_gluten_gree" />
                            <asp:BoundField DataField="item_active" HeaderText="Item Active" SortExpression="item_active" />
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" Position="Bottom" FirstPageText="<&nbsp;" LastPageText="&nbsp;>" PageButtonCount="5" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="sdsMenuItems" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_interim_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
