Imports System.Drawing
Public Class HDMFTable
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cHDMF As New HDMFTables
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Enabled = False
        txtFromRange.Enabled = False
        txtRangeTo.Enabled = False
        txtEmpShare.Enabled = False
        txtEmployerShare.Enabled = False

        fillHDMF()
    End Sub

    Protected Sub gvHDMF_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvHDMF, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvHDMF_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvHDMF.Rows
            If row.RowIndex = gvHDMF.SelectedIndex Then
                Session("HDMFid") = gvHDMF.SelectedRow.Cells(0).Text
                txtCode.Text = gvHDMF.SelectedRow.Cells(1).Text
                txtFromRange.Text = gvHDMF.SelectedRow.Cells(2).Text
                txtRangeTo.Text = gvHDMF.SelectedRow.Cells(3).Text

                If gvHDMF.SelectedRow.Cells(4).Text = "P" Then
                    rbPercentage.Checked = True
                    rbAmount.Checked = False
                ElseIf gvHDMF.SelectedRow.Cells(4).Text = "A" Then
                    rbPercentage.Checked = False
                    rbAmount.Checked = True
                End If

                txtEmpShare.Text = gvHDMF.SelectedRow.Cells(5).Text
                txtEmployerShare.Text = gvHDMF.SelectedRow.Cells(6).Text

                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvHDMF_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvHDMF.PageIndex = e.NewPageIndex
        gvHDMF.DataBind()
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
        Session("intHDMF") = "1"
    End Sub
    Private Sub fillHDMF()
        Dim cdb As New HDMFTablesDB
        dsGrid = cdb.HDMFTableGetList()
        gvHDMF.DataSource = dsGrid
        gvHDMF.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtCode.Text = "" And Not txtFromRange.Text = "" And Not txtRangeTo.Text = "" And Not txtEmpShare.Text = "" And Not txtEmployerShare.Text = "" Then
            cHDMF.hdmf_code = txtCode.Text
            cHDMF.hdmf_from_comp = txtFromRange.Text
            cHDMF.hdmf_to_comp = txtRangeTo.Text
            If rbPercentage.Checked = True Then
                cHDMF.hdmf_cont_option = "P"
            ElseIf rbAmount.Checked = True Then
                cHDMF.hdmf_cont_option = "A"
            End If
            cHDMF.hdmf_ee = txtEmpShare.Text
            cHDMF.hdmf_er = txtEmployerShare.Text
            cHDMF.is_deleted = "1"

            Dim cdb As New HDMFTablesDB
            If Not Session("intHDMF") = "0" Then
                cHDMF = cdb.HDMFTableInsertFile(cHDMF)
                ShowMessage("HDMF Sucessfully Added", MessageType.Success, Me)
            Else
                cHDMF.id = Session("HDMFid")
                cHDMF = cdb.HDMFTableUpdateFile(cHDMF)
                ShowMessage("HDMF Sucessfully Editted", MessageType.Success, Me)
                Session("HDMFid") = ""
            End If

            txtCode.Text = ""
            txtFromRange.Text = ""
            txtRangeTo.Text = ""
            txtEmpShare.Text = ""
            txtEmployerShare.Text = ""
            fillHDMF()

        Else
            ShowMessage("Please fill up all the Fields", MessageType.Warning, Me)

        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvHDMF.Rows.Count <> 0 Then
            If Not Session("HDMFid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cHDMF.id = Session("HDMFid")
                    cHDMF.hdmf_code = txtCode.Text
                    cHDMF.hdmf_from_comp = txtFromRange.Text
                    cHDMF.hdmf_to_comp = txtRangeTo.Text
                    If rbPercentage.Checked = True Then
                        cHDMF.hdmf_cont_option = "P"
                    ElseIf rbAmount.Checked = True Then
                        cHDMF.hdmf_cont_option = "A"
                    End If
                    cHDMF.hdmf_ee = txtEmpShare.Text
                    cHDMF.hdmf_er = txtEmployerShare.Text
                    cHDMF.is_deleted = "0"

                    Dim cdb As New HDMFTablesDB
                    cHDMF = cdb.HDMFTableUpdateFile(cHDMF)
                    txtCode.Text = ""
                    txtFromRange.Text = ""
                    txtRangeTo.Text = ""
                    txtEmpShare.Text = ""
                    txtEmployerShare.Text = ""
                    fillHDMF()

                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub


    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvHDMF.Rows.Count <> 0 Then
            If Not Session("HDMFid") = "" Then
                Session("intHDMF") = "0"
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