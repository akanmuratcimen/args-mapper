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

namespace ArgsMapper.ContentBuilding
{
    internal class Content
    {
        internal Content(ContentType type, params (string, string, string, string, string, string)[] values)
        {
            Type = type;
            ColumnSize = 6;
            Values = values;
        }

        internal Content(ContentType type, params (string, string)[] values)
        {
            Type = type;
            ColumnSize = 2;
            Values = values.Select(x => (x.Item1, x.Item2, (string)null, (string)null, (string)null, (string)null));
        }

        internal Content(ContentType type, params string[] values)
        {
            Type = type;
            ColumnSize = 1;
            Values = values.Select(x => (x, (string)null, (string)null, (string)null, (string)null, (string)null));
        }

        internal Content(ContentType type, params (string, string, string)[] values)
        {
            Type = type;
            ColumnSize = 3;
            Values = values.Select(x => (x.Item1, x.Item2, x.Item3, (string)null, (string)null, (string)null));
        }

        internal Content(ContentType type, params (string, string, string, string)[] values)
        {
            Type = type;
            ColumnSize = 4;
            Values = values.Select(x => (x.Item1, x.Item2, x.Item3, x.Item4, (string)null, (string)null));
        }

        internal Content(ContentType type, params (string, string, string, string, string)[] values)
        {
            Type = type;
            ColumnSize = 5;
            Values = values.Select(x => (x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, (string)null));
        }

        internal ContentType Type { get; }
        internal IEnumerable<(string, string, string, string, string, string)> Values { get; }
        internal int ColumnSize { get; }
    }
}
