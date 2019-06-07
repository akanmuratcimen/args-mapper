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
    public class OptionTests
    {
        [Theory]
        [InlineData("--option", "off")]
        [InlineData("--option", "0")]
        [InlineData("--option", "false")]
        [InlineData("-a", "off")]
        [InlineData("-a", "0")]
        [InlineData("-a", "false")]
        internal void Option_Bool_Value_Should_Be_False(params string[] args)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option, 'a', "option");

            // Act
            var result = mapper.Map(args);

            // Assert
            Assert.False(result.Model.Option);
        }

        [Theory]
        [InlineData("--option")]
        [InlineData("-a")]
        [InlineData("--option", "on")]
        [InlineData("--option", "1")]
        [InlineData("--option", "true")]
        [InlineData("-a", "on")]
        [InlineData("-a", "1")]
        [InlineData("-a", "true")]
        internal void Option_Bool_Value_Should_Be_True(params string[] args)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option, 'a', "option");

            // Act
            var result = mapper.Map(args);

            // Assert
            Assert.True(result.Model.Option);
        }

        [Theory]
        [InlineData("Option", StringComparison.InvariantCulture, false)]
        [InlineData("Option", StringComparison.InvariantCultureIgnoreCase, true)]
        internal void Option_Should_Match_Or_Not_By_StringComparison(
            string arg, StringComparison stringComparison, bool expected)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Settings.StringComparison = stringComparison;

            mapper.AddOption(x => x.Option, 'o', "option");

            // Act
            var result = mapper.Map($"--{arg}");

            // Assert
            Assert.Equal(expected, result.Model.Option);
        }

        [Theory]
        [InlineData("value:value")]
        [InlineData("value=value:value")]
        [InlineData(":value")]
        [InlineData("=value")]
        [InlineData("::value")]
        [InlineData("==value")]
        [InlineData("value:")]
        [InlineData("value=")]
        internal void PositionalOption_Should_Be_Matched_With_Assignment_Operator_Included_Values(string value)
        {
            // Arrange
            var mapper = new ArgsMapper<OneStringOptionArgs>();

            mapper.AddPositionalOption(x => x.Option);

            // Act
            var result = mapper.Map(value);

            // Assert
            Assert.Equal(value, result.Model.Option);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Args_Exceeded_PositionalOption_Definitions()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeIntOptionsArgs>();

            mapper.AddPositionalOption(x => x.Option1);
            mapper.AddPositionalOption(x => x.Option2);
            mapper.AddPositionalOption(x => x.Option3);

            // Act
            var result = mapper.Map("1", "2", "3", "4");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("There is no matched option for value '4'.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_CommandPositionalOption_Value_Valid_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Option);
            });

            // Act
            var result = mapper.Map("command", "--foobar");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Unknown 'command' command option 'foobar'.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Option_Has_Not_Valid_Value()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option);

            // Act
            var result = mapper.Map("--option", "non-integer-value");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("'non-integer-value' not a valid value for '--option' option.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Option_Is_Disabled()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option, optionSettings => {
                optionSettings.IsDisabled = true;
            });

            // Act
            var result = mapper.Map("--option");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Unknown option 'option'.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Option_Is_Required()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option, optionSettings => {
                optionSettings.IsRequired = true;
            });

            // Act
            var result = mapper.Map();

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Required option '--option' is missing.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_Option_Not_Defined()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option);

            // Act
            var result = mapper.Map("--option1");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Unknown option 'option1'.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_PositionalOption_Is_Required()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddPositionalOption(x => x.Option, optionSettings => {
                optionSettings.IsRequired = true;
            });

            // Act
            var result = mapper.Map();

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Required option 'option' is missing.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_PositionalOption_List_Is_Required()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionArgs>();

            mapper.AddPositionalOption(x => x.Option, optionSettings => {
                optionSettings.IsRequired = true;
            });

            // Act
            var result = mapper.Map();

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Required option 'option' is missing.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Error_When_PositionalOption_Value_Valid_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddPositionalOption(x => x.Option);

            // Act
            var result = mapper.Map("--foobar");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Unknown option 'foobar'.", result.ErrorMessage);
        }

        [Fact]
        internal void MapperResult_Should_Have_Required_Error_Even_When_Same_Property_Mapped_By_Another_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option, "option-1");

            mapper.AddOption(x => x.Option, "option-2", optionSettings => {
                optionSettings.IsRequired = true;
            });

            // Act
            var result = mapper.Map("--option-1", "1");

            // Assert
            Assert.True(result.HasError);
            Assert.Equal("Required option '--option-2' is missing.", result.ErrorMessage);
        }

        [Fact]
        internal void Option_Default_Value_Should_Be_Override()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option, optionSettings => {
                optionSettings.DefaultValue = 1;
            });

            // Act
            var result = mapper.Map("--option", "2");

            // Assert
            Assert.Equal(2, result.Model.Option);
        }

        [Fact]
        internal void Option_Should_Be_Matched_With_Custom_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option, "custom-named-option-1");

            // Act
            var result = mapper.Map("--custom-named-option-1", "1");

            // Assert
            Assert.Equal(1, result.Model.Option);
        }

        [Fact]
        internal void Option_Should_Be_Matched_With_Default_LongName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option);

            // Act
            var result = mapper.Map("--option", "1");

            // Assert
            Assert.Equal(1, result.Model.Option);
        }

        [Fact]
        internal void Option_Should_Be_Matched_With_Default_LongName_HyphenCase()
        {
            // Arrange
            var mapper = new ArgsMapper<OneLongNamedBoolOptionArgs>();

            mapper.AddOption(x => x.SomeOptionProperty);

            // Act
            var result = mapper.Map("--some-option-property");

            // Assert
            Assert.True(result.Model.SomeOptionProperty);
        }

        [Fact]
        internal void Option_Should_Be_Matched_With_ShortName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option, 'a', "option-1");

            // Act
            var result = mapper.Map("-a", "1");

            // Assert
            Assert.Equal(1, result.Model.Option);
        }

        [Fact]
        internal void Option_Value_Should_Be_Default_Value()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option, optionSettings => {
                optionSettings.DefaultValue = 1;
            });

            // Act
            var result = mapper.Map();

            // Assert
            Assert.Equal(1, result.Model.Option);
        }

        [Fact]
        internal void Option_Value_Should_Be_Default_Value_Multiple()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeIntOptionsArgs>();

            mapper.AddOption(x => x.Option1, optionSettings => {
                optionSettings.DefaultValue = 1;
            });

            mapper.AddOption(x => x.Option2, optionSettings => {
                optionSettings.DefaultValue = 2;
            });

            mapper.AddOption(x => x.Option3, optionSettings => {
                optionSettings.DefaultValue = 3;
            });

            // Act
            var result = mapper.Map();

            // Assert
            Assert.Equal(1, result.Model.Option1);
            Assert.Equal(2, result.Model.Option2);
            Assert.Equal(3, result.Model.Option3);
        }

        [Fact]
        internal void Option_Value_Should_Be_Last_Value_In_The_Args()
        {
            // Arrange
            var mapper = new ArgsMapper<OneIntOptionArgs>();

            mapper.AddOption(x => x.Option, "option-1");

            // Act
            var result = mapper.Map("--option-1", "1", "--option-1", "2");

            // Assert
            Assert.Equal(2, result.Model.Option);
        }

        [Fact]
        internal void Option_Values_Should_Be_Matched_With_One_Level_Nested_Class()
        {
            // Arrange
            var mapper = new ArgsMapper<OneLevelNestedClassWithTwoBoolOptionArgs>();

            mapper.AddOption(x => x.Nested.Option1);
            mapper.AddOption(x => x.Nested.Option2);

            // Act
            var result = mapper.Map("--nested.option1", "--nested.option2");

            // Assert
            Assert.True(result.Model.Nested.Option1);
            Assert.True(result.Model.Nested.Option2);
        }

        [Fact]
        internal void Option_Values_Should_Be_Matched_With_Two_Level_Nested_Class()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedClass>();

            mapper.AddOption(x => x.NestedA.NestedB.Option);

            // Act
            var result = mapper.Map("--nested-a.nested-b.option");

            // Assert
            Assert.True(result.Model.NestedA.NestedB.Option);
        }

        [Fact]
        internal void Option_Values_Should_Be_Merged_LongName_And_ShortName()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListIntOptionArgs>();

            mapper.AddOption(x => x.Option, 'o', "option");

            // Act
            var result = mapper.Map("-o", "1", "--option", "2");

            // Assert
            Assert.Contains(1, result.Model.Option);
            Assert.Contains(2, result.Model.Option);
        }

        [Fact]
        internal void Option_Values_Should_Be_Merged_Same_Property_Different_LongNames()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListIntOptionArgs>();

            mapper.AddOption(x => x.Option, "option1");
            mapper.AddOption(x => x.Option, "option2");

            // Act
            var result = mapper.Map("--option1", "1", "--option2", "2");

            // Assert
            Assert.Contains(1, result.Model.Option);
            Assert.Contains(2, result.Model.Option);
        }

        [Fact]
        internal void PositionalOption_List_Should_Have_Arg_Values()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionArgs>();

            mapper.AddPositionalOption(x => x.Option);

            // Act
            var result = mapper.Map("foo", "bar");

            // Assert
            Assert.Equal(new[] { "foo", "bar" }, result.Model.Option);
        }

        [Fact]
        internal void PositionalOption_List_Should_Have_Arg_Values_With_Option()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Options);
            mapper.AddOption(x => x.Option);

            // Act
            var result = mapper.Map("foo", "bar", "--option", "1");

            // Assert
            Assert.Equal(new[] { "foo", "bar" }, result.Model.Options);
            Assert.Equal(1, result.Model.Option);
        }

        [Fact]
        internal void PositionalOption_Should_Be_Matched_Bool_Values()
        {
            // Arrange
            var mapper = new ArgsMapper<FourBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Option1);
            mapper.AddPositionalOption(x => x.Option2);
            mapper.AddPositionalOption(x => x.Option3);
            mapper.AddPositionalOption(x => x.Option4);

            // Act
            var result = mapper.Map("1", "on", "true", "0");

            // Assert
            Assert.True(result.Model.Option1);
            Assert.True(result.Model.Option2);
            Assert.True(result.Model.Option3);
            Assert.False(result.Model.Option4);
        }

        [Fact]
        internal void PositionalOption_Should_Be_Matched_Bool_Values_Ignore_Case()
        {
            // Arrange
            var mapper = new ArgsMapper<FourBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Option1);
            mapper.AddPositionalOption(x => x.Option2);
            mapper.AddPositionalOption(x => x.Option3);
            mapper.AddPositionalOption(x => x.Option4);

            // Act
            var result = mapper.Map("ON", "True", "oFF", "falSe");

            // Assert
            Assert.True(result.Model.Option1);
            Assert.True(result.Model.Option2);

            Assert.False(result.Model.Option3);
            Assert.False(result.Model.Option4);
        }

        [Fact]
        internal void PositionalOption_Should_Be_Matched_Values_In_Order()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeIntOptionsArgs>();

            mapper.AddPositionalOption(x => x.Option1);
            mapper.AddPositionalOption(x => x.Option2);
            mapper.AddPositionalOption(x => x.Option3);

            // Act
            var result = mapper.Map("1", "2", "3");

            // Assert
            Assert.Equal(1, result.Model.Option1);
            Assert.Equal(2, result.Model.Option2);
            Assert.Equal(3, result.Model.Option3);
        }

        [Fact]
        internal void PositionalOption_Should_Be_Matched_Values_With_Default_Values()
        {
            // Arrange
            var mapper = new ArgsMapper<ThreeIntOptionsArgs>();

            mapper.AddPositionalOption(x => x.Option1);
            mapper.AddPositionalOption(x => x.Option2);
            mapper.AddPositionalOption(x => x.Option3);

            // Act
            var result = mapper.Map("1");

            // Assert
            Assert.Equal(1, result.Model.Option1);
            Assert.Equal(0, result.Model.Option2);
            Assert.Equal(0, result.Model.Option3);
        }

        [Fact]
        internal void PositionalOption_Should_Be_Used_With_Named_Options()
        {
            // Arrange
            var mapper = new ArgsMapper<FourBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Option1);
            mapper.AddOption(x => x.Option2);
            mapper.AddPositionalOption(x => x.Option3);
            mapper.AddOption(x => x.Option4, 'o', "option4");

            // Act
            var result = mapper.Map("1", "off", "-o", "--option2", "on");

            // Assert
            Assert.True(result.Model.Option1);
            Assert.True(result.Model.Option2);
            Assert.False(result.Model.Option3);
            Assert.True(result.Model.Option4);
        }
    }
}
