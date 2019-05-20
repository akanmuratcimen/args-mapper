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
        private const string Indent = "  ";
        private readonly IList<Content> _contents;
        private readonly StringBuilder _stringBuilder;

        public ContentFormatter(IList<Content> contents)
        {
            _contents = contents;
            _stringBuilder = new StringBuilder();
        }

        public override string ToString()
        {
            foreach (var content in _contents)
            {
                var columnLengths = GetColumnLengths(content.Values, TableColumnPadding);
                var formattedValues = Format(content.Style, content.Values, columnLengths);

                foreach (var formattedValue in formattedValues)
                {
                    _stringBuilder.AppendLine(formattedValue);
                }
            }

            return _stringBuilder.TrimEnd().ToString();
        }

        private static IEnumerable<string> Format(FormattingStyle style,
            IEnumerable<IReadOnlyList<string>> values, IReadOnlyList<int> columnSizes)
        {
            foreach (var row in values)
            {
                var stringBuilder = new StringBuilder();

                switch (style)
                {
                    case FormattingStyle.Indent:
                        stringBuilder.Append(Indent);

                        break;
                }

                for (var i = 0; i < row.Count; i++)
                {
                    if (i == row.Count - 1)
                    {
                        stringBuilder.Append(row[i]);

                        continue;
                    }

                    stringBuilder.AppendFormat($"{{0,{columnSizes[i] * -1}}}", row[i]);
                }

                yield return stringBuilder.ToString();
            }
        }

        internal static IReadOnlyList<int> GetColumnLengths(
            IEnumerable<IReadOnlyList<string>> values, int padding)
        {
            int[] lengths = null;

            foreach (var row in values)
            {
                lengths = lengths ?? new int[row.Count];

                for (var i = 0; i < row.Count; i++)
                {
                    if (string.IsNullOrEmpty(row[i]))
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
    }
}
