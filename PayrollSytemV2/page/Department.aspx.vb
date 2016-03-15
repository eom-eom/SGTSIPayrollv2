Imports System.Drawing

Public Class Department
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cDepartment As New Departments

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtDeptDesc.Enabled = False
        txtDeptName.Enabled = False
       
        fillDept()
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtDeptDesc.Enabled = True
        txtDeptName.Enabled = True
        Session("intSE") = "1"
        

    End Sub
    Private Sub fillDept()
        Dim cdb As New DepartmentDB
        dsGrid = cdb.DeptGetList()
        gvDepartment.DataSource = dsGrid
        gvDepartment.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtDeptDesc.Text = "" And Not txtDeptName.Text = "" Then
            cDepartment.name = txtDeptName.Text
            cDepartment.description = txtDeptDesc.Text
            cDepartment.is_deleted = "1"

            Dim cdb As New DepartmentDB
            If Not Session("intSE") = "0" Then
                cDepartment = cdb.DeptInsertFile(cDepartment)
                ShowMessage("Department Sucessfully Added", MessageType.Success, Me)
            Else
                cDepartment.id = Session("Deptid")
                cDepartment = cdb.DeptUpdateFile(cDepartment)
                ShowMessage("Department Sucessfully Editted", MessageType.Success, Me)
            End If

            txtDeptDesc.Text = ""
            txtDeptName.Text = ""
            fillDept()

        Else
            ShowMessage("Name and Description must not be blank", MessageType.Warning, Me)

        End If

    End Sub

    Protected Sub gvDepartment_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDepartment, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvDepartment_SelectedIndexChanged(sender As Object, e As EventArgs)

        For Each row As GridViewRow In gvDepartment.Rows
            If row.RowIndex = gvDepartment.SelectedIndex Then
                Session("Deptid") = gvDepartment.SelectedRow.Cells(0).Text
                txtDeptName.Text = gvDepartment.SelectedRow.Cells(1).Text
                txtDeptDesc.Text = gvDepartment.SelectedRow.Cells(2).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvDepartment.Rows.Count <> 0 Then
            If Not Session("Deptid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cDepartment.id = Session("Deptid")
                    cDepartment.name = txtDeptName.Text
                    cDepartment.description = txtDeptDesc.Text
                    cDepartment.is_deleted = "0"

                    Dim cdb As New DepartmentDB
                    cDepartment = cdb.DeptUpdateFile(cDepartment)
                    fillDept()
                    txtDeptDesc.Text = ""
                    txtDeptName.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvDepartment.Rows.Count <> 0 Then
            If Not Session("Deptid") = "" Then
                Session("intSE") = "0"
                txtDeptDesc.Enabled = True
                txtDeptName.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub gvDepartment_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvDepartment.PageIndex = e.NewPageIndex
        gvDepartment.DataBind()
        txtDeptDesc.Text = ""
        txtDeptName.Text = ""
    End Sub
End Class