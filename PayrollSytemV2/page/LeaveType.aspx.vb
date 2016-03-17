Imports System.Drawing

Public Class LeaveType
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cLeaves As New LeaveTypes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtDesc.Enabled = False
        txtNoDays.Enabled = False

        fillLeaves()
    End Sub

    Protected Sub gvLeaveType_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvLeaveType, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvLeaveType_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvLeaveType.Rows
            If row.RowIndex = gvLeaveType.SelectedIndex Then
                Session("Leavesid") = gvLeaveType.SelectedRow.Cells(0).Text
                txtDesc.Text = gvLeaveType.SelectedRow.Cells(1).Text
                txtNoDays.Text = gvLeaveType.SelectedRow.Cells(2).Text
                If gvLeaveType.SelectedRow.Cells(3).Text = "1" Then
                    cbConvertable.Checked = True
                    cbWithPay.Checked = False
                End If
                If gvLeaveType.SelectedRow.Cells(4).Text = "1" Then
                    cbConvertable.Checked = False
                    cbWithPay.Checked = True
                End If
                If gvLeaveType.SelectedRow.Cells(3).Text = "1" And gvLeaveType.SelectedRow.Cells(4).Text = "1" Then
                    cbConvertable.Checked = True
                    cbWithPay.Checked = True
                End If
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvLeaveType_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvLeaveType.PageIndex = e.NewPageIndex
        gvLeaveType.DataBind()
        txtDesc.Text = ""
        txtNoDays.Text = ""
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtDesc.Enabled = True
        txtNoDays.Enabled = True
        Session("intLeaves") = "1"
    End Sub
    Private Sub fillLeaves()
        Dim cdb As New LeaveTypesDB
        dsGrid = cdb.LeaveTypesGetList()
        gvLeaveType.DataSource = dsGrid
        gvLeaveType.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtDesc.Text = "" And Not txtNoDays.Text = "" Then
            cLeaves.leave_desc = txtDesc.Text
            cLeaves.leave_no_of_days = txtNoDays.Text
            If cbConvertable.Checked = True Then
                cLeaves.leave_convertable = "1"
            Else
                cLeaves.leave_convertable = "0"
            End If
            If cbWithPay.Checked = True Then
                cLeaves.w_pay = "1"
            Else
                cLeaves.w_pay = "0"
            End If
            cLeaves.is_deleted = "1"

            Dim cdb As New LeaveTypesDB
            If Not Session("intLeaves") = "0" Then
                cLeaves = cdb.LeavesInsertFile(cLeaves)
                ShowMessage("Leave Type Sucessfully Added", MessageType.Success, Me)
            Else
                cLeaves.id = Session("Leavesid")
                cLeaves = cdb.LeavesUpdateFile(cLeaves)
                ShowMessage("Leave Type Sucessfully Editted", MessageType.Success, Me)
                Session("Leavesid") = ""
            End If

            txtDesc.Text = ""
            txtNoDays.Text = ""
            fillLeaves()

        Else
            ShowMessage("Description and No of Days must not be blank", MessageType.Warning, Me)

        End If

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvLeaveType.Rows.Count <> 0 Then
            If Not Session("Leavesid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cLeaves.id = Session("Leavesid")
                    cLeaves.leave_desc = txtDesc.Text
                    cLeaves.leave_no_of_days = txtNoDays.Text
                    If cbConvertable.Checked = True Then
                        cLeaves.leave_convertable = "1"
                    Else
                        cLeaves.leave_convertable = "0"
                    End If
                    If cbWithPay.Checked = True Then
                        cLeaves.w_pay = "1"
                    Else
                        cLeaves.w_pay = "0"
                    End If
                    cLeaves.is_deleted = "0"


                    Dim cdb As New LeaveTypesDB
                    cLeaves = cdb.LeavesUpdateFile(cLeaves)
                    fillLeaves()
                    txtDesc.Text = ""
                    txtNoDays.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvLeaveType.Rows.Count <> 0 Then
            If Not Session("Leavesid") = "" Then
                Session("intLeaves") = "0"
                txtDesc.Enabled = True
                txtNoDays.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class