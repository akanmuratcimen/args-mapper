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

using System.Collections.Generic;

namespace ArgsMapper
{
    internal static class Constants
    {
        internal const string OptionShortNamePrefix = "-";
        internal const string OptionLongNamePrefix = "--";

        internal static readonly char[] AssignmentOperators = { '=', ':', ' ' };

        internal static char[] HelpOptionAliases = { '?', 'h' };
        internal static string[] HelpOptionNames = { "help" };
        internal static readonly string HelpOptionString = "-h|--help";

        internal static readonly char[] VersionOptionShortNames = { 'v' };
        internal static readonly string[] VersionOptionLongNames = { "version" };
        internal static readonly string VersionOptionString = "-v|--version";

        internal static IEnumerable<char> ReservedOptionShortNames
        {
            get
            {
                foreach (var shortName in VersionOptionShortNames)
                {
                    yield return shortName;
                }
            }
        }

        internal static IEnumerable<string> ReservedOptionLongNames
        {
            get
            {
                foreach (var longName in VersionOptionLongNames)
                {
                    yield return longName;
                }
            }
        }
    }
}
