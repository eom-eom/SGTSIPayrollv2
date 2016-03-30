Imports System.Drawing

Public Class OvertimeSettings
    Inherits System.Web.UI.Page
    Private cOvertimeSetting As New Overtime
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillOvertime()
        End If
    End Sub
    Public Sub fillOvertime()
        Dim cdb As New OvertimeDB
        cdb.GetOvertimeSetting()

        txtORate.Text = overtime_rate
        txtORegSH.Text = overtime_regular_sh
        txtOExSH.Text = overtime_excess_sh
        txtOSHandO.Text = overtime_sh_and_ot
        txtORegLH.Text = overtime_regular_lh
        txtOExLH.Text = overtime_excess_lh
        txtOLHandOT.Text = overtime_lh_and_ot
        txtORegSun.Text = overtime_regular_sun
        txtOExSun.Text = overtime_excess_sun
        txtORegLHSun.Text = overtime_regular_lh_sun
        txtOExLHSun.Text = overtime_excess_lh_sun
        txtONightDiff.Text = overtime_nightdiff
    End Sub
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        With cOvertimeSetting
            .overtime_rate = txtORate.Text
            .overtime_regular_sh = txtORegSH.Text
            .overtime_excess_sh = txtOExSH.Text
            .overtime_sh_and_ot = txtOSHandO.Text
            .overtime_regular_lh = txtORegLH.Text
            .overtime_excess_lh = txtOExLH.Text
            .overtime_lh_and_ot = txtOLHandOT.Text
            .overtime_regular_sun = txtORegSun.Text
            .overtime_excess_sun = txtOExSun.Text
            .overtime_regular_lh_sun = txtORegLHSun.Text
            .overtime_excess_lh_sun = txtOExLHSun.Text
            .overtime_nightdiff = txtONightDiff.Text
            .id = "1"
        End With
     

        Dim cdb As New OvertimeDB
        cOvertimeSetting = cdb.OTUpdateFile(cOvertimeSetting)
        ShowMessage("Overtime Settings Sucessfully Updated", MessageType.Success, Me)
        fillOvertime()
    End Sub
End Class