Imports System.Text
Imports MySql.Data.MySqlClient
Public Class HoliTable
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
    Private _holiday_name As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property holiday_name() As String
        Get
            Return _holiday_name
        End Get
        Set(ByVal Value As String)
            _holiday_name = Value
        End Set
    End Property
    Private _holiday_date As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property holiday_date() As String
        Get
            Return _holiday_date
        End Get
        Set(ByVal Value As String)
            _holiday_date = Value
        End Set
    End Property
    Private _holiday_day As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property holiday_day() As String
        Get
            Return _holiday_day
        End Get
        Set(ByVal Value As String)
            _holiday_day = Value
        End Set
    End Property
    Private _holiday_category As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property holiday_category() As String
        Get
            Return _holiday_category
        End Get
        Set(ByVal Value As String)
            _holiday_category = Value
        End Set
    End Property
    Private _holiday_percentage As String = ""
    ''' <summary> Object Property: Type=System.String, ColumnSize=50 </summary>
    Friend Property holiday_percentage() As String
        Get
            Return _holiday_percentage
        End Get
        Set(ByVal Value As String)
            _holiday_percentage = Value
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
Public Class HolidayTableDB
    Friend Function HolTableGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    id, ")
            xSQL.AppendLine("    holiday_name, ")
            xSQL.AppendLine("    holiday_date, ")
            xSQL.AppendLine("    holiday_day, ")
            xSQL.AppendLine("    holiday_category, ")
            xSQL.AppendLine("    holiday_percentage ")
            xSQL.AppendLine("FROM holidays")
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
    Friend Function HolTableInsertFile(ByVal cItem As HoliTable) As HoliTable
        Dim cReturn As New HoliTable
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder

                xSQL.AppendLine("INSERT INTO holidays(")
                xSQL.AppendLine("    holiday_name, ")
                xSQL.AppendLine("    holiday_date, ")
                xSQL.AppendLine("    holiday_day, ")
                xSQL.AppendLine("    holiday_category, ")
                xSQL.AppendLine("    holiday_percentage, ")
                xSQL.AppendLine("    is_deleted ")
                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("    @holiday_name, ")
                xSQL.AppendLine("    @holiday_date, ")
                xSQL.AppendLine("    @holiday_day, ")
                xSQL.AppendLine("    @holiday_category, ")
                xSQL.AppendLine("    @holiday_percentage, ")
                xSQL.AppendLine("    @is_deleted ")
                xSQL.AppendLine(")")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@holiday_name", cItem.holiday_name)
                commandDB1.Parameters.AddWithValue("@holiday_date", cItem.holiday_date)
                commandDB1.Parameters.AddWithValue("@holiday_day", cItem.holiday_day)
                commandDB1.Parameters.AddWithValue("@holiday_category", cItem.holiday_category)
                commandDB1.Parameters.AddWithValue("@holiday_percentage", cItem.holiday_percentage)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function JobTitleUpdateFile(ByVal pHT As HoliTable) As HoliTable
        Dim cReturn As New HoliTable
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("UPDATE holidays ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    holiday_name = @holiday_name, ")
                xSQL.AppendLine("    holiday_date = @holiday_date, ")
                xSQL.AppendLine("    holiday_day = @holiday_day, ")
                xSQL.AppendLine("    holiday_category = @holiday_category, ")
                xSQL.AppendLine("    holiday_percentage = @holiday_percentage, ")
                xSQL.AppendLine("    is_deleted  = @is_deleted")
                xSQL.AppendLine("WHERE id = @id")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@holiday_name", pHT.holiday_name)
                commandDB1.Parameters.AddWithValue("@holiday_date", pHT.holiday_date)
                commandDB1.Parameters.AddWithValue("@holiday_day", pHT.holiday_day)
                commandDB1.Parameters.AddWithValue("@holiday_category", pHT.holiday_category)
                commandDB1.Parameters.AddWithValue("@holiday_percentage", pHT.holiday_percentage)
                commandDB1.Parameters.AddWithValue("@is_deleted", pHT.is_deleted)
                commandDB1.Parameters.AddWithValue("@id", pHT.id)
                commandDB1.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = pHT
        Return cReturn
    End Function
End Class
