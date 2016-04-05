Imports System.Security.Cryptography

Module modFunction
    Public company_name As String
    Public company_address As String
    Public company_telephone As String
    Public default_shift As String
    Public grace_period As String

    Public overtime_rate As String
    Public overtime_regular_sh As String
    Public overtime_excess_sh As String
    Public overtime_sh_and_ot As String
    Public overtime_regular_lh As String
    Public overtime_excess_lh As String
    Public overtime_lh_and_ot As String
    Public overtime_regular_sun As String
    Public overtime_excess_sun As String
    Public overtime_regular_lh_sun As String
    Public overtime_excess_lh_sun As String
    Public overtime_nightdiff As String

    Public salary_setting As String
    'Public overtime_rate As String
    Public night_diff_rate As String
    Public special_holiday_rate As String
    Public legal_holiday_rate As String
    Public gov_deduction_settings As String
    Public tax_deduction_settings As String
    Public month_release_date As String
    Public comp_deduction_settings As String
    Public minimum_wage As String

    Enum MessageType
        Success
        Info
        Warning
        Errors
    End Enum
    Public Sub ShowMessage(Message As String, Types As MessageType, p As Page)
        ScriptManager.RegisterStartupScript(p, p.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" & Types & "');", True)
    End Sub
    Friend Function ModC(ByVal x As Double) As Double
        ModC = Format(x, "0.00")
    End Function
    Friend Function ShowComma(ByVal x As Double) As String
        ShowComma = x.ToString("N")
    End Function
    Public Sub ShowMessage_mod(Message As String, Types As MessageType, p As Page)
        ScriptManager.RegisterStartupScript(p, p.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage_mod('" + Message + "','" & Types & "');", True)
    End Sub
    Function makeMD5Hash(ByVal strToHash As String) As String
        Dim md5Obj As New MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function
End Module
