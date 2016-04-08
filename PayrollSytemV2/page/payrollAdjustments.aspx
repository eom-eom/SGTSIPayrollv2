    <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="payrollAdjustments.aspx.vb" Inherits="PayrollSytemV2.payrollAdjustments" EnableEventValidation ="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Payrol adjustment
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Payroll adjustment
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">

<ContentTemplate>
    <div class =" row">
        <div class="col-md-12">
            <div class="messagealert" id="alert_container">
            </div>
        </div>
    </div>
   <br />
    <div class="box box-warning">
        <div class =" box-header with-border">
            <h4>Adjustments</h4>
        </div>
        <div class="box-body">
            
            
            <div class=" row">
                <div class="col-md-6 ">
                    <div class='form-group'>
                        <div class ="row">
                            <div class='col-sm-12 col-md-3 '>
                                <asp:label id="lblEmpcode"  class='control-label' Text="Employee code:" runat="server"  /> 
                            </div>
                                
                            <div class='col-sm-12 col-md-9'>
                                <asp:DropDownList class="form-control select2"  ID="ddEmployeeCode" runat="server" OnSelectedIndexChanged ="ddEmployeeCode_SelectedIndexChanged" 
                                       Width =" 100%" Height =" 2.5em" enabled =" false" AutoPostBack ="true"> 
                                    </asp:DropDownList>
                            </div>
                          
                    
                        </div>           
                    </div>

                    <div class='form-group'>
                        <div class ="row">
                            <div class='col-sm-12 col-md-3 '>
                                <asp:label id="lblEmpname"  class='control-label' Text="Employee name:" runat="server"  /> 
                            </div>
                                
                            <div class='col-sm-12 col-md-9'>
                                <asp:TextBox ID="TxtEmpname" runat="server"  type="textbox" CssClass='form-control'  ClientIDMode="Static" ReadOnly="true" />
                            </div>
                        </div>           
                    </div>

                    <div class='form-group'>
                        <div class ="row">
                            <div class='col-sm-12 col-md-3 '>
                                <asp:label id="lblDTapplied"  class='control-label' Text="Date applied:" runat="server"  /> 
                            </div>
                                
                            <div class='col-sm-12 col-md-5'>
                                <asp:TextBox ID="txtDtApplied" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static" ReadOnly="true" />
                            </div>
                        </div>           
                    </div>
                    <div class='form-group'>
                        <div class ="row">
                            <div class='col-sm-12 col-md-3 '>
                                <asp:label id="lblDToccur"  class='control-label' Text="Date occur:" runat="server"  /> 
                            </div>
                                
                            <div class='col-sm-12 col-md-5'>
                                <asp:TextBox ID="txtDtoccur" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static"  />
                            </div>
                        </div>           
                    </div>
                </div>
                <div class="col-md-6">
                    <div class='form-group'>
                        <div class ="row">
                            <div class='col-sm-12 col-md-3 '>
                                <asp:label id="lblAmount"  class='control-label' Text="Amount:" runat="server"  /> 
                            </div>
                                
                            <div class='col-sm-12 col-md-9'>
                                <asp:TextBox ID="txtAmount" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"  />
                            </div>
                        </div>           
                    </div>
                    <div class='form-group'>
                        <div class ="row">
                            <div class='col-sm-12 col-md-3 '>
                                <asp:label id="lblReason"  class='control-label' Text="Reason:" runat="server"  /> 
                            </div>
                                
                            <div class='col-sm-12 col-md-9'>
                                <asp:TextBox ID="txtReason" runat="server"  type="text"  TextMode="MultiLine" Height=" 80px" style = "resize:none" CssClass='form-control'  ClientIDMode="Static"  />
                            </div>
                        </div>           
                    </div>
                </div>
            </div> 
            <div class="row">
                <div class="col-md-12 ">
                    <asp:GridView ID="gvEmpPayrollAdj" runat="server" 
                            class="table responsive table-bordered table-condensed table-hover table-striped dataTable" 
                            OnRowDataBound="gvEmpPayrollAdj_RowDataBound"
                            OnSelectedIndexChanged="gvEmpPayrollAdj_SelectedIndexChanged" AutoGenerateColumns="false" 
                            AllowPaging ="true" PageSize="15" OnPageIndexChanging="gvEmpPayrollAdj_PageIndexChanging"
                            EmptyDataText="No Record/s Found." DataKeyNames="id">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" visible="false"  />
                                <asp:BoundField DataField="emp_code" HeaderText="Employee Code" />
                                <asp:BoundField DataField="name" HeaderText="Name"  />
                                <asp:BoundField DataField="date_created" HeaderText="Date created"  />
                                <asp:BoundField DataField="date_occur" HeaderText="Date occur"  />
                                <asp:BoundField DataField="amount" HeaderText="Amount"  />
                                <asp:BoundField DataField="status" HeaderText="Status"  />
                                <asp:BoundField DataField="remarks" HeaderText="Reason"  />
                            </Columns>
                         </asp:GridView>
                </div>
            </div> 
                  
                    <br />
                            <div class="col-md-3">
                           <asp:LinkButton ID="btnNew" runat="server" Text="New" class="btn btn-block btn-primary btn-md-3"  />  
                          </div>
                        <div class=" col-md-3">
                           <asp:LinkButton  ID="btnEdit" runat="server" Text="Edit" class="btn btn-block btn-warning btn-md-3" />  
                          </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-block btn-success btn-md" />
                        </div>
                        <div class=" col-md-3">
                           <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" class="btn btn-block btn-danger btn-md-3" />  
         </div>
    </div> 
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
