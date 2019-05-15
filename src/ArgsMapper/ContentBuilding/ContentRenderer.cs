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
using System.Text;
using ArgsMapper.Utilities;

namespace ArgsMapper.ContentBuilding
{
    internal class ContentRenderer : IContentRenderer
    {
        private const int IndentSize = 2;
        private readonly int _maxWidth;
        private readonly StringBuilder _stringBuilder;

        public ContentRenderer(int maxWidth)
        {
            _maxWidth = maxWidth;
            _stringBuilder = new StringBuilder();
        }

        public void AppendContent(params string[] contents)
        {
            foreach (var content in contents)
            {
                _stringBuilder.AppendLine(content);
            }
        }

        public void AppendTable(params (string column1, string column2)[] columns)
        {
            foreach (var (column1, column2) in columns)
            {
                _stringBuilder.Append(column1);
                _stringBuilder.Append(column2);
                _stringBuilder.AppendNewLine();
            }
        }

        public void AppendTable(params (string column1, string column2, string column3)[] columns)
        {
            foreach (var (column1, column2, column3) in columns)
            {
                _stringBuilder.Append(column1);
                _stringBuilder.Append(column2);
                _stringBuilder.Append(column3);
                _stringBuilder.AppendNewLine();
            }
        }

        public void AppendTable(params (string column1, string column2, string column3,
            string column4)[] columns)
        {
            foreach (var (column1, column2, column3, column4) in columns)
            {
                _stringBuilder.Append(column1);
                _stringBuilder.Append(column2);
                _stringBuilder.Append(column3);
                _stringBuilder.Append(column4);
                _stringBuilder.AppendNewLine();
            }
        }

        public void AppendTable(params (string column1, string column2, string column3,
            string column4, string column5)[] columns)
        {
            foreach (var (column1, column2, column3, column4, column5) in columns)
            {
                _stringBuilder.Append(column1);
                _stringBuilder.Append(column2);
                _stringBuilder.Append(column3);
                _stringBuilder.Append(column4);
                _stringBuilder.Append(column5);
                _stringBuilder.AppendNewLine();
            }
        }

        public void AppendTable(params (string column1, string column2, string column3,
            string column4, string column5, string column6)[] columns)
        {
            foreach (var (column1, column2, column3, column4, column5, column6) in columns)
            {
                _stringBuilder.Append(column1);
                _stringBuilder.Append(column2);
                _stringBuilder.Append(column3);
                _stringBuilder.Append(column4);
                _stringBuilder.Append(column5);
                _stringBuilder.Append(column6);
                _stringBuilder.AppendNewLine();
            }
        }

        public void AppendSection(string header, string sectionString)
        {
            _stringBuilder.AppendLine(header);

            foreach (var line in sectionString.Split(Environment.NewLine))
            {
                _stringBuilder.Append(' ', IndentSize);
                _stringBuilder.Append(line);
                _stringBuilder.AppendNewLine();
            }
        }

        public void AppendOption(string optionString, string description)
        {
            _stringBuilder.AppendLine($"{optionString,-18} {description,-62}");
        }

        public void AppendCommand(string commandString, string description)
        {
            _stringBuilder.AppendLine($"{commandString,-18} {description,-62}");
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
