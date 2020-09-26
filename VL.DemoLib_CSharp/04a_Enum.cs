using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib
{
    //static enum
    public enum DemoEnum { Foo, Bar };

    public static class SomeEnumNodes
    {
        public static string StaticEnumDemo(DemoEnum e)
        {
            return e.ToString();
        }

        public static string StaticItalienEnumDemo(ItalianNumbers e)
        {
            return e.ToString();
        }
    }

    [Flags]
    public enum ItalianNumbers
    {
        Zero                   = 0,

        Uno                    = 0b0001,    // 1
        Due                    = 0b0010,    // 2
        Quattro                = 0b0100,    // 4
        Otto                   = 0b1000,    // 8

        Quindici               = 0xF,       // 15
        Sedici                 = 0x10,      // 16, 0b_0001_0000

        TrentaDue              = 32,        // 0b_0010_0000
        Sessanta­Quattro        = 64,        // 0b_0100_0000
        CentoVent­Otto          = 128,       // 0b_1000_0000

        DueCentoCinquantaSei   = 0x100,     // 256,  0b__0000_0001__0000_0000  (still 16 more bits available. enum ist encoded as 32 bit int by default)

        UnoODue                = Uno | Due, // 0b0011 also known as 3
    }
}
