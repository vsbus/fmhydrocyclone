namespace Hydrocyclone1
{
    partial class FormProtocolProperties
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_ffofuSmall = new System.Windows.Forms.ComboBox();
            this.comboBox_FFoFuBig = new System.Windows.Forms.ComboBox();
            this.comboBox_GGred = new System.Windows.Forms.ComboBox();
            this.comboBox_fF = new System.Windows.Forms.ComboBox();
            this.checkBox_fFPlot = new System.Windows.Forms.CheckBox();
            this.checkBox_FFoFuSmallPlot = new System.Windows.Forms.CheckBox();
            this.checkBox_FFoFuBigPlot = new System.Windows.Forms.CheckBox();
            this.checkBox_GGred = new System.Windows.Forms.CheckBox();
            this.checkBox_DataAndTables = new System.Windows.Forms.CheckBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_ffofuSmall);
            this.groupBox1.Controls.Add(this.comboBox_FFoFuBig);
            this.groupBox1.Controls.Add(this.comboBox_GGred);
            this.groupBox1.Controls.Add(this.comboBox_fF);
            this.groupBox1.Controls.Add(this.checkBox_fFPlot);
            this.groupBox1.Controls.Add(this.checkBox_FFoFuSmallPlot);
            this.groupBox1.Controls.Add(this.checkBox_FFoFuBigPlot);
            this.groupBox1.Controls.Add(this.checkBox_GGred);
            this.groupBox1.Controls.Add(this.checkBox_DataAndTables);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox_ffofuSmall
            // 
            this.comboBox_ffofuSmall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ffofuSmall.FormattingEnabled = true;
            this.comboBox_ffofuSmall.Items.AddRange(new object[] {
            "Linear",
            "Logarithmic"});
            this.comboBox_ffofuSmall.Location = new System.Drawing.Point(150, 86);
            this.comboBox_ffofuSmall.Name = "comboBox_ffofuSmall";
            this.comboBox_ffofuSmall.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ffofuSmall.TabIndex = 8;
            // 
            // comboBox_FFoFuBig
            // 
            this.comboBox_FFoFuBig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FFoFuBig.FormattingEnabled = true;
            this.comboBox_FFoFuBig.Items.AddRange(new object[] {
            "Linear",
            "Logarithmic"});
            this.comboBox_FFoFuBig.Location = new System.Drawing.Point(150, 63);
            this.comboBox_FFoFuBig.Name = "comboBox_FFoFuBig";
            this.comboBox_FFoFuBig.Size = new System.Drawing.Size(121, 21);
            this.comboBox_FFoFuBig.TabIndex = 7;
            // 
            // comboBox_GGred
            // 
            this.comboBox_GGred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_GGred.FormattingEnabled = true;
            this.comboBox_GGred.Items.AddRange(new object[] {
            "Linear",
            "Logarithmic"});
            this.comboBox_GGred.Location = new System.Drawing.Point(150, 40);
            this.comboBox_GGred.Name = "comboBox_GGred";
            this.comboBox_GGred.Size = new System.Drawing.Size(121, 21);
            this.comboBox_GGred.TabIndex = 6;
            // 
            // comboBox_fF
            // 
            this.comboBox_fF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fF.FormattingEnabled = true;
            this.comboBox_fF.Items.AddRange(new object[] {
            "Linear",
            "Logarithmic"});
            this.comboBox_fF.Location = new System.Drawing.Point(150, 109);
            this.comboBox_fF.Name = "comboBox_fF";
            this.comboBox_fF.Size = new System.Drawing.Size(121, 21);
            this.comboBox_fF.TabIndex = 5;
            // 
            // checkBox_fFPlot
            // 
            this.checkBox_fFPlot.AutoSize = true;
            this.checkBox_fFPlot.Location = new System.Drawing.Point(6, 111);
            this.checkBox_fFPlot.Name = "checkBox_fFPlot";
            this.checkBox_fFPlot.Size = new System.Drawing.Size(79, 17);
            this.checkBox_fFPlot.TabIndex = 4;
            this.checkBox_fFPlot.Text = "f anf F  plot";
            this.checkBox_fFPlot.UseVisualStyleBackColor = true;
            // 
            // checkBox_FFoFuSmallPlot
            // 
            this.checkBox_FFoFuSmallPlot.AutoSize = true;
            this.checkBox_FFoFuSmallPlot.Location = new System.Drawing.Point(6, 88);
            this.checkBox_FFoFuSmallPlot.Name = "checkBox_FFoFuSmallPlot";
            this.checkBox_FFoFuSmallPlot.Size = new System.Drawing.Size(100, 17);
            this.checkBox_FFoFuSmallPlot.TabIndex = 3;
            this.checkBox_FFoFuSmallPlot.Text = "f, fo and fu  plot";
            this.checkBox_FFoFuSmallPlot.UseVisualStyleBackColor = true;
            // 
            // checkBox_FFoFuBigPlot
            // 
            this.checkBox_FFoFuBigPlot.AutoSize = true;
            this.checkBox_FFoFuBigPlot.Location = new System.Drawing.Point(6, 65);
            this.checkBox_FFoFuBigPlot.Name = "checkBox_FFoFuBigPlot";
            this.checkBox_FFoFuBigPlot.Size = new System.Drawing.Size(109, 17);
            this.checkBox_FFoFuBigPlot.TabIndex = 2;
            this.checkBox_FFoFuBigPlot.Text = "F, Fo and Fu  plot";
            this.checkBox_FFoFuBigPlot.UseVisualStyleBackColor = true;
            // 
            // checkBox_GGred
            // 
            this.checkBox_GGred.AutoSize = true;
            this.checkBox_GGred.Location = new System.Drawing.Point(6, 42);
            this.checkBox_GGred.Name = "checkBox_GGred";
            this.checkBox_GGred.Size = new System.Drawing.Size(91, 17);
            this.checkBox_GGred.TabIndex = 1;
            this.checkBox_GGred.Text = "G and G\'  plot";
            this.checkBox_GGred.UseVisualStyleBackColor = true;
            // 
            // checkBox_DataAndTables
            // 
            this.checkBox_DataAndTables.AutoSize = true;
            this.checkBox_DataAndTables.Checked = true;
            this.checkBox_DataAndTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DataAndTables.Location = new System.Drawing.Point(6, 19);
            this.checkBox_DataAndTables.Name = "checkBox_DataAndTables";
            this.checkBox_DataAndTables.Size = new System.Drawing.Size(105, 17);
            this.checkBox_DataAndTables.TabIndex = 0;
            this.checkBox_DataAndTables.Text = "Data and Tables";
            this.checkBox_DataAndTables.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 179);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(131, 36);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "Export to Word";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(158, 179);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(131, 36);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(69, 155);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(1280, 880);
            this.zedGraphControl1.TabIndex = 3;
            this.zedGraphControl1.Visible = false;
            // 
            // FormProtocolProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 230);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "FormProtocolProperties";
            this.Text = "FormProtocolProperties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProtocolProperties_FormClosing);
            this.Load += new System.EventHandler(this.FormProtocolProperties_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        public  System.Windows.Forms.CheckBox checkBox_fFPlot;
        public  System.Windows.Forms.CheckBox checkBox_FFoFuSmallPlot;
        public  System.Windows.Forms.CheckBox checkBox_FFoFuBigPlot;
        public  System.Windows.Forms.CheckBox checkBox_GGred;
        public  System.Windows.Forms.CheckBox checkBox_DataAndTables;
        public  ZedGraph.ZedGraphControl zedGraphControl1;
        public  System.Windows.Forms.ComboBox comboBox_ffofuSmall;
        public  System.Windows.Forms.ComboBox comboBox_FFoFuBig;
        public  System.Windows.Forms.ComboBox comboBox_GGred;
        public  System.Windows.Forms.ComboBox comboBox_fF;
    }
}