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

namespace ArgsMapper.Utilities
{
    internal static class StringBuilderExtensions
    {
        internal static StringBuilder TrimEnd(this StringBuilder stringBuilder)
        {
            if (stringBuilder == null || stringBuilder.Length == 0)
            {
                return stringBuilder;
            }

            var i = stringBuilder.Length - 1;

            for (; i >= 0; i--)
            {
                if (!char.IsWhiteSpace(stringBuilder[i]))
                {
                    break;
                }
            }

            if (i < stringBuilder.Length - 1)
            {
                stringBuilder.Length = i + 1;
            }

            return stringBuilder;
        }
    }
}
