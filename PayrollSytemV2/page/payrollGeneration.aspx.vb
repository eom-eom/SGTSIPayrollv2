Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class payroll
    Inherits System.Web.UI.Page
    Dim ActionTax As Boolean
    Dim PayrollTransaction As MySqlTransaction = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub txtFrom_TextChanged(sender As Object, e As EventArgs) Handles txtFrom.TextChanged
        If IsPostBack Then
            lblPayrollCode.Text = Replace("P" & txtFrom.Text & TxtTo.Text, "-", "")
        End If

    End Sub

    Protected Sub TxtTo_TextChanged(sender As Object, e As EventArgs) Handles TxtTo.TextChanged

        If IsPostBack Then
            lblPayrollCode.Text = Replace("P" & txtFrom.Text & TxtTo.Text, "-", "")
        End If

    End Sub
    Friend Function ComputeGDeduction(ByVal xEmpCode As String, ByVal xBasicPay As Double, ByVal xGD_Name As String) As String
        ComputeGDeduction = 0
        If gov_deduction_settings = "End Month" Then
            If CInt(DateTime.Parse(TxtTo.Text).Day) >= 31 Or CInt(DateTime.Parse(TxtTo.Text).Day) <= 26 Then

            Else
                ComputeGDeduction = 0
                Exit Function
            End If
        Else
            If CInt(DateTime.Parse(TxtTo.Text).Day) >= 15 Or CInt(DateTime.Parse(TxtTo.Text).Day) <= 13 Then

            Else
                ComputeGDeduction = 0
                Exit Function
            End If
        End If

        Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
            SQLConnect.Open()

            Dim xSQL1 As New StringBuilder
            xSQL1.AppendLine("INSERT INTO payroll_govde(")
            xSQL1.AppendLine("    payroll_code, ")
            xSQL1.AppendLine("    emp_code, ")
            xSQL1.AppendLine("    govde_code, ")
            xSQL1.AppendLine("    govde_eeshare, ")
            xSQL1.AppendLine("    govde_ershare, ")
            xSQL1.AppendLine("    gov_desc ")
            xSQL1.AppendLine(") ")
            xSQL1.AppendLine("VALUES( ")
            xSQL1.AppendLine("    @payroll_code, ")
            xSQL1.AppendLine("    @emp_code, ")
            xSQL1.AppendLine("    @govde_code, ")
            xSQL1.AppendLine("    @govde_eeshare, ")
            xSQL1.AppendLine("    @govde_ershare, ")
            xSQL1.AppendLine("    @gov_desc  ")
            xSQL1.AppendLine(") ")

            Dim xSQL As New StringBuilder

            If xGD_Name = "SSS" Then
                xSQL.AppendLine("select * from gd_sss ")
                xSQL.AppendLine("WHERE ")
                xSQL.AppendLine("  sss_from_comp <= @xBasicPay  ")
                xSQL.AppendLine("  and sss_to_comp >= @xBasicPay and is_deleted = '1'  ")
            ElseIf xGD_Name = "PhilHealth" Then
                xSQL.AppendLine("select * from gd_philhealth ")
                xSQL.AppendLine("WHERE ")
                xSQL.AppendLine("  ph_from_comp <= @xBasicPay  ")
                xSQL.AppendLine("  and ph_to_comp >= @xBasicPay and is_deleted = '1' ")
            Else
                xSQL.AppendLine("select * from gd_hdmf ")
                xSQL.AppendLine("WHERE ")
                xSQL.AppendLine("  hdmf_from_comp <= @xBasicPay  ")
                xSQL.AppendLine("  and hdmf_to_comp >= @xBasicPay and is_deleted = '1' ")
            End If

            Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
            SQLCommand.Parameters.AddWithValue("@xBasicPay", xBasicPay)
            Dim da As New MySqlDataAdapter(SQLCommand)
            Dim ds As New DataSet
            da.Fill(ds)

            For Each dr In ds.Tables(0).Rows
                Dim cmdGovDeduc As New MySqlCommand(xSQL1.ToString, SQLConnect)
                If xGD_Name = "SSS" Then
                    ComputeGDeduction = ModC(dr("sss_ee"))
                    cmdGovDeduc.Parameters.AddWithValue("@payroll_code", lblPayrollCode.Text)
                    cmdGovDeduc.Parameters.AddWithValue("@emp_code", xEmpCode)
                    cmdGovDeduc.Parameters.AddWithValue("@govde_code", dr("sss_code"))
                    cmdGovDeduc.Parameters.AddWithValue("@govde_eeshare", dr("sss_ee"))
                    cmdGovDeduc.Parameters.AddWithValue("@govde_ershare", CDbl(dr("sss_er")) + CDbl(dr("sss_ec")))
                    cmdGovDeduc.Parameters.AddWithValue("@gov_desc", "SSS")
                    cmdGovDeduc.ExecuteNonQuery()
                ElseIf xGD_Name = "PhilHealth" Then
                    ComputeGDeduction = ModC(dr("ph_ee"))
                    cmdGovDeduc.Parameters.AddWithValue("@payroll_code", lblPayrollCode.Text)
                    cmdGovDeduc.Parameters.AddWithValue("@emp_code", xEmpCode)
                    cmdGovDeduc.Parameters.AddWithValue("@govde_code", dr("ph_code"))
                    cmdGovDeduc.Parameters.AddWithValue("@govde_eeshare", dr("ph_ee"))
                    cmdGovDeduc.Parameters.AddWithValue("@govde_ershare", dr("ph_er"))
                    cmdGovDeduc.Parameters.AddWithValue("@gov_desc", "PhilHealth")
                    cmdGovDeduc.ExecuteNonQuery()
                Else
                    If dr("hdmf_cont_option") = "0" Then
                        ComputeGDeduction = (ModC(dr("hdmf_ee")) / 100) * xBasicPay
                        cmdGovDeduc.Parameters.AddWithValue("@govde_eeshare", dr("hdmf_ee"))
                        cmdGovDeduc.Parameters.AddWithValue("@govde_ershare", dr("hdmf_er"))
                    Else
                        ComputeGDeduction = ModC(dr("hdmf_ee"))
                        cmdGovDeduc.Parameters.AddWithValue("@govde_eeshare", dr("hdmf_ee"))
                        cmdGovDeduc.Parameters.AddWithValue("@govde_ershare", dr("hdmf_er"))
                    End If
                    cmdGovDeduc.Parameters.AddWithValue("@payroll_code", lblPayrollCode.Text)
                    cmdGovDeduc.Parameters.AddWithValue("@emp_code", xEmpCode)
                    cmdGovDeduc.Parameters.AddWithValue("@govde_code", dr("hdmf_code"))
                    cmdGovDeduc.Parameters.AddWithValue("@gov_desc", "HDMF")
                    cmdGovDeduc.ExecuteNonQuery()
                End If
            Next

        End Using
    End Function
    Private Function PayrollCheck(ByVal xFrom As String, ByVal xTo As String) As Boolean
        PayrollCheck = False
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As String
                xSQL = " select * from Payroll " & _
                    " where date_to between @xFrom and @xTo or date_from between @xFrom and @xTo " & _
                    "  or date_from >= @xFrom and date_to <= @xTo or date_from <= @xFrom and date_to >= @xTo "
                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@xFrom", xFrom)
                SQLCommand.Parameters.AddWithValue("@xTo", xTo)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                For Each dr In ds.Tables(0).Rows
                    PayrollCheck = True
                Next
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function AbsentCheck(ByVal xFrom As String, ByVal xTo As String) As String
        AbsentCheck = 0
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As New System.Text.StringBuilder
                xSQL.AppendLine("SELECT dtrcompute.emp_code, ")
                xSQL.AppendLine("    dtrcompute.dtrc_dailyrate, ")
                xSQL.AppendLine("    dtrcompute.dtrc_date, ")
                xSQL.AppendLine("    count(dtrcompute.`status`) as Absent, ")
                xSQL.AppendLine("    dtrcompute.dtrc_dailyrate * count(dtrcompute.`status`) as 'Amount' ")
                xSQL.AppendLine("FROM dtrcompute ")
                xSQL.AppendLine("WHERE dtrcompute.`status` = 'Absent' and ")
                xSQL.AppendLine(" dtrc_date between @xFrom and @xTo")
                ' xSQL.AppendLine(" or dtrc_date >= @xFrom and dtrc_date <= @xTo ")
                xSQL.AppendLine("GROUP BY dtrcompute.emp_code ")

               
                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@xFrom", xFrom)
                SQLCommand.Parameters.AddWithValue("@xTo", xTo)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                For Each dr In ds.Tables(0).Rows
                    AbsentCheck = ModC(dr("Amount"))
                Next
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return AbsentCheck
    End Function
    Private Function LeaveCheck(ByVal xFrom As String, ByVal xTo As String) As String
        LeaveCheck = 0
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As New System.Text.StringBuilder
                xSQL.AppendLine("SELECT dtrcompute.emp_code, ")
                xSQL.AppendLine("    dtrcompute.dtrc_dailyrate, ")
                xSQL.AppendLine("    dtrcompute.dtrc_date, ")
                xSQL.AppendLine("    count(dtrcompute.`status`) as Absent, ")
                xSQL.AppendLine("    dtrcompute.dtrc_dailyrate * count(dtrcompute.`status`) as 'Amount' ")
                xSQL.AppendLine("FROM dtrcompute ")
                xSQL.AppendLine("WHERE dtrcompute.`status` = 'Leave' and ")
                xSQL.AppendLine(" dtrc_date between @xFrom and @xTo")
                ' xSQL.AppendLine(" or dtrc_date >= @xFrom and dtrc_date <= @xTo ")
                xSQL.AppendLine("GROUP BY dtrcompute.emp_code ")


                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@xFrom", xFrom)
                SQLCommand.Parameters.AddWithValue("@xTo", xTo)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                For Each dr In ds.Tables(0).Rows
                    LeaveCheck = ModC(dr("Amount"))
                Next
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return LeaveCheck
    End Function
    Private Function GetEmpCode()
        Dim empcodes As New ArrayList()

        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As New System.Text.StringBuilder
                xSQL.AppendLine("SELECT code from employee where job_status = 'Active' and is_deleted = '1' ")

                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)

                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)

                For Each dr In ds.Tables(0).Rows
                    empcodes.Add(dr("code"))
                Next
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return empcodes
    End Function

    Protected Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If PayrollCheck(txtFrom.Text, TxtTo.Text) = True Then
            MsgBox("Check payroll date, it might be already in the database.", vbInformation)
            Exit Sub
        End If

        Dim dt As New DataTable
        Dim dr As DataRow

        'Dim dtTotal As New DataTable
        'Dim drTotal As DataRow

        dt.Columns.Add(New DataColumn("Employee Code", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Employee Name", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Tax Compensation", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Basic Salary", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Late", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Absent", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Undertime", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Overtime", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Total Taxable Income", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SSS", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Philhealth", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("HDMF", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Withholding Tax", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Total Deduction", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Net Pay", System.Type.GetType("System.String")))

        'dtTotal.Columns.Add(New DataColumn(" ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("  ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("   ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("    ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("     ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("      ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("       ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("        ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("         ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("          ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("           ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("            ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("             ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("              ", System.Type.GetType("System.String")))
        'dtTotal.Columns.Add(New DataColumn("               ", System.Type.GetType("System.String")))


        Dim empcodes As ArrayList = GetEmpCode()


        For x = 0 To empcodes.Count - 1

            Dim GetPayroll() As String = Nothing

            GetPayroll = DTGetPayroll(empcodes(x), txtFrom.Text, TxtTo.Text)

            Dim empCode As String = GetPayroll(0)
            Dim empName As String = GetPayroll(1)
            Dim dailyrate As String = GetPayroll(2)
            Dim hourrate As String = GetPayroll(3)
            Dim nightdiffrate As String = GetPayroll(4)
            Dim basicsalary As String = GetPayroll(5)
            Dim Late As String = GetPayroll(6)
            Dim Undertime As String = GetPayroll(7)
            Dim Overtime As String = GetPayroll(8)
            Dim OvertimeSpecialHoliday As String = GetPayroll(9)
            Dim SpecialHoliday As String = GetPayroll(10)
            Dim OvertimeLegalHoliday As String = GetPayroll(11)
            Dim LegalHoliday As String = GetPayroll(12)
            Dim OvertimeSunday As String = GetPayroll(13)
            Dim OvertimeExcessSunday As String = GetPayroll(14)
            Dim OvertimeLegalHolidaySunday As String = GetPayroll(15)
            Dim OvertimeExcessLegalHolidaySunday As String = GetPayroll(16)
            Dim OvertimeNightDifferential As String = GetPayroll(17)
            Dim w_sss As String = GetPayroll(18)
            Dim w_hdmf As String = GetPayroll(19)
            Dim w_philhealth As String = GetPayroll(20)
            Dim tax_comp As String = GetPayroll(21)

            Dim emp_GD_SSS_Amt As Double = 0
            Dim emp_GD_PhilHealth_Amt As Double = 0
            Dim emp_GD_HDMF_Amt As Double = 0

            If gov_deduction_settings = "End Month" Then
            Else
                If w_sss = "1" Then
                    emp_GD_SSS_Amt = ComputeGDeduction(empCode, basicsalary, "SSS")
                End If

                If w_hdmf = "1" Then
                    emp_GD_PhilHealth_Amt = ComputeGDeduction(empCode, ModC(basicsalary), "PhilHealth")
                End If

                If w_philhealth = "1" Then
                    emp_GD_HDMF_Amt = ComputeGDeduction(empCode, basicsalary, "HDMF")
                End If
            End If


            Dim empGovDeduc As Double = emp_GD_SSS_Amt + emp_GD_HDMF_Amt + emp_GD_PhilHealth_Amt

            Dim empBasicPay As String = ""
            Dim empAbsent As String = AbsentCheck(txtFrom.Text, TxtTo.Text)
            Dim empLeave As String = LeaveCheck(txtFrom.Text, TxtTo.Text)
            Dim empTaxEarning As String = ""
            Dim empOvertime As Double = ModC(Overtime) + ModC(OvertimeSpecialHoliday) + ModC(SpecialHoliday) + ModC(OvertimeLegalHoliday) + _
                                        ModC(LegalHoliday) + ModC(OvertimeSunday) + ModC(OvertimeExcessSunday) + ModC(OvertimeLegalHolidaySunday) + _
                                        ModC(OvertimeExcessLegalHolidaySunday) + ModC(OvertimeNightDifferential)

            empBasicPay = basicsalary

            empTaxEarning = ModC(ModC(empBasicPay) + ModC(empOvertime)) - ModC(ModC(Late) + ModC(Undertime) + ModC(empGovDeduc) + ModC(empAbsent))


            Dim TaxTemp As String = ComputeTax(empTaxEarning, tax_comp, empCode)
            Dim TaxString() As String
            Dim empTax As Double
            Dim empTaxDue As Double
            Dim empTaxCeiling As Double
            If ActionTax = True Then
                TaxString = TaxTemp.Split(";")
                empTax = TaxString(0)
                empTaxDue = TaxString(1)
                empTaxCeiling = TaxString(2)
            Else
                empTax = 0
                empTaxDue = 0
                empTaxCeiling = 0
            End If

            Dim TotalDeduction As Double = ModC(empGovDeduc) + ModC(empTax)
            Dim NetPay As Double = ModC(empTaxEarning) - ModC(TotalDeduction)


            dr = dt.NewRow()
            dr(0) = empCode
            dr(1) = empName
            dr(2) = tax_comp
            dr(3) = ModC(empBasicPay)
            dr(4) = ShowComma(Late)
            dr(5) = ShowComma(empAbsent)
            dr(6) = ShowComma(Undertime)
            dr(7) = ShowComma(empOvertime)
            dr(8) = ShowComma(empTaxEarning)
            dr(9) = ShowComma(emp_GD_SSS_Amt)
            dr(10) = ShowComma(emp_GD_PhilHealth_Amt)
            dr(11) = ShowComma(emp_GD_HDMF_Amt)
            dr(12) = ShowComma(empTax)
            dr(13) = ShowComma(TotalDeduction)
            dr(14) = ShowComma(NetPay)
            dt.Rows.Add(dr)


            'dr(0) = "GRAND TOTAL"
            'dr(1) = ""
            'dr(2) = ""
            'dr(3) = ModC(empBasicPay)
            'dr(4) = ShowComma(Late)
            'dr(5) = ShowComma(empAbsent)
            'dr(6) = ShowComma(Undertime)
            'dr(7) = ShowComma(empOvertime)
            'dr(8) = ShowComma(empTaxEarning)
            'dr(9) = ShowComma(emp_GD_SSS_Amt)
            'dr(10) = ShowComma(emp_GD_PhilHealth_Amt)
            'dr(11) = ShowComma(emp_GD_HDMF_Amt)
            'dr(12) = ShowComma(empTax)
            'dr(13) = ShowComma(TotalDeduction)
            'dr(14) = ShowComma(NetPay)
            'dt.Rows.Add(dr)




        Next

        gvGenerate.DataSource = dt
        gvGenerate.DataBind()


        Dim xSQL1 As New StringBuilder
        xSQL1.AppendLine("INSERT INTO Payroll(")
        xSQL1.AppendLine("    payroll_code, ")
        xSQL1.AppendLine("    date_gen, ")
        xSQL1.AppendLine("    date_from, ")
        xSQL1.AppendLine("    date_to, ")
        xSQL1.AppendLine("    is_deleted ")
        xSQL1.AppendLine(") ")
        xSQL1.AppendLine("VALUES( ")
        xSQL1.AppendLine("    @payroll_code, ")
        xSQL1.AppendLine("    @date_gen, ")
        xSQL1.AppendLine("    @date_from, ")
        xSQL1.AppendLine("    @date_to, ")
        xSQL1.AppendLine("    '1' ")
        xSQL1.AppendLine(") ")

        Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
            SQLConnect.Open()
            PayrollTransaction = SQLConnect.BeginTransaction()
            Dim xSQL As New StringBuilder
            Dim commandDB As New MySqlCommand(xSQL1.ToString, SQLConnect)
            commandDB.Transaction = PayrollTransaction
            commandDB.Parameters.AddWithValue("@payroll_code", lblPayrollCode.Text)
            commandDB.Parameters.AddWithValue("@date_gen", Format(Date.Now, "yyyy-MM-dd"))
            commandDB.Parameters.AddWithValue("@date_from", txtFrom.Text)
            commandDB.Parameters.AddWithValue("@date_to", TxtTo.Text)
            commandDB.ExecuteNonQuery()

            'DTR
            Dim xSQLDTR As New StringBuilder
            xSQLDTR.AppendLine("UPDATE dtrcompute SET")
            xSQLDTR.AppendLine("    is_deleted = '1', ")
            xSQLDTR.AppendLine("    payroll_code = @payroll_code ")
            xSQLDTR.AppendLine("WHERE dtrc_date >= @xFrom ")
            xSQLDTR.AppendLine("  AND dtrc_date <= @xTo ")

            Dim cmdDTR As New MySqlCommand(xSQLDTR.ToString, SQLConnect)
            cmdDTR.Transaction = PayrollTransaction
            cmdDTR.Parameters.AddWithValue("@payroll_code", lblPayrollCode.Text)
            cmdDTR.Parameters.AddWithValue("@xFrom", txtFrom.Text)
            cmdDTR.Parameters.AddWithValue("@xTo", TxtTo.Text)
            cmdDTR.ExecuteNonQuery()

            If MsgBox("Save?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                PayrollTransaction.Commit()
            Else
                PayrollTransaction.Rollback()
            End If
        End Using

    End Sub
    Friend Function DTGetPayroll(ByVal xEmpCode As String, ByVal xFrom As DateTime, ByVal xTo As DateTime) As String()
        DTGetPayroll = Nothing

        Dim xSQL As New System.Text.StringBuilder
        xSQL.AppendLine("SELECT dtrcompute.id AS id, ")
        xSQL.AppendLine("    dtrcompute.emp_code AS emp_code, ")
        xSQL.AppendLine("    concat ( `employee`.`first_name`, ' ', `employee`.`middle_name`, ' ', `employee`.`last_name` ) AS `Name`, ")
        xSQL.AppendLine("    dtrcompute.dtrc_dailyrate AS dtrc_dailyrate, ")
        xSQL.AppendLine("    dtrcompute.dtrc_hourrate AS dtrc_hourrate, ")
        xSQL.AppendLine("    dtrcompute.dtrc_nightdiffrate AS dtrc_nightdiffrate, ")
        xSQL.AppendLine("    employee.basic_salary AS basic_salary, ")
        xSQL.AppendLine("    Sum(dtrcompute.late_amt) AS Late, ")
        xSQL.AppendLine("    Sum(dtrcompute.ut_amt) AS Undertime, ")
        xSQL.AppendLine("    Sum(dtrcompute.ot_amt) AS Overtime, ")
        xSQL.AppendLine("    Sum(dtrcompute.ot_sh_amt) AS `OvertimeSpecialHoliday`, ")
        xSQL.AppendLine("    Sum(dtrcompute.sh_amount) AS `SpecialHoliday`, ")
        xSQL.AppendLine("    Sum(dtrcompute.ot_lh_amt) AS `OvertimeLegalHoliday`, ")
        xSQL.AppendLine("    Sum(dtrcompute.lh_amt) AS `LegalHoliday`, ")
        xSQL.AppendLine("    Sum(dtrcompute.ot_sun_amt) AS `OvertimeSunday`, ")
        xSQL.AppendLine("    Sum(dtrcompute.ot_excess_sun_amt) AS `OvertimeExcessSunday`, ")
        xSQL.AppendLine("    Sum(dtrcompute.ot_lh_sun_amt) AS `OvertimeLegalHolidaySunday`, ")
        xSQL.AppendLine("    Sum(dtrcompute.ot_lh_excess_sun_amt) AS `OvertimeExcessLegalHolidaySunday`, ")
        xSQL.AppendLine("    Sum(dtrcompute.ot_nightdiff_amt) AS `OvertimeNightDifferential`, ")
        xSQL.AppendLine("    employee.w_sss AS w_sss, ")
        xSQL.AppendLine("    employee.w_hdmf AS w_hdmf, ")
        xSQL.AppendLine("    employee.w_philhealth, ")
        xSQL.AppendLine("    employee.tax_comp ")
        xSQL.AppendLine("FROM ( `dtrcompute` ")
        xSQL.AppendLine("    JOIN `employee` on ( ( `dtrcompute`.`emp_code` = `employee`.`code` ) ) ) ")
        xSQL.AppendLine("WHERE ( `dtrcompute`.`dtrc_date` between @xFrom and @xTo and `dtrcompute`.`emp_code` = @emp_code ) ")
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@emp_code", xEmpCode)
                SQLCommand.Parameters.AddWithValue("@xFrom", xFrom)
                SQLCommand.Parameters.AddWithValue("@xTo", xTo)
                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                If ds.Tables.Count <> 0 Then
                    For Each dr In ds.Tables(0).Rows

                        DTGetPayroll = New String() {dr("emp_code").ToString, _
                                                     dr("Name").ToString, _
                                                     ModC(dr("dtrc_dailyrate").ToString), _
                                                     ModC(dr("dtrc_hourrate").ToString), _
                                                     ModC(dr("dtrc_nightdiffrate").ToString), _
                                                     ModC(dr("basic_salary").ToString), _
                                                     ModC(dr("Late").ToString), _
                                                     ModC(dr("Undertime").ToString), _
                                                     ModC(dr("Overtime").ToString), _
                                                     ModC(dr("OvertimeSpecialHoliday").ToString), _
                                                     ModC(dr("SpecialHoliday").ToString), _
                                                     ModC(dr("OvertimeLegalHoliday").ToString), _
                                                     ModC(dr("LegalHoliday").ToString), _
                                                     ModC(dr("OvertimeSunday").ToString), _
                                                     ModC(dr("OvertimeExcessSunday").ToString), _
                                                     ModC(dr("OvertimeLegalHolidaySunday").ToString), _
                                                     ModC(dr("OvertimeExcessLegalHolidaySunday").ToString), _
                                                     ModC(dr("OvertimeNightDifferential").ToString), _
                                                     dr("w_sss").ToString, _
                                                     dr("w_hdmf").ToString, _
                                                     dr("w_philhealth").ToString, _
                                                     dr("tax_comp").ToString}
                    Next
                End If
                SQLConnect.Close()
            End Using
        Catch ex As Exception
            'Throw New Exception("Error in listing data.", ex)
            MsgBox(ex.Message)
        End Try

    End Function
    Friend Function ComputeTax(ByVal xTaxableEarning As Double, ByVal xTaxC As String, ByVal xEmpCode As String) As String
        ComputeTax = Nothing
        Dim temp As Integer = DateTime.Parse(TxtTo.Text).Day

        Try
            ActionTax = False
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As String
                xSQL = "Select * " & _
                        " from taxes WHERE tax_amount_comp >= @xTaxableEarning and tax_ceiling <= @xTaxableEarning and tax_status = @xTaxC " & _
                        " order by tax_amount_comp desc "
                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                SQLCommand.Parameters.AddWithValue("@xTaxableEarning", xTaxableEarning)
                SQLCommand.Parameters.AddWithValue("@xTaxC", xTaxC)
                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                For Each dr In ds.Tables(0).Rows

                    ComputeTax = ModC(ModC(dr("tax_additional")) + (ModC(dr("tax_rate")) * (ModC(xTaxableEarning) - ModC(dr("tax_ceiling")))))
                    ComputeTax = ComputeTax & ";" & ModC((ModC(xTaxableEarning) - ModC(dr("tax_ceiling"))) * ModC(dr("tax_rate")))
                    ComputeTax = ComputeTax & ";" & dr("tax_ceiling")

                    ActionTax = True
                Next
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
End Class