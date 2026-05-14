namespace BandCamp.UI
{
    partial class TourForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listTours = new System.Windows.Forms.ListBox();
            this.lblList = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBand = new System.Windows.Forms.Label();
            this.cboBand = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblBudget = new System.Windows.Forms.Label();
            this.nudBudget = new System.Windows.Forms.NumericUpDown();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)this.nudBudget).BeginInit();
            this.SuspendLayout();

            // lblList
            this.lblList.Text = "Туры";
            this.lblList.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblList.Location = new System.Drawing.Point(12, 12);
            this.lblList.Size = new System.Drawing.Size(200, 22);

            // listTours
            this.listTours.Location = new System.Drawing.Point(12, 38);
            this.listTours.Size = new System.Drawing.Size(260, 460);
            this.listTours.SelectedIndexChanged += new System.EventHandler(this.listTours_SelectedIndexChanged);

            // lblDetails
            this.lblDetails.Text = "Детали тура";
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

            // Дата начала
            this.lblStart.Text = "Начало:";
            this.lblStart.Location = new System.Drawing.Point(290, 114);
            this.lblStart.Size = new System.Drawing.Size(110, 20);
            this.dtpStart.Location = new System.Drawing.Point(410, 112);
            this.dtpStart.Size = new System.Drawing.Size(260, 24);
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Дата конца
            this.lblEnd.Text = "Конец:";
            this.lblEnd.Location = new System.Drawing.Point(290, 150);
            this.lblEnd.Size = new System.Drawing.Size(110, 20);
            this.dtpEnd.Location = new System.Drawing.Point(410, 148);
            this.dtpEnd.Size = new System.Drawing.Size(260, 24);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Бюджет
            this.lblBudget.Text = "Бюджет ($):";
            this.lblBudget.Location = new System.Drawing.Point(290, 186);
            this.lblBudget.Size = new System.Drawing.Size(110, 20);
            this.nudBudget.Location = new System.Drawing.Point(410, 184);
            this.nudBudget.Size = new System.Drawing.Size(160, 24);
            this.nudBudget.Maximum = 100000000;
            this.nudBudget.DecimalPlaces = 2;

            // Страна
            this.lblCountry.Text = "Страна:";
            this.lblCountry.Location = new System.Drawing.Point(290, 222);
            this.lblCountry.Size = new System.Drawing.Size(110, 20);
            this.txtCountry.Location = new System.Drawing.Point(410, 220);
            this.txtCountry.Size = new System.Drawing.Size(260, 24);

            // Кнопки
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(410, 262);
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(60, 120, 200);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnNew.Text = "Новый";
            this.btnNew.Location = new System.Drawing.Point(520, 262);
            this.btnNew.Size = new System.Drawing.Size(70, 32);
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(600, 262);
            this.btnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // UserControl
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblList,    this.listTours,
                this.lblDetails,
                this.lblName,    this.txtName,
                this.lblBand,    this.cboBand,
                this.lblStart,   this.dtpStart,
                this.lblEnd,     this.dtpEnd,
                this.lblBudget,  this.nudBudget,
                this.lblCountry, this.txtCountry,
                this.btnSave,    this.btnNew, this.btnDelete
            });

            this.Size = new System.Drawing.Size(980, 540);

            ((System.ComponentModel.ISupportInitialize)this.nudBudget).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox listTours;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBand;
        private System.Windows.Forms.ComboBox cboBand;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.NumericUpDown nudBudget;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
    }
}