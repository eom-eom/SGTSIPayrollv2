Imports System.Drawing
Public Class SSSTable
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cSSS As New SSSTables
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Enabled = False
        txtFromRange.Enabled = False
        txtRangeTo.Enabled = False
        txtEmpShare.Enabled = False
        txtEmpComp.Enabled = False
        txtEmployerShare.Enabled = False

        fillSSS()
    End Sub

    Protected Sub gvSSS_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvSSS, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvSSS_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvSSS.Rows
            If row.RowIndex = gvSSS.SelectedIndex Then
                Session("SSSid") = gvSSS.SelectedRow.Cells(0).Text
                txtCode.Text = gvSSS.SelectedRow.Cells(1).Text
                txtFromRange.Text = gvSSS.SelectedRow.Cells(2).Text
                txtRangeTo.Text = gvSSS.SelectedRow.Cells(3).Text
                txtEmpShare.Text = gvSSS.SelectedRow.Cells(4).Text
                txtEmpComp.Text = gvSSS.SelectedRow.Cells(5).Text
                txtEmployerShare.Text = gvSSS.SelectedRow.Cells(6).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvSSS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvSSS.PageIndex = e.NewPageIndex
        gvSSS.DataBind()
        txtCode.Text = ""
        txtFromRange.Text = ""
        txtRangeTo.Text = ""
        txtEmpShare.Text = ""
        txtEmpComp.Text = ""
        txtEmployerShare.Text = ""
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtCode.Enabled = True
        txtFromRange.Enabled = True
        txtRangeTo.Enabled = True
        txtEmpShare.Enabled = True
        txtEmpComp.Enabled = True
        txtEmployerShare.Enabled = True
        Session("intSSS") = "1"
    End Sub
    Private Sub fillSSS()
        Dim cdb As New SSSTablesDB
        dsGrid = cdb.SSSTableGetList()
        gvSSS.DataSource = dsGrid
        gvSSS.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtCode.Text = "" And Not txtFromRange.Text = "" And Not txtRangeTo.Text = "" And Not txtEmpShare.Text = "" And Not txtEmpComp.Text = "" And Not txtEmployerShare.Text = "" Then
            cSSS.sss_code = txtCode.Text
            cSSS.sss_from_comp = txtFromRange.Text
            cSSS.sss_to_comp = txtRangeTo.Text
            cSSS.sss_ee = txtEmpShare.Text
            cSSS.sss_ec = txtEmpComp.Text
            cSSS.sss_er = txtEmployerShare.Text
            cSSS.is_deleted = "1"

            Dim cdb As New SSSTablesDB
            If Not Session("intSSS") = "0" Then
                cSSS = cdb.SSSTableInsertFile(cSSS)
                ShowMessage("SSS Sucessfully Added", MessageType.Success, Me)
            Else
                cSSS.id = Session("SSSid")
                cSSS = cdb.SSSTableUpdateFile(cSSS)
                ShowMessage("SSS Sucessfully Editted", MessageType.Success, Me)
                Session("SSSid") = ""
            End If

            txtCode.Text = ""
            txtFromRange.Text = ""
            txtRangeTo.Text = ""
            txtEmpShare.Text = ""
            txtEmpComp.Text = ""
            txtEmployerShare.Text = ""
            fillSSS()

        Else
            ShowMessage("Please fill up all the Fields", MessageType.Warning, Me)

        End If

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvSSS.Rows.Count <> 0 Then
            If Not Session("SSSid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cSSS.id = Session("SSSid")
                    cSSS.sss_code = txtCode.Text
                    cSSS.sss_from_comp = txtFromRange.Text
                    cSSS.sss_to_comp = txtRangeTo.Text
                    cSSS.sss_ee = txtEmpShare.Text
                    cSSS.sss_ec = txtEmpComp.Text
                    cSSS.sss_er = txtEmployerShare.Text
                    cSSS.is_deleted = "0"

                    Dim cdb As New SSSTablesDB
                    cSSS = cdb.SSSTableUpdateFile(cSSS)
                    txtCode.Text = ""
                    txtFromRange.Text = ""
                    txtRangeTo.Text = ""
                    txtEmpShare.Text = ""
                    txtEmpComp.Text = ""
                    txtEmployerShare.Text = ""
                    fillSSS()
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvSSS.Rows.Count <> 0 Then
            If Not Session("SSSid") = "" Then
                Session("intSSS") = "0"
                txtCode.Enabled = True
                txtFromRange.Enabled = True
                txtRangeTo.Enabled = True
                txtEmpShare.Enabled = True
                txtEmpComp.Enabled = True
                txtEmployerShare.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class