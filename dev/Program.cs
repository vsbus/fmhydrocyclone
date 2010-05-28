using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hydrocyclone1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Form_Main = new Form1();
            Form_AddParams = new Form2();
            Form_Comments = new FormComments();
            Form_Units = new FormUnits();
            Form_ProtocolProperties = new FormProtocolProperties();

            Form_AddParams.dataGridView1.RowCount = 3;
            Form_AddParams.dataGridView1.RowHeadersWidth = 80;
            Form_AddParams.dataGridView1.Rows[0].HeaderCell.Value = "Alpha";
            Form_AddParams.dataGridView1.Rows[1].HeaderCell.Value = "Beta";
            Form_AddParams.dataGridView1.Rows[2].HeaderCell.Value = "Gamma";

            Form_AddParams.dataGridView_Machine_Coefficients.RowCount = 1;

            CList_For_TablesAndCharts = new List<Pair<ValueClass, int>>();
            SimulationList_Saved = new List<Simulation>();
            LoadSimulationsFromFile(SimulationList_Saved, "simuls.dat");
            SimulationList_Current = new List<Simulation>();
            ProgramStatus = StatusPreparing;

            foreach (Simulation sm in SimulationList_Saved)
                SimulationList_Current.Add(new Simulation(sm));

            Application.Run(Form_Main);
        }

        static public Form1 Form_Main;
        static public Form2 Form_AddParams;
        static public FormComments Form_Comments;
        static public FormUnits Form_Units;
        static public FormProtocolProperties Form_ProtocolProperties;

        public static List< Pair<ValueClass, int> > CList_For_TablesAndCharts;
        static public List<Simulation> SimulationList_Saved, SimulationList_Current;
        static public String ProgramStatus;
        public const String StatusPreparing = "StatusPreparing";
        public const String StatusRunning = "StatusRunning";
        public const String StatusUpdateSimulationListingRow = "StatusUpdateSimulationListingRow";

        static public class InputParametersIndexes
        {
            static public int mu=0;
            static public int rho_f=2, rho_s=3, rho_sus=4;
            static public int Cm=6, Cv=7, C=8;
            static public int x_g = 10, sigma_g = 11;
            static public int sigma_s = 13;
            static public int rf = 15, Du_over_D = 16;            
            static public int x_red_50 = 18, D = 19;

            static public int n = 0, Dp = 1;
            static public int Q = 3, Qm = 4, Qs = 5;

            public static int L_over_D = 0, l_over_D = 1, Di_over_D = 2, Do_over_D = 3;
            public static int L = 0, l = 1, Di = 2, Do = 3;
        }

        static public class ResultParametersIndexes
        {
            static public int Stk_red = 0, Eu = 1, Re = 2;
            static public int E_red_t = 4, Et = 5;
            static public int x_o_50 = 7, x_u_50 = 8;
            static public int Cmou = 11, Cvou = 12, Cou = 13;
        }

        static public class Colors
        {
            static public System.Drawing.Color InputColor = System.Drawing.Color.Blue;
            static public System.Drawing.Color CalculatedColor = System.Drawing.Color.Black;
        }

// Work with simulation list (begin)
        static public int GetCurrentSimulationIndex()
        {
            int i;
            for (i = 0; i < SimulationList_Current.Count; ++i)
                if (SimulationList_Current[i].SimulationInfo.ID ==
                    Convert.ToInt32(Form_Main.dataGridView_SimulationListing.Rows[Form_Main.dataGridView_SimulationListing.CurrentCell.RowIndex].Cells["ID"].Value))
                    return i;
            return -1;
        }
        static public Simulation GetCurrentSimulation()
        {
            return SimulationList_Current[GetCurrentSimulationIndex()];
        }
        static public void SaveSimulationsToFile(List<Simulation> list, String fname)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fname))
            {
                sw.WriteLine("|list|");
                sw.WriteLine(list.Count);
                
                for (int i = 0; i < list.Count; ++i)
                {
                    sw.WriteLine("SimulationName");
                    sw.WriteLine(list[i].SimulationInfo.Name);

                    sw.WriteLine("ID");
                    sw.WriteLine(list[i].SimulationInfo.ID);
    
                    sw.WriteLine("Material");
                    sw.WriteLine(list[i].SimulationInfo.Material);

                    sw.WriteLine("Custumer");
                    sw.WriteLine(list[i].SimulationInfo.Custumer);

                    sw.WriteLine("Charge");
                    sw.WriteLine(list[i].SimulationInfo.Charge);

                    sw.WriteLine("Comments");
                    sw.WriteLine(list[i].SimulationInfo.Comments.Replace('\n',Convert.ToChar(254)).Replace('\r',Convert.ToChar(253)));

        //  InputsInfo
                    sw.WriteLine("Is_rho_s_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_rho_s_Inputed);

                    sw.WriteLine("Is_rho_sus_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_rho_sus_Inputed);

                    sw.WriteLine("Is_C_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_C_Inputed);

                    sw.WriteLine("Is_Cm_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_Cm_Inputed);

                    sw.WriteLine("Is_Cv_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_Cv_Inputed);

                    sw.WriteLine("Is_Q_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_Q_Inputed);

                    sw.WriteLine("Is_Qm_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_Qm_Inputed);

                    sw.WriteLine("Is_Qs_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_Qs_Inputed);

                    sw.WriteLine("Is_rf_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_rf_Inputed);

                    sw.WriteLine("Is_Du_over_D_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_Du_over_D_Inputed);

                    sw.WriteLine("Is_n_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_n_Inputed);

                    sw.WriteLine("Is_Dp_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_Dp_Inputed);

                    sw.WriteLine("Is_x_red_50_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_x_red_50_Inputed);

                    sw.WriteLine("Is_D_Inputed");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_D_Inputed);

        //  Checked Info
                    sw.WriteLine("Is_n_Checked");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_n_Checked);

                    sw.WriteLine("Is_Dp_Checked");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_Dp_Checked);
                    
                    sw.WriteLine("Is_Q_Checked");
                    sw.WriteLine(list[i].ParameterInputInfo.Is_Q_Checked);

        //  ParameterValues
                    sw.WriteLine("mu");
                    list[i].ParameterValues.mu.WriteToStream(sw);

                    sw.WriteLine("rho_f");
                    list[i].ParameterValues.rho_f.WriteToStream(sw);

                    sw.WriteLine("rho_s");
                    list[i].ParameterValues.rho_s.WriteToStream(sw);

                    sw.WriteLine("rho_sus");
                    list[i].ParameterValues.rho_sus.WriteToStream(sw);

                    sw.WriteLine("C");
                    list[i].ParameterValues.C.WriteToStream(sw);

                    sw.WriteLine("Cm");
                    list[i].ParameterValues.Cm.WriteToStream(sw);

                    sw.WriteLine("Cv");
                    list[i].ParameterValues.Cv.WriteToStream(sw);

                    sw.WriteLine("Q");
                    list[i].ParameterValues.Q.WriteToStream(sw);

                    sw.WriteLine("Qm");
                    list[i].ParameterValues.Qm.WriteToStream(sw);

                    sw.WriteLine("Qs");
                    list[i].ParameterValues.Qs.WriteToStream(sw);

                    sw.WriteLine("rf");
                    list[i].ParameterValues.rf.WriteToStream(sw);

                    sw.WriteLine("Du_over_D");
                    list[i].ParameterValues.Du_over_D.WriteToStream(sw);

                    sw.WriteLine("n");
                    list[i].ParameterValues.n.WriteToStream(sw);

                    sw.WriteLine("Dp");
                    list[i].ParameterValues.Dp.WriteToStream(sw);

                    sw.WriteLine("x_red_50");
                    list[i].ParameterValues.x_red_50.WriteToStream(sw);

                    sw.WriteLine("D");
                    list[i].ParameterValues.D.WriteToStream(sw);

                    sw.WriteLine("x_g");
                    list[i].ParameterValues.x_g.WriteToStream(sw);

                    sw.WriteLine("sigma_g");
                    list[i].ParameterValues.sigma_g.WriteToStream(sw);

                    sw.WriteLine("sigma_s");
                    list[i].ParameterValues.sigma_s.WriteToStream(sw);

                    sw.WriteLine("alpha1");
                    list[i].ParameterValues.alpha1.WriteToStream(sw);

                    sw.WriteLine("alpha2");
                    list[i].ParameterValues.alpha2.WriteToStream(sw);

                    sw.WriteLine("alpha3");
                    list[i].ParameterValues.alpha3.WriteToStream(sw);

                    sw.WriteLine("beta1");
                    list[i].ParameterValues.beta1.WriteToStream(sw);

                    sw.WriteLine("beta2");
                    list[i].ParameterValues.beta2.WriteToStream(sw);

                    sw.WriteLine("beta3");
                    list[i].ParameterValues.beta3.WriteToStream(sw);

                    sw.WriteLine("gamma1");
                    list[i].ParameterValues.gamma1.WriteToStream(sw);

                    sw.WriteLine("gamma2");
                    list[i].ParameterValues.gamma2.WriteToStream(sw);

                    sw.WriteLine("gamma3");
                    list[i].ParameterValues.gamma3.WriteToStream(sw);

                    sw.WriteLine("L_over_D");
                    list[i].ParameterValues.L_over_D.WriteToStream(sw);

                    sw.WriteLine("l_over_D");
                    list[i].ParameterValues.l_over_D.WriteToStream(sw);

                    sw.WriteLine("Di_over_D");
                    list[i].ParameterValues.Di_over_D.WriteToStream(sw);

                    sw.WriteLine("Do_over_D");
                    list[i].ParameterValues.Do_over_D.WriteToStream(sw);
                }
            }
        }
        static public void UpdateCurrentSimulationListingRow()
        {
            UpdateSimulationListingRow(Form_Main.dataGridView_SimulationListing.CurrentCell.RowIndex, GetCurrentSimulation());
        }
        static public void UpdateSimulationListingRow(int row, Simulation sm)
        {
            if (ProgramStatus == StatusPreparing)
                return;

            String old_prg_status = ProgramStatus;
            ProgramStatus = StatusUpdateSimulationListingRow;

            DataGridViewRow drow = Form_Main.dataGridView_SimulationListing.Rows[row];
            drow.Cells["ID"].Value = sm.SimulationInfo.ID;
            drow.Cells["Comments"].Value = sm.SimulationInfo.Comments;
            Form_Comments.textBox_Comments.Text = sm.SimulationInfo.Comments;
            drow.Cells["Custumer"].Value = sm.SimulationInfo.Custumer;
            drow.Cells["Charge"].Value = sm.SimulationInfo.Charge;
            drow.Cells["Material"].Value = sm.SimulationInfo.Material;
            drow.Cells["SimulationName"].Value = sm.SimulationInfo.Name;
            drow.Cells["Changed"].Value = sm.SimulationInfo.WasChanged ? "*" : "";

            Form_Main.radioButton_Calculated_n.Checked = sm.ParameterInputInfo.Is_n_Checked;
            Form_Main.radioButton_Calculated_Dp.Checked = sm.ParameterInputInfo.Is_Dp_Checked;
            Form_Main.radioButton_Calculated_Q.Checked = sm.ParameterInputInfo.Is_Q_Checked;

            ProgramStatus = old_prg_status;            
        }
        static public void CopyCurrentSimulationToParameters()
        {
            Simulation sm = GetCurrentSimulation();

            // Copying  ParameterInputInfo
            Parameters.ParameterInputInfoStruct.Is_rho_s_Inputed = sm.ParameterInputInfo.Is_rho_s_Inputed;
            Parameters.ParameterInputInfoStruct.Is_rho_sus_Inputed = sm.ParameterInputInfo.Is_rho_sus_Inputed;

            Parameters.ParameterInputInfoStruct.Is_C_Inputed = sm.ParameterInputInfo.Is_C_Inputed;
            Parameters.ParameterInputInfoStruct.Is_Cm_Inputed = sm.ParameterInputInfo.Is_Cm_Inputed;
            Parameters.ParameterInputInfoStruct.Is_Cv_Inputed = sm.ParameterInputInfo.Is_Cv_Inputed;

            Parameters.ParameterInputInfoStruct.Is_Q_Inputed = sm.ParameterInputInfo.Is_Q_Inputed;
            Parameters.ParameterInputInfoStruct.Is_Qm_Inputed = sm.ParameterInputInfo.Is_Qm_Inputed;
            Parameters.ParameterInputInfoStruct.Is_Qs_Inputed = sm.ParameterInputInfo.Is_Qs_Inputed;

            Parameters.ParameterInputInfoStruct.Is_rf_Inputed = sm.ParameterInputInfo.Is_rf_Inputed;
            Parameters.ParameterInputInfoStruct.Is_Du_over_D_Inputed = sm.ParameterInputInfo.Is_Du_over_D_Inputed;

            Parameters.ParameterInputInfoStruct.Is_n_Inputed = sm.ParameterInputInfo.Is_n_Inputed;
            Parameters.ParameterInputInfoStruct.Is_Dp_Inputed = sm.ParameterInputInfo.Is_Dp_Inputed;

            Parameters.ParameterInputInfoStruct.Is_x_red_50_Inputed = sm.ParameterInputInfo.Is_x_red_50_Inputed;
            Parameters.ParameterInputInfoStruct.Is_D_Inputed = sm.ParameterInputInfo.Is_D_Inputed;

            Parameters.ParameterInputInfoStruct.Is_n_Checked = sm.ParameterInputInfo.Is_n_Checked;
            Parameters.ParameterInputInfoStruct.Is_Dp_Checked = sm.ParameterInputInfo.Is_Dp_Checked;
            Parameters.ParameterInputInfoStruct.Is_Q_Checked = sm.ParameterInputInfo.Is_Q_Checked;

            // Copying ParameterValues
            Parameters.ParameterValuesStruct.mu = sm.ParameterValues.mu;

            Parameters.ParameterValuesStruct.rho_f = sm.ParameterValues.rho_f;
            Parameters.ParameterValuesStruct.rho_s = sm.ParameterValues.rho_s;
            Parameters.ParameterValuesStruct.rho_sus = sm.ParameterValues.rho_sus;

            Parameters.ParameterValuesStruct.C = sm.ParameterValues.C;
            Parameters.ParameterValuesStruct.Cm = sm.ParameterValues.Cm;
            Parameters.ParameterValuesStruct.Cv = sm.ParameterValues.Cv;

            Parameters.ParameterValuesStruct.x_g = sm.ParameterValues.x_g;
            Parameters.ParameterValuesStruct.sigma_g = sm.ParameterValues.sigma_g;

            Parameters.ParameterValuesStruct.sigma_s = sm.ParameterValues.sigma_s;

            Parameters.ParameterValuesStruct.Q = sm.ParameterValues.Q;
            Parameters.ParameterValuesStruct.Qm = sm.ParameterValues.Qm;
            Parameters.ParameterValuesStruct.Qs = sm.ParameterValues.Qs;

            Parameters.ParameterValuesStruct.rf = sm.ParameterValues.rf;
            Parameters.ParameterValuesStruct.Du_over_D = sm.ParameterValues.Du_over_D;

            Parameters.ParameterValuesStruct.n = sm.ParameterValues.n;
            Parameters.ParameterValuesStruct.Dp = sm.ParameterValues.Dp;

            Parameters.ParameterValuesStruct.x_red_50 = sm.ParameterValues.x_red_50;
            Parameters.ParameterValuesStruct.D = sm.ParameterValues.D;

            Parameters.ParameterValuesStruct.alpha1 = sm.ParameterValues.alpha1;
            Parameters.ParameterValuesStruct.alpha2 = sm.ParameterValues.alpha2;
            Parameters.ParameterValuesStruct.alpha3 = sm.ParameterValues.alpha3;

            Parameters.ParameterValuesStruct.beta1 = sm.ParameterValues.beta1;
            Parameters.ParameterValuesStruct.beta2 = sm.ParameterValues.beta2;
            Parameters.ParameterValuesStruct.beta3 = sm.ParameterValues.beta3;

            Parameters.ParameterValuesStruct.gamma1 = sm.ParameterValues.gamma1;
            Parameters.ParameterValuesStruct.gamma2 = sm.ParameterValues.gamma2;
            Parameters.ParameterValuesStruct.gamma3 = sm.ParameterValues.gamma3;

            Parameters.ParameterValuesStruct.L_over_D = sm.ParameterValues.L_over_D;
            Parameters.ParameterValuesStruct.l_over_D = sm.ParameterValues.l_over_D;
            Parameters.ParameterValuesStruct.Di_over_D = sm.ParameterValues.Di_over_D;
            Parameters.ParameterValuesStruct.Do_over_D = sm.ParameterValues.Do_over_D;
            
            Parameters.Processors.WriteAllData();
            Parameters.Processors.ProcessData();
        }
        static public void CopyParametersToCurrentSimulation()
        {
            Simulation sm = GetCurrentSimulation();

            // Copying  ParameterInputInfo
            sm.ParameterInputInfo.Is_rho_s_Inputed = Parameters.ParameterInputInfoStruct.Is_rho_s_Inputed;
            sm.ParameterInputInfo.Is_rho_sus_Inputed = Parameters.ParameterInputInfoStruct.Is_rho_sus_Inputed;

            sm.ParameterInputInfo.Is_C_Inputed = Parameters.ParameterInputInfoStruct.Is_C_Inputed;
            sm.ParameterInputInfo.Is_Cm_Inputed = Parameters.ParameterInputInfoStruct.Is_Cm_Inputed;
            sm.ParameterInputInfo.Is_Cv_Inputed = Parameters.ParameterInputInfoStruct.Is_Cv_Inputed;

            sm.ParameterInputInfo.Is_Q_Inputed = Parameters.ParameterInputInfoStruct.Is_Q_Inputed;
            sm.ParameterInputInfo.Is_Qm_Inputed = Parameters.ParameterInputInfoStruct.Is_Qm_Inputed;
            sm.ParameterInputInfo.Is_Qs_Inputed = Parameters.ParameterInputInfoStruct.Is_Qs_Inputed;

            sm.ParameterInputInfo.Is_rf_Inputed = Parameters.ParameterInputInfoStruct.Is_rf_Inputed;
            sm.ParameterInputInfo.Is_Du_over_D_Inputed = Parameters.ParameterInputInfoStruct.Is_Du_over_D_Inputed;

            sm.ParameterInputInfo.Is_n_Inputed = Parameters.ParameterInputInfoStruct.Is_n_Inputed;
            sm.ParameterInputInfo.Is_Dp_Inputed = Parameters.ParameterInputInfoStruct.Is_Dp_Inputed;

            sm.ParameterInputInfo.Is_x_red_50_Inputed = Parameters.ParameterInputInfoStruct.Is_x_red_50_Inputed;
            sm.ParameterInputInfo.Is_D_Inputed = Parameters.ParameterInputInfoStruct.Is_D_Inputed;

            sm.ParameterInputInfo.Is_n_Checked = Parameters.ParameterInputInfoStruct.Is_n_Checked;
            sm.ParameterInputInfo.Is_Dp_Checked = Parameters.ParameterInputInfoStruct.Is_Dp_Checked;
            sm.ParameterInputInfo.Is_Q_Checked = Parameters.ParameterInputInfoStruct.Is_Q_Checked;

            // Copying ParameterValues
            sm.ParameterValues.mu = Parameters.ParameterValuesStruct.mu;

            sm.ParameterValues.rho_f = Parameters.ParameterValuesStruct.rho_f;
            sm.ParameterValues.rho_s = Parameters.ParameterValuesStruct.rho_s;
            sm.ParameterValues.rho_sus = Parameters.ParameterValuesStruct.rho_sus;

            sm.ParameterValues.C = Parameters.ParameterValuesStruct.C;
            sm.ParameterValues.Cm = Parameters.ParameterValuesStruct.Cm;
            sm.ParameterValues.Cv = Parameters.ParameterValuesStruct.Cv;

            sm.ParameterValues.x_g = Parameters.ParameterValuesStruct.x_g;
            sm.ParameterValues.sigma_g = Parameters.ParameterValuesStruct.sigma_g;

            sm.ParameterValues.sigma_s = Parameters.ParameterValuesStruct.sigma_s;

            sm.ParameterValues.Q = Parameters.ParameterValuesStruct.Q;
            sm.ParameterValues.Qm = Parameters.ParameterValuesStruct.Qm;
            sm.ParameterValues.Qs = Parameters.ParameterValuesStruct.Qs;
            
            sm.ParameterValues.rf = Parameters.ParameterValuesStruct.rf;
            sm.ParameterValues.Du_over_D = Parameters.ParameterValuesStruct.Du_over_D;

            sm.ParameterValues.n = Parameters.ParameterValuesStruct.n;
            sm.ParameterValues.Dp = Parameters.ParameterValuesStruct.Dp;

            sm.ParameterValues.x_red_50 = Parameters.ParameterValuesStruct.x_red_50;
            sm.ParameterValues.D = Parameters.ParameterValuesStruct.D;

            sm.ParameterValues.alpha1 = Parameters.ParameterValuesStruct.alpha1;
            sm.ParameterValues.alpha2 = Parameters.ParameterValuesStruct.alpha2;
            sm.ParameterValues.alpha3 = Parameters.ParameterValuesStruct.alpha3;

            sm.ParameterValues.beta1 = Parameters.ParameterValuesStruct.beta1;
            sm.ParameterValues.beta2 = Parameters.ParameterValuesStruct.beta2;
            sm.ParameterValues.beta3 = Parameters.ParameterValuesStruct.beta3;

            sm.ParameterValues.gamma1 = Parameters.ParameterValuesStruct.gamma1;
            sm.ParameterValues.gamma2 = Parameters.ParameterValuesStruct.gamma2;
            sm.ParameterValues.gamma3 = Parameters.ParameterValuesStruct.gamma3;

            sm.ParameterValues.L_over_D = Parameters.ParameterValuesStruct.L_over_D;
            sm.ParameterValues.l_over_D = Parameters.ParameterValuesStruct.l_over_D;
            sm.ParameterValues.Di_over_D = Parameters.ParameterValuesStruct.Di_over_D;
            sm.ParameterValues.Do_over_D = Parameters.ParameterValuesStruct.Do_over_D;
            
            sm.SimulationInfo.WasChanged = true;
            UpdateCurrentSimulationListingRow();
        }
        static public void UpdateCurrentSimulatoionFromGrid(int row)
        {
            
            DataGridView dg = Form_Main.dataGridView_SimulationListing;
            Simulation cur_sm = GetCurrentSimulation();
            Simulation sm = new Simulation(cur_sm);

            sm.SimulationInfo.ID = Convert.ToInt32(dg.Rows[row].Cells["ID"].Value);
            sm.SimulationInfo.Custumer = dg.Rows[row].Cells["Custumer"].Value.ToString();
            sm.SimulationInfo.Charge = dg.Rows[row].Cells["Charge"].Value.ToString();
            sm.SimulationInfo.Material = dg.Rows[row].Cells["Material"].Value.ToString();
            sm.SimulationInfo.Name = dg.Rows[row].Cells["SimulationName"].Value.ToString();
            //sm.SimulationInfo.Comments = dg.Rows[row].Cells["Comments"].Value.ToString();
            sm.SimulationInfo.Comments = Form_Comments.textBox_Comments.Text;
            
            if (dg.Columns[dg.CurrentCell.ColumnIndex].Name == "SimulationName" && ExistSimulationWithSuchName(SimulationList_Current, sm))
            {
                while (ExistSimulationWithSuchName(SimulationList_Current, sm)) 
                    sm.SimulationInfo.Name = "_" + sm.SimulationInfo.Name;
                MessageBox.Show("Entered name already exists but using of same names if restricted, so it was changed to \"" + sm.SimulationInfo.Name + "\"");
            }

            cur_sm = SimulationList_Current[GetCurrentSimulationIndex()] = new Simulation(sm);
            UpdateSimulationListingRow(row, cur_sm);
        }
        static public void LoadSimulationFromSaved()
        {
            DataGridView dg = Form_Main.dataGridView_SimulationListing;
            int id = Convert.ToInt32(dg.Rows[dg.CurrentCell.RowIndex].Cells["ID"].Value);
            
            int i1, i2;
            for (i1 = 0; SimulationList_Current[i1].SimulationInfo.ID != id; i1++);
            for (i2 = 0; i2 < SimulationList_Saved.Count && SimulationList_Saved[i2].SimulationInfo.ID != id; i2++) ;

            if (i2 >= SimulationList_Saved.Count)
            {
                MessageBox.Show("Sorry, but this simulation wasn't in Saved simulations.", "Load failed");
                return;
            }

            SimulationList_Current[i1] = new Simulation(SimulationList_Saved[i2]);

            UpdateSimulationListingRow(dg.CurrentCell.RowIndex, SimulationList_Current[i1]);
            CopyCurrentSimulationToParameters();
        }
        static public void SaveSimulationToSaved()
        {
            DataGridView dg = Form_Main.dataGridView_SimulationListing;
            int id = Convert.ToInt32(dg.Rows[dg.CurrentCell.RowIndex].Cells["ID"].Value);

            int i1, i2;
            for (i1 = 0; SimulationList_Current[i1].SimulationInfo.ID != id; i1++) ;
            for (i2 = 0; i2 < SimulationList_Saved.Count && SimulationList_Saved[i2].SimulationInfo.ID != id; i2++) ;

            SimulationList_Current[i1].SimulationInfo.WasChanged = false;

            if (i2 >= SimulationList_Saved.Count)
                SimulationList_Saved.Add(new Simulation(SimulationList_Current[i1]));
            else
                SimulationList_Saved[i2] = new Simulation(SimulationList_Current[i1]);
            
            UpdateSimulationListingRow(dg.CurrentCell.RowIndex, SimulationList_Current[i1]);
        }
        static public void LoadSimulationsFromFile(List<Simulation> list, String fname)
        {
            if (list == null)
                list = new List<Simulation>();
            else
                list.Clear();

            using (System.IO.StreamReader sr = new System.IO.StreamReader(fname))
            {
                //sr.WriteLine("|list|");                
                sr.ReadLine(); // |list|
                int lcount = Convert.ToInt32(sr.ReadLine());

                for (int i = 0; i < lcount; ++i)
                {
                    Simulation sm = new Simulation();
                    sr.ReadLine();
                    sm.SimulationInfo.Name = sr.ReadLine();
                    
                    sr.ReadLine();
                    sm.SimulationInfo.ID = Convert.ToInt32(sr.ReadLine());

                    sr.ReadLine();
                    sm.SimulationInfo.Material = sr.ReadLine();

                    sr.ReadLine();
                    sm.SimulationInfo.Custumer = sr.ReadLine();

                    sr.ReadLine();
                    sm.SimulationInfo.Charge = sr.ReadLine();

                    sr.ReadLine();
                    sm.SimulationInfo.Comments = sr.ReadLine().Replace(Convert.ToChar(254), '\n').Replace(Convert.ToChar(253), '\r');

        //  InputsInfo
                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_rho_s_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_rho_sus_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_C_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_Cm_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_Cv_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_Q_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_Qm_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_Qs_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_rf_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_Du_over_D_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_n_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_Dp_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_x_red_50_Inputed = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_D_Inputed = Convert.ToBoolean(sr.ReadLine());

        //  Checked Info
                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_n_Checked = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_Dp_Checked = Convert.ToBoolean(sr.ReadLine());

                    sr.ReadLine();
                    sm.ParameterInputInfo.Is_Q_Checked = Convert.ToBoolean(sr.ReadLine());


        //  ParameterValues
                    sr.ReadLine();
                    sm.ParameterValues.mu.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.rho_f.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.rho_s.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.rho_sus.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.C.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.Cm.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.Cv.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.Q.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.Qm.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.Qs.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.rf.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.Du_over_D.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.n.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.Dp.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.x_red_50.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.D.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.x_g.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.sigma_g.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.sigma_s.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.alpha1.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.alpha2.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.alpha3.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.beta1.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.beta2.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.beta3.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.gamma1.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.gamma2.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.gamma3.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.L_over_D.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.l_over_D.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.Di_over_D.ReadFromStream(sr);

                    sr.ReadLine();
                    sm.ParameterValues.Do_over_D.ReadFromStream(sr);
                    
                    AddSimulationToList(list, sm);
                }
            }
        }
        static public bool ExistsUnsavedSimulation()
        {
            int i;
            for (i = 0; i < SimulationList_Current.Count; ++i)
                if (SimulationList_Current[i].SimulationInfo.WasChanged)
                    return true;
            return false;
        }
        static public bool ExistSimulationWithSuchName(List<Simulation> list, Simulation sm)
        {
            int i;
            for (i = 0; i < list.Count; ++i)
                if (list[i].SimulationInfo.Name == sm.SimulationInfo.Name)
                    return true;
            return false;
        }
        static public void RemoveSimulationFromList(List<Simulation> list, Simulation sm)
        {
            if (list == null) throw new Exception("list is (null)");

            int i;
            for(i=0; i<list.Count;++i)
                if (list[i].SimulationInfo.ID == sm.SimulationInfo.ID)
                {
                    list.Remove(list[i]);
                    break;
                }
        }
        static public void UpdateTextBoxFont(TextBox tb)
        {
            if (!ValueClass.IsValueString(tb.Text))
            {
                tb.Font = new System.Drawing.Font(tb.Font, System.Drawing.FontStyle.Bold);
                tb.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                tb.Font = new System.Drawing.Font(tb.Font, System.Drawing.FontStyle.Regular);
                tb.ForeColor = Colors.InputColor;
            }
        }
        static public void AddSimulationToList(List<Simulation> list, Simulation sm)
        {
            if (list == null) throw new Exception("list is (null)");
            
            //if (ExistSimulationWithSuchName(list, sm))
                //throw new System.Exception("NameExists");
            while (ExistSimulationWithSuchName(list, sm))
                sm.SimulationInfo.Name = "_" + sm.SimulationInfo.Name;

            int i;
            Dictionary<int, bool> usedID = new Dictionary<int, bool>();
            for (i = 0; i < list.Count; ++i)
                usedID[list[i].SimulationInfo.ID] = true;

            for (i = 0; usedID.ContainsKey(i); ++i);
            sm.SimulationInfo.ID = i;
            list.Add(sm);
        }
// Work with simulation list (end)
    }
}