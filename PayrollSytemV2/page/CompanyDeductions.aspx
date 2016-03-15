<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="CompanyDeductions.aspx.vb" Inherits="PayrollSytemV2.CompanyDeductions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Company Deductions
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Company Deductions
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-md-12">
                 <div class="row">
                     <br />
                     <div class="row">
                        <div class="col-md-1">
                            <h5>Code</h5>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtCode" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <h5>Decription</h5>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDesc" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                         <div class="col-md-1">
                           
                        </div>
                        <div class="col-md-3">
                            <h5><asp:CheckBox ID="cbDuration" runat="server" /> Duration</h5>
                            
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
