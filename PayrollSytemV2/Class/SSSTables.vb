Imports System.Text
Imports MySql.Data.MySqlClient
Public Class SSSTables
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
    Private _sss_code As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property sss_code() As String
        Get
            Return _sss_code
        End Get
        Set(ByVal Value As String)
            _sss_code = Value
        End Set
    End Property
    Private _sss_from_comp As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property sss_from_comp() As String
        Get
            Return _sss_from_comp
        End Get
        Set(ByVal Value As String)
            _sss_from_comp = Value
        End Set
    End Property
    Private _sss_to_comp As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property sss_to_comp() As String
        Get
            Return _sss_to_comp
        End Get
        Set(ByVal Value As String)
            _sss_to_comp = Value
        End Set
    End Property
    Private _sss_ee As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property sss_ee() As String
        Get
            Return _sss_ee
        End Get
        Set(ByVal Value As String)
            _sss_ee = Value
        End Set
    End Property
    Private _sss_ec As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property sss_ec() As String
        Get
            Return _sss_ec
        End Get
        Set(ByVal Value As String)
            _sss_ec = Value
        End Set
    End Property
    Private _sss_er As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property sss_er() As String
        Get
            Return _sss_er
        End Get
        Set(ByVal Value As String)
            _sss_er = Value
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
Public Class SSSTablesDB
    Friend Function SSSTableGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    sss_code, ")
            xSQL.AppendLine("    sss_from_comp, ")
            xSQL.AppendLine("    sss_to_comp, ")
            xSQL.AppendLine("    sss_ee, ")
            xSQL.AppendLine("    sss_ec, ")
            xSQL.AppendLine("    sss_er ")
            xSQL.AppendLine("FROM gd_sss")
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
    Friend Function SSSTableInsertFile(ByVal cItem As SSSTables) As SSSTables
        Dim cReturn As New SSSTables
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO gd_sss(")
                xSQL.AppendLine("    sss_code, ")
                xSQL.AppendLine("    sss_from_comp, ")
                xSQL.AppendLine("    sss_to_comp, ")
                xSQL.AppendLine("    sss_ee, ")
                xSQL.AppendLine("    sss_ec, ")
                xSQL.AppendLine("    sss_er, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @sss_code, ")
                xSQL.AppendLine("    @sss_from_comp, ")
                xSQL.AppendLine("    @sss_to_comp, ")
                xSQL.AppendLine("    @sss_ee, ")
                xSQL.AppendLine("    @sss_ec, ")
                xSQL.AppendLine("    @sss_er, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@sss_code", cItem.sss_code)
                commandDB1.Parameters.AddWithValue("@sss_from_comp", cItem.sss_from_comp)
                commandDB1.Parameters.AddWithValue("@sss_to_comp", cItem.sss_to_comp)
                commandDB1.Parameters.AddWithValue("@sss_ee", cItem.sss_ee)
                commandDB1.Parameters.AddWithValue("@sss_ec", cItem.sss_ec)
                commandDB1.Parameters.AddWithValue("@sss_er", cItem.sss_er)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function SSSTableUpdateFile(ByVal cItem As SSSTables) As SSSTables
        Dim cReturn As New SSSTables
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE gd_sss ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    sss_code = @sss_code, ")
                xSQL.AppendLine("    sss_from_comp = @sss_from_comp, ")
                xSQL.AppendLine("    sss_to_comp = @sss_to_comp, ")
                xSQL.AppendLine("    sss_ee = @sss_ee, ")
                xSQL.AppendLine("    sss_ec = @sss_ec, ")
                xSQL.AppendLine("    sss_er = @sss_er, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@sss_code", cItem.sss_code)
                commandDB1.Parameters.AddWithValue("@sss_from_comp", cItem.sss_from_comp)
                commandDB1.Parameters.AddWithValue("@sss_to_comp", cItem.sss_to_comp)
                commandDB1.Parameters.AddWithValue("@sss_ee", cItem.sss_ee)
                commandDB1.Parameters.AddWithValue("@sss_ec", cItem.sss_ec)
                commandDB1.Parameters.AddWithValue("@sss_er", cItem.sss_er)
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
