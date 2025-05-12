Option Explicit On
'Option Strict On
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
Partial Class HR_HR_PAMACFEPAYOUT
    Inherits System.Web.UI.Page
    Dim objcon As New CCommon
    Dim sqlcmd, sqlcmd1 As OleDbCommand
    Dim sqlds As New DataSet
    Dim i, cnt, row, col As Integer
    Dim xls As New Excel.Application
    Dim qry, flag As String
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
   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlcon As New OleDbConnection
        sqlcon = New OleDbConnection
        sqlcon.ConnectionString = objcon.ConnectionString
        sqlcon.Open()
        If ddlyear.Items.Count = 0 Then
            year()
        End If

        If ddlcentre.Items.Count = 0 Then

            Dim dtcentre As New Data.DataTable()
            dtcentre = centre()
            ddlcentre.Items.Clear()

            ddlcentre.Items.Add("---All Centre---")
            ddlcentre.DataSource = dtcentre
            ddlcentre.DataTextField = "Centre_name"
            ddlcentre.DataValueField = "centre_id"
            ddlcentre.DataBind()
        End If
       


    End Sub
    Protected Function centre()
        Dim sqlcon As New OleDbConnection
        sqlcon = New OleDbConnection
        Dim ol As OleDbDataAdapter
        Dim dt As New Data.DataTable
        Dim ds As New DataSet
        Dim qry As String = ""
        qry = "Select centre_id,centre_name from centre_master order by centre_name"
        ol = New OleDbDataAdapter(qry, objcon.ConnectionString)
        ol.Fill(ds, "Search")
        dt = ds.Tables("Search")
        Return dt
        dt.Clear()
        Return centre()
    End Function
  
    Public Sub fecentre()
        Dim sqlcon As New OleDbConnection
        sqlcon = New OleDbConnection
        Dim feol As OleDbDataAdapter
        Dim fecdt As New Data.DataTable
        Dim fecds As New DataSet
        Dim qry As String = ""
        Dim flag As String = "b"
        qry = "Exec FEPAYOUTCENTREWISE   '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','" + ddlcentre.SelectedItem.ToString() + "','b'"
        feol = New OleDbDataAdapter(qry, objcon.ConnectionString)
        feol.Fill(fecds, "Search")
        fecdt = fecds.Tables("Search")
        If (fecdt.Rows.Count > 0) Then
            gvmis.DataSource = fecdt
            gvmis.DataBind()
            gvmis.Visible = True
        End If
    End Sub
    Public Function fecentreall()
        Dim sqlcon As New OleDbConnection
        sqlcon = New OleDbConnection
        Dim feol As OleDbDataAdapter
        Dim fecdt As New Data.DataTable
        Dim fecds As New DataSet
        Dim qry As String = ""
        Dim flag As String = "a"
        qry = "Exec FEPAYOUTCENTREWISE   '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','" + ddlcentre.SelectedItem.ToString() + "','a'"
        feol = New OleDbDataAdapter(qry, objcon.ConnectionString)
        feol.Fill(fecds, "Search")
        fecdt = fecds.Tables("Search")
        Return fecdt
    End Function

    Public Sub fecentreal()
        Dim fecdt As New Data.DataTable()
        fecdt = fecentreall()
        If (fecdt.Rows.Count > 0) Then
            gvmis.DataSource = fecdt
            gvmis.DataBind()
            gvmis.Visible = True
        End If
    End Sub
    Public Sub index()
        Dim sqlcon As New OleDbConnection
        Dim indol As OleDbDataAdapter
        Dim inddt As New Data.DataTable
        Dim indds As New DataSet
        Dim qry As String = ""
        qry = "Exec FEPAYOUTMIS '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "'"
        indol = New OleDbDataAdapter(qry, objcon.ConnectionString)
        indol.Fill(indds, "Search")
        inddt = indds.Tables("Search")
        If (inddt.Rows.Count > 0) Then
            gvmis.DataSource = inddt
            gvmis.DataBind()
            gvmis.Visible = True

        End If
    End Sub
    Public Function getreport()

        Dim FEdt As New Data.DataTable()
        Dim FEDS As New DataSet()
        Dim QRY As String = ""
        Dim SQLCON As New OleDbConnection
        Dim FEOLA As OleDbDataAdapter
        QRY = "exec FEPAYMIS '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "'"
        FEOLA = New OleDbDataAdapter(QRY, objcon.ConnectionString)
        FEOLA.Fill(FEDS, "Search")
        FEdt = FEDS.Tables("Search")
        Return FEdt
        Return getreport()
    End Function
    Public Function getbank()
        Dim QRY As String = ""
        Dim ODR As OleDbDataAdapter
        Dim ODS As New DataSet
        Dim ODTS As New Data.DataTable()
        QRY = "Select distinct bankname, bankid from bank_master order by bankid"
        ODR = New OleDbDataAdapter(QRY, objcon.ConnectionString)
        ODR.Fill(ODS, "Search")
        ODTS = ODS.Tables("Search")
        Return ODTS
        Return getbank()

    End Function
    Protected Function getbank1()

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
        dt1 = getreport()
        dt2 = getbank()
        qry = "update fe_salary set chq=0,chq#=0,total=0,total#=0"
        dr = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
        For i = 0 To dt2.Rows.Count - 1

            bankname = dt2.Rows.Item(i).Item("BankName")
            banknam = bankname.ToString()
            bid = dt2.Rows.Item(i).Item("bankid")
            bankid = bid.ToString()
            qry = "Exec sp_rename 'FE_SALARY." & bankid & "','" & banknam & "#" & "','column'"
            dr1 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
            qry = "Select distinct a.emp_type + a.location AS Emp_Type from FE_SALARY a,employee_salary_detail1 b,employee_master c,bank_master d " & _
                    " where b.emp_id=c.emp_id and designation_id='3' and a.emp_type=c.emp_type and b.location=c.centre_id and c.name_of_bank=d.bankname and name_of_bank='" & banknam & "' and payout_month='" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & "'"
            sqlad1 = New OleDbDataAdapter(qry, objcon.ConnectionString)
            sqlad1.Fill(ds, "Search")

            dt3 = ds.Tables("Search")
            For j = 0 To dt3.Rows.Count - 1
                emp = dt3.Rows.Item(j).Item("emp_type")
                emptype = emp.ToString()
                qry = "EXEC fepay_mis '" & banknam & "', '" & emptype & "','" & ddlmonth.SelectedValue & " " + ddlyear.SelectedValue + "'"
                dr2 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
                qry = "select charindex(' ','" & banknam & "',1) as Value"
                c = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, qry).ToString()
                'dr3.Read()
                'c = dr3("Value").ToString()
                a = Convert.ToInt32(c.ToString())
                If a = 0 Then
                    qry = "update a set " & banknam & "=b.netsalary," & banknam & "#" + "=b.total from fe_salary a,fe_salary2 b where a.emp_type=b.emp_type and a.location=b.location and name_of_bank='" + banknam + "' and a.emp_type=left('" + emptype + "',1)"
                    dr4 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
                    qry = "update a set a.total=a.total+b.netsalary,total#=total#+b.total from fe_salary a, fe_salary2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND NAME_OF_BANK = '" + banknam + "' and a.emp_type=left('" + emptype + "',1)"
                    dr6 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)

                Else

                    qry = "Update A set [" & banknam & "] = B.NETSALARY, [" + banknam + "#" + "] =b.Total from fe_salary a, fe_salary2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND NAME_OF_BANK = '" + banknam + "' and a.emp_type=left('" + emptype + "',1)"
                    dr9 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)

                    qry = "update a set a.total=a.total+b.netsalary,total#=total#+b.total from fe_salary a, fe_salary2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND NAME_OF_BANK = '" + banknam + "' and a.emp_type=left('" + emptype + "',1)"
                    dr7 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)


                End If
                qry = "DRop table fe_salary2"
                dr5 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
                dt3.Clear()
            Next
        Next
        qry = "select distinct a.emp_type + a.location AS Emp_Type from fe_salary a,employee_salary_detail1 b,employee_master c " & _
                   " where b.emp_id=c.emp_id and a.emp_type=c.emp_type and designation_id='3' and  b.location=c.centre_id and payout_month='" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "' and name_of_bank not in(Select Bankname from bank_master)"
        Dim dts4 As New DataSet
        Dim dt6 As New Data.DataTable
        Dim odt4 As New OleDbDataAdapter
        odt4 = New OleDbDataAdapter(qry, objcon.ConnectionString)
        odt4.Fill(dts4, "Search")
        dt6 = dts4.Tables("Search")

        For j = 0 To dt6.Rows.Count - 1


            emp = dt6.Rows.Item(j).Item("Emp_type")
            emptype = emp.ToString()
            qry = "EXEC fepay_mis '', '" + emptype + "', '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "'"
            Dim odr, odr1, od As OleDbDataReader
            odr = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
            qry = "UPDATE a SET chq=b.NETSALARY,chq#=B.TOTAL from fe_salary a,fe_salary2 b where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION and a.emp_type=left('" + emptype + "',1) "
            odr1 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
            qry = "update a set a.total=a.total+b.netsalary,total#=total#+b.total from fe_salary a, fe_salary2 B where A.EMP_TYPE = B.EMP_TYPE AND A.LOCATION = B.LOCATION AND a.emp_type=left('" + emptype + "',1)"
            dr8 = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)

            qry = "DRop table fe_salary2"
            od = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
        Next
        Dim su As New Data.DataTable
        Dim su2 As New DataSet
        Dim su1 As New OleDbDataAdapter
        qry = "SELECT * FROM fe_salary"
        su1 = New OleDbDataAdapter(qry, objcon.ConnectionString)
        su1.Fill(su2, "Search")
        su = su2.Tables("Search")

        Return su


    End Function
    Public Sub getbank2()
        Dim st As New Data.DataTable()
        st = getbank1()
        If st.Rows.Count > 0 Then

            gvmis.DataSource = st
            gvmis.DataBind()
            gvmis.Visible = True
            lblmsg.Visible = False

        Else

            gvmis.DataSource = st
            gvmis.DataBind()
            gvmis.Visible = False
            lblmsg.Text = "No Data Exists For Selected Month and Year"
            lblmsg.Visible = True

        End If
        Dim qry As String = ""
        qry = "drop table fe_salary"
        Dim oder As OleDbDataReader
        oder = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
    End Sub
    Public Sub client()
        Dim sqlcon As New OleDbConnection
        Dim cdt As New Data.DataTable()
        Dim cds As New DataSet
        Dim clo As OleDbDataAdapter
        Dim qry As String = ""
        qry = "Exec FE_CLIENT_MIS '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "'"
        clo = New OleDbDataAdapter(qry, objcon.ConnectionString)
        clo.Fill(cds, "Search")
        cdt = cds.Tables("Search")
        If cdt.Rows.Count > 0 Then
            gvmis.DataSource = cdt
            gvmis.DataBind()
            gvmis.Visible = True
        End If
    End Sub
    Protected Sub btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreport.Click
        If ddlreport.SelectedIndex = 1 And ddlcentre.SelectedIndex = 0 Then
            index()
        Else
            If ddlreport.SelectedIndex = 2 And ddlcentre.SelectedIndex = 0 Then
                getbank2()
            Else
                If ddlreport.SelectedIndex = 3 And ddlcentre.SelectedIndex = 0 Then
                    client()
                Else
                    If (ddlcentre.SelectedIndex <> 0) Then
                        fecentre()
                    End If

                End If

            End If


        End If
    End Sub

    Protected Sub Export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Export.Click
        If ddlreport.SelectedIndex = 1 And ddlcentre.SelectedIndex = 0 Then

            index()

            If gvmis.Rows.Count > 0 Then
                Dim attachment As String
                Dim sw As New StringWriter()
                Dim htw As HtmlTextWriter
                Dim tblspace As New Table()
                Dim tblrow As New TableRow()
                Dim tblcell As New TableCell()
                Dim tblrow1 As New TableRow()
                Dim tblcell1 As New TableCell()
                Dim frm As HtmlForm = New HtmlForm()
                Response.Clear()
                Response.Buffer = True
                attachment = "attachment; filename=PAMAC FE PAYOUT MIS.xls"
                Response.AddHeader("content-disposition", String.Format(attachment, "ExportedGridData"))
                Response.ContentType = "application/ms-excel"
                htw = New HtmlTextWriter(sw)
                tblcell.Text = " "
                tblcell1.ColumnSpan = 20
                'tblcell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/><b><font size='2'>PAMAC CPAN PAN INDIA STAFF DETAILS FOR : '" + ddlmonth.SelectedValue + " ' " " " + ddlyear.SelectedValue + " and " + ddlcentre.SelectedItem + "</font></b> <br/>"
                tblcell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/><b><font size='2'>PAMAC FE PAYOUT MIS FOR :" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & "  </font></b> <br/>"
                tblcell1.CssClass = "FormHeading"
                tblrow.Cells.Add(tblcell)
                tblrow1.Cells.Add(tblcell1)
                tblrow.Height = 20
                tblspace.Rows.Add(tblrow)
                tblspace.Rows.Add(tblrow1)
                frm.Attributes("runat") = "server"
                Controls.Add(frm)

                frm.Controls.Add(gvmis)

                tblspace.RenderControl(htw)
                Dim tbl As New Table()
                gvmis.EnableViewState = False
                'gvmis.GridLines = Data.Gridlines.Both
                gvmis.RenderControl(htw)
                Response.Write(sw.ToString())

                Response.End()
            End If
        Else

            If ddlreport.SelectedIndex = 2 And ddlcentre.SelectedIndex = 0 Then

                getbank2()

                If (gvmis.Rows.Count > 0) Then
                    Dim attachment As String
                    Dim sw As New StringWriter()
                    Dim htw As HtmlTextWriter
                    Dim tblspace As New Table()
                    Dim tblrow As New TableRow()
                    Dim tblcell As New TableCell()
                    Dim tblrow1 As New TableRow()
                    Dim tblcell1 As New TableCell()
                    Dim tbl As New Table()
                    Dim frm As HtmlForm = New HtmlForm()
                    attachment = "attachment; filename=PAMAC FE PAYOUT MIS.xls"
                    Response.Clear()
                    Response.Buffer = True
                    Response.AddHeader("content-disposition", String.Format(attachment, "ExportedGridData"))
                    Response.ContentType = "application/ms-excel"

                    htw = New HtmlTextWriter(sw)

                    tblcell.Text = " "
                    tblcell1.ColumnSpan = 20
                    'tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                    '               "<b><font size='2'>PAMAC CPA PAN INDIA DETAILS FOR : " + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + " And " + ddlcentre.SelectedItem + " </font></b> <br/>";
                    tblcell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/><b><font size='2'>PAMAC FE PAYOUT MIS FOR:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " </font></b> <br/>"
                    tblcell1.CssClass = "FormHeading"
                    tblrow.Cells.Add(tblcell)
                    tblrow1.Cells.Add(tblcell1)
                    tblrow.Height = 20
                    tblspace.Rows.Add(tblrow)
                    tblspace.Rows.Add(tblrow1)
                    frm.Attributes("runat") = "server"
                    Controls.Add(frm)

                    frm.Controls.Add(gvmis)

                    tblspace.RenderControl(htw)


                    gvmis.EnableViewState = False
                    'gvmis.GridLines = GridLines.Both
                    gvmis.RenderControl(htw)
                    Response.Write(sw.ToString())

                    Response.End()
                End If
            Else
                If ddlreport.SelectedIndex = 3 And ddlcentre.SelectedIndex = 0 Then
                    client()
                    If (gvmis.Rows.Count > 0) Then
                        Dim attachment As String
                        Dim sw As New StringWriter()
                        Dim htw As HtmlTextWriter
                        Dim tblspace As New Table()
                        Dim tblrow As New TableRow()
                        Dim tblcell As New TableCell()
                        Dim tblrow1 As New TableRow()
                        Dim tblcell1 As New TableCell()
                        Dim tbl As New Table()
                        Dim frm As HtmlForm = New HtmlForm()
                        attachment = "attachment; filename=PAMAC FE PAYOUT MIS.xls"
                        Response.Clear()
                        Response.Buffer = True
                        Response.ContentType = "application/ms-excel"
                        Response.AddHeader("content-disposition", String.Format(attachment, "ExportedGridData"))
                        htw = New HtmlTextWriter(sw)

                        tblcell.Text = " "
                        tblcell1.ColumnSpan = 20
                        tblcell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/><b><font size='2'>PAMAC FE PAYOUT MIS FOR:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " </font></b> <br/>"
                        tblcell1.CssClass = "FormHeading"
                        tblrow.Cells.Add(tblcell)
                        tblrow1.Cells.Add(tblcell1)
                        tblrow.Height = 20
                        tblspace.Rows.Add(tblrow)
                        tblspace.Rows.Add(tblrow1)
                        frm.Attributes("runat") = "server"
                        Controls.Add(frm)

                        frm.Controls.Add(gvmis)

                        tblspace.RenderControl(htw)


                        gvmis.EnableViewState = False
                        'gvmis.GridLines = GridLines.Both
                        gvmis.RenderControl(htw)
                        Response.Write(sw.ToString())

                        Response.End()
                    End If
                Else
                    If ddlcentre.SelectedIndex <> 0 Then
                        fecentre()
                        If (gvmis.Rows.Count > 0) Then
                            Dim attachment As String
                            Dim sw As New StringWriter()
                            Dim htw As HtmlTextWriter
                            Dim tblspace As New Table()
                            Dim tblrow As New TableRow()
                            Dim tblcell As New TableCell()
                            Dim tblrow1 As New TableRow()
                            Dim tblcell1 As New TableCell()
                            Dim tbl As New Table()
                            Dim frm As HtmlForm = New HtmlForm()
                            attachment = "attachment; filename=PAMAC FE PAYOUT MIS.xls"
                            Response.Clear()
                            Response.Buffer = True
                            Response.ContentType = "application/ms-excel"
                            Response.AddHeader("content-disposition", String.Format(attachment, "ExportedGridData"))
                            htw = New HtmlTextWriter(sw)

                            tblcell.Text = " "
                            tblcell1.ColumnSpan = 20
                            tblcell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/><b><font size='2'>PAMAC FE PAYOUT MIS FOR:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " </font></b> <br/>"
                            tblcell1.CssClass = "FormHeading"
                            tblrow.Cells.Add(tblcell)
                            tblrow1.Cells.Add(tblcell1)
                            tblrow.Height = 20
                            tblspace.Rows.Add(tblrow)
                            tblspace.Rows.Add(tblrow1)
                            frm.Attributes("runat") = "server"
                            Controls.Add(frm)

                            frm.Controls.Add(gvmis)

                            tblspace.RenderControl(htw)


                            gvmis.EnableViewState = False
                            'gvmis.GridLines = GridLines.Both
                            gvmis.RenderControl(htw)
                            Response.Write(sw.ToString())

                            Response.End()

                        End If




                    End If

                    'lblMsg.Text = "No data to Export";
                End If
            End If
        End If


    End Sub
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

        ' Confirms that an HtmlForm control is rendered for the 

        ' specified ASP.NET server control at run time. 

        ' No code required here. 
    End Sub

   
    Protected Sub btnexport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Dim inddt As New Data.DataTable
        Dim indds As New DataSet
        Dim indol As OleDbDataAdapter
        Dim no As Integer = 1
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim objcentre As Object
        Dim objcluster As Object
        Dim clus As String
        Dim cen As String
        Dim row As Integer
        Dim col As Integer
        Dim col2 As String = ""
        Dim rowCount As Integer
        Dim colCount As Integer
        Dim cell As String
        Dim rowcell As Integer

        Dim oExcel As Excel.Application = New Excel.Application
        xls.Workbooks.Close()
        Dim xlwb As Workbook = xls.Workbooks.Add()
        If (ddlcentre.SelectedIndex = 0 And ddlreport.SelectedIndex = 0) Then
            qry = "select Centre_name from Centre_master order by Centre_name"
            Dim centreol As OleDbDataAdapter
            Dim centredt As New Data.DataTable
            Dim centreds As New DataSet
            centreol = New OleDbDataAdapter(qry, objcon.ConnectionString)
            centreol.Fill(centreds, "Search")
            centredt = centreds.Tables("Search")
            Dim n As Integer = 0
            Dim flag As String
            flag = "a"


            For n = 0 To centredt.Rows.Count - 1

                objcentre = centredt.Rows.Item(n).Item("Centre_name")
                cen = objcentre.ToString()
                qry = "Exec FEPAYOUTCENTREWISE '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','" + cen + "','a'"
                Dim cenol As OleDbDataAdapter
                Dim cendt As New Data.DataTable
                Dim cends As New DataSet
                cenol = New OleDbDataAdapter(qry, objcon.ConnectionString)
                cenol.Fill(cends, "Search")
                cendt = cends.Tables("Search")

                If cendt.Rows.Count > 0 Then
                    xlwb.Sheets.Add()
                    Dim sheet4 As Excel.Worksheet = xls.ActiveSheet
                    sheet4.Name = cen
                    xls.Cells.EntireColumn.ColumnWidth = 18
                    xls.ActiveWindow.DisplayGridlines = False
                    xls.Cells.Range("A1").Cells.Value = "PAMAC FINSERVE PVT. LTD."
                    xls.Cells.Range("A1").Cells.Font.Bold = True
                    xls.Cells.Range("A1").Cells.Font.Name = "Arial"
                    xls.Cells.Range("A1").Cells.Font.Size = 8

                    xls.Cells.Range("A2").Cells.Value = "PAMAC CPA PAN INDIA DETAILS FOR DATE:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " , and CENTRE: " + cen + ""
                    xls.Cells.Range("A2").Cells.Font.Bold = True
                    xls.Cells.Range("A2").Cells.Font.Name = "Arial"
                    xls.Cells.Range("A2").Cells.Font.Size = 8

                    xls.Cells.Range("A4").Cells.Value = "Sr. No."
                    xls.Cells.Range("A4").Cells.ColumnWidth = 4
                    xls.Cells.Range("A4").Cells.Font.Bold = True
                    xls.Cells.Range("A4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("A4").Cells.Font.Size = 8

                    xls.Cells.Range("B4").Cells.Value = "Pamacian Name"
                    xls.Cells.Range("B4").Cells.Font.Bold = True
                    xls.Cells.Range("B4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("B4").Cells.Font.Size = 8

                    xls.Cells.Range("C4").Cells.Value = "Pamacian Code"
                    xls.Cells.Range("C4").Cells.Font.Bold = True
                    xls.Cells.Range("C4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("C4").Cells.Font.Size = 8

                    xls.Cells.Range("D4").Cells.Value = "A/C#"
                    xls.Cells.Range("D4").Cells.Font.Bold = True
                    xls.Cells.Range("D4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("D4").Cells.Font.Size = 8

                    xls.Cells.Range("E4").Cells.Value = "Professional Salary"
                    xls.Cells.Range("E4").Cells.Font.Bold = True
                    xls.Cells.Range("E4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("E4").Cells.Font.Size = 8

                    xls.Cells.Range("F4").Cells.Value = "HRA"
                    xls.Cells.Range("F4").Cells.Font.Bold = True
                    xls.Cells.Range("F4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("F4").Cells.Font.Size = 8

                    xls.Cells.Range("G4").Cells.Value = "O.T."
                    xls.Cells.Range("G4").Cells.Font.Bold = True
                    xls.Cells.Range("G4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("G4").Cells.Font.Size = 8

                    xls.Cells.Range("H4").Cells.Value = "Special Allowance"
                    xls.Cells.Range("H4").Cells.Font.Bold = True
                    xls.Cells.Range("H4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("H4").Cells.Font.Size = 8

                    xls.Cells.Range("I4").Cells.Value = "Other Allowance"
                    xls.Cells.Range("I4").Cells.Font.Bold = True
                    xls.Cells.Range("I4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("A4").Cells.Font.Size = 8

                    xls.Cells.Range("J4").Cells.Value = "Gross Earning"
                    xls.Cells.Range("J4").Cells.Font.Bold = True
                    xls.Cells.Range("J4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("j4").Cells.Font.Size = 8

                    xls.Cells.Range("K4").Cells.Value = "PF"
                    xls.Cells.Range("K4").Cells.Font.Bold = True
                    xls.Cells.Range("K4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("K4").Cells.Font.Size = 8

                    xls.Cells.Range("L4").Cells.Value = "PT"
                    xls.Cells.Range("L4").Cells.Font.Bold = True
                    xls.Cells.Range("L4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("L4").Cells.Font.Size = 8

                    xls.Cells.Range("M4").Cells.Value = "ESIC"
                    xls.Cells.Range("M4").Cells.Font.Bold = True
                    xls.Cells.Range("M4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("M4").Cells.Font.Size = 8

                    xls.Cells.Range("N4").Cells.Value = "Advance Pay"
                    xls.Cells.Range("N4").Cells.Font.Bold = True
                    xls.Cells.Range("N4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("N4").Cells.Font.Size = 8

                    xls.Cells.Range("O4").Cells.Value = "Loan Inst."
                    xls.Cells.Range("O4").Cells.Font.Bold = True
                    xls.Cells.Range("O4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("O4").Cells.Font.Size = 8

                    xls.Cells.Range("P4").Cells.Value = "Other Ded."
                    xls.Cells.Range("P4").Cells.Font.Bold = True
                    xls.Cells.Range("P4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("P4").Cells.Font.Size = 8

                    xls.Cells.Range("Q4").Cells.Value = "TDS Ded."
                    xls.Cells.Range("Q4").Cells.Font.Bold = True
                    xls.Cells.Range("Q4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("Q4").Cells.Font.Size = 8

                    xls.Cells.Range("R4").Cells.Value = "Insurance"
                    xls.Cells.Range("R4").Cells.Font.Bold = True
                    xls.Cells.Range("R4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("R4").Cells.Font.Size = 8

                    xls.Cells.Range("S4").Cells.Value = "Fix Ded."
                    xls.Cells.Range("S4").Cells.Font.Bold = True
                    xls.Cells.Range("S4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("S4").Cells.Font.Size = 8

                    xls.Cells.Range("T4").Cells.Value = "Gross Ded."
                    xls.Cells.Range("T4").Cells.Font.Bold = True
                    xls.Cells.Range("T4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("T4").Cells.Font.Size = 8

                    xls.Cells.Range("U4").Cells.Value = "Net Payout"
                    xls.Cells.Range("U4").Cells.Font.Bold = True
                    xls.Cells.Range("U4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("U4").Cells.Font.Size = 8

                    xls.Cells.Range("V4").Cells.Value = "Location"
                    xls.Cells.Range("V4").Cells.Font.Bold = True
                    xls.Cells.Range("V4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("V4").Cells.Font.Size = 8

                    xls.Cells.Range("W4").Cells.Value = "Unit"
                    xls.Cells.Range("W4").Cells.Font.Bold = True
                    xls.Cells.Range("W4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("W4").Cells.Font.Size = 8

                    xls.Cells.Range("X4").Cells.Value = "CS Card"
                    xls.Cells.Range("X4").Cells.Font.Bold = True
                    xls.Cells.Range("X4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("X4").Cells.Font.Size = 8

                    xls.Cells.Range("Y4").Cells.Value = "Barclay CS"
                    xls.Cells.Range("Y4").Cells.Font.Bold = True
                    xls.Cells.Range("Y4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("Y4").Cells.Font.Size = 8

                    xls.Cells.Range("Z4").Cells.Value = "Total CS"
                    xls.Cells.Range("Z4").Cells.Font.Bold = True
                    xls.Cells.Range("Z4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("Z4").Cells.Font.Size = 8

                    xls.Cells.Range("AA4").Cells.Value = "Average"
                    xls.Cells.Range("AA4").Cells.Font.Bold = True
                    xls.Cells.Range("AA4").Cells.Font.Name = "Arial"
                    xls.Cells.Range("AA4").Cells.Font.Size = 8

                    Dim m As Integer = 0

                    For m = 0 To cendt.Rows.Count - 1
                        Dim sun As Integer
                        sun = 0
                        Dim col8 As Integer = 0
                        'For col = 0 To colCount - 1
                        cell = GetExcelColumn(sun, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("SR NO").ToString()
                        cell = GetExcelColumn(sun + 1, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("PAMACIAN NAME").ToString()
                        cell = GetExcelColumn(sun + 2, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("EMP CODE").ToString()
                        cell = GetExcelColumn(sun + 3, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("A/C.#").ToString()
                        cell = GetExcelColumn(sun + 4, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("PROF. SAL").ToString()
                        cell = GetExcelColumn(sun + 5, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("HRA").ToString()
                        cell = GetExcelColumn(sun + 6, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("O.T.").ToString()
                        cell = GetExcelColumn(sun + 7, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("SPECIAL ALLOWANCE.").ToString()
                        cell = GetExcelColumn(sun + 8, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("OTHER ALLOWANCE").ToString()
                        cell = GetExcelColumn(sun + 9, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("GROSS EARNING").ToString()
                        cell = GetExcelColumn(sun + 10, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("PF").ToString()
                        cell = GetExcelColumn(sun + 11, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("PROF. TAX").ToString()
                        cell = GetExcelColumn(sun + 12, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("ESIC").ToString()
                        cell = GetExcelColumn(sun + 13, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("ADVANCE PAY").ToString()
                        cell = GetExcelColumn(sun + 14, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("LOAN INST.").ToString()
                        cell = GetExcelColumn(sun + 15, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("OTHER DEDUC.").ToString()
                        cell = GetExcelColumn(sun + 16, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("TDS DEDUCTION").ToString()
                        cell = GetExcelColumn(sun + 17, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("INSURANCE").ToString()
                        cell = GetExcelColumn(sun + 18, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("FIX DEDUC.").ToString()
                        cell = GetExcelColumn(sun + 19, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("GROSS DEDUC.").ToString()
                        cell = GetExcelColumn(sun + 20, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("NET PAYOUT").ToString()
                        cell = GetExcelColumn(sun + 21, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("LOCATION").ToString()
                        cell = GetExcelColumn(sun + 22, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("UNIT").ToString()
                        cell = GetExcelColumn(sun + 23, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("CS CARD").ToString()
                        cell = GetExcelColumn(sun + 24, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("BARCLAY CS").ToString()
                        cell = GetExcelColumn(sun + 25, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("TOTAL CS").ToString()
                        cell = GetExcelColumn(sun + 26, col8 + 5).ToString()
                        xls.Range(cell).Value = cendt.Rows.Item(m).Item("AVERAGE").ToString()

                        col8 = col8 + 1
                    Next
                End If
            Next

           
            xlwb.Sheets.Add()
            Dim sheet3 As Excel.Worksheet = xls.ActiveSheet
            sheet3.Name = "PAY-MIS"
            xls.Cells.EntireColumn.ColumnWidth = 18
            xls.ActiveWindow.DisplayGridlines = False
            xls.ActiveWindow.DisplayGridlines = False
            xls.Cells.Range("A1").Cells.Value = "PAMAC FINSERVE PVT. LTD."
            xls.Cells.Range("A1").Cells.Font.Bold = True
            xls.Cells.Range("A1").Cells.Font.Name = "Arial"
            xls.Cells.Range("A1").Cells.Font.Size = 8
            xls.Cells.Range("A2").Cells.Value = "PAMAC FE PAYOUT FOR:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " "
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

            xls.Cells.Range("E4").Cells.Value = "Total#"
            xls.Cells.Range("E4").Cells.Font.Bold = True
            xls.Cells.Range("E4").Cells.Font.Name = "Arial"
            xls.Cells.Range("E4").Cells.Font.Size = 8

            xls.Cells.Range("F4").Cells.Value = "Gross"
            xls.Cells.Range("F4").Cells.Font.Bold = True
            xls.Cells.Range("F4").Cells.Font.Name = "Arial"
            xls.Cells.Range("F4").Cells.Font.Size = 8

            xls.Cells.Range("G4").Cells.Value = "PT"
            xls.Cells.Range("G4").Cells.Font.Bold = True
            xls.Cells.Range("G4").Cells.Font.Name = "Arial"
            xls.Cells.Range("G4").Cells.Font.Size = 8

            xls.Cells.Range("H4").Cells.Value = "PF"
            xls.Cells.Range("H4").Cells.Font.Bold = True
            xls.Cells.Range("H4").Cells.Font.Name = "Arial"
            xls.Cells.Range("H4").Cells.Font.Size = 8

            xls.Cells.Range("I4").Cells.Value = "ESIC"
            xls.Cells.Range("I4").Cells.Font.Bold = True
            xls.Cells.Range("I4").Cells.Font.Name = "Arial"
            xls.Cells.Range("I4").Cells.Font.Size = 8

            xls.Cells.Range("J4").Cells.Value = "TDS"
            xls.Cells.Range("J4").Cells.Font.Bold = True
            xls.Cells.Range("J4").Cells.Font.Name = "Arial"
            xls.Cells.Range("J4").Cells.Font.Size = 8

            xls.Cells.Range("K4").Cells.Value = "Advance Pay"
            xls.Cells.Range("K4").Cells.Font.Bold = True
            xls.Cells.Range("K4").Cells.Font.Name = "Arial"
            xls.Cells.Range("K4").Cells.Font.Size = 8

            xls.Cells.Range("L4").Cells.Value = "EMI"
            xls.Cells.Range("L4").Cells.Font.Bold = True
            xls.Cells.Range("L4").Cells.Font.Name = "Arial"
            xls.Cells.Range("L4").Cells.Font.Size = 8

            xls.Cells.Range("M4").Cells.Value = "PMWP"
            xls.Cells.Range("M4").Cells.Font.Bold = True
            xls.Cells.Range("M4").Cells.Font.Name = "Arial"
            xls.Cells.Range("M4").Cells.Font.Size = 8

            xls.Cells.Range("N4").Cells.Value = "Insurance"
            xls.Cells.Range("N4").Cells.Font.Bold = True
            xls.Cells.Range("N4").Cells.Font.Name = "Arial"
            xls.Cells.Range("N4").Cells.Font.Size = 8

            xls.Cells.Range("O4").Cells.Value = "Other Deduc."
            xls.Cells.Range("O4").Cells.Font.Bold = True
            xls.Cells.Range("O4").Cells.Font.Name = "Arial"
            xls.Cells.Range("O4").Cells.Font.Size = 8

            xls.Cells.Range("P4").Cells.Value = "Tax Deduc."
            xls.Cells.Range("P4").Cells.Font.Bold = True
            xls.Cells.Range("P4").Cells.Font.Name = "Arial"
            xls.Cells.Range("P4").Cells.Font.Size = 8

            xls.Cells.Range("Q4").Cells.Value = "Paid on 2nd"
            xls.Cells.Range("Q4").Cells.Font.Bold = True
            xls.Cells.Range("Q4").Cells.Font.Name = "Arial"
            xls.Cells.Range("Q4").Cells.Font.Size = 8

            xls.Cells.Range("R4").Cells.Value = "Net Salary"
            xls.Cells.Range("R4").Cells.Font.Bold = True
            xls.Cells.Range("R4").Cells.Font.Name = "Arial"
            xls.Cells.Range("R4").Cells.Font.Size = 8

            xls.Cells.Range("S4").Cells.Value = "PF Employer"
            xls.Cells.Range("S4").Cells.Font.Bold = True
            xls.Cells.Range("S4").Cells.Font.Name = "Arial"
            xls.Cells.Range("S4").Cells.Font.Size = 8

            xls.Cells.Range("T4").Cells.Value = "ESIC Employer"
            xls.Cells.Range("T4").Cells.Font.Bold = True
            xls.Cells.Range("T4").Cells.Font.Name = "Arial"
            xls.Cells.Range("T4").Cells.Font.Size = 8
            qry = "select Bankname from bank_master order by bankid"
            Dim bankol As OleDbDataAdapter
            Dim bankdt As New Data.DataTable
            Dim bankds As New DataSet
            bankol = New OleDbDataAdapter(qry, objcon.ConnectionString)
            bankol.Fill(bankds, "Search")
            bankdt = bankds.Tables("Search")
            Dim a As Integer = 0
            Dim sum2 As Integer = 0
            Dim col1 As Integer = 0

            For a = 0 To bankdt.Rows.Count - 1

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
            paydt = getbank1()
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

                cell = GetExcelColumn(sum1 + 4, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(4).ToString()

                cell = GetExcelColumn(sum1 + 5, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(5).ToString()

                cell = GetExcelColumn(sum1 + 6, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(6).ToString()

                cell = GetExcelColumn(sum1 + 7, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(7).ToString()

                cell = GetExcelColumn(sum1 + 8, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(8).ToString()

                cell = GetExcelColumn(sum1 + 9, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(9).ToString()

                cell = GetExcelColumn(sum1 + 10, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(10).ToString()

                cell = GetExcelColumn(sum1 + 11, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(11).ToString()

                cell = GetExcelColumn(sum1 + 12, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(12).ToString()

                cell = GetExcelColumn(sum1 + 13, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(13).ToString()

                cell = GetExcelColumn(sum1 + 14, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(14).ToString()

                cell = GetExcelColumn(sum1 + 15, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(15).ToString()

                cell = GetExcelColumn(sum1 + 16, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(16).ToString()

                cell = GetExcelColumn(sum1 + 17, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(17).ToString()

                cell = GetExcelColumn(sum1 + 18, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(18).ToString()

                cell = GetExcelColumn(sum1 + 19, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(19).ToString()

                cell = GetExcelColumn(sum1 + 20, col3 + 5).ToString()
                xls.Range(cell).Value = paydt.Rows.Item(b).Item(20).ToString()

                col3 = col3 + 1
                Dim sum4 As Integer = 0
                For c = 20 To paydt.Columns.Count - 4

                    cell = GetExcelColumn1(sum4, col3 + 4).ToString()
                    xls.Range(cell).Value = paydt.Rows.Item(b).Item(c).ToString()

                    sum4 = sum4 + 1

                Next
                Dim sum5 As String
                Dim d As Integer = 0
                'cell = Len(cell)
                If Len(cell) = 2 Then
                    col = Left(cell, 1)
                    For d = c To paydt.Columns.Count - 1
                        cell = GetExcelColumn2(sum5, col3 + 4).ToString()
                        xls.Range(cell).Value = paydt.Rows.Item(b).Item(d).ToString()
                        sum5 = sum5 + 1
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
            qry = "drop table fe_salary"
            Dim oder As OleDbDataReader
            oder = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry)
                xlwb.Sheets.Add()
            Dim sheet2 As Excel.Worksheet = xls.ActiveSheet
            sheet2.Name = "BARCLAYS"

            xls.Cells.EntireColumn.ColumnWidth = 18
            'xls.ActiveWindow.DisplayGridlines = False
            xls.ActiveWindow.DisplayGridlines = False
            xls.Cells.Range("A1").Cells.Value = "PAMAC FINSERVE PVT. LTD."
            xls.Cells.Range("A1").Cells.Font.Bold = True
            xls.Cells.Range("A1").Cells.Font.Name = "Arial"
            xls.Cells.Range("A1").Cells.Font.Size = 8

            xls.Cells.Range("A2").Cells.Value = "PAMAC FE PAYOUT FOR:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " "
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
            xls.Cells.Range("D4").Select()


            xls.Cells.Range("D4").Cells.Font.Size = 8

            xls.Cells.Range("E4").Cells.Value = "Barclays"
            xls.Cells.Range("E4").Cells.Font.Bold = True
            xls.Cells.Range("E4").Cells.Font.Name = "Arial"
            xls.Cells.Range("E4").Cells.Font.Size = 8

            xls.Cells.Range("F4").Cells.Value = "CPV"
            xls.Cells.Range("F4").Cells.Font.Bold = True
            xls.Cells.Range("F4").Cells.Font.Name = "Arial"
            xls.Cells.Range("F4").Cells.Font.Size = 8

            xls.Cells.Range("G4").Cells.Value = "ALL"
            xls.Cells.Range("G4").Cells.Font.Bold = True
            xls.Cells.Range("G4").Cells.Font.Name = "Arial"
            xls.Cells.Range("G4").Cells.Font.Size = 8

            Dim barol As New OleDbDataAdapter
            Dim bardt As New Data.DataTable
            Dim bards As New DataSet
            Dim col11 As Integer = 0
            qry = "Exec FE_CLIENT_MIS   '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "'"
            barol = New OleDbDataAdapter(qry, objcon.ConnectionString)
            barol.Fill(bards, "search")
            bardt = bards.Tables("Search")
            Dim k As Integer = 0
            For k = 0 To bardt.Rows.Count - 1
                Dim sum1 As Integer = 0
                cell = GetExcelColumn(sum1, col11 + 5).ToString()
                xls.Range(cell).Value = bardt.Rows.Item(k).Item("Company Name").ToString()
                cell = GetExcelColumn(sum1 + 1, col11 + 5).ToString()
                xls.Range(cell).Value = bardt.Rows.Item(k).Item("Location").ToString()
                cell = GetExcelColumn(sum1 + 2, col11 + 5).ToString()
                xls.Range(cell).Value = bardt.Rows.Item(k).Item("Category").ToString()
                cell = GetExcelColumn(sum1 + 3, col11 + 5).ToString()
                xls.Range(cell).Value = bardt.Rows.Item(k).Item("Cluster").ToString()
                cell = GetExcelColumn(sum1 + 4, col11 + 5).ToString()
                xls.Range(cell).Value = bardt.Rows.Item(k).Item("Barclays").ToString()
                cell = GetExcelColumn(sum1 + 5, col11 + 5).ToString()
                xls.Range(cell).Value = bardt.Rows.Item(k).Item("CPV").ToString()
                cell = GetExcelColumn(sum1 + 6, col11 + 5).ToString()
                xls.Range(cell).Value = bardt.Rows.Item(k).Item("All Clients").ToString()
                cell = GetExcelColumn(sum1 + 7, col11 + 5).ToString()

                col11 = col11 + 1

            Next

            xlwb.Sheets.Add()
            Dim sheet As Excel.Worksheet = xls.ActiveSheet
            sheet.Name = "INDEX"

            xls.Visible = True
            xls.Cells.EntireColumn.ColumnWidth = 18
            'xls.ActiveWindow.DisplayGridlines = False
            xls.ActiveWindow.DisplayGridlines = False
            xls.Cells.Range("A1").Cells.Value = "PAMAC FINSERVE PVT. LTD."
            xls.Cells.Range("A1").Cells.Font.Bold = True
            xls.Cells.Range("A1").Cells.Font.Name = "Arial"
            xls.Cells.Range("A1").Cells.Font.Size = 8

            xls.Cells.Range("A2").Cells.Value = "PAMAC FE PAYOUT FOR:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " "
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

            xls.Cells.Range("E4").Cells.Value = "Previous Month Total#"
            xls.Cells.Range("E4").Cells.Font.Bold = True
            xls.Cells.Range("E4").Cells.Font.Name = "Arial"
            xls.Cells.Range("E4").Cells.Font.Size = 8

            xls.Cells.Range("F4").Cells.Value = "Previous Month Gross"
            xls.Cells.Range("F4").Cells.Font.Bold = True
            xls.Cells.Range("F4").Cells.Font.Name = "Arial"
            xls.Cells.Range("F4").Cells.Font.Size = 8

            xls.Cells.Range("G4").Cells.Value = "Previous Month CS#"
            xls.Cells.Range("G4").Cells.Font.Bold = True
            xls.Cells.Range("G4").Cells.Font.Name = "Arial"
            xls.Cells.Range("G4").Cells.Font.Size = 8


            xls.Cells.Range("H4").Cells.Value = "Previous Month Avg"
            xls.Cells.Range("H4").Cells.Font.Bold = True
            xls.Cells.Range("H4").Cells.Font.Name = "Arial"
            xls.Cells.Range("H4").Cells.Font.Size = 8

            xls.Cells.Range("I4").Cells.Value = "Current Month Total#"
            xls.Cells.Range("I4").Cells.Font.Bold = True
            xls.Cells.Range("I4").Cells.Font.Name = "Arial"
            xls.Cells.Range("I4").Cells.Font.Size = 8

            xls.Cells.Range("J4").Cells.Value = "Current Month Gross"
            xls.Cells.Range("J4").Cells.Font.Bold = True
            xls.Cells.Range("J4").Cells.Font.Name = "Arial"
            xls.Cells.Range("J4").Cells.Font.Size = 8

            xls.Cells.Range("K4").Cells.Value = "Current Month CS#"
            xls.Cells.Range("K4").Cells.Font.Bold = True
            xls.Cells.Range("K4").Cells.Font.Name = "Arial"
            xls.Cells.Range("K4").Cells.Font.Size = 8


            xls.Cells.Range("L4").Cells.Value = "Current Month Avg"
            xls.Cells.Range("L4").Cells.Font.Bold = True
            xls.Cells.Range("L4").Cells.Font.Name = "Arial"
            xls.Cells.Range("L4").Cells.Font.Size = 8


            xls.Cells.Range("M4").Cells.Value = "Fluctuation with Previous Month"
            xls.Cells.Range("M4").Cells.Font.Bold = True
            xls.Cells.Range("M4").Cells.Font.Name = "Arial"
            xls.Cells.Range("M4").Cells.Font.Size = 8
            qry = "Exec FEPAYOUTMIS '" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "'"
            indol = New OleDbDataAdapter(qry, objcon.ConnectionString)
            indol.Fill(indds, "Search")
            inddt = indds.Tables("Search")
            col = 0
            For j = 0 To inddt.Rows.Count - 1
                Dim sum As Integer = 0

                cell = GetExcelColumn(sum, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("Company Name").ToString()
                cell = GetExcelColumn(sum + 1, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("Location").ToString()
                cell = GetExcelColumn(sum + 2, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("Category").ToString()
                cell = GetExcelColumn(sum + 3, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("Cluster").ToString()
                cell = GetExcelColumn(sum + 4, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("PreviousMonth#").ToString()
                cell = GetExcelColumn(sum + 5, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("PreviousMonth Gross").ToString()
                cell = GetExcelColumn(sum + 6, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("PreviousMonth CS#").ToString()
                cell = GetExcelColumn(sum + 7, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("PreviousMonth Avg").ToString()
                cell = GetExcelColumn(sum + 8, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("CurrentMonth#").ToString()
                cell = GetExcelColumn(sum + 9, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("CurrentMonth Gross").ToString()
                cell = GetExcelColumn(sum + 10, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("CurrentMonth CS#").ToString()
                cell = GetExcelColumn(sum + 11, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("CurrentMonth Avg").ToString()
                cell = GetExcelColumn(sum + 12, col + 5).ToString()
                xls.Range(cell).Value = inddt.Rows.Item(j).Item("Fluctuation with PreviousMonth").ToString()
                col = col + 1
            Next
        End If
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
                result = "G" & s
            Case 7
                result = "H" & s
            Case 8
                result = "I" & s
            Case 9
                result = "J" & s
            Case 10
                result = "K" & s
            Case 11
                result = "L" & s
            Case 12
                result = "M" & s
            Case 13
                result = "N" & s
            Case 14
                result = "O" & s
            Case 15
                result = "P" & s
            Case 16
                result = "Q" & s
            Case 17
                result = "R" & s
            Case 18
                result = "S" & s
            Case 19
                result = "T" & s
            Case 20
                result = "U" & s
            Case 21
                result = "V" & s
            Case 22
                result = "W" & s
            Case 23
                result = "X" & s
            Case 24
                result = "Y" & s
            Case 25
                result = "Z" & s
            Case 26
                result = "AA" & s
        End Select
        Return result
    End Function
    Function GetExcelColumn1(ByVal col As Integer, ByVal s As Integer) As String
        Dim result As String
        Select Case col
            Case 0  ' first column
                result = "U" & s
            Case 1
                result = "V" & s
            Case 2
                result = "W" & s
            Case 3
                result = "X" & s
            Case 4
                result = "Y" & s
            Case 5
                result = "Z" & s
            Case 6
                result = "AA" & s
            Case 7
                result = "AB" & s
            Case 8
                result = "AC" & s
            Case 9
                result = "AD" & s
            Case 10
                result = "AE" & s
            Case 11
                result = "AF" & s
            Case 12
                result = "AG" & s
            Case 13
                result = "AH" & s
            Case 14
                result = "AI" & s
            Case 15
                result = "AJ" & s
            Case 16
                result = "AK" & s
            Case 17
                result = "AL" & s
            Case 18
                result = "AM" & s
            Case 19
                result = "AN" & s
            Case 20
                result = "AO" & s
            
        End Select
        Return result
    End Function
    Function GetExcelColumn2(ByVal col2 As String, ByVal s As Integer) As String
        Dim result As String
        Select Case col2
            Case "U"  ' first column
                result = "V" & s
            Case "V"
                result = "W" & s
            Case "W"
                result = "X" & s
            Case "X"
                result = "Y" & s
            Case "Y"
                result = "Z" & s
            Case "Z"
                result = "AA" & s
            Case "AA"
                result = "AB" & s
            Case "AB"
                result = "AC" & s
            Case "AC"
                result = "AD" & s
            Case "AD"
                result = "AE" & s
            Case "AE"
                result = "AF" & s
            Case "AF"
                result = "AG" & s
            Case "AG"
                result = "AH" & s
            Case "AH"
                result = "AI" & s
            Case "AI"
                result = "AJ" & s
            Case "AJ"
                result = "AK" & s
            Case "AK"
                result = "AL" & s
            Case "AL"
                result = "AM" & s
            Case "AM"
                result = "AN" & s
            Case "AN"
                result = "AO" & s
            Case "AO"
                result = "AP" & s

        End Select
        Return result
    End Function


End Class
