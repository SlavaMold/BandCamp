using System.Linq;

namespace BandCamp.UI
{
    partial class BandForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBands = new System.Windows.Forms.ListBox();
            this.listMembers = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpFormation = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRemoveMember = new System.Windows.Forms.Button();
            this.lblBands = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblMembers = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblFormation = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSelectPhoto = new System.Windows.Forms.Button();
            this.picMemberPhoto = new System.Windows.Forms.PictureBox();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.btnExport = new System.Windows.Forms.Button();
            this.btnExport.Text = "Экспорт в CSV";
            this.btnExport.Location = new System.Drawing.Point(340, 290);
            this.btnExport.Size = new System.Drawing.Size(120, 32);
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // 
            // listBands
            // 
            this.listBands.ItemHeight = 16;
            this.listBands.Location = new System.Drawing.Point(12, 38);
            this.listBands.Name = "listBands";
            this.listBands.Size = new System.Drawing.Size(220, 468);
            this.listBands.TabIndex = 1;
            this.listBands.SelectedIndexChanged += new System.EventHandler(this.listBands_SelectedIndexChanged);
            // 
            // listMembers
            // 
            this.listMembers.ItemHeight = 16;
            this.listMembers.Location = new System.Drawing.Point(650, 38);
            this.listMembers.Name = "listMembers";
            this.listMembers.Size = new System.Drawing.Size(280, 276);
            this.listMembers.TabIndex = 15;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(340, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 22);
            this.txtName.TabIndex = 4;
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(340, 76);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(280, 22);
            this.txtGenre.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(340, 148);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(280, 80);
            this.txtDescription.TabIndex = 10;
            // 
            // dtpFormation
            // 
            this.dtpFormation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFormation.Location = new System.Drawing.Point(340, 112);
            this.dtpFormation.Name = "dtpFormation";
            this.dtpFormation.Size = new System.Drawing.Size(280, 22);
            this.dtpFormation.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(340, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(450, 244);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 32);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "Новая";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDelete.Location = new System.Drawing.Point(540, 244);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRemoveMember
            // 
            this.btnRemoveMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMember.Location = new System.Drawing.Point(650, 326);
            this.btnRemoveMember.Name = "btnRemoveMember";
            this.btnRemoveMember.Size = new System.Drawing.Size(150, 32);
            this.btnRemoveMember.TabIndex = 16;
            this.btnRemoveMember.Text = "Убрать из группы";
            this.btnRemoveMember.Click += new System.EventHandler(this.btnRemoveMember_Click);

            // lblPhoto
            this.lblPhoto.Text = "Фото участника:";
            this.lblPhoto.Location = new System.Drawing.Point(650, 370);
            this.lblPhoto.Size = new System.Drawing.Size(120, 20);

            // picMemberPhoto
            this.picMemberPhoto.Location = new System.Drawing.Point(650, 395);
            this.picMemberPhoto.Size = new System.Drawing.Size(120, 120);
            this.picMemberPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMemberPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMemberPhoto.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            // btnSelectPhoto
            this.btnSelectPhoto.Text = "Выбрать фото";
            this.btnSelectPhoto.Location = new System.Drawing.Point(650, 522);
            this.btnSelectPhoto.Size = new System.Drawing.Size(120, 30);
            this.btnSelectPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectPhoto.Click += new System.EventHandler(this.btnSelectPhoto_Click);

            // 
            // lblBands
            // 
            this.lblBands.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBands.Location = new System.Drawing.Point(12, 12);
            this.lblBands.Name = "lblBands";
            this.lblBands.Size = new System.Drawing.Size(200, 22);
            this.lblBands.TabIndex = 0;
            this.lblBands.Text = "Группы";
            // 
            // lblDetails
            // 
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(250, 12);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(200, 22);
            this.lblDetails.TabIndex = 2;
            this.lblDetails.Text = "Детали группы";
            // 
            // lblMembers
            // 
            this.lblMembers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMembers.Location = new System.Drawing.Point(650, 12);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(200, 22);
            this.lblMembers.TabIndex = 14;
            this.lblMembers.Text = "Участники группы";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(250, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 20);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Название:";
            // 
            // lblGenre
            // 
            this.lblGenre.Location = new System.Drawing.Point(250, 78);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(80, 20);
            this.lblGenre.TabIndex = 5;
            this.lblGenre.Text = "Жанр:";
            // 
            // lblFormation
            // 
            this.lblFormation.Location = new System.Drawing.Point(250, 114);
            this.lblFormation.Name = "lblFormation";
            this.lblFormation.Size = new System.Drawing.Size(80, 20);
            this.lblFormation.TabIndex = 7;
            this.lblFormation.Text = "Основана:";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(250, 150);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 20);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Описание:";
            // 
            // BandForm
            // 
            this.Controls.Add(this.lblBands);
            this.Controls.Add(this.listBands);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblFormation);
            this.Controls.Add(this.dtpFormation);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblMembers);
            this.Controls.Add(this.listMembers);
            this.Controls.Add(this.btnRemoveMember);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.picMemberPhoto);
            this.Controls.Add(this.btnSelectPhoto);
            this.Name = "BandForm";
            this.Size = new System.Drawing.Size(980, 560);
            this.Load += new System.EventHandler(this.BandForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnSelectPhoto;
        private System.Windows.Forms.PictureBox picMemberPhoto;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ListBox listBands;
        private System.Windows.Forms.ListBox listMembers;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpFormation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRemoveMember;
        private System.Windows.Forms.Label lblBands;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblFormation;
        private System.Windows.Forms.Label lblDescription;
    }
}