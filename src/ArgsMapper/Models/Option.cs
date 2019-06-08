/**
 * The MIT License (MIT)
 * 
 * Copyright (c) 2019 Akan Murat Cimen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
 * the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Globalization;
using System.Reflection;
using ArgsMapper.Utilities;

namespace ArgsMapper.Models
{
    internal class Option
    {
        internal char? ShortName { get; set; }
        internal CultureInfo CultureInfo { get; set; }
        internal object DefaultValue { get; set; }
        internal bool HasShortName => ShortName.HasValue;
        internal bool IsDisabled { get; set; }
        internal bool IsPositionalOption => Position.HasValue;
        internal bool IsRequired { get; set; }
        internal string LongName { get; set; }
        internal int? Position { get; set; }
        internal PropertyInfo PropertyInfo => PropertyInfos[PropertyInfos.Length - 1];
        internal PropertyInfo[] PropertyInfos { get; set; }
        internal Type Type => PropertyInfo.PropertyType;

        public override string ToString()
        {
            if (IsPositionalOption)
            {
                return LongName.ToHyphenCase(CultureInfo);
            }

            var name = LongName.ToHyphenCase(CultureInfo).AddLongNamePrefix();

            if (!ShortName.HasValue)
            {
                return name;
            }

            return ShortName.Value.AddShortNamePrefix() + "|" + name;
        }
    }
}
