namespace Shitposter {
    partial class LoginPanel {
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
            this.label1 = new System.Windows.Forms.Label();
            this.textKey = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.textPin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Secret Key";
            // 
            // textKey
            // 
            this.textKey.Location = new System.Drawing.Point(94, 6);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(335, 20);
            this.textKey.TabIndex = 1;
            this.textKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textKey_KeyUp);
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(46, 40);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(25, 13);
            this.lblPin.TabIndex = 2;
            this.lblPin.Text = "PIN";
            // 
            // textPin
            // 
            this.textPin.Enabled = false;
            this.textPin.Location = new System.Drawing.Point(94, 40);
            this.textPin.Name = "textPin";
            this.textPin.Size = new System.Drawing.Size(335, 20);
            this.textPin.TabIndex = 3;
            this.textPin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textPin_KeyUp);
            // 
            // LoginPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 72);
            this.Controls.Add(this.textPin);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.textKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginPanel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textKey;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox textPin;
    }
}