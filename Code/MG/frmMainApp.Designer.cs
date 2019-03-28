namespace MG
{
    partial class frmMainApp
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
            this.flowInput = new System.Windows.Forms.FlowLayoutPanel();
            this.flowOutput = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowInput
            // 
            this.flowInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowInput.BackColor = System.Drawing.SystemColors.Control;
            this.flowInput.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowInput.Location = new System.Drawing.Point(12, 12);
            this.flowInput.Name = "flowInput";
            this.flowInput.Size = new System.Drawing.Size(1222, 128);
            this.flowInput.TabIndex = 0;
            // 
            // flowOutput
            // 
            this.flowOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowOutput.BackColor = System.Drawing.SystemColors.Control;
            this.flowOutput.Location = new System.Drawing.Point(12, 137);
            this.flowOutput.Name = "flowOutput";
            this.flowOutput.Size = new System.Drawing.Size(1222, 613);
            this.flowOutput.TabIndex = 1;
            // 
            // frmMainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 748);
            this.Controls.Add(this.flowOutput);
            this.Controls.Add(this.flowInput);
            this.Name = "frmMainApp";
            this.Text = "frmMainApp";
            this.Load += new System.EventHandler(this.frmMainApp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flowInput;
        public System.Windows.Forms.FlowLayoutPanel flowOutput;
    }
}