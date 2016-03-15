Imports System.Text
Imports MySql.Data.MySqlClient
Public Class DeMinimisBenefit
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
    Private _dmb_code As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property dmb_code() As String
        Get
            Return _dmb_code
        End Get
        Set(ByVal Value As String)
            _dmb_code = Value
        End Set
    End Property
    Private _dmb_desc As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property dmb_desc() As String
        Get
            Return _dmb_desc
        End Get
        Set(ByVal Value As String)
            _dmb_desc = Value
        End Set
    End Property
    Private _dmb_amount As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property dmb_amount() As String
        Get
            Return _dmb_amount
        End Get
        Set(ByVal Value As String)
            _dmb_amount = Value
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
Public Class DeMinimisBenefitDB
    Friend Function DMBGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    dmb_code, ")
            xSQL.AppendLine("    dmb_desc, ")
            xSQL.AppendLine("    dmb_amount ")
            xSQL.AppendLine("FROM de_minimis_benefits")
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
    Friend Function DMBInsertFile(ByVal cItem As DeMinimisBenefit) As DeMinimisBenefit
        Dim cReturn As New DeMinimisBenefit
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO de_minimis_benefits(")
                xSQL.AppendLine("    dmb_code, ")
                xSQL.AppendLine("    dmb_desc, ")
                xSQL.AppendLine("    dmb_amount, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @dmb_code, ")
                xSQL.AppendLine("    @dmb_desc, ")
                xSQL.AppendLine("    @dmb_amount, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@dmb_code", cItem.dmb_code)
                commandDB1.Parameters.AddWithValue("@dmb_desc", cItem.dmb_desc)
                commandDB1.Parameters.AddWithValue("@dmb_amount", cItem.dmb_amount)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function DMBUpdateFile(ByVal pDMB As DeMinimisBenefit) As DeMinimisBenefit
        Dim cReturn As New DeMinimisBenefit
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE de_minimis_benefits ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    dmb_code = @dmb_code, ")
                xSQL.AppendLine("    dmb_desc = @dmb_desc, ")
                xSQL.AppendLine("    dmb_amount = @dmb_amount, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@dmb_code", pDMB.dmb_code)
                commandDB1.Parameters.AddWithValue("@dmb_desc", pDMB.dmb_desc)
                commandDB1.Parameters.AddWithValue("@dmb_amount", pDMB.dmb_amount)
                commandDB1.Parameters.AddWithValue("@is_deleted", pDMB.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pDMB.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pDMB
        Return cReturn
    End Function
End Class
