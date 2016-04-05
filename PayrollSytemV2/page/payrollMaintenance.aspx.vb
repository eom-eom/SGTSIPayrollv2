Imports System.Drawing

Public Class payrollMaintenance
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cPM As New PayrollMain
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillPayroll()
    End Sub
    Private Sub fillPayroll()
        Dim cdb As New PayrollDB
        dsGrid = cdb.PayrollGetList()
        gvPayrollMain.DataSource = dsGrid
        gvPayrollMain.DataBind()
    End Sub
    Protected Sub gvPayrollMain_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvPayrollMain.PageIndex = e.NewPageIndex
        gvPayrollMain.DataBind()
    End Sub

    Protected Sub gvPayrollMain_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvPayrollMain, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvPayrollMain_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvPayrollMain.Rows
            If row.RowIndex = gvPayrollMain.SelectedIndex Then
                Session("PayrollCode") = gvPayrollMain.SelectedRow.Cells(0).Text()

                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvPayrollMain.Rows.Count <> 0 Then
            If Not Session("PayrollCode") = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "myModal", "$('#myModal').modal()", True)
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnOK_Click(sender As Object, e As EventArgs)
        Dim cdb As New PayrollDB
        If txtPassword.Text <> "" Then
            If cdb.GetAdminPassword(txtPassword.Text) = True Then

                cPM.payroll_code = Session("PayrollCode")
                cPM.is_deleted = "0"

                cPM = cdb.PayrollUpdateFile(cPM)
                fillPayroll()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "myModal", "Closepopup();", True)
                'UPmodal.Attributes("class") = "close"

            Else
                ShowMessage("Password didn't match", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Password must not be blank", MessageType.Errors, Me)
        End If
    End Sub
End Class