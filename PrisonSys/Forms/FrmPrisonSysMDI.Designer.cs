namespace PrisonSys
{
    partial class FrmPrisonSysMDI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addPrisonerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePrisonersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prisonerHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewToolStripMenuItem,
            this.resourcesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPrisonerToolStripMenuItem,
            this.managePrisonersToolStripMenuItem,
            this.manageCellsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(98, 20);
            this.fileMenu.Text = "&Administration";
            // 
            // addPrisonerToolStripMenuItem
            // 
            this.addPrisonerToolStripMenuItem.Name = "addPrisonerToolStripMenuItem";
            this.addPrisonerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addPrisonerToolStripMenuItem.Text = "&Add Prisoner";
            this.addPrisonerToolStripMenuItem.Click += new System.EventHandler(this.addPrisonerToolStripMenuItem_Click);
            // 
            // managePrisonersToolStripMenuItem
            // 
            this.managePrisonersToolStripMenuItem.Name = "managePrisonersToolStripMenuItem";
            this.managePrisonersToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.managePrisonersToolStripMenuItem.Text = "Manage &Prisoners";
            // 
            // manageCellsToolStripMenuItem
            // 
            this.manageCellsToolStripMenuItem.Name = "manageCellsToolStripMenuItem";
            this.manageCellsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.manageCellsToolStripMenuItem.Text = "Manage &Cells";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prisonerHistoryToolStripMenuItem,
            this.cellStatusToolStripMenuItem,
            this.employeeListToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // prisonerHistoryToolStripMenuItem
            // 
            this.prisonerHistoryToolStripMenuItem.Name = "prisonerHistoryToolStripMenuItem";
            this.prisonerHistoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.prisonerHistoryToolStripMenuItem.Text = "&Prisoner History";
            // 
            // cellStatusToolStripMenuItem
            // 
            this.cellStatusToolStripMenuItem.Name = "cellStatusToolStripMenuItem";
            this.cellStatusToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.cellStatusToolStripMenuItem.Text = "&Cell Status";
            // 
            // employeeListToolStripMenuItem
            // 
            this.employeeListToolStripMenuItem.Name = "employeeListToolStripMenuItem";
            this.employeeListToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.employeeListToolStripMenuItem.Text = "&Employee List";
            // 
            // resourcesToolStripMenuItem
            // 
            this.resourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem,
            this.manageToolStripMenuItem1,
            this.manageToolStripMenuItem2});
            this.resourcesToolStripMenuItem.Name = "resourcesToolStripMenuItem";
            this.resourcesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.resourcesToolStripMenuItem.Text = "&Resources";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.manageToolStripMenuItem.Text = "Manage &Cellblock Types";
            // 
            // manageToolStripMenuItem1
            // 
            this.manageToolStripMenuItem1.Name = "manageToolStripMenuItem1";
            this.manageToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.manageToolStripMenuItem1.Text = "Manage &Assignment Types";
            // 
            // manageToolStripMenuItem2
            // 
            this.manageToolStripMenuItem2.Name = "manageToolStripMenuItem2";
            this.manageToolStripMenuItem2.Size = new System.Drawing.Size(217, 22);
            this.manageToolStripMenuItem2.Text = "Manage &Supervisors";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // PrisonSysMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PrisonSysMDI";
            this.Text = "PrisonSysMDI";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem addPrisonerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePrisonersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prisonerHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cellStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem2;
    }
}



