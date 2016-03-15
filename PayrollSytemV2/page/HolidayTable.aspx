<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="HolidayTable.aspx.vb" Inherits="PayrollSytemV2.HolidayTables"  enableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Holiday Table
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Holiday Table
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
                            <h5>Holiday Name</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtHolName" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Day</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDay" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                     <br />
                      <div class="row">
                        <div class="col-md-2">
                            <h5>Holiday Date</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtHolDate" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h5>Category</h5>
                        </div>
                        <div class="col-md-4">
                             <asp:DropDownList class="form-control select2"  ID="ddlHolType" runat="server" AutoPostBack="False" >
                                <asp:ListItem Text="Legal Holiday" Value="Legal Holiday"></asp:ListItem>
                                <asp:ListItem Text="Regular Holiday" Value="Regular Holiday"></asp:ListItem>
                            </asp:DropDownList> 
                        </div>
                    </div>
                    <br />
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Percentage</h5>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPercentge" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                        </div>
                        
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvHolTable" runat="server" class="table table-bordered table-striped dataTable" OnRowDataBound="gvHolTable_RowDataBound" 
                                OnSelectedIndexChanged="gvHolTable_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvHolTable_PageIndexChanging" EmptyDataText="No Record/s Found.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID"  />
                                    <asp:BoundField DataField="holiday_name" HeaderText="Name"  />
                                    <asp:BoundField DataField="holiday_date" HeaderText="Date"  />
                                    <asp:BoundField DataField="holiday_day" HeaderText="Day"  />
                                    <asp:BoundField DataField="holiday_category" HeaderText="Category"  />
                                    <asp:BoundField DataField="holiday_percentage" HeaderText="Percentage"  />
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
