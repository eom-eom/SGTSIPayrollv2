<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="DTRUpload.aspx.vb" Inherits="PayrollSytemV2.DTRUpload" %>
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
    <style type="text/css">
        .FixedHeader {
            position:relative;
            font-weight: bold;
            font-size:small;
        }     
    </style>
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
                        <div style ="width:inherit; overflow:auto;" >
                        <asp:GridView ID="gvDTR" runat="server" class="table table-responsive table-bordered table-striped dataTable" AutoGenerateColumns="true" HeaderStyle-Font-Size="Smaller" AllowCustomPaging="true" >
                        </asp:GridView>
                        </div>
                    </div>
                </div>
             </div>
             <div class="row">
                 <asp:Label ID="lblORate" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblORegSH" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblOExSH" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblOSHandO" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblORegLH" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblOExLH" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblOLHandOT" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblORegSun" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblOExSun" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblORegLHSun" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblOExLHSun" runat="server" Text="Label" Visible="false"></asp:Label>
                 <asp:Label ID="lblONightDiff" runat="server" Text="Label" Visible="false"></asp:Label>
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
