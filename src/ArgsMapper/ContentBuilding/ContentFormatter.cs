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
using System.Text;
using ArgsMapper.Utilities;

namespace ArgsMapper.ContentBuilding
{
    internal interface IContentFormatter
    {
        string ToString();
    }

    internal class ContentFormatter : IContentFormatter
    {
        private const int TableColumnPadding = 4;
        private readonly IList<Content> _contents;
        private readonly int _lineLengthLimit;
        private readonly StringBuilder _stringBuilder;

        public ContentFormatter(IList<Content> contents, int lineLengthLimit)
        {
            _contents = contents;
            _lineLengthLimit = lineLengthLimit;
            _stringBuilder = new StringBuilder();
        }

        public override string ToString()
        {
            foreach (var content in _contents)
            {
                var columnLengths = GetColumnLengths(content.Values, TableColumnPadding);
                var formattedValues = Format(content.Values, columnLengths);

                foreach (var formattedValue in formattedValues)
                {
                    _stringBuilder.AppendLine(formattedValue);
                }
            }

            return _stringBuilder.TrimEnd().ToString();
        }

        private static IEnumerable<string> Format(IEnumerable<IReadOnlyList<string>> values,
            IReadOnlyList<int> columnSizes)
        {
            foreach (var row in values)
            {
                var stringBuilder = new StringBuilder();

                for (var i = 0; i < row.Count; i++)
                {
                    stringBuilder.Append(PadRight(row[i], columnSizes[i]));
                }

                yield return stringBuilder.ToString();
            }
        }

        internal static IReadOnlyList<int> GetColumnLengths(IEnumerable<IReadOnlyList<string>> values, int padding)
        {
            int[] lengths = null;

            foreach (var row in values)
            {
                lengths = lengths ?? new int[row.Count];

                for (var i = 0; i < row.Count; i++)
                {
                    if (row[i] == null)
                    {
                        continue;
                    }

                    lengths[i] = Math.Max(row[i].Length, lengths[i]);
                }
            }

            if (lengths == null)
            {
                return null;
            }

            for (var i = 0; i < lengths.Length - 1; i++)
            {
                lengths[i] += padding;
            }

            return lengths;
        }

        private static string PadRight(string value, int length)
        {
            return value == null ? new string(' ', length) : value.PadRight(length);
        }
    }
}
