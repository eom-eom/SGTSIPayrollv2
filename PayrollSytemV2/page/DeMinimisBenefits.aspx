﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="DeMinimisBenefits.aspx.vb" Inherits="PayrollSytemV2.DeMinimisBenefits"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    De Minimis Benefits
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    De Minimis Benefits
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
                            <h5>Amount</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAmount" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                     <br />
                      <div class="row">
                        <div class="col-md-2">
                            <h5>Description</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDescription" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Type</h5>
                        </div>
                        <div class="col-md-4">
                             <asp:DropDownList class="form-control select2"  ID="ddlType" runat="server" AutoPostBack="True" >
                                <asp:ListItem Text="Half Month" Value="HalfMonth"></asp:ListItem>
                                <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                            </asp:DropDownList> 
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvDeminimis" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvDeminimis_RowDataBound" 
                                OnSelectedIndexChanged="gvDeminimis_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvDeminimis_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="dmb_code" HeaderText="Code"  />
                                    <asp:BoundField DataField="dmb_desc" HeaderText="Description"  />
                                    <asp:BoundField DataField="dmb_amount" HeaderText="Amount"  />
                                    <asp:BoundField DataField="dmb_type" HeaderText="Type"  />
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
