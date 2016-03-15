<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="LateAndUndertimeTable.aspx.vb" Inherits="PayrollSytemV2.LateAndUndertimeTable" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Late and Undertime Table
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Late and Undertime Table
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
                             <asp:RadioButton id="rbLate" runat="server" GroupName="CO" Text="Late" ></asp:RadioButton>
                         </div>
                         <div class="col-md-2">
                             <asp:RadioButton id="rbUndertime" runat="server" GroupName="CO" Text="Undertime"></asp:RadioButton>
                         </div>

                        
                    </div>
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Shift</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList class="form-control select2"  ID="ddlShift" runat="server" AutoPostBack="false" >
                                
                            </asp:DropDownList> 

                        </div>
                         <div class="col-md-2">
                            <h5>From</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtFrom" runat="server"  type="time" CssClass='form-control' ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                        
                    </div>
                     <br />
                      <div class="row">
                        <div class="col-md-2">
                            <h5>Percentage</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPercentage" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>To</h5>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtTo" runat="server"  type="time" CssClass='form-control' ClientIDMode="Static"></asp:TextBox>
                            
                        </div>
                    </div>
                   <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvLateUndertime" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvLateUndertime_RowDataBound" 
                                OnSelectedIndexChanged="gvLateUndertime_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvLateUndertime_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="lu_type" HeaderText="Type"  />
                                    <asp:BoundField DataField="lu_from" HeaderText="From"  />
                                    <asp:BoundField DataField="lu_to" HeaderText="To"  />
                                    <asp:BoundField DataField="shift_name" HeaderText="Shift"  />
                                    <asp:BoundField DataField="lu_percentage" HeaderText="Percentage"  />
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
