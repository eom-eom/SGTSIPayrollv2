Imports System.Text
Imports MySql.Data.MySqlClient
Public Class PayrollSettings
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
    Private _salary_setting As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property salary_setting() As String
        Get
            Return _salary_setting
        End Get
        Set(ByVal Value As String)
            _salary_setting = Value
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
    Private _night_diff_rate As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property night_diff_rate() As String
        Get
            Return _night_diff_rate
        End Get
        Set(ByVal Value As String)
            _night_diff_rate = Value
        End Set
    End Property
    Private _special_holiday_rate As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property special_holiday_rate() As String
        Get
            Return _special_holiday_rate
        End Get
        Set(ByVal Value As String)
            _special_holiday_rate = Value
        End Set
    End Property
    Private _legal_holiday_rate As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property legal_holiday_rate() As String
        Get
            Return _legal_holiday_rate
        End Get
        Set(ByVal Value As String)
            _legal_holiday_rate = Value
        End Set
    End Property
    Private _gov_deduction_settings As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property gov_deduction_settings() As String
        Get
            Return _gov_deduction_settings
        End Get
        Set(ByVal Value As String)
            _gov_deduction_settings = Value
        End Set
    End Property
    Private _tax_deduction_settings As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property tax_deduction_settings() As String
        Get
            Return _tax_deduction_settings
        End Get
        Set(ByVal Value As String)
            _tax_deduction_settings = Value
        End Set
    End Property
    Private _13month_release_date As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property month_release_date() As String
        Get
            Return _13month_release_date
        End Get
        Set(ByVal Value As String)
            _13month_release_date = Value
        End Set
    End Property
    Private _comp_deduction_settings As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property comp_deduction_settings() As String
        Get
            Return _comp_deduction_settings
        End Get
        Set(ByVal Value As String)
            _comp_deduction_settings = Value
        End Set
    End Property
    Private _minimum_wage As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property minimum_wage() As String
        Get
            Return _minimum_wage
        End Get
        Set(ByVal Value As String)
            _minimum_wage = Value
        End Set
    End Property
#End Region
End Class
Public Class PayrollSettingDB
    Friend Function PayrollSetUpdateFile(ByVal pPS As PayrollSettings) As PayrollSettings
        Dim cReturn As New PayrollSettings
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE payroll_settings ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    salary_setting = @salary_setting, ")
                xSQL.AppendLine("    overtime_rate = @overtime_rate, ")
                xSQL.AppendLine("    night_diff_rate = @night_diff_rate, ")
                xSQL.AppendLine("    special_holiday_rate = @special_holiday_rate, ")
                xSQL.AppendLine("    legal_holiday_rate = @legal_holiday_rate, ")
                xSQL.AppendLine("    gov_deduction_settings = @gov_deduction_settings, ")
                xSQL.AppendLine("    tax_deduction_settings = @tax_deduction_settings, ")
                xSQL.AppendLine("    13month_release_date = @13month_release_date, ")
                xSQL.AppendLine("    comp_deduction_settings = @comp_deduction_settings, ")
                xSQL.AppendLine("    minimum_wage = @minimum_wage ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB.Parameters.AddWithValue("@salary_setting", pPS.salary_setting)
                commandDB.Parameters.AddWithValue("@overtime_rate", pPS.overtime_rate)
                commandDB.Parameters.AddWithValue("@night_diff_rate", pPS.night_diff_rate)
                commandDB.Parameters.AddWithValue("@special_holiday_rate", pPS.special_holiday_rate)
                commandDB.Parameters.AddWithValue("@legal_holiday_rate", pPS.legal_holiday_rate)
                commandDB.Parameters.AddWithValue("@gov_deduction_settings", pPS.gov_deduction_settings)
                commandDB.Parameters.AddWithValue("@tax_deduction_settings", pPS.tax_deduction_settings)
                commandDB.Parameters.AddWithValue("@13month_release_date", pPS.month_release_date)
                commandDB.Parameters.AddWithValue("@comp_deduction_settings", pPS.comp_deduction_settings)
                commandDB.Parameters.AddWithValue("@minimum_wage", pPS.minimum_wage)
                commandDB.Parameters.AddWithValue("@id", pPS.id)
                commandDB.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pPS
        Return cReturn
    End Function
    Friend Function GetPayrollSetting() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    * ")
            xSQL.AppendLine("FROM payroll_settings")
            Try
                Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                    SQLConnect.Open()
                    Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                    Dim da As New MySqlDataAdapter(SQLCommand)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    If ds.Tables.Count <> 0 Then
                        For Each dr In ds.Tables(0).Rows
                            If Not IsDBNull(dr("salary_setting")) Then salary_setting = dr("salary_setting")
                            If Not IsDBNull(dr("overtime_rate")) Then overtime_rate = dr("overtime_rate")
                            If Not IsDBNull(dr("night_diff_rate")) Then night_diff_rate = dr("night_diff_rate")
                            If Not IsDBNull(dr("special_holiday_rate")) Then special_holiday_rate = dr("special_holiday_rate")
                            If Not IsDBNull(dr("legal_holiday_rate")) Then legal_holiday_rate = dr("legal_holiday_rate")
                            If Not IsDBNull(dr("gov_deduction_settings")) Then gov_deduction_settings = dr("gov_deduction_settings")
                            If Not IsDBNull(dr("tax_deduction_settings")) Then tax_deduction_settings = dr("tax_deduction_settings")
                            If Not IsDBNull(dr("13month_release_date")) Then month_release_date = dr("13month_release_date")
                            If Not IsDBNull(dr("comp_deduction_settings")) Then comp_deduction_settings = dr("comp_deduction_settings")
                            If Not IsDBNull(dr("minimum_wage")) Then minimum_wage = dr("minimum_wage")
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
