<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="ShiftingSchedule.aspx.vb" Inherits="PayrollSytemV2.ShiftingSchedule" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Shifting Schedule
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Shifting Schedule
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
                <br />
                <div class="row">
                <div class="row">
                    <div class="col-md-2">
                        <h5>Employee</h5>
                    </div>
                    <div class="col-md-4">
                            
                        <asp:DropDownList class="form-control select2"  ID="ddlSelectEmp" runat="server" AutoPostBack="false" >
                               
                        </asp:DropDownList> 
                                  
                    </div>
                     <div class="col-md-2">
                            <h5>Shift</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList class="form-control select2"  ID="ddlShift" runat="server" AutoPostBack="false" >
                                
                            </asp:DropDownList> 

                        </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <h5>From</h5>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtFromDate" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <h5>To</h5>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtToDate" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvShifting" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvShifting_RowDataBound" 
                                OnSelectedIndexChanged="gvShifting_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvShifting_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="emp_id" HeaderText="Employee ID"  />
                                    <asp:BoundField DataField="shift_id" HeaderText="Shift"  />
                                    <asp:BoundField DataField="date_from" HeaderText="Date From"  />
                                    <asp:BoundField DataField="date_to" HeaderText="Date To"  />
                                    <asp:BoundField DataField="date_applied" HeaderText="Date Applied"  />
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
