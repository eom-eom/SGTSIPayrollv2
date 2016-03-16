<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="SystemSetting.aspx.vb" Inherits="PayrollSytemV2.SystemSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    System Setting
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    System Seeting
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
                            <h5>Company Name</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCompanyName" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                   
                    <div class="row">
                        <div class="col-md-2">
                            Company Logo
                        </div>
                        <div class="col-md-4">
                            <asp:FileUpload ID="fileupload" runat="server"/>
                        
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <h5>Company Address</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAddress" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <h5>Company Telephone No</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTelNo" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                     <br />
                    <div class="row">
                        <div class="col-md-2">
                            <h5>Default Shift</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList class="form-control select2"  ID="ddlShift" runat="server" AutoPostBack="false" >
                                <asp:ListItem Text="Day Shift" Value="DS"></asp:ListItem>
                                <asp:ListItem Text="Mid Shift" Value="MS"></asp:ListItem>
                                <asp:ListItem Text="Night Shift" Value="NS"></asp:ListItem>
                            </asp:DropDownList> 
                        </div>
                        
                    </div>
                     <br />
                    <div class="row">
                        <div class="col-md-2">
                            <h5>Garce Period (in Mins)</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtgracePeriod" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
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
