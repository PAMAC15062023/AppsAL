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
Partial Class HR_HR_PAMACBANKPAYOUT
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
        qry = "Exec Pamacctcmis '" + ddlcluser.SelectedItem.ToString() + "' ,'','" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','b'"
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

        qry = "Exec pamacctcmis '' ,'','" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','a'"
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

        qry = "Exec pamacctcmis '" + ddlcluser.SelectedItem.ToString() + "' ,'" + ddlcentre.SelectedItem.ToString() + "','" + ddlmonth.SelectedValue + " " + ddlyear.SelectedValue + "','c'"
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


    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

        ' Confirms that an HtmlForm control is rendered for the 

        ' specified ASP.NET server control at run time. 

        ' No code required here. 
    End Sub

    Protected Sub btnexport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexport.Click

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
                attachment = "attachment; filename=PAMAC HR CTC MIS.xls"
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
                        attachment = "attachment; filename=PAMAC HR CTC MIS.xls"
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
                            attachment = "attachment; filename=PAMAC HR CTC MIS.xls"
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
                result = "G5" & s
            Case 7
                result = "H5" & s
            Case 8
                result = "I5" & s
            Case 9
                result = "J5" & s
            Case 10
                result = "K5" & s
            Case 11
                result = "L5" & s
            Case 12
                result = "M5" & s
            Case 13
                result = "N5" & s
            Case 14
                result = "O5" & s
            Case 15
                result = "P5" & s
            Case 16
                result = "Q5" & s
            Case 17
                result = "R5" & s
            Case 18
                result = "S5" & s
            Case 19
                result = "T5" & s
            Case 20
                result = "U5" & s
            Case 21
                result = "V5" & s
            Case 22
                result = "W5" & s
            Case 23
                result = "X5" & s
            Case 24
                result = "Y5" & s
            Case 25
                result = "Z5" & s
        End Select
        Return result
    End Function




End Class
