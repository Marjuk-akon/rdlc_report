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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer2.RefreshReport();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SaddamDBEntities1 db = new SaddamDBEntities1())
            {
                rptReport_ResultBindingSource.DataSource = db.rptReport3(dateTimePicker1.Value, dateTimePicker2.Value).ToList();
                Microsoft.Reporting.WinForms.ReportParameter[] rParms = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("FromDate", dateTimePicker1.Value.ToLongDateString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("ToDate", dateTimePicker2.Value.ToLongDateString())
                };
                reportViewer2.LocalReport.SetParameters(rParms);
                reportViewer2.RefreshReport();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            From1 f1 = new From1();
            f1.Show();
        }
    }
}
