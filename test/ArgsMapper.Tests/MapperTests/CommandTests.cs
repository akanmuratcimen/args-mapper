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
using Xunit;

namespace ArgsMapper.Tests.MapperTests
{
    public class CommandTests
    {
        [Theory]
        [InlineData("Option", StringComparison.InvariantCulture, false)]
        [InlineData("Option", StringComparison.InvariantCultureIgnoreCase, true)]
        internal void Command_Option_Should_Match_Or_Not_By_StringComparison(
            string arg, StringComparison stringComparison, bool expected)
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.Settings.StringComparison = stringComparison;

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.AddOption(x => x.Option, "option");
            });

            // Act
            var result = mapper.Map("command", $"--{arg}");

            // Assert
            Assert.Equal(expected, result.Model.Command?.Option ?? false);
        }

        [Theory]
        [InlineData("Command", StringComparison.InvariantCulture, false)]
        [InlineData("Command", StringComparison.InvariantCultureIgnoreCase, true)]
        internal void Command_Should_Match_Or_Not_By_StringComparison(
            string arg, StringComparison stringComparison, bool expected)
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.Settings.StringComparison = stringComparison;

            mapper.AddCommand(x => x.Command, "command");

            // Act
            var result = mapper.Map(arg);

            // Assert
            Assert.True(result.Model.Command != null == expected);
        }

        [Fact]
        internal void Command_Option_Should_Be_Matched_With_Custom_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option, "custom-named-option");
            });

            // Act
            var result = mapper.Map("command", "--custom-named-option");

            // Assert
            Assert.True(result.Model.Command.Option);
        }

        [Fact]
        internal void Command_Option_Should_Be_Matched_With_Custom_ShortName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option, 'o', "option");
            });

            // Act
            var result = mapper.Map("command", "-o");

            // Assert
            Assert.True(result.Model.Command.Option);
        }

        [Fact]
        internal void Command_Option_Should_Be_Matched_With_Default_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option);
            });

            // Act
            var result = mapper.Map("command", "--option");

            // Assert
            Assert.True(result.Model.Command.Option);
        }

        [Fact]
        internal void Command_Option_Should_Be_Matched_With_Default_LongName_HyphenCase()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneLongNamedBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.SomeOptionProperty);
            });

            // Act
            var result = mapper.Map("command", "--some-option-property");

            // Assert
            Assert.True(result.Model.Command.SomeOptionProperty);
        }

        [Fact]
        internal void Command_Option_Value_Should_Be_Default_Value()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option, optionSettings => {
                    optionSettings.DefaultValue = true;
                });
            });

            // Act
            var result = mapper.Map("command");

            // Assert
            Assert.True(result.Model.Command.Option);
        }

        [Fact]
        internal void Command_Option_Value_Should_Be_Default_Value_Multiple()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithThreeIntOptionsArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option1, optionSettings => {
                    optionSettings.DefaultValue = 1;
                });

                commandSettings.AddOption(x => x.Option2, optionSettings => {
                    optionSettings.DefaultValue = 2;
                });

                commandSettings.AddOption(x => x.Option3, optionSettings => {
                    optionSettings.DefaultValue = 3;
                });
            });

            // Act
            var result = mapper.Map("command");

            // Assert
            Assert.Equal(1, result.Model.Command.Option1);
            Assert.Equal(2, result.Model.Command.Option2);
            Assert.Equal(3, result.Model.Command.Option3);
        }

        [Fact]
        internal void Command_Option_Values_Should_Be_Merged_LongName_And_ShortName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneListIntOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option, 'o', "option");
            });

            // Act
            var result = mapper.Map("command", "--option", "1", "-o", "2");

            // Assert
            Assert.Contains(1, result.Model.Command.Option);
            Assert.Contains(2, result.Model.Command.Option);
        }

        [Fact]
        internal void Command_PositionalOption_List_Should_Have_Arg_Values()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneListStringOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option);
            });

            // Act
            var result = mapper.Map("command", "foo", "bar");

            // Assert
            Assert.Equal(new[] { "foo", "bar" }, result.Model.Command.Option);
        }

        [Fact]
        internal void Command_PositionalOption_List_Should_Have_Arg_Values_With_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Options);
                commandSettings.AddOption(x => x.Option);
            });

            // Act
            var result = mapper.Map("command", "foo", "bar", "--option", "1");

            // Assert
            Assert.Equal(new[] { "foo", "bar" }, result.Model.Command.Options);
            Assert.Equal(1, result.Model.Command.Option);
        }

        [Fact]
        internal void Command_PositionalOption_Should_Be_Matched()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneIntOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option);
            });

            // Act
            var result = mapper.Map("command", "1");

            // Assert
            Assert.Equal(1, result.Model.Command.Option);
        }

        [Fact]
        internal void Command_PositionalOption_Should_Be_Used_With_Named_Options()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithThreeIntOptionsArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option1);
                commandSettings.AddOption(x => x.Option2, "option2");
                commandSettings.AddOption(x => x.Option3, 'o', "option3");
            });

            // Act
            var result = mapper.Map("command", "1", "--option2", "2", "-o", "3");

            // Assert
            Assert.Equal(1, result.Model.Command.Option1);
            Assert.Equal(2, result.Model.Command.Option2);
            Assert.Equal(3, result.Model.Command.Option3);
        }

        [Fact]
        internal void Command_Should_Be_Matched_With_Default_Name()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command);

            // Act
            var result = mapper.Map("command");

            // Assert
            Assert.NotNull(result.Model.Command);
            Assert.IsType<OneBoolOptionArgs>(result.Model.Command);
        }

        [Fact]
        internal void Command_Should_Be_Matched_With_Default_Name_HyphenCase()
        {
            // Arrange
            var mapper = new ArgsMapper<OneLongNamedCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.SomeCommandProperty);

            // Act
            var result = mapper.Map("some-command-property");

            // Assert
            Assert.NotNull(result.Model.SomeCommandProperty);
            Assert.IsType<OneBoolOptionArgs>(result.Model.SomeCommandProperty);
        }

        [Fact]
        internal void Command_Should_Be_Matched_With_Name()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, "custom-named-command");

            // Act
            var result = mapper.Map("custom-named-command");

            // Assert
            Assert.NotNull(result.Model.Command);
            Assert.IsType<OneBoolOptionArgs>(result.Model.Command);
        }

        [Fact]
        internal void Command_Should_Be_Matched_With_Nested_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithTwoLevelNestedClass>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.NestedA.NestedB.Option);
            });

            // Act
            var result = mapper.Map("command", "--nested-a.nested-b.option");

            // Assert
            Assert.True(result.Model.Command.NestedA.NestedB.Option);
        }

        [Fact]
        internal void Command_Should_Be_Null_When_Disabled()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.IsDisabled = true;
            });

            // Act
            var result = mapper.Map("command");

            // Assert
            Assert.Null(result.Model.Command);
        }

        [Fact]
        internal void Command_Should_Not_Be_Matched_When_Its_Not_In_Args()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option);
            });

            // Act
            var result = mapper.Map();

            // Assert
            Assert.Null(result.Model.Command);
        }

        [Fact]
        internal void Command_Stacked_Options_Value_Should_Be_Given_Value()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithThreeBoolOptionsArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option1, 'x', "option-1");
                commandSettings.AddOption(x => x.Option2, 'y', "option-2");
                commandSettings.AddOption(x => x.Option3, 'z', "option-3");
            });

            // Act
            var result = mapper.Map("command", "-xyz");

            // Assert
            Assert.True(result.Model.Command.Option1);
            Assert.True(result.Model.Command.Option2);
            Assert.True(result.Model.Command.Option3);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Args_Exceeded_PositionalOption_Definitions()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithThreeIntOptionsArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option1);
                commandSettings.AddPositionalOption(x => x.Option2);
                commandSettings.AddPositionalOption(x => x.Option3);
            });

            // Act
            var result = mapper.Map("command", "1", "2", "3", "4");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("There is no matched 'command' option for value '4'.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Command_Not_Found()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command);

            // Act
            var result = mapper.Map("unknown-command");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("'unknown-command' is not a valid command.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Command_Option_Is_Disabled()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option, optionSettings => {
                    optionSettings.IsDisabled = true;
                });
            });

            // Act
            var result = mapper.Map("command", "--option");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Unknown 'command' command option '--option'.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Command_Option_Is_Required()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option, optionSettings => {
                    optionSettings.IsRequired = true;
                });
            });

            // Act
            var result = mapper.Map("command");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Required 'command' command option '--option' is missing.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Command_PositionalOption_Is_Required()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option, optionSettings => {
                    optionSettings.IsRequired = true;
                });
            });

            // Act
            var result = mapper.Map("command");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Required 'command' command option 'option' is missing.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Command_PositionalOption_List_Is_Required()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneListStringOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option, optionSettings => {
                    optionSettings.IsRequired = true;
                });
            });

            // Act
            var result = mapper.Map("command");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Required 'command' command option 'option' is missing.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_CommandOption_Has_Not_Valid_Value()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneIntOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option);
            });

            // Act
            var result = mapper.Map("command", "--option", "non-integer-value");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("'non-integer-value' not a valid value for '--option' option.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Option_Not_Defined()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneIntOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option);
            });

            // Act
            var result = mapper.Map("command", "--option1");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Unknown 'command' command option '--option1'.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Option_Not_Defined_ShortName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneIntOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option);
            });

            // Act
            var result = mapper.Map("command", "-o");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Unknown 'command' command option '-o'.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Required_Error_When_Same_Property_Mapped_By_Another_Command_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option, "option-1");

                commandSettings.AddOption(x => x.Option, "option-2", optionSettings => {
                    optionSettings.IsRequired = true;
                });
            });

            // Act
            var result = mapper.Map("command", "--option-1", "1");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Required 'command' command option '--option-2' is missing.", result.ErrorMessage);
        }
    }
}
