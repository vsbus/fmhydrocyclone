namespace Hydrocyclone1
{
    partial class FormComments
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
            this.textBox_Comments = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_Comments
            // 
            this.textBox_Comments.Location = new System.Drawing.Point(12, 12);
            this.textBox_Comments.Multiline = true;
            this.textBox_Comments.Name = "textBox_Comments";
            this.textBox_Comments.Size = new System.Drawing.Size(268, 242);
            this.textBox_Comments.TabIndex = 0;
            this.textBox_Comments.TextChanged += new System.EventHandler(this.textBox_Comments_TextChanged);
            // 
            // FormComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.textBox_Comments);
            this.Name = "FormComments";
            this.Text = "Comments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormComments_FormClosing);
            this.Resize += new System.EventHandler(this.FormComments_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox_Comments;
    }
}