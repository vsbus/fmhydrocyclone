using System;

namespace Hydrocyclone1
{
    public struct UnitStruct
    {
        public String Name;
        public double Coefficient;

        /*
        UnitStruct()
        {
        }
         * */

        public UnitStruct(String name, double x)
        {
            Name = name;
            Coefficient = x;
        }
    }
}
