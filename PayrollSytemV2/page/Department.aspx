<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="Department.aspx.vb" Inherits="PayrollSytemV2.Department" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Department
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Department
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
                            <h5>Department Name</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDeptName" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Department Description</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDeptDesc" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvDepartment" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvDepartment_RowDataBound" 
                                OnSelectedIndexChanged="gvDepartment_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvDepartment_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="name" HeaderText="Name"  />
                                    <asp:BoundField DataField="description" HeaderText="Description"  />
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
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-block btn-success btn-md"  />
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
