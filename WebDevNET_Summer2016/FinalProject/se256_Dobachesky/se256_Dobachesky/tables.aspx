<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="tables.aspx.cs" Inherits="se256_Dobachesky.tables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvTables" runat="server" AutoGenerateColumns="false" EmptyDataText="N/A" DataSourceID="sdsTables" AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table">
                        <Columns>
                            <asp:HyperLinkField DataTextField="tbl_name" DataNavigateUrlFields="tbl_id" DataNavigateUrlFormatString="~/Admin/Table/{0}" HeaderText="Table Name" SortExpression="tbl_name" />
                            <asp:BoundField DataField="sect_name" HeaderText="Section Name" SortExpression="sect_name" />
                            <asp:BoundField DataField="tbl_desc" HeaderText="Table Description" SortExpression="tbl_desc" />
                            <asp:BoundField DataField="tbl_seat_cnt" HeaderText="Seat Count" SortExpression="tbl_seat_cnt" />
                            <asp:BoundField DataField="tbl_active" HeaderText="Active" SortExpression="tbl_active" />
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" Position="Bottom" FirstPageText="<&nbsp;" LastPageText="&nbsp;>" PageButtonCount="5" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="sdsTables" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="tables_interim_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
