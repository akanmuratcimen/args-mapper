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
using ArgsMapper.InitializationValidations.CommandOptionValidations;
using Xunit;

namespace ArgsMapper.Tests.InitializationValidationTests
{
    public class CommandOptionInitializationValidationTests
    {
        [Theory]
        [InlineData("version")]
        [InlineData("help")]
        internal void AddOption_Should_Throw_ReservedCommandOptionLongNameException(string optionLongName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                Assert.Throws<ReservedCommandOptionLongNameException>(() =>
                    commandSettings.AddOption(x => x.Option, optionLongName)
                );
            });
        }

        [Theory]
        [InlineData("version")]
        [InlineData("help")]
        internal void AddPositionalOption_Should_Throw_ReservedCommandOptionLongNameException(string optionLongName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                Assert.Throws<ReservedCommandOptionLongNameException>(() =>
                    commandSettings.AddPositionalOption(x => x.Option, optionLongName)
                );
            });
        }

        [Theory]
        [InlineData('v')]
        [InlineData('h')]
        internal void AddOption_Should_Throw_ReservedCommandOptionShortNameException(char optionShortName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                Assert.Throws<ReservedCommandOptionShortNameException>(() =>
                    commandSettings.AddOption(x => x.Option, optionShortName, "option")
                );
            });
        }

        [Theory]
        [InlineData("opt:ion")]
        [InlineData("opt=ion")]
        [InlineData("opt ion")]
        internal void AddCommand_AddOption_Should_Throw_InvalidCommandOptionLongNameException(string optionLongName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                Assert.Throws<InvalidCommandOptionLongNameException>(() =>
                    commandSettings.AddOption(x => x.Option, optionLongName)
                );
            });
        }

        [Theory]
        [InlineData("opt:ion")]
        [InlineData("opt=ion")]
        [InlineData("opt ion")]
        internal void AddCommand_AddPositionalOption_Should_Throw_InvalidCommandOptionLongNameException(string optionLongName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                Assert.Throws<InvalidCommandOptionLongNameException>(() =>
                    commandSettings.AddPositionalOption(x => x.Option, optionLongName)
                );
            });
        }

        [Theory]
        [InlineData('0')]
        [InlineData('-')]
        [InlineData('/')]
        [InlineData('+')]
        [InlineData('=')]
        [InlineData('.')]
        internal void AddCommand_AddOption_Should_Throw_InvalidCommandOptionShortNameException(char optionShortName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                Assert.Throws<InvalidCommandOptionShortNameException>(() =>
                    commandSettings.AddOption(x => x.Option, optionShortName, "option")
                );
            });
        }

        [Fact]
        internal void AddCommand_AddOption_Should_Throw_ArgumentException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolMethodOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.AddOption(x => x.Option());
                })
            );
        }

        [Fact]
        internal void AddCommand_AddOption_Should_Throw_ArgumentException_When_Property_Has_No_Setter()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolWithoutSetterOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.AddOption(x => x.Option);
                })
            );
        }

        [Fact]
        internal void AddCommand_AddOption_Should_Throw_ArgumentException_When_Property_Internal()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneInternalBoolOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.AddOption(x => x.Option);
                })
            );
        }

        [Fact]
        internal void AddCommand_AddOption_Should_Throw_CommandOptionLongNameAlreadyExistsException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option, "option");

                Assert.Throws<CommandOptionLongNameAlreadyExistsException>(() =>
                    commandSettings.AddOption(x => x.Option, "option")
                );
            });
        }

        [Fact]
        internal void AddCommand_AddOption_Should_Throw_CommandOptionLongNameRequiredException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            Assert.Throws<CommandOptionLongNameRequiredException>(() =>
                mapper.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.AddOption(x => x.Option, string.Empty);
                })
            );
        }

        [Fact]
        internal void AddCommand_AddOption_Should_Throw_CommandOptionShortNameAlreadyExistsException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option, 'o', "option1");

                Assert.Throws<CommandOptionShortNameAlreadyExistsException>(() =>
                    commandSettings.AddOption(x => x.Option, 'o', "option2")
                );
            });
        }

        [Fact]
        internal void AddCommand_AddOption_Should_Throw_UnsupportedCommandOptionPropertyTypeException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithUnsupportedTypeOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                Assert.Throws<UnsupportedCommandOptionPropertyTypeException>(() =>
                    commandSettings.AddOption(x => x.QueueOption)
                );

                Assert.Throws<UnsupportedCommandOptionPropertyTypeException>(() =>
                    commandSettings.AddOption(x => x.StackOption)
                );
            });
        }

        [Fact]
        internal void AddCommand_AddPositionalOption_Should_Throw_ArgumentException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolMethodOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.AddPositionalOption(x => x.Option());
                })
            );
        }

        [Fact]
        internal void AddCommand_AddPositionalOption_Should_Throw_ArgumentException_When_Property_Has_No_Setter()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolWithoutSetterOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.AddPositionalOption(x => x.Option);
                })
            );
        }

        [Fact]
        internal void AddCommand_AddPositionalOption_Should_Throw_ArgumentException_When_Property_Internal()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneInternalBoolOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.AddPositionalOption(x => x.Option);
                })
            );
        }

        [Fact]
        internal void AddCommand_AddPositionalOption_Should_Throw_CommandOptionLongNameAlreadyExistsException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option, "option");

                Assert.Throws<CommandOptionLongNameAlreadyExistsException>(() =>
                    commandSettings.AddPositionalOption(x => x.Option, "option")
                );
            });
        }

        [Fact]
        internal void AddCommand_AddPositionalOption_Should_Throw_CommandOptionLongNameRequiredException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            Assert.Throws<CommandOptionLongNameRequiredException>(() =>
                mapper.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.AddPositionalOption(x => x.Option, string.Empty);
                })
            );
        }

        [Fact]
        internal void AddCommand_AddPositionalOption_Should_Throw_CommandPositionalOptionListConflictException_PositionalOption()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneListStringOptionWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Options);

                Assert.Throws<CommandPositionalOptionListConflictException>(() =>
                    commandSettings.AddPositionalOption(x => x.Option)
                );
            });
        }

        [Fact]
        internal void AddCommand_AddPositionalOption_Should_Throw_CommandPositionalOptionListConflictException_PositionalOption_List()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithTwoListStringOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Options1);

                Assert.Throws<CommandPositionalOptionListConflictException>(() =>
                    commandSettings.AddPositionalOption(x => x.Options2)
                );
            });
        }

        [Fact]
        internal void AddCommand_AddPositionalOption_Should_Throw_CommandPositionalOptionListConflictException_PositionalOption_Reverse()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneListStringOptionWithOneBoolOptionArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option);

                Assert.Throws<CommandPositionalOptionListConflictException>(() =>
                    commandSettings.AddPositionalOption(x => x.Options)
                );
            });
        }

        [Fact]
        internal void AddCommand_AddPositionalOption_Should_Throw_UnsupportedCommandOptionPropertyTypeException_Class()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();

            // Assert
            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                Assert.Throws<UnsupportedCommandOptionPropertyTypeException>(() =>
                    commandSettings.AddPositionalOption(x => x.Command)
                );
            });
        }
    }
}
