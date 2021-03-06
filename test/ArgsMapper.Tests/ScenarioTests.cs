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
    public class ScenarioTests
    {
        [Fact]
        internal void Complex_Type_Scenario_Test_1()
        {
            // Arrange
            var mapper = new ArgsMapper<ComplexType1>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.SubCommand, subcommandSettings => {
                    subcommandSettings.AddOption(x => x.Option1);
                    subcommandSettings.AddOption(x => x.Option2);
                    subcommandSettings.AddOption(x => x.Option3);

                    subcommandSettings.AddOption(x => x.Option4, 'a', "option-4");
                    subcommandSettings.AddOption(x => x.Option5, 'b', "option-5");
                    subcommandSettings.AddOption(x => x.Option6, 'c', "option-6");

                    subcommandSettings.AddPositionalOption(x => x.Option7);
                });
            });

            // Act
            var result = mapper.Map(
                "command", "sub-command", "--option1", "1", "1.1", "-4", "xyz",
                "--option2", "2", "--option3", "-abc", "--", "foo", "bar"
            );

            // Assert
            Assert.NotNull(result.Model.Command);
            Assert.NotNull(result.Model.Command.SubCommand);
            Assert.Equal(new[] { "1", "1.1", "-4", "xyz" }, result.Model.Command.SubCommand.Option1);
            Assert.Equal(2, result.Model.Command.SubCommand.Option2);
            Assert.True(result.Model.Command.SubCommand.Option3);

            Assert.True(result.Model.Command.SubCommand.Option4);
            Assert.True(result.Model.Command.SubCommand.Option5);
            Assert.True(result.Model.Command.SubCommand.Option6);

            Assert.Equal(new[] { "foo", "bar" }, result.Model.Command.SubCommand.Option7);
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Unknown_Option_Error_When_Help_Alias_In_Stacked_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeBoolOptionsArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddOption(x => x.Option1, 'x', "option-1");
            mapper.AddOption(x => x.Option2, 'y', "option-2");
            mapper.AddOption(x => x.Option3, 'z', "option-3");

            mapper.Usage.AddText("sample usage text.");

            // Act
            mapper.Execute(new[] { "-hxyz" }, null);

            // Assert
            Assert.Equal("Unknown option '-h'.", output.ToString().TrimEnd());
        }

        [Fact]
        internal void Mapper_Output_Should_Be_Unknown_Option_Error_When_Version_Alias_In_Stacked_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeBoolOptionsArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            mapper.AddOption(x => x.Option1, 'x', "option-1");
            mapper.AddOption(x => x.Option2, 'y', "option-2");
            mapper.AddOption(x => x.Option3, 'z', "option-3");

            mapper.Usage.AddText("sample usage text.");

            // Act
            mapper.Execute(new[] { "-vxyz" }, null);

            // Assert
            Assert.Equal("Unknown option '-v'.", output.ToString().TrimEnd());
        }

        [Fact]
        internal void Mapper_Should_Throw_MissingMethodException_When_There_Is_No_Default_Constructor()
        {
            // Arrange
            var mapper = new ArgsMapper<ThereIsNoDefaultConstructor>();

            mapper.AddOption(x => x.Option);

            // Act
            // Assert
            Assert.Throws<MissingMethodException>(() => {
                mapper.Map();
            });
        }

        [Fact]
        internal void Output_Should_Be_Unknown_Command_Error_When_Input_Is_Not_Valid_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Act
            var result = mapper.Map("command");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("'command' is not a valid command.", result.ErrorMessage);
        }

        [Fact]
        internal void Output_Should_Be_Unknown_Option_Error_When_Input_Is_Valid_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Act
            var result = mapper.Map("--option");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Unknown option '--option'.", result.ErrorMessage);
        }

        [Fact]
        internal void Should_Be_Use_Command_PositionalOption_List_With_Another_Command_Option()
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
            Assert.Contains("foo", result.Model.Command.Options);
            Assert.Contains("bar", result.Model.Command.Options);

            Assert.Equal(1, result.Model.Command.Option);
        }

        [Fact]
        internal void Should_Be_Use_PositionalOption_List_With_Another_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Options);
            mapper.AddOption(x => x.Option);

            // Act
            var result = mapper.Map("foo", "bar", "--option", "1");

            // Assert
            Assert.Contains("foo", result.Model.Options);
            Assert.Contains("bar", result.Model.Options);

            Assert.Equal(1, result.Model.Option);
        }

        [Fact]
        internal void Should_Be_Valid_Adding_An_Command_After_An_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);
            mapper.AddCommand(x => x.Command);

            // Act
            var result = mapper.Map("--option", "1");

            // Assert
            Assert.True(result.Model.Option);
        }

        [Fact]
        internal void Should_Be_Valid_Adding_An_Option_After_An_Command()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command);
            mapper.AddOption(x => x.Option);

            // Act
            var result = mapper.Map("--option", "0");

            // Assert
            Assert.False(result.Model.Option);
        }

        [Fact]
        internal void Should_Be_Valid_Adding_Multiple_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeIntOptionsArgs>();

            mapper.AddOption(x => x.Option1);
            mapper.AddOption(x => x.Option2);
            mapper.AddOption(x => x.Option3);

            // Act
            var result = mapper.Map("--option1", "1", "--option2", "2", "--option3", "3");

            // Assert
            Assert.Equal(1, result.Model.Option1);
            Assert.Equal(2, result.Model.Option2);
            Assert.Equal(3, result.Model.Option3);
        }
    }
}
