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
                    new[] { 2, 2 }
                };

                yield return new object[] {
                    new[] { new[] { "", "" } },
                    new[] { 0, 0 }
                };

                yield return new object[] {
                    new[] {
                        new[] { "c1", "" },
                        new[] { null, "" }
                    },
                    new[] { 2, 0 }
                };

                yield return new object[] {
                    new[] { new string[] { null } },
                    new[] { 0 }
                };

                yield return new object[] {
                    new[] {
                        new[] { "c1", "c2" },
                        new[] { "a", "b" }
                    },
                    new[] { 2, 2 }
                };

                yield return new object[] {
                    new[] {
                        new[] { "c1", "c2" },
                        new[] { "aaa", "bbb" }
                    },
                    new[] { 3, 3 }
                };

                yield return new object[] {
                    new[] {
                        new[] { "", "c2" },
                        new[] { "aa", "bbb" }
                    },
                    new[] { 2, 3 }
                };

                yield return new object[] {
                    new string[] { },
                    null
                };
            }
        }

        [Theory]
        [MemberData(nameof(Values))]
        internal void Render_GetColumnLengths(string[][] values, int[] columnLengths)
        {
            Assert.Equal(columnLengths, ContentFormatter.GetColumnLengths(values, 0));
        }
    }
}
