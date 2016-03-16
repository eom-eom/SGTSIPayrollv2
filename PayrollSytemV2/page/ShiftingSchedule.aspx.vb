Imports System.Drawing

Public Class ShiftingSchedule
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cSSched As New ShiftingSchedules
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFromDate.Enabled = False
        txtToDate.Enabled = False

        If Not IsPostBack Then
            FillShiftDDL()
            FillEmployeeDDL()
        End If

        fillSSched()
    End Sub
    Public Sub FillShiftDDL()
        Dim cdb As New ShiftsDB
        Dim dt As DataTable = cdb.ShiftsListDDL

        ddlShift.DataValueField = "id"
        ddlShift.DataTextField = "shift"

        ddlShift.DataSource = dt
        ddlShift.DataBind()
    End Sub
    Public Sub FillEmployeeDDL()
        Dim cdb As New EmploymentInfoDB
        Dim dt As DataTable = cdb.EmpListDDL

        ddlSelectEmp.DataValueField = "emp_id"
        ddlSelectEmp.DataTextField = "fullname"

        ddlSelectEmp.DataSource = dt
        ddlSelectEmp.DataBind()
    End Sub
    Private Sub fillSSched()
        Dim cdb As New ShiftingScheduleDB
        dsGrid = cdb.ShiftingSchedGetList()
        gvShifting.DataSource = dsGrid
        gvShifting.DataBind()
    End Sub

    Protected Sub gvShifting_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvShifting, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvShifting_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvShifting.Rows
            If row.RowIndex = gvShifting.SelectedIndex Then
                Session("SSchedid") = gvShifting.SelectedRow.Cells(0).Text
                ddlSelectEmp.SelectedValue = gvShifting.SelectedRow.Cells(1).Text
                ddlShift.SelectedValue = gvShifting.SelectedRow.Cells(2).Text
                txtFromDate.Text = gvShifting.SelectedRow.Cells(3).Text
                txtToDate.Text = gvShifting.SelectedRow.Cells(4).Text

                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvShifting_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvShifting.PageIndex = e.NewPageIndex
        gvShifting.DataBind()
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtFromDate.Enabled = True
        txtToDate.Enabled = True
        Session("intSSched") = "1"
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtFromDate.Text = "" And Not txtToDate.Text = "" Then
            cSSched.emp_id = ddlSelectEmp.SelectedValue
            cSSched.shift_id = ddlShift.SelectedValue
            cSSched.date_from = txtFromDate.Text
            cSSched.date_to = txtToDate.Text
            cSSched.date_applied = Format(Date.Now, "yyyy-MM-dd")
            cSSched.is_deleted = "1"

            Dim cdb As New ShiftingScheduleDB
            If Not Session("intSSched") = "0" Then
                cSSched = cdb.ShiftingSchedInsertFile(cSSched)
                ShowMessage("Shifting Schedule Sucessfully Added", MessageType.Success, Me)
            Else
                cSSched.id = Session("SSChedid")
                cSSched = cdb.ShiftingSchedUpdateFile(cSSched)
                ShowMessage("Shifting Schedule Sucessfully Editted", MessageType.Success, Me)
                Session("SSChedid") = ""
            End If


            fillSSched()

        Else
            ShowMessage("From and To Date must not be blank", MessageType.Warning, Me)

        End If

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvShifting.Rows.Count <> 0 Then
            If Not Session("SSchedid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cSSched.id = Session("SSchedid")
                    cSSched.emp_id = ddlSelectEmp.SelectedValue
                    cSSched.shift_id = ddlShift.SelectedValue
                    cSSched.date_from = txtFromDate.Text
                    cSSched.date_to = txtToDate.Text
                    cSSched.date_applied = Format(Date.Now, "yyyy-mm-dd")
                    cSSched.is_deleted = "0"

                    Dim cdb As New ShiftingScheduleDB
                    cSSched = cdb.ShiftingSchedUpdateFile(cSSched)
                    fillSSched()

                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvShifting.Rows.Count <> 0 Then
            If Not Session("SSchedid") = "" Then
                Session("intSSched") = "0"
                txtFromDate.Enabled = True
                txtToDate.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class
