using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoLib
{
    //The name of a static class will show up as a category in VL
    public static class SomeStaticVLNodes
    { 
        //a simple static operation
        public static float MyAddition(float input, float input2)
        {
            return input + input2;
        }

        //function overloading
        public static float MyAddition(float input, float input2, float input3)
        {
            return input + input2 + input3;
        }

        //pinnames are separated at camelCasing for better reading in VL
        public static float PinNames(float firstInput, float secondInput)
        {
            return firstInput + secondInput;
        }

        //setting pin defaults
        public static float Defaults(float firstInput = 44f, float secondInput = 0.44f)
        {
            return firstInput + secondInput;
        }

        //multiple outputs via out parameters
        public static void MultipleOutputs(float firstInput, float secondInput, out float added, out float multiplied)
        {
            added = firstInput + secondInput;
            multiplied = firstInput * secondInput;
        }

        //using generics
        public static string Generic<T>(T input)
        {
            return input.ToString();
        }

        //IEnumerable<> appears as Sequence<> in vl
        public static IEnumerable<float> ReverseSequence(IEnumerable<float> input)
        {
            return input.Reverse();
        }

        //static enum
        public enum DemoEnum { Foo, Bar };
        public static string StaticEnumDemo(DemoEnum e)
        {
            return e.ToString();
        }

        //to use XML documentation don't forget to enable "XML Documentation File" in the projects properties!
        ///<summary>An operation to test xml documentation</summary>
        ///<remarks>This is only an example node</remarks>
        ///<tags>html documentation test</tags>
        ///<param name="a">the param a</param>
        ///<returns>returns 2 a</returns>
        public static int XMLDocuTest(int a)
        {
            return a*2;
        }

        //you can use ref parameters, but
        //beware: assigning the parameter in the method leads to undefined behavior in VL (for now)
        //so only make use of it in a readonly fashion
        public static int RefParams(ref int input)
        {
            return input + 4444;
        }
    }
}
