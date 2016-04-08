Imports MySql.Data.MySqlClient

Public Class PayrollMain
#Region "Properties"
    Private _payroll_code As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property payroll_code() As String
        Get
            Return _payroll_code
        End Get
        Set(ByVal Value As String)
            _payroll_code = Value
        End Set
    End Property
    Private _is_deleted As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property is_deleted() As String
        Get
            Return _is_deleted
        End Get
        Set(ByVal Value As String)
            _is_deleted = Value
        End Set
    End Property
#End Region

End Class
Public Class PayrollDB
    Friend Function PayrollGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    payroll_code, ")
            xSQL.AppendLine("    date_gen, ")
            xSQL.AppendLine("    date_from, ")
            xSQL.AppendLine("    date_to ")
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
    Friend Function PayrollUpdateFile(ByVal pPayroll As PayrollMain) As PayrollMain
        Dim cReturn As New PayrollMain
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE payroll")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE payroll_code = @payroll_code")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@is_deleted", pPayroll.is_deleted)
                commandDB1.Parameters.AddWithValue("@payroll_code", pPayroll.payroll_code)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pPayroll
        Return cReturn
    End Function
    Friend Function GetAdminPassword(ByVal xCode As String) As Boolean
        GetAdminPassword = False
        Dim salt As String = "xxxxxxxxxxxxx"
        Dim nPassword As String = xCode & salt
        Dim ePassword As String = makeMD5Hash(nPassword)
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    password ")
            xSQL.AppendLine("FROM users")
            xSQL.AppendLine("WHERE  user_name = 'admin' ")
            Try
                Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                    SQLConnect.Open()
                    Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                    Dim da As New MySqlDataAdapter(SQLCommand)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    If ds.Tables.Count <> 0 Then
                        For Each dr In ds.Tables(0).Rows
                            If Trim(dr("password").ToString) = Trim(ePassword) Then
                                GetAdminPassword = True
                            End If
                        Next
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
