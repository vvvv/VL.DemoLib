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

        //public event
        public event EventHandler<float> OnValueExceeded;
        public event EventHandler OnValueChanged;

        //constructor
        public MyDataType(float x)
        {
            FX = x;
        }

        //an operation called Update
        public float AddValue(float value)
        {
            var lastFX = FX;
            FX += value;
            if (FX != lastFX)
                OnValueChanged?.Invoke(this, EventArgs.Empty);

            if (FX > FThreshold)
                OnValueExceeded?.Invoke(this, FX);

            return FX;
        }

        //another operation
        public void SetThreshold(float threshold = 10f)
        {
            FThreshold = threshold;
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
