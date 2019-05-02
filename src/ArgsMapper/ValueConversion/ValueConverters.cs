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
using ArgsMapper.ValueConversion.Converters;

namespace ArgsMapper.ValueConversion
{
    internal class ValueConverters
    {
        internal static HashSet<Type> SupportedTypes = new HashSet<Type>(Converters.Keys);

        internal static IDictionary<Type, IValueConverter> Converters => new Dictionary<Type, IValueConverter> {
            [typeof(char)] = new CharValueConverter(),
            [typeof(bool)] = new BoolValueConverter(),
            [typeof(short)] = new ShortValueConverter(),
            [typeof(ushort)] = new UShortValueConverter(),
            [typeof(int)] = new IntValueConverter(),
            [typeof(uint)] = new UIntValueConverter(),
            [typeof(long)] = new LongValueConverter(),
            [typeof(ulong)] = new ULongValueConverter(),
            [typeof(float)] = new FloatValueConverter(),
            [typeof(double)] = new DoubleValueConverter(),
            [typeof(decimal)] = new DecimalValueConverter(),
            [typeof(string)] = new StringValueConverter()
        };
    }
}
