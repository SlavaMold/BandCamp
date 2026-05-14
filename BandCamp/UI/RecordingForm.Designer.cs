namespace BandCamp.UI
{
    partial class RecordingForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listContracts = new System.Windows.Forms.ListBox();
            this.lblList = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblStudio = new System.Windows.Forms.Label();
            this.txtStudio = new System.Windows.Forms.TextBox();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.txtResponsible = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.nudPayment = new System.Windows.Forms.NumericUpDown();
            this.lblBand = new System.Windows.Forms.Label();
            this.cboBand = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)this.nudPayment).BeginInit();
            this.SuspendLayout();

            // lblList
            this.lblList.Text = "Контракты на запись";
            this.lblList.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblList.Location = new System.Drawing.Point(12, 12);
            this.lblList.Size = new System.Drawing.Size(220, 22);

            // listContracts
            this.listContracts.Location = new System.Drawing.Point(12, 38);
            this.listContracts.Size = new System.Drawing.Size(260, 460);
            this.listContracts.SelectedIndexChanged += new System.EventHandler(this.listContracts_SelectedIndexChanged);

            // lblDetails
            this.lblDetails.Text = "Детали контракта";
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(290, 12);
            this.lblDetails.Size = new System.Drawing.Size(200, 22);

            // Студия
            this.lblStudio.Text = "Студия:";
            this.lblStudio.Location = new System.Drawing.Point(290, 42);
            this.lblStudio.Size = new System.Drawing.Size(110, 20);
            this.txtStudio.Location = new System.Drawing.Point(410, 40);
            this.txtStudio.Size = new System.Drawing.Size(260, 24);

            // Отв. лицо
            this.lblResponsible.Text = "Отв. лицо:";
            this.lblResponsible.Location = new System.Drawing.Point(290, 78);
            this.lblResponsible.Size = new System.Drawing.Size(110, 20);
            this.txtResponsible.Location = new System.Drawing.Point(410, 76);
            this.txtResponsible.Size = new System.Drawing.Size(260, 24);

            // Продукт
            this.lblProduct.Text = "Назв. продукта:";
            this.lblProduct.Location = new System.Drawing.Point(290, 114);
            this.lblProduct.Size = new System.Drawing.Size(110, 20);
            this.txtProduct.Location = new System.Drawing.Point(410, 112);
            this.txtProduct.Size = new System.Drawing.Size(260, 24);

            // Оплата
            this.lblPayment.Text = "Оплата ($):";
            this.lblPayment.Location = new System.Drawing.Point(290, 150);
            this.lblPayment.Size = new System.Drawing.Size(110, 20);
            this.nudPayment.Location = new System.Drawing.Point(410, 148);
            this.nudPayment.Size = new System.Drawing.Size(160, 24);
            this.nudPayment.Maximum = 10000000;
            this.nudPayment.DecimalPlaces = 2;

            // Группа
            this.lblBand.Text = "Группа:";
            this.lblBand.Location = new System.Drawing.Point(290, 186);
            this.lblBand.Size = new System.Drawing.Size(110, 20);
            this.cboBand.Location = new System.Drawing.Point(410, 184);
            this.cboBand.Size = new System.Drawing.Size(260, 24);
            this.cboBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Дата начала
            this.lblStart.Text = "Начало:";
            this.lblStart.Location = new System.Drawing.Point(290, 222);
            this.lblStart.Size = new System.Drawing.Size(110, 20);
            this.dtpStart.Location = new System.Drawing.Point(410, 220);
            this.dtpStart.Size = new System.Drawing.Size(260, 24);
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Дата конца
            this.lblEnd.Text = "Срок (до):";
            this.lblEnd.Location = new System.Drawing.Point(290, 258);
            this.lblEnd.Size = new System.Drawing.Size(110, 20);
            this.dtpEnd.Location = new System.Drawing.Point(410, 256);
            this.dtpEnd.Size = new System.Drawing.Size(260, 24);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Кнопки
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(410, 298);
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(60, 120, 200);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnNew.Text = "Новый";
            this.btnNew.Location = new System.Drawing.Point(520, 298);
            this.btnNew.Size = new System.Drawing.Size(70, 32);
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(600, 298);
            this.btnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // UserControl
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblList,       this.listContracts,
                this.lblDetails,
                this.lblStudio,     this.txtStudio,
                this.lblResponsible,this.txtResponsible,
                this.lblProduct,    this.txtProduct,
                this.lblPayment,    this.nudPayment,
                this.lblBand,       this.cboBand,
                this.lblStart,      this.dtpStart,
                this.lblEnd,        this.dtpEnd,
                this.btnSave,       this.btnNew, this.btnDelete
            });

            this.Size = new System.Drawing.Size(980, 540);

            ((System.ComponentModel.ISupportInitialize)this.nudPayment).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox listContracts;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblStudio;
        private System.Windows.Forms.TextBox txtStudio;
        private System.Windows.Forms.Label lblResponsible;
        private System.Windows.Forms.TextBox txtResponsible;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.NumericUpDown nudPayment;
        private System.Windows.Forms.Label lblBand;
        private System.Windows.Forms.ComboBox cboBand;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
    }
}