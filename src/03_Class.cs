using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLib
{
    public class MyDataType
    {
        float FX;

        public float FY;

        //constructor
        public MyDataType(float x)
        {
            FX = x;
        }

        //an operation called Update
        public float Update(float factor=1f)
        {
            FX *= factor;
            return FX;
        }

        //another operation
        public float Another(float factor=1f)
        {
            FX *= factor;
            return FX;
        }

        //protected operations will not show up
        protected float ProtectedOp(float factor)
        {
            FX *= factor;
            return FX;
        }

        //private operations will not show up
        private float PrivateOp(float factor)
        {
            FX *= factor;
            return FX;
        }
    }
}
