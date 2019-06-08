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
using System.Threading.Tasks;
using Xunit;

namespace ArgsMapper.Tests
{
    public class ExecutionTests
    {
        [Fact]
        internal void Execute_OnError_Result_Should_Have_ErrorMessage()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Act
            mapper.Execute(new[] { "--option" }, null, errorResult => {
                // Assert
                Assert.Equal("Unknown option '--option'.", errorResult.ErrorMessage);
            });
        }

        [Fact]
        internal void Execute_Output_Should_Be_Empty_When_OnError_Not_Null()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            // Act
            mapper.Execute(new[] { "--option" }, null, errorResult => {
            });

            Assert.Equal(string.Empty, output.ToString());
        }

        [Fact]
        internal void Execute_Output_Should_Be_Empty_When_OnSuccess_Method_Null()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            // Act
            mapper.Execute(Array.Empty<string>(), null);

            Assert.Equal(string.Empty, output.ToString().TrimEnd());
        }

        [Fact]
        internal void Execute_Output_Should_Be_Unknown_Command_Message()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command);
            });

            // Act
            mapper.Execute(new[] { "command", "unknown-command" }, null);

            // Assert
            Assert.StartsWith("'unknown-command' is not a valid command.", output.ToString());
        }

        [Fact]
        internal void Execute_Output_Should_Be_Unknown_Command_Message_When_Subcommand_Disabled()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.IsDisabled = true;
                });
            });

            // Act
            mapper.Execute(new[] { "command", "command" }, null);

            // Assert
            Assert.StartsWith("'command' is not a valid command.", output.ToString());
        }

        [Fact]
        internal void Execute_Should_Write_Error_Text_When_OnError_Null()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            // Act
            mapper.Execute(new[] { "--option" }, null);

            Assert.Equal("Unknown option '--option'.", output.ToString());
        }

        [Fact]
        internal void Execute_Success_Model_Option_Should_Be_True()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.AddPositionalOption(x => x.Option);
                });
            });

            // Act
            mapper.Execute(new[] { "command", "command", "on" }, args => {
                // Assert
                Assert.True(args.Command.Command.Option);
            });
        }

        [Fact]
        internal async Task ExecuteAsync_Usage()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);

            var result = false;

            // Act
            await mapper.ExecuteAsync(new[] { "--option" }, args => {
                result = args.Option;
            });

            // Assert
            Assert.True(result);
        }
    }
}
