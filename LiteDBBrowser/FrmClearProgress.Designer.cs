namespace LiteDBBrowser
{
    partial class FrmClearProgress
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
            this.PbProgress = new System.Windows.Forms.ProgressBar();
            this.LblCurrentNode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PbProgress
            // 
            this.PbProgress.Location = new System.Drawing.Point(12, 29);
            this.PbProgress.Name = "PbProgress";
            this.PbProgress.Size = new System.Drawing.Size(318, 23);
            this.PbProgress.TabIndex = 0;
            // 
            // LblCurrentNode
            // 
            this.LblCurrentNode.AutoSize = true;
            this.LblCurrentNode.Location = new System.Drawing.Point(13, 13);
            this.LblCurrentNode.Name = "LblCurrentNode";
            this.LblCurrentNode.Size = new System.Drawing.Size(35, 13);
            this.LblCurrentNode.TabIndex = 1;
            this.LblCurrentNode.Text = "label1";
            // 
            // FrmClearProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 58);
            this.ControlBox = false;
            this.Controls.Add(this.LblCurrentNode);
            this.Controls.Add(this.PbProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmClearProgress";
            this.Text = "Clearing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar PbProgress;
        public System.Windows.Forms.Label LblCurrentNode;
    }
}