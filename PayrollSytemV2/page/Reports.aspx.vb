Imports MySql.Data.MySqlClient

Public Class Reports
    Inherits System.Web.UI.Page
    Dim rptPayrollJournal As New payrolljournal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillPCodeDDL
        End If
    End Sub
    Public Sub FillPCodeDDL()
        Dim cdb As New CReports
        Dim dt As DataTable = cdb.ShiftsListDDL

        ddlPayrollCode.DataValueField = "payroll_code"
        ddlPayrollCode.DataTextField = "v_payroll_code"

        ddlPayrollCode.DataSource = dt
        ddlPayrollCode.DataBind()
    End Sub
    Private Sub PayrollJournal(Optional ByVal xEmpCode As String = "")
        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()
                Dim xSQL As New System.Text.StringBuilder
                xSQL.AppendLine("SELECT payroll_details.id, ")
                xSQL.AppendLine("    payroll_details.payroll_code, ")
                xSQL.AppendLine("    payroll_details.emp_code, ")
                xSQL.AppendLine("    payroll_details.emp_tax_comp, ")
                xSQL.AppendLine("    payroll_details.emp_basicpay, ")
                xSQL.AppendLine("    payroll_details.emp_late, ")
                xSQL.AppendLine("    payroll_details.emp_absent, ")
                xSQL.AppendLine("    payroll_details.emp_ut, ")
                xSQL.AppendLine("    payroll_details.emp_ot, ")
                xSQL.AppendLine("    payroll_details.emp_taxallowance, ")
                xSQL.AppendLine("    payroll_details.emp_receivable, ")
                xSQL.AppendLine("    payroll_details.emp_deminimis, ")
                xSQL.AppendLine("    payroll_details.emp_totaltaxearning, ")
                xSQL.AppendLine("    payroll_details.emp_bonus, ")
                xSQL.AppendLine("    payroll_details.emp_wtax, ")
                xSQL.AppendLine("    payroll_details.emp_govdeduc, ")
                xSQL.AppendLine("    payroll_details.emp_comdeduc, ")
                xSQL.AppendLine("    payroll_details.emp_totaldeduction, ")
                xSQL.AppendLine("    payroll_details.emp_netpay, ")
                xSQL.AppendLine("    payroll_details.emp_payrolladjustment, ")
                xSQL.AppendLine("    payroll_details.emp_payroll_year, ")
                xSQL.AppendLine("    payroll_details.is_deleted, ")
                xSQL.AppendLine("    SSS.govde_eeshare as 'SSS', ")
                xSQL.AppendLine("    PhilHealth.govde_eeshare as 'PhilHealth', ")
                xSQL.AppendLine("    HDMF.govde_eeshare as 'HDMF' ")
                xSQL.AppendLine("FROM payroll_details ")
                xSQL.AppendLine("    LEFT OUTER JOIN payroll_govde as SSS ON payroll_details.payroll_code = SSS.payroll_code and payroll_details.emp_code = SSS.emp_code and SSS.gov_desc = 'SSS' ")
                xSQL.AppendLine("    LEFT OUTER JOIN payroll_govde as PhilHealth ON payroll_details.payroll_code = PhilHealth.payroll_code and payroll_details.emp_code = PhilHealth.emp_code and PhilHealth.gov_desc = 'PhilHealth' ")
                xSQL.AppendLine("    LEFT OUTER JOIN payroll_govde as HDMF ON payroll_details.payroll_code = HDMF.payroll_code and payroll_details.emp_code = HDMF.emp_code and HDMF.gov_desc = 'HDMF' ")
                xSQL.AppendLine("WHERE payroll_details.payroll_code = '" & Trim(ddlPayrollCode.SelectedValue) & "' ")


                'If Len(xEmpCode) > 0 Then
                '    xSQL.AppendLine("AND PayrollDetail.emp_code = '" & Trim(xEmpCode) & "' ")
                'xSQL.AppendLine("WHERE payroll_details.emp_code = 'EMP-0001' ")
                'End If
                Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                Dim da As New MySqlDataAdapter(SQLCommand)
                Dim ds As New DataSet
                da.Fill(ds)
                If ds.Tables.Count <> 0 Then
                    ds.WriteXml(HttpRuntime.AppDomainAppPath & "\XML\PayrollJournal.xml", XmlWriteMode.WriteSchema)
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        PayrollJournal()
        If IsPostBack Then
            Dim dsPayrollJournal As New DataSet
            dsPayrollJournal = New DSREPORT()
            Dim dsPayrollJournalTemp As New DataSet
            dsPayrollJournal = New DataSet()
            dsPayrollJournalTemp.ReadXml(HttpRuntime.AppDomainAppPath() & "\XML\PayrollJournal.xml")
            dsPayrollJournal.Merge(dsPayrollJournalTemp.Tables(0))
            rptPayrollJournal = New payrolljournal
            rptPayrollJournal.SetDataSource(dsPayrollJournal.Tables(0))
            crvReports.ReportSource = rptPayrollJournal
            crvReports.DataBind()
        End If
    End Sub
End Class