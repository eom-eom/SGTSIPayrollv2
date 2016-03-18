Imports System.Text
Imports MySql.Data.MySqlClient
Public Class EmployeeInfo
#Region "Properties"
    '--------------EMPLOYEE TABLE---------------'
    Private _id As String = ""

    Friend Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal Value As String)
            _id = Value
        End Set
    End Property

    Private _code As String = ""

    Friend Property code() As String
        Get
            Return _code
        End Get
        Set(ByVal Value As String)
            _code = Value
        End Set
    End Property

    Private _first_name As String = ""

    Friend Property first_name() As String
        Get
            Return _first_name
        End Get
        Set(ByVal Value As String)
            _first_name = Value
        End Set
    End Property

    Private _last_name As String = ""

    Friend Property last_name() As String
        Get
            Return _last_name
        End Get
        Set(ByVal Value As String)
            _last_name = Value
        End Set
    End Property

    Private _middle_name As String

    Friend Property middle_name() As String
        Get
            Return _middle_name
        End Get
        Set(ByVal Value As String)
            _middle_name = Value
        End Set
    End Property

    Private _birthday As String = ""

    Friend Property birthday() As String
        Get
            Return _birthday
        End Get
        Set(ByVal Value As String)
            _birthday = Value
        End Set
    End Property

    Private _mobile As String = ""

    Friend Property mobile() As String
        Get
            Return _mobile
        End Get
        Set(ByVal Value As String)
            _mobile = Value
        End Set
    End Property


    Private _telephone As String = ""

    Friend Property telephone() As String
        Get
            Return _telephone
        End Get
        Set(ByVal Value As String)
            _telephone = Value
        End Set
    End Property

    Private _email As String = ""

    Friend Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal Value As String)
            _email = Value
        End Set
    End Property

    Private _nationality As String = ""

    Friend Property nationality() As String
        Get
            Return _nationality
        End Get
        Set(ByVal Value As String)
            _nationality = Value
        End Set
    End Property

    Private _department_id As Int32 = 0

    Friend Property department_id() As Int32
        Get
            Return _department_id
        End Get
        Set(ByVal Value As Int32)
            _department_id = Value
        End Set
    End Property

    Private _job_title_id As Int32 = 0

    Friend Property job_title_id() As Int32
        Get
            Return _job_title_id
        End Get
        Set(ByVal Value As Int32)
            _job_title_id = Value
        End Set
    End Property

    Private _employment_status As String = ""

    Friend Property employment_status() As String
        Get
            Return _employment_status
        End Get
        Set(ByVal Value As String)
            _employment_status = Value
        End Set
    End Property

    Private _date_hired As String = ""

    Friend Property date_hired() As String
        Get
            Return _date_hired
        End Get
        Set(ByVal Value As String)
            _date_hired = Value
        End Set
    End Property

    Private _address As String = ""

    Friend Property address() As String
        Get
            Return _address
        End Get
        Set(ByVal Value As String)
            _address = Value
        End Set
    End Property

    Private _job_status As String = ""

    Friend Property job_status() As String
        Get
            Return _job_status
        End Get
        Set(ByVal Value As String)
            _job_status = Value
        End Set
    End Property

    Private _date_resigned As String = ""

    Friend Property date_resigned() As String
        Get
            Return _date_resigned
        End Get
        Set(ByVal Value As String)
            _date_resigned = Value
        End Set
    End Property

    Private _basic_salary As String = ""

    Friend Property basic_salary() As String
        Get
            Return _basic_salary
        End Get
        Set(ByVal Value As String)
            _basic_salary = Value
        End Set
    End Property

    Private _daily_rate As String = ""

    Friend Property daily_rate() As String
        Get
            Return _daily_rate
        End Get
        Set(ByVal Value As String)
            _daily_rate = Value
        End Set
    End Property

    Private _hour_rate As String = ""

    Friend Property hour_rate() As String
        Get
            Return _hour_rate
        End Get
        Set(ByVal Value As String)
            _hour_rate = Value
        End Set
    End Property

    Private _def_time_in As String = ""

    Friend Property def_time_in() As String
        Get
            Return _def_time_in
        End Get
        Set(ByVal Value As String)
            _def_time_in = Value
        End Set
    End Property

    Private _def_time_out As String = ""

    Friend Property def_time_out() As String
        Get
            Return _def_time_out
        End Get
        Set(ByVal Value As String)
            _def_time_out = Value
        End Set
    End Property

    Private _w_13monthpay As String = ""

    Friend Property w_13monthpay() As String
        Get
            Return _w_13monthpay
        End Get
        Set(ByVal Value As String)
            _w_13monthpay = Value
        End Set
    End Property

    Private _w_sss As String = ""

    Friend Property w_sss() As String
        Get
            Return _w_sss
        End Get
        Set(ByVal Value As String)
            _w_sss = Value
        End Set
    End Property

    Private _w_philhealth As String = ""

    Friend Property w_philhealth() As String
        Get
            Return _w_philhealth
        End Get
        Set(ByVal Value As String)
            _w_philhealth = Value
        End Set
    End Property

    Private _w_hdmf As String = ""

    Friend Property w_hdmf() As String
        Get
            Return _w_hdmf
        End Get
        Set(ByVal Value As String)
            _w_hdmf = Value
        End Set
    End Property

    Private _tin_no As String = ""

    Friend Property tin_no() As String
        Get
            Return _tin_no
        End Get
        Set(ByVal Value As String)
            _tin_no = Value
        End Set
    End Property

    Private _sss_no As String = ""

    Friend Property sss_no() As String
        Get
            Return _sss_no
        End Get
        Set(ByVal Value As String)
            _sss_no = Value
        End Set
    End Property

    Private _pagibig_no As String = ""

    Friend Property pagibig_no() As String
        Get
            Return _pagibig_no
        End Get
        Set(ByVal Value As String)
            _pagibig_no = Value
        End Set
    End Property

    Private _philhealth_no As String = ""

    Friend Property philhealth_no() As String
        Get
            Return _philhealth_no
        End Get
        Set(ByVal Value As String)
            _philhealth_no = Value
        End Set
    End Property

    Private _tax_comp As String = ""

    Friend Property tax_comp() As String
        Get
            Return _tax_comp
        End Get
        Set(ByVal Value As String)
            _tax_comp = Value
        End Set
    End Property

    Private _is_deleted As String = ""

    Friend Property is_deleted() As String
        Get
            Return _is_deleted
        End Get
        Set(ByVal Value As String)
            _is_deleted = Value
        End Set
    End Property

    Private _def_shift_id As String = ""

    Friend Property def_shift_id() As String
        Get
            Return _def_shift_id
        End Get
        Set(ByVal Value As String)
            _def_shift_id = Value
        End Set
    End Property

    Private _emp_last_employer As String = ""

    Friend Property emp_last_employer() As String
        Get
            Return _emp_last_employer
        End Get
        Set(ByVal Value As String)
            _emp_last_employer = Value
        End Set
    End Property

    Private _prev_employer_date_resigned As String = ""

    Friend Property prev_employer_date_resigned() As String
        Get
            Return _prev_employer_date_resigned
        End Get
        Set(ByVal Value As String)
            _prev_employer_date_resigned = Value
        End Set
    End Property


    Private _acu_id As Int32 = 0

    Friend Property acu_id() As Int32
        Get
            Return _acu_id
        End Get
        Set(ByVal Value As Int32)
            _acu_id = Value
        End Set
    End Property
    '--------------EMPLOYEE COMPANY DEDUCTION TABLE---------------'

    Private _comde_id As Int32 = 0

    Friend Property comde_id() As Int32
        Get
            Return _comde_id
        End Get
        Set(ByVal Value As Int32)
            _comde_id = Value
        End Set
    End Property

    Private _emp_comde_amt As String = ""

    Friend Property emp_comde_amt() As String
        Get
            Return _emp_comde_amt
        End Get
        Set(ByVal Value As String)
            _emp_comde_amt = Value
        End Set
    End Property

    Private _emp_comde_start_date As String = ""

    Friend Property emp_comde_start_date() As String
        Get
            Return _emp_comde_start_date
        End Get
        Set(ByVal Value As String)
            _emp_comde_start_date = Value
        End Set
    End Property

    Private _emp_comde_end_date As String = ""

    Friend Property emp_comde_end_date() As String
        Get
            Return _emp_comde_end_date
        End Get
        Set(ByVal Value As String)
            _emp_comde_end_date = Value
        End Set
    End Property

    Private _emp_deduct_type As String = ""

    Friend Property emp_deduct_type() As String
        Get
            Return _emp_deduct_type
        End Get
        Set(ByVal Value As String)
            _emp_deduct_type = Value
        End Set
    End Property

    Private _emp_comde_deleted As String = ""

    Friend Property emp_comde_deleted() As String
        Get
            Return _emp_comde_deleted
        End Get
        Set(ByVal Value As String)
            _emp_comde_deleted = Value
        End Set
    End Property
    '--------------EMPLOYEE DE MINIMIS BENEFITS TABLE---------------'

    Private _dmb_id As Int32 = 0
    Friend Property dmb_id() As Int32
        Get
            Return _dmb_id
        End Get
        Set(ByVal Value As Int32)
            _comde_id = Value
        End Set
    End Property

    Private _emp_dmb_deleted As String = ""

    Friend Property emp_dmb_deleted() As String
        Get
            Return _emp_dmb_deleted
        End Get
        Set(ByVal Value As String)
            _emp_dmb_deleted = Value
        End Set
    End Property
    '--------------EMPLOYEE  LEAVES TABLE---------------'

    Private _leave_id As Int32 = 0
    Friend Property leave_id() As Int32
        Get
            Return _leave_id
        End Get
        Set(ByVal Value As Int32)
            _leave_id = Value
        End Set
    End Property

    Private _leave_used As String = ""

    Friend Property leave_used() As String
        Get
            Return _leave_used
        End Get
        Set(ByVal Value As String)
            _leave_used = Value
        End Set
    End Property

    Private _emp_leaves_deleted As String = ""

    Friend Property emp_leaves_deleted() As String
        Get
            Return _emp_leaves_deleted
        End Get
        Set(ByVal Value As String)
            _emp_leaves_deleted = Value
        End Set
    End Property
    '--------------EMPLOYEE  RECEIVABLE AND TAXABLE ALLOWANCES TABLE---------------'
    Private _rta_id As Int32
    Friend Property rta_id() As Int32
        Get
            Return _rta_id
        End Get
        Set(ByVal Value As Int32)
            _rta_id = Value
        End Set
    End Property

    Private _emp_rta_deleted As String = ""

    Friend Property emp_rta_deleted() As String
        Get
            Return _emp_rta_deleted
        End Get
        Set(ByVal Value As String)
            _emp_rta_deleted = Value
        End Set
    End Property
    '--------------EMPLOYEE SHIFT TABLE---------------'
    Private _shift_id As Int32 = 0
    Friend Property shift_id() As Int32
        Get
            Return _shift_id
        End Get
        Set(ByVal Value As Int32)
            _shift_id = Value
        End Set
    End Property

    Private _emp_shift_date_from As String = ""

    Friend Property emp_shift_date_from() As String
        Get
            Return _emp_shift_date_from
        End Get
        Set(ByVal Value As String)
            _emp_shift_date_from = Value
        End Set
    End Property

    Private _emp_shift_date_to As String = ""

    Friend Property emp_shift_date_to() As String
        Get
            Return _emp_shift_date_to
        End Get
        Set(ByVal Value As String)
            _emp_shift_date_to = Value
        End Set
    End Property

    Private _emp_shift_date_applied As String = ""

    Friend Property emp_shift_date_applied() As String
        Get
            Return _emp_shift_date_applied
        End Get
        Set(ByVal Value As String)
            _emp_shift_date_applied = Value
        End Set
    End Property

    Private _emp_shift_time_in As String = ""

    Friend Property emp_shift_time_in() As String
        Get
            Return _emp_shift_time_in
        End Get
        Set(ByVal Value As String)
            _emp_shift_time_in = Value
        End Set
    End Property

    Private _emp_shift_time_out As String = ""

    Friend Property emp_shift_time_out() As String
        Get
            Return _emp_shift_time_out
        End Get
        Set(ByVal Value As String)
            _emp_shift_time_out = Value
        End Set
    End Property

    Private _emp_shift_deleted As String = ""

    Friend Property emp_shift_deleted() As String
        Get
            Return _emp_shift_deleted
        End Get
        Set(ByVal Value As String)
            _emp_shift_deleted = Value
        End Set
    End Property
    '--------------EMPLOYEE WORKING DAYS TABLE---------------'
    Private _monday As String = ""

    Friend Property monday() As String
        Get
            Return _monday
        End Get
        Set(ByVal Value As String)
            _monday = Value
        End Set
    End Property

    Private _tuesday As String = ""

    Friend Property tuesday() As String
        Get
            Return _tuesday
        End Get
        Set(ByVal Value As String)
            _tuesday = Value
        End Set
    End Property

    Private _wednesday As String = ""

    Friend Property wednesday() As String
        Get
            Return _wednesday
        End Get
        Set(ByVal Value As String)
            _wednesday = Value
        End Set
    End Property

    Private _thursday As String = ""

    Friend Property thursday() As String
        Get
            Return _thursday
        End Get
        Set(ByVal Value As String)
            _thursday = Value
        End Set
    End Property

    Private _friday As String = ""

    Friend Property friday() As String
        Get
            Return _friday
        End Get
        Set(ByVal Value As String)
            _friday = Value
        End Set
    End Property

    Private _saturday As String = ""

    Friend Property saturday() As String
        Get
            Return _saturday
        End Get
        Set(ByVal Value As String)
            _saturday = Value
        End Set
    End Property

    Private _sunday As String = ""

    Friend Property sunday() As String
        Get
            Return _sunday
        End Get
        Set(ByVal Value As String)
            _sunday = Value
        End Set
    End Property

    Private _emp_wkng_days_date_stamp As String = ""

    Friend Property emp_wkng_days_date_stamp() As String
        Get
            Return _emp_wkng_days_date_stamp
        End Get
        Set(ByVal Value As String)
            _emp_wkng_days_date_stamp = Value
        End Set
    End Property

    Private _emp_wkng_days_deleted As String = ""

    Friend Property emp_wkng_days_deleted() As String
        Get
            Return _emp_wkng_days_deleted
        End Get
        Set(ByVal Value As String)
            _emp_wkng_days_deleted = Value
        End Set
    End Property

#End Region
End Class
Public Class EmploymentInfoDB



    Friend Function EmployeeGetList() As DataTable
        Dim dt As DataTable = Nothing

        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT")
            xSQL.AppendLine("employee.id,")
            xSQL.AppendLine("employee.`code`,")
            xSQL.AppendLine("concat(first_name,', ', last_name, ' ', middle_name) as name,")
            xSQL.AppendLine("employee.birthday,")
            xSQL.AppendLine("employee.mobile,")
            xSQL.AppendLine("employee.email,")
            xSQL.AppendLine("employment_status,")
            xSQL.AppendLine("departments.description as dept_name,")
            xSQL.AppendLine("job_titles.`name` as job_name")
            xSQL.AppendLine("FROM employee")
            xSQL.AppendLine("INNER JOIN departments ON employee.department_id = departments.id")
            xSQL.AppendLine("INNER JOIN job_titles ON employee.job_title_id = job_titles.id")
            xSQL.AppendLine("WHERE employee.is_deleted= '1'")
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
                MsgBox(ex.ToString, vbCritical + vbOKOnly, "Error")
                'ShowMessage(ex.ToString, MessageType.Success, Me)
            End Try
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
    'Friend Function EmployeeInsertFile(ByVal cItem As EmployeeInfo, lenOfRTA As Int32, lenofComde As Int32, _
    '                                   lenOfLeaves As Int32, lenOfDMB As Int32) As EmployeeInfo
    Friend Function EmployeeInsertFile(ByVal cItem As EmployeeInfo, _
                                       recVal As ArrayList, taxAllowVal As ArrayList, _
                                       comDeVal As ArrayList, leaveVal As ArrayList, _
                                       deminimisBenVal As ArrayList) As EmployeeInfo
        Dim cReturn As New EmployeeInfo

        Try
            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                xSQL.AppendLine("START TRANSACTION;")
                xSQL.AppendLine("INSERT INTO employee(")
                xSQL.AppendLine("code,")
                xSQL.AppendLine("first_name,")
                xSQL.AppendLine("last_name,")
                xSQL.AppendLine("middle_name,")
                xSQL.AppendLine("birthday,")
                xSQL.AppendLine("address,")
                xSQL.AppendLine("mobile,")
                xSQL.AppendLine("telephone,")
                xSQL.AppendLine("nationality,")
                xSQL.AppendLine("email,")
                xSQL.AppendLine("department_id,")
                xSQL.AppendLine("job_title_id,")
                xSQL.AppendLine("employment_status,")
                xSQL.AppendLine("date_hired,")
                xSQL.AppendLine("job_status,")
                xSQL.AppendLine("date_resigned,")
                xSQL.AppendLine("tax_comp,")
                xSQL.AppendLine("emp_last_employer,")
                xSQL.AppendLine("basic_salary,")
                xSQL.AppendLine("daily_rate,")
                xSQL.AppendLine("hour_rate,")
                xSQL.AppendLine("def_shift_id,")
                xSQL.AppendLine("def_time_in,")
                xSQL.AppendLine("def_time_out,")
                xSQL.AppendLine("w_13monthpay,")
                xSQL.AppendLine("tin_no,")
                xSQL.AppendLine("sss_no,")
                xSQL.AppendLine("pagibig_no,")
                xSQL.AppendLine("philhealth_no,")
                xSQL.AppendLine("w_sss,")
                xSQL.AppendLine("w_hdmf,")
                xSQL.AppendLine("w_philhealth,")
                xSQL.AppendLine("is_deleted")

                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("@code,")
                xSQL.AppendLine("@first_name,")
                xSQL.AppendLine("@last_name,")
                xSQL.AppendLine("@middle_name,")
                xSQL.AppendLine("@birthday,")
                xSQL.AppendLine("@address,")
                xSQL.AppendLine("@mobile,")
                xSQL.AppendLine("@telephone,")
                xSQL.AppendLine("@nationality,")
                xSQL.AppendLine("@email,")
                xSQL.AppendLine("@department_id,")
                xSQL.AppendLine("@job_title_id,")
                xSQL.AppendLine("@employment_status,")
                xSQL.AppendLine("@date_resigned,")
                xSQL.AppendLine("@job_status,")
                xSQL.AppendLine("@date_hired,")
                xSQL.AppendLine("@tax_comp,")
                xSQL.AppendLine("@emp_last_employer,")
                xSQL.AppendLine("@basic_salary,")
                xSQL.AppendLine("@daily_rate,")
                xSQL.AppendLine("@hour_rate,")
                xSQL.AppendLine("@def_shift_id,")
                xSQL.AppendLine("@def_time_in,")
                xSQL.AppendLine("@def_time_out,")
                xSQL.AppendLine("@w_13monthpay,")
                xSQL.AppendLine("@tin_no,")
                xSQL.AppendLine("@sss_no,")
                xSQL.AppendLine("@pagibig_no,")
                xSQL.AppendLine("@philhealth_no,")
                xSQL.AppendLine("@w_sss,")
                xSQL.AppendLine("@w_hdmf,")
                xSQL.AppendLine("@w_philhealth,")
                xSQL.AppendLine("@is_deleted")

                xSQL.AppendLine(");")
                xSQL.AppendLine("SET @e_id = LAST_INSERT_ID();")

                'deletion of previous working days
                'xSQL.AppendLine("DELETE FROM employee_working_days")
                'xSQL.AppendLine("WHERE emp_id = @e_id;")


                xSQL.AppendLine("INSERT INTO employee_working_days(")
                xSQL.AppendLine("emp_id,")
                xSQL.AppendLine("monday,")
                xSQL.AppendLine("tuesday,")
                xSQL.AppendLine("wednesday,")
                xSQL.AppendLine("thursday,")
                xSQL.AppendLine("friday,")
                xSQL.AppendLine("saturday,")
                xSQL.AppendLine("sunday,")
                xSQL.AppendLine("date_stamp")


                xSQL.AppendLine(") ")
                xSQL.AppendLine("VALUES( ")
                xSQL.AppendLine("@e_id,")
                xSQL.AppendLine("@monday,")
                xSQL.AppendLine("@tuesday,")
                xSQL.AppendLine("@wednesday,")
                xSQL.AppendLine("@thursday,")
                xSQL.AppendLine("@friday,")
                xSQL.AppendLine("@saturday,")
                xSQL.AppendLine("@sunday,")
                xSQL.AppendLine("@date_stamp")
                xSQL.AppendLine(");")

                'may update ng is_deleted and looping here I think.
                For x = 0 To recVal.Count - 1 Step 1
                    xSQL.AppendLine("INSERT INTO employee_receivable_and_taxable_allowances(")
                    xSQL.AppendLine("emp_id,")
                    xSQL.AppendLine("rta_id,")
                    xSQL.AppendLine("is_deleted")
                    xSQL.AppendLine(") ")
                    xSQL.AppendLine("VALUES( ")
                    xSQL.AppendLine("@e_id,")
                    xSQL.AppendLine("@rta_id_" & x & ",")
                    xSQL.AppendLine("@emp_rta_deleted_" & x)
                    xSQL.AppendLine(");")
                Next

                For x = 0 To taxAllowVal.Count - 1 Step 1
                    xSQL.AppendLine("INSERT INTO employee_receivable_and_taxable_allowances(")
                    xSQL.AppendLine("emp_id,")
                    xSQL.AppendLine("rta_id,")
                    xSQL.AppendLine("is_deleted")
                    xSQL.AppendLine(") ")
                    xSQL.AppendLine("VALUES( ")
                    xSQL.AppendLine("@e_id,")
                    xSQL.AppendLine("@rta_id_ta_" & x & ",")
                    xSQL.AppendLine("@emp_rta_deleted_ta_" & x)
                    xSQL.AppendLine(");")
                Next

                For x = 0 To comDeVal.Count - 1 Step 1
                    xSQL.AppendLine("INSERT INTO employee_company_deductions(")
                    xSQL.AppendLine("e_id,")
                    xSQL.AppendLine("comde_id,")
                    xSQL.AppendLine("emp_comde_amt,")
                    xSQL.AppendLine("emp_comde_start_date,")
                    xSQL.AppendLine("emp_comde_end_date,")
                    xSQL.AppendLine("emp_deduct_type,")
                    xSQL.AppendLine("is_deleted")
                    xSQL.AppendLine(") ")
                    xSQL.AppendLine("VALUES( ")
                    xSQL.AppendLine("e_id,")
                    xSQL.AppendLine("@comde_id_" & x & ",")
                    xSQL.AppendLine("@emp_comde_" & x & ",")
                    xSQL.AppendLine("@emp_comde_start_date_" & x & ",")
                    xSQL.AppendLine("@emp_comde_end_date_" & x & ",")
                    xSQL.AppendLine("@emp_deduct_type_" & x)
                    xSQL.AppendLine(");")
                Next

                For x = 0 To leaveVal.Count - 1 Step 1
                    xSQL.AppendLine("INSERT INTO employee_leaves(")
                    xSQL.AppendLine("e_id,")
                    xSQL.AppendLine("leave_id,")
                    xSQL.AppendLine("leave_used,")
                    xSQL.AppendLine(") ")
                    xSQL.AppendLine("VALUES( ")
                    xSQL.AppendLine("e_id,")
                    xSQL.AppendLine("@leave_id_" & x & ",")
                    xSQL.AppendLine("@leaved_used_" & x)
                    xSQL.AppendLine(");")
                Next

                For x = 0 To deminimisBenVal.Count - 1 Step 1
                    'may update ng is_deleted and looping here I think.
                    xSQL.AppendLine("INSERT INTO employee_de_minimis_benefits(")
                    xSQL.AppendLine("e_id,")
                    xSQL.AppendLine("dmb_id,")
                    xSQL.AppendLine("is_deleted")
                    xSQL.AppendLine(") ")
                    xSQL.AppendLine("VALUES( ")
                    xSQL.AppendLine("e_id,")
                    xSQL.AppendLine("@dmb_id_" & x & ",")
                    xSQL.AppendLine("@emp_dmb_deleted_" & x)
                    xSQL.AppendLine(");")
                Next





                xSQL.AppendLine("COMMIT;")
                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)

                commandDB1.Parameters.AddWithValue("@code", cItem.code)
                commandDB1.Parameters.AddWithValue("@first_name", cItem.first_name)
                commandDB1.Parameters.AddWithValue("@last_name", cItem.last_name)
                commandDB1.Parameters.AddWithValue("@middle_name", cItem.middle_name)
                commandDB1.Parameters.AddWithValue("@birthday", cItem.birthday)
                commandDB1.Parameters.AddWithValue("@address", cItem.address)
                commandDB1.Parameters.AddWithValue("@mobile", cItem.mobile)
                commandDB1.Parameters.AddWithValue("@telephone", cItem.telephone)
                commandDB1.Parameters.AddWithValue("@nationality", cItem.nationality)
                commandDB1.Parameters.AddWithValue("@email", cItem.email)
                commandDB1.Parameters.AddWithValue("@department_id", cItem.department_id)
                commandDB1.Parameters.AddWithValue("@job_title_id", cItem.job_title_id)
                commandDB1.Parameters.AddWithValue("@employment_status", cItem.employment_status)
                commandDB1.Parameters.AddWithValue("@date_resigned", cItem.date_resigned)
                commandDB1.Parameters.AddWithValue("@job_status", cItem.job_status)
                commandDB1.Parameters.AddWithValue("@date_hired", cItem.date_hired)
                commandDB1.Parameters.AddWithValue("@tax_comp", cItem.tax_comp)
                commandDB1.Parameters.AddWithValue("@emp_last_employer", cItem.emp_last_employer)
                commandDB1.Parameters.AddWithValue("@basic_salary", cItem.basic_salary)
                commandDB1.Parameters.AddWithValue("@daily_rate", cItem.daily_rate)
                commandDB1.Parameters.AddWithValue("@hour_rate", cItem.hour_rate)
                commandDB1.Parameters.AddWithValue("@def_shift_id", cItem.def_shift_id)
                commandDB1.Parameters.AddWithValue("@def_time_in", cItem.def_time_in)
                commandDB1.Parameters.AddWithValue("@def_time_out", cItem.def_time_out)
                commandDB1.Parameters.AddWithValue("@w_13monthpay", cItem.w_13monthpay)
                commandDB1.Parameters.AddWithValue("@tin_no", cItem.tin_no)
                commandDB1.Parameters.AddWithValue("@sss_no", cItem.sss_no)
                commandDB1.Parameters.AddWithValue("@pagibig_no", cItem.pagibig_no)
                commandDB1.Parameters.AddWithValue("@philhealth_no", cItem.philhealth_no)
                commandDB1.Parameters.AddWithValue("@w_sss", cItem.w_sss)
                commandDB1.Parameters.AddWithValue("@w_hdmf", cItem.w_hdmf)
                commandDB1.Parameters.AddWithValue("@w_philhealth", cItem.w_philhealth)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)


                '----WORKING DAYS-----
                commandDB1.Parameters.AddWithValue("@monday", cItem.monday)
                commandDB1.Parameters.AddWithValue("@tuesday", cItem.tuesday)
                commandDB1.Parameters.AddWithValue("@wednesday", cItem.wednesday)
                commandDB1.Parameters.AddWithValue("@thursday", cItem.thursday)
                commandDB1.Parameters.AddWithValue("@friday", cItem.friday)
                commandDB1.Parameters.AddWithValue("@saturday", cItem.saturday)
                commandDB1.Parameters.AddWithValue("@sunday", cItem.sunday)
                commandDB1.Parameters.AddWithValue("@date_stamp", Date.Now)


                For x = 0 To recVal.Count - 1 Step 1
                    commandDB1.Parameters.AddWithValue("@rta_id_" & x, recVal(x))
                    'commandDB1.Parameters.AddWithValue("@emp_rta_deleted" & x, cItem.emp_rta_deleted)
                Next
                For x = 0 To taxAllowVal.Count - 1 Step 1
                    commandDB1.Parameters.AddWithValue("@rta_id_ta_" & x, taxAllowVal(x))
                    'commandDB1.Parameters.AddWithValue("@emp_rta_deleted_ta_" & x, cItem.emp_rta_deleted)
                Next
                For x = 0 To comDeVal.Count - 1 Step 1
                    commandDB1.Parameters.AddWithValue("@comde_id_" & x, comDeVal(x))
                    commandDB1.Parameters.AddWithValue("@emp_comde_" & x, comDeVal(x))
                    commandDB1.Parameters.AddWithValue("@emp_comde_start_date_" & x, comDeVal(x))
                    commandDB1.Parameters.AddWithValue("@emp_comde_end_date_" & x, comDeVal(x))
                    commandDB1.Parameters.AddWithValue("@emp_deduct_type_" & x, comDeVal(x))
                    'commandDB1.Parameters.AddWithValue("@emp_comde_deleted_" & x, cItem.emp_comde_deleted)
                Next
                For x = 0 To leaveVal.Count - 1 Step 1
                    commandDB1.Parameters.AddWithValue("@leave_id_" & x, leaveVal(x))
                    commandDB1.Parameters.AddWithValue("@leave_used_" & x, leaveVal(x))
                Next

                commandDB1.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
        Return cReturn
    End Function
    Friend Function EmployeeUpdateFile(ByVal cItem As EmployeeInfo) As EmployeeInfo
        Dim cReturn As New EmployeeInfo
        Try

            Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                SQLConnect.Open()

                Dim xSQL As New StringBuilder
                'xSQL.AppendLine("START TRANSACTION;")
                xSQL.AppendLine("UPDATE employee ")
                xSQL.AppendLine("SET ")
                xSQL.AppendLine("    last_name = @last_name, ")
                xSQL.AppendLine("    first_name = @first_name, ")
                xSQL.AppendLine("    middle_name = @middle_name, ")
                xSQL.AppendLine("    birthday = @birthday, ")
                xSQL.AppendLine("    mobile = @mobile, ")
                xSQL.AppendLine("    telephone = @telephone, ")
                xSQL.AppendLine("    email = @email, ")
                xSQL.AppendLine("    nationality= @nationality, ")
                xSQL.AppendLine("    department_id = @department_id, ")
                xSQL.AppendLine("    job_title_id = @job_title_id, ")
                xSQL.AppendLine("    employment_status = @employment_status, ")
                xSQL.AppendLine("    date_hired = @date_hired, ")
                xSQL.AppendLine("    address = @address, ")
                xSQL.AppendLine("    job_status = @job_status, ")
                xSQL.AppendLine("    date_resigned = @date_resigned, ")
                xSQL.AppendLine("    basic_salary = @basic_salary, ")
                xSQL.AppendLine("    daily_rate = @daily_rate, ")
                xSQL.AppendLine("    hour_rate = @hour_rate, ")
                xSQL.AppendLine("    def_time_in = @def_time_in, ")
                xSQL.AppendLine("    def_time_out = @def_time_out, ")
                xSQL.AppendLine("    w_13monthpay = @w_13monthpay, ")
                xSQL.AppendLine("    tin_no = @tin_no, ")
                xSQL.AppendLine("    sss_no = @sss_no, ")
                xSQL.AppendLine("    pagibig_no = @pagibig_no, ")
                xSQL.AppendLine("    philhealth_no = @philhealth_no, ")
                xSQL.AppendLine("    tax_comp = @tax_comp, ")
                xSQL.AppendLine("    is_deleted = @is_deleted, ")
                xSQL.AppendLine("    def_shift_id = @def_shift_id, ")
                xSQL.AppendLine("    emp_last_employer = @emp_last_employer, ")
                xSQL.AppendLine("    prev_employer_date_resigned = @prev_employer_date_resigned, ")
                xSQL.AppendLine("    acu_id = @acu_id, ")
                'xSQL.AppendLine("    shift_id, ")
                xSQL.AppendLine("    w_sss = @w_sss, ")
                xSQL.AppendLine("    w_hdmf = @w_hdmf, ")
                xSQL.AppendLine("    w_philhealth = @w_philhealth ")
                xSQL.AppendLine("WHERE code = @code")
                'xSQL.AppendLine("COMMIT;")

                Dim commandDB1 As New MySqlCommand(xSQL.ToString, SQLConnect)
                commandDB1.Parameters.AddWithValue("@last_name", cItem.last_name)
                commandDB1.Parameters.AddWithValue("@first_name", cItem.first_name)
                commandDB1.Parameters.AddWithValue("@middle_name", cItem.middle_name)
                commandDB1.Parameters.AddWithValue("@birthday", cItem.birthday)
                commandDB1.Parameters.AddWithValue("@mobile", cItem.mobile)
                commandDB1.Parameters.AddWithValue("@telephone", cItem.telephone)
                commandDB1.Parameters.AddWithValue("@email", cItem.email)
                commandDB1.Parameters.AddWithValue("@nationality", cItem.nationality)
                commandDB1.Parameters.AddWithValue("@department_id", cItem.department_id)
                commandDB1.Parameters.AddWithValue("@job_title_id", cItem.job_title_id)
                commandDB1.Parameters.AddWithValue("@employment_status", cItem.employment_status)
                commandDB1.Parameters.AddWithValue("@date_hired", cItem.date_hired)
                commandDB1.Parameters.AddWithValue("@address", cItem.address)
                commandDB1.Parameters.AddWithValue("@job_status", cItem.job_status)
                commandDB1.Parameters.AddWithValue("@date_resigned", cItem.date_resigned)
                commandDB1.Parameters.AddWithValue("@basic_salary", cItem.basic_salary)
                commandDB1.Parameters.AddWithValue("@daily_rate", cItem.daily_rate)
                commandDB1.Parameters.AddWithValue("@hour_rate", cItem.hour_rate)
                commandDB1.Parameters.AddWithValue("@def_time_in", cItem.def_time_in)
                commandDB1.Parameters.AddWithValue("@def_time_out", cItem.def_time_out)
                commandDB1.Parameters.AddWithValue("@w_13monthpay", cItem.w_13monthpay)
                commandDB1.Parameters.AddWithValue("@tin_no", cItem.tin_no)
                commandDB1.Parameters.AddWithValue("@sss_no", cItem.sss_no)
                commandDB1.Parameters.AddWithValue("@pagibig_no", cItem.pagibig_no)
                commandDB1.Parameters.AddWithValue("@philhealth_no", cItem.philhealth_no)
                commandDB1.Parameters.AddWithValue("@tax_comp", cItem.tax_comp)
                commandDB1.Parameters.AddWithValue("@is_deleted", cItem.is_deleted)
                commandDB1.Parameters.AddWithValue("@def_shift_id", cItem.def_shift_id)
                commandDB1.Parameters.AddWithValue("@emp_last_employer", cItem.emp_last_employer)
                commandDB1.Parameters.AddWithValue("@prev_employer_date_resigned", cItem.prev_employer_date_resigned)
                commandDB1.Parameters.AddWithValue("@acu_id", cItem.acu_id)
                commandDB1.Parameters.AddWithValue("@w_sss", cItem.w_sss)
                commandDB1.Parameters.AddWithValue("@w_hdmf", cItem.w_hdmf)
                commandDB1.Parameters.AddWithValue("@w_philhealth", cItem.w_philhealth)
                commandDB1.Parameters.AddWithValue("@code", cItem.code)
                commandDB1.ExecuteNonQuery()
            End Using


        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = cItem
        Return cReturn
    End Function
    Friend Function EmpListDDL() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    `code` as 'emp_id', ")
            xSQL.AppendLine("   concat(first_name, ' ' ,middle_name, ' ' ,last_name) as 'fullname'")
            xSQL.AppendLine("FROM employee")


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
    Friend Function EmployeeGetFile(ByVal pEmployee_id As String) As EmployeeInfo
        Dim dt As New EmployeeInfo
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("    `code`, ")
            xSQL.AppendLine("    last_name, ")
            xSQL.AppendLine("    first_name, ")
            xSQL.AppendLine("    middle_name, ")
            xSQL.AppendLine("    birthday, ")
            xSQL.AppendLine("    mobile, ")
            xSQL.AppendLine("    telephone, ")
            xSQL.AppendLine("    email, ")
            xSQL.AppendLine("    nationality, ")
            xSQL.AppendLine("    department_id, ")
            xSQL.AppendLine("    job_title_id, ")
            xSQL.AppendLine("    employment_status, ")
            xSQL.AppendLine("    date_hired, ")
            xSQL.AppendLine("    address, ")
            xSQL.AppendLine("    job_status, ")
            xSQL.AppendLine("    date_resigned, ")
            xSQL.AppendLine("    basic_salary, ")
            xSQL.AppendLine("    daily_rate, ")
            xSQL.AppendLine("    hour_rate, ")
            xSQL.AppendLine("    def_time_in, ")
            xSQL.AppendLine("    def_time_out, ")
            xSQL.AppendLine("    w_13monthpay, ")
            xSQL.AppendLine("    tin_no, ")
            xSQL.AppendLine("    sss_no, ")
            xSQL.AppendLine("    pagibig_no, ")
            xSQL.AppendLine("    philhealth_no, ")
            xSQL.AppendLine("    tax_comp, ")
            xSQL.AppendLine("    is_deleted, ")
            xSQL.AppendLine("    def_shift_id, ")
            xSQL.AppendLine("    emp_last_employer, ")
            xSQL.AppendLine("    prev_employer_date_resigned, ")
            xSQL.AppendLine("    acu_id, ")
            'xSQL.AppendLine("    shift_id, ")
            xSQL.AppendLine("    w_sss, ")
            xSQL.AppendLine("    w_hdmf, ")
            xSQL.AppendLine("    w_philhealth ")
            xSQL.AppendLine("FROM employee ")
            xSQL.AppendLine("WHERE code = @code")

            Try
                Using SQLConnect As New MySqlConnection(My.Settings.DBConn)
                    SQLConnect.Open()
                    Dim SQLCommand As New MySqlCommand(xSQL.ToString, SQLConnect)
                    SQLCommand.Parameters.AddWithValue("@code", pEmployee_id)
                    Dim da As New MySqlDataAdapter(SQLCommand)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    If ds.Tables.Count <> 0 Then
                        For Each dr In ds.Tables(0).Rows
                            'dt.Found = True
                            If Not IsDBNull(dr("code")) Then dt.code = dr("code")
                            If Not IsDBNull(dr("last_name")) Then dt.last_name = dr("last_name")
                            If Not IsDBNull(dr("first_name")) Then dt.first_name = dr("first_name")
                            If Not IsDBNull(dr("middle_name")) Then dt.middle_name = dr("middle_name")
                            If Not IsDBNull(dr("birthday")) Then dt.birthday = dr("birthday")
                            If Not IsDBNull(dr("mobile")) Then dt.mobile = dr("mobile")
                            If Not IsDBNull(dr("telephone")) Then dt.telephone = dr("telephone")
                            If Not IsDBNull(dr("email")) Then dt.email = dr("email")
                            If Not IsDBNull(dr("nationality")) Then dt.nationality = dr("nationality")
                            If Not IsDBNull(dr("department_id")) Then dt.department_id = dr("department_id")
                            If Not IsDBNull(dr("job_title_id")) Then dt.job_title_id = dr("job_title_id")
                            If Not IsDBNull(dr("employment_status")) Then dt.employment_status = dr("employment_status")
                            If Not IsDBNull(dr("date_hired")) Then dt.date_hired = dr("date_hired")
                            If Not IsDBNull(dr("address")) Then dt.address = dr("address")
                            If Not IsDBNull(dr("job_status")) Then dt.job_status = dr("job_status")
                            If Not IsDBNull(dr("date_resigned")) Then dt.date_resigned = dr("date_resigned")
                            If Not IsDBNull(dr("basic_salary")) Then dt.basic_salary = dr("basic_salary")
                            If Not IsDBNull(dr("daily_rate")) Then dt.daily_rate = dr("daily_rate")
                            If Not IsDBNull(dr("hour_rate")) Then dt.hour_rate = dr("hour_rate")
                            If Not IsDBNull(dr("def_time_in")) Then dt.def_time_in = dr("def_time_in")
                            If Not IsDBNull(dr("def_time_out")) Then dt.def_time_out = dr("def_time_out")
                            If Not IsDBNull(dr("w_13monthpay")) Then dt.w_13monthpay = dr("w_13monthpay")
                            If Not IsDBNull(dr("tin_no")) Then dt.tin_no = dr("tin_no")
                            If Not IsDBNull(dr("sss_no")) Then dt.sss_no = dr("sss_no")
                            If Not IsDBNull(dr("pagibig_no")) Then dt.pagibig_no = dr("pagibig_no")
                            If Not IsDBNull(dr("philhealth_no")) Then dt.philhealth_no = dr("philhealth_no")
                            If Not IsDBNull(dr("tax_comp")) Then dt.tax_comp = dr("tax_comp")
                            'If Not IsDBNull(dr("def_shift_id")) Then dt.def_shift_id = dr("def_shift_id")
                            If Not IsDBNull(dr("emp_last_employer")) Then dt.emp_last_employer = dr("emp_last_employer")
                            If Not IsDBNull(dr("prev_employer_date_resigned")) Then dt.prev_employer_date_resigned = dr("prev_employer_date_resigned")
                            If Not IsDBNull(dr("acu_id")) Then dt.acu_id = dr("acu_id")
                            If Not IsDBNull(dr("w_sss")) Then dt.w_sss = dr("w_sss")
                            If Not IsDBNull(dr("w_hdmf")) Then dt.w_hdmf = dr("w_hdmf")
                            If Not IsDBNull(dr("w_philhealth")) Then dt.w_philhealth = dr("w_philhealth")
                            'If Not IsDBNull(dr("telephone")) Then dt.telephone = dr("telephone")
                        Next
                    End If
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            'sadsdasdas
            Throw ex
        End Try
        Return dt
    End Function
    'WOOOOOOOOOOOOOOOHHHHHHHHHHHHHHh
End Class
