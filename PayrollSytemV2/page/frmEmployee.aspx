
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/index.Master" CodeBehind="frmEmployee.aspx.vb" Inherits="PayrollSytemV2.frmEmployee" Async="true" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHeader" runat="server">
    Employee form
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentSmall" runat="server">
    New/Update <%--condition kung ano pinindot   --%> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBC" runat="server">
    Employee form
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="server">
                
    
                <div class="row">
                    <div class="col-md-12">
                        <div class="messagealert" id="alert_container">
                                
                        </div>
                    </div>
                </div>
    <br />
      
             <asp:Button Text="Details" runat="server" OnClick="btnPInfo_Click" ID="btnPInfo" class="btn  btn-primary btn-flat" />
         
      
            <asp:Button Text="Compensation" runat="server" OnClick="btnComp_Click" ID="btnComp" class="btn btn-primary btn-flat" />
      
            <asp:Button Text="Receivables/Taxable allowances." runat="server" OnClick="btnRecATax_Click" ID="btnRecATax" class="btn btn-primary btn-flat"  />
         
             <asp:Button Text="Deductions" runat="server" OnClick="btnDed_Click" ID="btn_Ded" class="btn  btn-primary btn-flat"/>
         
            <asp:Button Text="History" runat="server" OnClick="btnHistory_Click" ID="btn_history" class="btn  btn-primary btn-flat"/>
       
            <asp:Button Text="Leave/Deminimis" runat="server" OnClick="btnLD_Click" ID="btnLD" class="btn  btn-primary btn-flat"/>
         
   
    <asp:UpdatePanel ID="UP1" runat="server" UpdateMode="Conditional">
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
                                                <asp:TextBox ID="txtEmpcode" runat="server"  type="textbox" CssClass='form-control'  ClientIDMode="Static" />
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
                                                    <asp:TextBox ID="txtEmail" runat="server"  type="text" CssClass='form-control' TextMode="Email"  ClientIDMode="Static" />
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
                                                     OnSelectedIndexChanged="ddDept_SelectedIndexChanged" AutoPostBack="true" >
                                                    
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
                                                    
                                                    <asp:DropDownList class="form-control select2"  ID="ddEmpType" runat="server" AutoPostBack="true" >
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
                                                   <asp:DropDownList class="form-control "  ID="ddJobstats" runat="server" 
                                                       OnSelectedIndexChanged="ddJobstats_SelectedIndexChanged" AutoPostBack ="true">
                                                       <asp:ListItem>Active</asp:ListItem>
                                                        <asp:ListItem>Resigned</asp:ListItem>
                                                        <asp:ListItem>Terminated</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>  
                                        </div>
                                     </div> 
                                      <div class='form-group'>
                                        <div class =" row">
                                            <div class='col-sm-12 col-md-3'>
                                                <asp:label id="lblDateResigned"  class='control-label disabled' Text="Date resigned:" runat="server"  /> 
                                            </div>
                                        <div class='col-sm-12 col-md-5'>
                                                    <asp:TextBox ID="txtDateResigned" runat="server" Enabled="False" type="date" CssClass='form-control disabled'  ClientIDMode="Static"></asp:TextBox>
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
                                                       <asp:ListItem>S</asp:ListItem>
                                                       <asp:ListItem>ME1</asp:ListItem>
                                                       <asp:ListItem>ME2</asp:ListItem>
                                                       <asp:ListItem>ME4</asp:ListItem>
                                                      </asp:DropDownList> 
                                            </div>  
                                            
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
                                                            
                                                            <asp:TextBox ID="txtBasicSalary" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" 
                                                                OnTextChanged="txtBasicSalary_TextChanged" AutoPostBack="true"  />

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
                                                        
                                                        <asp:label id="lblNightDiff"  class='control-label' Text="Night diff rate:" runat="server"  /> 
                                                        
                                                        
                                                    </div>
                                
                                                    <div class='col-sm-12 col-md-9'>
                                                        <div class =" input-group">
                                                            
                                                                <asp:TextBox ID="txtNightDiff" runat="server"  type="text" CssClass='form-control'  ClientIDMode="Static" ReadOnly="True" />
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
                                                        <asp:DropDownList class="form-control select2"  ID="ddShift" 
                                                            AutoPostBack ="true"
                                                            runat="server"  OnSelectedIndexChanged ="ddShift_SelectedIndexChanged" >
                                                    
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
                                                                    <div class ="col-md-12">
                                                                       
                                                                        <asp:GridView ID="gvEmpRec" runat="server" AutoGenerateColumns="false"
                                                                            class="table responsive table-bordered table-condensed table-hover table-striped dataTable"
                                                                            EmptyDataText="No record(s) found.">
                                                                            <%--OnRowDataBound="gvEmpRec_RowDataBound" --%>
                                                                            <%--OnSelectedIndexChanged="gvEmpRec_SelectedIndexChanged"  
                                                                            AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvEmpRec_PageIndexChanging"--%> 
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkRow" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="id" HeaderText="id"  Visible="true" />
                                                                                <asp:BoundField DataField="rta_code" HeaderText="Code" />
                                                                                <asp:BoundField DataField="rta_desc" HeaderText="Description"  />
                                                                                <asp:BoundField DataField="rta_amount" HeaderText="Amount"  />
                                                                                <asp:BoundField DataField="rta_type" HeaderText="Deduction type"  />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                        
                                                                    </div>
                                                                 </div>
                                                              </div>
                                                         </div>    
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
                                                                        <asp:GridView ID="gvEmpTaxAllow" runat="server" AutoGenerateColumns="false"
                                                                            class="table responsive table-bordered table-condensed table-hover table-striped dataTable"
                                                                            EmptyDataText="No record(s) found.">
                                                                            <%--OnRowDataBound="gvEmpRec_RowDataBound" --%>
                                                                            <%--OnSelectedIndexChanged="gvEmpRec_SelectedIndexChanged"  
                                                                            AllowPaging ="true" PageSize="5" OnPageIndexChanging="gvEmpRec_PageIndexChanging"--%> 
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkRow" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="id" HeaderText="id"  Visible="true" />
                                                                                <asp:BoundField DataField="rta_code" HeaderText="Code" />
                                                                                <asp:BoundField DataField="rta_desc" HeaderText="Description"  />
                                                                                <asp:BoundField DataField="rta_amount" HeaderText="Amount"  />
                                                                                <asp:BoundField DataField="rta_type" HeaderText="Deduction type"  />
                                                                            </Columns>
                                                                        </asp:GridView>
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
                                                    
                                                    <asp:UpdatePanel ID="UPGvEmpComde" runat="server" UpdateMode="conditional"> 
                                                         <ContentTemplate>
                                                   <div class="row">
                                                        <div class="col-md-12">
                                                            <asp:GridView ID="gvEmpCompanyDeduction" runat="server" 
                                                                class="table table-hover table-bordered table-striped dataTable" 
                                                                OnRowDataBound ="gvEmpCompanyDeduction_RowDataBound"
                                                               AutoGenerateColumns="false" AllowPaging ="true" PageSize="5"  EmptyDataText="No Record/s Found."
                                                                DataKeyNames="comde_code" OnSelectedIndexChanged ="gvEmpCompanyDeduction_SelectedIndexChanged"
                                                                >
                                                
                                                                <Columns>

                                                                    <%--<asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkRow" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    
                                                                  
                                                                    <asp:BoundField DataField="comde_code" HeaderText="Code"  />
                                                                    <asp:BoundField DataField="comde_desc" HeaderText="Description"  />
                                                                    <asp:BoundField DataField="emp_comde_amt" HeaderText="Amount"  />
                                                                    <asp:BoundField DataField="emp_comde_start_date" HeaderText="Start date"  />
                                                                    <asp:BoundField DataField="emp_comde_end_date" HeaderText="End date"  />
                                                                    <asp:BoundField DataField="emp_deduct_type" HeaderText=" Deduction type"  />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                       
                                                    </div>
                                                             </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    <div class="form-group">
                                                        <div class ="row">
                                                            <div class='col-sm-offset-8 col-sm-4  col-md-offset-8 col-md-4 '> 
                                                                <asp:Linkbutton ID="LAddComde" runat="server"   class="btn btn-primary " > <span class='fa fa-plus'></span> Add</asp:Linkbutton>          
                                                                <asp:Linkbutton ID="LEditComde" runat="server"   class="btn btn-warning " > <span class='fa fa-pencil-square-o'></span> Edit</asp:Linkbutton>   
                                                                <asp:Linkbutton ID="LDeleteComde" runat="server" class="btn btn-danger   "> <span class='fa  fa-times'></span> Delete</asp:Linkbutton>  
                                                            </div>
                                                        </div>
       <!-- this is bootstrp modal popup -->  
         <div id="myModal" class="modal fade ">  
            <div class="modal-dialog">  
                <div class="modal-content">  
                    <div class="modal-header">  
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>  
                        <h4 class="modal-title modal-warning">Company deduction List</h4>  
                    </div>  
                    <asp:UpdatePanel ID="UPmodal" runat="server" UpdateMode="Conditional"> 
                        <ContentTemplate>
                    <div class="modal-body" >
                        <div class="row">
                            <div class="col-md-12">
                                <div class="messagealert" id="alert_container_mod">
                                </div>
                            </div>
                        </div>
                    <br />
                        <div class='form-group'>
                            <div class="row">
                                <div class ="col-md-3">
                                    <asp:label id="lblTheChosenOne"  class='control-label' Text="" runat="server" Visible="true"/> 
                                    
                                    <asp:label id="lblSelect"  class='control-label' Text="Select: " runat="server"/> 
                                </div> 
                                <div class ="col-md-9">
                                    <asp:DropDownList class="form-control select2"  ID="ddComde" runat="server" 
                                        OnSelectedIndexChanged="ddComde_SelectedIndexChanged" AutoPostBack="true" Width =" 100%"  >        
                                    </asp:DropDownList>
                                     
                                </div> 
                            </div>
                        </div>  
                        <div class='form-group'>
                            <div class="row">
                                <div class ="col-md-3">
                                    <asp:label id="lblComdeAmt"  class='control-label' Text="Amount: " runat="server"/> 
                                </div> 
                                <div class ="col-md-5">
                                   <asp:TextBox ID="txtComdeAmt" runat="server" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                                     
                                </div> 
                            </div>
                        </div>
                         <div class='form-group'>
                            <div class="row">
                                <div class='col-sm-12 col-md-3 '>
                                    <asp:label id="dtStart"  class='control-label' Text="Date start:" runat="server"  /> 
                                </div>
                                <div class='col-sm-12 col-md-5 '>
                                    <asp:TextBox ID="txtComdeStart" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                        </div>  
                        <div class='form-group'>
                            <div class="row">
                                <div class='col-sm-12 col-md-3 '>
                                    <asp:label id="dtEnd"  class='control-label' Text="Date end: " runat="server"  /> 
                                </div>
                                <div class ="col-md-5">
                                    <asp:TextBox ID="txtComdeEnd" runat="server"  type="date" CssClass='form-control'  ClientIDMode="Static"></asp:TextBox>
                                    </div>
                            </div>
                        </div>
                           <div class='form-group'>
                            <div class="row">
                                <div class ="col-md-3">
                                   
                                    <asp:label id="lblDedtype"  class='control-label' Text="Deduction type: " runat="server"/> 
                                </div> 
                                <div class ="col-md-5">
                                    <asp:DropDownList class="form-control select2"  ID="ddDeductType" runat="server" 
                                       Width =" 100%"  > 
                                        <asp:ListItem>Halfmonth</asp:ListItem>
                                        <asp:ListItem>Endmonth</asp:ListItem>
                                                                                       
                                    </asp:DropDownList>
                                     
                                </div> 
                            </div>
                        </div>   
                    </div>  
               
                    <div class="modal-footer">  
                        <asp:Linkbutton ID="selectedComde" runat="server" class="btn btn-primary "  OnClick ="selectedComde_Click" > <span class='fa fa-plus'></span> Select</asp:Linkbutton>
                        <button type="button" class="btn btn-default" data-dismiss="modal" >Close</button>  
                          
                    </div>  
                             </ContentTemplate>
            </asp:UpdatePanel>
                </div>  
            </div>  
             
        </div>  
         
        <!-- end -->
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
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <asp:GridView ID="gvLeaves" runat="server" class="table table-bordered table-striped dataTable" 
                                                                           AutoGenerateColumns="false" AllowPaging ="true" PageSize="5"  EmptyDataText="No Record/s Found.">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkRow" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="id" HeaderText="ID"  />
                                                                                <asp:BoundField DataField="leave_desc" HeaderText="Description"  />
                                                                                <asp:BoundField DataField="leave_no_of_days" HeaderText="No of Days"  />
                                                                                <asp:BoundField DataField="leave_convertable" HeaderText="Convertable to Cash"  />
                                                                                <asp:BoundField DataField="w_pay" HeaderText="With Pay"  />
                                                                                
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
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
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <asp:GridView ID="gvDeminimis" runat="server" class="table table-bordered table-striped dataTable" 
                                                                           AutoGenerateColumns="false" AllowPaging ="true" PageSize="5"  EmptyDataText="No Record/s Found.">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkRow" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="id" HeaderText="ID"  />
                                                                                <asp:BoundField DataField="dmb_code" HeaderText="Code"  />
                                                                                <asp:BoundField DataField="dmb_desc" HeaderText="Description"  />
                                                                                <asp:BoundField DataField="dmb_amount" HeaderText="Amount"  />
                                                                                <asp:BoundField DataField="dmb_type" HeaderText="Deduction type"  />
                                                                            </Columns>
                                                                        </asp:GridView>
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
        </asp:MultiView>
        <br />
    <div class ="row">
        <div class='col-sm-offset-8 col-sm-4  col-md-offset-10 col-md-2 '> 
            <asp:Linkbutton ID="LcancelEmployee" runat="server"  class="btn btn-default  "> Cancel</asp:Linkbutton>          
                
            <asp:Linkbutton ID="LSaveEmployee" runat="server" class="btn btn-success   "> <span class='fa fa-check'></span> Save </asp:Linkbutton> 
        </div>
        
    </div>
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddDept" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    
    
    
                    
                           
                      
  
    
</asp:Content>
