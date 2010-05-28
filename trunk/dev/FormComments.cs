using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hydrocyclone1
{
    public partial class FormComments : Form
    {
        public FormComments()
        {
            InitializeComponent();
        }

        private void FormComments_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((FormComments)sender).Hide();
            e.Cancel = true;
        }

        private void textBox_Comments_TextChanged(object sender, EventArgs e)
        {
            if (Program.ProgramStatus == Program.StatusRunning)
            {
                DataGridView dg = Program.Form_Main.dataGridView_SimulationListing;
                Simulation sm = Program.GetCurrentSimulation();
                sm.SimulationInfo.WasChanged = true;
                sm.SimulationInfo.Comments = ((TextBox)sender).Text;
                Program.UpdateCurrentSimulationListingRow();
                //Program.UpdateCurrentSimulatoionFromGrid(dg.CurrentCell.RowIndex);
            }
        }

        private void FormComments_Resize(object sender, EventArgs e)
        {
            textBox_Comments.Size = new Size(((FormComments)sender).Size.Width - 32, ((FormComments)sender).Size.Height - 58);            
        }
    }
}