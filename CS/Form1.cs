using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraRichEdit;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
                private DataTable CreateTable(int RowCount)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { MyTextProvider.GetHTMLText(i), i, 3 - i, DateTime.Now.AddDays(i) });
            return tbl;
        }


        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = CreateTable(20);
            RepositoryItemRichTextEdit ri = new RepositoryItemRichTextEdit();
            ri.DocumentFormat = DocumentFormat.Html;
            gridView1.Columns[0].ColumnEdit = ri;
            gridView1.OptionsView.RowAutoHeight = true;

        }
    }

    public static class MyTextProvider
    {
        private const string sourceText = @"<b><font color=#00FFAA>Name<font color=#FF0011>_Number_</font></font></b><br>AddressLine1<br>AddressLine2<br>";
        public static string GetHTMLText(int index)
        {
            return sourceText.Replace("_Number_", index.ToString());
        }
    }

}