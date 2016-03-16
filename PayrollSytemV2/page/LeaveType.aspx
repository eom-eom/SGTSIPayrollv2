<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="LeaveType.aspx.vb" Inherits="PayrollSytemV2.LeaveType" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Leave Type
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Leave Type
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-warning">
            <div class="box-body">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12">
                        <div class="messagealert" id="alert_container">
                        </div>
                    </div>
                </div>
                 <div class="row">
                     <br />
                     <div class="row">
                        <div class="col-md-1">
                            <h5>Description</h5>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDesc" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <h5>No of Days</h5>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtNoDays" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                         
                        <div class="col-md-2">
                            <h5><asp:CheckBox ID="cbWithPay" runat="server" /> Leave With Pay</h5>
                            
                        </div>
                        <div class="col-md-2">
                            <h5><asp:CheckBox ID="cbConvertable" runat="server" /> Convertable to Cash</h5>
                        </div>
                        
                    </div>
                     <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvLeaveType" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvLeaveType_RowDataBound" 
                                OnSelectedIndexChanged="gvLeaveType_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvLeaveType_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="leave_desc" HeaderText="Description"  />
                                    <asp:BoundField DataField="leave_no_of_days" HeaderText="No of Days"  />
                                    <asp:BoundField DataField="leave_convertable" HeaderText="Convertable to Cash (1 = YES / 0 = NO)"  />
                                    <asp:BoundField DataField="w_pay" HeaderText="With Pay (1 = YES / 0 = NO)"  />
                              
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-block btn-primary btn-md" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-block btn-success btn-md" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn btn-block btn-warning btn-md" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-block btn-danger btn-md" />
                        </div>
                    </div>
                 </div>
             </div>
             </div>
             </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
