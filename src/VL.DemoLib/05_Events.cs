using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLib
{
    //Publish Events that Conform to .NET Framework Guidelines (C# Programming Guide)
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines
    public class MyGenericEventArgs<T> : EventArgs
    {
        public readonly T Value;

        public MyGenericEventArgs(T value)
        {
            Value = value;
        }
    }

    public class MyDataTypeWithEvents
    {
        //private fields
        private float FX;
        private float FThreshold = 10f;

        //public events
        public event EventHandler ValueChanged;
        public event EventHandler<MyGenericEventArgs<float>> ValueExceeded;

        //public static events
        public static event EventHandler AnyValueChanged;
        public static event EventHandler<MyGenericEventArgs<float>> AnyValueExceeded;

        //constructor
        public MyDataTypeWithEvents(float x)
        {
            FX = x;
        }

        //an operation
        public float AddValue(float value)
        {
            if (value != 0)
            {
                FX += value;
                ValueChanged?.Invoke(this, EventArgs.Empty);
                AnyValueChanged?.Invoke(this, EventArgs.Empty);
            }

            if (FX > FThreshold)
            {
                ValueExceeded?.Invoke(this, new MyGenericEventArgs<float>(FX));
                AnyValueExceeded?.Invoke(this, new MyGenericEventArgs<float>(FX));
            }

            return FX;
        }

        //another operation
        public void SetThreshold(float threshold = 10f)
        {
            FThreshold = threshold;
        }
    }
}
