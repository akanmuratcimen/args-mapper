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

namespace ArgsMapper.ContentBuilding
{
    internal class ContentRenderer : IContentRenderer
    {
        private readonly IContentFormatter _contentFormatter;
        private readonly IList<Content> Contents = new List<Content>();

        public ContentRenderer(int lineLengthLimit)
        {
            _contentFormatter = new ContentFormatter(Contents, lineLengthLimit);
        }

        public void AppendContent(params string[] contents)
        {
            foreach (var content in contents)
            {
                Contents.Add(new Content(ContentColumnType.Content,
                    (content, null, null, null, null, null)));
            }
        }

        public void AppendTable(params (string column1, string column2)[] columns)
        {
            foreach (var (column1, column2) in columns)
            {
                Contents.Add(new Content(ContentColumnType.Content,
                    (column1, column2, null, null, null, null)));
            }
        }

        public void AppendTable(params (string column1, string column2, string column3)[] columns)
        {
            foreach (var (column1, column2, column3) in columns)
            {
                Contents.Add(new Content(ContentColumnType.Content,
                    (column1, column2, column3, null, null, null)));
            }
        }

        public void AppendTable(params (string column1, string column2, string column3,
            string column4)[] columns)
        {
            foreach (var (column1, column2, column3, column4) in columns)
            {
                Contents.Add(new Content(ContentColumnType.Content,
                    (column1, column2, column3, column4, null, null)));
            }
        }

        public void AppendTable(params (string column1, string column2, string column3,
            string column4, string column5)[] columns)
        {
            foreach (var (column1, column2, column3, column4, column5) in columns)
            {
                Contents.Add(new Content(ContentColumnType.Content,
                    (column1, column2, column3, column4, column5, null)));
            }
        }

        public void AppendTable(params (string column1, string column2, string column3,
            string column4, string column5, string column6)[] columns)
        {
            foreach (var (column1, column2, column3, column4, column5, column6) in columns)
            {
                Contents.Add(new Content(ContentColumnType.Content,
                    (column1, column2, column3, column4, column5, column6)));
            }
        }

        public void AppendSection(string header, string sectionString)
        {
            Contents.Add(new Content(ContentColumnType.Header,
                (header, null, null, null, null, null)));

            Contents.Add(new Content(ContentColumnType.Section,
                (sectionString, null, null, null, null, null)));
        }

        public void AppendProperty(string name, string description)
        {
            Contents.Add(new Content(ContentColumnType.Property,
                (name, description, null, null, null, null)));
        }

        public override string ToString()
        {
            return _contentFormatter.ToString();
        }
    }
}
