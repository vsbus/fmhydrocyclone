using System;
using System.Windows.Forms;

namespace Hydrocyclone1
{
    public partial class FormUnits : Form
    {
        public FormUnits()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.ParameterUnitsStruct.Q = new UnitStruct("m3/h", 1.0 / 3600);
            Parameters.ParameterUnitsStruct.Qm = new UnitStruct("t/h", 1000.0 / 3600);
            Parameters.ParameterUnitsStruct.Qs = new UnitStruct("t/h", 1000.0 / 3600);
            Program.Form_Main.Fill_DataGridView_Row(Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Q], "Q", Parameters.ParameterUnitsStruct.Q);
            Program.Form_Main.Fill_DataGridView_Row(Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qm], "Qm", Parameters.ParameterUnitsStruct.Qm);
            Program.Form_Main.Fill_DataGridView_Row(Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qs], "Qs", Parameters.ParameterUnitsStruct.Qs);
            Parameters.Processors.WriteAllData();
            Parameters.Processors.ProcessData(); 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.ParameterUnitsStruct.Q = new UnitStruct("l/h", 1e-3 / 3600);
            Parameters.ParameterUnitsStruct.Qm = new UnitStruct("kg/h", 1.0 / 3600);
            Parameters.ParameterUnitsStruct.Qs = new UnitStruct("kg/h", 1.0 / 3600);
            Program.Form_Main.Fill_DataGridView_Row(Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Q], "Q", Parameters.ParameterUnitsStruct.Q);
            Program.Form_Main.Fill_DataGridView_Row(Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qm], "Qm", Parameters.ParameterUnitsStruct.Qm);
            Program.Form_Main.Fill_DataGridView_Row(Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qs], "Qs", Parameters.ParameterUnitsStruct.Qs);
            Parameters.Processors.WriteAllData();
            Parameters.Processors.ProcessData();
        }

        private void FormUnits_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((FormUnits)sender).Hide();
            e.Cancel = true;
        }
    }
}