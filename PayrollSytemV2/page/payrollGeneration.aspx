<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="payrollGeneration.aspx.vb" Inherits="PayrollSytemV2.payroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Payroll Generation
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Data
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Payroll Generation
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
                    <div class="col-md-2">
                        Payroll Code
                    </div>
                    <div class="col-md-10">
                        <asp:Label ID="lblPayrollCode" runat="server" Text="Payroll Code"></asp:Label>
                         <asp:Label ID="lblGovDeSettings" runat="server" Text="GovDeSettings" Visible="false"></asp:Label>
                        <asp:Label ID="lblTaxDeSettings" runat="server" Text="TaxDeSettings"  Visible="false">></asp:Label>
                    </div>
                    
                </div>
                <br />
                <div class="row">
                    <div class="col-md-2">
                        <h5>Date From</h5>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtFrom" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static" OnTextChanged="txtFrom_TextChanged" ></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <h5>Date To</h5>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="TxtTo" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static" OnTextChanged="TxtTo_TextChanged"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnGenerate" runat="server" Text="Generate" class="btn btn-block btn-primary btn-md" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div style ="width:inherit; overflow:auto;" >
                        <asp:GridView ID="gvGenerate" runat="server" class="table table-responsive table-bordered table-striped dataTable" AutoGenerateColumns="true" HeaderStyle-Font-Size="Smaller" >
                        </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div style ="width:inherit; overflow:auto;" >
                        <asp:GridView ID="gvGenerateTotal" runat="server" class="table table-responsive table-bordered table-striped dataTable" AutoGenerateColumns="true" HeaderStyle-Font-Size="Smaller"   >
                        </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            </div>
            </div>

        </ContentTemplate>
         <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtFrom"  />
             <asp:AsyncPostBackTrigger ControlID="txtTo"  />
         </Triggers>
     </asp:UpdatePanel>
</asp:Content>
