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
Partial Class HR_HR_PAMACHRZONALMIS
    Inherits System.Web.UI.Page
    Dim objcon As New CCommon
    'Dim sqlcon As New OleDbConnection
    Dim sqlcmd, sqlcmd1 As OleDbCommand
    'Dim sqlad As OleDbDataAdapter
    Dim sqlds As New DataSet
    Dim i, cnt, row, col As Integer
    'Dim fsys As Directory
    'Dim var As String
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
        If ddlcluser.Items.Count = 1 Then

            Dcluster()

        End If
        If ddlyear.Items.Count = 0 Then
            year()
        End If
    End Sub
    Protected Function centre()
        Dim sqlcon As New OleDbConnection

        sqlcon = New OleDbConnection
        Dim ol As OleDbDataAdapter
        Dim dt As New Data.DataTable
        Dim ds As New DataSet
        Dim qry As String = ""
        qry = "Select centre_id,centre_name from centre_master where cluster_id='" + ddlcluser.SelectedValue + "' order by centre_name"
        ol = New OleDbDataAdapter(qry, objcon.ConnectionString)
        ol.Fill(ds, "Search")
        dt = ds.Tables("Search")
        Return dt
        dt.Clear()
        Return centre()
    End Function

    Public Function cluster()
        Dim sqlcon As New OleDbConnection
        sqlcon = New OleDbConnection
        Dim clus As OleDbDataAdapter
        Dim dclus As New Data.DataTable
        Dim dc As New DataSet
        qry = "Select cluster_id,cluster_name from cluster_master order by cluster_name"
        clus = New OleDbDataAdapter(qry, objcon.ConnectionString)
        clus.Fill(dc, "Search")
        dclus = dc.Tables("Search")
        Return dclus

        Return cluster()

    End Function

    Protected Sub ddlcluser_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcluser.SelectedIndexChanged
        Dim dtcentre As New Data.DataTable
        dtcentre = centre()
        ddlcentre.Items.Clear()
        ddlcentre.Items.Add("---All Centre---")
        ddlcentre.DataSource = dtcentre
        ddlcentre.DataTextField = "Centre_name"
        ddlcentre.DataValueField = "centre_id"
        ddlcentre.DataBind()
        'If ddlcentre.Items.Count = 0 Then
        '    ddlcentre.Items.Add("---All Centre---")
        'End If
        ' dtcentre.Clear()
    End Sub
    Public Sub Dcluster()
        Dim dt As New Data.DataTable
        dt = cluster()
        If dt.Rows.Count > 0 Then
            ddlcluser.DataSource = dt

            ddlcluser.DataTextField = "Cluster_name"
            ddlcluser.DataValueField = "cluster_id"
            ddlcluser.DataBind()

        End If
    End Sub
    Protected Function allcentre()

        Dim dcen As New Data.DataTable
        Dim dc As New DataSet
        Dim olc As OleDbDataAdapter
        flag = "b"

        qry = "Exec pamachrzonalmis '" + ddlcluser.SelectedItem.ToString() + "' ,'','" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','b'"
        olc = New OleDbDataAdapter(qry, objcon.ConnectionString)
        olc.Fill(dc, "Search")
        dcen = dc.Tables("Search")
        Return dcen
        Return allcentre()
    End Function
    Protected Sub allcentre1()
        Dim dcent As New Data.DataTable

        dcent = allcentre()
        If dcent.Rows.Count > 0 Then

            gvmis.DataSource = dcent
            gvmis.DataBind()
            gvmis.Visible = True


        Else

            lblmsg.Visible = True
            lblmsg.Text = "No Record Found for This Yearmonth"
        End If

    End Sub

    Public Function allcluster()
        Dim dclu As New Data.DataTable
        Dim dcl As New DataSet
        Dim olcus As OleDbDataAdapter
        flag = "a"

        qry = "Exec pamachrzonalmis '' ,'','" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','a'"
        olcus = New OleDbDataAdapter(qry, objcon.ConnectionString)
        olcus.Fill(dcl, "Search")
        dclu = dcl.Tables("Search")
        Return dclu
        Return allcluster()
    End Function

    Public Sub allcluster1()
        Dim dclus As New Data.DataTable

        dclus = allcluster()
        If dclus.Rows.Count > 0 Then

            gvmis.DataSource = dclus
            gvmis.DataBind()
            gvmis.Visible = True


        Else

            lblmsg.Visible = True
            lblmsg.Text = "No Record Found for This Yearmonth"
        End If
    End Sub
    Public Function centrecluster()
        Dim dclucen As New Data.DataTable
        Dim dclce As New DataSet
        Dim olcusce As OleDbDataAdapter
        flag = "c"

        qry = "Exec pamachrzonalmis '" + ddlcluser.SelectedItem.ToString() + "' ,'" + ddlcentre.SelectedItem.ToString() + "','" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','c'"
        olcusce = New OleDbDataAdapter(qry, objcon.ConnectionString)
        olcusce.Fill(dclce, "Search")
        dclucen = dclce.Tables("Search")
        Return dclucen
        Return centrecluster()
    End Function
    Public Sub centreclus()
        Dim dclus As New Data.DataTable

        dclus = centrecluster()
        If dclus.Rows.Count > 0 Then

            gvmis.DataSource = dclus
            gvmis.DataBind()
            gvmis.Visible = True


        Else

            lblmsg.Visible = True
            lblmsg.Text = "No Record Found for This Yearmonth"
        End If

    End Sub

    Protected Sub btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreport.Click
        If (ddlmonth.SelectedIndex = 0) Then
            lblmsg.Text = "Please Select the Payout Month"
            lblmsg.Visible = True
        Else
            If (ddlcluser.SelectedIndex = 0) Then
                allcluster1()
            Else
                If (ddlcentre.SelectedIndex = 0) Then
                    allcentre1()
                Else
                    centreclus()
                End If
            End If

        End If
    End Sub

    Protected Sub Export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Export.Click
        If ddlcluser.SelectedIndex = 0 Then

            allcluster1()
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
                attachment = "attachment; filename=PAMAC HR ZONAL MIS.xls"
                Response.AddHeader("content-disposition", String.Format(attachment, "ExportedGridData"))
                Response.ContentType = "application/ms-excel"
                htw = New HtmlTextWriter(sw)
                tblcell.Text = " "
                tblcell1.ColumnSpan = 20
                'tblcell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/><b><font size='2'>PAMAC CPAN PAN INDIA STAFF DETAILS FOR : '" + ddlmonth.SelectedValue + " ' " " " + ddlyear.SelectedValue + " and " + ddlcentre.SelectedItem + "</font></b> <br/>"
                tblcell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/><b><font size='2'>PAMAC CPA PAN INDIA DETAILS FOR DATE:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " ,CLUSTER: " + ddlcluser.SelectedItem.ToString() + " and CENTRE: " + ddlcentre.SelectedItem.ToString() + "</font></b> <br/>"
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

            Else

                If ddlcentre.SelectedIndex = 0 Then

                    allcentre1()

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
                        attachment = "attachment; filename=PAMAC HR ZONAL MIS.xls"
                        Response.Clear()
                        Response.Buffer = True
                        Response.AddHeader("content-disposition", String.Format(attachment, "ExportedGridData"))
                        Response.ContentType = "application/ms-excel"

                        htw = New HtmlTextWriter(sw)

                        tblcell.Text = " "
                        tblcell1.ColumnSpan = 20
                        'tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                        '               "<b><font size='2'>PAMAC CPA PAN INDIA DETAILS FOR : " + ddlmonth.SelectedValue + ' ' + ddlyear.SelectedValue + " And " + ddlcentre.SelectedItem + " </font></b> <br/>";
                        tblcell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/><b><font size='2'>PAMAC CPA PAN INDIA DETAILS FOR DATE:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " " & _
                                        " ,CLUSTER: " + ddlcluser.SelectedItem.ToString() + " and CENTRE: " + ddlcentre.SelectedItem.ToString() + "</font></b> <br/>"
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

                    Else
                        centreclus()
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
                            attachment = "attachment; filename=PAMAC HR ZONAL MIS.xls"
                            Response.Clear()
                            Response.Buffer = True
                            Response.ContentType = "application/ms-excel"
                            Response.AddHeader("content-disposition", String.Format(attachment, "ExportedGridData"))
                            htw = New HtmlTextWriter(sw)

                            tblcell.Text = " "
                            tblcell1.ColumnSpan = 20
                            tblcell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/><b><font size='2'>PAMAC CPA PAN INDIA DETAILS FOR DATE:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " ,CLUSTER: " + ddlcluser.SelectedItem.ToString() + " and CENTRE: " + ddlcentre.SelectedItem.ToString() + "</font></b> <br/>"
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

                        Else


                            'lblMsg.Text = "No data to Export";
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

        ' Confirms that an HtmlForm control is rendered for the 

        ' specified ASP.NET server control at run time. 

        ' No code required here. 
    End Sub
    Public Function exportallcentre()
        Dim sqlcon As New OleDbConnection

        sqlcon = New OleDbConnection
        Dim exp As OleDbDataAdapter
        Dim dtexp As New Data.DataTable
        Dim dsexp As New DataSet
        Dim qry As String = ""
        qry = "select centre_name,cluster_name from centre_master a,cluster_master b where a.cluster_id=b.cluster_id"
        exp = New OleDbDataAdapter(qry, objcon.ConnectionString)
        exp.Fill(dsexp, "Search")
        dtexp = dsexp.Tables("Search")
        Return dtexp
        Return exportallcentre()
    End Function

    Protected Sub btnexport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Dim dtexpcen As New Data.DataTable()
        Dim dtexp1 As New Data.DataTable()
        Dim dsexp1 As New DataSet
        Dim dol As OleDbDataAdapter

        Dim no As Integer = 1

        dtexpcen = exportallcentre()
        flag = "c"
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim objcentre As Object
        Dim objcluster As Object
        Dim clus As String
        Dim cen As String
        Dim row As Integer
        Dim col As Integer
        Dim rowCount As Integer
        Dim colCount As Integer
        Dim cell As String
        Dim rowcell As Integer


        Dim oExcel As Excel.Application = New Excel.Application
        xls.Workbooks.Close()
        Dim xlwb As Workbook = xls.Workbooks.Add()


        For i = 0 To dtexpcen.Rows.Count - 1
            objcentre = dtexpcen.Rows.Item(i).Item("Centre_name")
            cen = objcentre.ToString()
            objcluster = dtexpcen.Rows.Item(i).Item("cluster_name")
            clus = objcluster.ToString()
            qry = "Exec pamachrzonalmis '" + clus + "','" + cen + "','" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','c'"
            dol = New OleDbDataAdapter(qry, objcon.ConnectionString)
            dol.Fill(dsexp1, "Search")
            dtexp1 = dsexp1.Tables("Search")
            xlwb.Sheets.Add()

            Dim sheet As Excel.Worksheet = xls.ActiveSheet

            If dtexp1.Rows.Count > 0 Then
                rowCount = dtexp1.Rows.Count - 1
                colCount = dtexp1.Columns.Count - 1



                sheet.Name = cen

                xls.Visible = True
                xls.Cells.EntireColumn.ColumnWidth = 12.5
                xls.ActiveWindow.DisplayGridlines = False
                xls.Cells.Range("A1").Cells.Value = "PAMAC FINSERVE PVT. LTD."
                xls.Cells.Range("A1").Cells.Font.Bold = True
                xls.Cells.Range("A1").Cells.Font.Name = "Arial"
                xls.Cells.Range("A1").Cells.Font.Size = 8

                xls.Cells.Range("A2").Cells.Value = "PAMAC CPA PAN INDIA DETAILS FOR DATE:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & " ,CLUSTER: " + clus + " and CENTRE: " + cen + ""
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

                xls.Cells.Range("D4").Cells.Value = "Unit"
                xls.Cells.Range("D4").Cells.Font.Bold = True
                xls.Cells.Range("D4").Cells.Font.Name = "Arial"
                xls.Cells.Range("D4").Cells.Font.Size = 8

                xls.Cells.Range("E4").Cells.Value = "Current Month"
                xls.Cells.Range("E4").Cells.Font.Bold = True
                xls.Cells.Range("E4").Cells.Font.Name = "Arial"
                xls.Cells.Range("E4").Cells.Font.Size = 8

                xls.Cells.Range("F4").Cells.Value = "Previous Month"
                xls.Cells.Range("F4").Cells.Font.Bold = True
                xls.Cells.Range("F4").Cells.Font.Name = "Arial"
                xls.Cells.Range("F4").Cells.Font.Size = 8

            End If
            col = 0
            For j = 0 To dtexp1.Rows.Count - 1

                'For row = 0 To rowCount - 1
                'rowcell = row + 2
                Dim sun As Integer
                sun = 0

                'For col = 0 To colCount - 1
                cell = GetExcelColumn(sun, col + 5).ToString()
                xls.Range(cell).Value = dtexp1.Rows.Item(j).Item("SRNO").ToString()
                cell = GetExcelColumn(sun + 1, col + 5).ToString()
                xls.Range(cell).Value = dtexp1.Rows.Item(j).Item("Pamacian Name").ToString()
                cell = GetExcelColumn(sun + 2, col + 5).ToString()
                xls.Range(cell).Value = dtexp1.Rows.Item(j).Item("Pamacian Code").ToString()
                cell = GetExcelColumn(sun + 3, col + 5).ToString()
                xls.Range(cell).Value = dtexp1.Rows.Item(j).Item("Unit").ToString()
                cell = GetExcelColumn(sun + 4, col + 5).ToString()
                xls.Range(cell).Value = dtexp1.Rows.Item(j).Item("Current Month").ToString()
                cell = GetExcelColumn(sun + 5, col + 5).ToString()
                xls.Range(cell).Value = dtexp1.Rows.Item(j).Item("Previous Month").ToString()
                col = col + 1
                'Next
                'Next



                'xls.Cells.Range(j).Cells.Value = dtexp1.Rows.Item(j).Item("SRNO")
                'xls.Cells.Range("B5:B56").Cells.Value = "" + dtexp1.Rows.Item(j).Item("Pamacian Name") + ""
                'xls.Cells.Range("C5:C56").Cells.Value = "" + dtexp1.Rows.Item(j).Item("Pamacian Code") + ""
                'xls.Cells.Range("D5:D56").Cells.Value = "" + dtexp1.Rows.Item(j).Item("unit") + ""
                ''xls.Cells.Range("E5:E56").Cells.Value = dtexp1.Rows.Item(j).Item("current month")
                'xls.Cells.Range("F5:F56").Cells.Value = dtexp1.Rows.Item(j).Item("previous month")



            Next

        Next
        Dim FLAG1 As String
        flag = "A"
        Dim K As Integer = 0
        Dim ZONALDT As New Data.DataTable
        Dim ZONALDS As New DataSet
        Dim ZONALOL As OleDbDataAdapter
        qry = "EXEC PAMACZONALMIS 'WEST','','JUL 2008','A'"
        ZONALOL = New OleDbDataAdapter(qry, objcon.ConnectionString)
        ZONALOL.Fill(ZONALDS, "Search")
        ZONALDT = ZONALDS.Tables("Search")
        xlwb.Sheets.Add()
        Dim sheet1 As Excel.Worksheet = xls.ActiveSheet
        sheet1.Name = "1"
        If ZONALDT.Rows.Count > 0 Then
            For K = 0 To ZONALDT.Rows.Count - 1
                xls.Cells.EntireColumn.ColumnWidth = 12.5
                xls.ActiveWindow.DisplayGridlines = False
                xls.Cells.Range("A1").Cells.Value = "PAMAC FINSERVE PVT. LTD."
                xls.Cells.Range("A1").Cells.Font.Bold = True
                xls.Cells.Range("A1").Cells.Font.Name = "Arial"
                xls.Cells.Range("A1").Cells.Font.Size = 8

                xls.Cells.Range("A2").Cells.Value = "PAMAC CPA PAN INDIA DETAILS FOR DATE:" & ddlmonth.SelectedValue & " " & ddlyear.SelectedValue & ""
                xls.Cells.Range("A2").Cells.Font.Bold = True
                xls.Cells.Range("A2").Cells.Font.Name = "Arial"
                xls.Cells.Range("A2").Cells.Font.Size = 8

                xls.Cells.Range("A4").Cells.Value = "Cluster"
                xls.Cells.Range("A4").Cells.ColumnWidth = 4
                xls.Cells.Range("A4").Cells.Font.Bold = True
                xls.Cells.Range("A4").Cells.Font.Name = "Arial"
                xls.Cells.Range("A4").Cells.Font.Size = 8

                xls.Cells.Range("B4").Cells.Value = "Location"
                xls.Cells.Range("B4").Cells.Font.Bold = True
                xls.Cells.Range("B4").Cells.Font.Name = "Arial"
                xls.Cells.Range("B4").Cells.Font.Size = 8

                xls.Cells.Range("C4").Cells.Value = "Previous Month Count"
                xls.Cells.Range("C4").Cells.Font.Bold = True
                xls.Cells.Range("C4").Cells.Font.Name = "Arial"
                xls.Cells.Range("C4").Cells.Font.Size = 8

                xls.Cells.Range("D4").Cells.Value = "Previous Month Net Salary"
                xls.Cells.Range("D4").Cells.Font.Bold = True
                xls.Cells.Range("D4").Cells.Font.Name = "Arial"
                xls.Cells.Range("D4").Cells.Font.Size = 8

                xls.Cells.Range("E4").Cells.Value = "Current Month Count"
                xls.Cells.Range("E4").Cells.Font.Bold = True
                xls.Cells.Range("E4").Cells.Font.Name = "Arial"
                xls.Cells.Range("E4").Cells.Font.Size = 8

                xls.Cells.Range("F4").Cells.Value = "Current Month Net Salary"
                xls.Cells.Range("F4").Cells.Font.Bold = True
                xls.Cells.Range("F4").Cells.Font.Name = "Arial"
                xls.Cells.Range("F4").Cells.Font.Size = 8

                xls.Cells.Range("G4").Cells.Value = "Count Difference"
                xls.Cells.Range("G4").Cells.Font.Bold = True
                xls.Cells.Range("G4").Cells.Font.Name = "Arial"
                xls.Cells.Range("G4").Cells.Font.Size = 8

                xls.Cells.Range("H4").Cells.Value = "Net Salary Difference"
                xls.Cells.Range("H4").Cells.Font.Bold = True
                xls.Cells.Range("H4").Cells.Font.Name = "Arial"
                xls.Cells.Range("H4").Cells.Font.Size = 8
            Next
            col = 0
            Dim m As Integer = 0
            For m = 0 To ZONALDT.Rows.Count - 1
                Dim sun1 As Integer
                sun1 = 0

                'For col = 0 To colCount - 1
                cell = GetExcelColumn(sun1, col + 5).ToString()
                xls.Range(cell).Value = ZONALDT.Rows.Item(m).Item("Cluster").ToString()
                cell = GetExcelColumn(sun1 + 1, col + 5).ToString()
                xls.Range(cell).Value = ZONALDT.Rows.Item(m).Item("Location").ToString()
                cell = GetExcelColumn(sun1 + 2, col + 5).ToString()
                xls.Range(cell).Value = ZONALDT.Rows.Item(m).Item("Previousmonth Count").ToString()
                cell = GetExcelColumn(sun1 + 3, col + 5).ToString()
                xls.Range(cell).Value = ZONALDT.Rows.Item(m).Item("Previousmonth Netsalary").ToString()
                cell = GetExcelColumn(sun1 + 4, col + 5).ToString()
                xls.Range(cell).Value = ZONALDT.Rows.Item(m).Item("CurrentMonth Count").ToString()
                cell = GetExcelColumn(sun1 + 5, col + 5).ToString()
                xls.Range(cell).Value = ZONALDT.Rows.Item(m).Item("CurrentMonth Netsalary").ToString()
                cell = GetExcelColumn(sun1 + 6, col + 5).ToString()
                xls.Range(cell).Value = ZONALDT.Rows.Item(m).Item("Countdiff").ToString()
                cell = GetExcelColumn(sun1 + 7, col + 5).ToString()
                xls.Range(cell).Value = ZONALDT.Rows.Item(m).Item("Diffnetsalary").ToString()
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
  

End Class
