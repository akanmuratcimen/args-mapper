﻿// The MIT License (MIT)
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

namespace ArgsMapper.Utilities
{
    internal static class CollectionExtensions
    {
        internal static void AddOrMergeValues<TKey, TValue>(
            this IDictionary<TKey, List<TValue>> dictionary,
            TKey key, List<TValue> values)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key].AddRange(values);
                return;
            }

            dictionary.Add(key, values);
        }

        internal static int GetMaxLength(this IEnumerable<string> values)
        {
            var result = 0;

            foreach (var value in values)
            {
                if (value.Length > result)
                {
                    result = value.Length;
                }
            }

            return result;
        }

        internal static string ToSeparatedString(this IEnumerable<string> values, string separator)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return string.Join(separator, values);
        }

        internal static string ToCommaSeparatedString(this IEnumerable<string> values)
        {
            return values.ToSeparatedString(", ");
        }
    }
}
