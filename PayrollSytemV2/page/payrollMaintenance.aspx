<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="payrollMaintenance.aspx.vb" Inherits="PayrollSytemV2.payrollMaintenance" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Payroll Maintenance
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Data
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Payroll Maintenance
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="box box-warning">
            <div class="box-body">
            <div class="col-md-12">
                 
                 <div class="row">
                     <br />
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Payroll Code</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPayrollCode" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-block btn-primary btn-md" />
                        </div>
                       
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvPayrollMain" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvPayrollMain_RowDataBound" 
                                OnSelectedIndexChanged="gvPayrollMain_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvPayrollMain_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="payroll_code" HeaderText="Payroll Code"  />
                                    <asp:BoundField DataField="date_gen" HeaderText="Date Generated"  />
                                    <asp:BoundField DataField="date_from" HeaderText="Date From"  />
                                    <asp:BoundField DataField="date_to" HeaderText="Date To"  />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-block btn-danger btn-md" />
                        </div>
                    </div>
                 </div>
             </div>
            <!-- this is bootstrp modal popup -->  
             <div id="myModal" class="modal fade ">  
                <div class="modal-dialog">  
                    <div class="modal-content">  
                        <div class="modal-header">  
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>  
                            <h4 class="modal-title modal-warning">Administrator Password</h4>  
                        </div>  
                        <asp:UpdatePanel ID="UPmodal" runat="server" UpdateMode="Conditional"> 
                            <ContentTemplate>
                                <div class="modal-body" >
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="messagealert" id="alert_container">
                                            </div>
                                        </div>
                                    </div>
                                     <br />
                             
                                    <div class='form-group'>
                                        <div class="row">
                                            <div class='col-sm-12 col-md-5 '>
                                                Enter Administrator Password 
                                            </div>
                                            <div class='col-sm-12 col-md-5 '>
                                                <asp:TextBox ID="txtPassword" runat="server"  type="text" TextMode="Password" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                                            </div>
                                            <div class='col-sm-12 col-md-2 '>
                                                <asp:Button ID="btnOK" runat="server" Text="OK" class="btn btn-block btn-primary btn-md" OnClick="btnOK_Click" />
                                           </div>
                                        </div>
                                    </div>  
                            
                                </div>  
               
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>  
                </div>  
             
            </div>  
         
            <!-- end -->
             </div>
             </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
