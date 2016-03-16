Imports System.Drawing

Public Class OvertimeSettings
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cOT As New Overtime
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtOName.Enabled = False
        txtORate.Enabled = False

        fillOT()
    End Sub

    Protected Sub gvOT_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvOT, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvOT_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvOT.Rows
            If row.RowIndex = gvOT.SelectedIndex Then
                Session("OTid") = gvOT.SelectedRow.Cells(0).Text
                txtOName.Text = gvOT.SelectedRow.Cells(1).Text
                txtORate.Text = gvOT.SelectedRow.Cells(2).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvOT_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvOT.PageIndex = e.NewPageIndex
        gvOT.DataBind()
        txtOName.Text = ""
        txtORate.Text = ""
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtOName.Enabled = True
        txtORate.Enabled = True
        Session("intOT") = "1"
    End Sub
    Private Sub fillOT()
        Dim cdb As New OvertimeDB
        dsGrid = cdb.OTGetList()
        gvOT.DataSource = dsGrid
        gvOT.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtOName.Text = "" And Not txtORate.Text = "" Then
            cOT.overtime_name = txtOName.Text
            cOT.overtime_rate = txtORate.Text
            cOT.is_deleted = "1"

            Dim cdb As New OvertimeDB
            If Not Session("intOT") = "0" Then
                cOT = cdb.OTInsertFile(cOT)
                ShowMessage("Overtime Sucessfully Added", MessageType.Success, Me)
            Else
                cOT.id = Session("OTid")
                cOT = cdb.OTUpdateFile(cOT)
                ShowMessage("Overtime Sucessfully Editted", MessageType.Success, Me)
                Session("OTid") = ""
            End If

            txtOName.Text = ""
            txtORate.Text = ""
            fillOT()

        Else
            ShowMessage("Name and Rate must not be blank", MessageType.Warning, Me)

        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvOT.Rows.Count <> 0 Then
            If Not Session("OTid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cOT.id = Session("OTid")
                    cOT.overtime_name = txtOName.Text
                    cOT.overtime_rate = txtORate.Text
                    cOT.is_deleted = "0"

                    Dim cdb As New OvertimeDB
                    cOT = cdb.OTUpdateFile(cOT)
                    fillOT()
                    txtOName.Text = ""
                    txtORate.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvOT.Rows.Count <> 0 Then
            If Not Session("OTid") = "" Then
                Session("intOT") = "0"
                txtOName.Enabled = True
                txtORate.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class