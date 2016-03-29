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
    Private _overtime_regular_sh As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_regular_sh() As String
        Get
            Return _overtime_regular_sh
        End Get
        Set(ByVal Value As String)
            _overtime_regular_sh = Value
        End Set
    End Property
    Private _overtime_excess_sh As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_excess_sh() As String
        Get
            Return _overtime_excess_sh
        End Get
        Set(ByVal Value As String)
            _overtime_excess_sh = Value
        End Set
    End Property

    Private _overtime_sh_and_ot As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_sh_and_ot() As String
        Get
            Return _overtime_sh_and_ot
        End Get
        Set(ByVal Value As String)
            _overtime_sh_and_ot = Value
        End Set
    End Property
    Private _overtime_regular_lh As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_regular_lh() As String
        Get
            Return _overtime_regular_lh
        End Get
        Set(ByVal Value As String)
            _overtime_regular_lh = Value
        End Set
    End Property
    Private _overtime_excess_lh As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_excess_lh() As String
        Get
            Return _overtime_excess_lh
        End Get
        Set(ByVal Value As String)
            _overtime_excess_lh = Value
        End Set
    End Property
    Private _overtime_lh_and_ot As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_lh_and_ot() As String
        Get
            Return _overtime_lh_and_ot
        End Get
        Set(ByVal Value As String)
            _overtime_lh_and_ot = Value
        End Set
    End Property
    Private _overtime_regular_sun As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_regular_sun() As String
        Get
            Return _overtime_regular_sun
        End Get
        Set(ByVal Value As String)
            _overtime_regular_sun = Value
        End Set
    End Property
    Private _overtime_excess_sun As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_excess_sun() As String
        Get
            Return _overtime_excess_sun
        End Get
        Set(ByVal Value As String)
            _overtime_excess_sun = Value
        End Set
    End Property
    Private _overtime_regular_lh_sun As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_regular_lh_sun() As String
        Get
            Return _overtime_regular_lh_sun
        End Get
        Set(ByVal Value As String)
            _overtime_regular_lh_sun = Value
        End Set
    End Property
    Private _overtime_excess_lh_sun As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_excess_lh_sun() As String
        Get
            Return _overtime_excess_lh_sun
        End Get
        Set(ByVal Value As String)
            _overtime_excess_lh_sun = Value
        End Set
    End Property
    Private _overtime_nightdiff As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property overtime_nightdiff() As String
        Get
            Return _overtime_nightdiff
        End Get
        Set(ByVal Value As String)
            _overtime_nightdiff = Value
        End Set
    End Property
#End Region
End Class
Public Class OvertimeDB
    
   
    Friend Function OTUpdateFile(ByVal pOT As Overtime) As Overtime
        Dim cReturn As New Overtime
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE overtime ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    overtime_rate =  @overtime_rate, ")
                xSQL.AppendLine("    overtime_regular_sh =  @overtime_regular_sh, ")
                xSQL.AppendLine("    overtime_excess_sh =  @overtime_excess_sh, ")
                xSQL.AppendLine("    overtime_sh_and_ot =  @overtime_sh_and_ot, ")
                xSQL.AppendLine("    overtime_regular_lh =  @overtime_regular_lh, ")
                xSQL.AppendLine("    overtime_excess_lh =  @overtime_excess_lh, ")
                xSQL.AppendLine("    overtime_lh_and_ot =  @overtime_lh_and_ot, ")
                xSQL.AppendLine("    overtime_regular_sun =  @overtime_regular_sun, ")
                xSQL.AppendLine("    overtime_excess_sun =  @overtime_excess_sun, ")
                xSQL.AppendLine("    overtime_regular_lh_sun =  @overtime_regular_lh_sun, ")
                xSQL.AppendLine("    overtime_excess_lh_sun =  @overtime_excess_lh_sun, ")
                xSQL.AppendLine("    overtime_nightdiff =  @overtime_nightdiff ")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@overtime_rate", pOT.overtime_rate)
                commandDB1.Parameters.AddWithValue("@overtime_regular_sh", pOT.overtime_regular_sh)
                commandDB1.Parameters.AddWithValue("@overtime_excess_sh", pOT.overtime_excess_sh)
                commandDB1.Parameters.AddWithValue("@overtime_sh_and_ot", pOT.overtime_sh_and_ot)
                commandDB1.Parameters.AddWithValue("@overtime_regular_lh", pOT.overtime_regular_lh)
                commandDB1.Parameters.AddWithValue("@overtime_excess_lh", pOT.overtime_excess_lh)
                commandDB1.Parameters.AddWithValue("@overtime_lh_and_ot", pOT.overtime_lh_and_ot)
                commandDB1.Parameters.AddWithValue("@overtime_regular_sun", pOT.overtime_regular_sun)
                commandDB1.Parameters.AddWithValue("@overtime_excess_sun", pOT.overtime_excess_sun)
                commandDB1.Parameters.AddWithValue("@overtime_regular_lh_sun", pOT.overtime_regular_lh_sun)
                commandDB1.Parameters.AddWithValue("@overtime_excess_lh_sun", pOT.overtime_excess_lh_sun)
                commandDB1.Parameters.AddWithValue("@overtime_nightdiff", pOT.overtime_nightdiff)
                commandDB1.Parameters.AddWithValue("@id", pOT.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pOT
        Return cReturn
    End Function
    Friend Function GetOvertimeSetting() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    * ")
            xSQL.AppendLine("FROM overtime")
            Try
                Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                    SQLConnect.Open()
                    Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                    Dim da As New MySqlDataAdapter(SQLCommand)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    If ds.Tables.Count <> 0 Then
                        For Each dr In ds.Tables(0).Rows
                            If Not IsDBNull(dr("overtime_rate")) Then overtime_rate = dr("overtime_rate")
                            If Not IsDBNull(dr("overtime_regular_sh")) Then overtime_regular_sh = dr("overtime_regular_sh")
                            If Not IsDBNull(dr("overtime_excess_sh")) Then overtime_excess_sh = dr("overtime_excess_sh")
                            If Not IsDBNull(dr("overtime_sh_and_ot")) Then overtime_sh_and_ot = dr("overtime_sh_and_ot")
                            If Not IsDBNull(dr("overtime_regular_lh")) Then overtime_regular_lh = dr("overtime_regular_lh")
                            If Not IsDBNull(dr("overtime_excess_lh")) Then overtime_excess_lh = dr("overtime_excess_lh")
                            If Not IsDBNull(dr("overtime_lh_and_ot")) Then overtime_lh_and_ot = dr("overtime_lh_and_ot")
                            If Not IsDBNull(dr("overtime_regular_sun")) Then overtime_regular_sun = dr("overtime_regular_sun")
                            If Not IsDBNull(dr("overtime_excess_sun")) Then overtime_excess_sun = dr("overtime_excess_sun")
                            If Not IsDBNull(dr("overtime_regular_lh_sun")) Then overtime_regular_lh_sun = dr("overtime_regular_lh_sun")
                            If Not IsDBNull(dr("overtime_excess_lh_sun")) Then overtime_excess_lh_sun = dr("overtime_excess_lh_sun")
                            If Not IsDBNull(dr("overtime_nightdiff")) Then overtime_nightdiff = dr("overtime_nightdiff")
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
