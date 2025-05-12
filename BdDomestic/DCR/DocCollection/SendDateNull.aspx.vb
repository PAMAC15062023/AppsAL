''''''''''''''''''''''''''''''''''''''''''''''
''''''''''SANTOSH SHELLAR'''''''''''''''''''''
''''''''''START DATE : 10/05/2008'''''''''''''
''''''''''END DATE : 15/05/2008'''''''''''''''
''''''''''''''''''''''''''''''''''''''''''''''
Imports System.Data
Imports System.Data.OleDb.OleDbCommand
Imports vb = Microsoft.VisualBasic
Imports System.Data.OleDb
Imports System.Web

Partial Class CPV_CC_SendDateNull
    Inherits System.Web.UI.Page

    Dim sqlcon, connstr As New OleDbConnection
    Dim sqlcmd, sqlcmd1 As OleDbCommand
    Dim sqlad As OleDbDataAdapter
    Dim sqlds As New DataSet
    'Dim sa As New [abc]
    Dim aa, bb As String
    Dim objconn As New CCommon()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAppName.Enabled = False

        sqlcon = New OleDbConnection
        sqlcon.ConnectionString = objconn.ConnectionString()
        sqlcon.Open()
        lblMessage.Visible = False

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try
            'sqlcon.Open()
            txtAppName.Enabled = False
            If txtCaseId.Text = "" Then
                sqlcmd = New OleDbCommand("select case_id, isnull(first_name,'')+ ' '+isnull(middle_name,'')+' '+isnull(last_name,'') as Name from cpv_cc_case_details where ref_no='" & txtRefNo.Text & "'", sqlcon)
                sqlcmd.ExecuteNonQuery()
                sqlad = New OleDbDataAdapter(sqlcmd)
                sqlad.Fill(sqlds, "cpv_cc_case_details")
                txtCaseId.Text = sqlds.Tables("cpv_cc_case_details").Rows(0)(0).ToString
                txtAppName.Text = sqlds.Tables("cpv_cc_case_details").Rows(0)(1).ToString

            Else
                sqlcmd = New OleDbCommand("select ref_no, isnull(first_name,'')+ ' '+isnull(middle_name,'')+' '+isnull(last_name,'') as Name from cpv_cc_case_details where case_id='" & txtCaseId.Text & "'", sqlcon)
                sqlcmd.ExecuteNonQuery()
                sqlad = New OleDbDataAdapter(sqlcmd)
                sqlad.Fill(sqlds, "cpv_cc_case_details")
                txtRefNo.Text = sqlds.Tables("cpv_cc_case_details").Rows(0)(0).ToString
                txtAppName.Text = sqlds.Tables("cpv_cc_case_details").Rows(0)(1).ToString
            End If
        Catch ex As Exception
            lblMessage.Text = (ex.Message)
        End Try
    End Sub

    Protected Sub btnReopen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReopen.Click
        Try
            If txtCaseId.Text = "" Then
                lblMessage.Text = "Please Enter Case ID."
                lblMessage.Visible = True
                Exit Sub
            ElseIf txtRefNo.Text = "" Then
                lblMessage.Text = "Please Enter Ref No."
                lblMessage.Visible = True
                Exit Sub
            End If

            sqlcmd = New OleDbCommand("select send_datetime from cpv_cc_case_details where case_id='" & txtCaseId.Text & "'", sqlcon)
            sqlcmd.ExecuteNonQuery()
            sqlad = New OleDbDataAdapter(sqlcmd)
            sqlds.Tables.Clear()
            sqlad.Fill(sqlds, "abc")
            aa = sqlds.Tables("abc").Rows(0)(0).ToString
            'bb = sqlds.Tables("abc").Rows(0)(1).ToString

            If aa = "" Then
                lblMessage.Text = "This case ID already Reopen"
                lblMessage.Visible = True
                Exit Sub
            Else
                sqlcmd1 = New OleDbCommand("Update cpv_cc_case_details set send_datetime=null, is_case_complete=null where case_id='" & txtCaseId.Text & "'", sqlcon)
                sqlcmd1.ExecuteNonQuery()

                lblMessage.Text = "Send date updated succesfully"
                lblMessage.Visible = True
                txtCaseId.Text = ""
                txtRefNo.Text = ""
                txtAppName.Text = ""
            End If
            txtCaseId.Text = ""
            txtRefNo.Text = ""
            txtAppName.Text = ""
        Catch ex As Exception
            lblMessage.Text = (ex.Message)
        End Try

    End Sub
End Class
