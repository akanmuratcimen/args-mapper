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
                var columnSizes = GetColumnSizes(content.Values);
                var formattedValues = Format(content.Values, columnSizes);

                foreach (var formattedValue in formattedValues)
                {
                    _stringBuilder.AppendLine(formattedValue);
                }
            }

            return _stringBuilder.TrimEnd().ToString();
        }

        private static IEnumerable<string> Format(IEnumerable<IReadOnlyList<string>> contents,
            IReadOnlyList<int> columnSizes)
        {
            foreach (var content in contents)
            {
                var stringBuilder = new StringBuilder();

                for (var i = 0; i < content.Count; i++)
                {
                    stringBuilder.Append(PadRight(content[i], columnSizes[i]));
                }

                yield return stringBuilder.ToString();
            }
        }

        private static string PadRight(string value, int length)
        {
            if (value == null)
            {
                return new string(' ', length);
            }

            return value.PadRight(length);
        }

        private static IReadOnlyList<int> GetColumnSizes(IEnumerable<IReadOnlyList<string>> contents)
        {
            return new[] { 80 / 6, 80 / 6, 80 / 6, 80 / 6, 80 / 6, 80 / 6 };
        }
    }
}
