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
using System.Linq;
using System.Runtime.CompilerServices;

namespace ArgsMapper.ValueConversion.Converters
{
    internal class BoolValueConverter : ISystemTypeValueConverter
    {
        private static readonly string[] FalseValues = { "0", "off", "false" };
        private static readonly string[] TrueValues = { null, string.Empty, "1", "on", "true" };

        public object Convert(string value, IFormatProvider formatProvider)
        {
            if (IsValidTrueValue(value))
            {
                return true;
            }

            if (IsValidFalseValue(value))
            {
                return false;
            }

            throw new FormatException("String was not recognized as a valid Boolean.");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsValidFalseValue(string value)
        {
            return FalseValues.Contains(value, StringComparer.InvariantCultureIgnoreCase);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsValidTrueValue(string value)
        {
            return TrueValues.Contains(value, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
