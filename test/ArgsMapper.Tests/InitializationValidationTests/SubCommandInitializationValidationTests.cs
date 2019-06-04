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

using ArgsMapper.InitializationValidations.SubCommandValidations;
using Xunit;

namespace ArgsMapper.Tests.InitializationValidationTests
{
    public class SubCommandInitializationValidationTests
    {
        [Fact]
        internal void AddCommand_AddSubCommand_Should_Throw_CommandNameAlreadyExistsException()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            // Assert
            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubCommand(x => x.Command, "command");

                Assert.Throws<SubCommandNameAlreadyExistsException>(() => {
                    commandSettings.AddSubCommand(x => x.Command, "command");
                });
            });
        }

        [Fact]
        internal void AddCommand_AddSubCommand_Should_Throw_CommandNameRequiredException()
        {
            // Arrange
            var mapper = new ArgsMapper<TwoLevelNestedCommandArgs>();

            // Assert
            Assert.Throws<SubCommandNameRequiredException>(() =>
                mapper.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.AddSubCommand(x => x.Command, string.Empty);
                })
            );
        }
    }
}
