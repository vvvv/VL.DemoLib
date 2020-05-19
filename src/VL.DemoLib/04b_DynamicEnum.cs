using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Lib.Collections;
using VL.Core;

namespace DemoLib
{
    public class DynamicEnumDemo
    {
        public string Update(MyEnum enumInput)
        {
            if (enumInput.IsValid())
                return enumInput.Definition.Entries[enumInput.SelectedIndex()];
            else
                return "No valid entry selected";
        }

        public MyEnumDefinition GetDefinition()
        {
            return MyEnumDefinition.Instance;
        }

        public void AddEnumEntry(string entry)
        {
            MyEnumDefinition.Instance.AddEntry(entry, null);
        }

        public void RemoveEnumEntry(string entry)
        {
            MyEnumDefinition.Instance.RemoveEntry(entry);
        }
    }

    public class MyEnumDefinition : ManualDynamicEnumDefinitionBase<MyEnumDefinition>
    {
        //this is optional an can be used if any initialization before the call to GetEntries is needed
        protected override void Initialize()
        {
            //add two default entries on initialization
            AddEntry("abara", null);
            AddEntry("kadabara", null);
        }

        //add this to get a node that can access the Instance from everywhere
        public static MyEnumDefinition Instance => ManualDynamicEnumDefinitionBase<MyEnumDefinition>.Instance;
    }

    [Serializable]
    public class MyEnum: DynamicEnumBase<MyEnum, MyEnumDefinition>
    {
        public MyEnum(string value) : base(value)
        {
        }

        //this method needs to be imported in VL to set the default
        public static MyEnum CreateDefault()
        {
            //use method of base class if nothing special required
            return CreateDefaultBase();
        }
    }
}
