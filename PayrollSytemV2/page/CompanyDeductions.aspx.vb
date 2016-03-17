Imports System.Drawing
Public Class CompanyDeductions
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cCD As New CompanyDeduction
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Enabled = False
        txtDesc.Enabled = False

        fillCD()
    End Sub

    Protected Sub gvCompanyDeduction_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvCompanyDeduction, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvCompanyDeduction_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvCompanyDeduction.Rows
            If row.RowIndex = gvCompanyDeduction.SelectedIndex Then
                Session("CDid") = gvCompanyDeduction.SelectedRow.Cells(0).Text
                txtCode.Text = gvCompanyDeduction.SelectedRow.Cells(1).Text
                txtDesc.Text = gvCompanyDeduction.SelectedRow.Cells(2).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub


    Protected Sub gvCompanyDeduction_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvCompanyDeduction.PageIndex = e.NewPageIndex
        gvCompanyDeduction.DataBind()
        txtCode.Text = ""
        txtDesc.Text = ""
    End Sub


    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtCode.Enabled = True
        txtDesc.Enabled = True
        Session("intCD") = "1"
    End Sub
    Private Sub fillCD()
        Dim cdb As New CompanyDeductionDB
        dsGrid = cdb.CDGetList()
        gvCompanyDeduction.DataSource = dsGrid
        gvCompanyDeduction.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtCode.Text = "" And Not txtDesc.Text = "" Then
            cCD.comde_code = txtCode.Text
            cCD.comde_desc = txtDesc.Text
            cCD.is_deleted = "1"

            Dim cdb As New CompanyDeductionDB
            If Not Session("intCD") = "0" Then
                cCD = cdb.CDInsertFile(cCD)
                ShowMessage("Company Deduction Sucessfully Added", MessageType.Success, Me)
            Else
                cCD.id = Session("CDid")
                cCD = cdb.CDUpdateFile(cCD)
                ShowMessage("Company Deduction Sucessfully Editted", MessageType.Success, Me)
                Session("CDid") = ""
            End If

            txtCode.Text = ""
            txtDesc.Text = ""
            fillCD()

        Else
            ShowMessage("Code and Description must not be blank", MessageType.Warning, Me)

        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvCompanyDeduction.Rows.Count <> 0 Then
            If Not Session("CDid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cCD.id = Session("CDid")
                    cCD.comde_code = txtCode.Text
                    cCD.comde_desc = txtDesc.Text
                    cCD.is_deleted = "0"

                    Dim cdb As New CompanyDeductionDB
                    cCD = cdb.CDUpdateFile(cCD)
                    fillCD()
                    txtCode.Text = ""
                    txtDesc.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvCompanyDeduction.Rows.Count <> 0 Then
            If Not Session("CDid") = "" Then
                Session("intCD") = "0"
                txtCode.Enabled = True
                txtDesc.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class