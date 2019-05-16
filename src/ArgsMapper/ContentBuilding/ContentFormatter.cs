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
using System.Linq;
using System.Text;

namespace ArgsMapper.ContentBuilding
{
    internal interface IContentFormatter
    {
        string ToString();
    }

    internal class ContentFormatter : IContentFormatter
    {
        private const int IndentSize = 2;
        private readonly IList<Content> _contents;
        private readonly int _maxLength;
        private readonly StringBuilder _stringBuilder;

        public ContentFormatter(IList<Content> contents, int maxLength)
        {
            _contents = contents;
            _maxLength = maxLength;
            _stringBuilder = new StringBuilder();
        }

        private int MaxPropertyColumnLength
        {
            get
            {
                return _contents
                    .Where(x => x.ContentColumnType == ContentColumnType.Property)
                    .SelectMany(x => x.Values).DefaultIfEmpty().Max(x => x.Item1.Length);
            }
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
