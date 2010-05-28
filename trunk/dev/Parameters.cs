using System;
using System.Drawing;

namespace Hydrocyclone1
{
    static class Parameters
    {
        static public class ParameterUnitsStruct
        {
            static public UnitStruct mu = new UnitStruct("10-3Pa*s", 1e-3);
            static public UnitStruct rho_f = new UnitStruct("kg/m3", 1.0), rho_s = new UnitStruct("kg/m3", 1.0), rho_sus = new UnitStruct("kg/m3", 1.0);
            static public UnitStruct Cm = new UnitStruct("%", 0.01), Cv = new UnitStruct("%", 0.01), C = new UnitStruct("g/l", 1);
            static public UnitStruct x_g = new UnitStruct("10-6m", 1e-6), sigma_g = new UnitStruct("-", 1);
            static public UnitStruct sigma_s = new UnitStruct("-", 1);
            static public UnitStruct Q = new UnitStruct("m3/h", 1.0 / 3600), Qm = new UnitStruct("t/h", 1000.0 / 3600), Qs = new UnitStruct("t/h", 1000.0 / 3600);
            static public UnitStruct rf = new UnitStruct("%", 0.01), Du_over_D = new UnitStruct("-", 1);
            static public UnitStruct n = new UnitStruct("-", 1.0), Dp = new UnitStruct("bar", 1e5);
            static public UnitStruct x_red_50 = new UnitStruct("10-6m", 1e-6), D = new UnitStruct("mm", 1e-3);

            static public UnitStruct alpha1 = new UnitStruct("-", 1), alpha2 = new UnitStruct("-", 1), alpha3 = new UnitStruct("-", 1);
            static public UnitStruct beta1 = new UnitStruct("-", 1), beta2 = new UnitStruct("-", 1), beta3 = new UnitStruct("-", 1);
            static public UnitStruct gamma1 = new UnitStruct("-", 1), gamma2 = new UnitStruct("-", 1), gamma3 = new UnitStruct("-", 1);

            static public UnitStruct Stk_red = new UnitStruct("10-3", 1e-3), Eu = new UnitStruct("10+3", 1e3), Re = new UnitStruct("10+3", 1e3);
            static public UnitStruct E_red_t = new UnitStruct("%", 0.01), Et = new UnitStruct("%", 0.01);
            static public UnitStruct x_o_50 = new UnitStruct("10-6m", 1e-6), x_u_50 = new UnitStruct("10-6m", 1e-6);

            static public UnitStruct v = new UnitStruct("m/s", 1);

            static public UnitStruct L_over_D = new UnitStruct("-", 1), l_over_D = new UnitStruct("-", 1), Di_over_D = new UnitStruct("-", 1), Do_over_D = new UnitStruct("-", 1);
            static public UnitStruct L = new UnitStruct("mm", 1e-3), l = new UnitStruct("mm", 1e-3), Di = new UnitStruct("mm", 1e-3), Do = new UnitStruct("mm", 1e-3), Du = new UnitStruct("mm", 1e-3);
            //static public UnitStruct Cmo = new UnitStruct("%", 0.01), Cvo = new UnitStruct("%", 0.01), Co = new UnitStruct("kg/m3", 1);
            //static public UnitStruct Cmu = new UnitStruct("%", 0.01), Cvu = new UnitStruct("%", 0.01), Cu = new UnitStruct("kg/m3", 1);
        }
        static public class ParameterValuesStruct
        {
            static public ValueClass mu;
            static public ValueClass rho_f, rho_s, rho_sus;
            static public ValueClass Cm, Cv, C;
            static public ValueClass x_g, sigma_g;
            static public ValueClass sigma_s;            
            static public ValueClass Q, Qm, Qs; 
            static public ValueClass rf, Du_over_D;
            static public ValueClass n, Dp;
            static public ValueClass x_red_50, D;

            static public ValueClass alpha1, alpha2, alpha3;
            static public ValueClass beta1, beta2, beta3;
            static public ValueClass gamma1, gamma2, gamma3;

            static public ValueClass v;
            static public ValueClass Stk_red, Eu, Re;
            static public ValueClass E_red_t, Et;
            static public ValueClass x_50, x_o_50, x_u_50;
            static public ValueClass Cmo, Cvo, Co;
            static public ValueClass Cmu, Cvu, Cu;
            static public ValueClass Qo, Qmo, Qso;
            static public ValueClass Qu, Qmu, Qsu;

            static public ValueClass L_over_D, l_over_D, Di_over_D, Do_over_D;
            static public ValueClass L, l, Di, Do, Du;

            static public class Consts
            {
                static public ValueClass Pi = new ValueClass(3.1415926535897932384626433832795);
            }

            static public ValueClass Eval_rho_sus_From_rho_f_rho_s_Cm()
            {
                return -rho_s * rho_f / (-Cm * rho_f + Cm * rho_s - rho_s);
            }
            static public ValueClass Eval_rho_sus_From_rho_f_rho_s_Cv()
            {
                return -Cv * rho_f + Cv * rho_s + rho_f;
            }
            static public ValueClass Eval_rho_sus_From_rho_f_rho_s_C()
            {
                return (-C * rho_f + C * rho_s + rho_s * rho_f) / rho_s;
            }
            static public ValueClass Eval_rho_s_From_rho_f_rho_sus_Cv()
            {
                return (Cv * rho_f - rho_f + rho_sus) / Cv;
            }
            static public ValueClass Eval_rho_s_From_rho_f_rho_sus_C()
            {
                return -C * rho_f / (-C - rho_f + rho_sus);
            }
            static public ValueClass Eval_rho_s_From_rho_f_rho_sus_Cm()
            {
                return Cm * rho_sus * rho_f / (Cm * rho_sus + rho_f - rho_sus);
            }
            static public ValueClass Eval_Cm_From_rhos(ValueClass rho_f, ValueClass rho_s, ValueClass rho_sus)
            {
                return rho_s * (rho_f - rho_sus) / rho_sus / (rho_f - rho_s);
            }
            static public ValueClass Eval_Cm_From_rhos()
            {
                return Eval_Cm_From_rhos(rho_f, rho_s, rho_sus);
            }
            static public ValueClass Eval_Cv_From_rhos(ValueClass rho_f, ValueClass rho_s, ValueClass rho_sus)
            {
                return (rho_f - rho_sus) / (rho_f - rho_s);
            }
            static public ValueClass Eval_Cv_From_rhos()
            {
                return Eval_Cv_From_rhos(rho_f, rho_s, rho_sus);
            }
            static public ValueClass Eval_C_From_rhos(ValueClass rho_f, ValueClass rho_s, ValueClass rho_sus)
            {
                return rho_s * (rho_f - rho_sus) / (rho_f - rho_s);
            }
            static public ValueClass Eval_C_From_rhos()
            {
                return Eval_C_From_rhos(rho_f, rho_s, rho_sus);
            }
            static public void Eval_rho_sus_and_Cs_from_rho_s_and_Cm()
            {
                rho_sus = Eval_rho_sus_From_rho_f_rho_s_Cm();
                Cv = Eval_Cv_From_rhos();
                C = Eval_C_From_rhos();
            }
            static public void Eval_rho_sus_and_Cs_from_rho_s_and_Cv()
            {
                rho_sus = Eval_rho_sus_From_rho_f_rho_s_Cv();
                Cm = Eval_Cm_From_rhos();
                C = Eval_C_From_rhos();
            }
            static public void Eval_rho_sus_and_Cs_from_rho_s_and_C()
            {
                rho_sus = Eval_rho_sus_From_rho_f_rho_s_C();
                Cv = Eval_Cv_From_rhos();
                Cm = Eval_Cm_From_rhos();
            }
            static public void Eval_rho_s_and_Cs_from_rho_sus_and_Cm()
            {
                rho_s = Eval_rho_s_From_rho_f_rho_sus_Cm();
                Cv = Eval_Cv_From_rhos();
                C = Eval_C_From_rhos();
            }
            static public void Eval_rho_s_and_Cs_from_rho_sus_and_Cv()
            {
                rho_s = Eval_rho_s_From_rho_f_rho_sus_Cv();
                Cm = Eval_Cm_From_rhos();
                C = Eval_C_From_rhos();
            }
            static public void Eval_rho_s_and_Cs_from_rho_sus_and_C()
            {
                rho_s = Eval_rho_s_From_rho_f_rho_sus_C();
                Cv = Eval_Cv_From_rhos();
                Cm = Eval_Cm_From_rhos();
            }
            static public ValueClass Eval_Qm_From_Q_rhosus()
            {
                return Q * rho_sus;
            }
            static public ValueClass Eval_Q_From_Qm_rhosus()
            {
                return Qm / rho_sus;
            }
            static public ValueClass Eval_Qs_From_Q_C()
            {
                return Q * C;
            }
            static public ValueClass Eval_Q_From_Qs_C()
            {
                return Qs / C;
            }
            static public void Eval_Du_over_D_Dp_D_from_others()
            {
                ValueClass C1 = -9.0 / 2 * alpha1 * ValueClass.Pow(ValueClass.Log(1.0 / rf), alpha2) * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * n * mu / (x_red_50 * x_red_50) / (-rho_s + rho_f) / Q;
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f * Q / Consts.Pi / n / mu, beta2) / ValueClass.Exp(beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1 / rf, 1 / gamma3);
                ValueClass C4 = 1.0 / 8 * ValueClass.Sqr(Consts.Pi * n / Q) / rho_f;

                D = ValueClass.Pow(C2 / C1, 1.0 / (3 + beta2));
                Dp = C1 / C4 / D;
                Du_over_D = ValueClass.Pow(C3, -gamma3 / gamma2) * ValueClass.Pow(C1, beta2 * gamma3 / (3 + beta2) / gamma2) * ValueClass.Pow(C2, 3 * gamma3 / (3 + beta2) / gamma2);
            }
            static public void Eval_rf_n_x_red_50_from_others()
            {
                ValueClass C1 = -9.0 / 2 * alpha1 * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * ValueClass.Pow(D, 3) * mu / Q / (-rho_s + rho_f);
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f / D * Q / Consts.Pi, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1, (1 / gamma3)) * ValueClass.Pow(Du_over_D, (gamma2 / gamma3));
                ValueClass C4 = 1.0 / 8 * Dp * ValueClass.Sqr(Consts.Pi * D * D / Q) / rho_f;

                n = ValueClass.Pow((C2 * ValueClass.Pow(mu, -beta2) / C4), (1 / (2 + beta2)));
                rf = ValueClass.Pow((C4 / C3 * ValueClass.Sqr(n)), (-gamma3));
                x_red_50 = ValueClass.Pow(C4, (-0.5 * beta2 / (2 + beta2))) * ValueClass.Pow(C2, (-1 / (2 + beta2))) * ValueClass.Pow(mu, (beta2 / (2 + beta2))) * ValueClass.Sqrt(C1 * n) * ValueClass.Pow(ValueClass.Log(1 / rf), (0.5 * alpha2));
            }
            static public void Eval_Du_over_D_D_n_from_others()
            {
                ValueClass C1 = -9.0 / 2 * alpha1 * ValueClass.Pow(ValueClass.Log(1 / rf), alpha2) * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * mu / ValueClass.Sqr(x_red_50) / (-rho_s + rho_f) / Q;
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f * Q / Consts.Pi / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow((gamma1 / rf), (1 / gamma3));
                ValueClass C4 = 1.0 / 8 * Dp * ValueClass.Sqr(Consts.Pi / Q) / rho_f;

                D = ValueClass.Sqrt(C4 * C2 * ValueClass.Pow(C4 / C1, beta2)) / C1;
                n = C1 * C1 / C4 / ValueClass.Sqrt(C4 * C2 * ValueClass.Pow(C4 / C1, beta2));
                Du_over_D = ValueClass.Exp((ValueClass.Log(C2) - ValueClass.Log(C3) + beta2 * ValueClass.Log(C4) - beta2 * ValueClass.Log(C1)) * gamma3 / gamma2);
            }
            static public void Eval_rf_x_red_50_Dp_from_others()
            {
                ValueClass C1 = 9.0 / 2 * alpha1 * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * D*D*D * n * mu / Q / (rho_s - rho_f);
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f / D * Q / Consts.Pi / n / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1 * ValueClass.Pow(Du_over_D, gamma2), 1 / gamma3);
                ValueClass C4 = 1.0 / 8 * ValueClass.Sqr(Consts.Pi * D * D * n / Q) / rho_f;

                Dp = C2 / C4;
                rf = ValueClass.Pow(C2 / C3, -gamma3);
                x_red_50 = 1 / C2 * ValueClass.Sqrt(C2 * C1 * ValueClass.Pow(ValueClass.Log(1 / rf), alpha2));
            }
            static public void Eval_Du_over_D_D_Q_from_others()
            {
                ValueClass C1 = -9.0 / 2 * alpha1 * ValueClass.Pow(ValueClass.Log(1 / rf), alpha2) * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * n * mu / ValueClass.Sqr(x_red_50) / (-rho_s + rho_f);
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f / Consts.Pi / n / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1 / rf, 1 / gamma3);
                ValueClass C4 = 1.0 / 8 * Dp * ValueClass.Sqr(Consts.Pi * n) / rho_f;

                Q = 1 / ValueClass.Sqr(C1) * C4 * ValueClass.Sqrt(C4 * C2 * ValueClass.Pow(C4 / C1, beta2));
                D = ValueClass.Sqrt(C4 * C2 * ValueClass.Pow(C4 / C1, beta2)) / C1;
                //Du_over_D = ValueClass.Pow(C2, (gamma3 / gamma2)) * ValueClass.Pow(C4, ((beta2 - 1) * gamma3 / gamma2)) * ValueClass.Pow(C1, (-beta2 * gamma3 / gamma2));
                Du_over_D = ValueClass.Pow(C2, (gamma3 / gamma2)) * ValueClass.Pow(C4, (beta2 * gamma3 / gamma2)) * ValueClass.Pow(C1, (-beta2 * gamma3 / gamma2)) * ValueClass.Pow(C3, (-gamma3 / gamma2));
            }
            static public void Eval_rf_x_red_50_Q_from_others()
            {
                ValueClass C1 = -9.0 / 2 * alpha1 * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * D * D * D * n * mu / (-rho_s + rho_f);
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f / D / Consts.Pi / n / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow((gamma1 * ValueClass.Pow(Du_over_D, gamma2)), (1 / gamma3));
                ValueClass C4 = 1.0 / 8 * Dp * ValueClass.Sqr(Consts.Pi * D * D * n) / rho_f;

                rf = ValueClass.Pow(C4, (-beta2 / (2 + beta2) * gamma3)) * ValueClass.Pow(C2, (-2 / (2 + beta2) * gamma3)) * ValueClass.Pow(C3, gamma3);
                Q = ValueClass.Pow(C4 / C2, 1 / (2 + beta2));
                ValueClass Eu = C4 * ValueClass.Pow(C4 / C2, -2 / (2 + beta2));
                x_red_50 = 1 / Eu / Q * ValueClass.Sqrt(Eu * Q * C1 * ValueClass.Pow(ValueClass.Log(1 / rf), alpha2));
            }
            static public void Eval_rf_D_n_from_others()
            {
                ValueClass C1 = 9.0 / 2 * alpha1 * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * mu / ValueClass.Sqr(x_red_50) / (rho_s - rho_f) / Q;
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f * Q / Consts.Pi / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1 * ValueClass.Pow(Du_over_D, gamma2), 1 / gamma3);
                ValueClass C4 = 1.0 / 8 * Dp * ValueClass.Sqr(Consts.Pi / Q) / rho_f;

                ValueClass CC = ValueClass.Pow(C1, -gamma3 * beta2) * ValueClass.Pow(C4, gamma3 * beta2) * ValueClass.Pow(C3, -gamma3) * ValueClass.Pow(C2, gamma3);
                ValueClass PP = -alpha2 * gamma3 * beta2;

                rf = new ValueClass(0.5);
                ValueClass drf = 0.5 * rf, frf;

                while (drf.Value > 1e-9)
                {
                    frf = CC * ValueClass.Pow(ValueClass.Log(1 / rf), PP);
                    if (frf.Value < (1 / rf).Value)
                        rf = rf + drf;
                    else
                        rf = rf - drf;

                    drf = drf * 0.5;
                }

                frf = CC * ValueClass.Pow(ValueClass.Log(1 / rf), PP);
                rf.Defined = frf.Defined && Math.Abs((frf - 1/rf).Value) < 1e-6;

                Eu = C3 * ValueClass.Pow(1 / rf, 1 / gamma3);
                D = 1 / C4 * ValueClass.Sqrt(C4 * Eu) * ValueClass.Pow(Eu / C2, 1 / beta2);
                n = Eu / C1 / ValueClass.Pow(ValueClass.Log(1 / rf), alpha2) / (D * D * D);
            }
            static public void Eval_rf_D_Dp_from_others()
            {
                ValueClass C1 = -9.0 / 2 * alpha1 * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * n * mu / ValueClass.Sqr(x_red_50) / (-rho_s + rho_f) / Q;
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f * Q / Consts.Pi / n / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1 * ValueClass.Pow(Du_over_D, gamma2), 1 / gamma3);
                ValueClass C4 = 1.0 / 8 * ValueClass.Sqr(Consts.Pi * n / Q) / rho_f;

                ValueClass CC = ValueClass.Pow(C1, gamma3 / (beta2 + 3) * beta2) * ValueClass.Pow(C2, 3 * gamma3 / (beta2 + 3)) * ValueClass.Pow(C3, -gamma3);
                ValueClass PP = alpha2 * gamma3 / (beta2 + 3) * beta2;
                
                rf = new ValueClass(0.5);
                ValueClass drf = 0.5 * rf, frf;

                while (drf.Value > 1e-9)
                {
                    frf = CC * ValueClass.Pow(ValueClass.Log(1 / rf), PP);
                    if (frf.Value < (1 / rf).Value)
                        rf = rf + drf;
                    else
                        rf = rf - drf;

                    drf = drf * 0.5;
                }

                frf = CC * ValueClass.Pow(ValueClass.Log(1 / rf), PP);
                rf.Defined = frf.Defined && Math.Abs((frf - 1 / rf).Value) < 1e-6;

                Eu = C3 * ValueClass.Pow(1 / rf, 1 / gamma3);
                D = ValueClass.Pow(Eu / C2, -1 / beta2);
                Dp = Eu / C4 / (D*D*D*D);
            }
            static public void Eval_rf_D_Q_from_others()
            {
                ValueClass C1 = -9.0 / 2 * alpha1 * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * n * mu / ValueClass.Sqr(x_red_50) / (-rho_s + rho_f);
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f / Consts.Pi / n / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1 * ValueClass.Pow(Du_over_D, gamma2), 1 / gamma3);
                ValueClass C4 = 1.0 / 8 * Dp * ValueClass.Sqr(Consts.Pi * n) / rho_f;

                ValueClass CC = ValueClass.Pow(ValueClass.Pow(1 / C1 * C4, beta2) * C2 / C3, gamma3);
                ValueClass PP = -alpha2 * beta2 * gamma3;

                rf = new ValueClass(0.5);
                ValueClass drf = 0.5 * rf, frf;

                while (drf.Value > 1e-9)
                {
                    frf = CC * ValueClass.Pow(ValueClass.Log(1 / rf), PP);
                    if (frf.Value < (1 / rf).Value)
                        rf = rf + drf;
                    else
                        rf = rf - drf;

                    drf = drf * 0.5;
                }

                frf = CC * ValueClass.Pow(ValueClass.Log(1 / rf), PP);
                rf.Defined = frf.Defined && Math.Abs((frf - 1 / rf).Value) < 1e-6;

                Eu = C3 * ValueClass.Pow(1 / rf, 1 / gamma3);
                D = 1 / ValueClass.Sqrt(C4) * ValueClass.Pow(Eu, 0.5 * (beta2 + 2) / beta2) * ValueClass.Pow(C2, -1 / beta2);
                Q = C1 * ValueClass.Pow(ValueClass.Log(1 / rf), alpha2) * (D * D * D) / Eu;
            }
            static public void Eval_Du_over_D_x_red_50_n_from_others()
            {
                ValueClass C1 = 9.0 / 2 * alpha1 * ValueClass.Pow(ValueClass.Log(1 / rf), alpha2) * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * (D * D * D) * mu / Q / (rho_s - rho_f);
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f / D * Q / Consts.Pi / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1 / rf, 1 / gamma3);
                ValueClass C4 = 1.0 / 8 * Dp * ValueClass.Sqr(Consts.Pi * D * D / Q) / rho_f;

                n = ValueClass.Pow(C4 / C2, -1 / (2 + beta2));
                Eu = C4 * n * n;
                x_red_50 = ValueClass.Sqrt(C1 * n / Eu);
                Du_over_D = ValueClass.Pow(Eu / C3, gamma3 / gamma2);
            }
            static public void Eval_Du_over_D_x_red_50_Dp_from_others()
            {
                ValueClass C1 = 9.0 / 2 * alpha1 * ValueClass.Pow(ValueClass.Log(1 / rf), alpha2) * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * (D * D * D) * n * mu / Q / (rho_s - rho_f);
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f / D * Q / Consts.Pi / n / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1 / rf, 1 / gamma3);
                ValueClass C4 = 1.0 / 8 * ValueClass.Sqr(Consts.Pi * D * D * n / Q) / rho_f;

                Dp = C2 / C4;
                x_red_50 = ValueClass.Sqrt(C1 / C2);
                Du_over_D = ValueClass.Pow(C2 / C3, gamma3 / gamma2);
            }

            static public void Eval_Du_over_D_x_red_50_Q_from_others()
            {
                ValueClass C1 = -9.0 / 2 * alpha1 * ValueClass.Pow(ValueClass.Log(1 / rf), alpha2) * ValueClass.Exp(alpha3 * Cv) * Consts.Pi * (D * D * D) * n * mu / (-rho_s + rho_f);
                //C2 = 4 * beta1 * rho_f / D / Consts.Pi / n / mu * ValueClass.Exp(-beta3 * Cv);
                ValueClass C2 = beta1 * ValueClass.Pow(4 * rho_f / D / Consts.Pi / n / mu, beta2) * ValueClass.Exp(-beta3 * Cv);
                ValueClass C3 = ValueClass.Pow(gamma1 / rf, 1 / gamma3);
                ValueClass C4 = 1.0 / 8 * Dp * ValueClass.Sqr(Consts.Pi * D * D * n) / rho_f;

                Q = ValueClass.Pow(C4 / C2, 1 / (2 + beta2));
                Eu = C4 / (Q * Q);
                Du_over_D = ValueClass.Pow(Eu / C3, gamma3 / gamma2);
                x_red_50 = ValueClass.Sqrt(C1 / Eu / Q);
            }



            static public ValueClass Eval_v_From_Q_D_n()
            {
                return 4 * Q / (Consts.Pi * ValueClass.Sqr(D) * n);
            }
            static public ValueClass Eval_Eu_From_Dp_rho_v()
            {
                return 2 * Dp / (rho_f * ValueClass.Sqr(v));
            }
            static public ValueClass Eval_Re_From_Dp_rho_mu_v()
            {
                return rho_f * D * v / mu;
            }
            static public ValueClass Eval_Stk_red_From_Dp_rhos_v_mu_x_red_50()
            {
                return ValueClass.Sqr(x_red_50) * (rho_s - rho_f) * v / (18 * mu * D);
            }
            static public ValueClass Eval_E_red_t_From_xs_and_sigmas()
            {
                return 0.5 * (1 + ValueClass.Erf((ValueClass.Log(x_g) - ValueClass.Log(x_red_50)) / ValueClass.Sqrt(2 * (ValueClass.Sqr(ValueClass.Log(sigma_g)) + ValueClass.Sqr(ValueClass.Log(sigma_s))))));
            }
            static public ValueClass Eval_Et_From_E_red_t_and_rf()
            {
                return (1-rf) * E_red_t + rf;
            }
            static public ValueClass Eval_Cu_From_C_rf_Et()
            {
                return Et * C / rf;
            }
            static public ValueClass Eval_Co_From_C_rf_Cu()
            {
                return (C - rf * Cu) / (1 - rf);
            }
            static public ValueClass Eval_Cm_From_C_From_rho_rho_s(ValueClass C, ValueClass rho_f, ValueClass rho_s)
            {
                return C / (rho_f * (1 + C / rho_s * (rho_s / rho_f - 1)));
            }
            static public ValueClass Eval_Cv_From_C_From_rho_s(ValueClass C, ValueClass rho_s)
            {
                return C / rho_s;
            }

            static public ValueClass Eval_G_red_x_From_x_x_red_50_sigma_s(ValueClass x)
            {
                return 0.5 * (1 + ValueClass.Erf((ValueClass.Log(x) - ValueClass.Log(x_red_50)) / (Math.Sqrt(2) * ValueClass.Log(sigma_s))));
            }
            static public ValueClass Eval_G_From_G_red_rf(ValueClass G_red)
            {
                return (1 - rf) * G_red + rf;
            }
            static public ValueClass Eval_f_From_x_and_others(ValueClass x)
            {
                return 1 / ValueClass.Sqrt(2 * Consts.Pi) * ValueClass.Exp(-0.5 * ValueClass.Sqr((ValueClass.Log(x) - ValueClass.Log(x_g)) / ValueClass.Log(sigma_g))) / (x * ValueClass.Log(sigma_g));
            }
            static public ValueClass Eval_fo_From_x_and_others(ValueClass x)
            {
                return 1 / (1-Et) * (1-Eval_G_From_G_red_rf(Eval_G_red_x_From_x_x_red_50_sigma_s(x))) * Eval_f_From_x_and_others(x);
            }
            static public ValueClass Eval_fu_From_x_and_others(ValueClass x)
            {
                return 1 / Et * Eval_G_From_G_red_rf(Eval_G_red_x_From_x_x_red_50_sigma_s(x)) * Eval_f_From_x_and_others(x);
            }
            static public ValueClass Fo_Integrated_Function(ValueClass x)
            {
                return (1 - Eval_G_From_G_red_rf(Eval_G_red_x_From_x_x_red_50_sigma_s(x))) * Eval_f_From_x_and_others(x);
            }
            static public ValueClass Fu_Integrated_Function(ValueClass x)
            {
                return (Eval_G_From_G_red_rf(Eval_G_red_x_From_x_x_red_50_sigma_s(x))) * Eval_f_From_x_and_others(x);
            }
            static public ValueClass Eval_Fo_From_x_and_others(ValueClass x)
            {
                ValueClass.Integral.IntergatedFunction_x = Fo_Integrated_Function;
                return 1 / (1 - Et) * ValueClass.Integral.EvalIntegralValue(new ValueClass(0), x);
            }
            static public ValueClass Eval_Fu_From_x_and_others(ValueClass x)
            {
                ValueClass.Integral.IntergatedFunction_x = Fu_Integrated_Function;
                return 1 / Et * ValueClass.Integral.EvalIntegralValue(new ValueClass(0), x);
            }
            static public ValueClass Eval_F_From_x_and_others(ValueClass x)
            {
                return 0.5 * (1 + ValueClass.Erf((ValueClass.Log(x) - ValueClass.Log(x_g)) / (Math.Sqrt(2) * ValueClass.Log(sigma_g))));
            }
            static public ValueClass Eval_x_o_50_From_()
            {
                ValueClass res = new ValueClass(.5e-3), dres = res / 2;

                while (dres.Value > 1e-18)
                {
                    ValueClass Fo_res = Eval_Fo_From_x_and_others(res);
                    if (Fo_res.Value > 0.5)
                        res = res - dres;
                    else
                        res = res + dres;
                    dres = 0.5 * dres;
                }

                if (!Eval_Fo_From_x_and_others(res).Defined)
                    res.Defined = false;

                return res;
            }
            static public ValueClass Eval_x_u_50_From_()
            {
                ValueClass res = new ValueClass(.5e-3), dres = res / 2;

                while (dres.Value > 1e-18)
                {
                    ValueClass Fu_res = Eval_Fu_From_x_and_others(res);
                    if (Fu_res.Value > 0.5)
                        res = res - dres;
                    else
                        res = res + dres;
                    dres = 0.5 * dres;
                }

                if (!Eval_Fu_From_x_and_others(res).Defined)
                    res.Defined = false;

                return res;
            }
            static public ValueClass Eval_x_50_From_()
            {
                return x_g;
            }
            static public ValueClass Eval_x_From_G(ValueClass y)
            {
                ValueClass res = new ValueClass(.5e-3), dres = res / 2;

                while (dres.Value > 1e-18)
                {
                    ValueClass G_res = Eval_G_From_G_red_rf(Eval_G_red_x_From_x_x_red_50_sigma_s(res));
                    if (G_res.Value > y.Value)
                        res = res - dres;
                    else
                        res = res + dres;
                    dres = 0.5 * dres;
                }

                if (!Eval_G_From_G_red_rf(Eval_G_red_x_From_x_x_red_50_sigma_s(res)).Defined)
                    res.Defined = false;

                return res;
            }

            static public ValueClass Eval_Qu_From_()
            {
                return rf * Q;
            }

            static public ValueClass Eval_Qo_From_()
            {
                return (1-rf) * Q;
            }

            static public ValueClass Eval_Qmu_From_()
            {
                return Qu * (Cu + (rho_s - Cu) * rho_f / rho_s);
            }

            static public ValueClass Eval_Qmo_From_()
            {
                return Qo * (Co + (rho_s - Co) * rho_f / rho_s);
            }

            static public ValueClass Eval_Qs_From_()
            {
                return Q * C;
            }

            static public ValueClass Eval_Qsu_From_()
            {
                return Qu * Cu;
            }

            static public ValueClass Eval_Qso_From_()
            {
                return Qo * Co;
            }


            static public void Display_Curve_F_Fo_Fu_big(ZedGraph.ZedGraphControl zg, ZedGraph.AxisType XAxisType)
            {
                const int number_of_nodes = 100;
                ValueClass[] Vax = new ValueClass[number_of_nodes];
                ValueClass[] Vay1 = new ValueClass[number_of_nodes];
                ValueClass[] Vay2 = new ValueClass[number_of_nodes];
                ValueClass[] Vay3 = new ValueClass[number_of_nodes];
                double[] ax = new double[number_of_nodes];
                double[] ay1 = new double[number_of_nodes];
                double[] ay2 = new double[number_of_nodes];
                double[] ay3 = new double[number_of_nodes];

                zg.GraphPane.Title.IsVisible = false;
                zg.GraphPane.CurveList.Clear();

                double lastx = 5e-2, dlastx = 0.5 * lastx;
                while (dlastx > 5e-8)
                {
                    ValueClass cx = new ValueClass(lastx);
                    ValueClass cy = Eval_Fu_From_x_and_others(cx);
                    if (cy.Value >= 1.0 - 1e-2)
                        lastx -= dlastx;
                    else
                        lastx += dlastx;
                    dlastx *= 0.5;
                }
                
                zg.GraphPane.XAxis.Type = XAxisType;
                double min_x = 1e-6;
                while (min_x > 1e-12 && 
                       (Eval_Fu_From_x_and_others(new ValueClass(min_x)).Value > 1e-3 ||
                        Eval_Fo_From_x_and_others(new ValueClass(min_x)).Value > 1e-3 ||
                        Eval_F_From_x_and_others(new ValueClass(min_x)).Value > 1e-3))
                    min_x *= 0.1;
                //min_x *= 1.01;
                double coef = Math.Pow(min_x / lastx, 1.0 / (1 - number_of_nodes));
                
                for (int i = 0; i < number_of_nodes; i++)
                {
                    Vax[i] = XAxisType == ZedGraph.AxisType.Linear ? new ValueClass(lastx * i / number_of_nodes + 1e-9) : new ValueClass(Math.Pow(coef, i + 1 - number_of_nodes) * lastx);
                    Vay1[i] = Eval_Fu_From_x_and_others(Vax[i]);
                    Vay2[i] = Eval_Fo_From_x_and_others(Vax[i]);
                    Vay3[i] = Eval_F_From_x_and_others(Vax[i]);
                    ax[i] = Vax[i].Value * 1e6;
                    ay1[i] = 100 * Vay1[i].Value;
                    ay2[i] = 100 * Vay2[i].Value;
                    ay3[i] = 100 * Vay3[i].Value;
                }

                zg.GraphPane.AddCurve("F(x)", ax, ay3, System.Drawing.Color.Black , ZedGraph.SymbolType.None);
                zg.GraphPane.AddCurve("Fu(x)", ax, ay1, System.Drawing.Color.Red, ZedGraph.SymbolType.None);
                zg.GraphPane.AddCurve("Fo(x)", ax, ay2, System.Drawing.Color.Blue, ZedGraph.SymbolType.None);
                zg.GraphPane.XAxis.Title.Text = "x (" + ParameterUnitsStruct.x_red_50.Name + ")";
                zg.GraphPane.YAxis.Title.Text = "F (%)";
                zg.GraphPane.YAxis.Scale.Max = 100;
                zg.GraphPane.Y2Axis.IsVisible = false;
                if (XAxisType == ZedGraph.AxisType.Linear)
                    zg.GraphPane.XAxis.Scale.MinAuto = true;
                else
                {
                    zg.GraphPane.XAxis.Scale.MinAuto = false;
                    zg.GraphPane.XAxis.Scale.Min = min_x*1e6 - 1e-12;
                }

                zg.AxisChange();
                zg.Refresh();
            }
            static public void Display_Curve_f_fo_fu_small(ZedGraph.ZedGraphControl zg, ZedGraph.AxisType XAxisType)
            {
                const int number_on_nodes = 300;
                ValueClass[] Vax = new ValueClass[number_on_nodes];
                ValueClass[] Vay1 = new ValueClass[number_on_nodes];
                ValueClass[] Vay2 = new ValueClass[number_on_nodes];
                ValueClass[] Vay3 = new ValueClass[number_on_nodes];
                double[] ax = new double[number_on_nodes];
                double[] ay1 = new double[number_on_nodes];
                double[] ay2 = new double[number_on_nodes];
                double[] ay3 = new double[number_on_nodes];

                zg.GraphPane.Title.IsVisible = false;
                zg.GraphPane.CurveList.Clear();

                double lastx = 5e-2, dlastx = 0.5 * lastx;
                while (dlastx > 5e-8)
                {
                    ValueClass cx = new ValueClass(lastx);
                    ValueClass cy = Eval_fu_From_x_and_others(cx);
                    //if (cy.Value >= 1.0 - 1e-2)
                    if (cy.Value < 1e-1)
                        lastx -= dlastx;
                    else
                        lastx += dlastx;
                    dlastx *= 0.5;
                }

                zg.GraphPane.XAxis.Type = XAxisType;
                double min_x = Math.Min(x_o_50.Value, x_u_50.Value);
                while (min_x > 1e-12 && 
                      (Eval_fu_From_x_and_others(new ValueClass(min_x)).Value > 1 ||
                       Eval_fo_From_x_and_others(new ValueClass(min_x)).Value > 1 ||
                       Eval_f_From_x_and_others(new ValueClass(min_x)).Value > 1))
                    min_x *= 0.1;
                //min_x *= 1.01;
                double coef = Math.Pow(min_x / lastx, 1.0 / (1 - number_on_nodes));
                //double coef = Math.Pow(1e-12 / lastx, 1.0 / (1 - n));
                
                for (int i = 0; i < number_on_nodes; i++)
                {
                    Vax[i] = XAxisType == ZedGraph.AxisType.Linear ? new ValueClass(lastx * i / number_on_nodes + 1e-9) : new ValueClass(Math.Pow(coef, i + 1 - number_on_nodes) * lastx);
                    Vay1[i] = Eval_fu_From_x_and_others(Vax[i]);
                    Vay2[i] = Eval_fo_From_x_and_others(Vax[i]);
                    Vay3[i] = Eval_f_From_x_and_others(Vax[i]);
                    ax[i] = Vax[i].Value * 1e6;
                    ay1[i] = Vay1[i].Value;
                    ay2[i] = Vay2[i].Value;
                    ay3[i] = Vay3[i].Value;
                }

                zg.GraphPane.AddCurve("f(x)", ax, ay3, System.Drawing.Color.Black, ZedGraph.SymbolType.None); 
                zg.GraphPane.AddCurve("fu(x)", ax, ay1, System.Drawing.Color.Red, ZedGraph.SymbolType.None);
                zg.GraphPane.AddCurve("fo(x)", ax, ay2, System.Drawing.Color.Blue, ZedGraph.SymbolType.None);

                zg.GraphPane.XAxis.Title.Text = "x (" + ParameterUnitsStruct.x_red_50.Name + ")";
                zg.GraphPane.YAxis.Title.Text = "f (10+6/m)";
                
                zg.GraphPane.YAxis.Scale.MaxAuto = true;
                zg.GraphPane.Y2Axis.IsVisible = false;
                if (XAxisType == ZedGraph.AxisType.Linear)
                    zg.GraphPane.XAxis.Scale.MinAuto = true;
                else
                {
                    zg.GraphPane.XAxis.Scale.MinAuto = false;
                    zg.GraphPane.XAxis.Scale.Min = min_x * 1e6 - 1e-12;
                }

                zg.AxisChange();
                zg.Refresh();
            }
            static public void Display_Curve_G_G_red(ZedGraph.ZedGraphControl zg, ZedGraph.AxisType XAxisType)
            {
                const int number_on_nodes = 300;
                ValueClass[] Vax = new ValueClass[number_on_nodes];
                ValueClass[] Vay_G_red = new ValueClass[number_on_nodes];
                ValueClass[] Vay_G = new ValueClass[number_on_nodes];
                double[] ax = new double[number_on_nodes];
                double[] ay_G_red = new double[number_on_nodes];
                double[] ay_G = new double[number_on_nodes];

                zg.GraphPane.Title.IsVisible = false;
                zg.GraphPane.CurveList.Clear();

                double lastx = 5e-2, dlastx = 0.5 * lastx;
                while (dlastx > 5e-8)
                {
                    ValueClass cx = new ValueClass(lastx);
                    ValueClass cy = Eval_G_red_x_From_x_x_red_50_sigma_s(cx);
                    if (cy.Value >= 1.0 - 1e-2)
                        lastx -= dlastx;
                    else
                        lastx += dlastx;
                    dlastx *= 0.5;
                }

                zg.GraphPane.XAxis.Type = XAxisType;
                double min_x = 1e-6;
                while (min_x > 1e-12 &&
                      (Eval_G_red_x_From_x_x_red_50_sigma_s(new ValueClass(min_x)).Value > 1e-3))
                    min_x *= 0.1;
                //min_x *= 1.01;
                double coef = Math.Pow(min_x / lastx, 1.0 / (1 - number_on_nodes));
                
                for (int i = 0; i < number_on_nodes; i++)
                {
                    Vax[i] = XAxisType == ZedGraph.AxisType.Linear ? new ValueClass(lastx * i / number_on_nodes + 1e-9) : new ValueClass(Math.Pow(coef, i + 1 - number_on_nodes) * lastx);
                    Vay_G_red[i] = Eval_G_red_x_From_x_x_red_50_sigma_s(Vax[i]);
                    Vay_G[i] = Eval_G_From_G_red_rf(Vay_G_red[i]);
                    ax[i] = Vax[i].Value * 1e6;
                    ay_G_red[i] = 100 * Vay_G_red[i].Value;
                    ay_G[i] = 100 * Vay_G[i].Value;
                }

                zg.GraphPane.AddCurve("G'(x)", ax, ay_G_red, System.Drawing.Color.Red, ZedGraph.SymbolType.None);
                zg.GraphPane.AddCurve("G(x)", ax, ay_G, System.Drawing.Color.Blue, ZedGraph.SymbolType.None);
                zg.GraphPane.XAxis.Title.Text = "x (" + ParameterUnitsStruct.x_red_50.Name + ")";
                zg.GraphPane.YAxis.Title.Text = "G' and G (%)";
                zg.GraphPane.YAxis.Scale.Max = 100;
                zg.GraphPane.Y2Axis.IsVisible = false;
                if (XAxisType == ZedGraph.AxisType.Linear)
                    zg.GraphPane.XAxis.Scale.MinAuto = true;
                else
                {
                    zg.GraphPane.XAxis.Scale.MinAuto = false;
                    zg.GraphPane.XAxis.Scale.Min = min_x * 1e6 - 1e-12;
                }

                
                zg.AxisChange();
                zg.Refresh();
            }
            static public void Display_Curve_Ffx(ZedGraph.ZedGraphControl zg, ZedGraph.AxisType XAxisType)
            {
                const int number_on_nodes = 300;
                ValueClass[] Vax = new ValueClass[number_on_nodes];
                ValueClass[] Vay = new ValueClass[number_on_nodes];
                double[] ax = new double[number_on_nodes];
                double[] ay = new double[number_on_nodes];

                zg.GraphPane.Title.IsVisible = false;
                zg.GraphPane.CurveList.Clear();

                double lastx = 5e-2, dlastx = 0.5 * lastx;
                while (dlastx > 5e-8)
                {
                    ValueClass cx = new ValueClass(lastx);
                    ValueClass cy = 0.5 * (1 + ValueClass.Erf((ValueClass.Log(cx) - ValueClass.Log(x_g)) / (Math.Sqrt(2.0) * ValueClass.Log(sigma_g))));
                    ValueClass cy2 = 1.0 / ValueClass.Sqrt(2 * Consts.Pi) / ValueClass.Log(sigma_g) * ValueClass.Exp(-0.5 * ValueClass.Sqr((ValueClass.Log(cx) - ValueClass.Log(x_g)) / ValueClass.Log(sigma_g))) / cx;
                    if (cy.Value >= 1.0 - 1e-2 && cy2.Value < 1e-1)
                        lastx -= dlastx;
                    else
                        lastx += dlastx;
                    dlastx *= 0.5;
                }

                zg.GraphPane.XAxis.Type = XAxisType;
                double min_x = 1e-6;
                while (min_x > 1e-12)
                {
                    double Fval = (100 * 0.5 * (1 + ValueClass.Erf((ValueClass.Log(new ValueClass(min_x)) - ValueClass.Log(x_g)) / (Math.Sqrt(2.0) * ValueClass.Log(sigma_g))))).Value;
                    double fval = (1.0 / ValueClass.Sqrt(2 * Consts.Pi) / ValueClass.Log(sigma_g) * ValueClass.Exp(-0.5 * ValueClass.Sqr((ValueClass.Log(new ValueClass(min_x)) - ValueClass.Log(x_g)) / ValueClass.Log(sigma_g))) / new ValueClass(min_x)).Value;
                    if (Fval < 1e-3 && fval < 1)
                        break;
                    min_x *= 0.1;
                }
                min_x *= 1.01;
                double coef = Math.Pow(min_x / lastx, 1.0 / (1 - number_on_nodes));
                
                for (int i = 0; i < number_on_nodes; i++)
                {
                    Vax[i] = XAxisType == ZedGraph.AxisType.Linear ? new ValueClass(lastx * i / number_on_nodes + 1e-9) : new ValueClass(Math.Pow(coef, i + 1 - number_on_nodes) * lastx);
                    Vay[i] = 100 * 0.5 * (1 + ValueClass.Erf((ValueClass.Log(Vax[i]) - ValueClass.Log(x_g)) / (Math.Sqrt(2.0) * ValueClass.Log(sigma_g))));
                    ax[i] = Vax[i].Value * 1e6;
                    ay[i] = Vay[i].Value;
                }

                zg.GraphPane.AddCurve("F(x)", ax, ay, System.Drawing.Color.Red, ZedGraph.SymbolType.None);
                zg.GraphPane.YAxis.Scale.Max = 100;

                for (int i = 0; i < number_on_nodes; i++)
                {
                    Vax[i] = XAxisType == ZedGraph.AxisType.Linear ? new ValueClass(lastx * i / number_on_nodes + 1e-9) : new ValueClass(Math.Pow(coef, i + 1 - number_on_nodes) * lastx);
                    Vay[i] = 1.0 / ValueClass.Sqrt(2 * Consts.Pi) / ValueClass.Log(sigma_g) * ValueClass.Exp(-0.5 * ValueClass.Sqr((ValueClass.Log(Vax[i]) - ValueClass.Log(x_g)) / ValueClass.Log(sigma_g))) / Vax[i];
                    ax[i] = Vax[i].Value * 1e6;
                    ay[i] = Vay[i].Value;
                }

                zg.GraphPane.AddCurve("f(x)", ax, ay, System.Drawing.Color.Blue, ZedGraph.SymbolType.None);
                zg.GraphPane.Y2Axis.Scale.MaxAuto = true;
                zg.GraphPane.Y2Axis.IsVisible = true;
                zg.GraphPane.CurveList[1].IsY2Axis = true;

                zg.GraphPane.XAxis.Title.Text = "x (" + ParameterUnitsStruct.x_red_50.Name + ")";
                zg.GraphPane.YAxis.Title.Text = "F (%)";
                zg.GraphPane.Y2Axis.Title.Text = "f (10+6/m)";
                
                //zg.GraphPane.Fill = new ZedGraph.Fill(System.Drawing.Color.White, System.Drawing.Color.Yellow);
                //zg.GraphPane.Chart.Fill = new ZedGraph.Fill(System.Drawing.Color.Yellow, System.Drawing.Color.Cyan);

                zg.AxisChange();
                zg.Refresh();
            }
            static public void Display_Curve_Fx(ZedGraph.ZedGraphControl zg, ZedGraph.AxisType XAxisType)
            {
                const int number_on_nodes = 300;
                ValueClass[] Vax = new ValueClass[number_on_nodes];
                ValueClass[] Vay = new ValueClass[number_on_nodes];
                double[] ax = new double[number_on_nodes];
                double[] ay = new double[number_on_nodes];

                zg.GraphPane.Title.IsVisible = false;
                zg.GraphPane.CurveList.Clear();

                double lastx = 5e-2, dlastx = 0.5 * lastx;
                while (dlastx > 5e-8)
                {
                    ValueClass cx = new ValueClass(lastx);
                    ValueClass cy = 0.5 * (1 + ValueClass.Erf((ValueClass.Log(cx) - ValueClass.Log(x_g)) / (Math.Sqrt(2.0) * ValueClass.Log(sigma_g))));
                    if (cy.Value >= 1.0 - 1e-2)
                        lastx -= dlastx;
                    else
                        lastx += dlastx;
                    dlastx *= 0.5;
                }

                zg.GraphPane.XAxis.Type = XAxisType;
                double min_x = 1e-6;
                while (min_x > 1e-12)
                {
                    double Fval = (100 * 0.5 * (1 + ValueClass.Erf((ValueClass.Log(new ValueClass(min_x)) - ValueClass.Log(x_g)) / (Math.Sqrt(2.0) * ValueClass.Log(sigma_g))))).Value;
                    if (Fval < 1e-3)
                        break;
                    min_x *= 0.1;
                }
                min_x *= 1.01;
                double coef = Math.Pow(min_x / lastx, 1.0 / (1 - number_on_nodes));
                
                for (int i = 0; i < number_on_nodes; i++)
                {
                    Vax[i] = XAxisType == ZedGraph.AxisType.Linear ? new ValueClass(lastx * i / number_on_nodes + 1e-9) : new ValueClass(Math.Pow(coef, i + 1 - number_on_nodes) * lastx);
                    Vay[i] = 100 * 0.5 * (1 + ValueClass.Erf((ValueClass.Log(Vax[i]) - ValueClass.Log(x_g)) / (Math.Sqrt(2.0) * ValueClass.Log(sigma_g))));
                    ax[i] = Vax[i].Value * 1e6;
                    ay[i] = Vay[i].Value;
                }

                zg.GraphPane.YAxis.Scale.Max = 100;
                zg.GraphPane.Y2Axis.IsVisible = false;
                zg.GraphPane.AddCurve("F(x)", ax, ay, System.Drawing.Color.Red, ZedGraph.SymbolType.None);
                zg.GraphPane.XAxis.Title.Text = "x (" + ParameterUnitsStruct.x_red_50.Name + ")";
                zg.GraphPane.YAxis.Title.Text = "F (%)";
                zg.AxisChange();
                zg.Refresh();                
            }
            static public void Display_Curve_fx(ZedGraph.ZedGraphControl zg, ZedGraph.AxisType XAxisType)
            {                
                const int number_on_nodes = 300;
                ValueClass[] Vax = new ValueClass[number_on_nodes];
                ValueClass[] Vay = new ValueClass[number_on_nodes];
                double[] ax = new double[number_on_nodes];
                double[] ay = new double[number_on_nodes];

                zg.GraphPane.Title.IsVisible = false;
                zg.GraphPane.CurveList.Clear();

                double lastx = 5e-2, dlastx = 0.5 * lastx;
                while (dlastx > 5e-8)
                {
                    ValueClass cx = new ValueClass(lastx);
                    //ValueClass cy = 0.5 * (1 + ValueClass.Erf((ValueClass.Log(cx) - ValueClass.Log(x_g)) / (Math.Sqrt(2.0) * ValueClass.Log(sigma_g))));
                    ValueClass cy = 1.0 / ValueClass.Sqrt(2 * Consts.Pi) / ValueClass.Log(sigma_g) * ValueClass.Exp(-0.5 * ValueClass.Sqr((ValueClass.Log(cx) - ValueClass.Log(x_g)) / ValueClass.Log(sigma_g))) / cx;
                    
                    //if (cy.Value >= 1.0 - 1e-2)
                    if (cy.Value < 1e-1)
                        lastx -= dlastx;
                    else
                        lastx += dlastx;
                    dlastx *= 0.5;
                }

                zg.GraphPane.XAxis.Type = XAxisType;
                double min_x = 1e-6;
                while (min_x > 1e-12)
                {
                    double fval = (1.0 / ValueClass.Sqrt(2 * Consts.Pi) / ValueClass.Log(sigma_g) * ValueClass.Exp(-0.5 * ValueClass.Sqr((ValueClass.Log(new ValueClass(min_x)) - ValueClass.Log(x_g)) / ValueClass.Log(sigma_g))) / new ValueClass(min_x)).Value;
                    if (fval < 1)
                        break;
                    min_x *= 0.1;
                }
                min_x *= 1.01;
                double coef = Math.Pow(min_x / lastx, 1.0 / (1 - number_on_nodes));
                
                for (int i = 0; i < number_on_nodes; i++)
                {
                    Vax[i] = XAxisType == ZedGraph.AxisType.Linear ? new ValueClass(lastx * i / number_on_nodes + 1e-9) : new ValueClass(Math.Pow(coef, i + 1 - number_on_nodes) * lastx);
                    Vay[i] = 1.0 / ValueClass.Sqrt(2 * Consts.Pi) / ValueClass.Log(sigma_g) * ValueClass.Exp(-0.5 * ValueClass.Sqr((ValueClass.Log(Vax[i]) - ValueClass.Log(x_g)) / ValueClass.Log(sigma_g))) / Vax[i];
                    ax[i] = Vax[i].Value * 1e6;
                    ay[i] = Vay[i].Value;
                }

                zg.GraphPane.YAxis.Scale.MaxAuto = true;
                zg.GraphPane.Y2Axis.IsVisible = false;
                zg.GraphPane.AddCurve("f(x)", ax, ay, System.Drawing.Color.Blue, ZedGraph.SymbolType.None);
                zg.GraphPane.XAxis.Title.Text = "x (" + ParameterUnitsStruct.x_red_50.Name + ")";
                zg.GraphPane.YAxis.Title.Text = "f (10+6/m)";
                zg.AxisChange();
                zg.Refresh();
            }
        }
        static public class ParameterInputInfoStruct
        {
            static public bool Is_rho_s_Inputed, Is_rho_sus_Inputed;
            static public bool Is_Cm_Inputed, Is_Cv_Inputed, Is_C_Inputed;
            static public bool Is_Q_Inputed, Is_Qm_Inputed, Is_Qs_Inputed;
            static public bool Is_rf_Inputed, Is_Du_over_D_Inputed;
            static public bool Is_n_Inputed, Is_Dp_Inputed;
            static public bool Is_x_red_50_Inputed, Is_D_Inputed;
            static public bool Is_n_Checked, Is_Dp_Checked, Is_Q_Checked;
        }
        static public class Processors
        {
            static private void ReadInput(ref ValueClass val, UnitStruct units, int index)
            {
                val = ValueClass.objectToValue(Program.Form_Main.dataGrid_Inputs1.Rows[index].Cells["Value"].Value) * units.Coefficient;
                Program.Form_Main.dataGrid_Inputs1.Rows[index].Cells["Value"].Style.ForeColor = Program.Colors.InputColor;
            }
            static private void ReadInput(ref ValueClass val, UnitStruct units, System.Windows.Forms.DataGridViewCell cell)
            {
                val = ValueClass.objectToValue(cell.Value) * units.Coefficient;
                cell.Style.ForeColor = Program.Colors.InputColor;
            }
            static private void WriteOutput(ref ValueClass val, UnitStruct units, int index)
            {
                object ob = ValueClass.ValueToString(val / units.Coefficient);
                Program.Form_Main.dataGrid_Inputs1.Rows[index].Cells["Value"].Value = ob;
                Program.Form_Main.dataGrid_Inputs1.Rows[index].Cells["Value"].Style.ForeColor = Program.Colors.CalculatedColor;
            }
            static private void WriteOutput(ref ValueClass val, UnitStruct units, System.Windows.Forms.DataGridViewCell cell)
            {
                object ob = ValueClass.ValueToString(val / units.Coefficient);
                cell.Value = ob;
                cell.Style.ForeColor = Program.Colors.CalculatedColor;
            }
            static public  void WriteResult(System.Windows.Forms.DataGridViewRow row, string ParameterName, UnitStruct units, ValueClass val)
            {
                row.Height = 18;
                row.Cells[0].Value = ParameterName;
                row.Cells[1].Value = units.Name;
                row.Cells[2].Value = ValueClass.ValueToString(val / units.Coefficient);
                row.Cells[2].Style.ForeColor = Program.Colors.CalculatedColor;
            }
            static public  void WriteResult(System.Windows.Forms.DataGridViewRow row, string ParameterName, UnitStruct units, ValueClass val_f, ValueClass val_u, ValueClass val_o)
            {
                row.Height = 18;
                row.Cells[0].Value = ParameterName;
                row.Cells[1].Value = units.Name;

                row.Cells[2].Value = ValueClass.ValueToString(val_f / units.Coefficient);
                row.Cells[2].Style.ForeColor = Program.Colors.CalculatedColor;

                row.Cells[3].Value = ValueClass.ValueToString(val_u / units.Coefficient);
                row.Cells[3].Style.ForeColor = Program.Colors.CalculatedColor;

                row.Cells[4].Value = ValueClass.ValueToString(val_o / units.Coefficient);
                row.Cells[4].Style.ForeColor = Program.Colors.CalculatedColor;
            }
            static public void ReadInputs()
            {
                ReadInput(ref ParameterValuesStruct.mu, ParameterUnitsStruct.mu, Program.InputParametersIndexes.mu);

                ReadInput(ref ParameterValuesStruct.rho_f, ParameterUnitsStruct.rho_f, Program.InputParametersIndexes.rho_f);

                if (ParameterInputInfoStruct.Is_rho_s_Inputed)
                    ReadInput(ref ParameterValuesStruct.rho_s, ParameterUnitsStruct.rho_s, Program.InputParametersIndexes.rho_s);
                if (ParameterInputInfoStruct.Is_rho_sus_Inputed)
                    ReadInput(ref ParameterValuesStruct.rho_sus, ParameterUnitsStruct.rho_sus, Program.InputParametersIndexes.rho_sus);

                if (ParameterInputInfoStruct.Is_Cm_Inputed)
                    ReadInput(ref ParameterValuesStruct.Cm, ParameterUnitsStruct.Cm, Program.InputParametersIndexes.Cm);
                if (ParameterInputInfoStruct.Is_Cv_Inputed)
                    ReadInput(ref ParameterValuesStruct.Cv, ParameterUnitsStruct.Cv, Program.InputParametersIndexes.Cv);
                if (ParameterInputInfoStruct.Is_C_Inputed)
                    ReadInput(ref ParameterValuesStruct.C, ParameterUnitsStruct.C, Program.InputParametersIndexes.C);

                ReadInput(ref ParameterValuesStruct.x_g, ParameterUnitsStruct.x_g, Program.InputParametersIndexes.x_g);
                ReadInput(ref ParameterValuesStruct.sigma_g, ParameterUnitsStruct.sigma_g, Program.InputParametersIndexes.sigma_g);

                ReadInput(ref ParameterValuesStruct.sigma_s, ParameterUnitsStruct.sigma_s, Program.InputParametersIndexes.sigma_s);

                if (ParameterInputInfoStruct.Is_rf_Inputed)
                    ReadInput(ref ParameterValuesStruct.rf, ParameterUnitsStruct.rf, Program.InputParametersIndexes.rf);
                if (ParameterInputInfoStruct.Is_Du_over_D_Inputed)
                    ReadInput(ref ParameterValuesStruct.Du_over_D, ParameterUnitsStruct.Du_over_D, Program.InputParametersIndexes.Du_over_D);

                if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                    ReadInput(ref ParameterValuesStruct.x_red_50, ParameterUnitsStruct.x_red_50, Program.InputParametersIndexes.x_red_50);
                if (ParameterInputInfoStruct.Is_D_Inputed)
                    ReadInput(ref ParameterValuesStruct.D, ParameterUnitsStruct.D, Program.InputParametersIndexes.D);

                ParameterInputInfoStruct.Is_n_Checked = Program.Form_Main.radioButton_Calculated_n.Checked;
                ParameterInputInfoStruct.Is_Dp_Checked = Program.Form_Main.radioButton_Calculated_Dp.Checked;
                ParameterInputInfoStruct.Is_Q_Checked = Program.Form_Main.radioButton_Calculated_Q.Checked;

                if (ParameterInputInfoStruct.Is_n_Inputed)
                    ReadInput(ref ParameterValuesStruct.n, ParameterUnitsStruct.n, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.n].Cells[2]);
                if (ParameterInputInfoStruct.Is_Dp_Inputed)
                    ReadInput(ref ParameterValuesStruct.Dp, ParameterUnitsStruct.Dp, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Dp].Cells[2]);

                if (ParameterInputInfoStruct.Is_Q_Inputed)
                    ReadInput(ref ParameterValuesStruct.Q, ParameterUnitsStruct.Q, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Q].Cells[2]);
                if (ParameterInputInfoStruct.Is_Qm_Inputed)
                    ReadInput(ref ParameterValuesStruct.Qm, ParameterUnitsStruct.Qm, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qm].Cells[2]);
                if (ParameterInputInfoStruct.Is_Qs_Inputed)
                    ReadInput(ref ParameterValuesStruct.Qs, ParameterUnitsStruct.Qs, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qs].Cells[2]);

                ReadInput(ref ParameterValuesStruct.alpha1, ParameterUnitsStruct.alpha1, Program.Form_AddParams.dataGridView1.Rows[0].Cells[0]);
                ReadInput(ref ParameterValuesStruct.alpha2, ParameterUnitsStruct.alpha2, Program.Form_AddParams.dataGridView1.Rows[0].Cells[1]);
                ReadInput(ref ParameterValuesStruct.alpha3, ParameterUnitsStruct.alpha3, Program.Form_AddParams.dataGridView1.Rows[0].Cells[2]);

                ReadInput(ref ParameterValuesStruct.beta1, ParameterUnitsStruct.beta1, Program.Form_AddParams.dataGridView1.Rows[1].Cells[0]);
                ReadInput(ref ParameterValuesStruct.beta2, ParameterUnitsStruct.beta2, Program.Form_AddParams.dataGridView1.Rows[1].Cells[1]);
                ReadInput(ref ParameterValuesStruct.beta3, ParameterUnitsStruct.beta3, Program.Form_AddParams.dataGridView1.Rows[1].Cells[2]);

                ReadInput(ref ParameterValuesStruct.gamma1, ParameterUnitsStruct.gamma1, Program.Form_AddParams.dataGridView1.Rows[2].Cells[0]);
                ReadInput(ref ParameterValuesStruct.gamma2, ParameterUnitsStruct.gamma2, Program.Form_AddParams.dataGridView1.Rows[2].Cells[1]);
                ReadInput(ref ParameterValuesStruct.gamma3, ParameterUnitsStruct.gamma3, Program.Form_AddParams.dataGridView1.Rows[2].Cells[2]);

                ReadInput(ref ParameterValuesStruct.L_over_D, ParameterUnitsStruct.L_over_D, Program.Form_AddParams.dataGridView_Machine_Coefficients.Rows[0].Cells[Program.InputParametersIndexes.L_over_D]);
                ReadInput(ref ParameterValuesStruct.l_over_D, ParameterUnitsStruct.l_over_D, Program.Form_AddParams.dataGridView_Machine_Coefficients.Rows[0].Cells[Program.InputParametersIndexes.l_over_D]);
                ReadInput(ref ParameterValuesStruct.Di_over_D, ParameterUnitsStruct.Di_over_D, Program.Form_AddParams.dataGridView_Machine_Coefficients.Rows[0].Cells[Program.InputParametersIndexes.Di_over_D]);
                ReadInput(ref ParameterValuesStruct.Do_over_D, ParameterUnitsStruct.Do_over_D, Program.Form_AddParams.dataGridView_Machine_Coefficients.Rows[0].Cells[Program.InputParametersIndexes.Do_over_D]);
            }

            static public void WriteOutputs()
            {
                if (!ParameterInputInfoStruct.Is_rho_s_Inputed)
                    WriteOutput(ref ParameterValuesStruct.rho_s, ParameterUnitsStruct.rho_s, Program.InputParametersIndexes.rho_s);
                if (!ParameterInputInfoStruct.Is_rho_sus_Inputed)
                    WriteOutput(ref ParameterValuesStruct.rho_sus, ParameterUnitsStruct.rho_sus, Program.InputParametersIndexes.rho_sus);

                if (!ParameterInputInfoStruct.Is_Cm_Inputed)
                    WriteOutput(ref ParameterValuesStruct.Cm, ParameterUnitsStruct.Cm, Program.InputParametersIndexes.Cm);
                if (!ParameterInputInfoStruct.Is_Cv_Inputed)
                    WriteOutput(ref ParameterValuesStruct.Cv, ParameterUnitsStruct.Cv, Program.InputParametersIndexes.Cv);
                if (!ParameterInputInfoStruct.Is_C_Inputed)
                    WriteOutput(ref ParameterValuesStruct.C, ParameterUnitsStruct.C, Program.InputParametersIndexes.C);

                if (!ParameterInputInfoStruct.Is_Q_Inputed)
                    WriteOutput(ref ParameterValuesStruct.Q, ParameterUnitsStruct.Q, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Q].Cells[2]);
                if (!ParameterInputInfoStruct.Is_Qm_Inputed)
                    WriteOutput(ref ParameterValuesStruct.Qm, ParameterUnitsStruct.Qm, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qm].Cells[2]);
                if (!ParameterInputInfoStruct.Is_Qs_Inputed)
                    WriteOutput(ref ParameterValuesStruct.Qs, ParameterUnitsStruct.Qs, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qs].Cells[2]);

                if (!ParameterInputInfoStruct.Is_rf_Inputed)
                    WriteOutput(ref ParameterValuesStruct.rf, ParameterUnitsStruct.rf, Program.InputParametersIndexes.rf);
                if (!ParameterInputInfoStruct.Is_Du_over_D_Inputed)
                    WriteOutput(ref ParameterValuesStruct.Du_over_D, ParameterUnitsStruct.Du_over_D, Program.InputParametersIndexes.Du_over_D);

                if (!ParameterInputInfoStruct.Is_n_Inputed)
                    //WriteOutput(ref ParameterValuesStruct.n, ParameterUnitsStruct.n, Program.InputParametersIndexes.n);
                    WriteOutput(ref ParameterValuesStruct.n, ParameterUnitsStruct.n, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.n].Cells[2]);
                if (!ParameterInputInfoStruct.Is_Dp_Inputed)
                    //WriteOutput(ref ParameterValuesStruct.Dp, ParameterUnitsStruct.Dp, Program.InputParametersIndexes.Dp);
                    WriteOutput(ref ParameterValuesStruct.Dp, ParameterUnitsStruct.Dp, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Dp].Cells[2]);

                if (!ParameterInputInfoStruct.Is_x_red_50_Inputed)
                    WriteOutput(ref ParameterValuesStruct.x_red_50, ParameterUnitsStruct.x_red_50, Program.InputParametersIndexes.x_red_50);
                if (!ParameterInputInfoStruct.Is_D_Inputed)
                    WriteOutput(ref ParameterValuesStruct.D, ParameterUnitsStruct.D, Program.InputParametersIndexes.D);
            }
            static public void WriteAllData()
            {
                WriteOutput(ref ParameterValuesStruct.mu, ParameterUnitsStruct.mu, Program.InputParametersIndexes.mu);
                
                WriteOutput(ref ParameterValuesStruct.rho_f, ParameterUnitsStruct.rho_f, Program.InputParametersIndexes.rho_f);
                WriteOutput(ref ParameterValuesStruct.rho_s, ParameterUnitsStruct.rho_s, Program.InputParametersIndexes.rho_s);
                WriteOutput(ref ParameterValuesStruct.rho_sus, ParameterUnitsStruct.rho_sus, Program.InputParametersIndexes.rho_sus);
                
                WriteOutput(ref ParameterValuesStruct.Cm, ParameterUnitsStruct.Cm, Program.InputParametersIndexes.Cm);
                WriteOutput(ref ParameterValuesStruct.Cv, ParameterUnitsStruct.Cv, Program.InputParametersIndexes.Cv);
                WriteOutput(ref ParameterValuesStruct.C, ParameterUnitsStruct.C, Program.InputParametersIndexes.C);

                WriteOutput(ref ParameterValuesStruct.x_g, ParameterUnitsStruct.x_g, Program.InputParametersIndexes.x_g);
                WriteOutput(ref ParameterValuesStruct.sigma_g, ParameterUnitsStruct.sigma_g, Program.InputParametersIndexes.sigma_g);
                WriteOutput(ref ParameterValuesStruct.sigma_s, ParameterUnitsStruct.sigma_s, Program.InputParametersIndexes.sigma_s);

                WriteOutput(ref ParameterValuesStruct.rf, ParameterUnitsStruct.rf, Program.InputParametersIndexes.rf);
                WriteOutput(ref ParameterValuesStruct.Du_over_D, ParameterUnitsStruct.Du_over_D, Program.InputParametersIndexes.Du_over_D);

                WriteOutput(ref ParameterValuesStruct.n, ParameterUnitsStruct.n, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.n].Cells[2]);
                WriteOutput(ref ParameterValuesStruct.Dp, ParameterUnitsStruct.Dp, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Dp].Cells[2]);

                //Program.Form_Main.radioButton_Calculated_n.Checked = ParameterInputInfoStruct.Is_n_Checked;
                //Program.Form_Main.radioButton_Calculated_Dp.Checked = ParameterInputInfoStruct.Is_Dp_Checked;
                //Program.Form_Main.radioButton_Calculated_Q.Checked = ParameterInputInfoStruct.Is_Q_Checked;

                WriteOutput(ref ParameterValuesStruct.Q, ParameterUnitsStruct.Q, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Q].Cells[2]);
                WriteOutput(ref ParameterValuesStruct.Qm, ParameterUnitsStruct.Qm, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qm].Cells[2]);
                WriteOutput(ref ParameterValuesStruct.Qs, ParameterUnitsStruct.Qs, Program.Form_Main.dataGrid_Inputs2.Rows[Program.InputParametersIndexes.Qs].Cells[2]);

                WriteOutput(ref ParameterValuesStruct.x_red_50, ParameterUnitsStruct.x_red_50, Program.InputParametersIndexes.x_red_50);
                WriteOutput(ref ParameterValuesStruct.D, ParameterUnitsStruct.D, Program.InputParametersIndexes.D);

                WriteOutput(ref ParameterValuesStruct.alpha1, ParameterUnitsStruct.alpha1, Program.Form_AddParams.dataGridView1.Rows[0].Cells[0]);
                WriteOutput(ref ParameterValuesStruct.alpha2, ParameterUnitsStruct.alpha2, Program.Form_AddParams.dataGridView1.Rows[0].Cells[1]);
                WriteOutput(ref ParameterValuesStruct.alpha3, ParameterUnitsStruct.alpha3, Program.Form_AddParams.dataGridView1.Rows[0].Cells[2]);

                WriteOutput(ref ParameterValuesStruct.beta1, ParameterUnitsStruct.beta1, Program.Form_AddParams.dataGridView1.Rows[1].Cells[0]);
                WriteOutput(ref ParameterValuesStruct.beta2, ParameterUnitsStruct.beta2, Program.Form_AddParams.dataGridView1.Rows[1].Cells[1]);
                WriteOutput(ref ParameterValuesStruct.beta3, ParameterUnitsStruct.beta3, Program.Form_AddParams.dataGridView1.Rows[1].Cells[2]);

                WriteOutput(ref ParameterValuesStruct.gamma1, ParameterUnitsStruct.gamma1, Program.Form_AddParams.dataGridView1.Rows[2].Cells[0]);
                WriteOutput(ref ParameterValuesStruct.gamma2, ParameterUnitsStruct.gamma2, Program.Form_AddParams.dataGridView1.Rows[2].Cells[1]);
                WriteOutput(ref ParameterValuesStruct.gamma3, ParameterUnitsStruct.gamma3, Program.Form_AddParams.dataGridView1.Rows[2].Cells[2]);

                WriteOutput(ref ParameterValuesStruct.L_over_D, ParameterUnitsStruct.L_over_D, Program.Form_AddParams.dataGridView_Machine_Coefficients.Rows[0].Cells[Program.InputParametersIndexes.L_over_D]);
                WriteOutput(ref ParameterValuesStruct.l_over_D, ParameterUnitsStruct.l_over_D, Program.Form_AddParams.dataGridView_Machine_Coefficients.Rows[0].Cells[Program.InputParametersIndexes.l_over_D]);
                WriteOutput(ref ParameterValuesStruct.Di_over_D, ParameterUnitsStruct.Di_over_D, Program.Form_AddParams.dataGridView_Machine_Coefficients.Rows[0].Cells[Program.InputParametersIndexes.Di_over_D]);
                WriteOutput(ref ParameterValuesStruct.Do_over_D, ParameterUnitsStruct.Do_over_D, Program.Form_AddParams.dataGridView_Machine_Coefficients.Rows[0].Cells[Program.InputParametersIndexes.Do_over_D]);
            }

            static public void WriteResults()
            {
            
        // dataGrid_Results1
                Program.Form_Main.dataGridView_Results1.RowCount = 8;
                WriteResult(Program.Form_Main.dataGridView_Results1.Rows[0], "Stk'", ParameterUnitsStruct.Stk_red, ParameterValuesStruct.Stk_red);
                WriteResult(Program.Form_Main.dataGridView_Results1.Rows[1], "Eu", ParameterUnitsStruct.Eu, ParameterValuesStruct.Eu);
                WriteResult(Program.Form_Main.dataGridView_Results1.Rows[2], "Re", ParameterUnitsStruct.Re, ParameterValuesStruct.Re);
                Program.Form_Main.MakeDelimiter(Program.Form_Main.dataGridView_Results1.Rows[3]);
                WriteResult(Program.Form_Main.dataGridView_Results1.Rows[4], "v", ParameterUnitsStruct.v, ParameterValuesStruct.v);
                Program.Form_Main.MakeDelimiter(Program.Form_Main.dataGridView_Results1.Rows[5]);
                WriteResult(Program.Form_Main.dataGridView_Results1.Rows[6], "Et'", ParameterUnitsStruct.E_red_t, ParameterValuesStruct.E_red_t);
                WriteResult(Program.Form_Main.dataGridView_Results1.Rows[7], "Et", ParameterUnitsStruct.Et, ParameterValuesStruct.Et);

        // dataGrid_Results3
                Program.Form_Main.dataGridView_Results3.RowCount = 7;
                WriteResult(Program.Form_Main.dataGridView_Results3.Rows[0], "n", ParameterUnitsStruct.n, ParameterValuesStruct.n);
                WriteResult(Program.Form_Main.dataGridView_Results3.Rows[1], "D", ParameterUnitsStruct.D, ParameterValuesStruct.D);
                WriteResult(Program.Form_Main.dataGridView_Results3.Rows[2], "L", ParameterUnitsStruct.L, ParameterValuesStruct.L);
                WriteResult(Program.Form_Main.dataGridView_Results3.Rows[3], "l", ParameterUnitsStruct.l, ParameterValuesStruct.l);
                WriteResult(Program.Form_Main.dataGridView_Results3.Rows[4], "Di", ParameterUnitsStruct.Di, ParameterValuesStruct.Di);
                WriteResult(Program.Form_Main.dataGridView_Results3.Rows[5], "Do", ParameterUnitsStruct.Do, ParameterValuesStruct.Do);
                WriteResult(Program.Form_Main.dataGridView_Results3.Rows[6], "Du", ParameterUnitsStruct.Du, ParameterValuesStruct.Du);
                //Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.Stk_red], "Stk'", Parameters.ParameterUnitsStruct.Stk_red);
                //Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.Eu], "Eu", Parameters.ParameterUnitsStruct.Eu);
                //Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.Re], "Re", Parameters.ParameterUnitsStruct.Re);
                //MakeDelimiter(dataGridView_Results1.Rows[3]);
                //Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.E_red_t], "E'_t", Parameters.ParameterUnitsStruct.E_red_t);
                //Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.Et], "Et", Parameters.ParameterUnitsStruct.Et);


                Program.Form_Main.dataGridView_Results2.RowCount = 9;
                WriteResult(Program.Form_Main.dataGridView_Results2.Rows[0], "Q", ParameterUnitsStruct.Q, ParameterValuesStruct.Q, ParameterValuesStruct.Qu, ParameterValuesStruct.Qo);
                WriteResult(Program.Form_Main.dataGridView_Results2.Rows[1], "Qm", ParameterUnitsStruct.Qm, ParameterValuesStruct.Qm, ParameterValuesStruct.Qmu, ParameterValuesStruct.Qmo);
                WriteResult(Program.Form_Main.dataGridView_Results2.Rows[2], "Qs", ParameterUnitsStruct.Qs, ParameterValuesStruct.Qs, ParameterValuesStruct.Qsu, ParameterValuesStruct.Qso);
                Program.Form_Main.MakeDelimiter(Program.Form_Main.dataGridView_Results2.Rows[3]);
                WriteResult(Program.Form_Main.dataGridView_Results2.Rows[4], "x_50", ParameterUnitsStruct.x_red_50, ParameterValuesStruct.x_50, ParameterValuesStruct.x_u_50, ParameterValuesStruct.x_o_50);
                Program.Form_Main.MakeDelimiter(Program.Form_Main.dataGridView_Results2.Rows[5]);
                WriteResult(Program.Form_Main.dataGridView_Results2.Rows[6], "Cm", ParameterUnitsStruct.Cm, ParameterValuesStruct.Cm, ParameterValuesStruct.Cmu, ParameterValuesStruct.Cmo);
                WriteResult(Program.Form_Main.dataGridView_Results2.Rows[7], "Cv", ParameterUnitsStruct.Cv, ParameterValuesStruct.Cv, ParameterValuesStruct.Cvu, ParameterValuesStruct.Cvo);
                WriteResult(Program.Form_Main.dataGridView_Results2.Rows[8], "C", ParameterUnitsStruct.C, ParameterValuesStruct.C, ParameterValuesStruct.Cu, ParameterValuesStruct.Co);
                /*
                 * MakeDelimiter(dataGridView_Results1.Rows[6]);
                Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.x_o_50], "x_o_50", Parameters.ParameterUnitsStruct.x_o_50);
                Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.x_u_50], "x_u_50", Parameters.ParameterUnitsStruct.x_u_50);
                MakeDelimiter(dataGridView_Results1.Rows[9]);
                dataGridView_Results1.Rows[10].Height = 16;
                dataGridView_Results1.Rows[10].Cells[2].Style.BackColor = Color.Pink;
                dataGridView_Results1.Rows[10].Cells[3].Style.BackColor = Color.Pink;
                dataGridView_Results1.Rows[10].Cells[2].Value = "overflow";
                dataGridView_Results1.Rows[10].Cells[3].Value = "underflow";
                Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.Cmou], "Cm", Parameters.ParameterUnitsStruct.Cm);
                Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.Cvou], "Cv", Parameters.ParameterUnitsStruct.Cv);
                Fill_DataGridView_Row(dataGridView_Results1.Rows[Program.ResultParametersIndexes.Cou], "C", Parameters.ParameterUnitsStruct.C);
                */
                                // dataGrid_Results1
                //dataGridView_Results2.RowCount = 8;

                /*
                WriteOutput(ref ParameterValuesStruct.Stk_red, ParameterUnitsStruct.Stk_red, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Stk_red].Cells[2]);
                WriteOutput(ref ParameterValuesStruct.Eu, ParameterUnitsStruct.Eu, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Eu].Cells[2]);
                WriteOutput(ref ParameterValuesStruct.Re, ParameterUnitsStruct.Re, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Re].Cells[2]);

                WriteOutput(ref ParameterValuesStruct.E_red_t, ParameterUnitsStruct.E_red_t, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.E_red_t].Cells[2]);
                WriteOutput(ref ParameterValuesStruct.Et, ParameterUnitsStruct.Et, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Et].Cells[2]);

                WriteOutput(ref ParameterValuesStruct.x_o_50, ParameterUnitsStruct.x_o_50, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.x_o_50].Cells[2]);
                WriteOutput(ref ParameterValuesStruct.x_u_50, ParameterUnitsStruct.x_u_50, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.x_u_50].Cells[2]);

                WriteOutput(ref ParameterValuesStruct.Cmo, ParameterUnitsStruct.Cm, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Cmou].Cells[2]);
                WriteOutput(ref ParameterValuesStruct.Cvo, ParameterUnitsStruct.Cv, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Cvou].Cells[2]);
                WriteOutput(ref ParameterValuesStruct.Co, ParameterUnitsStruct.C, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Cou].Cells[2]);

                WriteOutput(ref ParameterValuesStruct.Cmu, ParameterUnitsStruct.Cm, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Cmou].Cells[3]);
                WriteOutput(ref ParameterValuesStruct.Cvu, ParameterUnitsStruct.Cv, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Cvou].Cells[3]);
                WriteOutput(ref ParameterValuesStruct.Cu, ParameterUnitsStruct.C, Program.Form_Main.dataGridView_Results1.Rows[Program.ResultParametersIndexes.Cou].Cells[3]);
                 */
            }

            static public void ProcessData()
            {
                ReadInputs();
                Docalculations();
                WriteOutputs();

                WriteResults();
                DisplayCurves();                
            }


            static public void DocalculationsForTablesAndGraphs()
            {
                if (ParameterInputInfoStruct.Is_rho_s_Inputed)
                {
                    if (ParameterInputInfoStruct.Is_Cm_Inputed)
                        ParameterValuesStruct.Eval_rho_sus_and_Cs_from_rho_s_and_Cm();

                    if (ParameterInputInfoStruct.Is_Cv_Inputed)
                        ParameterValuesStruct.Eval_rho_sus_and_Cs_from_rho_s_and_Cv();

                    if (ParameterInputInfoStruct.Is_C_Inputed)
                        ParameterValuesStruct.Eval_rho_sus_and_Cs_from_rho_s_and_C();
                }

                if (ParameterInputInfoStruct.Is_rho_sus_Inputed)
                {
                    if (ParameterInputInfoStruct.Is_Cm_Inputed)
                        ParameterValuesStruct.Eval_rho_s_and_Cs_from_rho_sus_and_Cm();

                    if (ParameterInputInfoStruct.Is_Cv_Inputed)
                        ParameterValuesStruct.Eval_rho_s_and_Cs_from_rho_sus_and_Cv();

                    if (ParameterInputInfoStruct.Is_C_Inputed)
                        ParameterValuesStruct.Eval_rho_s_and_Cs_from_rho_sus_and_C();
                }

                if (ParameterInputInfoStruct.Is_Q_Inputed)
                {
                    ParameterValuesStruct.Qm = ParameterValuesStruct.Eval_Qm_From_Q_rhosus();
                    ParameterValuesStruct.Qs = ParameterValuesStruct.Eval_Qs_From_Q_C();
                }
                else if (ParameterInputInfoStruct.Is_Qm_Inputed)
                {
                    ParameterValuesStruct.Q = ParameterValuesStruct.Eval_Q_From_Qm_rhosus();
                    ParameterValuesStruct.Qs = ParameterValuesStruct.Eval_Qs_From_Q_C();
                }
                else if (ParameterInputInfoStruct.Is_Qs_Inputed)
                {
                    ParameterValuesStruct.Q = ParameterValuesStruct.Eval_Q_From_Qs_C();
                    ParameterValuesStruct.Qm = ParameterValuesStruct.Eval_Qm_From_Q_rhosus();
                }

                if (ParameterInputInfoStruct.Is_n_Checked)
                {
                    if (ParameterInputInfoStruct.Is_rf_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_D_n_from_others();
                        else if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_x_red_50_n_from_others();
                    }
                    else if (ParameterInputInfoStruct.Is_Du_over_D_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_rf_D_n_from_others();
                        else if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_rf_n_x_red_50_from_others();
                    }
                }
                else if (ParameterInputInfoStruct.Is_Dp_Checked)
                {
                    if (ParameterInputInfoStruct.Is_rf_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_Dp_D_from_others();
                        else if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_x_red_50_Dp_from_others();
                    }
                    else if (ParameterInputInfoStruct.Is_Du_over_D_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_rf_x_red_50_Dp_from_others();
                        else if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_rf_D_Dp_from_others();
                    }
                }
                else if (ParameterInputInfoStruct.Is_Q_Checked)
                {
                    if (ParameterInputInfoStruct.Is_rf_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_D_Q_from_others();
                        else if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_x_red_50_Q_from_others();
                    }
                    else if (ParameterInputInfoStruct.Is_Du_over_D_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_rf_x_red_50_Q_from_others();
                        else if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_rf_D_Q_from_others();
                    }
                }

                ParameterValuesStruct.E_red_t = ParameterValuesStruct.Eval_E_red_t_From_xs_and_sigmas();
                ParameterValuesStruct.Et = ParameterValuesStruct.Eval_Et_From_E_red_t_and_rf();

                ParameterValuesStruct.Cu = ParameterValuesStruct.Eval_Cu_From_C_rf_Et();
                ParameterValuesStruct.Cmu = ParameterValuesStruct.Eval_Cm_From_C_From_rho_rho_s(ParameterValuesStruct.Cu, ParameterValuesStruct.rho_f, ParameterValuesStruct.rho_s);
                ParameterValuesStruct.Cvu = ParameterValuesStruct.Eval_Cv_From_C_From_rho_s(ParameterValuesStruct.Cu, ParameterValuesStruct.rho_s);

                ParameterValuesStruct.Co = ParameterValuesStruct.Eval_Co_From_C_rf_Cu();
                ParameterValuesStruct.Cmo = ParameterValuesStruct.Eval_Cm_From_C_From_rho_rho_s(ParameterValuesStruct.Co, ParameterValuesStruct.rho_f, ParameterValuesStruct.rho_s);
                ParameterValuesStruct.Cvo = ParameterValuesStruct.Eval_Cv_From_C_From_rho_s(ParameterValuesStruct.Co, ParameterValuesStruct.rho_s);

                /*
                if (!ParameterInputInfoStruct.Is_Q_Inputed &&
                    !ParameterInputInfoStruct.Is_Qm_Inputed &&
                    !ParameterInputInfoStruct.Is_Qs_Inputed)
                {
                    ParameterValuesStruct.Qm = ParameterValuesStruct.Eval_Qm_From_Q_rhosus();
                    ParameterValuesStruct.Qs = ParameterValuesStruct.Eval_Qs_From_Q_C();
                }

                // Only outputs
                ParameterValuesStruct.v = ParameterValuesStruct.Eval_v_From_Q_D_n();
                ParameterValuesStruct.Eu = ParameterValuesStruct.Eval_Eu_From_Dp_rho_v();
                ParameterValuesStruct.Re = ParameterValuesStruct.Eval_Re_From_Dp_rho_mu_v();
                ParameterValuesStruct.Stk_red = ParameterValuesStruct.Eval_Stk_red_From_Dp_rhos_v_mu_x_red_50();

                ParameterValuesStruct.E_red_t = ParameterValuesStruct.Eval_E_red_t_From_xs_and_sigmas();
                ParameterValuesStruct.Et = ParameterValuesStruct.Eval_Et_From_E_red_t_and_rf();

                ParameterValuesStruct.Cu = ParameterValuesStruct.Eval_Cu_From_C_rf_Et();
                ParameterValuesStruct.Cmu = ParameterValuesStruct.Eval_Cm_From_C_From_rho_rho_s(ParameterValuesStruct.Cu, ParameterValuesStruct.rho_f, ParameterValuesStruct.rho_s);
                ParameterValuesStruct.Cvu = ParameterValuesStruct.Eval_Cv_From_C_From_rho_s(ParameterValuesStruct.Cu, ParameterValuesStruct.rho_s);

                ParameterValuesStruct.Co = ParameterValuesStruct.Eval_Co_From_C_rf_Cu();
                ParameterValuesStruct.Cmo = ParameterValuesStruct.Eval_Cm_From_C_From_rho_rho_s(ParameterValuesStruct.Co, ParameterValuesStruct.rho_f, ParameterValuesStruct.rho_s);
                ParameterValuesStruct.Cvo = ParameterValuesStruct.Eval_Cv_From_C_From_rho_s(ParameterValuesStruct.Co, ParameterValuesStruct.rho_s);

                ParameterValuesStruct.x_o_50 = ParameterValuesStruct.Eval_x_o_50_From_();
                ParameterValuesStruct.x_u_50 = ParameterValuesStruct.Eval_x_u_50_From_();
                ParameterValuesStruct.x_50 = ParameterValuesStruct.Eval_x_50_From_();

                //ParameterValuesStruct.Qs = ParameterValuesStruct.Eval_Qs_From_();
                ParameterValuesStruct.Qu = ParameterValuesStruct.Eval_Qu_From_();
                ParameterValuesStruct.Qo = ParameterValuesStruct.Eval_Qo_From_();
                ParameterValuesStruct.Qmu = ParameterValuesStruct.Eval_Qmu_From_();
                ParameterValuesStruct.Qsu = ParameterValuesStruct.Eval_Qsu_From_();
                ParameterValuesStruct.Qmo = ParameterValuesStruct.Eval_Qmo_From_();
                ParameterValuesStruct.Qso = ParameterValuesStruct.Eval_Qso_From_();

                ParameterValuesStruct.L = ParameterValuesStruct.L_over_D * ParameterValuesStruct.D;
                ParameterValuesStruct.l = ParameterValuesStruct.l_over_D * ParameterValuesStruct.D;
                ParameterValuesStruct.Di = ParameterValuesStruct.Di_over_D * ParameterValuesStruct.D;
                ParameterValuesStruct.Do = ParameterValuesStruct.Do_over_D * ParameterValuesStruct.D;
                ParameterValuesStruct.Du = ParameterValuesStruct.Du_over_D * ParameterValuesStruct.D;
                 */
            }

            static public void Docalculations()
            {
                if (ParameterInputInfoStruct.Is_rho_s_Inputed)
                {
                    if (ParameterInputInfoStruct.Is_Cm_Inputed)
                        ParameterValuesStruct.Eval_rho_sus_and_Cs_from_rho_s_and_Cm();

                    if (ParameterInputInfoStruct.Is_Cv_Inputed)
                        ParameterValuesStruct.Eval_rho_sus_and_Cs_from_rho_s_and_Cv();

                    if (ParameterInputInfoStruct.Is_C_Inputed)
                        ParameterValuesStruct.Eval_rho_sus_and_Cs_from_rho_s_and_C();
                }

                if (ParameterInputInfoStruct.Is_rho_sus_Inputed)
                {
                    if (ParameterInputInfoStruct.Is_Cm_Inputed)
                        ParameterValuesStruct.Eval_rho_s_and_Cs_from_rho_sus_and_Cm();

                    if (ParameterInputInfoStruct.Is_Cv_Inputed)
                        ParameterValuesStruct.Eval_rho_s_and_Cs_from_rho_sus_and_Cv();

                    if (ParameterInputInfoStruct.Is_C_Inputed)
                        ParameterValuesStruct.Eval_rho_s_and_Cs_from_rho_sus_and_C();
                }

                if (ParameterInputInfoStruct.Is_Q_Inputed)
                {
                    ParameterValuesStruct.Qm = ParameterValuesStruct.Eval_Qm_From_Q_rhosus();
                    ParameterValuesStruct.Qs = ParameterValuesStruct.Eval_Qs_From_Q_C();
                }
                else if (ParameterInputInfoStruct.Is_Qm_Inputed)
                {
                    ParameterValuesStruct.Q = ParameterValuesStruct.Eval_Q_From_Qm_rhosus();
                    ParameterValuesStruct.Qs = ParameterValuesStruct.Eval_Qs_From_Q_C();
                }
                else if (ParameterInputInfoStruct.Is_Qs_Inputed)
                {
                    ParameterValuesStruct.Q = ParameterValuesStruct.Eval_Q_From_Qs_C();
                    ParameterValuesStruct.Qm = ParameterValuesStruct.Eval_Qm_From_Q_rhosus();
                }

                if (ParameterInputInfoStruct.Is_n_Checked)
                {
                    if (ParameterInputInfoStruct.Is_rf_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_D_n_from_others();
                        else if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_x_red_50_n_from_others();
                    }
                    else if (ParameterInputInfoStruct.Is_Du_over_D_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_rf_D_n_from_others();
                        else if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_rf_n_x_red_50_from_others();
                    }
                }
                else if (ParameterInputInfoStruct.Is_Dp_Checked)
                {
                    if (ParameterInputInfoStruct.Is_rf_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_Dp_D_from_others();
                        else if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_x_red_50_Dp_from_others();
                    }
                    else if (ParameterInputInfoStruct.Is_Du_over_D_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_rf_x_red_50_Dp_from_others();
                        else if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_rf_D_Dp_from_others();
                    }
                }
                else if (ParameterInputInfoStruct.Is_Q_Checked)
                {
                    if (ParameterInputInfoStruct.Is_rf_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_D_Q_from_others();
                        else if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_Du_over_D_x_red_50_Q_from_others();
                    }
                    else if (ParameterInputInfoStruct.Is_Du_over_D_Inputed)
                    {
                        if (ParameterInputInfoStruct.Is_D_Inputed)
                            ParameterValuesStruct.Eval_rf_x_red_50_Q_from_others();
                        else if (ParameterInputInfoStruct.Is_x_red_50_Inputed)
                            ParameterValuesStruct.Eval_rf_D_Q_from_others();
                    }
                }


                if (!ParameterInputInfoStruct.Is_Q_Inputed && 
                    !ParameterInputInfoStruct.Is_Qm_Inputed &&
                    !ParameterInputInfoStruct.Is_Qs_Inputed)
                {
                    ParameterValuesStruct.Qm = ParameterValuesStruct.Eval_Qm_From_Q_rhosus();
                    ParameterValuesStruct.Qs = ParameterValuesStruct.Eval_Qs_From_Q_C();
                }
                /*
                if (ParameterInputInfoStruct.Is_rf_Inputed)
                    ParameterValuesStruct.Eval_Du_over_D_Dp_D_from_others();
                else if (ParameterInputInfoStruct.Is_Du_over_D_Inputed)
                    ParameterValuesStruct.Eval_rf_n_x_red_50_from_others();                
                 */


    // Only outputs
                ParameterValuesStruct.v = ParameterValuesStruct.Eval_v_From_Q_D_n();
                ParameterValuesStruct.Eu = ParameterValuesStruct.Eval_Eu_From_Dp_rho_v();
                ParameterValuesStruct.Re = ParameterValuesStruct.Eval_Re_From_Dp_rho_mu_v();
                ParameterValuesStruct.Stk_red = ParameterValuesStruct.Eval_Stk_red_From_Dp_rhos_v_mu_x_red_50();

                ParameterValuesStruct.E_red_t = ParameterValuesStruct.Eval_E_red_t_From_xs_and_sigmas();
                ParameterValuesStruct.Et = ParameterValuesStruct.Eval_Et_From_E_red_t_and_rf();

                ParameterValuesStruct.Cu = ParameterValuesStruct.Eval_Cu_From_C_rf_Et();
                ParameterValuesStruct.Cmu = ParameterValuesStruct.Eval_Cm_From_C_From_rho_rho_s(ParameterValuesStruct.Cu, ParameterValuesStruct.rho_f, ParameterValuesStruct.rho_s);
                ParameterValuesStruct.Cvu = ParameterValuesStruct.Eval_Cv_From_C_From_rho_s(ParameterValuesStruct.Cu, ParameterValuesStruct.rho_s);

                ParameterValuesStruct.Co = ParameterValuesStruct.Eval_Co_From_C_rf_Cu();
                ParameterValuesStruct.Cmo = ParameterValuesStruct.Eval_Cm_From_C_From_rho_rho_s(ParameterValuesStruct.Co, ParameterValuesStruct.rho_f, ParameterValuesStruct.rho_s);
                ParameterValuesStruct.Cvo = ParameterValuesStruct.Eval_Cv_From_C_From_rho_s(ParameterValuesStruct.Co, ParameterValuesStruct.rho_s);

                ParameterValuesStruct.x_o_50 = ParameterValuesStruct.Eval_x_o_50_From_();
                ParameterValuesStruct.x_u_50 = ParameterValuesStruct.Eval_x_u_50_From_();
                ParameterValuesStruct.x_50 = ParameterValuesStruct.Eval_x_50_From_();

                //ParameterValuesStruct.Qs = ParameterValuesStruct.Eval_Qs_From_();
                ParameterValuesStruct.Qu = ParameterValuesStruct.Eval_Qu_From_();
                ParameterValuesStruct.Qo = ParameterValuesStruct.Eval_Qo_From_();
                ParameterValuesStruct.Qmu = ParameterValuesStruct.Eval_Qmu_From_();
                ParameterValuesStruct.Qsu = ParameterValuesStruct.Eval_Qsu_From_();
                ParameterValuesStruct.Qmo = ParameterValuesStruct.Eval_Qmo_From_();
                ParameterValuesStruct.Qso = ParameterValuesStruct.Eval_Qso_From_();

                ParameterValuesStruct.L = ParameterValuesStruct.L_over_D * ParameterValuesStruct.D;
                ParameterValuesStruct.l = ParameterValuesStruct.l_over_D * ParameterValuesStruct.D;
                ParameterValuesStruct.Di = ParameterValuesStruct.Di_over_D * ParameterValuesStruct.D;
                ParameterValuesStruct.Do = ParameterValuesStruct.Do_over_D * ParameterValuesStruct.D;
                ParameterValuesStruct.Du = ParameterValuesStruct.Du_over_D * ParameterValuesStruct.D;
            }

            static public void DisplayCurves()
            {
                ZedGraph.AxisType AxisType1 = (Program.Form_Main.comboBox_AxisType1.Text == "Linear") ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;
                ZedGraph.AxisType AxisType2 = (Program.Form_Main.comboBox_AxisType2.Text == "Linear") ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;

                if (Program.Form_Main.radioButton_f_small.Checked)
                    ParameterValuesStruct.Display_Curve_fx(Program.Form_Main.zedGraphControl1, AxisType1);
                if (Program.Form_Main.radioButton_F_Big.Checked)
                    ParameterValuesStruct.Display_Curve_Fx(Program.Form_Main.zedGraphControl1, AxisType1);
                if (Program.Form_Main.radioButton_Ff.Checked)
                    ParameterValuesStruct.Display_Curve_Ffx(Program.Form_Main.zedGraphControl1, AxisType1);
                if (Program.Form_Main.radioButton_G_G_red.Checked)
                    ParameterValuesStruct.Display_Curve_G_G_red(Program.Form_Main.zedGraphControl2, AxisType2);
                if (Program.Form_Main.radioButton_f_fo_fu_small.Checked)
                    ParameterValuesStruct.Display_Curve_f_fo_fu_small(Program.Form_Main.zedGraphControl2, AxisType2);
                if (Program.Form_Main.radioButton_F_Fo_Fu_Big.Checked)
                    ParameterValuesStruct.Display_Curve_F_Fo_Fu_big(Program.Form_Main.zedGraphControl2, AxisType2);
            }
            static public void ExportToWord(bool DataAndTables, bool GGred, bool FFoFu, bool ffofu, bool fF)
            {
                Word.Application app = new Word.Application();
                object template = System.Reflection.Missing.Value;
                object newTemplate = System.Reflection.Missing.Value;
                object documentType = System.Reflection.Missing.Value;
                object visible = true;

                Word._Document doc = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);

                object start = 0;
                object end = 1;

                Word.Range point = doc.Range(ref start, ref end);

                point.Font.Size = 14;
                point.Font.Underline = (Word.WdUnderline)1;
                point.Font.Bold = 1;
                point.Text = "Design and Performance Calculation of a Hydrocyclone – Unit\n";
                point.Start = point.End - 1;
                point.Font.Size = 12;
                point.Font.Underline = 0;
                point.Font.Bold = 0;

                if (Program.Form_ProtocolProperties.checkBox_DataAndTables.Checked)
                {
                    point.Font.Size = 12;
                    point.Font.Underline = 0;
                    point.Font.Bold = 0;
                    point.Text = "";
                    point.Text += "Material	: " + Program.GetCurrentSimulation().SimulationInfo.Material;
                    point.Text += "Customer	: " + Program.GetCurrentSimulation().SimulationInfo.Custumer;
                    point.Text += "Charge		: " + Program.GetCurrentSimulation().SimulationInfo.Charge + "\n";
                    point.Start = point.End - 1;

                    point.Font.Underline = (Word.WdUnderline)1;
                    point.Text += "Material Parameters\n";
                    point.Start = point.End - 1;

                    point.Font.Underline = 0;
                    point.Text += "Liquid viscosity (mili Pa s)			: " + (ParameterValuesStruct.mu / ParameterUnitsStruct.mu.Coefficient).ToStringWithRounding(2);
                    point.Text += "Liquid density (kg/m3)			: " + (ParameterValuesStruct.rho_f / ParameterUnitsStruct.rho_f.Coefficient).ToStringWithRounding(2);
                    point.Text += "Solids density (kg/m3)			: " + (ParameterValuesStruct.rho_s / ParameterUnitsStruct.rho_s.Coefficient).ToStringWithRounding(2);
                    point.Text += "Suspension density (kg/m3)			: " + (ParameterValuesStruct.rho_sus / ParameterUnitsStruct.rho_sus.Coefficient).ToStringWithRounding(2) + "\n";

                    point.Text += "Suspension solids mass fraction Cm(%)	: " + (ParameterValuesStruct.Cm / ParameterUnitsStruct.Cm.Coefficient).ToStringWithRounding(2);
                    point.Text += "Suspension solids volume fraction Cv(%)	: " + (ParameterValuesStruct.Cv / ParameterUnitsStruct.Cv.Coefficient).ToStringWithRounding(2);
                    point.Text += "Suspension solids concentration C(g/l)	: " + (ParameterValuesStruct.C / ParameterUnitsStruct.C.Coefficient).ToStringWithRounding(2) + "\n";

                    point.Text += "Median particle size x50 (micro m)		: " + (ParameterValuesStruct.x_g / ParameterUnitsStruct.x_g.Coefficient).ToStringWithRounding(2);
                    point.Text += "Spread of the particle size x84/x50 (-)	: " + (ParameterValuesStruct.sigma_g / ParameterUnitsStruct.sigma_g.Coefficient).ToStringWithRounding(2) + "\n";
                    point.Start = point.End - 1;

                    point.Font.Underline = (Word.WdUnderline)1;
                    point.Text += "Machine Parameters" + "\n\n";
                    point.Start = point.End - 1;

                    point.Font.Underline = 0;
                    Word.Table tb = point.Tables.AddOld(point, 4, 7);
                    tb.Cell(1, 3).Range.Text = "L/D(-)";
                    tb.Cell(2, 3).Range.Text =
                        (ParameterValuesStruct.L_over_D/ParameterUnitsStruct.L_over_D.Coefficient).ToStringWithRounding(3);
                    tb.Cell(1, 4).Range.Text = "l/D(-)";
                    tb.Cell(2, 4).Range.Text =
                        (ParameterValuesStruct.l_over_D/ParameterUnitsStruct.l_over_D.Coefficient).ToStringWithRounding(3);
                    tb.Cell(1, 5).Range.Text = "Di/D(-)";
                    tb.Cell(2, 5).Range.Text =
                        (ParameterValuesStruct.Di_over_D/ParameterUnitsStruct.Di_over_D.Coefficient).ToStringWithRounding(3);
                    tb.Cell(1, 6).Range.Text = "Du/D(-)";
                    tb.Cell(2, 6).Range.Text =
                        (ParameterValuesStruct.Du_over_D/ParameterUnitsStruct.Du_over_D.Coefficient).ToStringWithRounding(3);
                    tb.Cell(1, 7).Range.Text = "Do/D(-)";
                    tb.Cell(2, 7).Range.Text =
                        (ParameterValuesStruct.Do_over_D/ParameterUnitsStruct.Do_over_D.Coefficient).ToStringWithRounding(3);
                    tb.Cell(3, 1).Range.Text = "n(-)";
                    tb.Cell(4, 1).Range.Text =
                        (ParameterValuesStruct.n/ParameterUnitsStruct.n.Coefficient).ToStringWithRounding(0);
                    tb.Cell(3, 2).Range.Text = "D(mm)";
                    tb.Cell(4, 2).Range.Text =
                        (ParameterValuesStruct.D/ParameterUnitsStruct.D.Coefficient).ToStringWithRounding(1);
                    tb.Cell(3, 3).Range.Text = "L(mm)";
                    tb.Cell(4, 3).Range.Text =
                        (ParameterValuesStruct.L/ParameterUnitsStruct.L.Coefficient).ToStringWithRounding(1);
                    tb.Cell(3, 4).Range.Text = "l(mm)";
                    tb.Cell(4, 4).Range.Text =
                        (ParameterValuesStruct.l/ParameterUnitsStruct.l.Coefficient).ToStringWithRounding(1);
                    tb.Cell(3, 5).Range.Text = "Di(mm)";
                    tb.Cell(4, 5).Range.Text =
                        (ParameterValuesStruct.Di/ParameterUnitsStruct.Di.Coefficient).ToStringWithRounding(1);
                    tb.Cell(3, 6).Range.Text = "Du(mm)";
                    tb.Cell(4, 6).Range.Text =
                        (ParameterValuesStruct.Du/ParameterUnitsStruct.Du.Coefficient).ToStringWithRounding(1);
                    tb.Cell(3, 7).Range.Text = "Do(mm)";
                    tb.Cell(4, 7).Range.Text =
                        (ParameterValuesStruct.Do/ParameterUnitsStruct.Do.Coefficient).ToStringWithRounding(1);
                    tb.Borders.Enable = 1;
                    point.Start = point.End - 1;

                    point.Font.Underline = (Word.WdUnderline)1;
                    point.Text += "Machine Performance & Separation Efficiency" + "\n\n";
                    point.Start = point.End - 1;

                    point.Font.Underline = 0;
                    tb = point.Tables.AddOld(point, 2, 9);
                    tb.Cell(1, 1).Range.Text = "Q(" + ParameterUnitsStruct.Q.Name + ")";
                    tb.Cell(2, 1).Range.Text = (ParameterValuesStruct.Q / ParameterUnitsStruct.Q.Coefficient).ToStringWithRounding(2);
                    tb.Cell(1, 2).Range.Text = "Dp(bar)";
                    tb.Cell(2, 2).Range.Text =
                        (ParameterValuesStruct.Dp/ParameterUnitsStruct.Dp.Coefficient).ToStringWithRounding(2);
                    tb.Cell(1, 3).Range.Text = "v(" + ParameterUnitsStruct.v.Name + ")";
                    tb.Cell(2, 3).Range.Text =
                        (ParameterValuesStruct.v/ParameterUnitsStruct.v.Coefficient).ToStringWithRounding(2);
                    tb.Cell(1, 4).Range.Text = "rf(" + ParameterUnitsStruct.rf.Name + ")";
                    tb.Cell(2, 4).Range.Text =
                        (ParameterValuesStruct.rf/ParameterUnitsStruct.rf.Coefficient).ToStringWithRounding(2);
                    tb.Cell(1, 5).Range.Text = "x'50(mm)";
                    tb.Cell(2, 5).Range.Text =
                        (ParameterValuesStruct.x_red_50 / ParameterUnitsStruct.x_red_50.Coefficient).ToStringWithRounding(2);
                    tb.Cell(1, 5).Range.Font.Size = 10;
                    Word.Range cpoint = tb.Cell(1, 5).Range;
                    cpoint.Start = cpoint.Start + 5;
                    cpoint.End = cpoint.Start + 1;
                    cpoint.Font.Name = "Symbol";
                    tb.Cell(1, 6).Range.Text = "x50(mm)";
                    tb.Cell(2, 6).Range.Text =
                        (ParameterValuesStruct.Eval_x_From_G(new ValueClass(0.5)) / ParameterUnitsStruct.x_red_50.Coefficient).ToStringWithRounding(2);
                    tb.Cell(1, 6).Range.Font.Size = 10;
                    cpoint = tb.Cell(1, 6).Range;
                    cpoint.Start = cpoint.Start + 4;
                    cpoint.End = cpoint.Start + 1;
                    cpoint.Font.Name = "Symbol";
                    tb.Cell(1, 7).Range.Text = "ss(-)";
                    cpoint = tb.Cell(1, 7).Range;
                    cpoint.End = cpoint.Start + 1;
                    cpoint.Font.Name = "Symbol";
                    tb.Cell(2, 7).Range.Text =
                        (ParameterValuesStruct.sigma_s/ParameterUnitsStruct.sigma_s.Coefficient).ToStringWithRounding(2);
                    tb.Cell(1, 8).Range.Text = "E'T(%)";
                    tb.Cell(2, 8).Range.Text =
                        (ParameterValuesStruct.E_red_t/ParameterUnitsStruct.E_red_t.Coefficient).ToStringWithRounding(2);
                    tb.Cell(1, 9).Range.Text = "ET(%)";
                    tb.Cell(2, 9).Range.Text =
                        (ParameterValuesStruct.Et/ParameterUnitsStruct.Et.Coefficient).ToStringWithRounding(2);
                    tb.Borders.Enable = 1;
                    point.Start = point.End - 1;

                    point.Text += "\n";
                    point.Start = point.End - 1;

                    tb = point.Tables.AddOld(point, 8, 5);
                    tb.Cell(1, 1).Range.Text = "Parameter";
                    tb.Cell(1, 2).Range.Text = "Unit";
                    tb.Cell(1, 3).Range.Text = "Feeding";
                    tb.Cell(1, 4).Range.Text = "Underflow";
                    tb.Cell(1, 5).Range.Text = "Overflow";
                    int ni = 7;
                    for (int i = 0; i < ni; ++i)
                    {
                        if (Program.Form_Main.dataGridView_Results2.Rows[i].Cells[0].Value == null)
                        {
                            ni++;
                            continue;
                        }

                        for (int j = 0; j < 5; ++j)
                        {
                            string s = Program.Form_Main.dataGridView_Results2.Rows[i].Cells[j].Value.ToString();
                            tb.Cell(i + 2 + 7 - ni, j + 1).Range.Text = j < 2
                                                                            ? s
                                                                            : ValueClass.StringToValue(s).
                                                                                  ToStringWithRounding(2);
                        }
                    }
                    tb.Borders.Enable = 1;
                    point.Start = point.End - 1;

                    point.Text = "\n";
                    point.Start = point.End - 1;
                }

                if (Program.Form_ProtocolProperties.checkBox_DataAndTables.Checked
                    && (Program.Form_ProtocolProperties.checkBox_GGred.Checked
                        || Program.Form_ProtocolProperties.checkBox_FFoFuBigPlot.Checked
                        || Program.Form_ProtocolProperties.checkBox_FFoFuSmallPlot.Checked
                        || Program.Form_ProtocolProperties.checkBox_fFPlot.Checked))
                {
                    point.Text = new string((char) 12, 1);
                    point.Start = point.End - 1;
                }

                string fname = Environment.CurrentDirectory + "\\curve.bmp";
                object link_to_file = false, save_with_document = true, range = null;

                if (Program.Form_ProtocolProperties.checkBox_GGred.Checked)
                {
                    point.Text = "\n";
                    point.Start = point.End - 1;
                    ZedGraph.AxisType CurrentAxisType = (Program.Form_ProtocolProperties.comboBox_GGred.Text == "Linear") ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;
                    ParameterValuesStruct.Display_Curve_G_G_red(Program.Form_ProtocolProperties.zedGraphControl1,
                                                                CurrentAxisType);
                    Program.Form_ProtocolProperties.zedGraphControl1.Copy(false);
                    Image im = System.Windows.Forms.Clipboard.GetImage();
                    //im.
                    System.Windows.Forms.Clipboard.GetImage().Save(fname);
                    range = point;
                    point.InlineShapes.AddPicture(fname, ref link_to_file, ref save_with_document, ref range);
                    point.Start = point.End - 1;
                    point.Text = "\n";
                    point.Start = point.End - 1;
                }

                if (Program.Form_ProtocolProperties.checkBox_FFoFuBigPlot.Checked)
                {
                    point.Text = "\n";
                    point.Start = point.End - 1;
                    ZedGraph.AxisType CurrentAxisType = (Program.Form_ProtocolProperties.comboBox_FFoFuBig.Text == "Linear") ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;
                    ParameterValuesStruct.Display_Curve_F_Fo_Fu_big(Program.Form_ProtocolProperties.zedGraphControl1,
                                                                CurrentAxisType);
                    Program.Form_ProtocolProperties.zedGraphControl1.Copy(false);
                    System.Windows.Forms.Clipboard.GetImage().Save(fname);
                    range = point;
                    point.InlineShapes.AddPicture(fname, ref link_to_file, ref save_with_document, ref range);
                    point.Start = point.End - 1;
                    point.Text = "\n";
                    point.Start = point.End - 1;
                }

                if (Program.Form_ProtocolProperties.checkBox_FFoFuSmallPlot.Checked)
                {
                    point.Text = "\n";
                    point.Start = point.End - 1;
                    ZedGraph.AxisType CurrentAxisType = (Program.Form_ProtocolProperties.comboBox_ffofuSmall.Text == "Linear") ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;
                    ParameterValuesStruct.Display_Curve_f_fo_fu_small(Program.Form_ProtocolProperties.zedGraphControl1,
                                                                CurrentAxisType);
                    Program.Form_ProtocolProperties.zedGraphControl1.Copy(false);
                    System.Windows.Forms.Clipboard.GetImage().Save(fname);
                    range = point;
                    point.InlineShapes.AddPicture(fname, ref link_to_file, ref save_with_document, ref range);
                    point.Start = point.End - 1;
                    point.Text = "\n";
                    point.Start = point.End - 1;
                }

                if (Program.Form_ProtocolProperties.checkBox_fFPlot.Checked)
                {
                    point.Text = "\n";
                    point.Start = point.End - 1;
                    ZedGraph.AxisType CurrentAxisType = (Program.Form_ProtocolProperties.comboBox_fF.Text == "Linear") ? ZedGraph.AxisType.Linear : ZedGraph.AxisType.Log;
                    ParameterValuesStruct.Display_Curve_Ffx(Program.Form_ProtocolProperties.zedGraphControl1,
                                                                CurrentAxisType);
                    Program.Form_ProtocolProperties.zedGraphControl1.Copy(false);
                    System.Windows.Forms.Clipboard.GetImage().Save(fname);
                    range = point;
                    point.InlineShapes.AddPicture(fname, ref link_to_file, ref save_with_document, ref range);
                    point.Start = point.End - 1;
                    point.Text = "\n";
                    point.Start = point.End - 1;
                }

                System.IO.File.Delete(fname);

                app.Visible = true;
            }
        }
    }
}
