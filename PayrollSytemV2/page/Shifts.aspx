<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="Shifts.aspx.vb" Inherits="PayrollSytemV2.Shifts" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Shifts
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Shifts
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
                        <div class="col-md-2">
                            <h5>Shift Name</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtShiftName" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                     <br />
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Time In</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTimeIn" runat="server"  type="time" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Time Out</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTimeOut" runat="server"  type="time" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvShifts" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvShifts_RowDataBound" 
                                OnSelectedIndexChanged="gvShifts_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvShifts_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="shift_name" HeaderText="Name"  />
                                    <asp:BoundField DataField="time_in" HeaderText="Time In"  />
                                    <asp:BoundField DataField="time_out" HeaderText="Time Out"  />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Linkbutton ID="btnNew" runat="server" class="btn btn-block btn-primary btn-md"> <span class='fa fa-plus'></span> New </asp:Linkbutton>  
                        </div>
                        <div class="col-md-3">
                           <asp:Linkbutton ID="btnSave" runat="server" class="btn btn-block btn-success btn-md"> <span class='fa fa-check'></span> Save </asp:Linkbutton>
                        </div>
                        <div class="col-md-3">
                           <asp:Linkbutton ID="btnEdit" runat="server" class="btn btn-block btn-warning btn-mds"> <span class='fa fa-edit'></span> Edit </asp:Linkbutton>
                        </div>
                        <div class="col-md-3">
                            <asp:Linkbutton ID="btnDelete" runat="server" class="btn btn-block btn-danger btn-md"> <span class='fa fa-times'></span> Delete </asp:Linkbutton>
                        </div>
                    </div>
                 </div>
             </div>
             </div>
             </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
