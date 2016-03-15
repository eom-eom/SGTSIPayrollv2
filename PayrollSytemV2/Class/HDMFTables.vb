Imports System.Text
Imports MySql.Data.MySqlClient
Public Class HDMFTables
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
    Private _hdmf_code As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property hdmf_code() As String
        Get
            Return _hdmf_code
        End Get
        Set(ByVal Value As String)
            _hdmf_code = Value
        End Set
    End Property
    Private _hdmf_from_comp As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property hdmf_from_comp() As String
        Get
            Return _hdmf_from_comp
        End Get
        Set(ByVal Value As String)
            _hdmf_from_comp = Value
        End Set
    End Property
    Private _hdmf_to_comp As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property hdmf_to_comp() As String
        Get
            Return _hdmf_to_comp
        End Get
        Set(ByVal Value As String)
            _hdmf_to_comp = Value
        End Set
    End Property
    Private _hdmf_cont_option As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property hdmf_cont_option() As String
        Get
            Return _hdmf_cont_option
        End Get
        Set(ByVal Value As String)
            _hdmf_cont_option = Value
        End Set
    End Property
    Private _hdmf_ee As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property hdmf_ee() As String
        Get
            Return _hdmf_ee
        End Get
        Set(ByVal Value As String)
            _hdmf_ee = Value
        End Set
    End Property
    Private _hdmf_er As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property hdmf_er() As String
        Get
            Return _hdmf_er
        End Get
        Set(ByVal Value As String)
            _hdmf_er = Value
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
Public Class HDMFTablesDB
    Friend Function HDMFTableGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    hdmf_code, ")
            xSQL.AppendLine("    hdmf_from_comp, ")
            xSQL.AppendLine("    hdmf_to_comp, ")
            xSQL.AppendLine("    hdmf_cont_option, ")
            xSQL.AppendLine("    hdmf_ee, ")
            xSQL.AppendLine("    hdmf_er ")
            xSQL.AppendLine("FROM gd_hdmf")
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
    Friend Function HDMFTableInsertFile(ByVal cItem As HDMFTables) As HDMFTables
        Dim cReturn As New HDMFTables
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO gd_hdmf(")
                xSQL.AppendLine("    hdmf_code, ")
                xSQL.AppendLine("    hdmf_from_comp, ")
                xSQL.AppendLine("    hdmf_to_comp, ")
                xSQL.AppendLine("    hdmf_cont_option, ")
                xSQL.AppendLine("    hdmf_ee, ")
                xSQL.AppendLine("    hdmf_er, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @hdmf_code, ")
                xSQL.AppendLine("    @hdmf_from_comp,")
                xSQL.AppendLine("    @hdmf_to_comp, ")
                xSQL.AppendLine("    @hdmf_cont_option, ")
                xSQL.AppendLine("    @hdmf_ee, ")
                xSQL.AppendLine("    @hdmf_er, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@hdmf_code", cItem.hdmf_code)
                commandDB1.Parameters.AddWithValue("@hdmf_from_comp", cItem.hdmf_from_comp)
                commandDB1.Parameters.AddWithValue("@hdmf_to_comp", cItem.hdmf_to_comp)
                commandDB1.Parameters.AddWithValue("@hdmf_cont_option", cItem.hdmf_cont_option)
                commandDB1.Parameters.AddWithValue("@hdmf_ee", cItem.hdmf_ee)
                commandDB1.Parameters.AddWithValue("@hdmf_er", cItem.hdmf_er)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function HDMFTableUpdateFile(ByVal pHDMF As HDMFTables) As HDMFTables
        Dim cReturn As New HDMFTables
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE gd_hdmf ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    hdmf_code = @hdmf_code, ")
                xSQL.AppendLine("    hdmf_from_comp = @hdmf_from_comp, ")
                xSQL.AppendLine("    hdmf_to_comp = @hdmf_to_comp, ")
                xSQL.AppendLine("    hdmf_cont_option = @hdmf_cont_option, ")
                xSQL.AppendLine("    hdmf_ee = @hdmf_ee, ")
                xSQL.AppendLine("    hdmf_er = @hdmf_er, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@hdmf_code", pHDMF.hdmf_code)
                commandDB1.Parameters.AddWithValue("@hdmf_from_comp", pHDMF.hdmf_from_comp)
                commandDB1.Parameters.AddWithValue("@hdmf_to_comp", pHDMF.hdmf_to_comp)
                commandDB1.Parameters.AddWithValue("@hdmf_cont_option", pHDMF.hdmf_cont_option)
                commandDB1.Parameters.AddWithValue("@hdmf_ee", pHDMF.hdmf_ee)
                commandDB1.Parameters.AddWithValue("@hdmf_er", pHDMF.hdmf_er)
                commandDB1.Parameters.AddWithValue("@is_deleted", pHDMF.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pHDMF.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pHDMF
        Return cReturn
    End Function
End Class
