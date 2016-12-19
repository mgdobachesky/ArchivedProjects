<%@ Page Title="" Language="C#" MasterPageFile="~/resturant.Master" AutoEventWireup="true" CodeBehind="reservations.aspx.cs" Inherits="se256_Dobachesky.reservations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gvReservations" runat="server" AutoGenerateColumns="false" EmptyDataText="No reservations on this account yet!" DataSourceID="sdsReservations" AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="res_date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Reservation Date" SortExpression="res_date" />
                            <asp:BoundField DataField="res_time" HeaderText="Reservation Time" SortExpression="res_time" />
                            <asp:BoundField DataField="guest_email" HeaderText="Guest Email" SortExpression="guest_email" />
                            <asp:BoundField DataField="res_guest_cnt" HeaderText="Guest Count" SortExpression="res_guest_cnt" />
                            <asp:BoundField DataField="res_spec_req" HeaderText="Special Requirement" SortExpression="res_spec_req" />
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" Position="Bottom" FirstPageText="<&nbsp;" LastPageText="&nbsp;>" PageButtonCount="5" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
                <button type="button" class="btn btn-default btn-md" data-toggle="modal" data-target="#mdlAddRes">Add Reservation</button>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="sdsReservations" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="reservations_interim_getById" SelectCommandType="StoredProcedure">
            <SelectParameters><asp:SessionParameter Name="user_id" SessionField="user_id" type="Int32" /></SelectParameters>
    </asp:SqlDataSource>

<div id="mdlAddRes" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Add Reservation</h4>
            </div>
            <div class="modal-body">
                 <div class="container-fluid">
                    <div class="row">
                        <div class="col-sm-8">
                            <fieldset>
                            <legend>Add Reservation</legend>

                                <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="users_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control" DataSourceID="sdsUsers" DataTextField="user_email" DataValueField="user_id" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                                    placeholder="Guest Email" />
                                </div>

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
                                    <asp:TextBox ID="txtPhone" runat="server" 
                                    CssClass="form-control" placeholder="Phone" />
                                </div>

                                <div class="form-group">
                                    <div class='input-group date' id='dtpResDate'>
                                        <asp:TextBox ID="txtResDate" runat="server" CssClass="form-control" placeholder="Reservation Date" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                                <script type="text/javascript">
                                    $(function () {
                                        $('#dtpResDate').datetimepicker({
                                            format: 'L'
                                        });
                                    });
                                </script>

                                <div class="form-group">
                                    <div class='input-group date' id='dtpResTime'>
                                        <asp:TextBox ID="txtResTime" runat="server" CssClass="form-control" placeholder="Reservation Time" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-time"></span>
                                        </span>
                                    </div>
                                </div>
                                <script type="text/javascript">
                                    $(function () {
                                        $('#dtpResTime').datetimepicker({
                                            format: 'LT'
                                        });
                                    });
                                </script>

                                <div class="form-group">
                                    <asp:DropDownList ID="ddlGuestCount" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="txtSpecReq" runat="server" CssClass="form-control"
                                    placeholder="Special Requirements" />
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="btnAdd" runat="server" text="Add"
                                    CssClass="btn btn-default" OnClick="btnAdd_Click" />

                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                    CssClass="btn btn-default" OnClick="btnCancel_Click" 
                                    CausesValidation="false" />
                                </div>

                            </fieldset>
                        </div>

                        <div class="col-sm-4">

                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" 
                            ErrorMessage="Email required" ControlToValidate="txtEmail">
                            </asp:RequiredFieldValidator>

                             <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" Display="None" 
                            ErrorMessage="First name required" ControlToValidate="txtFirstName">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" Display="None"  
                            ErrorMessage="Last name required" ControlToValidate="txtLastName">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" Display="None"  
                            ErrorMessage="Phone required" ControlToValidate="txtPhone">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="rfvUser" runat="server" Display="None"  
                            ErrorMessage="User required" ControlToValidate="ddlUsers"
                            InitialValue="Please choose user">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="rfvResDate" runat="server" Display="None" 
                            ErrorMessage="Reservation date required" ControlToValidate="txtResDate">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="rfvResTime" runat="server" Display="None" 
                            ErrorMessage="Reservation time required" ControlToValidate="txtResTime">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="rfvGuestCount" runat="server" Display="None"  
                            ErrorMessage="Guest count required" ControlToValidate="ddlGuestCount"
                            InitialValue="Please choose guest count">
                            </asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                ControlToValidate="txtEmail"       
                                ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"      
                                ErrorMessage="Must enter a valid email"
                                Display="None"> 
                            </asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="revPhone" runat="server" 
                                ControlToValidate="txtPhone"       
                                ValidationExpression="^[0-9]{10}|[0-9]{7}$"      
                                ErrorMessage="Must enter a valid phone number"
                                Display="None"> 
                            </asp:RegularExpressionValidator>

                            <asp:ValidationSummary ID="vsReservationsForm" runat="server"  />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
