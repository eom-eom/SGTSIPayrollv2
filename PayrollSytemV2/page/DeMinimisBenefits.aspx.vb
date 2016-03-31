Imports System.Drawing

Public Class DeMinimisBenefits
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cDMB As New DeMinimisBenefit
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Enabled = False
        txtDescription.Enabled = False
        txtAmount.Enabled = False

        fillDMB()
    End Sub

    Protected Sub gvDeminimis_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDeminimis, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvDeminimis_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvDeminimis.PageIndex = e.NewPageIndex
        gvDeminimis.DataBind()
        txtCode.Text = ""
        txtDescription.Text = ""
        txtAmount.Text = ""
    End Sub

    Protected Sub gvDeminimis_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvDeminimis.Rows
            If row.RowIndex = gvDeminimis.SelectedIndex Then
                Session("DMBid") = gvDeminimis.SelectedRow.Cells(0).Text
                txtCode.Text = gvDeminimis.SelectedRow.Cells(1).Text
                txtDescription.Text = gvDeminimis.SelectedRow.Cells(2).Text
                txtAmount.Text = gvDeminimis.SelectedRow.Cells(3).Text
                ddlType.SelectedValue = gvDeminimis.SelectedRow.Cells(4).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtCode.Enabled = True
        txtDescription.Enabled = True
        txtAmount.Enabled = True
        Session("intDMB") = "1"
    End Sub
    Private Sub fillDMB()
        Dim cdb As New DeMinimisBenefitDB
        dsGrid = cdb.DMBGetList()
        gvDeminimis.DataSource = dsGrid
        gvDeminimis.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtCode.Text = "" And Not txtDescription.Text = "" And Not txtAmount.Text = "" Then
            cDMB.dmb_code = txtCode.Text
            cDMB.dmb_desc = txtDescription.Text
            cDMB.dmb_amount = txtAmount.Text
            cDMB.dmb_type = ddlType.SelectedValue
            cDMB.is_deleted = "1"

            Dim cdb As New DeMinimisBenefitDB
            If Not Session("intDMB") = "0" Then
                cDMB = cdb.DMBInsertFile(cDMB)
                ShowMessage("De Minimis Benefits Sucessfully Added", MessageType.Success, Me)
            Else
                cDMB.id = Session("DMBid")
                cDMB = cdb.DMBUpdateFile(cDMB)
                ShowMessage("Me Minimis Sucessfully Editted", MessageType.Success, Me)
                Session("DMBid") = ""
            End If

            txtCode.Text = ""
            txtDescription.Text = ""
            txtAmount.Text = ""
            fillDMB()

        Else
            ShowMessage("Code, Description and Amount must not be blank", MessageType.Warning, Me)

        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvDeminimis.Rows.Count <> 0 Then
            If Not Session("DMBid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cDMB.id = Session("DMBid")
                    cDMB.dmb_code = txtCode.Text
                    cDMB.dmb_desc = txtDescription.Text
                    cDMB.dmb_amount = txtAmount.Text
                    cDMB.dmb_type = ddlType.SelectedValue
                    cDMB.is_deleted = "0"


                    Dim cdb As New DeMinimisBenefitDB
                    cDMB = cdb.DMBUpdateFile(cDMB)
                    fillDMB()
                    txtCode.Text = ""
                    txtDescription.Text = ""
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
        If gvDeminimis.Rows.Count <> 0 Then
            If Not Session("DMBid") = "" Then
                Session("intDMB") = "0"
                txtCode.Enabled = True
                txtDescription.Enabled = True
                txtAmount.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class