namespace LiteDBBrowser
{
    partial class FrmBrowseDB
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
            this.BtnOpenDatabase = new System.Windows.Forms.Button();
            this.TvDB = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SlStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblNodeCount = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnOpenDatabase
            // 
            this.BtnOpenDatabase.Location = new System.Drawing.Point(13, 13);
            this.BtnOpenDatabase.Name = "BtnOpenDatabase";
            this.BtnOpenDatabase.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenDatabase.TabIndex = 0;
            this.BtnOpenDatabase.Text = "Database";
            this.BtnOpenDatabase.UseVisualStyleBackColor = true;
            this.BtnOpenDatabase.Click += new System.EventHandler(this.BtnOpenDatabase_Click);
            // 
            // TvDB
            // 
            this.TvDB.Location = new System.Drawing.Point(13, 43);
            this.TvDB.Name = "TvDB";
            this.TvDB.Size = new System.Drawing.Size(775, 382);
            this.TvDB.TabIndex = 1;
            this.TvDB.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvDB_BeforeExpand);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SlStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SlStatus
            // 
            this.SlStatus.Name = "SlStatus";
            this.SlStatus.Size = new System.Drawing.Size(39, 17);
            this.SlStatus.Text = "Ready";
            // 
            // LblNodeCount
            // 
            this.LblNodeCount.AutoSize = true;
            this.LblNodeCount.Location = new System.Drawing.Point(374, 13);
            this.LblNodeCount.Name = "LblNodeCount";
            this.LblNodeCount.Size = new System.Drawing.Size(35, 13);
            this.LblNodeCount.TabIndex = 3;
            this.LblNodeCount.Text = "label1";
            // 
            // FrmBrowseDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblNodeCount);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TvDB);
            this.Controls.Add(this.BtnOpenDatabase);
            this.Name = "FrmBrowseDB";
            this.Text = "Browse Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBrowseDB_FormClosing);
            this.Resize += new System.EventHandler(this.FrmBrowseDB_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOpenDatabase;
        private System.Windows.Forms.TreeView TvDB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SlStatus;
        private System.Windows.Forms.Label LblNodeCount;
    }
}

