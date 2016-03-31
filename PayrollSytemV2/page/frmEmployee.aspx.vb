Imports System.Drawing
Imports System.Globalization

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


            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(5) {New DataColumn("comde_code"), New DataColumn("comde_desc"), _
                                                    New DataColumn("emp_comde_amt"), New DataColumn("emp_comde_start_date"), _
                                                   New DataColumn("emp_comde_end_date"), New DataColumn("emp_deduct_type")})
            ViewState("comp_de") = dt
            Me.BindGrid()
            If Not Session("Empid") = "" Then
                'fillDept()
                UISetValues(Session("Empid"))
                Session("intEmp") = "0"
            End If
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
        ddPos.Items.Clear()
        Dim dt As DataTable = cdb1.PosGetListWhereClause("job_titles.is_deleted = '1' AND job_titles.dept_id = '" & Label2.Text & "' ")
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
        ddComde.DataValueField = "comde_code"
        ddComde.DataTextField = "comde_Desc"
        ddcomde.DataSource = dsGrid
        ddcomde.DataBind()
        ddcomde.Text = Nothing
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
        'If Not IsPostBack Then

        'Else

        'End If
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
    Protected Sub LcancelEmployee_Click(sender As Object, e As EventArgs) Handles LcancelEmployee.Click
        Session.RemoveAll()
        Response.Redirect("Employee.aspx")
    End Sub

    Protected Sub LSaveEmployee_Click(sender As Object, e As EventArgs) Handles LSaveEmployee.Click

        Dim empRec, empTaxAllw, empDeminimisBen, empLeaves As New ArrayList()
        Dim empComde As DataTable = Nothing


        If Not txtEmpcode.Text = "" Then
            cEmployee.id = Session("Empid")
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
            cEmployee.night_rate = Trim(txtNightDiff.Text)
            cEmployee.def_shift_id = ddShift.SelectedValue
            cEmployee.def_time_in = Format(CDate(Trim(txtTimeIn.Text)), "hh:mm:ss tt")
            cEmployee.def_time_out = Format(CDate(Trim(txtTimeOut.Text)), "hh:mm:ss tt")
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
                cEmployee.sunday = "1"
            Else
                cEmployee.sunday = "0"
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

                        empRec.Add(row.Cells(2).Text)
                        'cEmployee.rta_id = row.Cells(1).Text
                    End If
                End If
            Next

            For Each row As GridViewRow In gvEmpTaxAllow.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If chkRow.Checked Then

                        empTaxAllw.Add(row.Cells(2).Text)
                    End If
                End If
            Next
            'cEmployee.emp_rta_deleted = "1"

            '
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


            If gvEmpCompanyDeduction.Rows.Count = 0 Then
                empComde = Nothing
            Else
                empComde = DirectCast(ViewState("comp_de"), DataTable)
                For x = 0 To empComde.Rows.Count - 1 Step 1
                    If empComde.Rows(x).Item(5).ToString = "Halfmonth" Then
                        empComde.Rows(x).Item(5) = "0"
                    Else
                        empComde.Rows(x).Item(5) = "1"
                    End If
                Next
            End If




            For Each row As GridViewRow In gvLeaves.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If gvLeaves.Rows.Count = 0 Then
                        Exit For
                    End If
                    If chkRow.Checked Then
                        empLeaves.Add(row.Cells(1).Text)
                    End If
                End If
            Next

            For Each row As GridViewRow In gvDeminimis.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If gvDeminimis.Rows.Count = 0 Then
                        Exit For
                    End If
                    If chkRow.Checked Then
                        empDeminimisBen.Add(row.Cells(2).Text)
                    End If
                End If
            Next

            'cEmployee.emp_comde_deleted = "1"
            Dim cdb As New EmploymentInfoDB
            If Not Session("intEmp") = "0" Then
                cEmployee = cdb.EmployeeInsertFile(cEmployee, empRec, empTaxAllw, empComde, empLeaves, empDeminimisBen)

                'ShowMessage("Employee Sucessfully Added.", MessageType.Success, Me)
                MsgBox("Employee added successfully.")
                Session("intEmp") = "1"
            Else

                cEmployee = cdb.EmployeeUpdateFile(cEmployee, empRec, empTaxAllw, empComde, empLeaves, empDeminimisBen)
                MsgBox("Employee edited successfully.")
                ' ShowMessage("Employee Sucessfully Edited", MessageType.Success, Me)
                Session("intEmp") = "2"
            End If


            clearMe()
            Session.RemoveAll()
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
                DirectCast(ctl, TextBox).Text = String.Empty

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
                Label2.Text = .department_id
                Dim cdb1 As New JobTitleDB
                ddPos.Items.Clear()
                Dim dtJobtitle As DataTable = cdb1.PosGetListWhereClause("job_titles.is_deleted = '1' AND job_titles.dept_id = '" & Label2.Text & "' ")
                ddPos.DataValueField = "job_title_id"
                ddPos.DataTextField = "job_title_name"
                ddPos.DataSource = dtJobtitle
                ddPos.DataBind()
                ddPos.SelectedValue = .job_title_id
                Label3.Text = ddDept.SelectedItem.Text


                ddEmpType.Text = .employment_status
                txtDateHired.Text = .date_hired
                txtaddress.Text = .address
                ddJobstats.Text = .job_status
                txtDateResigned.Text = .date_resigned
                txtBasicSalary.Text = .basic_salary
                txtDailyRate.Text = .daily_rate
                txtHrRate.Text = .hour_rate
                txtNightDiff.Text = .night_rate
                Dim datteIN, datteOut As DateTime
                datteIN = DateTime.ParseExact(.def_time_in, "hh:mm:ss tt", CultureInfo.CurrentCulture)
                datteOut = DateTime.ParseExact(.def_time_out, "hh:mm:ss tt", CultureInfo.CurrentCulture)

                txtTimeIn.Text = datteIN.ToString("HH:mm:ss", CultureInfo.CurrentCulture)
                txtTimeOut.Text = datteOut.ToString("HH:mm:ss", CultureInfo.CurrentCulture)
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
                ddShift.SelectedValue = .def_shift_id
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

                'working days pa...

                If .monday = "1" Then
                    chkMonday.Checked = True
                Else
                    chkMonday.Checked = False
                End If

                If .tuesday = "1" Then
                    chkTuesday.Checked = True
                Else
                    chkTuesday.Checked = False
                End If

                If .wednesday = "1" Then
                    chkWednesday.Checked = True
                Else
                    chkWednesday.Checked = False
                End If

                If .thursday = "1" Then
                    chkThursday.Checked = True
                Else
                    chkThursday.Checked = False
                End If

                If .friday = "1" Then
                    chkFriday.Checked = True
                Else
                    chkFriday.Checked = False
                End If

                If .saturday = "1" Then
                    chkSaturday.Checked = True
                Else
                    chkSaturday.Checked = False
                End If

                If .sunday = "1" Then
                    chkSunday.Checked = True
                Else
                    chkSunday.Checked = False
                End If
            End With

            'call here of the functions I've set
            Dim dtEmpRecTax As DataTable = cdb.EmployeeGetListWhereClauseofRAT("emp_id = " & value)
            For Each row As GridViewRow In gvEmpRec.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If dtEmpRecTax.Rows.Count = 0 Then
                        Exit For
                    End If
                    For x = 0 To dtEmpRecTax.Rows.Count - 1 Step 1
                        If row.Cells(2).Text = dtEmpRecTax.Rows(x).Item(0).ToString Then
                            chkRow.Checked = True
                        End If
                    Next
                End If
            Next
            For Each row As GridViewRow In gvEmpTaxAllow.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If dtEmpRecTax.Rows.Count = 0 Then
                        Exit For
                    End If
                    For x = 0 To dtEmpRecTax.Rows.Count - 1 Step 1
                        If row.Cells(2).Text = dtEmpRecTax.Rows(x).Item(0).ToString Then
                            chkRow.Checked = True
                        End If
                    Next
                End If
            Next

            '-------company deduction----------
            Dim dtEmpComde As DataTable = cdb.EmployeeGetListWhereClauseofCompanyDeductions("emp_id = " & value)
            For x = 0 To dtEmpComde.Rows.Count - 1 Step 1
                If dtEmpComde.Rows(x).Item(5).ToString = "0" Then
                    dtEmpComde.Rows(x).Item(5) = "Halfmonth"
                Else
                    dtEmpComde.Rows(x).Item(5) = "Endmonth"
                End If
            Next
            ViewState("comp_de") = dtEmpComde
            Me.BindGrid()
            UPGvEmpComde.Update()

            '-------leaves------------------
            Dim dtEmpLeaves As DataTable = cdb.EmployeeGetListWhereClauseofLeaves("emp_id = " & value)
            For Each row As GridViewRow In gvLeaves.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If dtEmpLeaves.Rows.Count = 0 Then
                        Exit For
                    End If
                    For x = 0 To dtEmpLeaves.Rows.Count - 1 Step 1
                        If row.Cells(1).Text = dtEmpLeaves.Rows(x).Item(0).ToString Then
                            chkRow.Checked = True
                        End If
                    Next
                End If
            Next

            Dim dtEmpDMB As DataTable = cdb.EmployeeGetListWhereClauseofDeMinimisBen("emp_id = " & value)
            For Each row As GridViewRow In gvDeminimis.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If dtEmpDMB.Rows.Count = 0 Then
                        Exit For
                    End If
                    For x = 0 To dtEmpDMB.Rows.Count - 1 Step 1
                        If row.Cells(2).Text = dtEmpDMB.Rows(x).Item(0).ToString Then
                            chkRow.Checked = True
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub gvEmpRec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvEmpRec.SelectedIndexChanged

        For Each row As GridViewRow In gvEmpRec.Rows
            If row.RowIndex = gvEmpRec.SelectedIndex Then
                Session("Recid") = gvEmpRec.SelectedRow.Cells(1).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                ' row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                'row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub



    Protected Sub gvEmpCompanyDeduction_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvEmpCompanyDeduction, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.Cells(1).Text
        End If
        ' UPGvEmpComde.Update()
    End Sub
    Protected Sub gvEmpRec_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvEmpRec, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.Cells(1).Text
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
                txtNightDiff.Text = Format(CDbl((CDbl(txtHrRate.Text) * 1.25 * 0.1) + (CDbl(txtHrRate.Text * 1.25))), "0.00")
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub LAddComde_Click(sender As Object, e As EventArgs) Handles LAddComde.Click
        'show modal
        selectedComde.Text = "Select"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "myModal", "$('#myModal').modal()", True)
    End Sub

    'Protected Sub LAddLeaves_Click(sender As Object, e As EventArgs) Handles LAddLeaves.Click
    '    For Each row As GridViewRow In gvLeaves.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
    '            If chkRow.Checked Then
    '                MsgBox(row.Cells(1).Text)
    '            End If
    '        End If
    '    Next
    'End Sub

    'Protected Sub LAddDmns_Click(sender As Object, e As EventArgs) Handles LAddDmns.Click
    '    For Each row As GridViewRow In gvDeminimis.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
    '            If chkRow.Checked Then
    '                MsgBox(row.Cells(1).Text)
    '            End If
    '        End If
    '    Next
    'End Sub
    Protected Sub ddShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddShift.SelectedIndexChanged
        Dim cdb As New ShiftsDB
        Dim dt As DataTable = cdb.ShiftGetListWhereClause("is_deleted = '1' AND id = '" & ddShift.SelectedValue & "' ")
        Dim datteIN, datteOut As DateTime
        datteIN = DateTime.ParseExact(dt.Rows(0).Item(2).ToString, "hh:mm:ss tt", CultureInfo.CurrentCulture)
        datteOut = DateTime.ParseExact(dt.Rows(0).Item(3).ToString, "hh:mm:ss tt", CultureInfo.CurrentCulture)
        txtTimeIn.Text = datteIN.ToString("HH:mm:ss", CultureInfo.CurrentCulture)
        txtTimeOut.Text = datteOut.ToString("HH:mm:ss", CultureInfo.CurrentCulture)
        'Format(CDate(dt.Rows(0).Item(3).ToString), "HH:MM:ss tt")


    End Sub

    Protected Sub ddComde_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddComde.SelectedIndexChanged
        If IsPostBack Then
            lblTheChosenOne.Text = ddcomde.SelectedValue & "-" & ddComde.selecteditem.Text
        End If
        UPmodal.Update()
    End Sub

    Protected Sub BindGrid()
        gvEmpCompanyDeduction.DataSource = DirectCast(ViewState("comp_de"), DataTable)
        gvEmpCompanyDeduction.DataBind()
    End Sub
    Protected Sub selectedComde_Click(sender As Object, e As EventArgs) Handles selectedComde.Click

        ' insertCompanyDeductions()
        'check muna if nasa gridview na po
        'check muna si gridview

        If Not txtComdeAmt.Text = "" Then
            Dim dt As DataTable = DirectCast(ViewState("comp_de"), DataTable)
            If selectedComde.Text = "Update" And dt.Rows.Count <> 0 Then
                For x = 0 To dt.Rows.Count - 1 Step 1

                    If dt.Rows(x).Item(0).ToString = gvEmpCompanyDeduction.SelectedRow.Cells(0).Text Then
                        dt.Rows(x).Delete()
                        dt.AcceptChanges()
                        ViewState("comp_de") = dt
                        Me.BindGrid()
                        Exit For
                    End If
                Next
            End If
            dt.Rows.Add(ddComde.SelectedValue, ddComde.SelectedItem.Text, Trim(txtComdeAmt.Text), txtComdeStart.Text, txtComdeEnd.Text, ddDeductType.SelectedItem.Text)
            ViewState("comp_de") = dt
            Me.BindGrid()
            'updating modal and gridview
            UPmodal.Update()
            UPGvEmpComde.Update()

            'How do I close the modal after my codings ????? :)))) 
        Else
            ShowMessage_mod("Invalid Amount", MessageType.Success, Me)
        End If
        ddComde.Text = Nothing
        txtComdeAmt.Text = String.Empty
        txtComdeStart.Text = String.Empty
        txtComdeEnd.Text = String.Empty
        ddDeductType.Text = Nothing
    End Sub

    Protected Sub gvEmpCompanyDeduction_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvEmpCompanyDeduction.Rows
            If row.RowIndex = gvEmpCompanyDeduction.SelectedIndex Then
                'gvEmpCompanyDeduction.SelectedRow.Cells(1).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                ' row.ToolTip = String.Empty
                'Exit For
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                'row.ToolTip = "Click to select this row."
            End If
        Next
        ' UPGvEmpComde.Update()
    End Sub




    Protected Sub LEditComde_Click(sender As Object, e As EventArgs) Handles LEditComde.Click
        If gvEmpCompanyDeduction.Rows.Count <> 0 Then
            If IsNothing(gvEmpCompanyDeduction.SelectedRow) Then

                ShowMessage("Please select record.", MessageType.Errors, Me)
                Exit Sub

            End If
            selectedComde.Text = "Update"

            ddComde.SelectedValue = gvEmpCompanyDeduction.SelectedRow.Cells(0).Text
            txtComdeAmt.Text = gvEmpCompanyDeduction.SelectedRow.Cells(2).Text
            txtComdeStart.Text = gvEmpCompanyDeduction.SelectedRow.Cells(3).Text
            txtComdeEnd.Text = gvEmpCompanyDeduction.SelectedRow.Cells(4).Text
            If gvEmpCompanyDeduction.SelectedRow.Cells(5).Text = "Halfmonth" Then
                ddDeductType.SelectedIndex = 0
            Else
                ddDeductType.SelectedIndex = 1
            End If

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "myModal", "$('#myModal').modal()", True)

        Else
            ShowMessage("No record(s).", MessageType.Errors, Me)
        End If

    End Sub




    Protected Sub LDeleteComde_Click(sender As Object, e As EventArgs) Handles LDeleteComde.Click
        If gvEmpCompanyDeduction.Rows.Count <> 0 Then
            If IsNothing(gvEmpCompanyDeduction.SelectedRow) Then

                ShowMessage("Please select record.", MessageType.Errors, Me)
                Exit Sub

            End If
            Dim dt As DataTable = DirectCast(ViewState("comp_de"), DataTable)
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For x = 0 To dt.Rows.Count - 1 Step 1
                    If dt.Rows(x).Item(0).ToString = gvEmpCompanyDeduction.SelectedRow.Cells(0).Text Then
                        dt.Rows(x).Delete()
                        dt.AcceptChanges()
                        ViewState("comp_de") = dt
                        Me.BindGrid()
                        Exit For
                    End If
                Next
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub
End Class