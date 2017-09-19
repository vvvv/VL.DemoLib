using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLib
{
    public class MyDataType
    {
        //private fields
        private float FX;
        private float FThreshold = 10f;

        //public property
        public float Y { get; set; }

        //constructor
        public MyDataType(float x)
        {
            FX = x;
        }

        //an operation called AddValue
        public float AddValue(float value)
        {
            var lastFX = FX;
            FX += value;

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
