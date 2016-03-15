Imports System.Text
Imports MySql.Data.MySqlClient
Public Class PhilhealthTables
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
    Private _ph_code As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property ph_code() As String
        Get
            Return _ph_code
        End Get
        Set(ByVal Value As String)
            _ph_code = Value
        End Set
    End Property
    Private _ph_from_comp As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property ph_from_comp() As String
        Get
            Return _ph_from_comp
        End Get
        Set(ByVal Value As String)
            _ph_from_comp = Value
        End Set
    End Property
    Private _ph_to_comp As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property ph_to_comp() As String
        Get
            Return _ph_to_comp
        End Get
        Set(ByVal Value As String)
            _ph_to_comp = Value
        End Set
    End Property
    Private _ph_ee As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property ph_ee() As String
        Get
            Return _ph_ee
        End Get
        Set(ByVal Value As String)
            _ph_ee = Value
        End Set
    End Property
    Private _ph_er As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property ph_er() As String
        Get
            Return _ph_er
        End Get
        Set(ByVal Value As String)
            _ph_er = Value
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
Public Class PhilhealthTablesDB
    Friend Function PHTableGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    ph_code, ")
            xSQL.AppendLine("    ph_from_comp, ")
            xSQL.AppendLine("    ph_to_comp, ")
            xSQL.AppendLine("    ph_ee, ")
            xSQL.AppendLine("    ph_er ")
            xSQL.AppendLine("FROM gd_philhealth")
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
    Friend Function PHTableInsertFile(ByVal cItem As PhilhealthTables) As PhilhealthTables
        Dim cReturn As New PhilhealthTables
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO gd_philhealth(")
                xSQL.AppendLine("    ph_code, ")
                xSQL.AppendLine("    ph_from_comp, ")
                xSQL.AppendLine("    ph_to_comp, ")
                xSQL.AppendLine("    ph_ee, ")
                xSQL.AppendLine("    ph_er, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @ph_code, ")
                xSQL.AppendLine("    @ph_from_comp, ")
                xSQL.AppendLine("    @ph_to_comp, ")
                xSQL.AppendLine("    @ph_ee, ")
                xSQL.AppendLine("    @ph_er, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@ph_code", cItem.ph_code)
                commandDB1.Parameters.AddWithValue("@ph_from_comp", cItem.ph_from_comp)
                commandDB1.Parameters.AddWithValue("@ph_to_comp", cItem.ph_to_comp)
                commandDB1.Parameters.AddWithValue("@ph_ee", cItem.ph_ee)
                commandDB1.Parameters.AddWithValue("@ph_er", cItem.ph_er)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function PHTableUpdateFile(ByVal pPH As PhilhealthTables) As PhilhealthTables
        Dim cReturn As New PhilhealthTables
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE gd_philhealth ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    ph_code = @ph_code, ")
                xSQL.AppendLine("    ph_from_comp = @ph_from_comp, ")
                xSQL.AppendLine("    ph_to_comp = @ph_to_comp, ")
                xSQL.AppendLine("    ph_ee = @ph_ee, ")
                xSQL.AppendLine("    ph_er = @ph_er, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@ph_code", pPH.ph_code)
                commandDB1.Parameters.AddWithValue("@ph_from_comp", pPH.ph_from_comp)
                commandDB1.Parameters.AddWithValue("@ph_to_comp", pPH.ph_to_comp)
                commandDB1.Parameters.AddWithValue("@ph_ee", pPH.ph_ee)
                commandDB1.Parameters.AddWithValue("@ph_er", pPH.ph_er)
                commandDB1.Parameters.AddWithValue("@is_deleted", pPH.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pPH.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pPH
        Return cReturn
    End Function
End Class
