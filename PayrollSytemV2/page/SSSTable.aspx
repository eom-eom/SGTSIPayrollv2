﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="SSSTable.aspx.vb" Inherits="PayrollSytemV2.SSSTable" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    SSS Table
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    SSS Table
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
                            <h5>Code</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCode" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Employee Share</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtEmpShare" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                     <br />
                      <div class="row">
                        <div class="col-md-2">
                            <h5>Range Compensation From</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtFromRange" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Employee Compensation</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtEmpComp" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                      <div class="row">
                        <div class="col-md-2">
                            <h5>Range Compensation To</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtRangeTo" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Employer Share</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtEmployerShare" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvSSS" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvSSS_RowDataBound" 
                                OnSelectedIndexChanged="gvSSS_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvSSS_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="sss_code" HeaderText="Code"  />
                                    <asp:BoundField DataField="sss_from_comp" HeaderText="Range Compensation From"  />
                                    <asp:BoundField DataField="sss_to_comp" HeaderText="Range Compensation To"  />
                                    <asp:BoundField DataField="sss_ee" HeaderText="Employee Share"  />
                                    <asp:BoundField DataField="sss_ec" HeaderText="Employee Compensation"  />
                                    <asp:BoundField DataField="sss_er" HeaderText="Employer Share"  />
                                    
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
