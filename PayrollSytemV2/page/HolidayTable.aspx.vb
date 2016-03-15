Imports System.Drawing

Public Class HolidayTables
    Inherits System.Web.UI.Page
    Dim dsGrid As DataTable
    Private cHolTable As New HoliTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtHolName.Enabled = False
        txtHolDate.Enabled = False
        txtDay.Enabled = False
        txtPercentge.Enabled = False
        
        fillHT()
    End Sub

    Protected Sub gvHolTable_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvHolTable, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row." & e.Row.RowIndex
        End If
    End Sub

    Protected Sub gvHolTable_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In gvHolTable.Rows
            If row.RowIndex = gvHolTable.SelectedIndex Then
                Session("HTid") = gvHolTable.SelectedRow.Cells(0).Text
                txtHolName.Text = gvHolTable.SelectedRow.Cells(1).Text
                txtHolDate.Text = gvHolTable.SelectedRow.Cells(2).Text
                txtDay.Text = gvHolTable.SelectedRow.Cells(3).Text
                ddlHolType.Text = gvHolTable.SelectedRow.Cells(4).Text
                txtPercentge.Text = gvHolTable.SelectedRow.Cells(5).Text
                row.BackColor = ColorTranslator.FromHtml("#f39c12")
                row.ToolTip = String.Empty

            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    Protected Sub gvHolTable_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvHolTable.PageIndex = e.NewPageIndex
        gvHolTable.DataBind()
        txtHolName.Text = ""
        txtDay.Text = ""
        txtPercentge.Text = ""
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtHolName.Enabled = True
        txtHolDate.Enabled = True
        txtDay.Enabled = True
        txtPercentge.Enabled = True
        ddlHolType.Enabled = True
        Session("intHT") = "1"
    End Sub
    Private Sub fillHT()
        Dim cdb As New HolidayTableDB
        dsGrid = cdb.HolTableGetList()
        gvHolTable.DataSource = dsGrid
        gvHolTable.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtHolName.Text = "" And Not txtDay.Text = "" And Not txtPercentge.Text = "" Then
            cHolTable.holiday_name = txtHolName.Text
            cHolTable.holiday_date = txtHolDate.Text
            cHolTable.holiday_day = txtDay.Text
            cHolTable.holiday_category = ddlHolType.Text
            cHolTable.holiday_percentage = txtPercentge.Text
            cHolTable.is_deleted = "1"

            Dim cdb As New HolidayTableDB
            If Not Session("intHT") = "0" Then
                cHolTable = cdb.HolTableInsertFile(cHolTable)
                ShowMessage("Holiday Table Sucessfully Added", MessageType.Success, Me)
            Else
                cHolTable.id = Session("HTid")
                cHolTable = cdb.JobTitleUpdateFile(cHolTable)
                ShowMessage("Holiday Table Sucessfully Editted", MessageType.Success, Me)
            End If

            txtHolName.Text = ""
            txtDay.Text = ""
            txtPercentge.Text = ""
            fillHT()

        Else
            ShowMessage("Name and Description must not be blank", MessageType.Warning, Me)

        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gvHolTable.Rows.Count <> 0 Then
            If Not Session("HTid") = "" Then
                If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cHolTable.id = Session("HTid")
                    cHolTable.holiday_name = txtHolName.Text
                    cHolTable.holiday_date = txtHolDate.Text
                    cHolTable.holiday_day = txtDay.Text
                    cHolTable.holiday_category = ddlHolType.Text
                    cHolTable.holiday_percentage = txtPercentge.Text
                    cHolTable.is_deleted = "0"

                    Dim cdb As New HolidayTableDB
                    cHolTable = cdb.JobTitleUpdateFile(cHolTable)
                    fillHT()
                    txtHolName.Text = ""
                    txtDay.Text = ""
                    txtPercentge.Text = ""
                End If
            Else
                ShowMessage("Please Select before you delete", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("No Record to delete", MessageType.Errors, Me)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If gvHolTable.Rows.Count <> 0 Then
            If Not Session("HTid") = "" Then
                Session("intHT") = "0"
                txtHolName.Enabled = True
                txtHolDate.Enabled = True
                txtDay.Enabled = True
                txtPercentge.Enabled = True
                ddlHolType.Enabled = True
            Else
                ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
            End If
        Else
            ShowMessage("Please Select before you Edit", MessageType.Errors, Me)
        End If

    End Sub

    Protected Sub txtHolDate_TextChanged(sender As Object, e As EventArgs) Handles txtHolDate.TextChanged
        txtDay.Text = Format(CDate(txtHolDate.Text), "dddd")
    End Sub
End Class