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

using System.IO;
using System.Text;
using Xunit;

namespace ArgsMapper.Tests.PageTests
{
    public class GeneralUsagePageTests
    {
        [Theory]
        [InlineData("-h")]
        [InlineData("--help")]
        internal void Mapper_Output_Should_Be_Usage_Content(params string[] args)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddOption(x => x.Option);

            mapper.Usage.AddText("sample usage text.");

            // Act
            mapper.Execute(args, null);

            // Assert
            Assert.Equal("sample usage text.", output.ToString().TrimEnd());
        }

        [Theory]
        [InlineData("-h")]
        [InlineData("--help")]
        internal void Mapper_Output_Should_Unknown_Option_Error(params string[] args)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddOption(x => x.Option);

            // Act
            mapper.Execute(args, null);

            // Assert
            Assert.StartsWith("Unknown option", output.ToString());
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Help_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.Usage.AddHelpOption(contentOptionSettings => {
                contentOptionSettings.Description = "sample help description.";
            });

            // Act
            mapper.Execute(new[] { "--help" }, null);

            // Assert
            Assert.Equal("-h|--help  sample help description.", output.ToString().TrimEnd());
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Version_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.Usage.AddVersionOption(contentOptionSettings => {
                contentOptionSettings.Description = "sample version description.";
            });

            // Act
            mapper.Execute(new[] { "--help" }, null);

            // Assert
            Assert.Equal("-v|--version  sample version description.", output.ToString().TrimEnd());
        }
    }
}
