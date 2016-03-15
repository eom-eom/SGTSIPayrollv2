Imports System.Text
Imports MySql.Data.MySqlClient
Public Class ReceivablesAndTaxable
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
    Private _rta_code As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property rta_code() As String
        Get
            Return _rta_code
        End Get
        Set(ByVal Value As String)
            _rta_code = Value
        End Set
    End Property
    Private _rta_desc As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property rta_desc() As String
        Get
            Return _rta_desc
        End Get
        Set(ByVal Value As String)
            _rta_desc = Value
        End Set
    End Property
   
    Private _rta_amount As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property rta_amount() As String
        Get
            Return _rta_amount
        End Get
        Set(ByVal Value As String)
            _rta_amount = Value
        End Set
    End Property
    Private _rta_taxable As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property rta_taxable() As String
        Get
            Return _rta_taxable
        End Get
        Set(ByVal Value As String)
            _rta_taxable = Value
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
Public Class ReceivablesAndTaxableDB
    Friend Function RTAGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    rta_code, ")
            xSQL.AppendLine("    rta_desc, ")
            xSQL.AppendLine("    rta_amount, ")
            xSQL.AppendLine("    rta_taxable ")
            xSQL.AppendLine("FROM receivable_and_taxable_allowances")
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
    Friend Function RTAInsertFile(ByVal cItem As ReceivablesAndTaxable) As ReceivablesAndTaxable
        Dim cReturn As New ReceivablesAndTaxable
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO receivable_and_taxable_allowances(")
                xSQL.AppendLine("    rta_code, ")
                xSQL.AppendLine("    rta_desc, ")
                xSQL.AppendLine("    rta_amount, ")
                xSQL.AppendLine("    rta_taxable, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @rta_code, ")
                xSQL.AppendLine("    @rta_desc, ")
                xSQL.AppendLine("    @rta_amount, ")
                xSQL.AppendLine("    @rta_taxable, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@rta_code", cItem.rta_code)
                commandDB1.Parameters.AddWithValue("@rta_desc", cItem.rta_desc)
                commandDB1.Parameters.AddWithValue("@rta_amount", cItem.rta_amount)
                commandDB1.Parameters.AddWithValue("@rta_taxable", cItem.rta_taxable)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function RTAUpdateFile(ByVal pRTA As ReceivablesAndTaxable) As ReceivablesAndTaxable
        Dim cReturn As New ReceivablesAndTaxable
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE receivable_and_taxable_allowances ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    rta_code = @rta_code, ")
                xSQL.AppendLine("    rta_desc = @rta_desc, ")
                xSQL.AppendLine("    rta_amount = @rta_amount, ")
                xSQL.AppendLine("    rta_taxable = @rta_taxable, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@rta_code", pRTA.rta_code)
                commandDB1.Parameters.AddWithValue("@rta_desc", pRTA.rta_desc)
                commandDB1.Parameters.AddWithValue("@rta_amount", pRTA.rta_amount)
                commandDB1.Parameters.AddWithValue("@rta_taxable", pRTA.rta_taxable)
                commandDB1.Parameters.AddWithValue("@is_deleted", pRTA.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pRTA.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pRTA
        Return cReturn
    End Function
End Class
