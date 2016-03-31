Imports System.Drawing
Public Class ReceivablesAndTaxableAllowance
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cRTA As New ReceivablesAndTaxable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Enabled = False
        txtDesc.Enabled = False
        txtAmount.Enabled = False
      
        fillRTA()
    End Sub

    Protected Sub gvRTA_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvRTA, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvRTA_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvRTA.Rows
            If row.RowIndex = gvRTA.SelectedIndex Then
                Session("RTAid") = gvRTA.SelectedRow.Cells(0).Text
                txtCode.Text = gvRTA.SelectedRow.Cells(1).Text
                txtDesc.Text = gvRTA.SelectedRow.Cells(2).Text
                txtAmount.Text = gvRTA.SelectedRow.Cells(3).Text
                ddlType.SelectedValue = gvRTA.SelectedRow.Cells(4).Text
                If gvRTA.SelectedRow.Cells(5).Text = 1 Then
                    cbTaxable.Checked = True
                ElseIf gvRTA.SelectedRow.Cells(5).Text = 0 Then
                    cbTaxable.Checked = False
                End If
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvRTA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvRTA.PageIndex = e.NewPageIndex
        gvRTA.DataBind()
        txtCode.Text = ""
        txtDesc.Text = ""
        txtAmount.Text = ""
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtCode.Enabled = True
        txtDesc.Enabled = True
        txtAmount.Enabled = True
        Session("intRTA") = "1"

    End Sub
    Private Sub fillRTA()
        Dim cdb As New ReceivablesAndTaxableDB
        dsGrid = cdb.RTAGetList()
        gvRTA.DataSource = dsGrid
        gvRTA.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtCode.Text = "" And Not txtDesc.Text = "" And Not txtAmount.Text = "" Then
            cRTA.rta_code = txtCode.Text
            cRTA.rta_desc = txtDesc.Text
            cRTA.rta_amount = txtAmount.Text
            cRTA.rta_type = ddlType.SelectedValue
            If cbTaxable.Checked = True Then
                cRTA.rta_taxable = "1"
            ElseIf cbTaxable.Checked = False Then
                cRTA.rta_taxable = "0"
            End If
            cRTA.is_deleted = "1"

            Dim cdb As New ReceivablesAndTaxableDB
            If Not Session("intRTA") = "0" Then
                cRTA = cdb.RTAInsertFile(cRTA)
                ShowMessage("Receivables and Taxable Sucessfully Added", MessageType.Success, Me)
            Else
                cRTA.id = Session("RTAid")
                cRTA = cdb.RTAUpdateFile(cRTA)
                ShowMessage("Receivables and Taxable Sucessfully Editted", MessageType.Success, Me)
                Session("RTAid") = ""
            End If

            txtCode.Text = ""
            txtDesc.Text = ""
            txtAmount.Text = ""
            fillRTA()

        Else
            ShowMessage("Code, Description and Amount must not be blank", MessageType.Warning, Me)

        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvRTA.Rows.Count <> 0 Then
            If Not Session("RTAid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cRTA.id = Session("RTAid")
                    cRTA.rta_code = txtCode.Text
                    cRTA.rta_desc = txtDesc.Text
                    cRTA.rta_amount = txtAmount.Text
                    cRTA.rta_type = ddlType.SelectedValue
                    If cbTaxable.Checked = True Then
                        cRTA.rta_taxable = "1"
                    ElseIf cbTaxable.Checked = False Then
                        cRTA.rta_taxable = "0"
                    End If
                    cRTA.is_deleted = "0"

                    Dim cdb As New ReceivablesAndTaxableDB
                    cRTA = cdb.RTAUpdateFile(cRTA)
                    fillRTA()
                    txtCode.Text = ""
                    txtDesc.Text = ""
                    txtAmount.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvRTA.Rows.Count <> 0 Then
            If Not Session("RTAid") = "" Then
                Session("intRTA") = "0"
                txtCode.Enabled = True
                txtDesc.Enabled = True
                txtAmount.Enabled = True

            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class