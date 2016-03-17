Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class DTRUpload
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


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
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim dt As New DataTable
        Dim file As String

        Dim tColumn As Data.DataColumn          ' TABLE COLUMNS.

        tColumn = New Data.DataColumn("emp_code", System.Type.GetType("System.String"))
        dt.Columns.Add(tColumn)

        For Each file In FilePath
            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(FilePath)
            xlWorkSheet = xlWorkBook.Worksheets("sheet1")

            Dim infiniteLoop As Boolean = False
            Dim i As Integer = 5

            Do While infiniteLoop = False
                If Len(xlWorkSheet.Cells(i, 1).value) > 0 Then
                    ' dt.Columns.Add(New String())
                    dt.Rows.Add({xlWorkSheet.Cells(1, 1).value})

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
        Next file

     

       
    End Sub
End Class