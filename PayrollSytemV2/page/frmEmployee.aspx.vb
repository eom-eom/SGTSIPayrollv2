Imports System.Drawing
Public Class frmEmployee
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cEmployee As New EmployeeInfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            multiviews.SetActiveView(viewDetails)
            fillRec()
            fillTaxableAllowance()
            fillDept()
            fillShift()
            fillCompanyDeduction()
            fillLeaves()
            fillDeminimis()
        End If

        If Not Session("Empid") = "" Then
            UISetValues(Session("Empid"))
            Session("intEmp") = "0"
        
        End If

    End Sub
    Private Sub fillRec()
        Dim cdb As New ReceivablesAndTaxableDB
        dsGrid = cdb.fillReceivables()
        gvEmpRec.DataSource = dsGrid
        gvEmpRec.DataBind()
        'ddRecList.DataValueField = "rta_code"
        'ddRecList.DataTextField = "rta_desc"
        'ddRecList.DataSource = dsGrid
        'ddRecList.DataBind()
        'ddRecList.Text = Nothing
    End Sub

    Private Sub fillTaxableAllowance()
        Dim cdb As New ReceivablesAndTaxableDB
        dsGrid = cdb.fillTaxable()
        gvEmpTaxAllow.DataSource = dsGrid
        gvEmpTaxAllow.DataBind()

    End Sub
    Private Sub fillDept()
        Dim cdb As New DepartmentDB
        dsGrid = cdb.DeptGetList()
        ddDept.DataValueField = "id"
        ddDept.DataTextField = "name"
        ddDept.DataSource = dsGrid
        ddDept.DataBind()
        Label2.Text = ddDept.SelectedValue
        Label3.Text = ddDept.SelectedItem.Text
        Dim cdb1 As New JobTitleDB


        Dim dt As DataTable = cdb1.PosGetListWhereClause("job_titles.is_deleted = '1' AND job_titles.dept_id = '" & Label2.Text & "' ")
        ddPos.Items.Clear()

        ddPos.DataValueField = "job_title_id"
        ddPos.DataTextField = "job_title_name"
        ddPos.DataSource = dt
        ddPos.DataBind()
    End Sub
    Private Sub fillShift()
        Dim cdb As New ShiftsDB
        dsGrid = cdb.ShiftsList()
        ddShift.DataValueField = "id"
        ddShift.DataTextField = "shift_name"

        ddShift.DataSource = dsGrid
        ddShift.DataBind()
        Dim cdb1 As New ShiftsDB


        Dim dt As DataTable = cdb.ShiftGetListWhereClause("is_deleted = '1' AND id = '" & ddShift.SelectedValue & "' ")
        txtTimeIn.Text = dt.Rows(0).Item(2).ToString
        txtTimeOut.Text = dt.Rows(0).Item(3).ToString

    End Sub
    Private Sub fillCompanyDeduction()
        Dim cdb As New CompanyDeductionDB
        dsGrid = cdb.CDGetList()
        gvCompanyDeduction.DataSource = dsGrid
        gvCompanyDeduction.DataBind()
    End Sub
    Private Sub fillLeaves()
        Dim cdb As New LeaveTypesDB
        dsGrid = cdb.LeaveTypesGetList()
        gvLeaves.DataSource = dsGrid
        gvLeaves.DataBind()
    End Sub
    Private Sub fillDeminimis()
        Dim cdb As New DeMinimisBenefitDB
        dsGrid = cdb.DMBGetList()
        gvDeminimis.DataSource = dsGrid
        gvDeminimis.DataBind()
    End Sub
    'Protected Sub Unnamed1_Click(sender As Object, e As EventArgs)
    '    multiviews.SetActiveView(view1)
    'End Sub

    'Protected Sub Unnamed2_Click(sender As Object, e As EventArgs)
    '    multiviews.SetActiveView(view2)
    'End Sub

    'Protected Sub Unnamed3_Click(sender As Object, e As EventArgs)
    '    multiviews.SetActiveView(view3)
    'End Sub

    Protected Sub btnPInfo_Click(sender As Object, e As EventArgs) Handles btnPInfo.Click
        multiviews.SetActiveView(viewDetails)
    End Sub

    Protected Sub btnComp_Click(sender As Object, e As EventArgs) Handles btnComp.Click
        multiviews.SetActiveView(viewCompensation)
    End Sub

    Protected Sub btnRecATax_Click(sender As Object, e As EventArgs) Handles btnRecATax.Click
        multiviews.SetActiveView(viewRAT)
    End Sub
    Protected Sub btnDed_Click(sender As Object, e As EventArgs) Handles btn_Ded.Click
        multiviews.SetActiveView(viewDeductions)
    End Sub



    Protected Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btn_history.Click
        multiviews.SetActiveView(viewHistory)
    End Sub

    Protected Sub btnLD_Click(sender As Object, e As EventArgs) Handles btnLD.Click
        multiviews.SetActiveView(viewLvDmns)
    End Sub




    Protected Sub ddDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddDept.SelectedIndexChanged
        If IsPostBack Then
            Label2.Text = ddDept.SelectedValue
            Label3.Text = ddDept.SelectedItem.Text
        End If

        Dim cdb As New JobTitleDB


        Dim dt As DataTable = cdb.PosGetListWhereClause("job_titles.is_deleted = '1' AND job_titles.dept_id = '" & Label2.Text & "' ")
        ddPos.Items.Clear()

        ddPos.DataValueField = "job_title_id"
        ddPos.DataTextField = "job_title_name"
        ddPos.DataSource = dt
        ddPos.DataBind()
    End Sub
    Protected Sub ddJobstats_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddJobstats.SelectedIndexChanged
        If IsPostBack Then
            If ddJobstats.SelectedItem.Text = "Resigned" Or ddJobstats.SelectedItem.Text = "Terminated" Then
                txtDateResigned.Enabled = True
            Else
                txtDateResigned.Enabled = False
                txtDateResigned.Text = ""
            End If
        End If
       
    End Sub


    Protected Sub LSaveEmployee_Click(sender As Object, e As EventArgs) Handles LSaveEmployee.Click
        Dim rec_Val, comde_Val, taxAllow_val As New ArrayList()


        If Not txtEmpcode.Text = "" Then

            cEmployee.code = Trim(txtEmpcode.Text)
            cEmployee.first_name = Trim(txtFirstname.Text)
            cEmployee.last_name = Trim(txtLastname.Text)
            cEmployee.middle_name = Trim(txtMiddlename.Text)
            cEmployee.birthday = Trim(txtBirthday.Text)
            cEmployee.address = Trim(txtaddress.Text)
            cEmployee.mobile = Trim(txtMobile.Text)
            cEmployee.telephone = Trim(txtTelephone.Text)
            cEmployee.nationality = Trim(txtNationality.Text)
            cEmployee.email = Trim(txtEmail.Text)
            cEmployee.department_id = ddDept.SelectedValue
            cEmployee.job_title_id = ddPos.SelectedValue
            cEmployee.employment_status = ddEmpType.Text
            cEmployee.date_hired = Trim(txtDateHired.Text)
            cEmployee.job_status = ddJobstats.Text
            cEmployee.tax_comp = ddTax.Text
            cEmployee.emp_last_employer = Trim(txtLastEmployer.Text)
            cEmployee.basic_salary = Trim(txtBasicSalary.Text)
            cEmployee.daily_rate = Trim(txtDailyRate.Text)
            cEmployee.hour_rate = Trim(txtHrRate.Text)
            cEmployee.def_shift_id = ddShift.SelectedValue
            cEmployee.def_time_in = Trim(txtTimeIn.Text)
            cEmployee.def_time_out = Trim(txtTimeOut.Text)
            If chk13month.Checked = True Then
                cEmployee.w_13monthpay = "1"
            Else
                cEmployee.w_13monthpay = "0"
            End If
            cEmployee.tin_no = Trim(txtTin.Text)
            cEmployee.sss_no = Trim(txtSSS.Text)
            cEmployee.pagibig_no = Trim(txtPagibig.Text)
            cEmployee.philhealth_no = Trim(txtPH.Text)
            If chkSSS.Checked = True Then
                cEmployee.w_sss = "1"
            Else
                cEmployee.w_sss = "0"
            End If
            If chkHDMF.Checked = True Then
                cEmployee.w_hdmf = "1"
            Else
                cEmployee.w_hdmf = "0"
            End If
            If chkPhilhealth.Checked = True Then
                cEmployee.w_philhealth = "1"
            Else
                cEmployee.w_philhealth = "0"
            End If

            cEmployee.is_deleted = "1"

            If chkMonday.Checked = True Then
                cEmployee.monday = "1"
            Else
                cEmployee.monday = "0"
            End If

            If chkTuesday.Checked = True Then
                cEmployee.tuesday = "1"
            Else
                cEmployee.tuesday = "0"
            End If

            If chkWednesday.Checked = True Then
                cEmployee.wednesday = "1"
            Else
                cEmployee.wednesday = "0"
            End If

            If chkThursday.Checked = True Then
                cEmployee.thursday = "1"
            Else
                cEmployee.thursday = "0"
            End If

            If chkFriday.Checked = True Then
                cEmployee.friday = "1"
            Else
                cEmployee.friday = "0"
            End If

            If chkSaturday.Checked = True Then
                cEmployee.saturday = "1"
            Else
                cEmployee.saturday = "0"
            End If
            If chkSunday.Checked = True Then
                chkSunday.Text = "1"
            Else
                chkSunday.Text = "0"
            End If

            If chk13month.Checked = True Then
                cEmployee.w_13monthpay = "1"
            Else
                cEmployee.w_13monthpay = "0"
            End If

            For Each row As GridViewRow In gvEmpRec.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If chkRow.Checked Then
                        rec_Val.Add(row.Cells(1).Text)
                    End If
                End If
            Next
            For Each row As GridViewRow In gvEmpTaxAllow.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If chkRow.Checked Then
                        taxAllow_val.Add(row.Cells(1).Text)
                    End If
                End If
            Next
            If chkSSS.Checked = True Then
                cEmployee.w_sss = "1"
            Else
                cEmployee.w_sss = "0"
            End If

            If chkPhilhealth.Checked = True Then
                cEmployee.w_philhealth = "1"
            Else
                cEmployee.w_philhealth = "0"
            End If

            If chkHDMF.Checked = True Then
                cEmployee.w_hdmf = "1"
            Else
                cEmployee.w_hdmf = "0"
            End If

            For Each row As GridViewRow In gvCompanyDeduction.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If chkRow.Checked Then

                        comde_Val.Add(row.Cells(1).Text)
                    End If
                End If
            Next

            'cEmployee.emp_comde_deleted = "1"
            Dim cdb As New EmploymentInfoDB
            If Not Session("intEmp") = "0" Then
                cEmployee = cdb.EmployeeInsertFile(cEmployee, rec_Val, taxAllow_val, comde_Val)

                ShowMessage("Employee Sucessfully Added.", MessageType.Success, Me)
            Else
                cEmployee.id = Trim(txtEmpcode.Text)
                cEmployee = cdb.EmployeeUpdateFile(cEmployee)
                ShowMessage("Employee Sucessfully Edited", MessageType.Success, Me)
            End If


            clearMe()
            Response.Redirect("Employee.aspx")


        Else
            ShowMessage("Code must not be blank", MessageType.Warning, Me)

            '    Dim cdb As New DepartmentDB
            '    If Not Session("intSE") = "0" Then
            '        cDepartment = cdb.DeptInsertFile(cDepartment)
            '        ShowMessage("Department Sucessfully Added", MessageType.Success, Me)
            '    Else
            '        cDepartment.id = Session("Deptid")
            '        cDepartment = cdb.DeptUpdateFile(cDepartment)
            '        ShowMessage("Department Sucessfully Edited", MessageType.Success, Me)
            '    End If

            '    txtDeptDesc.Text = ""
            '    txtDeptName.Text = ""
            '    fillDept()

            'Else
            '    ShowMessage("Code must not be blank", MessageType.Warning, Me)

        End If
    End Sub
    Public Sub clearMe(Optional ByVal ctlcol As ControlCollection = Nothing)
        If ctlcol Is Nothing Then ctlcol = Me.Controls
        For Each ctl As Control In ctlcol
            If TypeOf (ctl) Is TextBox Then
                DirectCast(ctl, TextBox).Text = Nothing

            ElseIf TypeOf (ctl) Is DropDownList Then
                DirectCast(ctl, DropDownList).Text = Nothing
            Else
                If Not ctl.Controls Is Nothing OrElse ctl.Controls.Count <> 0 Then
                    clearMe(ctl.Controls)
                End If
            End If

        Next

    End Sub
    Private Sub UISetValues(ByVal value As String)
        Try

            Dim cdb As New EmploymentInfoDB
            cEmployee = cdb.EmployeeGetFile(pEmployee_id:=value)
            With cEmployee
                txtEmpcode.Text = .code
                txtLastname.Text = .last_name
                txtFirstname.Text = .first_name
                txtMiddlename.Text = .middle_name
                txtBirthday.Text = .birthday
                txtMobile.Text = .mobile
                txtTelephone.Text = .telephone
                txtEmail.Text = .email
                txtNationality.Text = .nationality
                ddDept.SelectedValue = .department_id
                ddPos.SelectedValue = .job_title_id
                ddEmpType.Text = .employment_status
                txtDateHired.Text = .date_hired
                txtaddress.Text = .address
                ddJobstats.Text = .job_status
                'txt.Text = .date_resigned
                txtBasicSalary.Text = .basic_salary
                txtDailyRate.Text = .daily_rate
                txtHrRate.Text = .hour_rate
                txtTimeIn.Text = .def_time_in
                txtTimeOut.Text = .def_time_out
                If .w_13monthpay = "1" Then
                    chk13month.Checked = True
                ElseIf .w_13monthpay = "0" Then
                    chk13month.Checked = False
                End If
                txtTin.Text = .tin_no
                txtSSS.Text = .sss_no
                txtPagibig.Text = .pagibig_no
                txtPH.Text = .philhealth_no
                ddTax.SelectedValue = .tax_comp
                'ddShift.SelectedValue = .def_shift_id
                txtLastEmployer.Text = .emp_last_employer
                txtLEmpDtRes.Text = .prev_employer_date_resigned
                If .w_sss = "1" Then
                    chkSSS.Checked = True
                ElseIf .w_sss = "0" Then
                    chkSSS.Checked = False
                End If
                If .w_hdmf = "1" Then
                    chkHDMF.Checked = True
                ElseIf .w_hdmf = "0" Then
                    chkHDMF.Checked = False
                End If
                If .w_philhealth = "1" Then
                    chkPhilhealth.Checked = True
                ElseIf .w_philhealth = "0" Then
                    chkPhilhealth.Checked = False
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub gvEmpRec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvEmpRec.SelectedIndexChanged
        For Each row As GridViewRow In gvEmpRec.Rows
            If row.RowIndex = gvEmpRec.SelectedIndex Then
                Session("Recid") = gvEmpRec.SelectedRow.Cells(1).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvEmpRec_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvEmpRec, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvEmpRec_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvEmpRec.PageIndex = e.NewPageIndex
        gvEmpRec.DataBind()
    End Sub
    Protected Sub txtBasicSalary_TextChanged(sender As Object, e As EventArgs) Handles txtBasicSalary.TextChanged
        Try
            If IsPostBack Then
                txtDailyRate.Text = Format(CDbl(CDbl(txtBasicSalary.Text) / 21.75), "0.00")
                txtHrRate.Text = Format(CDbl(CDbl(txtDailyRate.Text) / 8), "0.00")
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub LAddComde_Click(sender As Object, e As EventArgs) Handles LAddComde.Click
        For Each row As GridViewRow In gvCompanyDeduction.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
                If chkRow.Checked Then
                    MsgBox(row.Cells(1).Text)
                End If
            End If
        Next
    End Sub

    Protected Sub LAddLeaves_Click(sender As Object, e As EventArgs) Handles LAddLeaves.Click
        For Each row As GridViewRow In gvLeaves.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
                If chkRow.Checked Then
                    MsgBox(row.Cells(1).Text)
                End If
            End If
        Next
    End Sub

    Protected Sub LAddDmns_Click(sender As Object, e As EventArgs) Handles LAddDmns.Click
        For Each row As GridViewRow In gvDeminimis.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
                If chkRow.Checked Then
                    MsgBox(row.Cells(1).Text)
                End If
            End If
        Next
    End Sub
End Class