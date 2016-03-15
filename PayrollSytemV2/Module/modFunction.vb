Module modFunction

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
