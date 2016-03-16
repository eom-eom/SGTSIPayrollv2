Imports System.Drawing
Public Class PhilhealthTable
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cPH As New PhilhealthTables

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Enabled = False
        txtFromRange.Enabled = False
        txtRangeTo.Enabled = False
        txtEmpShare.Enabled = False
        txtEmployerShare.Enabled = False

        fillPH()
    End Sub

    Protected Sub gvPhilhealth_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvPhilhealth, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvPhilhealth_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvPhilhealth.Rows
            If row.RowIndex = gvPhilhealth.SelectedIndex Then
                Session("PHid") = gvPhilhealth.SelectedRow.Cells(0).Text
                txtCode.Text = gvPhilhealth.SelectedRow.Cells(1).Text
                txtFromRange.Text = gvPhilhealth.SelectedRow.Cells(2).Text
                txtRangeTo.Text = gvPhilhealth.SelectedRow.Cells(3).Text
                txtEmpShare.Text = gvPhilhealth.SelectedRow.Cells(4).Text
                txtEmployerShare.Text = gvPhilhealth.SelectedRow.Cells(5).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvPhilhealth_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvPhilhealth.PageIndex = e.NewPageIndex
        gvPhilhealth.DataBind()
        txtCode.Text = ""
        txtFromRange.Text = ""
        txtRangeTo.Text = ""
        txtEmpShare.Text = ""
        txtEmployerShare.Text = ""
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtCode.Enabled = True
        txtFromRange.Enabled = True
        txtRangeTo.Enabled = True
        txtEmpShare.Enabled = True
        txtEmployerShare.Enabled = True
        Session("intPH") = "1"
    End Sub
    Private Sub fillPH()
        Dim cdb As New PhilhealthTablesDB
        dsGrid = cdb.PHTableGetList()
        gvPhilhealth.DataSource = dsGrid
        gvPhilhealth.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtCode.Text = "" And Not txtFromRange.Text = "" And Not txtRangeTo.Text = "" And Not txtEmpShare.Text = "" And Not txtEmployerShare.Text = "" Then
            cPH.ph_code = txtCode.Text
            cPH.ph_from_comp = txtFromRange.Text
            cPH.ph_to_comp = txtRangeTo.Text
            cPH.ph_ee = txtEmpShare.Text
            cPH.ph_er = txtEmployerShare.Text
            cPH.is_deleted = "1"

            Dim cdb As New PhilhealthTablesDB
            If Not Session("intPH") = "0" Then
                cPH = cdb.PHTableInsertFile(cPH)
                ShowMessage("Philhealth Sucessfully Added", MessageType.Success, Me)
            Else
                cPH.id = Session("PHid")
                cPH = cdb.PHTableUpdateFile(cPH)
                ShowMessage("Philhealth Sucessfully Editted", MessageType.Success, Me)
                Session("PHid") = ""
            End If

            txtCode.Text = ""
            txtFromRange.Text = ""
            txtRangeTo.Text = ""
            txtEmpShare.Text = ""
            txtEmployerShare.Text = ""
            fillPH()

        Else
            ShowMessage("Please fill up all the Fields", MessageType.Warning, Me)

        End If

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvPhilhealth.Rows.Count <> 0 Then
            If Not Session("PHid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cPH.id = Session("PHid")
                    cPH.ph_code = txtCode.Text
                    cPH.ph_from_comp = txtFromRange.Text
                    cPH.ph_to_comp = txtRangeTo.Text
                    cPH.ph_ee = txtEmpShare.Text
                    cPH.ph_er = txtEmployerShare.Text
                    cPH.is_deleted = "0"

                    Dim cdb As New PhilhealthTablesDB
                    cPH = cdb.PHTableUpdateFile(cPH)
                    txtCode.Text = ""
                    txtFromRange.Text = ""
                    txtRangeTo.Text = ""
                    txtEmpShare.Text = ""
                    txtEmployerShare.Text = ""
                    fillPH()
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvPhilhealth.Rows.Count <> 0 Then
            If Not Session("PHid") = "" Then
                Session("intPH") = "0"
                txtCode.Enabled = True
                txtFromRange.Enabled = True
                txtRangeTo.Enabled = True
                txtEmpShare.Enabled = True
                txtEmployerShare.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class