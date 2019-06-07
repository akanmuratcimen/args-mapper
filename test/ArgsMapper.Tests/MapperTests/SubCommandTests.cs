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

namespace ArgsMapper.Tests.MapperTests
{
    public class SubCommandTests
    {
        [Fact]
        internal void Command_PositionalOption_Should_Be_Matched()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneCommandWithOneIntOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, subCommandSettings => {
                    subCommandSettings.AddPositionalOption(x => x.Option);
                });
            });

            // Act
            var result = mapper.Map("command", "command", "1");

            // Assert
            Assert.Equal(1, result.Model.Command.Command.Option);
        }

        [Fact]
        internal void Command_SubCommand_Option_Should_Be_Matched_With_Default_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, subCommandSettings => {
                    subCommandSettings.AddOption(x => x.Option);
                });
            });

            // Act
            var result = mapper.Map("command", "command", "--option");

            // Assert
            Assert.True(result.Model.Command.Command.Option);
        }

        [Fact]
        internal void Command_SubCommand_PositionalOption_List_Should_Have_Arg_Values()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneCommandWithOneListStringOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, subCommandSettings => {
                    subCommandSettings.AddPositionalOption(x => x.Option);
                });
            });

            // Act
            var result = mapper.Map("command", "command", "foo", "bar");

            // Assert
            Assert.Equal(new[] { "foo", "bar" }, result.Model.Command.Command.Option);
        }

        [Fact]
        internal void Command_SubCommand_PositionalOption_List_Should_Have_Arg_Values_With_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneCommandWithOneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, subCommandSettings => {
                    subCommandSettings.AddPositionalOption(x => x.Options);
                    subCommandSettings.AddOption(x => x.Option);
                });
            });

            // Act
            var result = mapper.Map("command", "command", "foo", "bar", "--option", "1");

            // Assert
            Assert.Equal(new[] { "foo", "bar" }, result.Model.Command.Command.Options);
            Assert.Equal(1, result.Model.Command.Command.Option);
        }

        [Fact]
        internal void Command_SubCommand_Should_Be_Matched_With_Default_Name()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command);
            });

            // Act
            var result = mapper.Map("command", "command");

            // Assert
            Assert.NotNull(result.Model.Command);
            Assert.NotNull(result.Model.Command.Command);

            Assert.IsType<OneCommandWithOneBoolOptionArgs>(result.Model.Command);
            Assert.IsType<OneBoolOptionArgs>(result.Model.Command.Command);
        }

        [Fact]
        internal void Command_SubCommand_Should_Be_Matched_With_Nested_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneCommandWithTwoLevelNestedClass>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, subCommandSettings => {
                    subCommandSettings.AddOption(x => x.NestedA.NestedB.Option);
                });
            });

            // Act
            var result = mapper.Map("command", "command", "--nested-a.nested-b.option");

            // Assert
            Assert.True(result.Model.Command.Command.NestedA.NestedB.Option);
        }

        [Fact]
        internal void Command_SubCommand_SubCommand_Should_Be_Matched_With_CustomName()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, "sub-command-1", subCommandSettings => {
                    subCommandSettings.AddSubCommand(x => x.Command, "sub-command-2");
                });
            });

            // Act
            var result = mapper.Map("command", "sub-command-1", "sub-command-2");

            // Assert
            Assert.NotNull(result.Model.Command);
            Assert.NotNull(result.Model.Command.Command);
            Assert.NotNull(result.Model.Command.Command.Command);

            Assert.IsType<TwoLevelNestedCommandArgs>(result.Model.Command);
            Assert.IsType<OneCommandWithOneBoolOptionArgs>(result.Model.Command.Command);
            Assert.IsType<OneBoolOptionArgs>(result.Model.Command.Command.Command);
        }

        [Fact]
        internal void Command_SubCommand_SubCommand_Should_Be_Matched_With_Default_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, subCommandSettings => {
                    subCommandSettings.AddSubCommand(x => x.Command);
                });
            });

            // Act
            var result = mapper.Map("command", "command", "command");

            // Assert
            Assert.NotNull(result.Model.Command);
            Assert.NotNull(result.Model.Command.Command);
            Assert.NotNull(result.Model.Command.Command.Command);

            Assert.IsType<TwoLevelNestedCommandArgs>(result.Model.Command);
            Assert.IsType<OneCommandWithOneBoolOptionArgs>(result.Model.Command.Command);
            Assert.IsType<OneBoolOptionArgs>(result.Model.Command.Command.Command);
        }

        [Fact]
        internal void Command_SubCommand_SubCommand_SubCommand_Should_Be_Matched_With_Default_Name()
        {
            // Arrange
            var mapper = new ArgsMapper<FourLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, subCommandSettings0 => {
                    subCommandSettings0.AddSubCommand(x => x.Command, subCommandSettings1 => {
                        subCommandSettings1.AddSubCommand(x => x.Command);
                    });
                });
            });

            // Act
            var result = mapper.Map("command", "command", "command", "command");

            // Assert
            Assert.NotNull(result.Model.Command);
            Assert.NotNull(result.Model.Command.Command);
            Assert.NotNull(result.Model.Command.Command.Command);
            Assert.NotNull(result.Model.Command.Command.Command.Command);

            Assert.IsType<ThreeLevelNestedCommandArgs>(result.Model.Command);
            Assert.IsType<TwoLevelNestedCommandArgs>(result.Model.Command.Command);
            Assert.IsType<OneCommandWithOneBoolOptionArgs>(result.Model.Command.Command.Command);
            Assert.IsType<OneBoolOptionArgs>(result.Model.Command.Command.Command.Command);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_SubCommand_Defined_But_Not_Matched()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command);
            });

            // Act
            var result = mapper.Map("command", "unknown-command");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("'unknown-command' is not a valid command.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_SubCommand_Not_Found()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command);

            // Act
            var result = mapper.Map("command", "unknown-command");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("'unknown-command' is not a valid command.", result.ErrorMessage);
        }

        [Fact]
        internal void SubCommand_Should_Be_Null_When_Disabled()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, subCommandSettings => {
                    subCommandSettings.IsDisabled = true;
                });
            });

            // Act
            var result = mapper.Map("command", "command");

            // Assert
            Assert.NotNull(result.Model.Command);
            Assert.Null(result.Model.Command.Command);
        }

        [Fact]
        internal void SubCommand_Should_Be_Null_When_Its_Parent_Disabled()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.IsDisabled = true;

                commandSettings.AddSubCommand(x => x.Command);
            });

            // Act
            var result = mapper.Map("command", "command");

            // Assert
            Assert.Null(result.Model.Command);
        }
    }
}
