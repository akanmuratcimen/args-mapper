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
using System.Linq;
using ArgsMapper.Utilities;

namespace ArgsMapper.ValueConversion
{
    internal class ValueConverterFactory
    {
        internal static object Convert(IList<string> values, Type type, CultureInfo cultureInfo)
        {
            if (type.IsList())
            {
                return CreateListWithValues(type.GetFirstGenericArgument(), values, cultureInfo);
            }

            var value = values.Count > 1 ? values.LastOrDefault() : values.FirstOrDefault();

            if (type.IsNullable() && string.IsNullOrEmpty(value))
            {
                return null;
            }

            return ValueConverters.Converters[type.GetBaseType()].Convert(value, cultureInfo);
        }

        private static IList CreateListWithValues(Type itemType, IEnumerable<string> values, CultureInfo cultureInfo)
        {
            var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType));
            var converter = ValueConverters.Converters[itemType.GetBaseType()];

            foreach (var value in values)
            {
                list.Add(converter.Convert(value, cultureInfo));
            }

            return list;
        }
    }
}
