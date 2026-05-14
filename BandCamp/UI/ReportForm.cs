using System;
using System.IO;
using System.Windows.Forms;
using BandCamp.Patterns.Structural;

namespace BandCamp.UI
{
    public partial class ReportForm : UserControl
    {
        private readonly BandManagerFacade _facade;

        public ReportForm(BandManagerFacade facade)
        {
            InitializeComponent();
            _facade = facade;
        }

        private void btnTextReport_Click(object sender, EventArgs e)
        {
            string type = GetSelectedReportType();
            if (type == null) return;

            string result = _facade.GenerateTextReport(type);
            txtPreview.Text = result;
        }

        private void btnCsvReport_Click(object sender, EventArgs e)
        {
            string type = GetSelectedReportType();
            if (type == null) return;

            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Выберите папку для сохранения CSV";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string result = _facade.GenerateCsvReport(type, dlg.SelectedPath);
                    txtPreview.Text = result;
                    MessageBox.Show(result, "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string GetSelectedReportType()
        {
            if (rbMembers.Checked) return "members";
            if (rbConcerts.Checked) return "concerts";
            if (rbContracts.Checked) return "contracts";

            MessageBox.Show("Выберите тип отчёта", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }
    }
}