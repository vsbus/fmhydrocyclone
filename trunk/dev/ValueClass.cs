using System;

namespace Hydrocyclone1
{
    public struct ValueClass
    {
        public double Value;
        public bool Defined;
        const string UndefinedValue = "<undefined>";

        public ValueClass(double x)
        {
            Defined = true;
            Value = x;
        }
        public ValueClass(double x, bool d)
        {
            Defined = d;
            Value = x;
        }
        public ValueClass(ValueClass val)
        {
            Defined = val.Defined;
            Value = val.Value;
        }

        public ValueClass Round(int precision)
        {
            ValueClass result = new ValueClass(0, Defined);

            if (Value == 0)
            {
                return result;
            }

            double pMin = Math.Pow(10, precision - 1);
            double pMax = Math.Pow(10, precision);
            double factor = 1;
            const double eps = 1e-8;

            result.Value = Value;

            while (Math.Abs(result.Value) < pMin - eps)
            {
                result.Value *= 10;
                factor *= 10;
            }

            while (Math.Abs(result.Value) >= pMax - eps)
            {
                result.Value /= 10;
                factor /= 10;
            }

            result.Value = Math.Floor(result.Value + 0.5 + eps);
            result.Value /= factor;
            return result;
        }

        public string ToStringWithRounding(int digits_count)
        {
            //if (!Defined) return UndefinedValue;
            //double p10 = Math.Pow(10.0, digits_count);
            //double val = Value * p10 + 1e-12;
            //double fval = Math.Floor(val);
            //if (val - fval >= 0.5)
            //    fval += 1;
            //fval /= p10;
            //return fval.ToString();

            ValueClass val = Round(digits_count);
            string res = Convert.ToString(val.Value);
            res = val.Defined ? res : "";
            return res;
        }
        public static bool IsValueString(String s)
        {
            try
            {
                Convert.ToDouble(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public void WriteToStream(System.IO.StreamWriter sw)
        {
            sw.WriteLine(Defined);
            sw.WriteLine(Value);
        }
        public void ReadFromStream(System.IO.StreamReader sr)
        {
            Defined = Convert.ToBoolean(sr.ReadLine());
            Value = Convert.ToDouble(sr.ReadLine());
        }
        public static ValueClass StringToValue(String s)
        {
            ValueClass res = new ValueClass();
            res.Defined = double.TryParse(s, out res.Value);
            return res;
        }
        public static ValueClass objectToValue(object obj)
        {
            return StringToValue(obj == null ? "" : obj.ToString());
        }
        public static ValueClass TextBoxToValue(System.Windows.Forms.TextBox tb)
        {
            ValueClass res = StringToValue(tb.Text);
            return res;
        }

        public static String ValueToString(ValueClass val)
        {
            
            string res = val.Value.ToString("0.##############################");
            res = val.Defined ? res : UndefinedValue;
            return res;
        }
        public static void WriteValueToTextBox(ValueClass val, System.Windows.Forms.TextBox tb)
        {
            tb.Text = ValueToString(val);
        }

        public static bool operator <(ValueClass op1, ValueClass op2)
        {
            return !op1.Defined
                   || op1.Defined && op2.Defined && op1.Value < op2.Value;
        }
        public static bool operator >(ValueClass op1, ValueClass op2)
        {
            return op2 < op1;
        }
        public static bool operator ==(ValueClass op1, ValueClass op2)
        {
            return op1.Defined == op2.Defined && op1.Value == op2.Value;
        }
        public static bool operator !=(ValueClass op1, ValueClass op2)
        {
            return op1.Defined != op2.Defined || op1.Value != op2.Value;
        }
        public static ValueClass operator -(ValueClass op)
        {
            ValueClass res = new ValueClass(-op.Value, op.Defined);
            return res;
        }
        public static ValueClass operator +(ValueClass op1, ValueClass op2)
        {
            ValueClass res = new ValueClass(op1.Value + op2.Value, op1.Defined && op2.Defined);
            return res;
        }
        public static ValueClass operator +(ValueClass op1, double op2)
        {
            ValueClass res = new ValueClass(op1.Value + op2, op1.Defined);
            return res;
        }
        public static ValueClass operator +(double op1, ValueClass op2)
        {
            ValueClass res = new ValueClass(op1 + op2.Value, op2.Defined);
            return res;
        }
        public static ValueClass operator -(ValueClass op1, ValueClass op2)
        {
            ValueClass res = new ValueClass(op1.Value - op2.Value, op1.Defined && op2.Defined);
            return res;
        }
        public static ValueClass operator -(ValueClass op1, double op2)
        {
            ValueClass res = new ValueClass(op1.Value - op2, op1.Defined);
            return res;
        }
        public static ValueClass operator -(double op1, ValueClass op2)
        {
            ValueClass res = new ValueClass(op1 - op2.Value, op2.Defined);
            return res;
        }
        public static ValueClass operator *(ValueClass op1, ValueClass op2)
        {
            ValueClass res = new ValueClass(op1.Value * op2.Value, op1.Defined && op2.Defined);
            return res;
        }
        public static ValueClass operator *(ValueClass op1, double op2)
        {
            ValueClass res = new ValueClass(op1.Value * op2, op1.Defined);
            return res;
        }
        public static ValueClass operator *(double op1, ValueClass op2)
        {
            ValueClass res = new ValueClass(op1 * op2.Value, op2.Defined);
            return res;
        }
        public static ValueClass operator /(ValueClass op1, ValueClass op2)
        {
            ValueClass res = new ValueClass();
            res.Defined = op1.Defined && op2.Defined && (op2.Value != 0.0);
            res.Value = res.Defined ? op1.Value / op2.Value : 1;
            return res;
        }
        public static ValueClass operator /(ValueClass op1, double op2)
        {
            ValueClass res = new ValueClass();
            res.Defined = op1.Defined && (op2 != 0.0);
            res.Value = res.Defined ? op1.Value / op2 : 1;
            return res;
        }
        public static ValueClass operator /(double op1, ValueClass op2)
        {
            ValueClass res = new ValueClass();
            res.Defined = op2.Defined && (op2.Value != 0.0);
            res.Value = res.Defined ? op1 / op2.Value : 1;
            return res;
        }
        public static ValueClass Exp(ValueClass op)
        {
            ValueClass res = new ValueClass();
            res.Defined = op.Defined;
            res.Value = res.Defined ? Math.Exp(op.Value) : 1;
            return res;
        }
        public static ValueClass Log(ValueClass op)
        {
            ValueClass res = new ValueClass();
            res.Defined = op.Defined && op.Value > 0;
            res.Value = res.Defined ? Math.Log(op.Value) : 1;
            return res;
        }
        public static ValueClass Pow(ValueClass op1, ValueClass op2)
        {
            ValueClass res = new ValueClass();
            res.Defined = op1.Defined && op2.Defined && op1.Value > 0;
            res.Value = res.Defined ? Math.Pow(op1.Value, op2.Value) : 1;
            return res;
        }
        public static ValueClass Pow(ValueClass op1, double op2)
        {
            ValueClass res = new ValueClass();
            res.Defined = op1.Defined && op1.Value > 0;
            res.Value = res.Defined ? Math.Pow(op1.Value, op2) : 1;
            return res;
        }
        public static ValueClass Sqrt(ValueClass op1)
        {
            ValueClass res = new ValueClass();
            res.Defined = op1.Defined && op1.Value > 0;
            res.Value = res.Defined ? Math.Sqrt(op1.Value) : 1;
            return res;
        }
        public static ValueClass Sqr(ValueClass op)
        {
            ValueClass res = new ValueClass(op);
            res = res * op;
            return res;
        }
        public static ValueClass Erf(ValueClass op)
        {
            ValueClass res = new ValueClass();
            res.Defined = op.Defined;
            res.Value = res.Defined ? normaldistr.erf(op.Value) : 1;
            return res;
        }

        public static class Integral
        {
            public delegate ValueClass function_x(ValueClass x);
            static public function_x IntergatedFunction_x;
            static bool DefinedResult;
            static public ValueClass EvalIntegralValue(ValueClass a, ValueClass b)
            {
                int hu = 0;
                double val = 0;
                ValueClass res;
                
                autogk61.IntergatedFunction_x = IntergatedFunction_x_double;
                
                DefinedResult = a.Defined && b.Defined;
                if (!DefinedResult)
                    return new ValueClass(1, false);

                autogk61.autogk61integrator(a.Value, b.Value, 1e-9, 2, ref val, ref hu);
                
                res.Defined = DefinedResult;
                res.Value = val;
                
                return res;
            }
            static double IntergatedFunction_x_double(double x)
            {
                ValueClass y = IntergatedFunction_x(new ValueClass(x));
                if (!y.Defined)
                    DefinedResult = false;
                return y.Value;
            }
        }
    }
}
