using System;
using System.Windows.Forms;

namespace Hydrocyclone1
{
    public partial class FormProtocolProperties : Form
    {
        public FormProtocolProperties()
        {
            InitializeComponent();
        }

        private void FormProtocolProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((FormProtocolProperties)sender).Hide();
            e.Cancel = true;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Program.Form_ProtocolProperties.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Parameters.Processors.ExportToWord(true, true, true, true, true);
            //Program.Form_ProtocolProperties.Close();
        }

        private void FormProtocolProperties_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.Border.Color = System.Drawing.Color.White;
            comboBox_fF.Text = "Logarithmic";
            comboBox_GGred.Text = "Logarithmic";
            comboBox_FFoFuBig.Text = "Logarithmic";
            comboBox_ffofuSmall.Text = "Logarithmic";
        }
    }
}