using System;

namespace Hydrocyclone1
{
    class Simulation
    {
        public struct SimulationInfoStruct
        {
            public int ID;
            public String Name, Material, Custumer, Charge, Comments;
            public bool WasChanged;
        }

        public struct ParameterValuesStruct
        {
            public ValueClass mu;
            public ValueClass rho_f, rho_s, rho_sus;
            public ValueClass Cm, Cv, C;
            public ValueClass x_g, sigma_g;
            public ValueClass sigma_s;
            public ValueClass Qm, Q, Qs;
            public ValueClass rf, Du_over_D;
            public ValueClass n, Dp;
            public ValueClass x_red_50, D;

            public ValueClass alpha1, alpha2, alpha3;
            public ValueClass beta1, beta2, beta3;
            public ValueClass gamma1, gamma2, gamma3;

            public ValueClass L_over_D, l_over_D, Di_over_D, Do_over_D;
            //public ValueClass L, l, Di, Do;
        }

        public struct ParameterInputInfoStruct
        {
            public bool Is_rho_s_Inputed, Is_rho_sus_Inputed;
            public bool Is_Cm_Inputed, Is_Cv_Inputed, Is_C_Inputed;
            public bool Is_Qm_Inputed, Is_Q_Inputed, Is_Qs_Inputed;
            public bool Is_rf_Inputed, Is_Du_over_D_Inputed;
            public bool Is_n_Inputed, Is_Dp_Inputed;
            public bool Is_x_red_50_Inputed, Is_D_Inputed;
            public bool Is_n_Checked, Is_Dp_Checked, Is_Q_Checked;
        }

        public SimulationInfoStruct SimulationInfo;
        public ParameterValuesStruct ParameterValues;
        public ParameterInputInfoStruct ParameterInputInfo;

        public Simulation()
        {
        }

        public Simulation(Simulation sm)
        {
            SimulationInfo = sm.SimulationInfo;
            ParameterValues = sm.ParameterValues;
            ParameterInputInfo = sm.ParameterInputInfo;
        }
    }
}
