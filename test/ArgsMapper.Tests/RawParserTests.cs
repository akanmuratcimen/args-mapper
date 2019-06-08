/**
 * The MIT License (MIT)
 * 
 * Copyright (c) 2019 Akan Murat Cimen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
 * the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System.Collections.Generic;
using System.Linq;
using ArgsMapper.Models;
using ArgsMapper.Parsing;
using Xunit;

namespace ArgsMapper.Tests
{
    public class RawParserTests
    {
        public static IEnumerable<object[]> EmptyOptionValues
        {
            get
            {
                yield return new object[] {
                    new[] { "--option1", "--option2" },
                    new[] {
                        ("--option1", OptionMatchType.ByLongName),
                        ("--option2", OptionMatchType.ByLongName)
                    }
                };

                yield return new object[] {
                    new[] { "-x", "-y" },
                    new[] {
                        ("-x", OptionMatchType.ByShortName),
                        ("-y", OptionMatchType.ByShortName)
                    }
                };
            }
        }

        public static IEnumerable<object[]> MergeOptionValues
        {
            get
            {
                yield return new object[] {
                    new[] { "--option", "value1", "value2", "--option", "value3" },
                    ("--option", OptionMatchType.ByLongName),
                    new[] { "value1", "value2", "value3" }
                };

                yield return new object[] {
                    new[] { "-o", "value1", "value2", "-o", "value3" },
                    ("-o", OptionMatchType.ByShortName),
                    new[] { "value1", "value2", "value3" }
                };
            }
        }

        public static IEnumerable<object[]> MergeTheirOwnOptionValues
        {
            get
            {
                yield return new object[] {
                    new[] {
                        "--option1", "value1", "value2", "--option1", "value3",
                        "--option2", "value4", "--option1", "value5", "--option2", "value6",
                        "--option3", "value7", "--option3", "value8", "--option1", "value9"
                    },
                    new object[] {
                        ("--option1", OptionMatchType.ByLongName),
                        new[] { "value1", "value2", "value3", "value5", "value9" },
                        ("--option2", OptionMatchType.ByLongName),
                        new[] { "value4", "value6" },
                        ("--option3", OptionMatchType.ByLongName),
                        new[] { "value7", "value8" }
                    }
                };

                yield return new object[] {
                    new[] {
                        "-a", "value1", "value2", "-a", "value3",
                        "-b", "value4", "-a", "value5", "-b", "value6",
                        "-c", "value7", "-c", "value8", "-a", "value9"
                    },
                    new object[] {
                        ("-a", OptionMatchType.ByShortName),
                        new[] { "value1", "value2", "value3", "value5", "value9" },
                        ("-b", OptionMatchType.ByShortName),
                        new[] { "value4", "value6" },
                        ("-c", OptionMatchType.ByShortName),
                        new[] { "value7", "value8" }
                    }
                };
            }
        }

        public static IEnumerable<object[]> MultipleOptionValues
        {
            get
            {
                yield return new object[] {
                    new[] { "--option", "value1", "value2" },
                    ("--option", OptionMatchType.ByLongName),
                    new[] { "value1", "value2" }
                };

                yield return new object[] {
                    new[] { "-o", "value1", "value2" },
                    ("-o", OptionMatchType.ByShortName),
                    new[] { "value1", "value2" }
                };
            }
        }

        [Theory]
        [InlineData("value", "-o=value")]
        [InlineData("value", "-o=", "value")]
        [InlineData("value", "-o", "=", "value")]
        [InlineData("value", "-o:value")]
        [InlineData("value", "-o:", "value")]
        [InlineData("value", "-o", ":", "value")]
        [InlineData("value=value", "-o=value=value")]
        [InlineData("value=value", "-o=", "value=value")]
        [InlineData("value=value", "-o", "=", "value=value")]
        [InlineData("value:value", "-o:value:value")]
        [InlineData("value:value", "-o:", "value:value")]
        [InlineData("value:value", "-o", ":", "value:value")]
        [InlineData("value:value=value", "-o=value:value=value")]
        [InlineData("value=value:value", "-o:value=value:value")]
        [InlineData(":value", "-o::value")]
        [InlineData("=value", "-o==value")]
        [InlineData("::value", "-o", "::value")]
        [InlineData("==value", "-o", "==value")]
        [InlineData("value:", "-o:value:")]
        [InlineData("value=", "-o=value=")]
        internal void RawParser_ParseOptions_Should_Handle_Assignment_Operators(
            string expected, params string[] args)
        {
            // Act
            var result = RawParser.ParseOptions(args);

            // Assert
            Assert.Contains(("-o", OptionMatchType.ByShortName), result.Keys);
            Assert.Contains(expected, result[("-o", OptionMatchType.ByShortName)]);
        }

        [Theory]
        [MemberData(nameof(EmptyOptionValues))]
        internal void RawParser_ParseOptions_Should_Have_Empty_Values(
            string[] args, (string, OptionMatchType)[] keys)
        {
            // Act
            var result = RawParser.ParseOptions(args);

            // Assert
            foreach (var optionKey in keys)
            {
                Assert.Contains(optionKey, result.Keys);
                Assert.Empty(result[optionKey]);
            }
        }

        [Theory]
        [MemberData(nameof(MergeOptionValues))]
        internal void RawParser_ParseOptions_Should_Merge_Values(
            string[] args, (string, OptionMatchType) key, string[] expectedValues)
        {
            // Act
            var result = RawParser.ParseOptions(args);

            // Assert
            Assert.Contains(key, result.Keys);

            foreach (var value in expectedValues)
            {
                Assert.Contains(value, result[key]);
            }
        }

        [Theory]
        [MemberData(nameof(MergeTheirOwnOptionValues))]
        internal void RawParser_ParseOptions_Should_Merge_With_Their_Own_Values(
            string[] args, object[] values)
        {
            // Act
            var result = RawParser.ParseOptions(args);

            // Assert
            Assert.Contains(((string, OptionMatchType))values[0], result.Keys);

            foreach (var value in (string[])values[1])
            {
                Assert.Contains(value, result[((string, OptionMatchType))values[0]]);
            }
        }

        [Theory]
        [MemberData(nameof(MultipleOptionValues))]
        internal void RawParser_ParseOptions_Should_Parse_Multiple_Value(
            string[] args, (string, OptionMatchType) key, string[] expectedValues)
        {
            // Act
            var result = RawParser.ParseOptions(args);

            // Assert
            Assert.Contains(key, result.Keys);

            foreach (var value in expectedValues)
            {
                Assert.Contains(value, result[key]);
            }
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-1.0")]
        internal void RawParser_ParseOptions_Should_Parse_Negative_Numbers_Values_Correctly(string value)
        {
            // Act
            var result = RawParser.ParseOptions(new[] { "-o", value });

            // Assert
            Assert.Contains(value, result[("-o", OptionMatchType.ByShortName)]);
        }

        [Theory]
        [MemberData(nameof(SingleOptionValues))]
        internal void RawParser_ParseOptions_Should_Parse_Single_Value(
            string[] args, (string, OptionMatchType) key, string expectedValue)
        {
            // Act
            var result = RawParser.ParseOptions(args);

            // Assert
            Assert.Contains(key, result.Keys);
            Assert.Contains(expectedValue, result[key]);
        }

        public static IEnumerable<object[]> SingleOptionValues
        {
            get
            {
                yield return new object[] {
                    new[] { "--option", "value" }, ("--option", OptionMatchType.ByLongName), "value"
                };

                yield return new object[] {
                    new[] { "-o", "value" }, ("-o", OptionMatchType.ByShortName), "value"
                };
            }
        }

        [Theory]
        [InlineData("C:\\file.txt")]
        [InlineData("foobar.com")]
        [InlineData("http://foobar.com")]
        [InlineData("http://www.foobar.com/")]
        [InlineData("http://www.foobar.org/abc/def.htm")]
        [InlineData("www.foobar.org/abc/def.htm#ghj")]
        [InlineData("mailto:foo@bar.com")]
        [InlineData("tel:1-888-555-5555")]
        [InlineData("file:///foo/bar/file.txt")]
        internal void RawParser_ParseOptions_Should_Parse_Paths_Correctly(string path)
        {
            // Act
            var result = RawParser.ParseOptions(new[] { "-o", path });

            // Assert
            Assert.Equal(path, result[("-o", OptionMatchType.ByShortName)][0]);
        }

        [Theory]
        [InlineData("\"foobar\"")]
        [InlineData("\"-o foo\"")]
        [InlineData("\"--option foobar\"")]
        [InlineData("\"-o \"foo bar\"\"")]
        [InlineData("'-o foobar'")]
        [InlineData("\"-o 'foo bar'\"")]
        [InlineData("\"-o \"\"foo bar\"\"\"")]
        internal void RawParser_ParseOptions_Should_Not_Parse_Values_If_It_Is_In_Quotes(string arg)
        {
            // Act
            var result = RawParser.ParseOptions(new[] { "-o", arg });

            // Assert
            Assert.Equal(arg, result[("-o", OptionMatchType.ByShortName)][0]);
        }

        [Theory]
        [InlineData(null, "-xyz")]
        [InlineData("1", "-xyz", "1")]
        [InlineData("foobar", "-xyz", "foobar")]
        internal void RawParser_ParseOptions_Should_Parse_Stacked_Options(string expectedValue, params string[] args)
        {
            // Act
            var result = RawParser.ParseOptions(args);

            // Assert
            Assert.Contains(("-x", OptionMatchType.ByShortName), result.Keys);
            Assert.Contains(("-y", OptionMatchType.ByShortName), result.Keys);
            Assert.Contains(("-z", OptionMatchType.ByShortName), result.Keys);

            Assert.Equal(expectedValue, result[("-x", OptionMatchType.ByShortName)].FirstOrDefault());
            Assert.Equal(expectedValue, result[("-y", OptionMatchType.ByShortName)].FirstOrDefault());
            Assert.Equal(expectedValue, result[("-z", OptionMatchType.ByShortName)].FirstOrDefault());
        }

        [Fact]
        internal void RawParser_ParseOptions_Should_Parse_Mixed_Prefixes()
        {
            // Arrange
            var args = new[] {
                "-o", "value1", "--option1", "value2"
            };

            // Act
            var result = RawParser.ParseOptions(args);

            // Assert
            Assert.Contains(("-o", OptionMatchType.ByShortName), result.Keys);
            Assert.Contains(("--option1", OptionMatchType.ByLongName), result.Keys);

            Assert.Contains("value1", result[("-o", OptionMatchType.ByShortName)]);
            Assert.Contains("value2", result[("--option1", OptionMatchType.ByLongName)]);
        }
    }
}
