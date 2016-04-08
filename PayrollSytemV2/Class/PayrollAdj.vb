Imports System.Globalization
Imports MySql.Data.MySqlClient
Public Class PayrollAdj
#Region "Properties"
    Private _id As Int32 = 0
    ''' <summary> Object Property: Type=System.Int32, ColumnSize=4 </summary>
    Friend Property id() As Int32
        Get
            Return _id
        End Get
        Set(ByVal Value As Int32)
            _id = Value
        End Set
    End Property



    Private _date_created As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property date_created() As String
        Get
            Return _date_created
        End Get
        Set(ByVal Value As String)
            _date_created = Value
        End Set
    End Property

    Private _date_occur As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property date_occur() As String
        Get
            Return _date_occur
        End Get
        Set(ByVal Value As String)
            _date_occur = Value
        End Set
    End Property

    Private _amount As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property amount() As String
        Get
            Return _amount
        End Get
        Set(ByVal Value As String)
            _amount = Value
        End Set
    End Property

    Private _remarks As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal Value As String)
            _remarks = Value
        End Set
    End Property

    Private _status As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal Value As String)
            _status = Value
        End Set
    End Property

    Private _payroll_id As Int32 = 0
    ''' <summary> Object Property: Type=System.Int32, ColumnSize=4 </summary>
    Friend Property payroll_id() As Int32
        Get
            Return _payroll_id
        End Get
        Set(ByVal Value As Int32)
            _payroll_id = Value
        End Set
    End Property

    Private _emp_code As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property emp_code() As String
        Get
            Return _emp_code
        End Get
        Set(ByVal Value As String)
            _emp_code = Value
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
Public Class PayrollAdjDB
    Friend Function fillPayrollAdjustments() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT")
            xSQL.AppendLine("payroll_adjustments.id,")
            xSQL.AppendLine("emp_code,")
            xSQL.AppendLine("   concat(first_name, ' ' ,middle_name, ' ' ,last_name) as 'Name', ")
            xSQL.AppendLine("date_created,")
            xSQL.AppendLine("date_occur,")
            xSQL.AppendLine("amount,")
            xSQL.AppendLine("status,")
            xSQL.AppendLine("remarks")
            xSQL.AppendLine("FROM payroll_adjustments")
            xSQL.AppendLine("INNER JOIN employee ON")
            xSQL.AppendLine("payroll_adjustments.emp_code = employee.code")
            xSQL.AppendLine("WHERE payroll_adjustments.is_deleted= '1' ")
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
                MsgBox(ex.ToString, vbCritical + vbOKOnly, "Error")
                'ShowMessage(ex.ToString, MessageType.Success, Me)
            End Try
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
    Friend Function EmpPayAdjInsertFile(ByVal cItem As PayrollAdj) As PayrollAdj
        Dim cReturn As New PayrollAdj
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO payroll_adjustments(")
                xSQL.AppendLine("    date_created, ")
                xSQL.AppendLine("    date_occur, ")
                xSQL.AppendLine("    amount, ")
                xSQL.AppendLine("    remarks, ")
                xSQL.AppendLine("    status, ")
                xSQL.AppendLine("    emp_code, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @date_created, ")
                xSQL.AppendLine("    @date_occur, ")
                xSQL.AppendLine("    @amount, ")
                xSQL.AppendLine("    @remarks, ")
                xSQL.AppendLine("    @status, ")
                xSQL.AppendLine("    @emp_code, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@date_created", cItem.date_created)
                commandDB1.Parameters.AddWithValue("@date_occur", cItem.date_occur)
                commandDB1.Parameters.AddWithValue("@amount", cItem.amount)
                commandDB1.Parameters.AddWithValue("@remarks", cItem.remarks)
                commandDB1.Parameters.AddWithValue("@status", cItem.status)
                commandDB1.Parameters.AddWithValue("@emp_code", cItem.emp_code)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()
                'asdsd
            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function EmpPayAdjUpdateFile(ByVal cItem As PayrollAdj) As PayrollAdj
        Dim cReturn As New PayrollAdj
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("UPDATE  payroll_adjustments ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    date_created = @date_created, ")
                xSQL.AppendLine("    date_occur = @date_occur , ")
                xSQL.AppendLine("    amount = @amount , ")
                xSQL.AppendLine("    remarks = @remarks, ")
                xSQL.AppendLine("    status = @status, ")
                xSQL.AppendLine("    emp_code = @emp_code, ")
                xSQL.AppendLine("    is_deleted = @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")
               

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@date_created", cItem.date_created)
                commandDB1.Parameters.AddWithValue("@date_occur", cItem.date_occur)
                commandDB1.Parameters.AddWithValue("@amount", cItem.amount)
                commandDB1.Parameters.AddWithValue("@remarks", cItem.remarks)
                commandDB1.Parameters.AddWithValue("@status", cItem.status)
                commandDB1.Parameters.AddWithValue("@emp_code", cItem.emp_code)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", cItem.id)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = cItem
        Return cReturn
    End Function
End Class


