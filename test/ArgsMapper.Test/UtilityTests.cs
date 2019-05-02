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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using ArgsMapper.Models;
using ArgsMapper.Utilities;
using Xunit;

namespace ArgsMapper.Test
{
    public class UtilityTests
    {
        [Theory]
        [InlineData(true, null)]
        [InlineData(true, "")]
        [InlineData(true, "", "")]
        [InlineData(true, "", "", null, "")]
        [InlineData(false, "a")]
        [InlineData(false, "", "a")]
        [InlineData(false, "", "", null, "a", "")]
        internal void ArgsExtensions_IsNullOrEmpty(bool expected, params string[] args)
        {
            Assert.Equal(expected, args.IsNullOrEmpty());
        }

        [Theory]
        [InlineData("-o", true)]
        [InlineData("--option", true)]
        [InlineData("----option", true)]
        [InlineData("", false)]
        [InlineData("o", false)]
        [InlineData("option", false)]
        [InlineData("-", false)]
        [InlineData("--", false)]
        [InlineData("-oo", false)]
        internal void ArgsExtensions_IsValidOption(string value, bool expected)
        {
            Assert.Equal(expected, value.IsValidOption());
        }

        [Theory]
        [InlineData("-o", "o")]
        [InlineData("--option", "option")]
        [InlineData("o", "o")]
        [InlineData("option", "option")]
        [InlineData("", "")]
        internal void ArgsExtensions_RemoveOptionPrefix(string value, string expected)
        {
            Assert.Equal(expected, value.RemoveOptionPrefix());
        }

        [Theory]
        [InlineData("command", "command")]
        [InlineData("Command", "command")]
        [InlineData("COMMAND", "command")]
        [InlineData("commAnd", "comm-and")]
        internal void Command_ToString(string name, string expected)
        {
            // Arrange
            var command = new Command {
                Name = name,
                CultureInfo = CultureInfo.InvariantCulture
            };

            // Act
            var displayName = command.ToString();

            // Assert
            Assert.Equal(expected, displayName);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("foobar", "foobar")]
        [InlineData("FooBar", "foo-bar")]
        [InlineData("fooBar", "foo-bar")]
        [InlineData("FOOBAR", "foobar")]
        [InlineData("Foobar", "foobar")]
        internal void NamingHelper_ToHyphenCase(string value, string expected)
        {
            Assert.Equal(expected, value.ToHyphenCase(CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(null, "option", "--option")]
        [InlineData('o', "option", "-o|--option")]
        [InlineData('o', "Option", "-o|--option")]
        [InlineData('o', "OptIon", "-o|--opt-ion")]
        internal void Option_ToString(char? shortName, string longName, string expected)
        {
            // Arrange
            var option = new Option {
                ShortName = shortName,
                LongName = longName,
                CultureInfo = CultureInfo.InvariantCulture
            };

            // Act
            var displayName = option.ToString();

            // Assert
            Assert.Equal(expected, displayName);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("v", false)]
        [InlineData("-v", true)]
        [InlineData("version", false)]
        [InlineData("-version", false)]
        [InlineData("--version", true)]
        [InlineData("--v", false)]
        [InlineData("-f", false)]
        [InlineData("--foobar", false)]
        internal void OptionExtensions_IsVersionOption(string value, bool expected)
        {
            Assert.Equal(expected, value.IsVersionOption());
        }

        [Theory]
        [InlineData("option", "option")]
        [InlineData("Option", "option")]
        [InlineData("OptIon", "opt-ion")]
        internal void Positional_Option_ToString(string name, string expected)
        {
            // Arrange
            var option = new Option {
                LongName = name,
                CultureInfo = CultureInfo.InvariantCulture,
                Position = 1
            };

            // Act
            var displayName = option.ToString();

            // Assert
            Assert.Equal(expected, displayName);
        }

        [Theory]
        [InlineData(typeof(int[]))]
        [InlineData(typeof(List<int>))]
        [InlineData(typeof(IList<int>))]
        [InlineData(typeof(IEnumerable<int>))]
        [InlineData(typeof(ICollection<int>))]
        [InlineData(typeof(IReadOnlyCollection<int>))]
        [InlineData(typeof(IReadOnlyList<int>))]
        [InlineData(typeof(Hashtable))]
        [InlineData(typeof(HashSet<int>))]
        [InlineData(typeof(Queue<int>))]
        [InlineData(typeof(Stack<int>))]
        [InlineData(typeof(SortedList<int, int>))]
        [InlineData(typeof(SortedSet<int>))]
        [InlineData(typeof(IEnumerable))]
        [InlineData(typeof(IList))]
        [InlineData(typeof(IDictionary))]
        [InlineData(typeof(IDictionary<int, int>))]
        [InlineData(typeof(ArrayList))]
        internal void TypeExtensions_IsArrayOrCollection(Type value)
        {
            Assert.True(value.IsCollection());
        }

        [Fact]
        internal void ExpressionExtensions_GetPropertyName()
        {
            Assert.Equal("option",
                ((Expression<Func<OneBoolOptionArgs, bool>>)
                    (x => x.Option)).GetPropertyInfos()
                .GetName(CultureInfo.InvariantCulture));

            Assert.Equal("nested.option",
                ((Expression<Func<OneLevelNestedClass, bool>>)
                    (x => x.Nested.Option)).GetPropertyInfos()
                .GetName(CultureInfo.InvariantCulture));

            Assert.Equal("nested-a.nested-b.option",
                ((Expression<Func<TwoLevelNestedClass, bool>>)
                    (x => x.NestedA.NestedB.Option)).GetPropertyInfos()
                .GetName(CultureInfo.InvariantCulture));
        }
    }
}
