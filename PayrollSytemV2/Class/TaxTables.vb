Imports System.Text
Imports MySql.Data.MySqlClient
Public Class TaxTables
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
    Private _tax_code As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property tax_code() As String
        Get
            Return _tax_code
        End Get
        Set(ByVal Value As String)
            _tax_code = Value
        End Set
    End Property
    Private _tax_status As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property tax_status() As String
        Get
            Return _tax_status
        End Get
        Set(ByVal Value As String)
            _tax_status = Value
        End Set
    End Property
    Private _tax_operand As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property tax_operand() As String
        Get
            Return _tax_operand
        End Get
        Set(ByVal Value As String)
            _tax_operand = Value
        End Set
    End Property
    Private _tax_amount_comp As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property tax_amount_comp() As String
        Get
            Return _tax_amount_comp
        End Get
        Set(ByVal Value As String)
            _tax_amount_comp = Value
        End Set
    End Property
    Private _tax_ceiling As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property tax_ceiling() As String
        Get
            Return _tax_ceiling
        End Get
        Set(ByVal Value As String)
            _tax_ceiling = Value
        End Set
    End Property
    Private _tax_additional As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property tax_additional() As String
        Get
            Return _tax_additional
        End Get
        Set(ByVal Value As String)
            _tax_additional = Value
        End Set
    End Property
    Private _tax_rate As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property tax_rate() As String
        Get
            Return _tax_rate
        End Get
        Set(ByVal Value As String)
            _tax_rate = Value
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
Public Class TaxTablesDB
    Friend Function TaxTableGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    tax_code, ")
            xSQL.AppendLine("    tax_status, ")
            xSQL.AppendLine("    tax_operand, ")
            xSQL.AppendLine("    tax_amount_comp, ")
            xSQL.AppendLine("    tax_ceiling, ")
            xSQL.AppendLine("    tax_additional, ")
            xSQL.AppendLine("    tax_rate ")
            xSQL.AppendLine("FROM taxes")
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
    Friend Function TaxTableInsertFile(ByVal cItem As TaxTables) As TaxTables
        Dim cReturn As New TaxTables
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO taxes(")
                xSQL.AppendLine("    tax_code, ")
                xSQL.AppendLine("    tax_status, ")
                xSQL.AppendLine("    tax_operand, ")
                xSQL.AppendLine("    tax_amount_comp, ")
                xSQL.AppendLine("    tax_ceiling, ")
                xSQL.AppendLine("    tax_additional, ")
                xSQL.AppendLine("    tax_rate, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @tax_code, ")
                xSQL.AppendLine("    @tax_status, ")
                xSQL.AppendLine("    @tax_operand, ")
                xSQL.AppendLine("    @tax_amount_comp, ")
                xSQL.AppendLine("    @tax_ceiling, ")
                xSQL.AppendLine("    @tax_additional, ")
                xSQL.AppendLine("    @tax_rate, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@tax_code", cItem.tax_code)
                commandDB1.Parameters.AddWithValue("@tax_status", cItem.tax_status)
                commandDB1.Parameters.AddWithValue("@tax_operand", cItem.tax_operand)
                commandDB1.Parameters.AddWithValue("@tax_amount_comp", cItem.tax_amount_comp)
                commandDB1.Parameters.AddWithValue("@tax_ceiling", cItem.tax_ceiling)
                commandDB1.Parameters.AddWithValue("@tax_additional", cItem.tax_additional)
                commandDB1.Parameters.AddWithValue("@tax_rate", cItem.tax_rate)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function TaxTableUpdateFile(ByVal pTaxTable As TaxTables) As TaxTables
        Dim cReturn As New TaxTables
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE taxes ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    tax_code = @tax_code, ")
                xSQL.AppendLine("    tax_status = @tax_status, ")
                xSQL.AppendLine("    tax_operand = @tax_operand, ")
                xSQL.AppendLine("    tax_amount_comp = @tax_amount_comp, ")
                xSQL.AppendLine("    tax_ceiling = @tax_ceiling, ")
                xSQL.AppendLine("    tax_additional = @tax_additional, ")
                xSQL.AppendLine("    tax_rate = @tax_rate, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@tax_code", pTaxTable.tax_code)
                commandDB1.Parameters.AddWithValue("@tax_status", pTaxTable.tax_status)
                commandDB1.Parameters.AddWithValue("@tax_operand", pTaxTable.tax_operand)
                commandDB1.Parameters.AddWithValue("@tax_amount_comp", pTaxTable.tax_amount_comp)
                commandDB1.Parameters.AddWithValue("@tax_ceiling", pTaxTable.tax_ceiling)
                commandDB1.Parameters.AddWithValue("@tax_additional", pTaxTable.tax_additional)
                commandDB1.Parameters.AddWithValue("@tax_rate", pTaxTable.tax_rate)
                commandDB1.Parameters.AddWithValue("@is_deleted", pTaxTable.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pTaxTable.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pTaxTable
        Return cReturn
    End Function
End Class
