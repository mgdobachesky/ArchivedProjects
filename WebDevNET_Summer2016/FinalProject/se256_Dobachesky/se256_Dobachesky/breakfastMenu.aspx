<%@ Page Title="" Language="C#" MasterPageFile="~/resturant.Master" AutoEventWireup="true" CodeBehind="breakfastMenu.aspx.cs" Inherits="se256_Dobachesky.breakfastMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <h1>Appetizers</h1>
                <asp:GridView ID="gvApp" runat="server" AutoGenerateColumns="False" DataSourceID="sdsApp" CssClass="table" EmptyDataText="There are no items on this menu yet!">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Allergens" HeaderText="Allergens" SortExpression="Allergens" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CheckBoxField DataField="Gluten Free" HeaderText="Gluten Free" SortExpression="Gluten Free" />
                    </Columns>
                </asp:GridView>
                </div>
                
                 <div class="table-responsive">
                <h1>Sandwiches</h1>
                <asp:GridView ID="gvSand" runat="server" AutoGenerateColumns="False" DataSourceID="sdsSand" CssClass="table" EmptyDataText="There are no items on this menu yet!">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Allergens" HeaderText="Allergens" SortExpression="Allergens" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CheckBoxField DataField="Gluten Free" HeaderText="Gluten Free" SortExpression="Gluten Free" />
                    </Columns>
                </asp:GridView>
                </div>

                 <div class="table-responsive">
                     <h1>Soups</h1>
                <asp:GridView ID="gvSoup" runat="server" AutoGenerateColumns="False" DataSourceID="sdsSoup" CssClass="table" EmptyDataText="There are no items on this menu yet!">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Allergens" HeaderText="Allergens" SortExpression="Allergens" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CheckBoxField DataField="Gluten Free" HeaderText="Gluten Free" SortExpression="Gluten Free" />
                    </Columns>
                </asp:GridView>
                </div>
                
                 <div class="table-responsive">
                     <h1>Salads</h1>
                <asp:GridView ID="gvSalad" runat="server" AutoGenerateColumns="False" DataSourceID="sdsSalad" CssClass="table" EmptyDataText="There are no items on this menu yet!">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Allergens" HeaderText="Allergens" SortExpression="Allergens" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CheckBoxField DataField="Gluten Free" HeaderText="Gluten Free" SortExpression="Gluten Free" />
                    </Columns>
                </asp:GridView>
                </div>
                
                 <div class="table-responsive">
                     <h1>Entrees</h1>
                <asp:GridView ID="gvEnree" runat="server" AutoGenerateColumns="False" DataSourceID="sdsEntree" CssClass="table" EmptyDataText="There are no items on this menu yet!">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Allergens" HeaderText="Allergens" SortExpression="Allergens" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CheckBoxField DataField="Gluten Free" HeaderText="Gluten Free" SortExpression="Gluten Free" />
                    </Columns>
                </asp:GridView>
                </div>
                
                 <div class="table-responsive">
                     <h1>Sides</h1>
                <asp:GridView ID="gvSide" runat="server" AutoGenerateColumns="False" DataSourceID="sdsSide" CssClass="table" EmptyDataText="There are no items on this menu yet!">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Allergens" HeaderText="Allergens" SortExpression="Allergens" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CheckBoxField DataField="Gluten Free" HeaderText="Gluten Free" SortExpression="Gluten Free" />
                    </Columns>
                </asp:GridView>
                </div>
                
                 <div class="table-responsive">
                     <h1>Non Alcholic Beverages</h1>
                <asp:GridView ID="gvNonAlch" runat="server" AutoGenerateColumns="False" DataSourceID="sdsNonAlch" CssClass="table" EmptyDataText="There are no items on this menu yet!">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Allergens" HeaderText="Allergens" SortExpression="Allergens" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CheckBoxField DataField="Gluten Free" HeaderText="Gluten Free" SortExpression="Gluten Free" />
                    </Columns>
                </asp:GridView>
                </div>
                
                 <div class="table-responsive">
                     <h1>Wine</h1>
                <asp:GridView ID="gvWine" runat="server" AutoGenerateColumns="False" DataSourceID="sdsWine" CssClass="table" EmptyDataText="There are no items on this menu yet!">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Allergens" HeaderText="Allergens" SortExpression="Allergens" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CheckBoxField DataField="Gluten Free" HeaderText="Gluten Free" SortExpression="Gluten Free" />
                    </Columns>
                </asp:GridView>
                </div>
                
                 <div class="table-responsive">
                     <h1>Beer</h1>
                <asp:GridView ID="gvBeer" runat="server" AutoGenerateColumns="False" DataSourceID="sdsBeer" CssClass="table" EmptyDataText="There are no items on this menu yet!">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Allergens" HeaderText="Allergens" SortExpression="Allergens" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CheckBoxField DataField="Gluten Free" HeaderText="Gluten Free" SortExpression="Gluten Free" />
                    </Columns>
                </asp:GridView>
                </div>
                
                <asp:SqlDataSource ID="sdsApp" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_getByMenuAndCat" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="menu_id" Type="Int32" />
                        <asp:Parameter DefaultValue="1" Name="cat_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="sdsSand" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_getByMenuAndCat" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="menu_id" Type="Int32" />
                        <asp:Parameter DefaultValue="2" Name="cat_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="sdsSalad" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_getByMenuAndCat" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="menu_id" Type="Int32" />
                        <asp:Parameter DefaultValue="3" Name="cat_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="sdsEntree" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_getByMenuAndCat" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="menu_id" Type="Int32" />
                        <asp:Parameter DefaultValue="4" Name="cat_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="sdsSide" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_getByMenuAndCat" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="menu_id" Type="Int32" />
                        <asp:Parameter DefaultValue="5" Name="cat_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="sdsNonAlch" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_getByMenuAndCat" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="menu_id" Type="Int32" />
                        <asp:Parameter DefaultValue="6" Name="cat_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="sdsWine" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_getByMenuAndCat" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="menu_id" Type="Int32" />
                        <asp:Parameter DefaultValue="7" Name="cat_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="sdsBeer" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_getByMenuAndCat" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="menu_id" Type="Int32" />
                        <asp:Parameter DefaultValue="8" Name="cat_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="sdsSoup" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="menu_items_getByMenuAndCat" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="menu_id" Type="Int32" />
                        <asp:Parameter DefaultValue="9" Name="cat_id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
