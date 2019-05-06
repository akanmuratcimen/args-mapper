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
using System.Linq;
using ArgsMapper.Utilities;
using ArgsMapper.ValueConversion.Converters;

namespace ArgsMapper.ValueConversion
{
    internal interface IValueConverterFactory
    {
        HashSet<Type> SupportedTypes { get; }
        object Convert(IList<string> values, Type type, IFormatProvider formatProvider);
        bool IsSupportedBaseType(Type type);
        bool IsSupportedType(Type type);
    }

    internal class ValueConverterFactory : IValueConverterFactory
    {
        internal ValueConverterFactory()
        {
            Converters = new Dictionary<Type, IValueConverter> {
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
                [typeof(string)] = new StringValueConverter(),
                [typeof(Guid)] = new GuidValueConverter(),
                [typeof(TimeSpan)] = new TimeSpanValueConverter(),
                [typeof(DateTime)] = new DateTimeValueConverter(),
                [typeof(Uri)] = new UriValueConverter()
            };
        }

        private IDictionary<Type, IValueConverter> Converters { get; }

        public HashSet<Type> SupportedTypes => new HashSet<Type>(Converters.Keys);

        public object Convert(IList<string> values, Type type, IFormatProvider formatProvider)
        {
            if (type.IsList())
            {
                return CreateListWithValues(type.GetFirstGenericArgument(), values, formatProvider);
            }

            var value = values.Count > 1 ? values.LastOrDefault() : values.FirstOrDefault();

            if (type.IsNullable() && string.IsNullOrEmpty(value))
            {
                return null;
            }

            return Converters[type.GetBaseType()].Convert(value, formatProvider);
        }

        private IList CreateListWithValues(Type itemType, IEnumerable<string> values,
            IFormatProvider formatProvider)
        {
            var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType));
            var converter = Converters[itemType.GetBaseType()];

            foreach (var value in values)
            {
                list.Add(converter.Convert(value, formatProvider));
            }

            return list;
        }

        public bool IsSupportedBaseType(Type type)
        {
            return SupportedTypes.Contains(type.GetBaseType());
        }

        public bool IsSupportedType(Type type)
        {
            return SupportedTypes.Contains(type);
        }
    }
}
