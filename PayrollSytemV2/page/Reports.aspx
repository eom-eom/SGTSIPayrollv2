<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="Reports.aspx.vb" Inherits="PayrollSytemV2.Reports" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Reports
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Reports
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="server">
    <asp:Button Text="Payroll Journal" runat="server" ID="btnPayrollJournal" class="btn  btn-primary btn-flat" />
    <asp:Button Text="Pay Slip" runat="server" ID="btnPaySlip" class="btn  btn-primary btn-flat" />
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
                     <asp:Label ID="lblCompanyName" runat="server" Text="CompanyName"></asp:Label>
                     <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                     <asp:Label ID="lblTelNo" runat="server" Text="TelNO"></asp:Label>
                 </div>
                 <div class="row">
                     <br />
                     <div class="row">
                        <div class="col-md-2">
                            <h5>Payroll Code</h5>
                        </div>
                        <div class="col-md-4">
                           <asp:DropDownList class="form-control select2"  ID="ddlPayrollCode" runat="server" AutoPostBack="false" >
                            </asp:DropDownList> 
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-block btn-primary btn-md" />
                        </div>
                    </div>   
                 </div>
                <br />
                 <div class="row">
                     <div class="col-md-12">
                         <asp:MultiView ID="mvReports" runat="server">
                             <asp:View ID="PanelPayrollJournal" runat="server">
                                 <CR:CrystalReportViewer ID="crvPayrollJournal" runat="server" AutoDataBind="true" ToolPanelView="None" />
                             </asp:View>
                             <asp:View ID="PanelPaySlip" runat="server">
                                 <CR:CrystalReportViewer ID="crvPaySlip" runat="server" AutoDataBind="true" ToolPanelView="None" />
                             </asp:View>
                         </asp:MultiView>                    
                     </div>
                 </div>
             </div>
             </div>
             </div>
       
</asp:Content>
