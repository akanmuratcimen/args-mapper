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

using System.Linq;
using System.Runtime.CompilerServices;
using ArgsMapper.Models;

namespace ArgsMapper.Utilities
{
    internal static class ArgsExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string AddShortNamePrefix(this string value)
        {
            return Constants.OptionShortNamePrefix + value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string AddShortNamePrefix(this char value)
        {
            return Constants.OptionShortNamePrefix + value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string AddLongNamePrefix(this string value)
        {
            return Constants.OptionLongNamePrefix + value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static OptionMatchType GetOptionMatchType(this string value)
        {
            switch (GetOptionPrefix(value))
            {
                case Constants.OptionShortNamePrefix:
                    return OptionMatchType.ByShortName;

                case Constants.OptionLongNamePrefix:
                    return OptionMatchType.ByLongName;

                default:
                    return OptionMatchType.None;
            }
        }

        private static string GetOptionPrefix(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            if (value[0] != '-')
            {
                return null;
            }

            if (value.Length > 1 && value[1] == '-')
            {
                return Constants.OptionLongNamePrefix;
            }

            return Constants.OptionShortNamePrefix;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsAssignmentOperator(this string value)
        {
            return value.Length == 1 && Constants.AssignmentOperators.Contains(value[0]);
        }

        internal static bool IsNullOrEmpty(this string[] args)
        {
            if (args is null || args.Length == 0)
            {
                return true;
            }

            foreach (var arg in args)
            {
                if (!string.IsNullOrEmpty(arg))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool IsValidOption(this string value)
        {
            var prefix = GetOptionPrefix(value);

            if (prefix is null)
            {
                return false;
            }

            if (value.Length == prefix.Length)
            {
                return false;
            }

            switch (prefix)
            {
                case "-" when value.Length != 2:
                case "-" when char.IsDigit(value[1]):
                    return false;

                default:
                    return true;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string RemoveOptionPrefix(this string value)
        {
            return RemovePrefix(value, GetOptionPrefix(value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string RemovePrefix(string value, string prefix)
        {
            return prefix is null ? value : value.Remove(0, prefix.Length);
        }

        internal static bool IsReservedOptionLongName(this string value)
        {
            return Constants.ReservedOptionLongNames.Contains(value);
        }

        internal static bool IsReservedOptionShortName(this char value)
        {
            return Constants.ReservedOptionShortNames.Contains(value);
        }
    }
}
