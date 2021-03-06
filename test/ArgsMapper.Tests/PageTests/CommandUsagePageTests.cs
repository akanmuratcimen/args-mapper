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
    public class CommandUsagePageTests
    {
        [Fact]
        internal void Mapper_Output_Should_Be_Command_Usage_Content()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddText("sample command usage text.");
            });

            // Act
            mapper.Execute(new[] { "command", "--help" }, null);

            // Assert
            Assert.Equal("sample command usage text.", output.ToString().TrimEnd());
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Help_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddHelpOption(contentOptionSettings => {
                    contentOptionSettings.Description = "sample help description.";
                });
            });

            // Act
            mapper.Execute(new[] { "command", "--help" }, null);

            // Assert
            Assert.Equal("-h|--help  sample help description.", output.ToString().TrimEnd());
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Subcommand_Usage_Content()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.Usage.AddText("sample subcommand usage text.");
                });
            });

            // Act
            mapper.Execute(new[] { "command", "command", "--help" }, null);

            // Assert
            Assert.Equal("sample subcommand usage text.", output.ToString().TrimEnd());
        }

        [Fact]
        internal void Mapper_Output_Should_Unknown_Option_Error()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command);

            // Act
            mapper.Execute(new[] { "command", "--help" }, null);

            // Assert
            Assert.StartsWith("Unknown 'command' command option", output.ToString());
        }

        [Fact]
        internal void Mapper_Subcommand_Output_Should_Be_Empty()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.AddPositionalOption(x => x.Option);

                    subcommandSettings.Usage.AddText("sample usage text");
                });
            });

            // Act
            mapper.Execute(new[] { "command", "command" }, null);

            // Assert
            Assert.Equal(string.Empty, output.ToString());
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Subcommand_Usage_Content_When_ShowUsageWhenEmptyOptions_True_And_No_Option_In_Args()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.ShowUsageWhenEmptyOptions = true;

                    subcommandSettings.Usage.AddText("sample usage text");
                });
            });

            // Act
            mapper.Execute(new[] { "command", "command" }, null);

            // Assert
            Assert.Equal("sample usage text", output.ToString().Trim());
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Command_Usage_Content_When_ShowUsageWhenEmptyOptions_True_And_No_Option_In_Args()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.ShowUsageWhenEmptyOptions = true;

                commandSettings.Usage.AddText("sample usage text");
            });

            // Act
            mapper.Execute(new[] { "command" }, null);

            // Assert
            Assert.Equal("sample usage text", output.ToString().Trim());
        }

        [Fact]
        internal void Mapper_Subcommand_Output_Should_Unknown_Option_Error()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, "sub-command");
            });

            // Act
            mapper.Execute(new[] { "command", "sub-command", "--help" }, null);

            // Assert
            Assert.StartsWith("Unknown 'sub-command' command option", output.ToString());
        }
    }
}
