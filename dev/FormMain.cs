using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Word;

namespace Hydrocyclone1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Simulation> sim_list = Program.SimulationList_Current;
            
            dataGridView_SimulationListing.RowCount = sim_list.Count;
            for (int i = 0; i < sim_list.Count; ++i)
            {
                DataGridViewCellCollection cell = dataGridView_SimulationListing.Rows[i].Cells;
                Simulation sm = sim_list[i];

                cell["SimulationName"].Value = sm.SimulationInfo.Name;
                cell["ID"].Value = sm.SimulationInfo.ID;
                cell["Material"].Value = sm.SimulationInfo.Material;
                cell["Custumer"].Value = sm.SimulationInfo.Custumer;
                cell["Charge"].Value = sm.SimulationInfo.Charge;
                cell["Comments"].Value = sm.SimulationInfo.Comments;                
            }
            Program.Form_Comments.textBox_Comments.Text = sim_list[0].SimulationInfo.Comments;

            dataGrid_Inputs1.RowCount = 20;
            for (int i = 0; i < dataGrid_Inputs1.RowCount; ++i)
            {
                dataGrid_Inputs1.Rows[i].Resizable = DataGridViewTriState.False;
                dataGrid_Inputs1.Rows[i].Cells["Value"].Value = new object();
                dataGrid_Inputs1.Rows[i].Cells["Value"].Value = " ";
            }

        // dataGrid_Inputs1
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.mu], "mu", Parameters.ParameterUnitsStruct.mu);
            MakeDelimiter(dataGrid_Inputs1.Rows[1]);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.rho_f], "rho_f", Parameters.ParameterUnitsStruct.rho_f);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.rho_s], "rho_s", Parameters.ParameterUnitsStruct.rho_s);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.rho_sus], "rho_sus", Parameters.ParameterUnitsStruct.rho_sus);
            MakeDelimiter(dataGrid_Inputs1.Rows[5]);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.Cm], "Cm", Parameters.ParameterUnitsStruct.Cm);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.Cv], "Cv", Parameters.ParameterUnitsStruct.Cv);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.C], "C", Parameters.ParameterUnitsStruct.C);
            MakeDelimiter(dataGrid_Inputs1.Rows[9]);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.x_g], "x_g", Parameters.ParameterUnitsStruct.x_g);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.sigma_g], "sigma_g", Parameters.ParameterUnitsStruct.sigma_g);
            MakeDelimiter(dataGrid_Inputs1.Rows[12]);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.sigma_s], "sigma_s", Parameters.ParameterUnitsStruct.sigma_s);
            MakeDelimiter(dataGrid_Inputs1.Rows[14]);
            //Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.Q], "Q", Parameters.ParameterUnitsStruct.Q);
            //Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.Qm], "Qm", Parameters.ParameterUnitsStruct.Qm);
            MakeDelimiter(dataGrid_Inputs1.Rows[17]);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.rf], "rf", Parameters.ParameterUnitsStruct.rf);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.Du_over_D], "Du/D", Parameters.ParameterUnitsStruct.Du_over_D);
            //MakeDelimiter(dataGrid_Inputs1.Rows[20]);
            //Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.n], "n", Parameters.ParameterUnitsStruct.n);
            //Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.Dp], "Dp", Parameters.ParameterUnitsStruct.Dp);
            //MakeDelimiter(dataGrid_Inputs1.Rows[23]);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.x_red_50], "x'_50", Parameters.ParameterUnitsStruct.x_red_50);
            Fill_DataGridView_Row(dataGrid_Inputs1.Rows[Program.InputParametersIndexes.D], "D", Parameters.ParameterUnitsStruct.D);

        // dataGrid_Inputs2
            dataGrid_Inputs2.RowCount = 6;
            Fill_DataGridView_Row(dataGrid_Inputs2.Rows[Program.InputParametersIndexes.n], "n", Parameters.ParameterUnitsStruct.n);
            Fill_DataGridView_Row(dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Dp], "Dp", Parameters.ParameterUnitsStruct.Dp);
            MakeDelimiter(dataGrid_Inputs2.Rows[2]);
            //Fill_DataGridView_Row(dataGrid_Inputs2.Rows[1], "Dp", Parameters.ParameterUnitsStruct.Dp);
            Fill_DataGridView_Row(dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Q], "Q", Parameters.ParameterUnitsStruct.Q);
            Fill_DataGridView_Row(dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qm], "Qm", Parameters.ParameterUnitsStruct.Qm);
            
            //Fill_DataGridView_Row(dataGrid_Inputs2.Rows[2], "Q", Parameters.ParameterUnitsStruct.Q);
            //Fill_DataGridView_Row(dataGrid_Inputs2.Rows[3], "Qm", Parameters.ParameterUnitsStruct.Qm);
            Fill_DataGridView_Row(dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qs], "Qs", Parameters.ParameterUnitsStruct.Qs);


            comboBox_AxisType1.Text = "Logarithmic";
            comboBox_AxisType2.Text = "Logarithmic";
        
            Program.ProgramStatus = Program.StatusRunning;

            dataGridView_SimulationListing.CurrentCell = dataGridView_SimulationListing.Rows[0].Cells["SimulationName"];
        }

        public  void Fill_DataGridView_Row(DataGridViewRow r, String parameter_name, UnitStruct units)
        {
            r.Height = 18;
            //r.Cells["Parameter"].Value = parameter_name;
            r.Cells[0].Value = parameter_name;
            //r.Cells["Units"].Value = units.parameter_name;
            r.Cells[1].Value = units.Name;
        }

        public  void MakeDelimiter(DataGridViewRow r)
        {
            r.Height = 0;
            for (int i = 0; i < r.Cells.Count; ++i)
            {
                r.Cells[i].ReadOnly = true;
                r.Cells[i].Style.BackColor = Color.LightGreen;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {            
            Program.SaveSimulationsToFile(Program.SimulationList_Saved, "simuls.dat");
        }

        /*
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Program.ProgramStatus == Program.StatusRunning)
            {
                DataGridView dg = dataGridView_SimulationListing;
                Simulation sm = Program.GetCurrentSimulation();
                sm.SimulationInfo.WasChanged = true;
                sm.SimulationInfo.Comments = ((TextBox)sender).Text;
                Program.UpdateCurrentSimulationListingRow();
                //Program.UpdateCurrentSimulatoionFromGrid(dg.CurrentCell.RowIndex);
            }
        } 
         */

        private void dataGrid_Inputs_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Program.UpdateTextBoxFont(tb);

            dataGrid_Inputs1.CurrentCell.Value = tb.Text;
            
            if (dataGrid_Inputs1.CurrentCell.RowIndex == Program.InputParametersIndexes.rho_s)
            {                
                Parameters.ParameterInputInfoStruct.Is_rho_s_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_rho_sus_Inputed = false;
            }

            if (dataGrid_Inputs1.CurrentCell.RowIndex == Program.InputParametersIndexes.rho_sus)
            {
                Parameters.ParameterInputInfoStruct.Is_rho_sus_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_rho_s_Inputed = false;
            }

            if (dataGrid_Inputs1.CurrentCell.RowIndex == Program.InputParametersIndexes.C)
            {
                Parameters.ParameterInputInfoStruct.Is_C_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Cm_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Cv_Inputed = false;
            }

            if (dataGrid_Inputs1.CurrentCell.RowIndex == Program.InputParametersIndexes.Cm)
            {
                Parameters.ParameterInputInfoStruct.Is_C_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Cm_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Cv_Inputed = false;
            }

            if (dataGrid_Inputs1.CurrentCell.RowIndex == Program.InputParametersIndexes.Cv)
            {
                Parameters.ParameterInputInfoStruct.Is_C_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Cm_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Cv_Inputed = true;
            }

            if (dataGrid_Inputs1.CurrentCell.RowIndex == Program.InputParametersIndexes.rf)
            {
                Parameters.ParameterInputInfoStruct.Is_rf_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Du_over_D_Inputed = false;
            }

            if (dataGrid_Inputs1.CurrentCell.RowIndex == Program.InputParametersIndexes.Du_over_D)
            {
                Parameters.ParameterInputInfoStruct.Is_rf_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Du_over_D_Inputed = true;

            }

            if (dataGrid_Inputs1.CurrentCell.RowIndex == Program.InputParametersIndexes.x_red_50)
            {
                Parameters.ParameterInputInfoStruct.Is_x_red_50_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_D_Inputed = false;
            }

            if (dataGrid_Inputs1.CurrentCell.RowIndex == Program.InputParametersIndexes.D)
            {
                Parameters.ParameterInputInfoStruct.Is_x_red_50_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_D_Inputed = true;
            }
            
            Parameters.Processors.ProcessData();
            Program.CopyParametersToCurrentSimulation(); 
        }

        private void dataGrid_Inputs2_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Program.UpdateTextBoxFont(tb);

            dataGrid_Inputs2.CurrentCell.Value = tb.Text;

            if (dataGrid_Inputs2.CurrentCell.RowIndex == Program.InputParametersIndexes.Q)
            {
                Parameters.ParameterInputInfoStruct.Is_Q_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Qm_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Qs_Inputed = false;
            }

            if (dataGrid_Inputs2.CurrentCell.RowIndex == Program.InputParametersIndexes.Qm)
            {
                Parameters.ParameterInputInfoStruct.Is_Q_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Qm_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Qs_Inputed = false;
            }

            if (dataGrid_Inputs2.CurrentCell.RowIndex == Program.InputParametersIndexes.Qs)
            {
                Parameters.ParameterInputInfoStruct.Is_Q_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Qm_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Qs_Inputed = true;
            }

            /*
            if (dataGrid_Inputs2.CurrentCell.RowIndex == Program.InputParametersIndexes.n)
            {
                Parameters.ParameterInputInfoStruct.Is_rf_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Du_over_D_Inputed = false;

                Parameters.ParameterInputInfoStruct.Is_n_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Dp_Inputed = false;

                Parameters.ParameterInputInfoStruct.Is_x_red_50_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_D_Inputed = false;
            }

            if (dataGrid_Inputs2.CurrentCell.RowIndex == Program.InputParametersIndexes.Dp)
            {
                Parameters.ParameterInputInfoStruct.Is_rf_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Du_over_D_Inputed = true;

                Parameters.ParameterInputInfoStruct.Is_n_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Dp_Inputed = true;

                Parameters.ParameterInputInfoStruct.Is_x_red_50_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_D_Inputed = true;
            }
             */

            Parameters.Processors.ProcessData();
            Program.CopyParametersToCurrentSimulation();
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            Program.LoadSimulationFromSaved();
        }

        private void dataGridView_SimulationListing_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
        }

        private void dataGridView_SimulationListing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView_SimulationListing_CurrentCellChanged(object sender, EventArgs e)
        {
            if (Program.ProgramStatus == Program.StatusPreparing)
                return;

            DataGridView dg = (DataGridView)sender;
            if (dg.CurrentCell == null) return;

            int i, j;
            for (i = 0; i < dg.RowCount; ++i)
                for (j = 0; j < dg.ColumnCount; ++j)
                    dg.Rows[i].Cells[j].Style.BackColor = i == dg.CurrentCell.RowIndex ? Color.Cyan : Color.FromKnownColor(KnownColor.Window);

            Program.UpdateSimulationListingRow(dg.CurrentCell.RowIndex, Program.GetCurrentSimulation());
            Program.CopyCurrentSimulationToParameters();
        }

        private void dataGridView_SimulationListing_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.ProgramStatus == Program.StatusRunning)
            {                
                DataGridView dg = (DataGridView)sender;
                Simulation sm = Program.GetCurrentSimulation();
                sm.SimulationInfo.WasChanged = true;
                Program.UpdateCurrentSimulatoionFromGrid(dg.CurrentCell.RowIndex);
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Program.SaveSimulationToSaved();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.ExistsUnsavedSimulation())
            {
                DialogResult dr = MessageBox.Show("You have unsaved simulations.\nDo you want to exit and lost the changes?", "Unsaved", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                    e.Cancel = true;

                if (e.Cancel == false && Program.SimulationList_Saved.Count == 0)
                {
                    MessageBox.Show("You have no saved simulations.\nPlease save at least one of them and then exiting will be possible.", "Error");
                    e.Cancel = true;
                }
            }
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            Simulation sm = new Simulation(Program.GetCurrentSimulation());
            while (Program.ExistSimulationWithSuchName(Program.SimulationList_Current, sm))
                sm.SimulationInfo.Name = "_" + sm.SimulationInfo.Name;
            sm.SimulationInfo.WasChanged = true;
            Program.AddSimulationToList(Program.SimulationList_Current, sm);
            dataGridView_SimulationListing.Rows.Add(1);

            Program.ProgramStatus = Program.StatusUpdateSimulationListingRow;
            dataGridView_SimulationListing.Rows[dataGridView_SimulationListing.RowCount-1].Cells["ID"].Value = sm.SimulationInfo.ID;
            Program.ProgramStatus = Program.StatusRunning;

            Program.UpdateSimulationListingRow(dataGridView_SimulationListing.RowCount - 1, sm);
            
            dataGridView_SimulationListing.CurrentCell = dataGridView_SimulationListing.Rows[dataGridView_SimulationListing.RowCount - 1].Cells["SimulationName"];            
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (Program.SimulationList_Current.Count == 1)
            {
                MessageBox.Show("It is restricted to remove all simulations from Current List", "Error");
                return;
            }
            Program.RemoveSimulationFromList(Program.SimulationList_Saved, Program.GetCurrentSimulation());
            Program.RemoveSimulationFromList(Program.SimulationList_Current, Program.GetCurrentSimulation());
            dataGridView_SimulationListing.Rows.Remove(dataGridView_SimulationListing.Rows[dataGridView_SimulationListing.CurrentCell.RowIndex]);
        }

        public void dataGrid_Inputs_Editing_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            else if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
                e.KeyChar = '\0';
        }

        private void dataGrid_Inputs_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {            
            e.Control.TextChanged -= dataGrid_Inputs_TextChanged;
            e.Control.TextChanged += dataGrid_Inputs_TextChanged;
            e.Control.KeyPress -= dataGrid_Inputs_Editing_KeyPress;
            e.Control.KeyPress += dataGrid_Inputs_Editing_KeyPress;
        }

        private void dataGrid_Inputs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*
            DataGridView dg = (DataGridView)sender;

            
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                return;

            try
            {
                Convert.ToDouble(dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font(dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font, FontStyle.Regular);
                dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
            }
            catch (System.FormatException)
            {
                dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font("Times", 10, FontStyle.Bold);
                dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
            }
            catch (InvalidCastException)
            {
                return;
            }
            */
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Program.Form_AddParams.Show();
            Program.Form_AddParams.Activate();
        }

        private void radioButton_F_Big_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.Processors.DisplayCurves();
        }

        private void radioButton_f_small_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.Processors.DisplayCurves();
        }

        private void radioButton_Ff_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.Processors.DisplayCurves();
        }


        private void Form1_Activated(object sender, EventArgs e)
        {            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.Processors.DisplayCurves();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.Processors.DisplayCurves();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.Processors.DisplayCurves();
        }

        /*
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            
            Parameters.ParameterUnitsStruct.Q = new UnitStruct("m3/h", 1.0 / 3600);
            Parameters.ParameterUnitsStruct.Qm = new UnitStruct("t/h", 1000.0 / 3600);
            Fill_DataGridView_Row(dataGrid_Inputs.Rows[Program.InputParametersIndexes.Q], "Q", Parameters.ParameterUnitsStruct.Q);
            Fill_DataGridView_Row(dataGrid_Inputs.Rows[Program.InputParametersIndexes.Qm], "Qm", Parameters.ParameterUnitsStruct.Qm);
            Parameters.Processors.WriteAllData();
            Parameters.Processors.ProcessData(); 
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            Parameters.ParameterUnitsStruct.Q = new UnitStruct("l/h", 1e-3 / 3600);
            Parameters.ParameterUnitsStruct.Qm = new UnitStruct("kg/h", 1.0 / 3600);
            Fill_DataGridView_Row(dataGrid_Inputs.Rows[Program.InputParametersIndexes.Q], "Q", Parameters.ParameterUnitsStruct.Q);
            Fill_DataGridView_Row(dataGrid_Inputs.Rows[Program.InputParametersIndexes.Qm], "Qm", Parameters.ParameterUnitsStruct.Qm);
            Parameters.Processors.WriteAllData();
            Parameters.Processors.ProcessData();
        }

        */
        private void button2_Click_1(object sender, EventArgs e)
        {
            Program.Form_Comments.Show();
            Program.Form_Comments.Activate();
        }

        private void button_units_Click(object sender, EventArgs e)
        {
            Program.Form_Units.Show();
            Program.Form_Units.Activate();
        }

        private void dataGrid_Inputs2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged -= dataGrid_Inputs2_TextChanged;
            e.Control.TextChanged += dataGrid_Inputs2_TextChanged;
            e.Control.KeyPress -= dataGrid_Inputs_Editing_KeyPress;
            e.Control.KeyPress += dataGrid_Inputs_Editing_KeyPress;
        }

        private void radioButton_Calculated_n_Dp_Q_CheckChenged()
        {
            Parameters.ParameterInputInfoStruct.Is_n_Checked = radioButton_Calculated_n.Checked;
            Parameters.ParameterInputInfoStruct.Is_Dp_Checked = radioButton_Calculated_Dp.Checked;
            Parameters.ParameterInputInfoStruct.Is_Q_Checked = radioButton_Calculated_Q.Checked;

            if (Parameters.ParameterInputInfoStruct.Is_n_Checked)
            {
                Parameters.ParameterInputInfoStruct.Is_n_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Dp_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Q_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Qm_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Qs_Inputed = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.n].Cells[2].ReadOnly = true;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Dp].Cells[2].ReadOnly = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Q].Cells[2].ReadOnly = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qm].Cells[2].ReadOnly = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qs].Cells[2].ReadOnly = false;
            }

            if (Parameters.ParameterInputInfoStruct.Is_Dp_Checked)
            {
                Parameters.ParameterInputInfoStruct.Is_n_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Dp_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Q_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Qm_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Qs_Inputed = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.n].Cells[2].ReadOnly = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Dp].Cells[2].ReadOnly = true;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Q].Cells[2].ReadOnly = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qm].Cells[2].ReadOnly = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qs].Cells[2].ReadOnly = false;
            }

            if (Parameters.ParameterInputInfoStruct.Is_Q_Checked)
            {
                Parameters.ParameterInputInfoStruct.Is_n_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Dp_Inputed = true;
                Parameters.ParameterInputInfoStruct.Is_Q_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Qm_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Qs_Inputed = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.n].Cells[2].ReadOnly = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Dp].Cells[2].ReadOnly = false;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Q].Cells[2].ReadOnly = true;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qm].Cells[2].ReadOnly = true;
                dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qs].Cells[2].ReadOnly = true;
            }

            Parameters.Processors.WriteAllData();

            if (Program.ProgramStatus == Program.StatusRunning)
            {
                Simulation sm = Program.GetCurrentSimulation();
                sm.SimulationInfo.WasChanged = true;
                Program.CopyParametersToCurrentSimulation();
                //Program.UpdateCurrentSimulationListingRow();
                Parameters.Processors.ProcessData();
            }
        }
        
        private void radioButton_Calculated_n_CheckedChanged(object sender, EventArgs e)
        {
            if (/*Program.ProgramStatus == Program.StatusRunning &&*/
                ((RadioButton)sender).Checked)
                radioButton_Calculated_n_Dp_Q_CheckChenged();
        }

        private void radioButton_Calculated_Dp_CheckedChanged(object sender, EventArgs e)
        {
            if (/*Program.ProgramStatus == Program.StatusRunning &&*/
                ((RadioButton)sender).Checked)
                radioButton_Calculated_n_Dp_Q_CheckChenged();
        }

        private void radioButton_Calculated_Q_CheckedChanged(object sender, EventArgs e)
        {
            if (/*Program.ProgramStatus == Program.StatusRunning &&*/
                ((RadioButton)sender).Checked)
                radioButton_Calculated_n_Dp_Q_CheckChenged();
        }

        private void comboBox_AxisType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parameters.Processors.DisplayCurves();
        }

        private void comboBox_AxisType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parameters.Processors.DisplayCurves();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.Form_ProtocolProperties.Show();
            Program.Form_ProtocolProperties.Activate();
        }

        private void button_TablesAndGraphsRun_Click(object sender, EventArgs e)
        {
            //Program.CopyParametersToCurrentSimulation();
            
            FormTablesAndCharts Form_TablesAndCharts = new FormTablesAndCharts();
            Form_TablesAndCharts.ShowDialog();
            
            Program.CopyCurrentSimulationToParameters();
        }
    }
}