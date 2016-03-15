
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="frmEmployee.aspx.vb" Inherits="PayrollSytemV2.frmEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Employee form
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    New/Update <%--condition kung ano pinindodfgfdghdhfkjt--%>  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Employee form
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="server">


    
      
             <asp:Button Text="Details" runat="server" OnClick="btnPInfo_Click" ID="btnPInfo" class="btn  btn-primary btn-flat" />
         
      
            <asp:Button Text="Compensation" runat="server" OnClick="btnComp_Click" ID="btnComp" class="btn btn-primary btn-flat" />
      
            <asp:Button Text="Receivables/Taxable allowances." runat="server" OnClick="btnRecATax_Click" ID="btnRecATax" class="btn btn-primary btn-flat"  />
         
             <asp:Button Text="Deductions" runat="server" OnClick="btnDed_Click" ID="btn_Ded" class="btn  btn-primary btn-flat"/>
         
            <asp:Button Text="History" runat="server" OnClick="btnHistory_Click" ID="btn_history" class="btn  btn-primary btn-flat"/>
       
            <asp:Button Text="Leave/Deminimis" runat="server" OnClick="btnLD_Click" ID="btnLD" class="btn  btn-primary btn-flat"/>
         
   
        
   
   
    
    
   
    <asp:UpdatePanel ID="UP1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:MultiView ID="multiviews" runat="server"  >
        <asp:View ID="viewDetails" runat="server">
            <div class ="row">
                <div class=" col-md-12">
           
            <div class=" box box-warning">
                <div class =" box-header with-border">
                    <h4>Details</h4>
                </div>
            
                    
                    <div class ="box-body">
                        <div class =" row">
                                <div class ="col-md-6">
                                    <div class='form-group'>
                                        <div class ="row">
                                            <div class='col-sm-12 col-md-3 '>
                                                <asp:label id="lblEmpcode"  class='control-label' Text="Employee no.:" runat="server"  /> 
                                            </div>
                                
                                            <div class='col-sm-12 col-md-9'>
                                                <asp:TextBox ID="txtEmpcode" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" />
                                            </div>
                                        </div>
                                        
                                    </div>
                                    
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblLastname"  class='control-label' Text="Last name:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    <asp:TextBox ID="txtLastname" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" />
                                            </div>  
                                        </div>
                                     </div>

                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblFirstname"  class='control-label' Text="First name:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    <asp:TextBox ID="txtFirstname" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" />
                                            </div>  
                                        </div>
                                     </div>

                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblMidname"  class='control-label' Text="Middle name:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    <asp:TextBox ID="txtMiddlename" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" />
                                            </div>  
                                        </div>
                                     </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblBday"  class='control-label' Text="Birthday:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-5'>
                                                    <asp:TextBox ID="txtBirthday" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static" >100</asp:TextBox>
                                            </div>  
                                        </div>
                                     </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblAddress"  class='control-label' runat="server" Text="Address:*" /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    <asp:TextBox ID="txtaddress" runat="server"  CssClass='form-control'  textmode="multiline" ClientIDMode="Static" style = "resize:none" Height=" 80px"></asp:TextBox>
                                            </div>  
                                        </div>
                                     </div> 
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblMobileNo"  class='control-label' Text="Mobile no.:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    <asp:TextBox ID="txtMobile" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" />
                                            </div>  
                                        </div>
                                     </div>

                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblTel"  class='control-label' Text="Telephone no.:" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    <asp:TextBox ID="txtTelephone" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" />
                                            </div>  
                                        </div>
                                     </div>
                                    
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblNationaly"  class='control-label' Text="Nationality:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    
                                                    <asp:TextBox ID="txtNationality" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" />
                                            
                                            </div>  
                                        </div>
                                     </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblEmail"  class='control-label' Text="E-mail Address:*" runat="server" /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    <asp:TextBox ID="txtEmail" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" />
                                            </div>  
                                        </div>
                                     </div>
                                    
                                </div>
                                <div class ="col-md-6">
                                     <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblDept"  class='control-label' Text="Department:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    
                                                <asp:DropDownList class="form-control select2"  ID="ddDept" runat="server" 
                                                     OnSelectedIndexChanged="ddDept_SelectedIndexChanged" AutoPostBack="True" >
                                                    
                                                </asp:DropDownList> 
                                            
                                            </div>  
                                        </div>
                                      </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblPos"  class='control-label' Text="Job title:*" runat="server" /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    
                                                    <asp:DropDownList class="form-control "  ID="ddPos" runat="server" AutoPostBack="True" >
                                                    
                                                </asp:DropDownList> 
                                            
                                            </div>  
                                        </div>
                                     </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lbltype"  class='control-label' Text="Employment type:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                    
                                                    <asp:DropDownList class="form-control select2"  ID="ddEmpType" runat="server" AutoPostBack="False" >
                                                       <asp:ListItem>Probitionary</asp:ListItem>
                                                        <asp:ListItem>Regular</asp:ListItem>
                                                        <asp:ListItem>Part-time</asp:ListItem>
                                                </asp:DropDownList> 
                                            
                                            </div>  
                                        </div>
                                     </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblDateHired"  class='control-label' Text="Date Hired:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-5'>
                                                    <asp:TextBox ID="txtDateHired" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                                            </div>  
                                        </div>
                                     </div> 
                                    
                                    
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblStatus"  class='control-label' Text="Job status:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                   <asp:DropDownList class="form-control "  ID="ddJobstats" runat="server" AutoPostBack="True" >
                                                </asp:DropDownList> 
                                            </div>  
                                        </div>
                                     </div> 
                                      <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblTax_stats"  class='control-label' Text="Tax type:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-9'>
                                                   <asp:DropDownList class="form-control select2"  ID="ddTax" runat="server" AutoPostBack="True" >
                                                </asp:DropDownList> 
                                            </div>  
                                            <div id="selectedM"></div>
                                        </div>
                                     </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblLastEmployer"  class='control-label' Text="Last Employer:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-5'>
                                                  
                                                    <asp:TextBox ID="txtLastEmployer" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                                               
                                            </div>  
                                        </div>
                                     </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblLEmpDtRes"  class='control-label' Text="Date resigned in last employer:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-5'>
                                                   
                                                    <asp:TextBox ID="txtLEmpDtRes" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                                            
                                            </div>  
                                        </div>
                                     </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="Label2"  class='control-label' Text="here lalabas id ng departments" runat="server"  /> 
                                            </div>
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="Label3"  class='control-label' Text="here lalabas id departments" runat="server"  /> 
                                            </div>
                                           
                                        </div>
                                     </div>
                                </div>
                            </div> 
                    </div>
                    <br />  
                 
                </div>
            
            </div>
        </div>

        </asp:View>
        <asp:View ID="viewCompensation" runat="server">  
            <div class ="row">
                <div class=" col-md-12">
                    <div class=" box box-warning">
                        <div class =" box-header with-border">
                            <h4>Compensation</h4>
                        </div>
                        
                            <div class ="box-body">
                                <div class ="row">
                                    
                                       <div class ="col-md-4">
                                            <div class='form-group'>
                                                <div class ="row">
                                                    <div class='col-sm-12 col-md-3 '>
                                                        <asp:label id="lblBasicSalary"  class='control-label' Text="Basic Salary:*" runat="server"  /> 
                                                    </div>
                                                    
                                                    <div class='col-sm-12 col-md-9'>
                                                        <div class =" input-group">
                                                            
                                                            <asp:TextBox ID="txtBasicSalary" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" />
                                                            <span class="input-group-addon">PHP</span>
                                                        </div>
                                                    </div>
                                                    
                                                </div>
                                        
                                            </div>
                                           <div class='form-group'>
                                                <div class ="row">
                                                    <div class='col-sm-12 col-md-3 '>
                                                        
                                                        <asp:label id="lblDailyRate"  class='control-label' Text="Daily Rate:" runat="server"  /> 
                                                        
                                                        
                                                    </div>
                                
                                                    <div class='col-sm-12 col-md-9'>
                                                        <div class =" input-group">
                                                            
                                                                <asp:TextBox ID="txtDailyRate" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" ReadOnly="True" />
                                                                <span class="input-group-addon">PHP</span>
                                                        </div>                                                                
                                                    </div>
                                                    
                                                </div>
                                        
                                            </div>
                                           
                                           <div class='form-group'>
                                                <div class ="row">
                                                    <div class='col-sm-12 col-md-3 '>
                                                        <asp:label id="lblHrRate"  class='control-label' Text="Hour Rate:" runat="server"  /> 
                                                    </div>
                                
                                                    <div class='col-sm-12 col-md-9'>
                                                        <div class =" input-group">
                                                            
                                                        <asp:TextBox ID="txtHrRate" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" ReadOnly="True" />
                                                            <span class="input-group-addon">PHP</span>
                                                        </div>
                                                    </div>
                                                </div>
                                        
                                            </div>
                                           <div class='form-group'>
                                                <div class ="row">
                                                    <div class='col-sm-12 col-md-3 '>
                                                        <asp:label id="lblshift"  class='control-label' Text="Shift:*" runat="server"  /> 
                                                    </div>
                                
                                                    <div class='col-sm-12 col-md-9'>
                                                        <asp:DropDownList class="form-control select2"  ID="ddShift" runat="server"  >
                                                    
                                                        </asp:DropDownList> 
                                                    </div>
                                                   
                                                </div>
                                        
                                            </div>
                                    <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblTimeIn"  class='control-label' Text="Time in:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-5'>
                                                    <asp:TextBox ID="txtTimeIn" runat="server"  type="time" CssClass='form-control'  ClientIDMode="Static" >100</asp:TextBox>
                                            </div>  
                                        </div>
                                     </div>
                                      <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="Label1"  class='control-label' Text="Time out:*" runat="server"  /> 
                                            </div>
                                        
                                            <div class='col-sm-12 col-md-5'>
                                                    <asp:TextBox ID="txtTimeOut" runat="server"  type="time" CssClass='form-control'  ClientIDMode="Static" >100</asp:TextBox>
                                            </div>  
                                        </div>
                                     </div>
                                    </div>

                                    <!-- WORKING DAYS, BONUS and GOVERNMENT ID'S-->
                                        <div class =" col-md-8">
                                           
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class='col-md-6 col-sm-12'>
                                                        <div class=" box box-warning">
                                                            <div class =" box-header with-border">
                                                                <h5>Working days</h5>
                                                            </div>
                                                            <div class ="box-body">
                                                                <div class ="row">
                                                                    <div class='col-md-6 col-sm-12'>
                                                                        <div class =" form-group">
                                                                            <div class ="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="chkMonday" runat="server" />
                                                                                    Monday
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                        <div class =" form-group">
                                                                            <div class ="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="chkTuesday" runat="server" />
                                                                                    Tuesday
                                                                                </label>
                                                                            </div>
                                                                        </div>    
                                                                        <div class =" form-group">
                                                                            <div class ="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="chkWednesday" runat="server" />
                                                                                    Wednesday
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                        <div class =" form-group">
                                                                            <div class ="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="chkThursday" runat="server" />
                                                                                    Thursday
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class='col-md-6 col-sm-12'>
                                                                        <div class =" form-group">
                                                                            <div class ="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="chkFriday" runat="server" />
                                                                                    Friday
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                        <div class =" form-group">
                                                                            <div class ="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="chkSaturday" runat="server" />
                                                                                    Saturday
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                        <div class =" form-group">
                                                                            <div class ="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="chkSunday" runat="server" />
                                                                                    Sunday
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class='col-md-6 col-sm-12'>
                                                        <div class=" box box-warning">
                                                            <div class =" box-header with-border">
                                                                <h5>Bonus</h5>
                                                            </div>
                                                            <div class ="box-body">
                                                                <div class ="row">
                                                                    <div class="col-md-12 col-sm-12">
                                                                        <div class =" form-group">
                                                                            <div class ="checkbox">
                                                                                <label>
                                                                                    <asp:CheckBox ID="chk13month" runat="server" />
                                                                                    13month pay
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                    </div>
                                                </div>
                                                
                                            </div>

                                        </div>

                                    <div class="form-group">
                                     
                                        <div class="row">
                                            <div class='col-md-12 col-sm-12'>
                                                
                                                        <div class=" box box-warning">
                                                            <div class =" box-header with-border">
                                                                <h5>Contributions</h5>
                                                            </div>
                                                            <div class ="box-body">
                                                                <div class ="row">
                                                                    <div class='col-sm 12 col-md-6'>
                                                                        <div class='form-group'>
                                                                            <div class =" row">
                                                                                <div class='col-sm-12 col-md-3'>
                                                                                    <asp:label id="lblTin"  class='control-label' Text="Tin no.:" runat="server"  /> 
                                                                                </div>
                                        
                                                                                <div class='col-sm-12 col-md-9'>
                                                                                        <asp:TextBox ID="txtTin" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" ></asp:TextBox>
                                                                                </div>  
                                                                            </div>
                                                                         </div>
                                                                        <div class='form-group'>
                                                                            <div class =" row">
                                                                                <div class='col-sm-12 col-md-3'>
                                                                                    <asp:label id="lblSSS"  class='control-label' Text="SSS no.:" runat="server"  /> 
                                                                                </div>
                                        
                                                                                <div class='col-sm-12 col-md-9'>
                                                                                        <asp:TextBox ID="txtSSS" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" ></asp:TextBox>
                                                                                </div>  
                                                                            </div>
                                                                         </div>
                                                                    </div>
                                                                    <div class='col-sm 12 col-md-6'>
                                                                        <div class='form-group'>
                                                                            <div class =" row">
                                                                                <div class='col-sm-12 col-md-3'>
                                                                                    <asp:label id="lblPagibig"  class='control-label' Text="Pagibig no.:" runat="server"  /> 
                                                                                </div>
                                        
                                                                                <div class='col-sm-12 col-md-9'>
                                                                                        <asp:TextBox ID="txtPagibig" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" ></asp:TextBox>
                                                                                </div>  
                                                                            </div>
                                                                         </div>
                                                                        <div class='form-group'>
                                                                            <div class =" row">
                                                                                <div class='col-sm-12 col-md-3'>
                                                                                    <asp:label id="lblPH"  class='control-label' Text="Philhealth no.:" runat="server"  /> 
                                                                                </div>
                                        
                                                                                <div class='col-sm-12 col-md-9'>
                                                                                        <asp:TextBox ID="txtPH" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" ></asp:TextBox>
                                                                                </div>  
                                                                            </div>
                                                                         </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        
                                                 </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                             </div>
                       
                    </div>
                 </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="viewRAT" runat="server"> 
            <div class ="row">
                <div class=" col-md-12">
                    <div class=" box box-warning">
                        <div class =" box-header with-border">
                            <h4>Receivables and Taxable Allowances</h4>
                        </div>
                        
                            <div class ="box-body">
                                <div class ="row">
                                    <div class=" col-md-6 col-sm-12">
                                        <div class="form-group">
                                                <div class="row">
                                                    <div class='col-md-12 col-sm-12'>
                                                        <div class=" box box-warning">
                                                            <div class =" box-header with-border">
                                                                <h5>Receivables</h5>
                                                            </div>
                                                            
                                                            <div class ="box-body">

                                                                <div class ="row">
                                                                    <div class =" col-md-12">
                                                                        <asp:dropdownlist ID="ddRecList" class=" form-control select2" runat="server" >
                                                                          
                                                                        </asp:dropdownlist>
                                                                    </div>
                                                                 </div>
                                                                <br />
                                                                <div class ="row">
                                                                    <div class =" col-md-12">
                                                                        <asp:ListView ID="ListView1" runat="server" ItemType="details">
                                                                            <EmptyDataTemplate>
                                                                                <asp:Label runat="server"> ID</asp:Label>
                                                                            </EmptyDataTemplate>
                                                                        </asp:ListView>
                                                                        
                                                                    </div>
                                                                 </div>
                                                            </div>
                                                                
                                                        </div>
                                                   </div>        
                                               </div>
                                          </div> 
                                        <div class="form-group">
                                            <div class ="row">
                                                <div class='col-sm-offset-8 col-sm-4  col-md-offset-8 col-md-4 '> 
                                                    <asp:Linkbutton ID="lAddR" runat="server"  class="btn btn-primary  "> <span class='fa fa-plus'></span>Add</asp:Linkbutton>          
       
                                                    <asp:Linkbutton ID="lDeleteR" runat="server" class="btn btn-danger   "> <span class='fa  fa-times'></span> Delete </asp:Linkbutton>  
                                                </div>
        
                                            </div>
                                        </div>               
                                    </div>
                                    <div class=" col-md-6 col-sm-12">
                                        <div class="form-group">
                                                <div class="row">
                                                    <div class='col-md-12 col-sm-12'>
                                                        <div class=" box box-warning">
                                                            <div class =" box-header with-border">
                                                                <h5>Taxable allowances</h5>
                                                            </div>
                                                            <div class ="box-body">
                                                                <div class ="row">
                                                                    <div class =" col-md-12">
                                                                        <asp:dropdownlist ID="ddTaxlist" class=" form-control select2" multiple="multiple" runat="server">
                                                                          
                                                                        </asp:dropdownlist>
                                                                    </div>
                                                                 </div>
                                                                </div>
                                                        </div>
                                                   </div>        
                                               </div>
                                          </div>
                                        <div class="form-group">
                                            <div class ="row">
                                                <div class='col-sm-offset-8 col-sm-4  col-md-offset-8 col-md-4 '> 
                                                    <asp:Linkbutton ID="LAddTA" runat="server"  class="btn btn-primary  "> <span class='fa fa-plus'></span>Add</asp:Linkbutton>          
       
                                                    <asp:Linkbutton ID="LDeleteTA" runat="server" class="btn btn-danger   "> <span class='fa  fa-times'></span> Delete </asp:Linkbutton>  
                                                </div>
        
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                     </div>
                  </div>
              </div>

         

        </asp:View>
        <asp:View ID="viewDeductions" runat="server">
            <div class=" row">
                <div class="col-md-12">
                    <div class=" box box-warning">
                        <div class =" box-header with-border">
                            <h4>Deductions</h4>
                        </div>
                            <div class ="box-body">
                                <div class ="row">
                                   <div class ="col-md-3 col-sm-12">
                                       <div class=" box box-warning">
                                            <div class =" box-header with-border">
                                                <h5>Government Deductions</h5>
                                            </div>
                                                <div class ="box-body">
                                                    <div class ="row">
                                                        <div class=" col-md-12 col-sm-12">
                                                            <div class="form-group">
                                                                <div class ="checkbox">
                                                                    <label>
                                                                        <asp:CheckBox ID="chkSSS" runat="server" />
                                                                        SSS
                                                                    </label>    
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class ="checkbox">
                                                                    <label>
                                                                        <asp:CheckBox ID="chkPhilhealth" runat="server" />
                                                                        Philhealth
                                                                    </label>    
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class ="checkbox">
                                                                    <label>
                                                                        <asp:CheckBox ID="chkHDMF" runat="server" />
                                                                        HDMF
                                                                    </label>    
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                    <div class ="col-md-9 col-sm-12">
                                        <div class=" box box-warning">
                                            <div class =" box-header with-border">
                                                <h5>Company Deductions</h5>
                                            </div>
                                                <div class ="box-body">
                                                    <div class ="row">
                                                        <div class="col-md-12 col-sm-12">
                                                        
                                                            <!-- table here -->

                                                            
                                                        </div>
                                                    </div>
                                                </div>
                                           </div>
                                        <div class="form-group">
                                            <div class ="row">
                                                <div class='col-sm-offset-9 col-sm-3  col-md-offset-9 col-md-3 '> 
                                                    <asp:Linkbutton ID="LAddComde" runat="server"  class="btn btn-primary  "> <span class='fa fa-plus'></span>Add</asp:Linkbutton>          
       
                                                    <asp:Linkbutton ID="LDeleteComde" runat="server" class="btn btn-danger   "> <span class='fa  fa-times'></span> Delete </asp:Linkbutton>  
                                                </div>
        
                                            </div>
                                        </div>
                                   </div>
                                </div>
                            </div>
                        
                    </div>
                </div> 
                <div class="col-md-9 col-sm-12">

                </div>
                
            </div>
        </asp:View>
        <asp:View ID="viewHistory" runat="server">
            <div class=" row">
                <div class="col-md-12">
                    <div class=" box box-warning">
                        <div class =" box-header with-border">
                            <h4>History</h4>
                        </div>
                            <div class ="box-body">
                                <div class ="row">
                                   <div class ="col-md-12 col-sm-12">
                                       
                                    </div>
                                </div>
                                   </div>
                                </div>
                            </div>
                    </div>
              
        </asp:View>
        <asp:View ID ="viewLvDmns" runat="server">
            <div class ="row">
                <div class=" col-md-12">
                    <div class=" box box-warning">
                        <div class =" box-header with-border">
                            <h4>Leaves and De minimis Benefits</h4>
                        </div>
                        
                            <div class ="box-body">
                                <div class ="row">
                                    <div class=" col-md-6 col-sm-12">
                                        <div class="form-group">
                                                <div class="row">
                                                    <div class='col-md-12 col-sm-12'>
                                                        <div class=" box box-warning">
                                                            <div class =" box-header with-border">
                                                                <h5>Leaves</h5>
                                                            </div>
                                                            <div class ="box-body">
                                                                <div class ="row">
                                                                 </div>
                                                                </div>
                                                        </div>
                                                   </div>        
                                               </div>
                                          </div> 
                                        <div class="form-group">
                                            <div class ="row">
                                                <div class='col-sm-offset-8 col-sm-4  col-md-offset-8 col-md-4 '> 
                                                    <asp:Linkbutton ID="LAddLeaves" runat="server"  class="btn btn-primary"> <span class='fa fa-plus'></span>Add</asp:Linkbutton>          
       
                                                    <asp:Linkbutton ID="LDeleteLeaves" runat="server" class="btn btn-danger "> <span class='fa  fa-times'></span> Delete </asp:Linkbutton>  
                                                </div>
        
                                            </div>
                                        </div>               
                                    </div>
                                    <div class=" col-md-6 col-sm-12">
                                        <div class="form-group">
                                                <div class="row">
                                                    <div class='col-md-12 col-sm-12'>
                                                        <div class=" box box-warning">
                                                            <div class =" box-header with-border">
                                                                <h5>De minimis Benefits</h5>
                                                            </div>
                                                            <div class ="box-body">
                                                                <div class ="row">
                                                                 </div>
                                                                </div>
                                                        </div>
                                                   </div>        
                                               </div>
                                          </div>
                                        <div class="form-group">
                                            <div class ="row">
                                                <div class='col-sm-offset-8 col-sm-4  col-md-offset-8 col-md-4 '> 
                                                    <asp:Linkbutton ID="LAddDmns" runat="server"  class="btn btn-primary"> <span class='fa fa-plus'></span>Add</asp:Linkbutton>          
       
                                                    <asp:Linkbutton ID="LDeleteDmns" runat="server" class="btn btn-danger "> <span class='fa  fa-times'></span> Delete </asp:Linkbutton>  
                                                </div>
        
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                     </div>
                  </div>
              </div>
        </asp:View>
        </asp:MultiView>
        <br />
    <div class ="row">
        <div class='col-sm-offset-8 col-sm-4  col-md-offset-10 col-md-2 '> 
            <asp:Linkbutton ID="LcancelEmployee" runat="server"  class="btn btn-default  "> Cancel</asp:Linkbutton>          
       
            <asp:Linkbutton ID="LSaveEmployee" runat="server" class="btn btn-success   "> <span class='fa fa-check'></span> Save </asp:Linkbutton>  
        </div>
        
    </div>

        </ContentTemplate>

    </asp:UpdatePanel>
    
    
    
                    
                           
                      
  
    
</asp:Content>
