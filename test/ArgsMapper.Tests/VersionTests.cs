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

using System;
using System.IO;
using System.Text;
using Xunit;

namespace ArgsMapper.Tests
{
    public class VersionTests
    {
        [Theory]
        [InlineData("-v")]
        [InlineData("--version")]
        internal void Output_Should_Be_1_0_0_0_Version_Text(params string[] args)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            // Act
            mapper.Execute(args, null);

            // Assert
            Assert.Equal(new Version(1, 0, 0, 0).ToString(), output.ToString());
        }

        [Theory]
        [InlineData("-v")]
        [InlineData("--version")]
        internal void Output_Should_Be_Version_Text(params string[] args)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            var version = new Version(4, 3, 2, 1);

            mapper.Settings.DefaultWriter = new StringWriter(output);
            mapper.Settings.ApplicationVersion = version;

            // Act
            mapper.Execute(args, null);

            // Assert
            Assert.Equal(version.ToString(), output.ToString());
        }
    }
}
