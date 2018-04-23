Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
				Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable()
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("ID", GetType(Integer))
			tbl.Columns.Add("Number", GetType(Integer))
			tbl.Columns.Add("Date", GetType(DateTime))
			For i As Integer = 0 To RowCount - 1
				tbl.Rows.Add(New Object() { MyTextProvider.GetHTMLText(i), i, 3 - i, DateTime.Now.AddDays(i) })
			Next i
			Return tbl
				End Function


		Public Sub New()
			InitializeComponent()
			gridControl1.DataSource = CreateTable(20)
			Dim ri As New RepositoryItemRichTextEdit()
			ri.DocumentFormat = DocumentFormat.Html
			gridView1.Columns(0).ColumnEdit = ri
			gridView1.OptionsView.RowAutoHeight = True

		End Sub
	End Class

	Public NotInheritable Class MyTextProvider
		Private Const sourceText As String = "<b><font color=#00FFAA>Name<font color=#FF0011>_Number_</font></font></b><br>AddressLine1<br>AddressLine2<br>"
		Private Sub New()
		End Sub
		Public Shared Function GetHTMLText(ByVal index As Integer) As String
			Return sourceText.Replace("_Number_", index.ToString())
		End Function
	End Class

End Namespace