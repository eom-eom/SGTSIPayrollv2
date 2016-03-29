Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Text
Imports MySql.Data.MySqlClient


Public Class DTRUpload
    Inherits System.Web.UI.Page
    Dim gloTimeIn As String
    Dim gloTimeOut As String
    Dim gloShift As String
    Dim gloTimeInC As String
    Dim gloTimeOutC As String
    Dim gloShiftC As String
    Dim gloDailyRate As String
    Dim gloHourRate As String
    Dim gloNightDiff As String

    Dim xlApp As Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        Dim cdb As New OvertimeDB
        cdb.GetOvertimeSetting()

        lblORate.Text = overtime_rate
        lblORegSH.Text = overtime_regular_sh
        lblOExSH.Text = overtime_excess_sh
        lblOSHandO.Text = overtime_sh_and_ot
        lblORegLH.Text = overtime_regular_lh
        lblOExLH.Text = overtime_excess_lh
        lblOLHandOT.Text = overtime_lh_and_ot
        lblORegSun.Text = overtime_regular_sun
        lblOExSun.Text = overtime_excess_sun
        lblORegLHSun.Text = overtime_regular_lh_sun
        lblOExLHSun.Text = overtime_excess_lh_sun
        lblONightDiff.Text = overtime_nightdiff
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
        'dt.Columns.Add(New DataColumn("Late (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Late Amount", System.Type.GetType("System.String")))
        ' dt.Columns.Add(New DataColumn("Undertime (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Undertime Amount", System.Type.GetType("System.String")))
        'dt.Columns.Add(New DataColumn("Overtime (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime Amount", System.Type.GetType("System.String")))
        'dt.Columns.Add(New DataColumn("Overtime Special Holiday (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime Special Holiday Amount", System.Type.GetType("System.String")))
        'dt.Columns.Add(New DataColumn("Special Holiday (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Special Holiday Amount", System.Type.GetType("System.String")))
        'dt.Columns.Add(New DataColumn("Legal Holiday (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime Legal Holiday Amount", System.Type.GetType("System.String")))
        'dt.Columns.Add(New DataColumn("Legal Holiday (%)", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Legal Holiday Amount", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime Sunday", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime Excess Sunday", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime Legal Holiday Sunday", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime Excess Legal Holiday Sunday", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime Night Differential", System.Type.GetType("System.String")))

        'For Each file In FilePath
        Dim DTRSqlTran As MySqlTransaction = Nothing
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(FilePath)
        xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

        GetGlobalData(xlWorkSheet.Cells(2, 1).value)

        Dim infiniteLoop As Boolean = False
        Dim i As Integer = 2

        Do While infiniteLoop = False
            If Len(xlWorkSheet.Cells(i, 1).value) > 0 Then
                gloShift = gloShiftC
                gloTimeIn = gloTimeInC
                gloTimeOut = gloTimeOutC
                CheckShift(xlWorkSheet.Cells(i, 1).value, Format(xlWorkSheet.Cells(i, 3).value, "yyyy-MM-dd"))

                Dim LateString() As String = Nothing
                Dim OvertimeString() As String = Nothing
                Dim SHOvertimeString() As String = Nothing
                Dim LHOvertimeString() As String = Nothing
                Dim UndertimeString() As String = Nothing
                Dim LegalHolidayString() As String = Nothing
                Dim SpecialHolidayString() As String = Nothing
                Dim OvertimeRegSunString() As String = Nothing
                Dim OvertimeExSunString() As String = Nothing
                Dim OvertimeLHSunString() As String = Nothing
                Dim OvertimeLHExSunString() As String = Nothing
                Dim OvertimeNightDiffString() As String = Nothing
                Dim vDate As String
                Dim vTimeIN As String
                Dim vTimeOut As String
                Dim vOThrs As String


                dr = dt.NewRow()
                dr(0) = xlWorkSheet.Cells(i, 1).value
                dr(1) = xlWorkSheet.Cells(i, 2).value
                dr(2) = Format(xlWorkSheet.Cells(i, 3).value, "yyyy-MM-dd")
                dr(3) = Format(xlWorkSheet.Cells(i, 4).value, "hh:mm:ss tt")
                dr(4) = Format(xlWorkSheet.Cells(i, 5).value, "hh:mm:ss tt")
                dr(5) = xlWorkSheet.Cells(i, 6).value
                dr(6) = xlWorkSheet.Cells(i, 7).value

                vDate = Format(xlWorkSheet.Cells(i, 3).value, "yyyy-MM-dd")
                vTimeIN = Format(xlWorkSheet.Cells(i, 4).value, "hh:mm:ss tt")
                vTimeOut = Format(xlWorkSheet.Cells(i, 5).value, "hh:mm:ss tt")
                vOThrs = xlWorkSheet.Cells(i, 6).value

                'Late Computation
                LateString = LateCompute(vTimeIN)
                'dr(7) = LateString(0).ToString
                dr(7) = LateString(1).ToString

                'Undertime Computation
                UndertimeString = UndertimeCompute(vTimeOut)
                'dr(9) = UndertimeString(0).ToString
                dr(8) = UndertimeString(1).ToString

                'Overtime Computation
                OvertimeString = RegularOvertimeCompute(vDate, vOThrs)
                'dr(11) = OvertimeString(0).ToString
                dr(9) = OvertimeString(1).ToString
                '-------------------------------------------------------------------------------------'
                'Overtime SH Computation
                SHOvertimeString = SHOvertimeCompute(vDate, vOThrs)
                ' dr(13) = SHOvertimeString(0).ToString
                dr(10) = SHOvertimeString(1).ToString

                'Special Holiday Computation
                SpecialHolidayString = SpecialHolidayCompute(vDate, vOThrs)
                'dr(17) = SpecialHolidayString(0).ToString
                dr(11) = SpecialHolidayString(1).ToString

                'Overtime LH Computationz
                LHOvertimeString = LHOvertimeCompute(vDate, vOThrs)
                'dr(15) = LegalHolidayString(0).ToString
                dr(12) = LHOvertimeString(1).ToString

                'Legal Holiday Computation
                LegalHolidayString = LegalHolidayCompute(vDate, vOThrs)
                'dr(15) = LegalHolidayString(0).ToString
                dr(13) = LegalHolidayString(1).ToString

                'Overtime Sunday Computation
                OvertimeRegSunString = RegularOvertimeComputeSun(vDate, vOThrs)
                'dr(15) = LegalHolidayString(0).ToString
                dr(14) = OvertimeRegSunString(1).ToString

                'Overtime Sunday Excess Computation
                OvertimeExSunString = ExcessOvertimeComputeSun(vDate, vOThrs)
                dr(15) = OvertimeExSunString(1).ToString

                'Overtime Legal Holiday Sunday Computation
                OvertimeLHSunString = LHOvertimeComputeSun(vDate, vOThrs)
                dr(16) = OvertimeLHSunString(1).ToString

                'Overtime Excess Legal Holiday Sunday Computation
                OvertimeLHExSunString = LHExOvertimeComputeSun(vDate, vOThrs)
                dr(17) = OvertimeLHExSunString(1).ToString

                'Overtime Excess Legal Holiday Sunday Computation
                OvertimeNightDiffString = RegularOvertimeComputeNightDiff(vDate, vOThrs)
                dr(18) = OvertimeNightDiffString(1).ToString


                dt.Rows.Add(dr)

                If DTRCheck(vDate, xlWorkSheet.Cells(i, 1).value) = False Then
                    DTRDelete(vDate, xlWorkSheet.Cells(i, 1).value)
                    Try
                        Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                            SQLConnect.Open()
                            Dim xSQL As New StringBuilder
                            xSQL.AppendLine("INSERT INTO DTRCompute(")
                            xSQL.AppendLine("    emp_code, ")
                            xSQL.AppendLine("    dtrc_dailyrate, ")
                            xSQL.AppendLine("    dtrc_hourrate, ")
                            xSQL.AppendLine("    dtrc_nightdiffrate, ")
                            xSQL.AppendLine("    dtrc_date, ")
                            xSQL.AppendLine("    dtrc_timein, ")
                            xSQL.AppendLine("    dtrc_timeout, ")
                            xSQL.AppendLine("    overtime_hours, ")
                            xSQL.AppendLine("    status, ")
                            xSQL.AppendLine("    late_perc, ")
                            xSQL.AppendLine("    late_amt, ")
                            xSQL.AppendLine("    ut_perc, ")
                            xSQL.AppendLine("    ut_amt, ")
                            xSQL.AppendLine("    ot_rate, ")
                            xSQL.AppendLine("    ot_amt, ")
                            xSQL.AppendLine("    ot_sh_rate, ")
                            xSQL.AppendLine("    ot_sh_amt, ")
                            xSQL.AppendLine("    sh_rate, ")
                            xSQL.AppendLine("    sh_amount, ")
                            xSQL.AppendLine("    ot_lh_rate, ")
                            xSQL.AppendLine("    ot_lh_amt, ")
                            xSQL.AppendLine("    lh_rate, ")
                            xSQL.AppendLine("    lh_amt, ")
                            xSQL.AppendLine("    ot_sun_rate, ")
                            xSQL.AppendLine("    ot_sun_amt, ")
                            xSQL.AppendLine("    ot_excess_sun_rate, ")
                            xSQL.AppendLine("    ot_excess_sun_amt, ")
                            xSQL.AppendLine("    ot_lh_sun_rate, ")
                            xSQL.AppendLine("    ot_lh_sun_amt, ")
                            xSQL.AppendLine("    ot_lh_excess_sun_rate, ")
                            xSQL.AppendLine("    ot_lh_excess_sun_amt, ")
                            xSQL.AppendLine("    ot_nightdiff_rate, ")
                            xSQL.AppendLine("    ot_nightdiff_amt, ")
                            xSQL.AppendLine("    is_deleted ")
                            xSQL.AppendLine(") ")
                            xSQL.AppendLine("VALUES( ")
                            xSQL.AppendLine("    @emp_code, ")
                            xSQL.AppendLine("    @daily_rate, ")
                            xSQL.AppendLine("    @hour_rate, ")
                            xSQL.AppendLine("    @night_diff_rate, ")
                            xSQL.AppendLine("    @dtrc_date, ")
                            xSQL.AppendLine("    @dtrc_timein, ")
                            xSQL.AppendLine("    @dtrc_timeout, ")
                            xSQL.AppendLine("    @overtime_hours, ")
                            xSQL.AppendLine("    @status, ")
                            xSQL.AppendLine("    @late_perc, ")
                            xSQL.AppendLine("    @late_amt, ")
                            xSQL.AppendLine("    @ut_perc, ")
                            xSQL.AppendLine("    @ut_amt, ")
                            xSQL.AppendLine("    @ot_rate, ")
                            xSQL.AppendLine("    @ot_amt, ")
                            xSQL.AppendLine("    @ot_sh_rate, ")
                            xSQL.AppendLine("    @ot_sh_amt, ")
                            xSQL.AppendLine("    @sh_rate, ")
                            xSQL.AppendLine("    @sh_amount, ")
                            xSQL.AppendLine("    @ot_lh_rate, ")
                            xSQL.AppendLine("    @ot_lh_amt, ")
                            xSQL.AppendLine("    @lh_rate, ")
                            xSQL.AppendLine("    @lh_amt, ")
                            xSQL.AppendLine("    @ot_sun_rate, ")
                            xSQL.AppendLine("    @ot_sun_amt, ")
                            xSQL.AppendLine("    @ot_excess_sun_rate, ")
                            xSQL.AppendLine("    @ot_excess_sun_amt, ")
                            xSQL.AppendLine("    @ot_lh_sun_rate, ")
                            xSQL.AppendLine("    @ot_lh_sun_amt, ")
                            xSQL.AppendLine("    @ot_lh_excess_sun_rate, ")
                            xSQL.AppendLine("    @ot_lh_excess_sun_amt, ")
                            xSQL.AppendLine("    @ot_nightdiff_rate, ")
                            xSQL.AppendLine("    @ot_nightdiff_amt, ")
                            xSQL.AppendLine("    1 ")
                            xSQL.AppendLine(")")

                            Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                            DTRSqlTran = SQLConnect.BeginTransaction()
                            commandDB1.Transaction = DTRSqlTran
                            commandDB1.Parameters.AddWithValue("@emp_code", CStr(xlWorkSheet.Cells(i, 1).value.ToString))
                            commandDB1.Parameters.AddWithValue("@daily_rate", gloDailyRate)
                            commandDB1.Parameters.AddWithValue("@hour_rate", gloHourRate)
                            commandDB1.Parameters.AddWithValue("@night_diff_rate", gloNightDiff)
                            commandDB1.Parameters.AddWithValue("@dtrc_date", vDate)
                            commandDB1.Parameters.AddWithValue("@dtrc_timein", vTimeIN)
                            commandDB1.Parameters.AddWithValue("@dtrc_timeout", vTimeOut)
                            commandDB1.Parameters.AddWithValue("@overtime_hours", xlWorkSheet.Cells(i, 6).value)
                            commandDB1.Parameters.AddWithValue("@status", xlWorkSheet.Cells(i, 7).value)
                            commandDB1.Parameters.AddWithValue("@late_perc", LateString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@late_amt", LateString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@ut_perc", UndertimeString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@ut_amt", UndertimeString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_rate", OvertimeString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_amt", OvertimeString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_sh_rate", SHOvertimeString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_sh_amt", SHOvertimeString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@sh_rate", SpecialHolidayString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@sh_amount", SpecialHolidayString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_lh_rate", LHOvertimeString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_lh_amt", LHOvertimeString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@lh_rate", LegalHolidayString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@lh_amt", LegalHolidayString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_sun_rate", OvertimeRegSunString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_sun_amt", OvertimeRegSunString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_excess_sun_rate", OvertimeExSunString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_excess_sun_amt", OvertimeExSunString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_lh_sun_rate", OvertimeLHSunString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_lh_sun_amt", OvertimeLHSunString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_lh_excess_sun_rate", OvertimeLHExSunString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_lh_excess_sun_amt", OvertimeLHExSunString(1).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_nightdiff_rate", OvertimeNightDiffString(0).ToString)
                            commandDB1.Parameters.AddWithValue("@ot_nightdiff_amt", OvertimeNightDiffString(1).ToString)
                            commandDB1.ExecuteNonQuery()
                            DTRSqlTran.Commit()
                        End Using
                    Catch ex As Exception
                        Throw ex
                        DTRSqlTran.Rollback()
                    End Try
                End If

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
                xSQL = "SELECT daily_rate, hour_rate, night_rate, def_time_in, def_time_out, shift_name" & _
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
                    gloNightDiff = dr("night_rate").ToString
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
                xSQL.AppendLine("       and shifts.shift_name = @shift_name")
                xSQL.AppendLine("       and lu_type = 'L'")
                xSQL.AppendLine("       and late_undertime.is_deleted = '1'")

                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@late_time", x)
                SQLCommand.Parameters.AddWithValue("@shift_name", gloShift)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                LateCompute = New String() {"0", "0"}

                For Each dr In ds.Tables(0).Rows
                    LateCompute = New String() {dr("lu_percentage"), ModC(dr("lu_percentage") * IIf(gloShift = "Day Shift", CDbl(gloHourRate), CDbl(gloNightDiff)))}

                Next

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Dim ExcessHours As Double = 0
    Private Function SHOvertimeCompute(HoliDate As String, OThrs As String) As String()
        SHOvertimeCompute = New String() {"0", "0"}
        Dim HolidayCategory As String = HolidayCheck(HoliDate)

        If OThrs >= 8 Then
            ExcessHours = OThrs - 8
        End If

        If HolidayCategory = "Special Holiday" And ExcessHours > 0 Then
            Dim RegSHAmt As Double = ModC(lblORegSH.Text) * CDbl(gloDailyRate)
            Dim ExSHAmt As Double = ModC(ExcessHours * CDbl(gloHourRate)) * ModC(lblOExSH.Text)
            Dim OExSHAmt As Double = RegSHAmt + ExSHAmt
            SHOvertimeCompute = New String() {ModC(lblOExSH.Text), ModC(OExSHAmt)}
            ExcessHours = 0
   
        End If


    End Function
    Private Function LHOvertimeCompute(HoliDate As String, OThrs As String) As String()
        LHOvertimeCompute = New String() {"0", "0"}
        Dim HolidayCategory As String = HolidayCheck(HoliDate)
        Dim dayOfWeek As String = Format(CDate(HoliDate), "dddd")
        If OThrs >= 8 Then
            ExcessHours = OThrs - 8
        End If

        If HolidayCategory = "Legal Holiday" And ExcessHours > 0 And Not dayOfWeek = "Sunday" Then
            Dim RegLHAmt As Double = ModC(lblORegLH.Text) * CDbl(gloDailyRate)
            Dim ExLHAmt As Double = ModC(ExcessHours * CDbl(gloHourRate)) * ModC(lblOExLH.Text)
            Dim OExLHAmt As Double = RegLHAmt + ExLHAmt
            LHOvertimeCompute = New String() {ModC(lblOExSH.Text), ModC(OExLHAmt)}
            ExcessHours = 0
        End If


    End Function
    Private Function ExcessOvertimeComputeSun(ThisDate As String, OThrs As String) As String()
        ExcessOvertimeComputeSun = New String() {"0", "0"}
        Dim dayOfWeek As String = Format(CDate(ThisDate), "dddd")
        Dim HolidayCategory As String = HolidayCheck(ThisDate)

        If OThrs >= 8 Then
            ExcessHours = OThrs - 8
        End If

        If dayOfWeek = "Sunday" And ExcessHours > 0 And Not HolidayCategory = "Legal Holiday" Then
            Dim SunAmt As Double = ModC(lblORegSun.Text) * CDbl(gloDailyRate)
            Dim ExSunAmt As Double = ModC(ExcessHours * CDbl(gloHourRate)) * ModC(lblOExSun.Text)
            Dim OExSunAmt As Double = SunAmt + ExSunAmt
            ExcessOvertimeComputeSun = New String() {ModC(lblOExSun.Text), ModC(OExSunAmt)}
            ExcessHours = 0
        End If

    End Function
    Private Function RegularOvertimeCompute(HoliDate As String, OThrs As String) As String()
        RegularOvertimeCompute = New String() {"0", "0"}
        Dim HolidayCategory As String = HolidayCheck(HoliDate)
        Dim dayOfWeek As String = Format(CDate(HoliDate), "dddd")

        If Not gloShiftC = "Night Shift" And Not gloShiftC = "" And Not HolidayCategory = "Special Holiday" And Not HolidayCategory = "Legal Holiday" And Not dayOfWeek = "Sunday" Then
            ' RegularOvertimeCompute = New String() {ModC(lblORate.Text), ModC(ModC(lblORate.Text) * CDbl(gloHourRate)) * CDbl(OThrs)}
            RegularOvertimeCompute = New String() {ModC(lblORate.Text), ModC(ModC(lblORate.Text) * CDbl(gloHourRate)) * CDbl(OThrs)}
        End If

    End Function
    Private Function RegularOvertimeComputeNightDiff(HoliDate As String, OThrs As String) As String()
        RegularOvertimeComputeNightDiff = New String() {"0", "0"}
        Dim HolidayCategory As String = HolidayCheck(HoliDate)
        Dim dayOfWeek As String = Format(CDate(HoliDate), "dddd")

        If gloShiftC = "Night Shift" Or gloShiftC = "" And Not HolidayCategory = "Special Holiday" And Not HolidayCategory = "Legal Holiday" And Not dayOfWeek = "Sunday" Then
            ' RegularOvertimeCompute = New String() {ModC(lblORate.Text), ModC(ModC(lblORate.Text) * CDbl(gloHourRate)) * CDbl(OThrs)}
            RegularOvertimeComputeNightDiff = New String() {ModC(lblONightDiff.Text), ModC(ModC(lblONightDiff.Text) * CDbl(gloNightDiff)) * CDbl(OThrs)}
        End If

    End Function
    Private Function RegularOvertimeComputeSun(ThisDate As String, OThrs As String) As String()
        RegularOvertimeComputeSun = New String() {"0", "0"}
        Dim dayOfWeek As String = Format(CDate(ThisDate), "dddd")
        Dim HolidayCategory As String = HolidayCheck(ThisDate)

        If OThrs >= 8 Then
            ExcessHours = OThrs - 8
        End If

        If dayOfWeek = "Sunday" And OThrs = 0 And Not HolidayCategory = "Legal Holiday" Then
            RegularOvertimeComputeSun = New String() {ModC(lblORegSun.Text), ModC(ModC(lblORegSun.Text) * CDbl(gloDailyRate))}
        ElseIf dayOfWeek = "Sunday" And Not OThrs = 0 And ExcessHours <= 0 And Not HolidayCategory = "Legal Holiday" Then
            RegularOvertimeComputeSun = New String() {ModC(lblORegSun.Text), ModC(ModC(lblORegSun.Text) * CDbl(gloHourRate)) * CDbl(OThrs)}
        End If

    End Function
    Private Function LHOvertimeComputeSun(HoliDate As String, OThrs As String) As String()
        LHOvertimeComputeSun = New String() {"0", "0"}
        Dim dayOfWeek As String = Format(CDate(HoliDate), "dddd")
        Dim HolidayCategory As String = HolidayCheck(HoliDate)

        If OThrs >= 8 Then
            ExcessHours = OThrs - 8
        End If

        If dayOfWeek = "Sunday" And HolidayCategory = "Legal Holiday" And OThrs = 0 Then
            LHOvertimeComputeSun = New String() {ModC(lblORegLHSun.Text), ModC(ModC(lblORegLHSun.Text) * CDbl(gloDailyRate))}
        ElseIf dayOfWeek = "Sunday" And HolidayCategory = "Legal Holiday" And Not OThrs = 0 And ExcessHours <= 0 Then
            LHOvertimeComputeSun = New String() {ModC(lblORegLHSun.Text), ModC(ModC(lblORegLHSun.Text) * CDbl(gloHourRate)) * CDbl(OThrs)}
        End If

    End Function
    Private Function LHExOvertimeComputeSun(HoliDate As String, OThrs As String) As String()
        LHExOvertimeComputeSun = New String() {"0", "0"}
        Dim dayOfWeek As String = Format(CDate(HoliDate), "dddd")
        Dim HolidayCategory As String = HolidayCheck(HoliDate)

        If OThrs >= 8 Then
            ExcessHours = OThrs - 8
        End If

        If dayOfWeek = "Sunday" And HolidayCategory = "Legal Holiday" And ExcessHours > 0 Then
            Dim LHExSunAmt As Double = ModC(lblORegLHSun.Text) * CDbl(gloDailyRate)
            Dim OLHExSunAmt As Double = ModC(ExcessHours * CDbl(gloHourRate)) * ModC(lblOExLHSun.Text)
            Dim OExLHSunAmt As Double = LHExSunAmt + OLHExSunAmt
            LHExOvertimeComputeSun = New String() {ModC(lblOExLHSun.Text), ModC(OExLHSunAmt)}
            ExcessHours = 0

        End If

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
    Private Function DTRCheck(ByVal xDate As String, ByVal xEmpID As String) As Boolean
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As String
                xSQL = "Select emp_code from dtrcompute WHERE dtrc_date = @xDate and emp_code = @xEmpID"
                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@xDate", xDate)
                SQLCommand.Parameters.AddWithValue("@xEmpID", xEmpID)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                DTRCheck = False
                For Each dr In ds.Tables(0).Rows
                    DTRCheck = True
                Next
            End Using
        Catch ex As Exception
            DTRCheck = False
            Throw ex
        End Try
    End Function
    Private Sub DTRDelete(ByVal xDate As String, ByVal xEmpID As String)
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As String
                xSQL = "Delete From dtrcompute WHERE dtrc_date = @xDate and emp_code = @xEmpID"
                Dim SQLCommand1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand1.Parameters.AddWithValue("@xDate", xDate)
                SQLCommand1.Parameters.AddWithValue("@xEmpID", xEmpID)
                SQLCommand1.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function LegalHolidayCompute(ByVal HoliDate As String, OThrs As String) As String()
        LegalHolidayCompute = New String() {"0", "0"}
        Dim dayOfWeek As String = Format(CDate(HoliDate), "dddd")
        Dim HolidayCategory As String = HolidayCheck(HoliDate)

        If OThrs >= 8 Then
            ExcessHours = OThrs - 8
        End If

        If HolidayCategory = "Legal Holiday" And OThrs = 0 And Not dayOfWeek = "Sunday" Then
            Dim RegLHAmt As Double = ModC(lblORegLH.Text) * CDbl(gloDailyRate)
            LegalHolidayCompute = New String() {ModC(lblORegLH.Text), ModC(RegLHAmt)}
        ElseIf HolidayCategory = "Legal Holiday" And Not OThrs = 0 And ExcessHours <= 0 And Not dayOfWeek = "Sunday" Then
            Dim RegLHAmt As Double = ModC(ModC(lblORegLH.Text) * CDbl(gloHourRate) * ModC(OThrs))
            LegalHolidayCompute = New String() {ModC(lblORegLH.Text), ModC(RegLHAmt)}
        End If
        ExcessHours = 0
    End Function
    Private Function SpecialHolidayCompute(ByVal HoliDate As String, OThrs As String) As String()
        SpecialHolidayCompute = New String() {"0", "0"}

        Dim HolidayCategory As String = HolidayCheck(HoliDate)

        If OThrs >= 8 Then
            ExcessHours = OThrs - 8
        End If

        If HolidayCategory = "Special Holiday" And OThrs = 0 Then
            Dim RegSHAmt As Double = ModC(lblORegSH.Text) * CDbl(gloDailyRate)
            SpecialHolidayCompute = New String() {ModC(lblORegSH.Text), ModC(RegSHAmt)}

        ElseIf HolidayCategory = "Special Holiday" And Not OThrs = 0 And ExcessHours <= 0 Then
            Dim RegSHAmt As Double = ModC(ModC(lblORegSH.Text) * CDbl(gloHourRate) * OThrs)
            SpecialHolidayCompute = New String() {ModC(lblORegSH.Text), ModC(RegSHAmt)}
    
        End If
        ExcessHours = 0
    End Function
  
    Private Function HolidayCheck(ByVal HoliDate As String) As String

        Try
            Dim holiCat As String = ""
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As New StringBuilder
                xSQL.AppendLine("SELECT ")
                xSQL.AppendLine("    holiday_date, ")
                xSQL.AppendLine("    holiday_day, ")
                xSQL.AppendLine("    holiday_category ")
                xSQL.AppendLine("FROM holidays")
                xSQL.AppendLine("WHERE is_deleted = '1' and holiday_date = @holiday_date ")


                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@holiday_date", HoliDate)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)

                For Each dr In ds.Tables(0).Rows
                    holiCat = dr("holiday_category")
                Next
                Return holiCat
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Sub CheckShift(ByVal emp_code As String, ByVal dtr_date As String)
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As New StringBuilder
                xSQL.AppendLine("SELECT")
                xSQL.AppendLine("employee_shift.emp_id,")
                xSQL.AppendLine("Shifts.shift_name,")
                xSQL.AppendLine("employee_shift.date_from,")
                xSQL.AppendLine("employee_shift.date_to,")
                xSQL.AppendLine("Shifts.time_in,")
                xSQL.AppendLine("Shifts.time_out,")
                xSQL.AppendLine("employee_shift.is_deleted")
                xSQL.AppendLine("FROM")
                xSQL.AppendLine("Shifts")
                xSQL.AppendLine("INNER JOIN employee_shift ON employee_shift.shift_id = shifts.id")
                xSQL.AppendLine("WHERE emp_id = @emp_code ")
                xSQL.AppendLine("       AND date_from<= @dtr_date")
                xSQL.AppendLine("       and date_to >= @dtr_date")
                xSQL.AppendLine("       and employee_shift.is_deleted = '1'")

                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@emp_code", emp_code)
                SQLCommand.Parameters.AddWithValue("@dtr_date", dtr_date)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                gloShiftC = ""
                For Each dr In ds.Tables(0).Rows
                    If Len(dr("shift_name")) > 0 Then
                        gloShiftC = dr("shift_name")
                        gloTimeInC = dr("time_in")
                        gloTimeOutC = dr("time_out")
                    End If
                Next
                If Len(gloShiftC) > 0 Then
                    gloShiftC = ""
                Else
                    gloShiftC = gloShift
                    gloTimeInC = gloTimeIn
                    gloTimeOutC = gloTimeOut
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Friend Function ModC(ByVal x As Double) As Double
        ModC = Format(x, "0.00")
    End Function
End Class