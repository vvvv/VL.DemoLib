﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Lib.Collections;

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

        public void AddEnumEntry(string entry)
        {
            MyEnumDefinition.Instance.AddEntry(entry);
        }

        public void RemoveEnumEntry(string entry)
        {
            MyEnumDefinition.Instance.RemoveEntry(entry);
        }
    }

    public class MyEnumDefinition : DynamicEnumDefinitionBase<MyEnumDefinition>
    {
        ObservableCollection<string> FMyEntries = new ObservableCollection<string>();

        //this is optional an can be used if any initialization before the call to GetEntries is needed
        protected override void Initialize()
        {
            //add two default entries on initialization
            FMyEntries.Add("abara");
            FMyEntries.Add("kadabara");
        }

        //return the current enum entries
        protected override IReadOnlyList<string> GetEntries()
        {
            return FMyEntries;
        }

        //inform the system that the enum has changed
        protected override IObservable<object> GetEntriesChangedObservable()
        {
            return Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                h => FMyEntries.CollectionChanged += h,
                h => FMyEntries.CollectionChanged -= h);
        }

        public void AddEntry(string entry)
        {
            FMyEntries.Add(entry);
        }

        public bool RemoveEntry(string entry)
        {
            return FMyEntries.Remove(entry);
        }
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
