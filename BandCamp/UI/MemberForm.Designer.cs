namespace BandCamp.UI
{
    partial class MemberForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listMembers = new System.Windows.Forms.ListBox();
            this.lblList = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.lblExperience = new System.Windows.Forms.Label();
            this.nudExperience = new System.Windows.Forms.NumericUpDown();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.btnSelectPhoto = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)this.nudExperience).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picPhoto).BeginInit();
            this.SuspendLayout();

            // lblList
            this.lblList.Text = "Участники";
            this.lblList.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblList.Location = new System.Drawing.Point(12, 12);
            this.lblList.Size = new System.Drawing.Size(200, 22);

            // listMembers
            this.listMembers.Location = new System.Drawing.Point(12, 38);
            this.listMembers.Size = new System.Drawing.Size(220, 460);
            this.listMembers.SelectedIndexChanged += new System.EventHandler(this.listMembers_SelectedIndexChanged);

            // lblDetails
            this.lblDetails.Text = "Данные участника";
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(250, 12);
            this.lblDetails.Size = new System.Drawing.Size(200, 22);

            // Имя
            this.lblFirstName.Text = "Имя:";
            this.lblFirstName.Location = new System.Drawing.Point(250, 42);
            this.lblFirstName.Size = new System.Drawing.Size(80, 20);
            this.txtFirstName.Location = new System.Drawing.Point(340, 40);
            this.txtFirstName.Size = new System.Drawing.Size(240, 24);

            // Фамилия
            this.lblLastName.Text = "Фамилия:";
            this.lblLastName.Location = new System.Drawing.Point(250, 78);
            this.lblLastName.Size = new System.Drawing.Size(80, 20);
            this.txtLastName.Location = new System.Drawing.Point(340, 76);
            this.txtLastName.Size = new System.Drawing.Size(240, 24);

            // Должность
            this.lblRole.Text = "Должность:";
            this.lblRole.Location = new System.Drawing.Point(250, 114);
            this.lblRole.Size = new System.Drawing.Size(80, 20);
            this.txtRole.Location = new System.Drawing.Point(340, 112);
            this.txtRole.Size = new System.Drawing.Size(240, 24);

            // Опыт
            this.lblExperience.Text = "Опыт (лет):";
            this.lblExperience.Location = new System.Drawing.Point(250, 150);
            this.lblExperience.Size = new System.Drawing.Size(80, 20);
            this.nudExperience.Location = new System.Drawing.Point(340, 148);
            this.nudExperience.Size = new System.Drawing.Size(100, 24);
            this.nudExperience.Minimum = 0;
            this.nudExperience.Maximum = 60;

            // Дата вступления
            this.lblJoinDate.Text = "В группе с:";
            this.lblJoinDate.Location = new System.Drawing.Point(250, 186);
            this.lblJoinDate.Size = new System.Drawing.Size(80, 20);
            this.dtpJoinDate.Location = new System.Drawing.Point(340, 184);
            this.dtpJoinDate.Size = new System.Drawing.Size(240, 24);
            this.dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Активен
            this.chkIsActive.Text = "Активный участник";
            this.chkIsActive.Location = new System.Drawing.Point(340, 220);
            this.chkIsActive.Size = new System.Drawing.Size(180, 22);
            this.chkIsActive.Checked = true;

            // Кнопки
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(340, 256);
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(60, 120, 200);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnNew.Text = "Новый";
            this.btnNew.Location = new System.Drawing.Point(450, 256);
            this.btnNew.Size = new System.Drawing.Size(70, 32);
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(530, 256);
            this.btnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Фото
            this.lblPhoto.Text = "Фото:";
            this.lblPhoto.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblPhoto.Location = new System.Drawing.Point(650, 12);
            this.lblPhoto.Size = new System.Drawing.Size(60, 22);

            this.picPhoto.Location = new System.Drawing.Point(650, 38);
            this.picPhoto.Size = new System.Drawing.Size(150, 150);
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            this.btnSelectPhoto.Text = "Выбрать фото";
            this.btnSelectPhoto.Location = new System.Drawing.Point(650, 196);
            this.btnSelectPhoto.Size = new System.Drawing.Size(120, 30);
            this.btnSelectPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectPhoto.Click += new System.EventHandler(this.btnSelectPhoto_Click);

            // UserControl
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblList,      this.listMembers,
                this.lblDetails,
                this.lblFirstName, this.txtFirstName,
                this.lblLastName,  this.txtLastName,
                this.lblRole,      this.txtRole,
                this.lblExperience,this.nudExperience,
                this.lblJoinDate,  this.dtpJoinDate,
                this.chkIsActive,
                this.btnSave,      this.btnNew,   this.btnDelete,
                this.lblPhoto,     this.picPhoto, this.btnSelectPhoto
            });

            this.Size = new System.Drawing.Size(980, 540);

            ((System.ComponentModel.ISupportInitialize)this.nudExperience).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picPhoto).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox listMembers;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.NumericUpDown nudExperience;
        private System.Windows.Forms.Label lblJoinDate;
        private System.Windows.Forms.DateTimePicker dtpJoinDate;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Button btnSelectPhoto;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
    }
}