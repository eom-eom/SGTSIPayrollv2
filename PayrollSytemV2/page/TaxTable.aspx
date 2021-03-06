﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="TaxTable.aspx.vb" Inherits="PayrollSytemV2.TaxTable" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Tax Table
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Tax Table
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
                            <h5>Ceiling</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCeiling" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                     <br />
                      <div class="row">
                        <div class="col-md-2">
                            <h5>Status</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList class="form-control select2"  ID="ddlStatus" runat="server" AutoPostBack="True" >
                                <asp:ListItem Text="S" Value="S"></asp:ListItem>
                                <asp:ListItem Text="ME1" Value="ME1"></asp:ListItem>
                                <asp:ListItem Text="ME2" Value="ME2"></asp:ListItem>
                                <asp:ListItem Text="ME3" Value="ME3"></asp:ListItem>
                                <asp:ListItem Text="ME4" Value="ME4"></asp:ListItem>
                            </asp:DropDownList> 
                        </div>
                        <div class="col-md-2">
                            <h5>Additional Tax</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAddTax" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                      <div class="row">
                        <div class="col-md-2">
                            <h5>Operand</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList class="form-control select2"  ID="ddlOperand" runat="server" AutoPostBack="True" >
                                <asp:ListItem Text="<" Value="<"></asp:ListItem>
                                <asp:ListItem Text=">" Value=">"></asp:ListItem>
                                <asp:ListItem Text="=" Value="="></asp:ListItem>
                                
                            </asp:DropDownList> 
                        </div>
                        <div class="col-md-2">
                            <h5>Tax Rate Percentage</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTaxRatePercent" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                      <div class="row">
                        <div class="col-md-2">
                            <h5>Amount Compensation</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAmountComp" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvTaxTable" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvTaxTable_RowDataBound" 
                                OnSelectedIndexChanged="gvTaxTable_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvTaxTable_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="tax_code" HeaderText="Code"  />
                                    <asp:BoundField DataField="tax_status" HeaderText="Status"  />
                                    <asp:BoundField DataField="tax_operand" HeaderText="Operand"  />
                                    <asp:BoundField DataField="tax_amount_comp" HeaderText="Amount Compensation"  />
                                    <asp:BoundField DataField="tax_ceiling" HeaderText="Ceiling"  />
                                    <asp:BoundField DataField="tax_additional" HeaderText="Additional"  />
                                    <asp:BoundField DataField="tax_rate" HeaderText="Rate"  />
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
