Imports System.Text
Imports MySql.Data.MySqlClient
Public Class CompanyDeduction
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
    Private _comde_code As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property comde_code() As String
        Get
            Return _comde_code
        End Get
        Set(ByVal Value As String)
            _comde_code = Value
        End Set
    End Property
    Private _comde_desc As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property comde_desc() As String
        Get
            Return _comde_desc
        End Get
        Set(ByVal Value As String)
            _comde_desc = Value
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
Public Class CompanyDeductionDB
    Friend Function CDGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    comde_code, ")
            xSQL.AppendLine("    comde_desc ")
            xSQL.AppendLine("FROM company_deductions")
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
    Friend Function CDInsertFile(ByVal cItem As CompanyDeduction) As CompanyDeduction
        Dim cReturn As New CompanyDeduction
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO company_deductions(")
                xSQL.AppendLine("    comde_code, ")
                xSQL.AppendLine("    comde_desc, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @comde_code, ")
                xSQL.AppendLine("    @comde_desc, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@comde_code", cItem.comde_code)
                commandDB1.Parameters.AddWithValue("@comde_desc", cItem.comde_desc)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function CDUpdateFile(ByVal pCD As CompanyDeduction) As CompanyDeduction
        Dim cReturn As New CompanyDeduction
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE company_deductions ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    comde_code =  @comde_code, ")
                xSQL.AppendLine("    comde_desc =  @comde_desc, ")
                xSQL.AppendLine("    is_deleted =  @is_deleted ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@comde_code", pCD.comde_code)
                commandDB1.Parameters.AddWithValue("@comde_desc", pCD.comde_desc)
                commandDB1.Parameters.AddWithValue("@is_deleted", pCD.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pCD.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pCD
        Return cReturn
    End Function
End Class
