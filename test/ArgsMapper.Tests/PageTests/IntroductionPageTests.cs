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
using System.IO;
using System.Text;
using Xunit;

namespace ArgsMapper.Tests.PageTests
{
    public class IntroductionPageTests
    {
        [Fact]
        internal void Mapper_Output_Should_Be_Empty_When_Introduction_And_Usage_Not_Defined()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddOption(x => x.Option);

            // Act
            mapper.Execute(Array.Empty<string>(), null);

            // Assert
            Assert.Equal(string.Empty, output.ToString());
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Introduction_Content()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);
            mapper.AddOption(x => x.Option);

            mapper.Introduction.AddText("sample introduction text.");

            // Act
            mapper.Execute(Array.Empty<string>(), null);

            // Assert
            Assert.Equal("sample introduction text.", output.ToString());
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Usage_Content_When_Introduction_Not_Defined()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddOption(x => x.Option);

            mapper.Usage.AddText("sample usage text.");

            // Act
            mapper.Execute(Array.Empty<string>(), null);

            // Assert
            Assert.Equal("sample usage text.", output.ToString());
        }
    }
}
