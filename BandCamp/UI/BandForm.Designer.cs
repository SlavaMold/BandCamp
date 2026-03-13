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
            this.SuspendLayout();

            // lblBands
            this.lblBands.Text = "Группы";
            this.lblBands.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblBands.Location = new System.Drawing.Point(12, 12);
            this.lblBands.Size = new System.Drawing.Size(200, 22);

            // listBands
            this.listBands.Location = new System.Drawing.Point(12, 38);
            this.listBands.Size = new System.Drawing.Size(220, 480);
            this.listBands.SelectedIndexChanged += new System.EventHandler(this.listBands_SelectedIndexChanged);

            // lblDetails
            this.lblDetails.Text = "Детали группы";
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(250, 12);
            this.lblDetails.Size = new System.Drawing.Size(200, 22);

            // lblName / txtName
            this.lblName.Text = "Название:";
            this.lblName.Location = new System.Drawing.Point(250, 42);
            this.lblName.Size = new System.Drawing.Size(80, 20);
            this.txtName.Location = new System.Drawing.Point(340, 40);
            this.txtName.Size = new System.Drawing.Size(280, 24);

            // lblGenre / txtGenre
            this.lblGenre.Text = "Жанр:";
            this.lblGenre.Location = new System.Drawing.Point(250, 78);
            this.lblGenre.Size = new System.Drawing.Size(80, 20);
            this.txtGenre.Location = new System.Drawing.Point(340, 76);
            this.txtGenre.Size = new System.Drawing.Size(280, 24);

            // lblFormation / dtpFormation
            this.lblFormation.Text = "Основана:";
            this.lblFormation.Location = new System.Drawing.Point(250, 114);
            this.lblFormation.Size = new System.Drawing.Size(80, 20);
            this.dtpFormation.Location = new System.Drawing.Point(340, 112);
            this.dtpFormation.Size = new System.Drawing.Size(280, 24);
            this.dtpFormation.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // lblDescription / txtDescription
            this.lblDescription.Text = "Описание:";
            this.lblDescription.Location = new System.Drawing.Point(250, 150);
            this.lblDescription.Size = new System.Drawing.Size(80, 20);
            this.txtDescription.Location = new System.Drawing.Point(340, 148);
            this.txtDescription.Size = new System.Drawing.Size(280, 80);
            this.txtDescription.Multiline = true;

            // buttons
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(340, 244);
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(60, 120, 200);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnNew.Text = "Новая";
            this.btnNew.Location = new System.Drawing.Point(450, 244);
            this.btnNew.Size = new System.Drawing.Size(80, 32);
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(540, 244);
            this.btnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // lblMembers / listMembers
            this.lblMembers.Text = "Участники группы";
            this.lblMembers.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblMembers.Location = new System.Drawing.Point(650, 12);
            this.lblMembers.Size = new System.Drawing.Size(200, 22);

            this.listMembers.Location = new System.Drawing.Point(650, 38);
            this.listMembers.Size = new System.Drawing.Size(280, 280);

            this.btnRemoveMember.Text = "Убрать из группы";
            this.btnRemoveMember.Location = new System.Drawing.Point(650, 326);
            this.btnRemoveMember.Size = new System.Drawing.Size(150, 32);
            this.btnRemoveMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMember.Click += new System.EventHandler(this.btnRemoveMember_Click);

            // BandForm
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblBands,    this.listBands,
                this.lblDetails,
                this.lblName,     this.txtName,
                this.lblGenre,    this.txtGenre,
                this.lblFormation,this.dtpFormation,
                this.lblDescription, this.txtDescription,
                this.btnSave,     this.btnNew,     this.btnDelete,
                this.lblMembers,  this.listMembers, this.btnRemoveMember
            });

            this.Size = new System.Drawing.Size(980, 560);
            this.ResumeLayout(false);
        }

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