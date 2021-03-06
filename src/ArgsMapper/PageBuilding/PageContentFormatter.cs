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
using System.Collections.Generic;
using System.Text;
using ArgsMapper.Utilities;

namespace ArgsMapper.PageBuilding
{
    internal interface IPageContentFormatter
    {
        string ToString();
    }

    internal class PageContentFormatter : IPageContentFormatter
    {
        private const int TableColumnPadding = 2;
        private const int IndentSize = 2;
        private readonly IList<PageContent> _contents;
        private readonly StringBuilder _stringBuilder;

        public PageContentFormatter(IList<PageContent> contents)
        {
            _contents = contents;
            _stringBuilder = new StringBuilder();
        }

        public override string ToString()
        {
            foreach (var content in _contents)
            {
                var definedWidths = PrepareColumnWidths(content.ColumnSize, content.ColumnSettings);
                var columnLengths = GetColumnLengths(content.Values, definedWidths, TableColumnPadding);
                var formattedValues = Format(content.Style, content.Values, columnLengths);

                foreach (var formattedValue in formattedValues)
                {
                    _stringBuilder.AppendLine(formattedValue);
                }
            }

            if (_stringBuilder.Length == 0)
            {
                return string.Empty;
            }

            return _stringBuilder.TrimEnd().AppendLine().ToString();
        }

        private static IEnumerable<string> Format(PageContentRowFormattingStyle style,
            IEnumerable<IReadOnlyList<string>> values, IReadOnlyList<int> columnLengths)
        {
            foreach (var row in values)
            {
                var stringBuilder = new StringBuilder();

                switch (style)
                {
                    case PageContentRowFormattingStyle.Indent:
                        stringBuilder.Append(' ', IndentSize);

                        break;
                }

                for (var i = 0; i < row.Count; i++)
                {
                    if (i == row.Count - 1)
                    {
                        stringBuilder.Append(row[i]);

                        continue;
                    }

                    stringBuilder.AppendFormat($"{{0,{columnLengths[i] * -1}}}", row[i]);
                }

                yield return stringBuilder.ToString();
            }
        }

        private static int[] PrepareColumnWidths(int columnLength,
            IReadOnlyList<PageContentColumnSettings> columnSettings)
        {
            var result = new int[columnLength];

            if (columnSettings == null)
            {
                return result;
            }

            for (var i = 0; i < columnLength; i++)
            {
                result[i] = i > columnSettings.Count - 1 ? 0 : columnSettings[i].Width;
            }

            return result;
        }

        internal static IReadOnlyList<int> GetColumnLengths(
            IEnumerable<IReadOnlyList<string>> values,
            int[] lengths, int padding)
        {
            foreach (var row in values)
            {
                for (var i = 0; i < row.Count; i++)
                {
                    if (string.IsNullOrEmpty(row[i]))
                    {
                        continue;
                    }

                    lengths[i] = Math.Max(row[i].Length, lengths[i]);
                }
            }

            for (var i = 0; i < lengths.Length - 1; i++)
            {
                lengths[i] += padding;
            }

            return lengths;
        }
    }
}
