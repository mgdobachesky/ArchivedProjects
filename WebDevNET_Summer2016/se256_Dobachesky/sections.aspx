<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="sections.aspx.cs" Inherits="se256_Dobachesky.sections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvSections" runat="server" AutoGenerateColumns="false" EmptyDataText="N/A" DataSourceID="sdsSections" AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table">
                        <Columns>
                            <asp:HyperLinkField DataTextField="sect_name" DataNavigateUrlFields="sect_id" DataNavigateUrlFormatString="~/Admin/Section/{0}" HeaderText="Section Name" SortExpression="sect_name" />
                            <asp:BoundField DataField="sect_desc" HeaderText="Section Description" SortExpression="sect_desc" />
                            <asp:BoundField DataField="sect_active" HeaderText="Active" SortExpression="sect_active" />
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" Position="Bottom" FirstPageText="<&nbsp;" LastPageText="&nbsp;>" PageButtonCount="5" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="sdsSections" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="sections_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
