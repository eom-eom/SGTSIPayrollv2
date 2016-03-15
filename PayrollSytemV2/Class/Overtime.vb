Imports System.Text
Imports MySql.Data.MySqlClient
Public Class Overtime
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
    Private _overtime_name As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_name() As String
        Get
            Return _overtime_name
        End Get
        Set(ByVal Value As String)
            _overtime_name = Value
        End Set
    End Property
    Private _overtime_rate As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_rate() As String
        Get
            Return _overtime_rate
        End Get
        Set(ByVal Value As String)
            _overtime_rate = Value
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
Public Class OvertimeDB
    Friend Function OTGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    overtime_name, ")
            xSQL.AppendLine("    overtime_rate ")
            xSQL.AppendLine("FROM overtime")
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
    Friend Function OTInsertFile(ByVal cItem As Overtime) As Overtime
        Dim cReturn As New Overtime
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO overtime(")
                xSQL.AppendLine("    overtime_name, ")
                xSQL.AppendLine("    overtime_rate, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @overtime_name, ")
                xSQL.AppendLine("    @overtime_rate, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@overtime_name", cItem.overtime_name)
                commandDB1.Parameters.AddWithValue("@overtime_rate", cItem.overtime_rate)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function OTUpdateFile(ByVal pOT As Overtime) As Overtime
        Dim cReturn As New Overtime
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE overtime ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    overtime_name =  @overtime_name, ")
                xSQL.AppendLine("    overtime_rate =  @overtime_rate, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@overtime_name", pOT.overtime_name)
                commandDB1.Parameters.AddWithValue("@overtime_rate", pOT.overtime_rate)
                commandDB1.Parameters.AddWithValue("@is_deleted", pOT.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pOT.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pOT
        Return cReturn
    End Function
End Class
