Imports System.Text
Imports MySql.Data.MySqlClient
Public Class SystemSettings
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
    Private _company_name As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property company_name() As String
        Get
            Return _company_name
        End Get
        Set(ByVal Value As String)
            _company_name = Value
        End Set
    End Property
    '-
    Private _company_address As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property company_address() As String
        Get
            Return _company_address
        End Get
        Set(ByVal Value As String)
            _company_address = Value
        End Set
    End Property
    '-
    Private _company_telephone As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property company_telephone() As String
        Get
            Return _company_telephone
        End Get
        Set(ByVal Value As String)
            _company_telephone = Value
        End Set
    End Property
    '-
    Private _company_logo As Byte() = Nothing
    ''' <summary> Object Property: Type=System.Byte[], ColumnSize=2147483647 </summary>
    Friend Property company_logo() As Byte()
        Get
            Return _company_logo
        End Get
        Set(ByVal Value As Byte())
            _company_logo = Value
        End Set
    End Property
    Private _default_shift As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property default_shift() As String
        Get
            Return _default_shift
        End Get
        Set(ByVal Value As String)
            _default_shift = Value
        End Set
    End Property
    Private _grace_period As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property grace_period() As String
        Get
            Return _grace_period
        End Get
        Set(ByVal Value As String)
            _grace_period = Value
        End Set
    End Property
#End Region
End Class
Public Class SystemSettingsDB
    Friend Function SSUpdateFile(ByVal pSS As SystemSettings) As SystemSettings
        Dim cReturn As New SystemSettings
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE system_settings ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    company_name = @company_name, ")
                xSQL.AppendLine("    company_address = @company_address, ")
                xSQL.AppendLine("    company_telephone = @company_telephone, ")
                xSQL.AppendLine("    company_logo = @company_logo, ")
                xSQL.AppendLine("    default_shift = @default_shift, ")
                xSQL.AppendLine("    grace_period = @grace_period ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB.Parameters.AddWithValue("@company_name", pSS.company_name)
                commandDB.Parameters.AddWithValue("@company_address", pSS.company_address)
                commandDB.Parameters.AddWithValue("@company_telephone", pSS.company_telephone)
                commandDB.Parameters.AddWithValue("@company_logo", pSS.company_logo)
                commandDB.Parameters.AddWithValue("@default_shift", pSS.default_shift)
                commandDB.Parameters.AddWithValue("@grace_period", pSS.grace_period)
                commandDB.Parameters.AddWithValue("@id", pSS.id)
                commandDB.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pSS
        Return cReturn
    End Function
   
    Friend Function GetSystemSetting() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    * ")
            xSQL.AppendLine("FROM system_settings")
            Try
                Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                    SQLConnect.Open()
                    Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                    Dim da As New MySqlDataAdapter(SQLCommand)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    If ds.Tables.Count <> 0 Then
                        For Each dr In ds.Tables(0).Rows
                            If Not IsDBNull(dr("company_name")) Then company_name = dr("company_name")
                            If Not IsDBNull(dr("company_address")) Then company_address = dr("company_address")
                            If Not IsDBNull(dr("company_telephone")) Then company_telephone = dr("company_telephone")
                            If Not IsDBNull(dr("default_shift")) Then default_shift = dr("default_shift")
                            If Not IsDBNull(dr("grace_period")) Then grace_period = dr("grace_period")
                        Next
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
End Class