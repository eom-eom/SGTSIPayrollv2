<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="PayrollSetting.aspx.vb" Inherits="PayrollSytemV2.PayrollSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Payroll Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Payroll Settings
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
                            <h5>Salary Setting</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtSalarySetting" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Government Deduction Setting</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtGovDecSettings" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                   
                    <div class="row">
                        <div class="col-md-2">
                            Overtime Rate
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOTRate" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            Tax Deduction Settings
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTaxDeducSettings" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <h5>Night Differential Rate</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtNightDiffRate" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>13 Month Release Date</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt13Montdate" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <h5>Special Holiday Rate</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtSHolidayRate" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                         <div class="col-md-2">
                            <h5>Company Deduction Settings</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCompDeducSettings" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                     <br />
                    <div class="row">
                        <div class="col-md-2">
                            <h5>Legal Holiday Rate</h5>
                        </div>
                        <div class="col-md-4">
                             <asp:TextBox ID="txtLHolidayRate" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Minimum Wage</h5>
                        </div>
                        <div class="col-md-4">
                             <asp:TextBox ID="txtMinWage" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    
                     <br />
                    <div class="row">
                        <div class="col-md-2">
                            
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="btnEdit" runat="server" Text="Update" class="btn btn-block btn-warning btn-md" />
                        </div>
                        
                    </div>
                 </div>
             </div>
             </div>
             </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
