Imports System.Drawing

Public Class LateAndUndertimeTable
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cLU As New LateUndertime


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFrom.Enabled = False
        txtTo.Enabled = False
        txtPercentage.Enabled = False


        fillLU()

        FillShift()
    End Sub

    Protected Sub gvLateUndertime_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvLateUndertime, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvLateUndertime_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvLateUndertime.Rows
            If row.RowIndex = gvLateUndertime.SelectedIndex Then
                Session("LUid") = gvLateUndertime.SelectedRow.Cells(0).Text
                If gvLateUndertime.SelectedRow.Cells(1).Text = "L" Then
                    rbLate.Checked = True
                    rbUndertime.Checked = False
                ElseIf gvLateUndertime.SelectedRow.Cells(1).Text = "U" Then
                    rbUndertime.Checked = True
                    rbLate.Checked = False
                End If
                txtFrom.Text = gvLateUndertime.SelectedRow.Cells(2).Text
                txtTo.Text = gvLateUndertime.SelectedRow.Cells(3).Text
                ' ddlShift.Text = gvLateUndertime.SelectedRow.Cells(4).Text
                txtPercentage.Text = gvLateUndertime.SelectedRow.Cells(5).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvLateUndertime_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvLateUndertime.PageIndex = e.NewPageIndex
        gvLateUndertime.DataBind()
        txtFrom.Text = ""
        txtTo.Text = ""
        txtPercentage.Text = ""
    End Sub

    Public Sub FillShift()
        Dim cdb As New ShiftsDB
        Dim dt As DataTable = cdb.ShiftsListDDL

        ddlShift.DataValueField = "id"
        ddlShift.DataTextField = "shift"

        ddlShift.DataSource = dt
        ddlShift.DataBind()
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtFrom.Enabled = True
        txtTo.Enabled = True
        txtPercentage.Enabled = True
        Session("intLU") = "1"
    End Sub
    Private Sub fillLU()
        Dim cdb As New LateUndertimeDB
        dsGrid = cdb.LateUndertimeGetList()
        gvLateUndertime.DataSource = dsGrid
        gvLateUndertime.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtFrom.Text = "" And Not txtTo.Text = "" And Not txtPercentage.Text = "" Then
            cLU.lu_from = txtFrom.Text
            cLU.lu_to = txtTo.Text
            cLU.shift_id = ddlShift.SelectedValue
            cLU.lu_percentage = txtPercentage.Text
            If rbLate.Checked = True Then
                cLU.lu_type = "L"
            ElseIf rbUndertime.Checked = True Then
                cLU.lu_type = "U"
            End If
            cLU.is_deleted = "1"

            Dim cdb As New LateUndertimeDB
            If Not Session("intLU") = "0" Then
                cLU = cdb.LateUndertimeInsertFile(cLU)
                ShowMessage("Late / Undertime Sucessfully Added", MessageType.Success, Me)
            Else
                cLU.id = Session("LUid")
                cLU = cdb.LateUndertimeUpdateFile(cLU)
                ShowMessage("Late / Undertime Sucessfully Editted", MessageType.Success, Me)
                Session("LUid") = ""
            End If

            txtFrom.Text = ""
            txtTo.Text = ""
            txtPercentage.Text = ""
            fillLU()

        Else
            ShowMessage("Name and Description must not be blank", MessageType.Warning, Me)

        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvLateUndertime.Rows.Count <> 0 Then
            If Not Session("LUid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cLU.id = Session("LUid")
                    cLU.lu_from = txtFrom.Text
                    cLU.lu_to = txtTo.Text
                    cLU.shift_id = ddlShift.SelectedValue
                    cLU.lu_percentage = txtPercentage.Text
                    cLU.is_deleted = "0"

                    Dim cdb As New LateUndertimeDB
                    cLU = cdb.LateUndertimeUpdateFile(cLU)
                    fillLU()
                    txtFrom.Text = ""
                    txtTo.Text = ""
                    txtPercentage.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvLateUndertime.Rows.Count <> 0 Then
            If Not Session("LUid") = "" Then
                Session("intLU") = "0"
                txtFrom.Enabled = True
                txtTo.Enabled = True
                txtPercentage.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class