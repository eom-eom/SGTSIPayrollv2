Imports MySql.Data.MySqlClient

Public Class CReports

    Friend Function ShiftsListDDL() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    payroll.payroll_code, ")
            xSQL.AppendLine("    payroll.date_from, ")
            xSQL.AppendLine("    payroll.date_to, ")
            xSQL.AppendLine("    concat(payroll.payroll_code, ': ' ,payroll.date_from, ' - ' ,payroll.date_to) AS v_payroll_code")
            xSQL.AppendLine("FROM payroll")
            xSQL.AppendLine("WHERE is_deleted = '1' ")

            Try
                Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                    SQLConnect.Open()
                    Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                    Dim da As New MySqlDataAdapter(SQLCommand)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    If ds.Tables.Count <> 0 Then
                        dt = ds.Tables(0)
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
    Friend Function GetSystemSetting() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    * ")
            xSQL.AppendLine("FROM system_settings")
            Try
                Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                    SQLConnect.Open()
                    Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                    Dim da As New MySqlDataAdapter(SQLCommand)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    If ds.Tables.Count <> 0 Then
                        For Each dr In ds.Tables(0).Rows
                            If Not IsDBNull(dr("Company_Name")) Then company_name = dr("Company_Name")
                            If Not IsDBNull(dr("Company_Address")) Then company_address = dr("Company_Address")
                            If Not IsDBNull(dr("Company_Telephone")) Then company_telephone = dr("Company_Telephone")
                        Next
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
End Class
