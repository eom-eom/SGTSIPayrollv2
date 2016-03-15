Imports System.Text
Imports MySql.Data.MySqlClient
Public Class ShiftsClass
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
    Private _shift_name As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property shift_name() As String
        Get
            Return _shift_name
        End Get
        Set(ByVal Value As String)
            _shift_name = Value
        End Set
    End Property
    Private _time_in As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property time_in() As String
        Get
            Return _time_in
        End Get
        Set(ByVal Value As String)
            _time_in = Value
        End Set
    End Property
    Private _time_out As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property time_out() As String
        Get
            Return _time_out
        End Get
        Set(ByVal Value As String)
            _time_out = Value
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
Public Class ShiftsDB
    Friend Function ShiftsList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    shift_name, ")
            xSQL.AppendLine("    time_in, ")
            xSQL.AppendLine("    time_out ")
            xSQL.AppendLine("FROM shifts")
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
    Friend Function ShiftsListDDL() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    concat(shift_name, ' : ', time_in, ' - ', time_out) as 'shift' ")
            xSQL.AppendLine("FROM shifts")
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
    Friend Function DeptInsertFile(ByVal cItem As ShiftsClass) As ShiftsClass
        Dim cReturn As New ShiftsClass
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO shifts(")
                xSQL.AppendLine("    shift_name, ")
                xSQL.AppendLine("    time_in, ")
                xSQL.AppendLine("    time_out, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @shift_name, ")
                xSQL.AppendLine("    @time_in, ")
                xSQL.AppendLine("    @time_out, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@shift_name", cItem.shift_name)
                commandDB1.Parameters.AddWithValue("@time_in", cItem.time_in)
                commandDB1.Parameters.AddWithValue("@time_out", cItem.time_out)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function ShiftsUpdateFile(ByVal pShifts As ShiftsClass) As ShiftsClass
        Dim cReturn As New ShiftsClass
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE shifts ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    shift_name = @shift_name, ")
                xSQL.AppendLine("    time_in = @time_in, ")
                xSQL.AppendLine("    time_out = @time_out, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@shift_name", pShifts.shift_name)
                commandDB1.Parameters.AddWithValue("@time_in", pShifts.time_in)
                commandDB1.Parameters.AddWithValue("@time_out", pShifts.time_out)
                commandDB1.Parameters.AddWithValue("@is_deleted", pShifts.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pShifts.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pShifts
        Return cReturn
    End Function
End Class
