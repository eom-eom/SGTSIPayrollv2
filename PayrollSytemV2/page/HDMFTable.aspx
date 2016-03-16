<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="HDMFTable.aspx.vb" Inherits="PayrollSytemV2.HDMFTable" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    HDMF Table
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    HDMF Table
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
                            <h5>Contribution Option</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:RadioButton id="rbPercentage" runat="server" GroupName="CO" Text="Percentage"></asp:RadioButton>
                            <asp:RadioButton id="rbAmount" runat="server" GroupName="CO" Text="Amount"></asp:RadioButton>

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
                            <asp:GridView ID="gvHDMF" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvHDMF_RowDataBound" 
                                OnSelectedIndexChanged="gvHDMF_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvHDMF_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="hdmf_code" HeaderText="Code"  />
                                    <asp:BoundField DataField="hdmf_from_comp" HeaderText="Range Compensation From"  />
                                    <asp:BoundField DataField="hdmf_to_comp" HeaderText="Range Compensation To"  />
                                    <asp:BoundField DataField="hdmf_cont_option" HeaderText="Contribution Option"  />
                                    <asp:BoundField DataField="hdmf_ee" HeaderText="Employee Share"  />
                                    <asp:BoundField DataField="hdmf_er" HeaderText="Employer Share"  />
                                    
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
