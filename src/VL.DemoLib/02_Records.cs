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

    /// <summary>
    /// This Record was hand written in C#. 
    /// </summary>
    public class BreadCrumb
    {
        public BreadCrumb(BreadCrumb previous, float distance)
        {
            Previous = previous;
            Distance = distance;
        }

        // All our fiels are readonly. They only can be written by a constructor. This is purest way of expressing immutability in c#. 
        // Oh and also note that if you want to be actual immutable all your fields need to be. 
        public readonly BreadCrumb Previous;
        public readonly float Distance;

        // These setters return new instances of our record. Because of this we should try hard to avoid type hierarchies.
        public BreadCrumb SetPrevious(BreadCrumb previous) => new BreadCrumb(previous, Distance);
        public BreadCrumb SetDistance(float distance) => new BreadCrumb(Previous, distance);
        public bool HasPrevious => Previous != null;
    }
}
