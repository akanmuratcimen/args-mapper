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
using ArgsMapper.InitializationValidations.SubcommandValidations;
using Xunit;

namespace ArgsMapper.Tests.InitializationValidationTests
{
    public class SubcommandInitializationValidationTests
    {
        [Theory]
        [InlineData("command:")]
        [InlineData("command=")]
        [InlineData("command ")]
        internal void AddCommand_AddSubcommand_Should_Throw_InvalidCommandNameException(string commandName)
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, commandSettings => {
                Assert.Throws<InvalidSubcommandNameException>(() =>
                    commandSettings.AddSubcommand(x => x.Command, commandName)
                );
            });
        }

        [Fact]
        internal void AddCommand_AddSubcommand_Should_Throw_ArgumentException_When_Property_Has_No_Setter()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneCommandWithoutSetterWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, commandSettings => {
                Assert.Throws<ArgumentException>(() =>
                    commandSettings.AddSubcommand(x => x.Command)
                );
            });
        }

        [Fact]
        internal void AddCommand_AddSubcommand_Should_Throw_ArgumentException_When_Property_Internal()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneInternalCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, commandSettings => {
                Assert.Throws<ArgumentException>(() =>
                    commandSettings.AddSubcommand(x => x.Command)
                );
            });
        }

        [Fact]
        internal void AddCommand_AddSubcommand_Should_Throw_ArgumentException_When_Property_Method()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneCommandMethodWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, commandSettings => {
                Assert.Throws<ArgumentException>(() =>
                    commandSettings.AddSubcommand(x => x.Command())
                );
            });
        }

        [Fact]
        internal void AddCommand_AddSubcommand_Should_Throw_CommandNameAlreadyExistsException()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, "command");

                Assert.Throws<SubcommandNameAlreadyExistsException>(() => {
                    commandSettings.AddSubcommand(x => x.Command, "command");
                });
            });
        }

        [Fact]
        internal void AddCommand_AddSubcommand_Should_Throw_CommandNameRequiredException()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, commandSettings => {
                Assert.Throws<SubcommandNameRequiredException>(() =>
                    commandSettings.AddSubcommand(x => x.Command, string.Empty)
                );
            });
        }
    }
}
