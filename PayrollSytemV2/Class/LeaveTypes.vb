Imports System.Text
Imports MySql.Data.MySqlClient
Public Class LeaveTypes
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
    Private _leave_desc As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property leave_desc() As String
        Get
            Return _leave_desc
        End Get
        Set(ByVal Value As String)
            _leave_desc = Value
        End Set
    End Property
    Private _leave_no_of_days As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property leave_no_of_days() As String
        Get
            Return _leave_no_of_days
        End Get
        Set(ByVal Value As String)
            _leave_no_of_days = Value
        End Set
    End Property
    Private _leave_convertable As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property leave_convertable() As String
        Get
            Return _leave_convertable
        End Get
        Set(ByVal Value As String)
            _leave_convertable = Value
        End Set
    End Property
    Private _w_pay As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property w_pay() As String
        Get
            Return _w_pay
        End Get
        Set(ByVal Value As String)
            _w_pay = Value
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
Public Class LeaveTypesDB
    Friend Function LeaveTypesGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    leave_desc, ")
            xSQL.AppendLine("    leave_no_of_days, ")
            xSQL.AppendLine("    leave_convertable, ")
            xSQL.AppendLine("    w_pay ")
            xSQL.AppendLine("FROM leaves")
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
    Friend Function LeavesInsertFile(ByVal cItem As LeaveTypes) As LeaveTypes
        Dim cReturn As New LeaveTypes
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO leaves(")
                xSQL.AppendLine("    leave_desc, ")
                xSQL.AppendLine("    leave_no_of_days, ")
                xSQL.AppendLine("    leave_convertable, ")
                xSQL.AppendLine("    w_pay, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @leave_desc, ")
                xSQL.AppendLine("    @leave_no_of_days, ")
                xSQL.AppendLine("    @leave_convertable, ")
                xSQL.AppendLine("    @w_pay, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@leave_desc", cItem.leave_desc)
                commandDB1.Parameters.AddWithValue("@leave_no_of_days", cItem.leave_no_of_days)
                commandDB1.Parameters.AddWithValue("@leave_convertable", cItem.leave_convertable)
                commandDB1.Parameters.AddWithValue("@w_pay", cItem.w_pay)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function LeavesUpdateFile(ByVal pLeaves As LeaveTypes) As LeaveTypes
        Dim cReturn As New LeaveTypes
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE leaves ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    leave_desc = @leave_desc, ")
                xSQL.AppendLine("    leave_no_of_days = @leave_no_of_days, ")
                xSQL.AppendLine("    leave_convertable = @leave_convertable, ")
                xSQL.AppendLine("    w_pay = @w_pay, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@leave_desc", pLeaves.leave_desc)
                commandDB1.Parameters.AddWithValue("@leave_no_of_days", pLeaves.leave_no_of_days)
                commandDB1.Parameters.AddWithValue("@leave_convertable", pLeaves.leave_convertable)
                commandDB1.Parameters.AddWithValue("@w_pay", pLeaves.w_pay)
                commandDB1.Parameters.AddWithValue("@is_deleted", pLeaves.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pLeaves.id)
                commandDB1.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pLeaves
        Return cReturn
    End Function
End Class
