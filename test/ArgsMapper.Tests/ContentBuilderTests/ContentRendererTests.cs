// The MIT License (MIT)
// 
// Copyright (c) 2019 Akan Murat Cimen
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using ArgsMapper.ContentBuilding;
using ArgsMapper.Tests.Helpers;
using Xunit;

namespace ArgsMapper.Tests.ContentBuilderTests
{
    public class ContentRendererTests
    {
        [Fact]
        internal void Render_Content()
        {
            // Arrange
            var renderer = new ContentRenderer();

            renderer.AppendContent("content line");

            // Act
            var contentText = renderer.ToString();

            // Assert
            Assert.Equal("content line", contentText);
        }

        [Fact]
        internal void Render_Multiple_Content()
        {
            // Arrange
            var renderer = new ContentRenderer();

            renderer.AppendContent("content line 1");
            renderer.AppendContent("content line 2");

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(2, lines.Length);

            Assert.Equal("content line 1", lines[0]);
            Assert.Equal("content line 2", lines[1]);
        }

        [Fact]
        internal void Render_Multiple_Five_Columns_Table()
        {
            // Arrange
            var renderer = new ContentRenderer();

            renderer.AppendTable(("value 1", "value 2", "value 3", "value 4", "value 5"));

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("value 1    value 2    value 3    value 4    value 5", lines[0]);
        }

        [Fact]
        internal void Render_Multiple_Four_Columns_Table()
        {
            // Arrange
            var renderer = new ContentRenderer();

            renderer.AppendTable(("value 1", "value 2", "value 3", "value 4"));

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("value 1    value 2    value 3    value 4", lines[0]);
        }

        [Fact]
        internal void Render_Multiple_Six_Columns_Table()
        {
            // Arrange
            var renderer = new ContentRenderer();

            renderer.AppendTable(("value 1", "value 2", "value 3", "value 4", "value 5", "value 6"));

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("value 1    value 2    value 3    value 4    value 5    value 6", lines[0]);
        }

        [Fact]
        internal void Render_Multiple_Three_Columns_Table()
        {
            // Arrange
            var renderer = new ContentRenderer();

            renderer.AppendTable(("value 1", "value 2", "value 3"));

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("value 1    value 2    value 3", lines[0]);
        }

        [Fact]
        internal void Render_Multiple_Two_Columns_Table()
        {
            // Arrange
            var renderer = new ContentRenderer();

            renderer.AppendTable(("value 1", "value 2"));

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("value 1    value 2", lines[0]);
        }
    }
}
