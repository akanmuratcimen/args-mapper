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
using ArgsMapper.InitializationValidations.OptionValidations;
using Xunit;

namespace ArgsMapper.Tests.InitializationValidationTests
{
    public class OptionInitializationValidationTests
    {
        [Theory]
        [InlineData("opt:ion")]
        [InlineData("opt=ion")]
        [InlineData("opt ion")]
        internal void AddOption_Should_Throw_InvalidOptionLongNameException(string optionLongName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Assert
            Assert.Throws<InvalidOptionLongNameException>(() =>
                mapper.AddOption(x => x.Option, optionLongName)
            );
        }

        [Theory]
        [InlineData("opt:ion")]
        [InlineData("opt=ion")]
        [InlineData("opt ion")]
        internal void AddPositionalOption_Should_Throw_InvalidOptionLongNameException(string optionLongName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Assert
            Assert.Throws<InvalidOptionLongNameException>(() =>
                mapper.AddPositionalOption(x => x.Option, optionLongName)
            );
        }

        [Theory]
        [InlineData('0')]
        [InlineData('-')]
        [InlineData('/')]
        [InlineData('+')]
        [InlineData('=')]
        [InlineData('.')]
        internal void AddOption_Should_Throw_InvalidOptionShortNameException(char optionShortName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Assert
            Assert.Throws<InvalidOptionShortNameException>(() =>
                mapper.AddOption(x => x.Option, optionShortName, "option")
            );
        }

        [Theory]
        [InlineData("version")]
        [InlineData("help")]
        internal void AddOption_Should_Throw_ReservedOptionLongNameException(string optionLongName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Assert
            Assert.Throws<ReservedOptionLongNameException>(() =>
                mapper.AddOption(x => x.Option, optionLongName)
            );
        }

        [Theory]
        [InlineData("version")]
        [InlineData("help")]
        internal void AddPositionalOption_Should_Throw_ReservedOptionLongNameException(string optionLongName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Assert
            Assert.Throws<ReservedOptionLongNameException>(() =>
                mapper.AddPositionalOption(x => x.Option, optionLongName)
            );
        }

        [Theory]
        [InlineData('v')]
        [InlineData('h')]
        internal void AddOption_Should_Throw_ReservedOptionShortNameException(char optionShortName)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Assert
            Assert.Throws<ReservedOptionShortNameException>(() =>
                mapper.AddOption(x => x.Option, optionShortName, "option")
            );
        }

        [Fact]
        internal void AddOption_Should_Throw_ArgumentException_When_Property_Has_No_Setter()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolWithoutSetterOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddOption(x => x.Option)
            );
        }

        [Fact]
        internal void AddOption_Should_Throw_ArgumentException_When_Property_Internal()
        {
            // Arrange
            var mapper = new ArgsMapper<OneInternalBoolOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddOption(x => x.Option)
            );
        }

        [Fact]
        internal void AddOption_Should_Throw_ArgumentException_When_Property_Method()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolMethodOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddOption(x => x.Option())
            );
        }

        [Fact]
        internal void AddOption_Should_Throw_OptionLongNameAlreadyExistsException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);

            // Assert
            Assert.Throws<OptionLongNameAlreadyExistsException>(() =>
                mapper.AddOption(x => x.Option)
            );
        }

        [Fact]
        internal void AddOption_Should_Throw_OptionLongNameRequiredException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Assert
            Assert.Throws<OptionLongNameRequiredException>(() =>
                mapper.AddOption(x => x.Option, string.Empty)
            );
        }

        [Fact]
        internal void AddOption_Should_Throw_OptionShortNameAlreadyExistsException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option, 'o', "option1");

            // Assert
            Assert.Throws<OptionShortNameAlreadyExistsException>(() =>
                mapper.AddOption(x => x.Option, 'o', "option2")
            );
        }

        [Fact]
        internal void AddOption_Should_Throw_UnsupportedOptionPropertyTypeException()
        {
            // Arrange
            var mapper = new ArgsMapper<UnsupportedTypeOptionArgs>();

            // Assert
            Assert.Throws<UnsupportedOptionPropertyTypeException>(() =>
                mapper.AddOption(x => x.QueueOption)
            );

            Assert.Throws<UnsupportedOptionPropertyTypeException>(() =>
                mapper.AddOption(x => x.StackOption)
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_ArgumentException_When_Property_Has_No_Setter()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolWithoutSetterOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddPositionalOption(x => x.Option)
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_ArgumentException_When_Property_Internal()
        {
            // Arrange
            var mapper = new ArgsMapper<OneInternalBoolOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddPositionalOption(x => x.Option)
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_ArgumentException_When_Property_Method()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolMethodOptionArgs>();

            // Assert
            Assert.Throws<ArgumentException>(() =>
                mapper.AddPositionalOption(x => x.Option())
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_OptionLongNameAlreadyExistsException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Option);

            // Assert
            Assert.Throws<OptionLongNameAlreadyExistsException>(() =>
                mapper.AddPositionalOption(x => x.Option)
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_OptionLongNameRequiredException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            // Assert
            Assert.Throws<OptionLongNameRequiredException>(() =>
                mapper.AddPositionalOption(x => x.Option, string.Empty)
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_PositionalOptionConflictsWithCommandException()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionAndOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command);

            // Assert
            Assert.Throws<PositionalOptionConflictsWithCommandException>(() =>
                mapper.AddPositionalOption(x => x.Option)
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_PositionalOptionListConflictException_PositionalOption()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Options);

            // Assert
            Assert.Throws<PositionalOptionListConflictException>(() =>
                mapper.AddPositionalOption(x => x.Option)
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_PositionalOptionListConflictException_PositionalOption_List()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoListStringOptionArgs>();

            mapper.AddPositionalOption(x => x.Options1);

            // Assert
            Assert.Throws<PositionalOptionListConflictException>(() =>
                mapper.AddPositionalOption(x => x.Options2)
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_PositionalOptionListConflictException_PositionalOption_Reverse()
        {
            // Arrange
            var mapper = new ArgsMapper<OneListStringOptionWithOneBoolOptionArgs>();

            mapper.AddPositionalOption(x => x.Option);

            // Assert
            Assert.Throws<PositionalOptionListConflictException>(() =>
                mapper.AddPositionalOption(x => x.Options)
            );
        }

        [Fact]
        internal void AddPositionalOption_Should_Throw_UnsupportedOptionPropertyTypeException_Class()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            // Assert
            Assert.Throws<UnsupportedOptionPropertyTypeException>(() =>
                mapper.AddPositionalOption(x => x.Command)
            );
        }
    }
}
