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
using System.Linq;
using ArgsMapper.Models;

namespace ArgsMapper.Utilities
{
    internal static class OptionListExtensions
    {
        internal static Option Get(this IEnumerable<Option> options,
            OptionMatchType matchType, string key, StringComparison stringComparison)
        {
            switch (matchType)
            {
                case OptionMatchType.ByShortName:
                    return options.GetByShortName(key);

                case OptionMatchType.ByLongName:
                    return options.GetByLongName(key, stringComparison);

                default:
                    return null;
            }
        }

        internal static Option GetByShortName(this IEnumerable<Option> options, string key)
        {
            return GetByShortName(options, char.Parse(key));
        }

        internal static Option GetByShortName(this IEnumerable<Option> options, char key)
        {
            return options.FirstOrDefault(x => x.ShortName == key);
        }

        internal static Option GetByLongName(this IEnumerable<Option> options,
            string key, StringComparison stringComparison)
        {
            return options.FirstOrDefault(x => string.Equals(x.LongName, key, stringComparison));
        }

        internal static Option GetByPosition(this IEnumerable<Option> options, short position)
        {
            return options.FirstOrDefault(x => x.Position == position);
        }

        internal static ushort GetNextPositionalOptionPosition(this IEnumerable<Option> options)
        {
            ushort result = 0;

            foreach (var option in options)
            {
                if (option.IsPositionalOption)
                {
                    result++;
                }
            }

            return result;
        }

        internal static bool HasPositionalOption(this IEnumerable<Option> options)
        {
            return options.Any(x => x.IsPositionalOption);
        }
    }
}
