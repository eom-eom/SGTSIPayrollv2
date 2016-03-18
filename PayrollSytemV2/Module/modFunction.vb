Module modFunction
    Public company_name As String
    Public company_address As String
    Public company_telephone As String
    Public default_shift As String
    Public grace_period As String

    Public salary_setting As String
    Public overtime_rate As String
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
    
End Module
