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

        public ContentRenderer(int lineLengthLimit = Constants.DefaultContentBuilderLineLengthLimit)
        {
            _contentFormatter = new ContentFormatter(Contents, lineLengthLimit);
        }

        public void AppendContent(params string[] contents)
        {
            Contents.Add(new Content(ContentType.Text, contents));
        }

        public void AppendTable(params (string, string)[] columns)
        {
            Contents.Add(new Content(ContentType.Table, columns));
        }

        public void AppendTable(params (string, string, string)[] columns)
        {
            Contents.Add(new Content(ContentType.Table, columns));
        }

        public void AppendTable(params (string, string, string, string)[] columns)
        {
            Contents.Add(new Content(ContentType.Table, columns));
        }

        public void AppendTable(params (string, string, string, string, string)[] columns)
        {
            Contents.Add(new Content(ContentType.Table, columns));
        }

        public void AppendTable(params (string, string, string, string, string, string)[] columns)
        {
            Contents.Add(new Content(ContentType.Table, columns));
        }

        public void AppendSection(string header, string sectionString)
        {
            Contents.Add(new Content(ContentType.Header, header));
            Contents.Add(new Content(ContentType.Section, sectionString));
        }

        public void AppendProperty(string name, string description)
        {
            Contents.Add(new Content(ContentType.Property, (name, description)));
        }

        public override string ToString()
        {
            return _contentFormatter.ToString();
        }
    }
}
