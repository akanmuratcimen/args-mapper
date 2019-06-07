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

using Xunit;

namespace ArgsMapper.Tests
{
    public class InitializationTests
    {
        [Fact]
        internal void Mapper_AddCommand_AddOption_AddPositionalOption_List_Should_Be_Initialized()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option);
                commandSettings.AddPositionalOption(x => x.Options);
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddOption_Should_Be_Initialized_With_Property()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option);
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddOption_Should_Be_Initialized_With_Property_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option, "option");
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddOption_Should_Be_Initialized_With_Property_LongName_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option, "option", optionSettings => {
                });
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddOption_Should_Be_Initialized_With_Property_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option, optionSettings => {
                });
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddOption_Should_Be_Initialized_With_Property_ShortName_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option, 'o', "option");
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddOption_Should_Be_Initialized_With_Property_ShortName_LongName_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option, 'o', "option", optionSettings => {
                });
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddPositionalOption_List_AddOption_Should_Be_Initialized()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Options);
                commandSettings.AddOption(x => x.Option);
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddPositionalOption_List_Should_Be_Initialized_With_Property()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneListStringOption>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option);
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddPositionalOption_Should_Be_Initialized_With_Property()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option);
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddPositionalOption_Should_Be_Initialized_With_Property_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option, "option");
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddPositionalOption_Should_Be_Initialized_With_Property_LongName_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option, "option", optionSettings => {
                });
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddPositionalOption_Should_Be_Initialized_With_Property_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option, optionSettings => {
                });
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddSubcommand_AddSubcommand_AddSubcommand_Should_Be_Initialized()
        {
            // Arrange
            var mapper = new ArgsMapper<FourLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.AddSubcommand(x => x.Command, level2SubcommandSettings => {
                        level2SubcommandSettings.AddSubcommand(x => x.Command);
                    });
                });
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddSubcommand_AddSubcommand_Should_Be_Initialized()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.AddSubcommand(x => x.Command);
                });
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddSubcommand_Should_Be_Initialized()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command);
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddSubcommand_Should_Be_Initialized_With_Property_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, "command");
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddSubcommand_Should_Be_Initialized_With_Property_LongName_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, "command", subcommandSettings => {
                    subcommandSettings.IsDisabled = false;
                });
            });
        }

        [Fact]
        internal void Mapper_AddCommand_AddSubcommand_Should_Be_Initialized_With_Property_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.IsDisabled = false;
                });
            });
        }

        [Fact]
        internal void Mapper_AddCommand_Should_Be_Initialized_With_Property()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command);
        }

        [Fact]
        internal void Mapper_AddCommand_Should_Be_Initialized_With_Property_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "command");
        }

        [Fact]
        internal void Mapper_AddCommand_Should_Be_Initialized_With_Property_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
            });
        }

        [Fact]
        internal void Mapper_AddOption_AddPositionalOption_List_Should_Be_Initialized()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);
            mapper.AddPositionalOption(x => x.Options);
        }

        [Fact]
        internal void Mapper_AddOption_Should_Be_Initialized_With_Property()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);
        }

        [Fact]
        internal void Mapper_AddOption_Should_Be_Initialized_With_Property_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option, "option");
        }

        [Fact]
        internal void Mapper_AddOption_Should_Be_Initialized_With_Property_LongName_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option, "option", optionSettings => {
            });
        }

        [Fact]
        internal void Mapper_AddOption_Should_Be_Initialized_With_Property_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option, optionSettings => {
            });
        }

        [Fact]
        internal void Mapper_AddOption_Should_Be_Initialized_With_Property_ShortName_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option, 'o', "option");
        }

        [Fact]
        internal void Mapper_AddOption_Should_Be_Initialized_With_Property_ShortName_LongName_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option, 'o', "option", optionSettings => {
            });
        }

        [Fact]
        internal void Mapper_AddPositionalOption_List_AddOption_Should_Be_Initialized()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Options);
            mapper.AddOption(x => x.Option);
        }

        [Fact]
        internal void Mapper_AddPositionalOption_List_Should_Be_Initialized_With_Property()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionArgs>();

            mapper.AddPositionalOption(x => x.Option);
        }

        [Fact]
        internal void Mapper_AddPositionalOption_List_Should_Be_Initialized_With_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Options, optionSettings => {
            });
        }

        [Fact]
        internal void Mapper_AddPositionalOption_Should_Be_Initialized_With_Property()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Option);
        }

        [Fact]
        internal void Mapper_AddPositionalOption_Should_Be_Initialized_With_Property_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Option, "option");
        }

        [Fact]
        internal void Mapper_AddPositionalOption_Should_Be_Initialized_With_Property_LongName_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Option, "option", optionSettings => {
            });
        }

        [Fact]
        internal void Mapper_AddPositionalOption_Should_Be_Initialized_With_Property_Settings()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Option, optionSettings => {
            });
        }
    }
}
