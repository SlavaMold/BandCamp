namespace BandCamp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelSidebar = new System.Windows.Forms.Panel();
            this.buttonNavRecording = new System.Windows.Forms.Button();
            this.btnNavConcerts = new System.Windows.Forms.Button();
            this.btnNavTours = new System.Windows.Forms.Button();
            this.btnNavMembers = new System.Windows.Forms.Button();
            this.btnNavBands = new System.Windows.Forms.Button();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonNavReports = new System.Windows.Forms.Button();
            this.PanelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSidebar
            // 
            this.PanelSidebar.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.PanelSidebar.Controls.Add(this.buttonNavReports);
            this.PanelSidebar.Controls.Add(this.buttonNavRecording);
            this.PanelSidebar.Controls.Add(this.btnNavConcerts);
            this.PanelSidebar.Controls.Add(this.btnNavTours);
            this.PanelSidebar.Controls.Add(this.btnNavMembers);
            this.PanelSidebar.Controls.Add(this.btnNavBands);
            this.PanelSidebar.Controls.Add(this.lblAppTitle);
            this.PanelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSidebar.Location = new System.Drawing.Point(0, 0);
            this.PanelSidebar.Name = "PanelSidebar";
            this.PanelSidebar.Size = new System.Drawing.Size(200, 503);
            this.PanelSidebar.TabIndex = 0;
            //undo-redo
            this.panelUndoRedo = new System.Windows.Forms.Panel();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.lblLastAction = new System.Windows.Forms.Label();

            // panelUndoRedo — полоска внизу окна
            this.panelUndoRedo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUndoRedo.Height = 40;
            this.panelUndoRedo.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);

            // btnUndo
            this.btnUndo.Text = "↩ Undo";
            this.btnUndo.Location = new System.Drawing.Point(8, 6);
            this.btnUndo.Size = new System.Drawing.Size(90, 28);
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.ForeColor = System.Drawing.Color.White;
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.btnUndo.Enabled = false;

            // btnRedo
            this.btnRedo.Text = "↪ Redo";
            this.btnRedo.Location = new System.Drawing.Point(106, 6);
            this.btnRedo.Size = new System.Drawing.Size(90, 28);
            this.btnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedo.FlatAppearance.BorderSize = 0;
            this.btnRedo.ForeColor = System.Drawing.Color.White;
            this.btnRedo.BackColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.btnRedo.Enabled = false;

            // lblLastAction
            this.lblLastAction.Text = "";
            this.lblLastAction.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            this.lblLastAction.Location = new System.Drawing.Point(210, 11);
            this.lblLastAction.Size = new System.Drawing.Size(600, 20);
            this.lblLastAction.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.panelUndoRedo.Controls.Add(this.btnUndo);
            this.panelUndoRedo.Controls.Add(this.btnRedo);
            this.panelUndoRedo.Controls.Add(this.lblLastAction);
            //
            // 
            // buttonNavRecording
            // 
            this.buttonNavRecording.Location = new System.Drawing.Point(61, 159);
            this.buttonNavRecording.Name = "buttonNavRecording";
            this.buttonNavRecording.Size = new System.Drawing.Size(75, 23);
            this.buttonNavRecording.TabIndex = 5;
            this.buttonNavRecording.Text = "Записи";
            this.buttonNavRecording.UseVisualStyleBackColor = true;
            // 
            // btnNavConcerts
            // 
            this.btnNavConcerts.Location = new System.Drawing.Point(61, 130);
            this.btnNavConcerts.Name = "btnNavConcerts";
            this.btnNavConcerts.Size = new System.Drawing.Size(75, 23);
            this.btnNavConcerts.TabIndex = 4;
            this.btnNavConcerts.Text = "btnNavConcerts";
            this.btnNavConcerts.UseVisualStyleBackColor = true;
            // 
            // btnNavTours
            // 
            this.btnNavTours.Location = new System.Drawing.Point(61, 101);
            this.btnNavTours.Name = "btnNavTours";
            this.btnNavTours.Size = new System.Drawing.Size(75, 23);
            this.btnNavTours.TabIndex = 3;
            this.btnNavTours.Text = "btnNavTours";
            this.btnNavTours.UseVisualStyleBackColor = true;
            // 
            // btnNavMembers
            // 
            this.btnNavMembers.Location = new System.Drawing.Point(61, 72);
            this.btnNavMembers.Name = "btnNavMembers";
            this.btnNavMembers.Size = new System.Drawing.Size(75, 23);
            this.btnNavMembers.TabIndex = 2;
            this.btnNavMembers.Text = "btnNavMembers";
            this.btnNavMembers.UseVisualStyleBackColor = true;
            // 
            // btnNavBands
            // 
            this.btnNavBands.Location = new System.Drawing.Point(61, 43);
            this.btnNavBands.Name = "btnNavBands";
            this.btnNavBands.Size = new System.Drawing.Size(75, 23);
            this.btnNavBands.TabIndex = 1;
            this.btnNavBands.Text = "btnNavBands";
            this.btnNavBands.UseVisualStyleBackColor = true;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblAppTitle.Location = new System.Drawing.Point(27, 9);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(139, 31);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "BandCamp";
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(882, 503);
            this.panelContent.TabIndex = 1;
            //
            // buttonNavReports
            // 
            this.buttonNavReports.Location = new System.Drawing.Point(61, 188);
            this.buttonNavReports.Name = "buttonNavReports";
            this.buttonNavReports.Size = new System.Drawing.Size(75, 23);
            this.buttonNavReports.TabIndex = 6;
            this.buttonNavReports.Text = "button1";
            this.buttonNavReports.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 503);
            this.Controls.Add(this.panelContent);   // Fill — добавляется первым
            this.Controls.Add(this.panelUndoRedo);  // Bottom
            this.Controls.Add(this.PanelSidebar);   // Left
            this.MinimumSize = new System.Drawing.Size(1100, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Band Camp - Your Band Manager";
            this.PanelSidebar.ResumeLayout(false);
            this.PanelSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelSidebar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnNavBands;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Button btnNavConcerts;
        private System.Windows.Forms.Button btnNavTours;
        private System.Windows.Forms.Button btnNavMembers;
        private System.Windows.Forms.Button buttonNavRecording;
        private System.Windows.Forms.Button buttonNavReports;
        private System.Windows.Forms.Panel panelUndoRedo;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Label lblLastAction;
    }
}

