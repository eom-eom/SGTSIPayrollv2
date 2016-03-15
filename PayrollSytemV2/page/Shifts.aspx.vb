Imports System.Drawing

Public Class Shifts
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cShifts As New ShiftsClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtShiftName.Enabled = False
        txtTimeIn.Enabled = False
        txtTimeOut.Enabled = False

        fillShifts()
    End Sub

    Protected Sub gvShifts_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvShifts, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvShifts_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvShifts.Rows
            If row.RowIndex = gvShifts.SelectedIndex Then
                Session("Shiftid") = gvShifts.SelectedRow.Cells(0).Text
                txtShiftName.Text = gvShifts.SelectedRow.Cells(1).Text
                txtTimeIn.Text = gvShifts.SelectedRow.Cells(2).Text
                txtTimeOut.Text = gvShifts.SelectedRow.Cells(3).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvShifts_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvShifts.PageIndex = e.NewPageIndex
        gvShifts.DataBind()
        txtShiftName.Text = ""
        txtTimeIn.Text = ""
        txtTimeOut.Text = ""
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtShiftName.Enabled = True
        txtTimeIn.Enabled = True
        txtTimeOut.Enabled = True
        Session("intShifts") = "1"
    End Sub
    Private Sub fillShifts()
        Dim cdb As New ShiftsDB
        dsGrid = cdb.ShiftsList()
        gvShifts.DataSource = dsGrid
        gvShifts.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtShiftName.Text = "" And Not txtTimeIn.Text = "" And Not txtTimeOut.Text = "" Then
            cShifts.shift_name = txtShiftName.Text
            cShifts.time_in = txtTimeIn.Text
            cShifts.time_out = txtTimeOut.Text
            'cShifts.time_in = Format(DateTime.Parse(txtTimeIn.Text), "hh:mm tt")
            'cShifts.time_out = Format(DateTime.Parse(txtTimeOut.Text), "hh:mm tt")
            cShifts.is_deleted = "1"

            Dim cdb As New ShiftsDB
            If Not Session("intShifts") = "0" Then
                cShifts = cdb.DeptInsertFile(cShifts)
                ShowMessage("Shifts Sucessfully Added", MessageType.Success, Me)
            Else
                cShifts.id = Session("Shiftid")
                cShifts = cdb.ShiftsUpdateFile(cShifts)
                ShowMessage("Shifts Sucessfully Editted", MessageType.Success, Me)
            End If

            txtShiftName.Text = ""
            txtTimeIn.Text = ""
            txtTimeOut.Text = ""
            fillShifts()

        Else
            ShowMessage("Name and Description must not be blank", MessageType.Warning, Me)

        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvShifts.Rows.Count <> 0 Then
            If Not Session("Shiftid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cShifts.id = Session("Shiftid")
                    cShifts.shift_name = txtShiftName.Text
                    cShifts.time_in = txtTimeIn.Text
                    cShifts.time_out = txtTimeOut.Text
                    cShifts.is_deleted = "0"

                    Dim cdb As New ShiftsDB
                    cShifts = cdb.ShiftsUpdateFile(cShifts)
                    fillShifts()
                    txtShiftName.Text = ""
                    txtTimeIn.Text = ""
                    txtTimeOut.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvShifts.Rows.Count <> 0 Then
            If Not Session("Shiftid") = "" Then
                Session("intShifts") = "0"
                txtShiftName.Enabled = True
                txtTimeIn.Enabled = True
                txtTimeOut.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class