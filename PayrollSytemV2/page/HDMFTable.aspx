<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="HDMFTable.aspx.vb" Inherits="PayrollSytemV2.HDMFTable" %>
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
            <div class="col-md-12">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
