<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="OvertimeSettings.aspx.vb" Inherits="PayrollSytemV2.OvertimeSettings" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Overtime Settings   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
     Overtime Setting
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
                            <h5>Overtime Rate</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtORate" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Overtime Legal Holiday and Overtime </h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOLHandOT" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    <br />
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Overtime Regular Special Holiday</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtORegSH" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Overtime Regular Sunday </h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtORegSun" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    <br />
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Overtime Excess Special Holiday</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOExSH" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Overtime Excess Sunday </h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOExSun" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    <br />
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Overtime Special Holiday and Overtime</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOSHandO" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Overtime Regular Legal Holiday Sunday </h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtORegLHSun" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                     <br />
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Overtime Regular Legal Holiday</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtORegLH" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Overtime Excess Legal Holiday Sunday </h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOExLHSun" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                     <br />
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Overtime Excess Legal Holiday</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOExLH" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Overtime Night Differential </h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtONightDiff" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
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
