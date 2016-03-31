Imports MySql.Data.MySqlClient

Public Class PayrollGen
    ''
End Class
Public Class PayrollGenDB
    Friend Function GetPayrollSetting() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    *")
            xSQL.AppendLine("FROM payroll_settings")
            Try
                Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                    SQLConnect.Open()
                    Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                    Dim da As New MySqlDataAdapter(SQLCommand)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    If ds.Tables.Count <> 0 Then
                        For Each dr In ds.Tables(0).Rows
                            If Not IsDBNull(dr("gov_deduction_settings")) Then gov_deduction_settings = dr("gov_deduction_settings")
                            If Not IsDBNull(dr("tax_deduction_settings")) Then tax_deduction_settings = dr("tax_deduction_settings")

                        Next
                    End If
                End Using
            Catch ex As Exception
                'Throw New Exception("Error in listing data.", ex)
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
End Class

