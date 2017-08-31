using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLib
{
    //How to: Publish Events that Conform to .NET Framework Guidelines (C# Programming Guide)
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines
    public class CustomEventArgs<T> : EventArgs
    {
        public CustomEventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public class MyDataTypeWithEvents
    {
        //private fields
        private float FX;
        private float FThreshold = 10f;

        //public property
        public float Y { get; set; }

        //public events
        public event EventHandler OnValueChanged;
        public event EventHandler<CustomEventArgs<float>> OnValueExceeded;

        //public static events
        public static event EventHandler OnAnyValueChanged;
        public static event EventHandler<CustomEventArgs<float>> OnAnyValueExceeded;

        //constructor
        public MyDataTypeWithEvents(float x)
        {
            FX = x;
        }

        //an operation called Update
        public float AddValue(float value)
        {
            var lastFX = FX;
            FX += value;
            if (FX != lastFX)
            {
                OnValueChanged?.Invoke(this, EventArgs.Empty);
                OnAnyValueChanged?.Invoke(this, EventArgs.Empty);
            }

            if (FX > FThreshold)
            {
                OnValueExceeded?.Invoke(this, new CustomEventArgs<float>(FX));
                OnAnyValueExceeded?.Invoke(this, new CustomEventArgs<float>(FX));
            }

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
