﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="DTRUpload.aspx.vb" Inherits="PayrollSytemV2.DTRUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Daily Time Record Upload
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    Control Panel
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
     Daily Time Record Upload
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
                        Browse File
                    </div>
                    <div class="col-md-3">
                        <asp:FileUpload ID="UploadDTR" runat="server"  />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" class="btn btn-block btn-primary btn-md" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="gvDTR" runat="server" class="table table-bordered table-striped dataTable" AutoGenerateColumns="true" >
                        </asp:GridView>
                    </div>
                </div>
             </div>
         </div>
         </div>
         </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>  
    </asp:UpdatePanel>
    
</asp:Content>
