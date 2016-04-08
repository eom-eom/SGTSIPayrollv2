Imports System.Drawing
Public Class payrollAdjustments
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cPayAdj As New PayrollAdj
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillEmpPayrollAdjustments()
            fillEmployee()
        End If

    End Sub
    Protected Sub fillEmployee()
        Dim cdb As New EmploymentInfoDB
        dsGrid = cdb.EmployeeGetList
        ddEmployeeCode.DataValueField = "name"
        ddEmployeeCode.DataTextField = "code"
        ddEmployeeCode.DataSource = dsGrid
        ddEmployeeCode.DataBind()
        TxtEmpname.Text = ddEmployeeCode.SelectedValue
        ddEmployeeCode.Text = Nothing
    End Sub
    Protected Sub fillEmpPayrollAdjustments()
        Dim cdb As New PayrollAdjDB
        dsGrid = cdb.fillPayrollAdjustments
        gvEmpPayrollAdj.DataSource = dsGrid
        gvEmpPayrollAdj.DataBind()
    End Sub
    Protected Sub gvEmpPayrollAdj_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvEmpPayrollAdj, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub


    Protected Sub gvEmpPayrollAdj_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvEmpPayrollAdj.Rows
            If row.RowIndex = gvEmpPayrollAdj.SelectedIndex Then

                Session("EPAid") = CStr(gvEmpPayrollAdj.DataKeys(gvEmpPayrollAdj.SelectedIndex).Values("id"))
                ddEmployeeCode.SelectedItem.text = gvEmpPayrollAdj.SelectedRow.Cells(1).Text
                txtDtApplied.text = gvEmpPayrollAdj.SelectedRow.Cells(3).Text
                TxtEmpname.text = gvEmpPayrollAdj.SelectedRow.Cells(2).Text
                txtDtoccur.text = gvEmpPayrollAdj.SelectedRow.Cells(4).Text
                txtamount.text = gvEmpPayrollAdj.SelectedRow.Cells(5).Text
                txtReason.text = gvEmpPayrollAdj.SelectedRow.Cells(7).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                ' row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                'row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvEmpPayrollAdj_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvEmpPayrollAdj.PageIndex = e.NewPageIndex
        gvEmpPayrollAdj.DataBind()
    End Sub
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ddEmployeeCode.Enabled = True
        txtDtApplied.text = Format(Date.Now, "yyyy-MM-dd")
        TxtEmpname.Enabled = True
        txtDtoccur.enabled = True
        txtamount.enabled = True
        txtReason.enabled = True
        Session("intEPA") = "1"
        'im here waits
    End Sub
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvEmpPayrollAdj.rows.Count <> 0 Then
            If Not Session("EPAid") = "" Then
                Session("intEPA") = "0"
                ddEmployeeCode.Enabled = True
                TxtEmpname.Enabled = True
                txtDtoccur.enabled = True
                txtamount.enabled = True
                txtReason.enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not ddEmployeeCode.text = Nothing And Not txtDtoccur.Text = "" Then 'dadagdagan pa

            cPayAdj.emp_code = ddEmployeeCode.SelectedItem.text
            cPayAdj.date_created = txtDtApplied.Text
            cpayadj.date_occur = txtDtOccur.text
            cPayAdj.amount = txtAmount.Text
            cPayAdj.remarks = txtReason.Text
            cPayAdj.is_deleted = "1"
            Dim pa As New PayrollAdjDB
            If Not Session("intEPA") = "0" Then
                cpayAdj.status = "NOT YET PAID"
                cPayAdj = pa.EmpPayAdjInsertFile(cPayAdj)
                ShowMessage("Payroll Adjustments Sucessfully Added", MessageType.Success, Me)
            Else
                cPayAdj.id = Session("EPAid")
                If gvEmpPayrollAdj.SelectedRow.Cells(6).Text = "PAID" Then
                    ShowMessage("Payroll adjustment cannot edited because it's paid already.", MessageType.Success, Me)
                    Session("EPAid") = ""
                    GoTo bgry
                End If
                cpayAdj.status = "NOT YET PAID"
                cPayAdj = pa.EmpPayAdjUpdateFile(cPayAdj)
                ShowMessage("Payroll Adjustments Sucessfully Edited", MessageType.Success, Me)
                Session("EPAid") = ""
            End If

bgry:
            txtDtoccur.text = String.empty
            txtDtApplied.text = String.Empty
            txtAmount.text = String.Empty
            txtReason.text = String.empty
            ddEmployeeCode.Enabled = False
            txtDtApplied.text = Format(Date.Now, "yyyy-MM-dd")
            TxtEmpname.Enabled = False
            txtDtoccur.enabled = False
            txtamount.enabled = False
            txtReason.enabled = False
            fillEmpPayrollAdjustments()
            'cCD.comde_code = txtCode.Text
            'cCD.comde_desc = txtDesc.Text
            'cCD.is_deleted = "1"

            'Dim cdb As New CompanyDeductionDB
            'If Not Session("intCD") = "0" Then
            '    cCD = cdb.CDInsertFile(cCD)
            '    ShowMessage("Company Deduction Sucessfully Added", MessageType.Success, Me)
            'Else
            '    cCD.id = Session("CDid")
            '    cCD = cdb.CDUpdateFile(cCD)
            '    ShowMessage("Company Deduction Sucessfully Editted", MessageType.Success, Me)
            '    Session("CDid") = ""
            'End If

            'txtCode.Text = ""
            'txtDesc.Text = ""
            'fillCD()

        Else
            ShowMessage("Code and Description must not be blank", MessageType.Warning, Me)

        End If

    End Sub


    Protected Sub ddEmployeeCode_SelectedIndexChanged(sender As Object, e As EventArgs)
        If IsPostBack Then
            TxtEmpname.Text = ddEmployeeCode.SelectedValue
        End If
    End Sub
End Class