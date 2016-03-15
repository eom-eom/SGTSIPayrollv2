Imports System.Text
Imports MySql.Data.MySqlClient
Public Class LateUndertime
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
    Private _lu_from As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property lu_from() As String
        Get
            Return _lu_from
        End Get
        Set(ByVal Value As String)
            _lu_from = Value
        End Set
    End Property
    Private _lu_to As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property lu_to() As String
        Get
            Return _lu_to
        End Get
        Set(ByVal Value As String)
            _lu_to = Value
        End Set
    End Property
    Private _lu_percentage As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property lu_percentage() As String
        Get
            Return _lu_percentage
        End Get
        Set(ByVal Value As String)
            _lu_percentage = Value
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
    Private _lu_type As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property lu_type() As String
        Get
            Return _lu_type
        End Get
        Set(ByVal Value As String)
            _lu_type = Value
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
Public Class LateUndertimeDB
    Friend Function LateUndertimeGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    late_undertime.id, ")
            xSQL.AppendLine("    lu_from, ")
            xSQL.AppendLine("    lu_to, ")
            xSQL.AppendLine("    lu_percentage, ")
            xSQL.AppendLine("    shifts.shift_name as 'shift_name', ")
            xSQL.AppendLine("    lu_type ")
            xSQL.AppendLine("FROM late_undertime")
            xSQL.AppendLine("INNER JOIN shifts ON late_undertime.shift_id = shifts.id")
            xSQL.AppendLine("WHERE late_undertime.is_deleted = '1' ")

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
    Friend Function LateUndertimeInsertFile(ByVal cItem As LateUndertime) As LateUndertime
        Dim cReturn As New LateUndertime
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO late_undertime(")
                xSQL.AppendLine("    lu_from, ")
                xSQL.AppendLine("    lu_to, ")
                xSQL.AppendLine("    lu_percentage, ")
                xSQL.AppendLine("    shift_id, ")
                xSQL.AppendLine("    lu_type, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @lu_from, ")
                xSQL.AppendLine("    @lu_to, ")
                xSQL.AppendLine("    @lu_percentage, ")
                xSQL.AppendLine("    @shift_id, ")
                xSQL.AppendLine("    @lu_type, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@lu_from", cItem.lu_from)
                commandDB1.Parameters.AddWithValue("@lu_to", cItem.lu_to)
                commandDB1.Parameters.AddWithValue("@lu_percentage", cItem.lu_percentage)
                commandDB1.Parameters.AddWithValue("@shift_id", cItem.shift_id)
                commandDB1.Parameters.AddWithValue("@lu_type", cItem.lu_type)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function LateUndertimeUpdateFile(ByVal pLU As LateUndertime) As LateUndertime
        Dim cReturn As New LateUndertime
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE late_undertime ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    lu_from = @lu_from, ")
                xSQL.AppendLine("    lu_to = @lu_to, ")
                xSQL.AppendLine("    lu_percentage = @lu_percentage, ")
                xSQL.AppendLine("    shift_id = @shift_id, ")
                xSQL.AppendLine("    lu_type = @lu_type, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@lu_from", pLU.lu_from)
                commandDB1.Parameters.AddWithValue("@lu_to", pLU.lu_to)
                commandDB1.Parameters.AddWithValue("@lu_percentage", pLU.lu_percentage)
                commandDB1.Parameters.AddWithValue("@shift_id", pLU.shift_id)
                commandDB1.Parameters.AddWithValue("@lu_type", pLU.lu_type)
                commandDB1.Parameters.AddWithValue("@is_deleted", pLU.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pLU.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pLU
        Return cReturn
    End Function
End Class
