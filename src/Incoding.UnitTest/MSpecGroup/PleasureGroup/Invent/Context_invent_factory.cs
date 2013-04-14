namespace Incoding.UnitTest.MSpecGroup
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.IO;

    #endregion

    public class Context_invent_factory
    {
        #region Fake classes

        protected class FakeGenerateObject
        {
            #region Properties

            public string StrValue { get; set; }

            public bool BoolValue { get; set; }

            public int IntValue { get; set; }

            public float FloatValue { get; set; }

            public decimal DecimalValue { get; set; }

            public long LongValue { get; set; }

            public byte ByteValue { get; set; }

            public DateTime DateTimeValue { get; set; }

            public TimeSpan TimeSpanValue { get; set; }

            public FakeGenerateObject Fake { get; set; }

            public byte[] ByteArray { get; set; }

            public int[] IntArray { get; set; }

            public string[] StrArray { get; set; }

            public Stream StreamValue { get; set; }

            public Dictionary<string, string> DictionaryValue { get; set; }

            public Dictionary<string, object> DictionaryObjectValue { get; set; }

            public DayOfWeek DayOfWeek { get; set; }

            public double DoubleValue { get; set; }

            public char CharValue { get; set; }

            public string CallbackValue { get; set; }

            public DayOfWeek EnumValue { get; set; }

            public object ObjValue { get; set; }

            #endregion
        }

        #endregion
    }
}