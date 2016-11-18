namespace Shitposter {
    partial class Shitpost {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shitpost));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.textProfanity = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPost);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 31);
            this.panel1.TabIndex = 1;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(738, 4);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(74, 23);
            this.btnPost.TabIndex = 1;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(371, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(74, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.Generate);
            // 
            // textProfanity
            // 
            this.textProfanity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textProfanity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textProfanity.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfanity.Location = new System.Drawing.Point(0, 0);
            this.textProfanity.Multiline = true;
            this.textProfanity.Name = "textProfanity";
            this.textProfanity.Size = new System.Drawing.Size(816, 175);
            this.textProfanity.TabIndex = 2;
            // 
            // Shitpost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 206);
            this.Controls.Add(this.textProfanity);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Shitpost";
            this.Text = "Behold, Profanotron";
            this.Load += new System.EventHandler(this.Generate);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox textProfanity;
    }
}

