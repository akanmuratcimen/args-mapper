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
using ArgsMapper.ValueConversion;

namespace ArgsMapper.Utilities
{
    internal static class TypeExtensions
    {
        internal static Type GetBaseType(this Type type)
        {
            if (type.IsList())
            {
                var genericArgument = type.GetFirstGenericArgument();

                if (genericArgument.IsNullable())
                {
                    return Nullable.GetUnderlyingType(genericArgument);
                }

                return genericArgument;
            }

            if (type.IsNullable())
            {
                return Nullable.GetUnderlyingType(type);
            }

            return type;
        }

        internal static Type GetFirstGenericArgument(this Type type)
        {
            if (!type.IsGenericType)
            {
                return null;
            }

            return type.GetGenericArguments()[0];
        }

        internal static bool IsBaseSupported(this Type type)
        {
            return ValueConverters.SupportedTypes.Contains(type.GetBaseType());
        }

        internal static bool IsCollection(this Type type)
        {
            return
                typeof(ICollection).IsAssignableFrom(type) ||
                typeof(ICollection<>).IsAssignableFrom(type) ||
                typeof(IEnumerable).IsAssignableFrom(type) ||
                typeof(IEnumerable<>).IsAssignableFrom(type);
        }

        internal static bool IsList(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        internal static bool IsNullable(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        internal static bool IsSupported(this Type type)
        {
            return ValueConverters.SupportedTypes.Contains(type);
        }
    }
}
