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
using System.Collections.Generic;
using System.Globalization;
using ArgsMapper.ValueConversion;
using Xunit;

namespace ArgsMapper.Test
{
    public class ValueConverterFactoryTests
    {
        [Theory]
        [InlineData(typeof(List<bool?>))]
        [InlineData(typeof(List<char?>))]
        [InlineData(typeof(List<decimal?>))]
        [InlineData(typeof(List<double?>))]
        [InlineData(typeof(List<float?>))]
        [InlineData(typeof(List<int?>))]
        [InlineData(typeof(List<long?>))]
        [InlineData(typeof(List<short?>))]
        [InlineData(typeof(List<uint?>))]
        [InlineData(typeof(List<ulong?>))]
        [InlineData(typeof(List<ushort?>))]
        [InlineData(typeof(List<Guid?>))]
        [InlineData(typeof(List<TimeSpan?>))]
        internal void ValueConverterFactory_Convert_ListNullablePrimitiveTypes(Type type)
        {
            Assert.IsType(type, ValueConverterFactory.Convert(
                Array.Empty<string>(), type, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(typeof(List<bool>), "0", "1")]
        [InlineData(typeof(List<char>), "a", "b")]
        [InlineData(typeof(List<decimal>), ".1", ".1")]
        [InlineData(typeof(List<double>), ".0", ".1")]
        [InlineData(typeof(List<float>), ".0", ".1")]
        [InlineData(typeof(List<int>), "0", "1")]
        [InlineData(typeof(List<long>), "0", "1")]
        [InlineData(typeof(List<short>), "0", "1")]
        [InlineData(typeof(List<uint>), "0", "1")]
        [InlineData(typeof(List<ulong>), "0", "1")]
        [InlineData(typeof(List<ushort>), "0", "1")]
        [InlineData(typeof(List<Guid>), "319dae9f5f2f4846a8d5789e01f5b7e2", "11470f068e8c4052ad54e3d3e5cccf6c")]
        [InlineData(typeof(List<TimeSpan>), "6.12:14:45", "6:12:14:45")]
        internal void ValueConverterFactory_Convert_ListPrimitiveTypes(Type type, params string[] values)
        {
            Assert.IsType(type, ValueConverterFactory.Convert(
                values, type, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(typeof(bool?))]
        [InlineData(typeof(char?))]
        [InlineData(typeof(decimal?))]
        [InlineData(typeof(double?))]
        [InlineData(typeof(float?))]
        [InlineData(typeof(int?))]
        [InlineData(typeof(long?))]
        [InlineData(typeof(short?))]
        [InlineData(typeof(uint?))]
        [InlineData(typeof(ulong?))]
        [InlineData(typeof(ushort?))]
        [InlineData(typeof(Guid?))]
        [InlineData(typeof(TimeSpan?))]
        internal void ValueConverterFactory_Convert_NullablePrimitiveTypes(Type type)
        {
            Assert.Null(ValueConverterFactory.Convert(
                Array.Empty<string>(), type, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(typeof(bool), "0")]
        [InlineData(typeof(bool), "1")]
        [InlineData(typeof(bool), "on")]
        [InlineData(typeof(bool), "off")]
        [InlineData(typeof(bool), "true")]
        [InlineData(typeof(bool), "false")]
        [InlineData(typeof(char), "a")]
        [InlineData(typeof(decimal), "0")]
        [InlineData(typeof(double), "0")]
        [InlineData(typeof(float), "0")]
        [InlineData(typeof(int), "0")]
        [InlineData(typeof(long), "0")]
        [InlineData(typeof(short), "0")]
        [InlineData(typeof(string), "foobar")]
        [InlineData(typeof(uint), "0")]
        [InlineData(typeof(ulong), "0")]
        [InlineData(typeof(ushort), "0")]
        [InlineData(typeof(Guid), "aa13a8b4-be17-4932-8af0-08b84accd971")]
        [InlineData(typeof(Guid), "4DFF9BAACA3E4FA38A1B75B289389227")]
        [InlineData(typeof(TimeSpan), "6")]
        [InlineData(typeof(TimeSpan), "6:12")]
        [InlineData(typeof(TimeSpan), "6.12:14:45")]
        [InlineData(typeof(TimeSpan), "6:12:14:45.3448")]
        internal void ValueConverterFactory_Convert_PrimitiveTypes(Type type, string value)
        {
            Assert.IsType(type, ValueConverterFactory.Convert(
                new[] { value }, type, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData(typeof(bool), "invalid-value")]
        [InlineData(typeof(char), "invalid-value")]
        [InlineData(typeof(decimal), "invalid-value")]
        [InlineData(typeof(double), "invalid-value")]
        [InlineData(typeof(float), "invalid-value")]
        [InlineData(typeof(int), "2147483648")]
        [InlineData(typeof(long), "invalid-value")]
        [InlineData(typeof(short), "invalid-value")]
        [InlineData(typeof(uint), "invalid-value")]
        [InlineData(typeof(ulong), "invalid-value")]
        [InlineData(typeof(ushort), "invalid-value")]
        [InlineData(typeof(Guid), "invalid-value")]
        [InlineData(typeof(TimeSpan), "invalid-value")]
        internal void ValueConverterFactory_Convert_Should_Throw_Exception(Type type, params string[] values)
        {
            Assert.ThrowsAny<Exception>(() => ValueConverterFactory.Convert(
                values, type, CultureInfo.InvariantCulture));
        }
    }
}
