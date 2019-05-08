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

using ArgsMapper.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using ArgsMapper.Models;
using Xunit;

namespace ArgsMapper.Tests
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

        [Fact]
        internal void OptionListExtensions_Get_Should_Return_Null()
        {
            // Arrange
            var options = new List<Option> {
                new Option()
            };

            // Act
            var option = options.Get(OptionMatchType.None, "option", 
                StringComparison.InvariantCultureIgnoreCase);

            // Assert
            Assert.Null(option);
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

        [Fact]
        internal void ArgsExtensions_GetOptionMatchType_Should_Return_None()
        {
            Assert.Equal(OptionMatchType.None, "foobar".GetOptionMatchType());
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
        [InlineData(typeof(List<string>), typeof(string))]
        [InlineData(typeof(char?), typeof(char))]
        [InlineData(typeof(SampleEnum), typeof(Enum))]
        [InlineData(typeof(int), typeof(int))]
        internal void TypeExtensions_GetBaseType(Type type, Type expectedType)
        {
            Assert.Equal(expectedType, type.GetBaseType());
        }

        [Theory]
        [InlineData(typeof(IList<string>), typeof(string))]
        [InlineData(typeof(IDictionary<int, string>), typeof(int))]
        [InlineData(typeof(Queue<long>), typeof(long))]
        [InlineData(typeof(string), null)]
        internal void TypeExtensions_GetFirstGenericArgument(Type genericType, Type expectedType)
        {
            Assert.Equal(expectedType, genericType.GetFirstGenericArgument());
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

            Assert.Throws<ArgumentException>(() =>
                ((Expression<Func<OneBoolFieldOptionArgs, bool>>)
                    (x => x.Option)).GetPropertyInfos()
                .GetName(CultureInfo.InvariantCulture));
        }
    }
}
