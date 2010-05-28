using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hydrocyclone1
{
    public partial class FormTablesAndCharts : Form
    {
        static private string[] ParametersOrder = { "n",  "D",     "x'50",     "Q",   "Dp",   "rf",  "Du/D" };
        static private double[] ParametersMinLimit = { 1,  10e-3,    1e-6,  25e-6/9,   100,     0,     0 };
        static private double[] ParametersMaxLimit = { 30, 200e-3,   30e-6, 25e-2/9,  10e5,     1,     1 };
        private static Color[] ColorsSet = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Pink };
        private string FormStatus;
        private int number_of_points;
        private struct Data
        {
            public static List<List<ValueClass>> x_red_50, D, n, Q, Dp, rf, Du_over_D;
            public static List<List<ValueClass>> Et, E_red_t, Cmo, Cvo, Co, Cmu, Cvu, Cu;
        }


        bool StringToIsInputedParameter(string s)
        {
            switch(s)
            {
                case "n":
                    return Parameters.ParameterInputInfoStruct.Is_n_Inputed;
                case "D":
                    return Parameters.ParameterInputInfoStruct.Is_D_Inputed;
                case "x'50":
                    return Parameters.ParameterInputInfoStruct.Is_x_red_50_Inputed;
                case "Q":
                    return Parameters.ParameterInputInfoStruct.Is_Q_Inputed;
                case "Dp":
                    return Parameters.ParameterInputInfoStruct.Is_Dp_Inputed;
                case "rf":
                    return Parameters.ParameterInputInfoStruct.Is_rf_Inputed;
                case "Du/D":
                    return Parameters.ParameterInputInfoStruct.Is_Du_over_D_Inputed;

            }
            return false;
        }

        public FormTablesAndCharts()
        {
            InitializeComponent();
        }

        private void PrepareListBoxXAxis(ListBox lb)
        {
            lb.DrawMode = DrawMode.OwnerDrawVariable;
            lb.DrawItem += DrawItemHandlerXAxis;

            foreach (string s in ParametersOrder)
                lb.Items.Add(s);

            int i;
            for (i = 0; StringToIsInputedParameter(ParametersOrder[i]) == false; ++i) ;
            lb.SelectedIndex = i;
        }

        private void PrepareListBoxYAxis(ListBox lb)
        {
            //lb.DrawMode = DrawMode.OwnerDrawVariable;
            //lb.DrawItem += DrawItemHandlerXAxis;

            lb.Items.Add("<none>");
            foreach (string s in ParametersOrder)
                if (StringToIsInputedParameter(s) == false)
                    lb.Items.Add(s);
        }

        private void DrawItemHandlerXAxis(object sender, DrawItemEventArgs e)
        {
            ListBox lb = sender as ListBox;
            
            e.DrawBackground();
            e.DrawFocusRectangle();
            
            string s = lb.Items[e.Index].ToString();
            bool Is_Inputed = StringToIsInputedParameter(s);

            e.Graphics.DrawString(s,
                                  lb.Font,
                                  Is_Inputed
                                      ? (e.BackColor != Color.FromKnownColor(KnownColor.Window)
                                             ? new SolidBrush(Color.White)
                                             : new SolidBrush(Color.Black))
                                      : new SolidBrush(Color.Gray),
                                  new PointF(e.Bounds.Left, e.Bounds.Top));
        }

        private void FormTablesAndCharts_Load(object sender, EventArgs e)
        {
            FormStatus = "Preparing";

            PrepareListBoxXAxis(listBox_XAxis);

            PrepareListBoxYAxis(listBox_YAxis1);
            listBox_YAxis1.SelectedIndex = 1;
            PrepareListBoxYAxis(listBox_YAxis2);
            listBox_YAxis2.SelectedIndex = 0;

            //dataGridView1.RowCount = 1000;
            //dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            //for (int i = 0; i < dataGridView1.RowCount; ++i)
                //dataGridView1.Rows[i].HeaderCell.Value = i + 1;

            bool cur_C_exists = false;
            foreach (Pair<ValueClass, int> p in Program.CList_For_TablesAndCharts)
            {
                if (p.Second == 0 && p.First.Value == Parameters.ParameterValuesStruct.Cm.Value && Parameters.ParameterInputInfoStruct.Is_Cm_Inputed)
                    cur_C_exists = true;
                else if (p.Second == 1 && p.First.Value == Parameters.ParameterValuesStruct.Cv.Value && Parameters.ParameterInputInfoStruct.Is_Cv_Inputed)
                    cur_C_exists = true;
                else if (p.Second == 2 && p.First.Value == Parameters.ParameterValuesStruct.C.Value && Parameters.ParameterInputInfoStruct.Is_C_Inputed)
                    cur_C_exists = true;
            }

            if (!cur_C_exists)
            {
                int ind = Parameters.ParameterInputInfoStruct.Is_Cm_Inputed
                              ? 0
                              : (Parameters.ParameterInputInfoStruct.Is_Cv_Inputed ? 1 : 2);

                ValueClass val = Parameters.ParameterInputInfoStruct.Is_Cm_Inputed
                                     ? Parameters.ParameterValuesStruct.Cm
                                     :
                                         (Parameters.ParameterInputInfoStruct.Is_Cv_Inputed
                                              ? Parameters.ParameterValuesStruct.Cv
                                              : Parameters.ParameterValuesStruct.C);
                
                Program.CList_For_TablesAndCharts.Add(new Pair<ValueClass, int>(val, ind));
            }

            dataGridViewCmCvC.RowCount = Program.CList_For_TablesAndCharts.Count + 1;

            for (int i = 0; i < Program.CList_For_TablesAndCharts.Count; ++i)
            {
                //dataGridViewCmCvC.Rows[i].Cells[2].Value = ValueClass.ValueToString(Program.CList_For_TablesAndCharts[i].First);

                int j;
                for (j = 0; j < 3; ++j)
                    dataGridViewCmCvC.Rows[i].Cells[0].Style.ForeColor = Program.Colors.CalculatedColor;

                j = Program.CList_For_TablesAndCharts[i].Second;
                dataGridViewCmCvC.Rows[i].Cells[j].Style.ForeColor = Program.Colors.InputColor;
                UnitStruct unit = j == 0
                                      ? Parameters.ParameterUnitsStruct.Cm
                                      : (j == 1 ? Parameters.ParameterUnitsStruct.Cv : Parameters.ParameterUnitsStruct.C);
                dataGridViewCmCvC.Rows[i].Cells[j].Value =
                    ValueClass.ValueToString(Program.CList_For_TablesAndCharts[i].First / unit.Coefficient);

                //dataGridViewCmCvC.Rows[i].Cells[0].Style.ForeColor = Program.Colors.CalculatedColor;
                //dataGridViewCmCvC.Rows[i].Cells[1].Style.ForeColor = Program.Colors.CalculatedColor;

                dataGridViewCmCvC.Rows[i].Cells[3].Value = true;
                dataGridViewCmCvC.Rows[i].Cells[4].Value = "Delete";
            }

            dataGridViewCmCvC.Rows[Program.CList_For_TablesAndCharts.Count].Cells[3].Value = true;
            dataGridViewCmCvC.Rows[Program.CList_For_TablesAndCharts.Count].Cells[4].Value = "Delete";

            comboBox_EtEredt.Text = comboBox_EtEredt.Items[0].ToString();
            comboBox_CmCvC.Text = comboBox_CmCvC.Items[0].ToString();

            textBox1.KeyPress -= Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;
            textBox1.KeyPress += Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;

            comboBox_XAxisType.Text = comboBox_XAxisType.Items[0].ToString();
            comboBox_YAxisType.Text = comboBox_YAxisType.Items[0].ToString();

            dataGridView_Limits.RowCount = 7;
            for (int i = 0; i < dataGridView_Limits.RowCount; ++i)
            {
                dataGridView_Limits.Rows[i].Cells[0].Value = ParametersOrder[i];
                dataGridView_Limits.Rows[i].Cells[1].Value = Get_Units(ParametersOrder[i]).Name;
                dataGridView_Limits.Rows[i].Cells[2].Value = ParametersMinLimit[i]/
                                                             Get_Units(ParametersOrder[i]).Coefficient;
                dataGridView_Limits.Rows[i].Cells[3].Value = ParametersMaxLimit[i]/
                                                             Get_Units(ParametersOrder[i]).Coefficient;
                dataGridView_Limits.Rows[i].Height = 18;
            }

            zedGraphControl1.GraphPane.Title.IsVisible = false;

            
            /*
             * WriteResult(Program.Form_Main.dataGridView_Results1.Rows[1], "Eu", ParameterUnitsStruct.Eu, ParameterValuesStruct.Eu);
            WriteResult(Program.Form_Main.dataGridView_Results1.Rows[2], "Re", ParameterUnitsStruct.Re, ParameterValuesStruct.Re);
            Program.Form_Main.MakeDelimiter(Program.Form_Main.dataGridView_Results1.Rows[3]);
            WriteResult(Program.Form_Main.dataGridView_Results1.Rows[4], "v", ParameterUnitsStruct.v, ParameterValuesStruct.v);
            Program.Form_Main.MakeDelimiter(Program.Form_Main.dataGridView_Results1.Rows[5]);
            WriteResult(Program.Form_Main.dataGridView_Results1.Rows[6], "Et'", ParameterUnitsStruct.E_red_t, ParameterValuesStruct.E_red_t);
            WriteResult(Program.Form_Main.dataGridView_Results1.Rows[7], "Et", ParameterUnitsStruct.Et, ParameterValuesStruct.Et);
             */

            FormStatus = "Running";
            ProcessData();
            //DisplayCurves();
        }

                // dataGrid_Consts
        void DisplayTableWithConsts()
        {
            dataGridView_Consts.RowCount = 0;
            for (int i = 0; i < ParametersOrder.Length; ++i)
                if (StringToIsInputedParameter(ParametersOrder[i]) &&
                    ParametersOrder[i] != listBox_XAxis.Items[listBox_XAxis.SelectedIndex].ToString())
                {
                    dataGridView_Consts.RowCount++;
                    Parameters.Processors.WriteResult(dataGridView_Consts.Rows[dataGridView_Consts.RowCount - 1],
                                                      ParametersOrder[i], Get_Units(ParametersOrder[i]),
                                                      Get_Value(ParametersOrder[i]));
                }
        }


        private void listBox_XAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_Limits.RowCount; ++i)
                if (dataGridView_Limits.Rows[i].Cells[0].Value == listBox_XAxis.Items[listBox_XAxis.SelectedIndex])
                    dataGridView_Limits.CurrentCell = dataGridView_Limits.Rows[i].Cells[0];

            ProcessData();

            /*
            DoCalculations();
            DisplayCurves();
            DisplayTableWithResults();
             */
        }

        private void UpdateCmCvCTable()
        {
            for(int i = 0; i < dataGridViewCmCvC.RowCount; ++i)
            {
                int j;
                Parameters.ParameterInputInfoStruct.Is_Cm_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_Cv_Inputed = false;
                Parameters.ParameterInputInfoStruct.Is_C_Inputed = false;

                for(j = 0; j < 3; j++)
                {
                    ValueClass val = ValueClass.objectToValue(dataGridViewCmCvC.Rows[i].Cells[j].Value);

                    if(dataGridViewCmCvC.Rows[i].Cells[j].Style.ForeColor == Program.Colors.InputColor)
                    {
                        if (j == 0)
                        {
                            Parameters.ParameterInputInfoStruct.Is_Cm_Inputed = true;
                            Parameters.ParameterValuesStruct.Cm = val * Parameters.ParameterUnitsStruct.Cm.Coefficient;
                        }
                        if (j == 1)
                        {
                            Parameters.ParameterInputInfoStruct.Is_Cv_Inputed = true;
                            Parameters.ParameterValuesStruct.Cv = val * Parameters.ParameterUnitsStruct.Cv.Coefficient;
                        }
                        if (j == 2)
                        {
                            Parameters.ParameterInputInfoStruct.Is_C_Inputed = true;
                            Parameters.ParameterValuesStruct.C = val * Parameters.ParameterUnitsStruct.C.Coefficient;
                        }
                        break;
                    }
                }
                if(j < 3)
                {
                    Parameters.Processors.DocalculationsForTablesAndGraphs();
                    dataGridViewCmCvC.Rows[i].Cells[0].Value = ValueClass.ValueToString(Parameters.ParameterValuesStruct.Cm / Parameters.ParameterUnitsStruct.Cm.Coefficient);
                    dataGridViewCmCvC.Rows[i].Cells[1].Value = ValueClass.ValueToString(Parameters.ParameterValuesStruct.Cv / Parameters.ParameterUnitsStruct.Cv.Coefficient);
                    dataGridViewCmCvC.Rows[i].Cells[2].Value = ValueClass.ValueToString(Parameters.ParameterValuesStruct.C / Parameters.ParameterUnitsStruct.C.Coefficient);
                }
            }
        }

        private void ProcessData()
        {
            if (FormStatus != "Running")
                return;

            Program.CopyCurrentSimulationToParameters();
            UpdateCmCvCTable();
            DoCalculations();
            DisplayTableWithConsts();
            DisplayCurves();
            DisplayTableWithResults();
        }

        private List<List<ValueClass>> NewList2D(int n, int m)
        {
            List<List<ValueClass>> res = new List<List<ValueClass>>();
            for (int i = 0; i < n; ++i)
            {
                res.Add(new List<ValueClass>());
                for (int j = 0; j < m; ++j)
                    res[i].Add(new ValueClass());
            }
            return res;
        }

        void DoIterations(ref ValueClass XVal, double start, double end, UnitStruct units)
            //, ref int number_of_points)
        {
            if (!XVal.Defined)
                return;

            int number_of_Cs = dataGridViewCmCvC.RowCount;

            start /= units.Coefficient;
            end /= units.Coefficient;

            double best_step = 1;
            double eps = 1e-10;
            for (int n = -3; n <= 3; ++n)
                for (int k = 0; k <= 3; ++k)
                {
                    double st = Math.Pow(10, n) * Math.Pow(5, k);
                    long nd = Convert.ToInt64((end + eps) / st) - Convert.ToInt64((start + eps) / st) + 1;
                    long nd_best = Convert.ToInt32((end + eps) / best_step) - Convert.ToInt32((start + eps) / best_step) + 1;
                    //if (Math.Abs((end - start) / (number_of_points - 1) - st) < Math.Abs((end - start) / (number_of_points - 1) - best_step))
                        //best_step = st;
                    if (Math.Abs(nd - number_of_points) < Math.Abs(nd_best - number_of_points))
                        best_step = st;
                }
            double first_x = (Convert.ToInt64((start - eps) / best_step) + 1) * best_step;

            start *= units.Coefficient;
            end *= units.Coefficient;
            best_step *= units.Coefficient; 
            first_x *= units.Coefficient;

            if (comboBox_XAxisType.Text == "Linear")
            {
                //number_of_points = 0;
                //for (double x = start; x <= end; x += best_step)
                //    number_of_points++;
                number_of_points = Convert.ToInt32((end + eps)/best_step) - Convert.ToInt32((start + eps)/best_step) + 1;
            }

            start += 1e-12;
            double coef = Math.Pow(end/(start), 1.0/(number_of_points - 1));

            Data.D = NewList2D(number_of_Cs, number_of_points);
            Data.x_red_50 = NewList2D(number_of_Cs, number_of_points);
            Data.n = NewList2D(number_of_Cs, number_of_points);
            Data.Q = NewList2D(number_of_Cs, number_of_points);
            Data.Dp = NewList2D(number_of_Cs, number_of_points);
            Data.rf = NewList2D(number_of_Cs, number_of_points);
            Data.Du_over_D = NewList2D(number_of_Cs, number_of_points);

            Data.Et = NewList2D(number_of_Cs, number_of_points);
            Data.E_red_t = NewList2D(number_of_Cs, number_of_points);
            Data.Cmo = NewList2D(number_of_Cs, number_of_points);
            Data.Cvo = NewList2D(number_of_Cs, number_of_points);
            Data.Co = NewList2D(number_of_Cs, number_of_points);
            Data.Cmu = NewList2D(number_of_Cs, number_of_points);
            Data.Cvu = NewList2D(number_of_Cs, number_of_points);
            Data.Cu = NewList2D(number_of_Cs, number_of_points);

            for (int k = 0; k < number_of_Cs; ++k) 
            {
                for (int i = 0; i < number_of_points; ++i)
                {
                    Parameters.ParameterValuesStruct.Cm = ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[0].Value) * Parameters.ParameterUnitsStruct.Cm.Coefficient;
                    Parameters.ParameterValuesStruct.Cv = ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[1].Value) * Parameters.ParameterUnitsStruct.Cv.Coefficient;
                    Parameters.ParameterValuesStruct.C = ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[2].Value) * Parameters.ParameterUnitsStruct.C.Coefficient;

                    Parameters.ParameterInputInfoStruct.Is_Cm_Inputed = dataGridViewCmCvC.Rows[k].Cells[0].Style.ForeColor == Program.Colors.InputColor;
                    Parameters.ParameterInputInfoStruct.Is_Cv_Inputed = dataGridViewCmCvC.Rows[k].Cells[1].Style.ForeColor == Program.Colors.InputColor;
                    Parameters.ParameterInputInfoStruct.Is_C_Inputed = dataGridViewCmCvC.Rows[k].Cells[2].Style.ForeColor == Program.Colors.InputColor;


                    //XVal.Value = start + (end - start)*i/(number_of_points - 1);
                    if (comboBox_XAxisType.Text == "Linear")
                    {
                        //XVal.Value = start + best_step*i;
                        if (i == 0)
                            XVal.Value = start;
                        else if (i == number_of_points - 1)
                            XVal.Value = end;
                        else
                            XVal.Value = first_x + (i - 1)*best_step;
                    }
                    else
                        XVal.Value = start * Math.Pow(coef, i);

                    Parameters.Processors.DocalculationsForTablesAndGraphs();
                    
                    Data.D[k][i] = Parameters.ParameterValuesStruct.D;
                    Data.x_red_50[k][i] = Parameters.ParameterValuesStruct.x_red_50;
                    Data.n[k][i] = Parameters.ParameterValuesStruct.n;
                    Data.Q[k][i] = Parameters.ParameterValuesStruct.Q;
                    Data.Dp[k][i] = Parameters.ParameterValuesStruct.Dp;
                    Data.rf[k][i] = Parameters.ParameterValuesStruct.rf;
                    Data.Du_over_D[k][i] = Parameters.ParameterValuesStruct.Du_over_D;

                    Data.Et[k][i] = Parameters.ParameterValuesStruct.Et;
                    Data.E_red_t[k][i] = Parameters.ParameterValuesStruct.E_red_t;
                    Data.Cmo[k][i] = Parameters.ParameterValuesStruct.Cmo;
                    Data.Cvo[k][i] = Parameters.ParameterValuesStruct.Cvo;
                    Data.Co[k][i] = Parameters.ParameterValuesStruct.Co;
                    Data.Cmu[k][i] = Parameters.ParameterValuesStruct.Cmu;
                    Data.Cvu[k][i] = Parameters.ParameterValuesStruct.Cvu;
                    Data.Cu[k][i] = Parameters.ParameterValuesStruct.Cu;
                }
            }
        }

        private int Get_ID_InParamsOrder(string s)
        {
            int i;
            for (i = 0; i < ParametersOrder.Length; ++i)
                if (s == ParametersOrder[i])
                    return i;
            return -1;
        }

        private void DoCalculations()
        {
            if (FormStatus != "Running")
                return;

            if (StringToIsInputedParameter(listBox_XAxis.Items[listBox_XAxis.SelectedIndex].ToString()))
            {
                if (!int.TryParse(textBox1.Text, out number_of_points) || number_of_points < 2)
                    number_of_points = 2;
                double start, end;
                
                switch (listBox_XAxis.Items[listBox_XAxis.SelectedIndex].ToString())
                {
                    case "x'50":
                        //start = 1e-6;
                        //end = 1e-4;
                        start =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("x'50")].Cells[2].Value)*
                             Parameters.ParameterUnitsStruct.x_red_50.Coefficient).Value;
                        end =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("x'50")].Cells[3].Value)*
                             Parameters.ParameterUnitsStruct.x_red_50.Coefficient).Value;
                        DoIterations(ref Parameters.ParameterValuesStruct.x_red_50, start, end, Parameters.ParameterUnitsStruct.x_red_50);
                        break;

                    case "D":
                        //start = 1e-4;
                        //end = 0.5;
                        start =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("D")].Cells[2].Value) *
                             Parameters.ParameterUnitsStruct.D.Coefficient).Value;
                        end =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("D")].Cells[3].Value) *
                             Parameters.ParameterUnitsStruct.D.Coefficient).Value;
                        DoIterations(ref Parameters.ParameterValuesStruct.D, start, end, Parameters.ParameterUnitsStruct.D);
                        break;

                    case "n":
                        //start = 1;
                        //end = 20;
                        start =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("n")].Cells[2].Value) *
                             Parameters.ParameterUnitsStruct.n.Coefficient).Value;
                        end =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("n")].Cells[3].Value) *
                             Parameters.ParameterUnitsStruct.n.Coefficient).Value;
                        DoIterations(ref Parameters.ParameterValuesStruct.n, start, end, Parameters.ParameterUnitsStruct.n);
                        break;

                    case "Q":
                        //start = 0.05;
                        //end = 500;
                        start =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("Q")].Cells[2].Value) *
                             Parameters.ParameterUnitsStruct.Q.Coefficient).Value;
                        end =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("Q")].Cells[3].Value) *
                             Parameters.ParameterUnitsStruct.Q.Coefficient).Value;
                        DoIterations(ref Parameters.ParameterValuesStruct.Q, start, end, Parameters.ParameterUnitsStruct.Q);
                        break;

                    case "Dp":
                        //start = 0;
                        //end = 50;
                        start =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("Dp")].Cells[2].Value) *
                             Parameters.ParameterUnitsStruct.Dp.Coefficient).Value;
                        end =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("Dp")].Cells[3].Value) *
                             Parameters.ParameterUnitsStruct.Dp.Coefficient).Value;
                        DoIterations(ref Parameters.ParameterValuesStruct.Dp, start, end, Parameters.ParameterUnitsStruct.Dp);
                        break;

                    case "rf":
                        //start = 1e-6;
                        //end = 1 - 1e-6;
                        start =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("rf")].Cells[2].Value) *
                             Parameters.ParameterUnitsStruct.rf.Coefficient).Value;
                        end =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("rf")].Cells[3].Value) *
                             Parameters.ParameterUnitsStruct.rf.Coefficient).Value;
                        DoIterations(ref Parameters.ParameterValuesStruct.rf, start, end, Parameters.ParameterUnitsStruct.rf);
                        break;

                    case "Du/D":
                        //start = 1e-6;
                        //end = 1 - 1e-6;
                        start =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("Du/D")].Cells[2].Value) *
                             Parameters.ParameterUnitsStruct.Du_over_D.Coefficient).Value;
                        end =
                            (ValueClass.objectToValue(
                                 dataGridView_Limits.Rows[Get_ID_InParamsOrder("Du/D")].Cells[3].Value) *
                             Parameters.ParameterUnitsStruct.Du_over_D.Coefficient).Value;
                        DoIterations(ref Parameters.ParameterValuesStruct.Du_over_D, start, end, Parameters.ParameterUnitsStruct.Du_over_D);
                        break;
                }
            }
        }

        private void DisplayTableWithResults()
        {
            if (FormStatus != "Running")
                return;

            if (dataGridViewCmCvC.CurrentCell == null
                || !ValueClass.objectToValue(dataGridViewCmCvC.Rows[dataGridViewCmCvC.CurrentCell.RowIndex].Cells[0].Value).Defined)
            {
                dataGridView1.RowCount = 0;
                return;
            }


            int cur_C_row = dataGridViewCmCvC.CurrentCell.RowIndex;
            
            if (StringToIsInputedParameter(listBox_XAxis.Items[listBox_XAxis.SelectedIndex].ToString()))
            {
                //number_of_points = (Data.x_red_50 == null ? 0 : Data.x_red_50[0].Count);
                int i;
                string str;

                str = listBox_XAxis.Items[listBox_XAxis.SelectedIndex].ToString();
                dataGridView1.Columns[1].HeaderCell.Value = str + " (" + Get_Units(str).Name + ")";
                for (int j = 1; j < listBox_YAxis1.Items.Count; ++j)
                {
                    str = listBox_YAxis1.Items[j].ToString();
                    dataGridView1.Columns[1 + j].HeaderCell.Value = str + " (" + Get_Units(str).Name + ")";
                }

                str = comboBox_EtEredt.Text;
                dataGridView1.Columns[5].HeaderCell.Value = str + " (" + Get_Units(str).Name + ")";

                str = comboBox_CmCvC.Text + "u";
                dataGridView1.Columns[6].HeaderCell.Value = str + " (" + Get_Units(str).Name + ")";

                str = comboBox_CmCvC.Text + "o";
                dataGridView1.Columns[7].HeaderCell.Value = str + " (" + Get_Units(str).Name + ")";
                    
                
                dataGridView1.RowCount = number_of_points;
                for (i = 0; i < number_of_points; ++i)
                {
                    dataGridView1.Rows[i].Height = 18;

                    dataGridView1.Rows[i].Cells[0].Value = i + 1;

                    str = listBox_XAxis.Items[listBox_XAxis.SelectedIndex].ToString();
                   
                    dataGridView1.Rows[i].Cells[1].Value = (Get_kth_List(str,cur_C_row)[i] / Get_Units(str).Coefficient).ToStringWithRounding(2);// / Parameters.ParameterUnitsStruct.x_red_50.Coefficient;

                    for (int j = 1; j < listBox_YAxis1.Items.Count; ++j)
                    {
                        str = listBox_YAxis1.Items[j].ToString();
                        dataGridView1.Rows[i].Cells[1+j].Value = (Get_kth_List(str, cur_C_row)[i] / Get_Units(str).Coefficient).ToStringWithRounding(2 + (str == "Du/D" ? 1 : 0));
                    }

                    str = comboBox_EtEredt.Text;
                    dataGridView1.Rows[i].Cells[5].Value = (Get_kth_List(str, cur_C_row)[i] / Get_Units(str).Coefficient).ToStringWithRounding(2);

                    str = comboBox_CmCvC.Text + "u";
                    dataGridView1.Rows[i].Cells[6].Value = (Get_kth_List(str, cur_C_row)[i] / Get_Units(str).Coefficient).ToStringWithRounding(2);
                    
                    str = comboBox_CmCvC.Text + "o";
                    dataGridView1.Rows[i].Cells[7].Value = (Get_kth_List(str, cur_C_row)[i] / Get_Units(str).Coefficient).ToStringWithRounding(2);
                    /*
                    if (listBox_YAxis1.Items[listBox_YAxis1.SelectedIndex].ToString() == "D")
                        dataGridView1.Rows[i].Cells[2].Value = Data.D[cur_C_row][i].Value / Parameters.ParameterUnitsStruct.D.Coefficient;
                     */
                }
            }
            else
                dataGridView1.RowCount = 0;
        }

        private void DisplayCurves()
        {
            if (FormStatus != "Running")
                return;

            zedGraphControl1.GraphPane.CurveList.Clear();

            if( StringToIsInputedParameter(listBox_XAxis.Items[listBox_XAxis.SelectedIndex].ToString()) )
            {
                label_WrongX.Visible = false;
                zedGraphControl1.Visible = true;

                int number_of_Cs = (Data.x_red_50 == null ? 0 : Data.x_red_50.Count);
                //int number_of_points = (Data.x_red_50 == null ? 0 : Data.x_red_50[0].Count);
                int k;

                for (k = 0; k < number_of_Cs; ++k) if (Convert.ToBoolean(dataGridViewCmCvC.Rows[k].Cells[3].Value))
                {
                    if (!ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[0].Value).Defined)
                        continue;

                    Add_kth_CurveY1ToPane(zedGraphControl1.GraphPane, k);
                    Add_kth_CurveY2ToPane(zedGraphControl1.GraphPane, k);
                }
            }
            else
            {
                label_WrongX.Visible = true;
                zedGraphControl1.Visible = false;
                dataGridView1.RowCount = 0;
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        UnitStruct Get_Units(string parameter)
        {
            switch (parameter)
            {
                case "D":
                    return Parameters.ParameterUnitsStruct.D;
                case "x'50":
                    return Parameters.ParameterUnitsStruct.x_red_50;
                case "n":
                    return Parameters.ParameterUnitsStruct.n;
                case "Q":
                    return Parameters.ParameterUnitsStruct.Q;
                case "Dp":
                    return Parameters.ParameterUnitsStruct.Dp;
                case "rf":
                    return Parameters.ParameterUnitsStruct.rf;
                case "Du/D":
                    return Parameters.ParameterUnitsStruct.Du_over_D;

                case "ET":
                    return Parameters.ParameterUnitsStruct.Et;
                case "E'T":
                    return Parameters.ParameterUnitsStruct.E_red_t;

                case "Cmo":
                case "Cmu":
                    return Parameters.ParameterUnitsStruct.Cm;

                case "Cvo":
                case "Cvu":
                    return Parameters.ParameterUnitsStruct.Cv;

                case "Co":
                case "Cu":
                    return Parameters.ParameterUnitsStruct.C;

            }
            return new UnitStruct();
        }

        ValueClass Get_Value(string parameter)
        {
            switch (parameter)
            {
                case "D":
                    return Parameters.ParameterValuesStruct.D;
                case "x'50":
                    return Parameters.ParameterValuesStruct.x_red_50;
                case "n":
                    return Parameters.ParameterValuesStruct.n;
                case "Q":
                    return Parameters.ParameterValuesStruct.Q;
                case "Dp":
                    return Parameters.ParameterValuesStruct.Dp;
                case "rf":
                    return Parameters.ParameterValuesStruct.rf;
                case "Du/D":
                    return Parameters.ParameterValuesStruct.Du_over_D;

                case "ET":
                    return Parameters.ParameterValuesStruct.Et;
                case "E'T":
                    return Parameters.ParameterValuesStruct.E_red_t;

                case "Cmo":
                case "Cmu":
                    return Parameters.ParameterValuesStruct.Cm;

                case "Cvo":
                case "Cvu":
                    return Parameters.ParameterValuesStruct.Cv;

                case "Co":
                case "Cu":
                    return Parameters.ParameterValuesStruct.C;

            }
            return new ValueClass();
        }

        List<ValueClass> Get_kth_List(string parameter, int k)
        {
            switch(parameter)
            {
                case "D":
                    return Data.D[k];
                case "x'50":
                    return Data.x_red_50[k];
                case "n":
                    return Data.n[k];
                case "Q":
                    return Data.Q[k];
                case "Dp":
                    return Data.Dp[k];
                case "rf":
                    return Data.rf[k];
                case "Du/D":
                    return Data.Du_over_D[k];

                case "ET":
                    return Data.Et[k];
                case "E'T":
                    return Data.E_red_t[k];

                case "Cmo":
                    return Data.Cmo[k];
                case "Cmu":
                    return Data.Cmu[k];
                    
                case "Cvo":
                    return Data.Cvo[k];
                case "Cvu":
                    return Data.Cvu[k];

                case "Co":
                    return Data.Co[k];
                case "Cu":
                    return Data.Cu[k];
                
            }
            return new List<ValueClass>();
        }

        private void Add_kth_CurveY1ToPane(ZedGraph.GraphPane pane, int k)
        {
            string str_x = listBox_XAxis.Items[listBox_XAxis.SelectedIndex].ToString();
            string str_y = listBox_YAxis1.Items[listBox_YAxis1.SelectedIndex].ToString();

            List<ValueClass> xList = Get_kth_List(str_x, k);
            List<ValueClass> yList = Get_kth_List(str_y, k);

            int number_of_nodes = Math.Min(xList.Count, yList.Count);
            int bad_points_count = 0;

            for (int i = 0; i < number_of_nodes; ++i)
            {
                if (!(xList[i]/Get_Units(str_x).Coefficient).Defined
                    || !(yList[i]/Get_Units(str_y).Coefficient).Defined)
                    bad_points_count++;
            }

            int number_of_points = number_of_nodes - bad_points_count;

            double[] ax = new double[number_of_points];
            double[] ay = new double[number_of_points];

            bad_points_count = 0;
            
            for (int i = 0; i < number_of_nodes; ++i)
            {
                if (!(xList[i] / Get_Units(str_x).Coefficient).Defined
                    || !(yList[i] / Get_Units(str_y).Coefficient).Defined)
                    bad_points_count++;
                else
                {
                    ax[i - bad_points_count] = (xList[i] / Get_Units(str_x).Coefficient).Value;
                    ay[i - bad_points_count] = (yList[i] / Get_Units(str_y).Coefficient).Value;
                }
            }

            if (ax.Length > 0)
            {
                string legend = (dataGridViewCmCvC.Rows[k].Cells[0].Style.ForeColor == Program.Colors.InputColor
                                     ? "Cm=" +
                                       ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[0].Value).
                                           ToStringWithRounding(2)
                                     : (dataGridViewCmCvC.Rows[k].Cells[1].Style.ForeColor == Program.Colors.InputColor
                                            ? "Cv=" +
                                              ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[1].Value).
                                                  ToStringWithRounding(2)
                                            : "C=" +
                                              ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[2].Value).
                                                  ToStringWithRounding(2)));
                pane.AddCurve(legend, ax, ay, ColorsSet[k%ColorsSet.Length], ZedGraph.SymbolType.None);
            }
            pane.YAxis.IsVisible = number_of_nodes > 0;
            pane.YAxis.Title.Text = str_y;
            pane.XAxis.Type = comboBox_XAxisType.Text == "Linear" ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;
            pane.YAxis.Type = comboBox_YAxisType.Text == "Linear" ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;
            pane.XAxis.Title.Text = str_x;
        }

        private void Add_kth_CurveY2ToPane(ZedGraph.GraphPane pane, int k)
        {
            string str_x = listBox_XAxis.Items[listBox_XAxis.SelectedIndex].ToString();
            string str_y = listBox_YAxis2.Items[listBox_YAxis2.SelectedIndex].ToString();

            List<ValueClass> xList = Get_kth_List(str_x, k);
            List<ValueClass> yList = Get_kth_List(str_y, k);

            int number_of_nodes = Math.Min(xList.Count, yList.Count);
            int bad_points_count = 0;

            for (int i = 0; i < number_of_nodes; ++i)
            {
                if (!(xList[i] / Get_Units(str_x).Coefficient).Defined
                    || !(yList[i] / Get_Units(str_y).Coefficient).Defined)
                    bad_points_count++;
            }

            int number_of_points = number_of_nodes - bad_points_count;

            double[] ax = new double[number_of_nodes];
            double[] ay = new double[number_of_nodes];

            bad_points_count = 0;

            for (int i = 0; i < number_of_nodes; ++i)
            {
                if (!(xList[i] / Get_Units(str_x).Coefficient).Defined
                    || !(yList[i] / Get_Units(str_y).Coefficient).Defined)
                    bad_points_count++;
                else
                {
                    ax[i - bad_points_count] = (xList[i] / Get_Units(str_x).Coefficient).Value;
                    ay[i - bad_points_count] = (yList[i] / Get_Units(str_y).Coefficient).Value;
                }
            }
            /*
            for (int i = 0; i < number_of_nodes; ++i)
            {
                ax[i] = (xList[i] / Get_Units(str_x).Coefficient).Value;
                ay[i] = (yList[i] / Get_Units(str_y).Coefficient).Value;
            }
            */

            if (ax.Length > 0)
            {
                //string legend = "Cm=" + ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[0].Value).ToStringWithRounding(2);
                string legend = (dataGridViewCmCvC.Rows[k].Cells[0].Style.ForeColor == Program.Colors.InputColor
                                     ? "Cm=" +
                                       ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[0].Value).
                                           ToStringWithRounding(2)
                                     : (dataGridViewCmCvC.Rows[k].Cells[1].Style.ForeColor == Program.Colors.InputColor
                                            ? "Cv=" +
                                              ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[1].Value).
                                                  ToStringWithRounding(2)
                                            : "C=" +
                                              ValueClass.objectToValue(dataGridViewCmCvC.Rows[k].Cells[2].Value).
                                                  ToStringWithRounding(2)));
                
                pane.AddCurve(legend, ax, ay, ColorsSet[k % ColorsSet.Length], ZedGraph.SymbolType.None);
                pane.CurveList[pane.CurveList.Count - 1].IsY2Axis = true;
            }
            pane.Y2Axis.IsVisible = number_of_nodes > 0;
            pane.Y2Axis.Title.Text = str_y;
            pane.XAxis.Type = comboBox_XAxisType.Text == "Linear" ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;
            pane.Y2Axis.Type = comboBox_YAxisType.Text == "Linear" ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;
            pane.XAxis.Title.Text = str_x;
        }


        private void listBox_YAxis1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayCurves();
        }

        private void listBox_YAxis2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayCurves();
        }

        private void dataGridCmCvC_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Program.UpdateTextBoxFont(tb);

            dataGridViewCmCvC.CurrentCell.Value = tb.Text;
            for (int j = 0; j < 3; ++j)
                dataGridViewCmCvC.Rows[dataGridViewCmCvC.CurrentCell.RowIndex].Cells[j].Style.ForeColor =
                    Program.Colors.CalculatedColor;

            dataGridViewCmCvC.CurrentCell.Style.ForeColor = Program.Colors.InputColor;

            ProcessData();
        }

        private void dataGridLimits_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Program.UpdateTextBoxFont(tb);

            dataGridView_Limits.CurrentCell.Value = tb.Text;
            /*
            for (int j = 0; j < 3; ++j)
                dataGridView_Limits.Rows[dataGridViewCmCvC.CurrentCell.RowIndex].Cells[j].Style.ForeColor =
                    Program.Colors.CalculatedColor;
            */
            dataGridView_Limits.CurrentCell.Style.ForeColor = Program.Colors.InputColor;

            ProcessData();
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged -= dataGridCmCvC_TextChanged;
            e.Control.TextChanged += dataGridCmCvC_TextChanged;
            e.Control.KeyPress -= Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;
            e.Control.KeyPress += Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;
        }

        private void FormTablesAndCharts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.CList_For_TablesAndCharts.Clear();
            for(int i = 0; i < dataGridViewCmCvC.RowCount; ++i)
            {
                for (int j = 0; j < 3; ++j)
                    if(dataGridViewCmCvC.Rows[i].Cells[j].Style.ForeColor == Program.Colors.InputColor)
                    {
                        ValueClass val = ValueClass.objectToValue(dataGridViewCmCvC.Rows[i].Cells[j].Value);
                        UnitStruct unit = j == 0
                                      ? Parameters.ParameterUnitsStruct.Cm
                                      : (j == 1 ? Parameters.ParameterUnitsStruct.Cv : Parameters.ParameterUnitsStruct.C);
                        //bool inp = dataGridViewCmCvC.Rows[i].Cells[2].Value

                        if (val.Defined)
                            Program.CList_For_TablesAndCharts.Add(new Pair<ValueClass, int>(val * unit.Coefficient, j));
                    }
            }
        }

        private void dataGridViewCmCvC_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ProcessData();
        }

        private void dataGridViewCmCvC_CurrentCellChanged(object sender, EventArgs e)
        {
            DisplayTableWithResults();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTableWithResults();
        }

        private void comboBox_CmCvC_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTableWithResults();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ProcessData();
        }

        private void comboBox_XAxisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessData();
        }

        private void dataGridView_Limits_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged -= dataGridLimits_TextChanged;
            e.Control.TextChanged += dataGridLimits_TextChanged;
            e.Control.KeyPress -= Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;
            e.Control.KeyPress += Program.Form_Main.dataGrid_Inputs_Editing_KeyPress;
        }

        private void dataGridViewCmCvC_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value = true;
            ((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value = "Delete";
        }

        private void dataGridView_Limits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewCmCvC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            //if (dg.CurrentCell.ColumnIndex == 3)
            if (e.ColumnIndex == 3)
            {
                //textBox_Cm.Text = "EditFormVal = " + dg.CurrentCell.EditedFormattedValue.ToString();
                dg.CurrentCell.Value = dg.CurrentCell.EditedFormattedValue;
                DisplayCurves();
                //DisplayTableWithResults();
                //ProcessData();
            }
            //else if (dg.CurrentCell.ColumnIndex == 4)
            else if (e.ColumnIndex == 4)
            {
                //dg.CurrentCell.Value = dg.CurrentCell.EditedFormattedValue;
                if (e.RowIndex < dg.Rows.Count - 1)
                {
                    dg.Rows.Remove(dg.Rows[dg.CurrentCell.RowIndex]);
                    ProcessData();
                }
            }
        }

        private void dataGridViewCmCvC_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.CurrentCell.ColumnIndex == 3)
            {
                //textBox_Cm.Text = "EditFormVal = " + dg.CurrentCell.EditedFormattedValue.ToString();
                dg.CurrentCell.Value = dg.CurrentCell.EditedFormattedValue;
                DisplayCurves();
                //DisplayTableWithResults();
                //ProcessData();
            }
        }

        private void comboBox_YAxisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessData();
        }

        private void dataGridViewCmCvC_Sorted(object sender, EventArgs e)
        {
            ProcessData();
        }

        private void dataGridViewCmCvC_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index < 3)
            {
                ValueClass v1 = ValueClass.objectToValue(e.CellValue1);
                ValueClass v2 = ValueClass.objectToValue(e.CellValue2);
                e.SortResult = (v1 < v2 ? -1 : (v1 == v2 ? 0 : 1));
            }
            else
            {
                bool v1 = Convert.ToBoolean(e.CellValue1);
                bool v2 = Convert.ToBoolean(e.CellValue2);
                e.SortResult = (v1 == v2 ? 0 : (!v1 ? -1 : 1));
            }

            e.Handled = true;
        }

    }
}