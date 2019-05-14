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

namespace ArgsMapper.Usage
{
    internal static class UsageScreenFormatter
    {
        internal static StringBuilder AppendContent(this StringBuilder stringBuilder, 
            int maxWidth, params string[] contents)
        {
            return stringBuilder;
        }

        internal static StringBuilder AppendSection(this StringBuilder stringBuilder, 
            int maxWidth, string header, StringBuilder sectionStringBuilder)
        {
            return stringBuilder;
        }

        internal static StringBuilder AppendOption(this StringBuilder stringBuilder,
            int maxWidth, string optionString, string description)
        {
            return stringBuilder;
        }

        internal static StringBuilder AppendCommand(this StringBuilder stringBuilder,
            int maxWidth, string commandString, string description)
        {
            return stringBuilder;
        }
    }
}
