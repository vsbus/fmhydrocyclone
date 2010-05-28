using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hydrocyclone1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGrid_abg_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Program.UpdateTextBoxFont(tb);

            dataGridView1.CurrentCell.Value = tb.Text;

            Parameters.Processors.ProcessData();
            Program.CopyParametersToCurrentSimulation();
        }

        private void dataGrid_Machine_Coefficients_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Program.UpdateTextBoxFont(tb);

            dataGridView_Machine_Coefficients.CurrentCell.Value = tb.Text;

            Parameters.Processors.ProcessData();
            Program.CopyParametersToCurrentSimulation();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged -= dataGrid_abg_TextChanged;
            e.Control.TextChanged += dataGrid_abg_TextChanged;
            e.Control.KeyPress -= Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;
            e.Control.KeyPress += Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Form2)sender).Hide();
            e.Cancel = true;
        }

        private void dataGridView_Machine_Coefficients_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged -= dataGrid_Machine_Coefficients_TextChanged;
            e.Control.TextChanged += dataGrid_Machine_Coefficients_TextChanged;
            e.Control.KeyPress -= Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;
            e.Control.KeyPress += Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;
        }
    }
}