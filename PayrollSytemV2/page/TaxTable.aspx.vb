Imports System.Drawing
Public Class TaxTable
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cTaxTable As New TaxTables

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Enabled = False
        txtCeiling.Enabled = False
        txtAddTax.Enabled = False
        txtTaxRatePercent.Enabled = False
        txtAmountComp.Enabled = False

        fillTaxTable()
    End Sub

    Protected Sub gvTaxTable_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvTaxTable, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvTaxTable_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvTaxTable.Rows
            If row.RowIndex = gvTaxTable.SelectedIndex Then
                Session("Taxid") = gvTaxTable.SelectedRow.Cells(0).Text
                txtCode.Text = gvTaxTable.SelectedRow.Cells(1).Text
                ddlStatus.SelectedValue = gvTaxTable.SelectedRow.Cells(2).Text
                ddlOperand.SelectedValue = gvTaxTable.SelectedRow.Cells(3).Text
                txtAmountComp.Text = gvTaxTable.SelectedRow.Cells(4).Text
                txtCeiling.Text = gvTaxTable.SelectedRow.Cells(5).Text
                txtAddTax.Text = gvTaxTable.SelectedRow.Cells(6).Text
                txtTaxRatePercent.Text = gvTaxTable.SelectedRow.Cells(7).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvTaxTable_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvTaxTable.PageIndex = e.NewPageIndex
        gvTaxTable.DataBind()
        txtCode.Text = ""
        txtCeiling.Text = ""
        txtAddTax.Text = ""
        txtTaxRatePercent.Text = ""
        txtAmountComp.Text = ""
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtCode.Enabled = True
        txtCeiling.Enabled = True
        txtAddTax.Enabled = True
        txtTaxRatePercent.Enabled = True
        txtAmountComp.Enabled = True
        Session("intTax") = "1"
    End Sub
    Private Sub fillTaxTable()
        Dim cdb As New TaxTablesDB
        dsGrid = cdb.TaxTableGetList()
        gvTaxTable.DataSource = dsGrid
        gvTaxTable.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtCode.Text = "" And Not txtCeiling.Text = "" And Not txtAddTax.Text = "" And Not txtTaxRatePercent.Text = "" And Not txtAmountComp.Text = "" Then
            cTaxTable.tax_code = txtCode.Text
            cTaxTable.tax_status = ddlStatus.Text
            cTaxTable.tax_operand = ddlOperand.Text
            cTaxTable.tax_amount_comp = txtAmountComp.Text
            cTaxTable.tax_ceiling = txtCeiling.Text
            cTaxTable.tax_additional = txtAddTax.Text
            cTaxTable.tax_rate = txtTaxRatePercent.Text
            cTaxTable.is_deleted = "1"

            Dim cdb As New TaxTablesDB
            If Not Session("intTax") = "0" Then
                cTaxTable = cdb.TaxTableInsertFile(cTaxTable)
                ShowMessage("Tax Sucessfully Added", MessageType.Success, Me)
            Else
                cTaxTable.id = Session("Taxid")
                cTaxTable = cdb.TaxTableUpdateFile(cTaxTable)
                ShowMessage("Tax Sucessfully Editted", MessageType.Success, Me)
                Session("Taxid") = ""
            End If

            txtCode.Text = ""
            txtCeiling.Text = ""
            txtAddTax.Text = ""
            txtTaxRatePercent.Text = ""
            txtAmountComp.Text = ""
            fillTaxTable()

        Else
            ShowMessage("Please fill up all the Fields", MessageType.Warning, Me)

        End If

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvTaxTable.Rows.Count <> 0 Then
            If Not Session("Taxid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cTaxTable.id = Session("Taxid")
                    cTaxTable.tax_code = txtCode.Text
                    cTaxTable.tax_status = ddlStatus.Text
                    cTaxTable.tax_operand = ddlOperand.Text
                    cTaxTable.tax_amount_comp = txtAmountComp.Text
                    cTaxTable.tax_ceiling = txtCeiling.Text
                    cTaxTable.tax_additional = txtAddTax.Text
                    cTaxTable.tax_rate = txtTaxRatePercent.Text
                    cTaxTable.is_deleted = "0"

                    Dim cdb As New TaxTablesDB
                    cTaxTable = cdb.TaxTableUpdateFile(cTaxTable)
                    fillTaxTable()
                    txtCode.Text = ""
                    txtCeiling.Text = ""
                    txtAddTax.Text = ""
                    txtTaxRatePercent.Text = ""
                    txtAmountComp.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvTaxTable.Rows.Count <> 0 Then
            If Not Session("Taxid") = "" Then
                Session("intTax") = "0"
                txtCode.Enabled = True
                txtCeiling.Enabled = True
                txtAddTax.Enabled = True
                txtTaxRatePercent.Enabled = True
                txtAmountComp.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class