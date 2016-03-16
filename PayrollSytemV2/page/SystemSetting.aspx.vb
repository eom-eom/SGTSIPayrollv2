Imports System.IO

Public Class SystemSetting
    Inherits System.Web.UI.Page
    Private cSytemSetting As New SystemSettings
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillsystem()
        End If

    End Sub

    Public Sub fillsystem()
        Dim cdb As New SystemSettingsDB
        cdb.GetSystemSetting()
        txtCompanyName.Text = company_name
        txtAddress.Text = company_address
        txtTelNo.Text = company_telephone
        If default_shift = "DS" Then
            ddlShift.SelectedValue = "DS"
        ElseIf default_shift = "MS" Then
            ddlShift.SelectedValue = "MS"
        ElseIf default_shift = "NS" Then
            ddlShift.SelectedValue = "NS"
        End If
        txtgracePeriod.Text = grace_period
    End Sub

  
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If Not txtCompanyName.Text = "" And Not txtAddress.Text = "" And Not txtTelNo.Text = "" And Not txtgracePeriod.Text = "" Then
            cSytemSetting.company_name = txtCompanyName.Text
            cSytemSetting.company_address = txtAddress.Text
            cSytemSetting.company_telephone = txtTelNo.Text
            cSytemSetting.default_shift = ddlShift.SelectedValue
            cSytemSetting.grace_period = txtgracePeriod.Text
            cSytemSetting.id = "1"

            Dim cdb As New SystemSettingsDB
            cSytemSetting = cdb.SSUpdateFile(cSytemSetting)
            ShowMessage("System Settings Sucessfully Updated", MessageType.Success, Me)
            fillsystem()
        End If

    End Sub
End Class