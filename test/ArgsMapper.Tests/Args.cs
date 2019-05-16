// The MIT License (MIT)
// 
// Copyright (c) 2019 Akan Murat Cimen
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ArgsMapper.Tests
{
    [ExcludeFromCodeCoverage]
    internal class OneBoolOptionArgs
    {
        public bool Option { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneIntOptionArgs
    {
        public int Option { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneBoolWithoutSetterOptionArgs
    {
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public bool Option { get; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneInternalBoolOptionArgs
    {
        internal bool Option { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneBoolMethodOptionArgs
    {
        public bool Option()
        {
            return false;
        }
    }

    [ExcludeFromCodeCoverage]
    internal class OneBoolFieldOptionArgs
    {
#pragma warning disable CS0649
        public bool Option;
#pragma warning restore
    }

    [ExcludeFromCodeCoverage]
    internal class OneByteOptionArgs
    {
        public byte Option { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneBoolOptionAndOneBoolOptionArgs
    {
        public OneBoolOptionArgs Command { get; set; }
        public bool Option { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneLongNamedCommandWithOneBoolOptionArgs
    {
        public OneBoolOptionArgs SomeCommandProperty { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneBoolOptionAndOneIntOptionArgs
    {
        public OneBoolOptionArgs Command { get; set; }
        public int Option { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneListStringOptionArgs
    {
        public List<string> Option { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneListIntOptionArgs
    {
        public List<int> Option { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithUnsupportedTypeOptionArgs
    {
        public UnsupportedTypeOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneBoolOptionArgs
    {
        public OneBoolOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneIntOptionArgs
    {
        public OneIntOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneClassWithOneBoolOption
    {
        public OneCommandWithOneBoolOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneListStringOption
    {
        public OneListStringOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneListIntOption
    {
        public OneListIntOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneBoolWithoutSetterOptionArgs
    {
        public OneBoolWithoutSetterOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneInternalBoolOptionArgs
    {
        public OneInternalBoolOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneBoolMethodOptionArgs
    {
        public OneBoolMethodOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithoutSetterWithOneBoolOptionArgs
    {
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public OneBoolOptionArgs Command { get; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneInternalCommandWithOneBoolOptionArgs
    {
        internal OneBoolOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandMethodWithOneBoolOptionArgs
    {
        public OneBoolOptionArgs Command()
        {
            return null;
        }
    }

    [ExcludeFromCodeCoverage]
    internal class ThreeIntOptionsArgs
    {
        public int Option1 { get; set; }
        public int Option2 { get; set; }
        public int Option3 { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class FourBoolOptionArgs
    {
        public bool Option1 { get; set; }
        public bool Option2 { get; set; }
        public bool Option3 { get; set; }
        public bool Option4 { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithThreeIntOptionsArgs
    {
        public ThreeIntOptionsArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class TwoLevelNestedClass
    {
        public NestedModelA NestedA { get; set; }

        internal class NestedModelA
        {
            public NestedModelB NestedB { get; set; }

            internal class NestedModelB
            {
                public bool Option { get; set; }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    internal class OneLevelNestedClass
    {
        public NestedModel Nested { get; set; }

        internal class NestedModel
        {
            public bool Option { get; set; }
        }
    }

    [ExcludeFromCodeCoverage]
    internal class OneLevelNestedClassWithTwoBoolOptionArgs
    {
        public NestedModel Nested { get; set; }

        internal class NestedModel
        {
            public bool Option1 { get; set; }
            public bool Option2 { get; set; }
        }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithTwoLevelNestedClass
    {
        public TwoLevelNestedClass Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneLongNamedBoolOptionArgs
    {
        public bool SomeOptionProperty { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class OneCommandWithOneLongNamedBoolOptionArgs
    {
        public OneLongNamedBoolOptionArgs Command { get; set; }
    }

    [ExcludeFromCodeCoverage]
    internal class UnsupportedTypeOptionArgs
    {
        public Queue<int> QueueOption { get; set; }
        public Stack<int> StackOption { get; set; }
        public IEnumerable<int> IEnumerableIntOption { get; set; }
        public IList<int> ListIntOption { get; set; }
    }

    internal enum SampleEnum
    {
        Value1,
        Value2,
        Value3
    }

    internal enum SampleUshortEnum : ushort
    {
        Value1,
        Value2,
        Value3
    }
}