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
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.btnNavBands = new System.Windows.Forms.Button();
            this.btnNavMembers = new System.Windows.Forms.Button();
            this.btnNavTours = new System.Windows.Forms.Button();
            this.btnNavConcerts = new System.Windows.Forms.Button();
            this.PanelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSidebar
            // 
            this.PanelSidebar.BackColor = System.Drawing.Color.DarkSlateBlue;
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
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(882, 503);
            this.panelContent.TabIndex = 1;
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
            // btnNavBands
            // 
            this.btnNavBands.Location = new System.Drawing.Point(61, 43);
            this.btnNavBands.Name = "btnNavBands";
            this.btnNavBands.Size = new System.Drawing.Size(75, 23);
            this.btnNavBands.TabIndex = 1;
            this.btnNavBands.Text = "btnNavBands";
            this.btnNavBands.UseVisualStyleBackColor = true;
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
            // btnNavTours
            // 
            this.btnNavTours.Location = new System.Drawing.Point(61, 101);
            this.btnNavTours.Name = "btnNavTours";
            this.btnNavTours.Size = new System.Drawing.Size(75, 23);
            this.btnNavTours.TabIndex = 3;
            this.btnNavTours.Text = "btnNavTours";
            this.btnNavTours.UseVisualStyleBackColor = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 503);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.PanelSidebar);
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
    }
}

