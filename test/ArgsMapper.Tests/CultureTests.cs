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
using System.Globalization;
using Xunit;

namespace ArgsMapper.Tests
{
    public class CultureTests
    {
        [Fact]
        internal void Mapper_Should_Map_DateTime_With_Specified_Culture()
        {
            // Arrange
            var mapper = new ArgsMapper<OneDateTimeOptionArgs>();

            mapper.Settings.Culture = CultureInfo.GetCultureInfo("tr");

            mapper.AddOption(x => x.Option);

            // Act
            var result = mapper.Map("--option", "27.05.2019 21:53:20");

            // Assert
            Assert.Equal(new DateTime(2019, 05, 27, 21, 53, 20), result.Model.Option);
        }

        [Fact]
        internal void Mapper_Should_Map_Number_With_Specified_Culture()
        {
            // Arrange
            var mapper = new ArgsMapper<OneDoubleOptionArgs>();

            mapper.Settings.Culture = CultureInfo.GetCultureInfo("tr");

            mapper.AddOption(x => x.Option);

            // Act
            var result = mapper.Map("--option", "3,14");

            // Assert
            Assert.Equal(3.14, result.Model.Option);
        }
    }
}
