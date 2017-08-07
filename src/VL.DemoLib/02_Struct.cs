using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLib
{
    //this can be imported as immutable record in VL because it only has a read-only property
    public struct SimpleStruct
    {
        public int X { get; }

        public SimpleStruct(int x)
        {
            X = x;
        }

        public int TwoX()
        {
            return X * 2;
        }
    }
}
