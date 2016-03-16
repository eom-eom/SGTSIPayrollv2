<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="ReceivablesAndTaxableAllowance.aspx.vb" Inherits="PayrollSytemV2.ReceivablesAndTaxableAllowance" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Receivables and Taxable Allowance
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Receivables and Taxable Allowance
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
                            <asp:TextBox ID="txtDesc" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            
                        </div>
                        <div class="col-md-3">
                            <h5><asp:CheckBox ID="cbTaxable" runat="server" /> Taxable</h5>
                            
                        </div>
                    </div>
                     <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvRTA" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvRTA_RowDataBound" 
                                OnSelectedIndexChanged="gvRTA_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvRTA_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="rta_code" HeaderText="Code"  />
                                    <asp:BoundField DataField="rta_desc" HeaderText="Description"  />
                                    <asp:BoundField DataField="rta_amount" HeaderText="Amount"  />
                                    <asp:BoundField DataField="rta_Taxable" HeaderText="Taxable (1 = YES / 0 = NO)"  />
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
