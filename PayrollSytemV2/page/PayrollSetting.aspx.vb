Imports System.IO
Public Class PayrollSetting
    Inherits System.Web.UI.Page
    Private cPayrollSetting As New PayrollSettings
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillPayroll()
        End If
    End Sub
    Public Sub fillPayroll()
        Dim cdb As New PayrollSettingDB
        cdb.GetPayrollSetting()
        txtSalarySetting.Text = salary_setting
        txtNightDiffRate.Text = night_diff_rate
        txtSHolidayRate.Text = special_holiday_rate
        txtLHolidayRate.Text = legal_holiday_rate
        txtGovDecSettings.Text = gov_deduction_settings
        txtTaxDeducSettings.Text = tax_deduction_settings
        txt13Montdate.Text = month_release_date
        txtCompDeducSettings.Text = comp_deduction_settings
        txtMinWage.Text = minimum_wage
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not txtSalarySetting.Text = "" And Not txtNightDiffRate.Text = "" And Not txtSHolidayRate.Text = "" And Not txtLHolidayRate.Text = "" And Not txtGovDecSettings.Text = "" And Not txtTaxDeducSettings.Text = "" And Not txtCompDeducSettings.Text = "" And Not txtMinWage.Text = "" Then
            cPayrollSetting.salary_setting = txtSalarySetting.Text
            cPayrollSetting.overtime_rate = txtOTRate.Text
            cPayrollSetting.night_diff_rate = txtNightDiffRate.Text
            cPayrollSetting.special_holiday_rate = txtSHolidayRate.Text
            cPayrollSetting.legal_holiday_rate = txtLHolidayRate.Text
            cPayrollSetting.gov_deduction_settings = txtGovDecSettings.Text
            cPayrollSetting.tax_deduction_settings = txtTaxDeducSettings.Text
            cPayrollSetting.month_release_date = txt13Montdate.Text
            cPayrollSetting.comp_deduction_settings = txtCompDeducSettings.Text
            cPayrollSetting.minimum_wage = txtMinWage.Text
            cPayrollSetting.id = "1"

            Dim cdb As New PayrollSettingDB
            cPayrollSetting = cdb.PayrollSetUpdateFile(cPayrollSetting)
            ShowMessage("Payroll Settings Sucessfully Updated", MessageType.Success, Me)
            fillPayroll()
        Else
            ShowMessage("Fill up all the fields", MessageType.Errors, Me)
        End If
    End Sub
End Class