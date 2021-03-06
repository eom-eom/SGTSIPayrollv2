﻿Imports System.Drawing
Public Class Employee
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cEmployee As New EmployeeInfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillEmployee()
        'If IsPostBack Then
        '    If Not Session("intEmp") = "1" Then
        '        ShowMessage("Employee Sucessfully Added.", MessageType.Success, Me)
        '    ElseIf Session("intEmp") = "2" Then
        '        ShowMessage("Employee was edited successfully.", MessageType.Info, Me)
        '    End If
        'End If
        

    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Response.Redirect("frmEmployee.aspx")
    End Sub
    Private Sub fillEmployee()
        Dim cdb As New EmploymentInfoDB
        dsGrid = cdb.EmployeeGetList()
        gvEmployee.DataSource = dsGrid
        gvEmployee.DataBind()
    End Sub
    Protected Sub gvEmployee_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvEmployee, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub
    Protected Sub gvEmployee_SelectedIndexChanged(sender As Object, e As EventArgs)

        For Each row As GridViewRow In gvEmployee.Rows
            If row.RowIndex = gvEmployee.SelectedIndex Then

                Session("Empid") = CStr(gvEmployee.DataKeys(gvEmployee.SelectedIndex).Values("id"))

                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty
                'Exit For
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    Protected Sub gvEmployee_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvEmployee.PageIndex = e.NewPageIndex
        gvEmployee.DataBind()
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvEmployee.Rows.Count <> 0 Then
            If Not Session("Empid") = "" Then
                Session("intEmp") = "0"
                Response.Redirect("frmEmployee.aspx")
                'how to get data from database? another getfile?
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If
    End Sub
    Public Sub clearMe(Optional ByVal ctlcol As ControlCollection = Nothing)
        If ctlcol Is Nothing Then ctlcol = Me.Controls
        For Each ctl As Control In ctlcol
            If TypeOf (ctl) Is TextBox Then
                DirectCast(ctl, TextBox).Text = Nothing

            ElseIf TypeOf (ctl) Is DropDownList Then
                DirectCast(ctl, DropDownList).Text = Nothing
            Else
                If Not ctl.Controls Is Nothing OrElse ctl.Controls.Count <> 0 Then
                    clearMe(ctl.Controls)
                End If
            End If

        Next

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvEmployee.Rows.Count <> 0 Then
            If Not Session("Empid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cEmployee.id = Session("Empid")
                    
                    cEmployee.is_deleted = "0"

                    Dim cdb As New EmploymentInfoDB
                    cEmployee = cdb.CEmpUpdatetoDeleteFile(cEmployee)
                    fillEmployee()
                    ShowMessage("Record deleted.", MessageType.Errors, Me)
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub
End Class