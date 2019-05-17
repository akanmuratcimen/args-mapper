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
using ArgsMapper.ContentBuilding;
using Xunit;

namespace ArgsMapper.Tests.ContentBuilderTests
{
    public class ContentFormatterTests
    {
        public static IEnumerable<object[]> Values
        {
            get
            {
                yield return new object[] {
                    new[] { new[] { "c1", "c2" } },
                    new[] { 2, 2 }, 
                    0
                };

                yield return new object[] {
                    new[] { new[] { "", "" } },
                    new[] { 0, 0 },
                    0
                };

                yield return new object[] {
                    new[] {
                        new[] { "c1", "" },
                        new[] { null, "" }
                    },
                    new[] { 2, 0 },
                    0
                };

                yield return new object[] {
                    new[] { new string[] { null } },
                    new[] { 0 },
                    0
                };

                yield return new object[] {
                    new[] {
                        new[] { "c1", "c2" },
                        new[] { "a", "b" }
                    },
                    new[] { 2, 2 },
                    0
                };

                yield return new object[] {
                    new[] {
                        new[] { "c1", "c2" },
                        new[] { "aaa", "bbb" }
                    },
                    new[] { 3, 3 },
                    0
                };

                yield return new object[] {
                    new[] {
                        new[] { "", "c2" },
                        new[] { "aa", "bbb" }
                    },
                    new[] { 2, 3 },
                    0
                };

                yield return new object[] {
                    new[] {
                        new[] { "", "c2" },
                        new[] { "aa", "bbb" }
                    },
                    new[] { 4, 3 },
                    2
                };

                yield return new object[] {
                    new[] {
                        new[] { "", "c2", "c3" },
                        new[] { "aa", "bbb", "ccc" }
                    },
                    new[] { 4, 5, 3 },
                    2
                };

                yield return new object[] {
                    new string[] { },
                    null,
                    0
                };
            }
        }

        [Theory]
        [MemberData(nameof(Values))]
        internal void Render_GetColumnLengths(string[][] values, int[] columnLengths, int padding)
        {
            Assert.Equal(columnLengths, ContentFormatter.GetColumnLengths(values, padding));
        }
    }
}
