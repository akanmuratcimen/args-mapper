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

using System.Text;

namespace ArgsMapper.ContentBuilding
{
    internal interface IContentRenderer
    {
        void AppendContent(params string[] contents);
        void AppendSection(string header, string sectionString);
        void AppendOption(string optionString, string description);
        void AppendCommand(string commandString, string description);
        string ToString();
    }

    internal class ContentRenderer : IContentRenderer
    {
        private readonly int _maxWidth;
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public ContentRenderer(int maxWidth)
        {
            _maxWidth = maxWidth;
        }

        public int MaxWidth { get; set; }

        public void AppendContent(params string[] contents)
        {
            _stringBuilder.Append("");
        }

        public void AppendSection(string header, string sectionString)
        {
            _stringBuilder.Append("");
        }

        public void AppendOption(string optionString, string description)
        {
            _stringBuilder.Append("");
        }

        public void AppendCommand(string commandString, string description)
        {
            _stringBuilder.Append("");
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
