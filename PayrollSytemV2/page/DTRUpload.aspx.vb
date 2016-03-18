Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class DTRUpload
    Inherits System.Web.UI.Page
    Dim gloTimeInC As String
    Dim gloTimeOutC As String
    Dim gloShiftC As String
    Dim gloDailyRate As String
    Dim gloHourRate As String

    Dim xlApp As Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        'Release an automation object
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

        If UploadDTR.HasFile Then
            Dim FileName As String = Path.GetFileName(UploadDTR.PostedFile.FileName)
            Dim Extension As String = Path.GetExtension(UploadDTR.PostedFile.FileName)
            ' Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")

            Dim FilePath As String = Server.MapPath(FileName)
            UploadDTR.SaveAs(FilePath)
            Import_To_Grid(FilePath)
        End If

    End Sub
    Private Sub Import_To_Grid(ByVal FilePath As String)

        Dim dt As New DataTable
        Dim dr As DataRow
        'Dim file As String

        dt.Columns.Add(New DataColumn("Employee Code", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Employee Name", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Date", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("In Time", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Out Time", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Late (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Late Amount", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime Amount", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Undertime (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Undertime Amount", System.Type.GetType("System.String")))
        'dt.Columns.Add(New DataColumn("Note", System.Type.GetType("System.String")))


        'For Each file In FilePath
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(FilePath)
        xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

        GetGlobalData(xlWorkSheet.Cells(3, 1).value)

        Dim infiniteLoop As Boolean = False
        Dim i As Integer = 3

        Do While infiniteLoop = False
            If Len(xlWorkSheet.Cells(i, 1).value) > 0 Then

                Dim LateString() As String = Nothing
                Dim OvertimeString() As String = Nothing
                Dim UndertimeString() As String = Nothing
                Dim vTimeIN As String
                Dim vTimeOut As String
                Dim vOThrs As String
                Dim vOTName As String

                dr = dt.NewRow()
                dr(0) = xlWorkSheet.Cells(i, 1).value
                dr(1) = xlWorkSheet.Cells(i, 2).value
                dr(2) = Format(xlWorkSheet.Cells(i, 3).value, "yyyy-MM-dd")
                dr(3) = Format(xlWorkSheet.Cells(i, 4).value, "hh:mm:ss tt")
                dr(4) = Format(xlWorkSheet.Cells(i, 5).value, "hh:mm:ss tt")
                dr(5) = xlWorkSheet.Cells(i, 6).value
                dr(6) = xlWorkSheet.Cells(i, 7).value

                vTimeIN = Format(xlWorkSheet.Cells(i, 4).value, "hh:mm:ss tt")
                vTimeOut = Format(xlWorkSheet.Cells(i, 5).value, "hh:mm:ss tt")
                vOThrs = xlWorkSheet.Cells(i, 6).value
                vOTName = xlWorkSheet.Cells(i, 7).value

                'Late Computation
                LateString = LateCompute(vTimeIN)
                dr(7) = LateString(0).ToString
                dr(8) = LateString(1).ToString

                'Overtime Computation
                OvertimeString = OvertimeCompute(vOTName, vOThrs)
                dr(9) = OvertimeString(0).ToString
                dr(10) = OvertimeString(1).ToString

                'Undertime Computation
                UndertimeString = UndertimeCompute(vTimeOut)
                dr(11) = UndertimeString(0).ToString
                dr(12) = UndertimeString(1).ToString

                dt.Rows.Add(dr)
                i = i + 1

            Else
                infiniteLoop = True
            End If
        Loop
        gvDTR.DataSource = dt
        gvDTR.DataBind()


        xlWorkBook.Close()
        xlApp.Quit()
        Marshal.ReleaseComObject(xlApp)
        xlApp = Nothing
        'Next file




    End Sub
    Friend Sub GetGlobalData(ByVal xCode As String)
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As String
                xSQL = "SELECT daily_rate, hour_rate, def_time_in, def_time_out, shift_name" & _
                        " FROM employee INNER JOIN shifts ON employee.def_shift_id = shifts.id WHERE code = @code"
                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@code", xCode)
                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                For Each dr In ds.Tables(0).Rows
                    gloTimeInC = dr("def_time_in").ToString
                    gloTimeOutC = dr("def_time_out").ToString
                    gloShiftC = dr("shift_name").ToString
                    gloDailyRate = dr("daily_rate").ToString
                    gloHourRate = dr("hour_rate").ToString
                    'gloNightDiffRate = dr("emp_nightdiffrate").ToString
                Next
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function LateCompute(ByVal x As String) As String()

        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As New StringBuilder
                xSQL.AppendLine("SELECT lu_from, lu_to,lu_percentage, late_undertime.is_deleted, lu_type, shifts.shift_name ")
                xSQL.AppendLine("FROM late_undertime INNER JOIN shifts ON late_undertime.shift_id = shifts.id ")
                xSQL.AppendLine("WHERE  lu_from <= @late_time")
                xSQL.AppendLine("       and lu_to >= @late_time")
                xSQL.AppendLine("       and shifts.shift_name = @late_shift")
                xSQL.AppendLine("       and lu_type = 'L'")
                xSQL.AppendLine("       and late_undertime.is_deleted = '1'")

                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@late_time", x)
                SQLCommand.Parameters.AddWithValue("@late_shift", gloShiftC)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                LateCompute = New String() {"0", "0"}
                For Each dr In ds.Tables(0).Rows
                    LateCompute = New String() {dr("lu_percentage"), ModC(dr("lu_percentage") * CDbl(gloHourRate))}
                Next
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function OvertimeCompute(ByVal OTName As String, OThrs As String) As String()

        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As New StringBuilder
                xSQL.AppendLine("SELECT ")
                xSQL.AppendLine("    id, ")
                xSQL.AppendLine("    overtime_name, ")
                xSQL.AppendLine("    overtime_rate ")
                xSQL.AppendLine("FROM overtime")
                xSQL.AppendLine("WHERE is_deleted = '1' and overtime_name = @overtime_name ")


                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@overtime_name", OTName)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                OvertimeCompute = New String() {"0", "0"}
                For Each dr In ds.Tables(0).Rows
                    OvertimeCompute = New String() {dr("overtime_rate"), ModC(ModC(dr("overtime_rate") * CDbl(gloHourRate))) * CDbl(OThrs)}
                Next
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function UndertimeCompute(ByVal x As String) As String()

        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As New StringBuilder
                xSQL.AppendLine("SELECT lu_from, lu_to,lu_percentage, late_undertime.is_deleted, lu_type, shifts.shift_name ")
                xSQL.AppendLine("FROM late_undertime INNER JOIN shifts ON late_undertime.shift_id = shifts.id ")
                xSQL.AppendLine("WHERE  lu_from <= @late_time")
                xSQL.AppendLine("       and lu_to >= @late_time")
                xSQL.AppendLine("       and shifts.shift_name = @late_shift")
                xSQL.AppendLine("       and lu_type = 'U'")
                xSQL.AppendLine("       and late_undertime.is_deleted = '1'")

                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@late_time", x)
                SQLCommand.Parameters.AddWithValue("@late_shift", gloShiftC)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                UndertimeCompute = New String() {"0", "0"}
                For Each dr In ds.Tables(0).Rows
                    UndertimeCompute = New String() {dr("lu_percentage"), ModC(dr("lu_percentage") * CDbl(gloHourRate))}
                Next
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Friend Function ModC(ByVal x As Double) As Double
        ModC = Format(x, "0.00")
    End Function
End Class