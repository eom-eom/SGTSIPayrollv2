

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="Employee.aspx.vb" Inherits="PayrollSytemV2.Employee" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Employee
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Information
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Employee
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
            <div class="box-body">
                <div class=" row">
                    
                        
                             
                        
                           
                       
                           <div class="col-md-12 ">
                        <asp:GridView ID="gvEmployee" runat="server" 
                            class="table responsive table-bordered table-condensed table-hover table-striped dataTable" 
                            OnRowDataBound="gvEmployee_RowDataBound" 
                            OnSelectedIndexChanged="gvEmployee_SelectedIndexChanged" AutoGenerateColumns="false" 
                            AllowPaging ="true" PageSize="15" OnPageIndexChanging="gvEmployee_PageIndexChanging" 
                            EmptyDataText="No Record/s Found." DataKeyNames="id">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" visible="false"  />
                                <asp:BoundField DataField="code" HeaderText="Employee Code" />
                                <asp:BoundField DataField="name" HeaderText="Name"  />
                                <asp:BoundField DataField="birthday" HeaderText="Birthday"  />
                                <asp:BoundField DataField="mobile" HeaderText="Mobile"  />
                                <asp:BoundField DataField="email" HeaderText="Email"  />
                                <asp:BoundField DataField="employment_status" HeaderText="Employment type"  />
                                <asp:BoundField DataField="dept_name" HeaderText="Department"  />
                                <asp:BoundField DataField="job_name" HeaderText="Position"  />
                            </Columns>
                         </asp:GridView>
                    </div>
                    
                        
                    <br />

                  
                            <div class="col-md-offset-3 col-md-3">
                           <asp:LinkButton ID="btnNew" runat="server" Text="New" class="btn btn-block btn-primary btn-md-3" />  
                          </div>
                        <div class=" col-md-3">
                           <asp:LinkButton  ID="btnEdit" runat="server" Text="Edit" class="btn btn-block btn-warning btn-md-3" />  
                          </div>
                        <div class=" col-md-3">
                           <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" class="btn btn-block btn-danger btn-md-3" />  
                    
                      
          </div>
      </div>
    </div>
        </ContentTemplate>
  </asp:UpdatePanel>
      
  
</asp:Content>
