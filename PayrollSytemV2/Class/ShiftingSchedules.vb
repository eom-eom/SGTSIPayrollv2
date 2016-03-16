Imports System.Text
Imports MySql.Data.MySqlClient
Public Class ShiftingSchedules
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
    Private _emp_id As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property emp_id() As String
        Get
            Return _emp_id
        End Get
        Set(ByVal Value As String)
            _emp_id = Value
        End Set
    End Property
    Private _shift_id As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property shift_id() As String
        Get
            Return _shift_id
        End Get
        Set(ByVal Value As String)
            _shift_id = Value
        End Set
    End Property
    Private _date_from As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property date_from() As String
        Get
            Return _date_from
        End Get
        Set(ByVal Value As String)
            _date_from = Value
        End Set
    End Property
    Private _date_to As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property date_to() As String
        Get
            Return _date_to
        End Get
        Set(ByVal Value As String)
            _date_to = Value
        End Set
    End Property
    Private _date_applied As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property date_applied() As String
        Get
            Return _date_applied
        End Get
        Set(ByVal Value As String)
            _date_applied = Value
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
Public Class ShiftingScheduleDB
    Friend Function ShiftingSchedGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    emp_id, ")
            xSQL.AppendLine("    shift_id, ")
            xSQL.AppendLine("    date_from, ")
            xSQL.AppendLine("    date_to, ")
            xSQL.AppendLine("    date_applied ")
            xSQL.AppendLine("FROM employee_shift")
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
    Friend Function ShiftingSchedInsertFile(ByVal cItem As ShiftingSchedules) As ShiftingSchedules
        Dim cReturn As New ShiftingSchedules
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO employee_shift(")
                xSQL.AppendLine("    emp_id, ")
                xSQL.AppendLine("    shift_id, ")
                xSQL.AppendLine("    date_from, ")
                xSQL.AppendLine("    date_to, ")
                xSQL.AppendLine("    date_applied, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @emp_id, ")
                xSQL.AppendLine("    @shift_id, ")
                xSQL.AppendLine("    @date_from, ")
                xSQL.AppendLine("    @date_to, ")
                xSQL.AppendLine("    @date_applied, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@emp_id", cItem.emp_id)
                commandDB1.Parameters.AddWithValue("@shift_id", cItem.shift_id)
                commandDB1.Parameters.AddWithValue("@date_from", cItem.date_from)
                commandDB1.Parameters.AddWithValue("@date_to", cItem.date_to)
                commandDB1.Parameters.AddWithValue("@date_applied", cItem.date_applied)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function ShiftingSchedUpdateFile(ByVal cItem As ShiftingSchedules) As ShiftingSchedules
        Dim cReturn As New ShiftingSchedules
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE employee_shift ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    emp_id = @emp_id, ")
                xSQL.AppendLine("    shift_id = @shift_id, ")
                xSQL.AppendLine("    date_from = @date_from, ")
                xSQL.AppendLine("    date_to = @date_to, ")
                xSQL.AppendLine("    date_applied = @date_applied, ")
                xSQL.AppendLine("    is_deleted = @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@emp_id", cItem.emp_id)
                commandDB1.Parameters.AddWithValue("@shift_id", cItem.shift_id)
                commandDB1.Parameters.AddWithValue("@date_from", cItem.date_from)
                commandDB1.Parameters.AddWithValue("@date_to", cItem.date_to)
                commandDB1.Parameters.AddWithValue("@date_applied", cItem.date_applied)
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
