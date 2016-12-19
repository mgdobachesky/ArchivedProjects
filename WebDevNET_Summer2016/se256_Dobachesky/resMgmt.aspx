<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="resMgmt.aspx.cs" Inherits="se256_Dobachesky.resMgmt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvReservations" runat="server" AutoGenerateColumns="false" EmptyDataText="N/A" DataSourceID="sdsReservations" AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table">
                        <Columns>
                            <asp:HyperLinkField DataTextField="res_date" DataTextFormatString="{0:MM/dd/yyyy}" DataNavigateUrlFields="res_id" DataNavigateUrlFormatString="~/Admin/Reservation/{0}" HeaderText="Reservation Date" SortExpression="res_date" />
                            <asp:BoundField DataField="res_time" HeaderText="Reservation Time" SortExpression="res_time" />
                            <asp:BoundField DataField="user_email" HeaderText="User Email" SortExpression="user_email" />
                            <asp:BoundField DataField="guest_email" HeaderText="Guest Email" SortExpression="guest_email" />
                            <asp:BoundField DataField="tbl_name" HeaderText="Table Name" SortExpression="tbl_name" />
                            <asp:BoundField DataField="res_guest_cnt" HeaderText="Guest Count" SortExpression="res_guest_cnt" />
                            <asp:BoundField DataField="res_spec_req" HeaderText="Special Requirement" SortExpression="res_spec_req" />
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" Position="Bottom" FirstPageText="<&nbsp;" LastPageText="&nbsp;>" PageButtonCount="5" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="sdsReservations" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="reservations_interim_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
