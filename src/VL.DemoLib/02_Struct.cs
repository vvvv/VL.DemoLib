using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLib
{
    public struct SimpleStruct
    {
        private int FX;
        public int X
        {
            get
            {
                return FX;
            }
            set
            {
                if (value < 100)
                    FX = value;
            }
        }
        public int TwoX()
        {
            return FX * 2;
        }
    }
}
