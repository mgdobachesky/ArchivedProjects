<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="se256_Dobachesky.reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <fieldset>
                <legend>Reservation</legend>

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

                    <asp:SqlDataSource ID="sdsTables" runat="server" ConnectionString="<%$ ConnectionStrings:SE256_CS %>" SelectCommand="tables_getAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlTables" runat="server" CssClass="form-control" DataSourceID="sdsTables" DataTextField="tbl_name" DataValueField="tbl_id" AppendDataBoundItems="true">
                        </asp:DropDownList>
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
                        <asp:Button ID="btnAddUpdate" runat="server" text="Add"
                        CssClass="btn btn-default" OnClick="btnAddUpdate_Click" />

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                        CssClass="btn btn-default" OnClick="btnCancel_Click" 
                        CausesValidation="false" />
                    </div>

                </fieldset>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
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

                <asp:RequiredFieldValidator ID="rfvTable" runat="server" Display="None"  
                ErrorMessage="Table required" ControlToValidate="ddlTables"
                InitialValue="Please choose table">
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
</asp:Content>
