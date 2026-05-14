namespace BandCamp.UI
{
    partial class ConcertForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listConcerts = new System.Windows.Forms.ListBox();
            this.lblList = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBand = new System.Windows.Forms.Label();
            this.cboBand = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.txtResponsible = new System.Windows.Forms.TextBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.nudPayment = new System.Windows.Forms.NumericUpDown();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)this.nudPayment).BeginInit();
            this.SuspendLayout();

            // lblList
            this.lblList.Text = "Концерты";
            this.lblList.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblList.Location = new System.Drawing.Point(12, 12);
            this.lblList.Size = new System.Drawing.Size(200, 22);

            // listConcerts
            this.listConcerts.Location = new System.Drawing.Point(12, 38);
            this.listConcerts.Size = new System.Drawing.Size(260, 460);
            this.listConcerts.SelectedIndexChanged += new System.EventHandler(this.listConcerts_SelectedIndexChanged);

            // lblDetails
            this.lblDetails.Text = "Детали концерта";
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(290, 12);
            this.lblDetails.Size = new System.Drawing.Size(200, 22);

            // Название
            this.lblName.Text = "Название:";
            this.lblName.Location = new System.Drawing.Point(290, 42);
            this.lblName.Size = new System.Drawing.Size(110, 20);
            this.txtName.Location = new System.Drawing.Point(410, 40);
            this.txtName.Size = new System.Drawing.Size(260, 24);

            // Группа
            this.lblBand.Text = "Группа:";
            this.lblBand.Location = new System.Drawing.Point(290, 78);
            this.lblBand.Size = new System.Drawing.Size(110, 20);
            this.cboBand.Location = new System.Drawing.Point(410, 76);
            this.cboBand.Size = new System.Drawing.Size(260, 24);
            this.cboBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Дата
            this.lblDate.Text = "Дата:";
            this.lblDate.Location = new System.Drawing.Point(290, 114);
            this.lblDate.Size = new System.Drawing.Size(110, 20);
            this.dtpDate.Location = new System.Drawing.Point(410, 112);
            this.dtpDate.Size = new System.Drawing.Size(260, 24);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Отв. лицо
            this.lblResponsible.Text = "Отв. лицо:";
            this.lblResponsible.Location = new System.Drawing.Point(290, 150);
            this.lblResponsible.Size = new System.Drawing.Size(110, 20);
            this.txtResponsible.Location = new System.Drawing.Point(410, 148);
            this.txtResponsible.Size = new System.Drawing.Size(260, 24);

            // Оплата
            this.lblPayment.Text = "Оплата ($):";
            this.lblPayment.Location = new System.Drawing.Point(290, 186);
            this.lblPayment.Size = new System.Drawing.Size(110, 20);
            this.nudPayment.Location = new System.Drawing.Point(410, 184);
            this.nudPayment.Size = new System.Drawing.Size(160, 24);
            this.nudPayment.Maximum = 10000000;
            this.nudPayment.DecimalPlaces = 2;

            // Комментарий
            this.lblComment.Text = "Комментарий:";
            this.lblComment.Location = new System.Drawing.Point(290, 222);
            this.lblComment.Size = new System.Drawing.Size(110, 20);
            this.txtComment.Location = new System.Drawing.Point(410, 220);
            this.txtComment.Size = new System.Drawing.Size(260, 90);
            this.txtComment.Multiline = true;
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // Кнопки
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(410, 324);
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(60, 120, 200);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnNew.Text = "Новый";
            this.btnNew.Location = new System.Drawing.Point(520, 324);
            this.btnNew.Size = new System.Drawing.Size(70, 32);
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(600, 324);
            this.btnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // UserControl
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblList,       this.listConcerts,
                this.lblDetails,
                this.lblName,       this.txtName,
                this.lblBand,       this.cboBand,
                this.lblDate,       this.dtpDate,
                this.lblResponsible,this.txtResponsible,
                this.lblPayment,    this.nudPayment,
                this.lblComment,    this.txtComment,
                this.btnSave,       this.btnNew, this.btnDelete
            });

            this.Size = new System.Drawing.Size(980, 540);

            ((System.ComponentModel.ISupportInitialize)this.nudPayment).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox listConcerts;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBand;
        private System.Windows.Forms.ComboBox cboBand;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblResponsible;
        private System.Windows.Forms.TextBox txtResponsible;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.NumericUpDown nudPayment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
    }
}