Module modFunction
    Public company_name As String
    Public company_address As String
    Public company_telephone As String
    Public default_shift As String
    Public grace_period As String
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
