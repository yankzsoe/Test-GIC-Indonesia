namespace ContactApps {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucAction = new ContactApps.View.Component.UcAction();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ucHeader = new ContactApps.View.Component.UcHeader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucAction);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlContent);
            this.splitContainer1.Panel2.Controls.Add(this.ucHeader);
            this.splitContainer1.Size = new System.Drawing.Size(651, 508);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucAction
            // 
            this.ucAction.BackColor = System.Drawing.Color.Teal;
            this.ucAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAction.Location = new System.Drawing.Point(0, 0);
            this.ucAction.Name = "ucAction";
            this.ucAction.Size = new System.Drawing.Size(96, 508);
            this.ucAction.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 34);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(551, 474);
            this.pnlContent.TabIndex = 1;
            // 
            // ucHeader
            // 
            this.ucHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucHeader.Location = new System.Drawing.Point(0, 0);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.Size = new System.Drawing.Size(551, 34);
            this.ucHeader.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 508);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Contact Application";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private View.Component.UcAction ucAction;
        private View.Component.UcHeader ucHeader;
        private System.Windows.Forms.Panel pnlContent;
    }
}

