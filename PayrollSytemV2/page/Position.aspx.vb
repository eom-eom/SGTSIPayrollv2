Imports System.Drawing

Public Class Position
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cJobTitle As New JobTitle
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPosName.Enabled = False
        txtPosDesc.Enabled = False

        fillJT()
    End Sub

    Protected Sub gvJobTitles_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvJobTitles.Rows
            If row.RowIndex = gvJobTitles.SelectedIndex Then
                Session("JTid") = gvJobTitles.SelectedRow.Cells(0).Text
                txtPosName.Text = gvJobTitles.SelectedRow.Cells(1).Text
                txtPosDesc.Text = gvJobTitles.SelectedRow.Cells(2).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvJobTitles_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvJobTitles, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvJobTitles_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvJobTitles.PageIndex = e.NewPageIndex
        gvJobTitles.DataBind()
        txtPosDesc.Text = ""
        txtPosName.Text = ""
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtPosName.Enabled = True
        txtPosDesc.Enabled = True
        Session("intJT") = "1"
    End Sub
    Private Sub fillJT()
        Dim cdb As New JobTitleDB
        dsGrid = cdb.JobTitleGetList()
        gvJobTitles.DataSource = dsGrid
        gvJobTitles.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtPosName.Text = "" And Not txtPosDesc.Text = "" Then
            cJobTitle.name = txtPosName.Text
            cJobTitle.description = txtPosDesc.Text
            cJobTitle.is_deleted = "1"

            Dim cdb As New JobTitleDB
            If Not Session("intJT") = "0" Then
                cJobTitle = cdb.JobTitleInsertFile(cJobTitle)
                ShowMessage("Job Title Sucessfully Added", MessageType.Success, Me)
            Else
                cJobTitle.id = Session("JTid")
                cJobTitle = cdb.JobTitleUpdateFile(cJobTitle)
                ShowMessage("Job Title Sucessfully Editted", MessageType.Success, Me)
            End If

            txtPosDesc.Text = ""
            txtPosName.Text = ""
            fillJT()

        Else
            ShowMessage("Name and Description must not be blank", MessageType.Warning, Me)

        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvJobTitles.Rows.Count <> 0 Then
            If Not Session("JTid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cJobTitle.id = Session("Deptid")
                    cJobTitle.name = txtPosName.Text
                    cJobTitle.description = txtPosDesc.Text
                    cJobTitle.is_deleted = "0"

                    Dim cdb As New JobTitleDB
                    cJobTitle = cdb.JobTitleUpdateFile(cJobTitle)
                    fillJT()
                    txtPosDesc.Text = ""
                    txtPosName.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvJobTitles.Rows.Count <> 0 Then
            If Not Session("JTid") = "" Then
                Session("intJT") = "0"
                txtPosDesc.Enabled = True
                txtPosName.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
End Class