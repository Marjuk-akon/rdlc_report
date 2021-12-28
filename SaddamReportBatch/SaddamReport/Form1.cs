using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaddamReport
{
    public partial class From1 : Form
    {
        public From1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
      {   
            using(SaddamDBEntities db = new SaddamDBEntities())
            {
                rptReport_ResultBindingSource.DataSource = db.rptReport(dateTimePicker1.Value, dateTimePicker2.Value).ToList();
                Microsoft.Reporting.WinForms.ReportParameter[] rParms = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("FromDate", dateTimePicker1.Value.ToLongDateString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("ToDate", dateTimePicker2.Value.ToLongDateString())
                };
            reportViewer1.LocalReport.SetParameters(rParms);
            reportViewer1.RefreshReport();

            }
          }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}