namespace BandCamp.UI
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.rbMembers = new System.Windows.Forms.RadioButton();
            this.rbConcerts = new System.Windows.Forms.RadioButton();
            this.rbContracts = new System.Windows.Forms.RadioButton();
            this.btnTextReport = new System.Windows.Forms.Button();
            this.btnCsvReport = new System.Windows.Forms.Button();
            this.lblPreview = new System.Windows.Forms.Label();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "Генерация отчётов";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);

            // lblType
            this.lblType.Text = "Выберите тип отчёта:";
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.lblType.Location = new System.Drawing.Point(30, 65);
            this.lblType.Size = new System.Drawing.Size(200, 22);

            // RadioButtons
            this.rbMembers.Text = "Участники";
            this.rbMembers.Location = new System.Drawing.Point(30, 95);
            this.rbMembers.Size = new System.Drawing.Size(130, 24);
            this.rbMembers.Checked = true;
            this.rbMembers.Font = new System.Drawing.Font("Segoe UI", 10f);

            this.rbConcerts.Text = "Концерты";
            this.rbConcerts.Location = new System.Drawing.Point(170, 95);
            this.rbConcerts.Size = new System.Drawing.Size(130, 24);
            this.rbConcerts.Font = new System.Drawing.Font("Segoe UI", 10f);

            this.rbContracts.Text = "Контракты";
            this.rbContracts.Location = new System.Drawing.Point(310, 95);
            this.rbContracts.Size = new System.Drawing.Size(130, 24);
            this.rbContracts.Font = new System.Drawing.Font("Segoe UI", 10f);

            // Кнопки
            this.btnTextReport.Text = "Текстовый отчёт";
            this.btnTextReport.Location = new System.Drawing.Point(30, 135);
            this.btnTextReport.Size = new System.Drawing.Size(160, 38);
            this.btnTextReport.BackColor = System.Drawing.Color.FromArgb(60, 120, 200);
            this.btnTextReport.ForeColor = System.Drawing.Color.White;
            this.btnTextReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTextReport.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.btnTextReport.Click += new System.EventHandler(this.btnTextReport_Click);

            this.btnCsvReport.Text = "Сохранить CSV";
            this.btnCsvReport.Location = new System.Drawing.Point(205, 135);
            this.btnCsvReport.Size = new System.Drawing.Size(160, 38);
            this.btnCsvReport.BackColor = System.Drawing.Color.FromArgb(40, 160, 80);
            this.btnCsvReport.ForeColor = System.Drawing.Color.White;
            this.btnCsvReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCsvReport.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.btnCsvReport.Click += new System.EventHandler(this.btnCsvReport_Click);

            // Preview
            this.lblPreview.Text = "Предпросмотр:";
            this.lblPreview.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblPreview.Location = new System.Drawing.Point(30, 192);
            this.lblPreview.Size = new System.Drawing.Size(150, 22);

            this.txtPreview.Location = new System.Drawing.Point(30, 218);
            this.txtPreview.Size = new System.Drawing.Size(900, 280);
            this.txtPreview.Multiline = true;
            this.txtPreview.ReadOnly = true;
            this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPreview.Font = new System.Drawing.Font("Courier New", 9f);
            this.txtPreview.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.txtPreview.WordWrap = false;

            // UserControl
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.lblType,
                this.rbMembers,    this.rbConcerts,   this.rbContracts,
                this.btnTextReport,this.btnCsvReport,
                this.lblPreview,   this.txtPreview
            });

            this.Size = new System.Drawing.Size(980, 540);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton rbMembers;
        private System.Windows.Forms.RadioButton rbConcerts;
        private System.Windows.Forms.RadioButton rbContracts;
        private System.Windows.Forms.Button btnTextReport;
        private System.Windows.Forms.Button btnCsvReport;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.TextBox txtPreview;
    }
}