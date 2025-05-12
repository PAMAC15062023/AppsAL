Imports System
Imports System.Data.OleDb
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Text
Imports System.Drawing
Imports Excel
Imports System.Runtime.InteropServices
Partial Class HR_HR_PAMACHRBANKMIS
    Inherits System.Web.UI.Page

    Dim objcon As New Ccommon()
    'Dim sqlcon As New OleDbConnection
    Dim sqlcmd, sqlcmd1 As OleDbCommand
    'Dim sqlad As OleDbDataAdapter
    Dim sqlds As New DataSet
    Dim i, cnt, row, col As Integer
    'Dim fsys As Directory
    'Dim var As String
    Dim xls As New Excel.Application
    
    Dim qry As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlcon As New OleDbConnection

        sqlcon = New OleDbConnection
        sqlcon.ConnectionString = objcon.ConnectionString
        sqlcon.Open()
        If ddlyear.Items.Count = 0 Then
            year()
        End If
    End Sub
    Public Function getyear()

        Dim dt As New Data.DataTable
        Dim ds As New DataSet
        Dim sqlcon As New OleDbConnection
        Dim sqlad As OleDbDataAdapter

        qry = "select substring(convert(varchar(11),getdate(),113),7,8) -1  as year union select substring(convert(varchar(11),getdate(),113),7,8) as year " & _
                " Union select substring(convert(varchar(11),getdate(),113),7,8) + 1 as year "
        sqlad = New OleDbDataAdapter(qry, objcon.ConnectionString)
        sqlad.Fill(ds, "Search")
        dt = ds.Tables("Search")
        Return dt
        Return getyear

    End Function
    Public Sub year()
        Dim dt As New Data.DataTable
        dt = getyear()
        If dt.Rows.Count > 0 Then
            ddlyear.DataSource = dt

            ddlyear.DataTextField = "Year"
            ddlyear.DataValueField = "year"
            ddlyear.DataBind()
            ddlyear.SelectedIndex = 1
        End If
    End Sub

    Public Function getbank1()
        Dim sqlcon As New OleDbConnection
        Dim sqlad As OleDbDataAdapter
        Dim dt As New Data.DataTable
        Dim ds As New DataSet
        qry = "Exec PAMACBANKMIS '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "'"
        sqlad = New OleDbDataAdapter(qry, objcon.ConnectionString)

        sqlad.Fill(ds, "Search")
        dt = ds.Tables("Search")
        Return dt
        Return getbank1()
    End Function
    Public Function getbank()
        Dim sqlcon As New OleDbConnection
        Dim sqlad As OleDbDataAdapter
        Dim dt As New Data.DataTable
        Dim ds As New DataSet
        qry = "Select Bankid,Bankname from Bank_master order by bankid"
        sqlad = New OleDbDataAdapter(qry, objcon.ConnectionString)

        sqlad.Fill(ds, "Search")
        dt = ds.Tables("Search")
        Return dt
        Return getbank()
    End Function
    Public Function getbank2()
        Dim sqlcon As New OleDbConnection
        Dim sqlad, sqlad1 As OleDbDataAdapter
        Dim dt1, dt2, dt3 As New Data.DataTable
        Dim ds As New DataSet
        Dim c As Object
        Dim i, j, a As Integer
        Dim dr, dr1, dr2, dr3, dr4, dr5, dr6, dr7, dr8, dr9 As OleDbDataReader
        Dim bid, bankname, emp As Object
        Dim bankid, banknam, emptype As String
        c = ""
        i = 0
        j = 0
        a = 0
        dt1 = getbank1()
        dt2 = getbank()
        qry = "update bank_detail set chq=0,chq#=0,total=0,total#=0"
        dr = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
        For i = 0 To dt2.Rows.Count - 1
            
            bankname = dt2.Rows.Item(i).Item("BankName")
            banknam = bankname.ToString()
            bid = dt2.Rows.Item(i).Item("bankid")
            bankid = bid.ToString()
            qry = "Exec sp_rename 'bank_detail." & bankid & "','" & banknam & "#" & "','column'"
            dr1 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
            qry = "Select distinct a.emp_type + a.location AS Emp_Type from bank_detail a,employee_salary_detail1 b,employee_master c,bank_master d " & _
                    " where b.emp_id=c.emp_id and a.emp_type=c.emp_type and b.location=c.centre_id and c.name_of_bank=d.bankname and name_of_bank='" & banknam & "' and payout_month='" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & "'"
            sqlad1 = New OleDbDataAdapter(qry, objcon.ConnectionString)
            sqlad1.Fill(ds, "Search")

            dt3 = ds.Tables("Search")
            For j = 0 To dt3.Rows.Count - 1
                emp = dt3.Rows.Item(j).Item("emp_type")
                emptype = emp.ToString()
                qry = "EXEC UPDATE_bank '" & banknam & "', '" & emptype & "','" & ddlmonth.SelectedValue & " " + ddlyear.SelectedValue + "'"
                dr2 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
                qry = "select charindex(' ','" & banknam & "',1) as Value"
                c = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, qry).ToString()
                'dr3.Read()
                'c = dr3("Value").ToString()
                a = Convert.ToInt32(c.ToString())
                If a = 0 Then
                    qry = "update a set " & banknam & "=b.netsalary," & banknam & "#" + "=b.total from bank_detail a,bank_detail2 b where a.emp_type=b.emp_type and a.location=b.location and name_of_bank='" + banknam + "' and a.emp_type=left('" + emptype + "',1)"
                    dr4 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
                    qry = "update a set a.total=a.total+b.netsalary,total#=total#+b.total from bank_detail a, bank_detail2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND NAME_OF_BANK = '" + banknam + "' and a.emp_type=left('" + emptype + "',1)"
                    dr6 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)

                Else

                    qry = "Update A set [" & banknam & "] = B.NETSALARY, [" + banknam + "#" + "] =b.Total from bank_detail a, bank_detail2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND NAME_OF_BANK = '" + banknam + "' and a.emp_type=left('" + emptype + "',1)"
                    dr9 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)

                    qry = "update a set a.total=a.total+b.netsalary,total#=total#+b.total from bank_detail a, bank_detail2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND NAME_OF_BANK = '" + banknam + "' and a.emp_type=left('" + emptype + "',1)"
                    dr7 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)


                End If
                qry = "DRop table bank_detail2"
                dr5 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
                dt3.Clear()
            Next
        Next
        qry = "select distinct a.emp_type + a.location AS Emp_Type from bank_detail a,employee_salary_detail1 b,employee_master c " & _
                   " where b.emp_id=c.emp_id and a.emp_type=c.emp_type and b.location=c.centre_id and payout_month='" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "' and name_of_bank not in(Select Bankname from bank_master)"
        Dim dts4 As New DataSet
        Dim dt6 As New Data.DataTable
        Dim odt4 As New OleDbDataAdapter
        odt4 = New OleDbDataAdapter(qry, objcon.ConnectionString)
        odt4.Fill(dts4, "Search")
        dt6 = dts4.Tables("Search")

        For j = 0 To dt6.Rows.Count - 1


            emp = dt6.Rows.Item(j).Item("Emp_type")
            emptype = emp.ToString()
            qry = "EXEC UPDATE_bank '', '" + emptype + "', '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "'"
            Dim odr, odr1, od As OleDbDataReader
            odr = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
            qry = "UPDATE a SET chq=b.NETSALARY,chq#=B.TOTAL from bank_detail a,bank_detail2 b where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION and a.emp_type=left('" + emptype + "',1) "
            odr1 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
            qry = "update a set a.total=a.total+b.netsalary,total#=total#+b.total from bank_detail a, bank_detail2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND a.emp_type=left('" + emptype + "',1)"
            dr8 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)

            qry = "DRop table bank_detail2"
            od = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
        Next
        Dim su As New Data.DataTable
        Dim su2 As New DataSet
        Dim su1 As New OleDbDataAdapter
        qry = "SELECT * FROM bank_DETAiL order by emp_type desc"
        su1 = New OleDbDataAdapter(qry, objcon.ConnectionString)
        su1.Fill(su2, "Search")
        SU = su2.Tables("Search")

        Return su

        Return getbank2()

    End Function
    Public Sub getbank3()
        Dim dt As New Data.DataTable
        Dim odr As OleDbDataReader
        dt = getbank2()
        If (dt.Rows.Count > 0) Then

            gvmis.DataSource = dt
            gvmis.DataBind()
            gvmis.Visible = True
            lblmsg.Visible = False

        Else

            gvmis.DataSource = dt
            gvmis.DataBind()
            gvmis.Visible = False
            lblmsg.Text = "No Data Exists For Selected Month and Year"
            lblmsg.Visible = True
        End If

        qry = "drop table bank_detail"
        odr = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
    End Sub



    Protected Sub btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreport.Click
        getbank3()
    End Sub

    Protected Sub Export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Export.Click
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim j As Integer = 0
        Dim typeol As OleDbDataAdapter
        Dim typedt As New Data.DataTable
        Dim typeds As New DataSet
        Dim bankol As OleDbDataAdapter
        Dim bankdt As New Data.DataTable
        Dim bankds As New DataSet
        Dim bankname As Object
        Dim type As Object
        Dim banke As String
        Dim emp As String
        Dim qry1 As String
        Dim cell As String


        Dim oExcel As Excel.Application = New Excel.Application
        xls.Workbooks.Close()
        Dim xlwb As Workbook = xls.Workbooks.Add()

        qry = "select distinct bankname from bank_master"
        bankol = New OleDbDataAdapter(qry, objcon.ConnectionString)
        bankol.Fill(bankds, "Search")
        bankdt = bankds.Tables("Search")
        qry1 = "select distinct emp_type from employee_master"
        typeol = New OleDbDataAdapter(qry1, objcon.ConnectionString)
        typeol.Fill(typeds, "Search")
        typedt = typeds.Tables("Search")
        For j = 0 To bankdt.Rows.Count - 1
            bankname = bankdt.Rows.Item(j).Item("BankName")
            banke = bankname.ToString()
            If bankdt.Rows.Count > 0 Then
                


                For k = 0 To typedt.Rows.Count - 1
                    type = typedt.Rows.Item(k).Item("emp_type")
                    emp = type.ToString()



                    xlwb.Sheets.Add()
                    Dim sheet As Excel.Worksheet = xls.ActiveSheet
                    sheet.Name = banke + "-" + emp

                    xls.Cells.EntireColumn.ColumnWidth = 18
                    xls.ActiveWindow.DisplayGridlines = False
                    xls.Cells.Range("A1").Cells.Value = "PAMAC FINSERVE PVT. LTD."
                    xls.Cells.Range("A1").Cells.Font.Bold = True
                    xls.Cells.Range("A1").Cells.Font.Name = "Arial"
                    xls.Cells.Range("A1").Cells.Font.Size = 8

                    xls.Cells.Range("A2").Cells.Value = "PAMAC Bank MIS FOR DATE:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " ,Bank: " + banke + " and Type: " + emp + ""
                    xls.Cells.Range("A2").Cells.Font.Bold = True
                    xls.Cells.Range("A2").Cells.Font.Name = "Arial"
                    xls.Cells.Range("A2").Cells.Font.Size = 8

                    xls.Cells.Range("A4").Cells.Value = "Sr. No."
                    xls.Cells.Range("A4").Cells.ColumnWidth = 4
                    xls.Cells.Range("A4").Cells.Font.Bold = True
                    xls.Cells.Range("A4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("A4").Cells.Font.Size = 8

                    xls.Cells.Range("B4").Cells.Value = "Account Number"
                    xls.Cells.Range("B4").Cells.Font.Bold = True
                    xls.Cells.Range("B4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("B4").Cells.Font.Size = 8

                    xls.Cells.Range("C4").Cells.Value = "Name Of Card Holder"
                    xls.Cells.Range("C4").Cells.Font.Bold = True
                    xls.Cells.Range("C4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("C4").Cells.Font.Size = 8

                    xls.Cells.Range("D4").Cells.Value = "Net Fees"
                    xls.Cells.Range("D4").Cells.Font.Bold = True
                    xls.Cells.Range("D4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("D4").Cells.Font.Size = 8

                    xls.Cells.Range("E4").Cells.Value = "Location"
                    xls.Cells.Range("E4").Cells.Font.Bold = True
                    xls.Cells.Range("E4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("E4").Cells.Font.Size = 8

                    xls.Cells.Range("F4").Cells.Value = "Remarks"
                    xls.Cells.Range("F4").Cells.Font.Bold = True
                    xls.Cells.Range("F4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("F4").Cells.Font.Size = 8

                    Dim banktypeol As OleDbDataAdapter
                    Dim banktypedt As New Data.DataTable
                    Dim banktypeds As New DataSet
                    qry = "Exec PAMACBANKMISTYPEWISE '" + banke + "','" + emp + "' "
                    banktypeol = New OleDbDataAdapter(qry, objcon.ConnectionString)
                    banktypeol.Fill(banktypeds, "Search")
                    banktypedt = banktypeds.Tables("Search")
                    For i = 0 To banktypedt.Rows.Count - 1
                        col = 0
                        Dim sun As Integer
                        sun = 0

                        'For col = 0 To colCount - 1
                        cell = GetExcelColumn(sun, col + 5).ToString()
                        xls.Range(cell).Value = banktypedt.Rows.Item(i).Item("SRNO").ToString()
                        cell = GetExcelColumn(sun + 1, col + 5).ToString()
                        xls.Range(cell).Value = banktypedt.Rows.Item(i).Item("Account Number").ToString()
                        cell = GetExcelColumn(sun + 2, col + 5).ToString()
                        xls.Range(cell).Value = banktypedt.Rows.Item(i).Item("Name of card Holder").ToString()
                        cell = GetExcelColumn(sun + 3, col + 5).ToString()
                        xls.Range(cell).Value = banktypedt.Rows.Item(i).Item("net fees").ToString()
                        cell = GetExcelColumn(sun + 4, col + 5).ToString()
                        xls.Range(cell).Value = banktypedt.Rows.Item(i).Item("location").ToString()
                        cell = GetExcelColumn(sun + 5, col + 5).ToString()
                        xls.Range(cell).Value = banktypedt.Rows.Item(i).Item("Remarks").ToString()
                        col = col + 1
                    Next
                Next
            End If

        Next

        xls.Visible = True
        xlwb.Sheets.Add()
        Dim sheet3 As Excel.Worksheet = xls.ActiveSheet
        sheet3.Name = "INDEX"
        xls.Cells.EntireColumn.ColumnWidth = 18
        xls.ActiveWindow.DisplayGridlines = False
        xls.ActiveWindow.DisplayGridlines = False
        xls.Cells.Range("A1").Cells.Value = "PAMAC FINSERVE PVT. LTD."
        xls.Cells.Range("A1").Cells.Font.Bold = True
        xls.Cells.Range("A1").Cells.Font.Name = "Arial"
        xls.Cells.Range("A1").Cells.Font.Size = 8

        xls.Cells.Range("A2").Cells.Value = "PAMAC BANK MIS FOR:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " "
        xls.Cells.Range("A2").Cells.Font.Bold = True
        xls.Cells.Range("A2").Cells.Font.Name = "Arial"
        xls.Cells.Range("A2").Cells.Font.Size = 8

        xls.Cells.Range("A4").Cells.Value = "Company"
        xls.Cells.Range("A4").Cells.Font.Bold = True
        xls.Cells.Range("A4").Cells.Font.Name = "Arial"
        xls.Cells.Range("A4").Cells.Font.Size = 8

        xls.Cells.Range("B4").Cells.Value = "Location"
        xls.Cells.Range("B4").Cells.Font.Bold = True
        xls.Cells.Range("B4").Cells.Font.Name = "Arial"
        xls.Cells.Range("B4").Cells.Font.Size = 8

        xls.Cells.Range("C4").Cells.Value = "Category"
        xls.Cells.Range("C4").Cells.Font.Bold = True
        xls.Cells.Range("C4").Cells.Font.Name = "Arial"
        xls.Cells.Range("C4").Cells.Font.Size = 8

        xls.Cells.Range("D4").Cells.Value = "Cluster"
        xls.Cells.Range("D4").Cells.Font.Bold = True
        xls.Cells.Range("D4").Cells.Font.Name = "Arial"
        xls.Cells.Range("D4").Cells.Font.Size = 8

        qry = "select Bankname from bank_master order by bankid"
        Dim bankol1 As OleDbDataAdapter
        Dim bankdt1 As New Data.DataTable
        Dim bankds1 As New DataSet
        bankol1 = New OleDbDataAdapter(qry, objcon.ConnectionString)
        bankol1.Fill(bankds1, "Search")
        bankdt1 = bankds1.Tables("Search")
        Dim a As Integer = 0
        Dim sum2 As Integer = 0
        Dim col1 As Integer = 0

        For a = 0 To bankdt1.Rows.Count - 1

            cell = GetExcelColumn1(sum2, col1 + 4).ToString()
            xls.Range(cell).Value = bankdt.Rows.Item(a).Item("Bankname").ToString()
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8

            cell = GetExcelColumn1(sum2 + 1, col1 + 4).ToString()
            xls.Range(cell).Value = "#"
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8
            sum2 = sum2 + 2
            '    col = col + 1
        Next
        cell = Len(cell)
        If Len(cell) = 2 Then
            col = Left(cell, 1)
            cell = GetExcelColumn1(sum2, col1 + 4).ToString()
            xls.Range(cell).Value = "CHQ"
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8

            cell = GetExcelColumn1(sum2 + 1, col1 + 4).ToString()
            xls.Range(cell + 1).Value = "CHQ#"
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8

            cell = GetExcelColumn1(sum2 + 2, col1 + 4).ToString()
            xls.Range(cell).Value = "TOTAL"
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8

            cell = GetExcelColumn1(sum2 + 3, col1 + 4).ToString()
            xls.Range(cell).Value = "TOTAL#"
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8

        Else
            col = Left(cell, 2)
            cell = GetExcelColumn1(sum2, col1 + 4).ToString()
            xls.Range(cell).Value = "CHQ"
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8

            cell = GetExcelColumn1(sum2 + 1, col1 + 4).ToString()
            xls.Range(cell).Value = "CHQ#"
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8

            cell = GetExcelColumn1(sum2 + 2, col1 + 4).ToString()
            xls.Range(cell).Value = "TOTAL"
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8

            cell = GetExcelColumn1(sum2 + 3, col1 + 4).ToString()
            xls.Range(cell).Value = "TOTAL#"
            xls.Cells.Range(cell).Cells.Font.Bold = True
            xls.Cells.Range(cell).Cells.Font.Name = "Arial"
            xls.Cells.Range(cell).Cells.Font.Size = 8

            sum2 = sum2 + 1

        End If

        Dim payol As New OleDbDataAdapter
        Dim paydt As New Data.DataTable
        Dim payds As New DataSet
        paydt = getbank2()
        Dim c As Integer = 0
        Dim b As Integer = 0
        Dim col3 As Integer = 0



        For b = 0 To paydt.Rows.Count - 1
            Dim sum1 As Integer = 0
            cell = GetExcelColumn(sum1, col3 + 5).ToString()
            xls.Range(cell).Value = paydt.Rows.Item(b).Item(0).ToString()

            cell = GetExcelColumn(sum1 + 1, col3 + 5).ToString()
            xls.Range(cell).Value = paydt.Rows.Item(b).Item(1).ToString()

            cell = GetExcelColumn(sum1 + 2, col3 + 5).ToString()
            xls.Range(cell).Value = paydt.Rows.Item(b).Item(2).ToString()

            cell = GetExcelColumn(sum1 + 3, col3 + 5).ToString()
            xls.Range(cell).Value = paydt.Rows.Item(b).Item(3).ToString()

             col3 = col3 + 1
            Dim sum4 As Integer = 0
            For c = 4 To paydt.Columns.Count - 4

                cell = GetExcelColumn1(sum4, col3 + 4).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(c).ToString()

                sum4 = sum4 + 1

            Next
            Dim sum5 As String
            Dim d As Integer = 0
            'cell = Len(cell)
            If Len(cell) = 2 Then
                sum5 = Left(cell, 1)
                For d = c To paydt.Columns.Count - 1
                    cell = GetExcelColumn2(sum5, col3 + 4).ToString()
                    xls.Range(cell).Value = paydt.Rows.Item(b).Item(d).ToString()
                    sum5 = Left(cell, 1)
                Next
            Else
                sum5 = Left(cell, 2)
                For d = c To paydt.Columns.Count - 1
                    cell = GetExcelColumn2(sum5, col3 + 4).ToString()
                    xls.Range(cell).Value = paydt.Rows.Item(b).Item(d).ToString()
                    sum5 = Left(cell, 2)
                Next
            End If

        Next
        '  Dim qry As String = ""
        qry = "drop table bank_detail"
        Dim oder As OleDbDataReader
        oder = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
        xls.Sheets("sheet1").select()
        xls.ActiveWindow.SelectedSheets.Delete()
        xls.Sheets("sheet2").select()
        xls.ActiveWindow.SelectedSheets.Delete()
        xls.Sheets("sheet3").select()
        xls.ActiveWindow.SelectedSheets.Delete()

      
    End Sub
    Function GetExcelColumn(ByVal col As Integer, ByVal s As Integer) As String
        Dim result As String
        Select Case col
            Case 0  ' first column
                result = "A" & s
            Case 1
                result = "B" & s
            Case 2
                result = "C" & s
            Case 3
                result = "D" & s
            Case 4
                result = "E" & s
            Case 5
                result = "F" & s
            Case 6
                result = "G5"
            Case 7
                result = "H5"
            Case 8
                result = "I5"
            Case 9
                result = "J5"
            Case 10
                result = "K5"
            Case 11
                result = "L5"
            Case 12
                result = "M5"
            Case 13
                result = "N5"
            Case 14
                result = "O5"
            Case 15
                result = "P5"
            Case 16
                result = "Q5"
            Case 17
                result = "R5"
            Case 18
                result = "S5"
            Case 19
                result = "T5"
            Case 20
                result = "U5"
            Case 21
                result = "V5"
            Case 22
                result = "W5"
            Case 23
                result = "X5"
            Case 24
                result = "Y5"
            Case 25
                result = "Z5"
        End Select
        Return result
    End Function
    Function GetExcelColumn1(ByVal col As Integer, ByVal s As Integer) As String
        Dim result As String
        Select Case col
            Case 0  ' first column
                result = "E" & s
            Case 1
                result = "F" & s
            Case 2
                result = "G" & s
            Case 3
                result = "H" & s
            Case 4
                result = "I" & s
            Case 5
                result = "J" & s
            Case 6
                result = "K" & s
            Case 7
                result = "L" & s
            Case 8
                result = "M" & s
            Case 9
                result = "N" & s
            Case 10
                result = "O" & s
            Case 11
                result = "P" & s
            Case 12
                result = "Q" & s
            Case 13
                result = "R" & s
            Case 14
                result = "S" & s
            Case 15
                result = "T" & s
            Case 16
                result = "U" & s
            Case 17
                result = "V" & s
            Case 18
                result = "W" & s
            Case 19
                result = "X" & s
            Case 20
                result = "Y" & s

        End Select
        Return result
    End Function
    Function GetExcelColumn2(ByVal col2 As String, ByVal s As Integer) As String
        Dim result As String
        Select Case col2
            Case "E"  ' first column
                result = "F" & s
            Case "F"
                result = "G" & s
            Case "G"
                result = "H" & s
            Case "H"
                result = "I" & s
            Case "I"
                result = "J" & s
            Case "J"
                result = "K" & s
            Case "K"
                result = "L" & s
            Case "L"
                result = "M" & s
            Case "M"
                result = "N" & s
            Case "N"
                result = "O" & s
            Case "O"
                result = "P" & s
            Case "P"
                result = "Q" & s
            Case "Q"
                result = "R" & s
            Case "R"
                result = "S" & s
            Case "S"
                result = "T" & s
            Case "T"
                result = "U" & s
            Case "U"
                result = "V" & s
            Case "V"
                result = "W" & s
            Case "W"
                result = "X" & s
            Case "X"
                result = "Y" & s
            Case "Y"
                result = "Z" & s

        End Select
        Return result
    End Function
End Class
