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
using ArgsMapper.PageBuilding;
using ArgsMapper.Tests.Helpers;
using Xunit;

namespace ArgsMapper.Tests.PageBuildingTests
{
    public class PageRendererTests
    {
        [Fact]
        internal void Render_Command()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendCommand(
                PageContentRowFormattingStyle.None,
                "command-name",
                new PageContentCommandSettings {
                    Description = "command description."
                }
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("command-name  command description.", lines[0]);
        }

        [Fact]
        internal void Render_Command_With_NameColumnWidth()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendCommand(
                PageContentRowFormattingStyle.None,
                "command-name",
                new PageContentCommandSettings {
                    Description = "command description.",
                    NameColumnWidth = 20
                }
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("command-name          command description.", lines[0]);
        }

        [Fact]
        internal void Render_Command_Without_Description()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendCommand(
                PageContentRowFormattingStyle.None,
                "command-name",
                new PageContentCommandSettings()
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("command-name", lines[0]);
        }

        [Fact]
        internal void Render_Text()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendText(PageContentRowFormattingStyle.None, "content line");

            // Act
            var contentText = renderer.ToString();

            // Assert
            Assert.Equal("content line", contentText.TrimEnd());
        }

        [Fact]
        internal void Render_Text_Indent()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendText(PageContentRowFormattingStyle.Indent, "content line");

            // Act
            var contentText = renderer.ToString();

            // Assert
            Assert.Equal("  content line", contentText.TrimEnd());
        }

        [Fact]
        internal void Render_Text_Multiple_Append()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendText(PageContentRowFormattingStyle.None, "content line 1");
            renderer.AppendText(PageContentRowFormattingStyle.None, "content line 2");

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(2, lines.Length);

            Assert.Equal("content line 1", lines[0]);
            Assert.Equal("content line 2", lines[1]);
        }

        [Fact]
        internal void Render_Multiple_Text()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendText(PageContentRowFormattingStyle.None, "content line 1");
            renderer.AppendText(PageContentRowFormattingStyle.None, "content line 2");

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
            var renderer = new PageRenderer();

            renderer.AppendTable(
                PageContentRowFormattingStyle.None,
                ("column 1", "column 2", "column 3", "column 4", "column 5"),
                ("value 1", "value 2", "value 3", "value 4", "value 5")
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(2, lines.Length);

            Assert.Equal("column 1  column 2  column 3  column 4  column 5", lines[0]);
            Assert.Equal("value 1   value 2   value 3   value 4   value 5", lines[1]);
        }

        [Fact]
        internal void Render_Multiple_Four_Columns_Table()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendTable(
                PageContentRowFormattingStyle.None,
                ("column 1", "column 2", "column 3", "column 4"),
                ("value 1", "value 2", "value 3", "value 4")
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(2, lines.Length);

            Assert.Equal("column 1  column 2  column 3  column 4", lines[0]);
            Assert.Equal("value 1   value 2   value 3   value 4", lines[1]);
        }

        [Fact]
        internal void Render_Multiple_Six_Columns_Table()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendTable(
                PageContentRowFormattingStyle.None,
                ("column 1", "column 2", "column 3", "column 4", "column 5", "column 6"),
                ("value 1", "value 2", "value 3", "value 4", "value 5", "value 6")
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(2, lines.Length);

            Assert.Equal("column 1  column 2  column 3  column 4  column 5  column 6", lines[0]);
            Assert.Equal("value 1   value 2   value 3   value 4   value 5   value 6", lines[1]);
        }

        [Fact]
        internal void Render_Multiple_Three_Columns_Table()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendTable(
                PageContentRowFormattingStyle.None,
                ("column 1", "column 2", "column 3"),
                ("value 1", "value 2", "value 3")
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(2, lines.Length);

            Assert.Equal("column 1  column 2  column 3", lines[0]);
            Assert.Equal("value 1   value 2   value 3", lines[1]);
        }

        [Fact]
        internal void Render_Multiple_Two_Columns_Table()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendTable(
                PageContentRowFormattingStyle.None,
                ("column 1", "column 2"),
                ("value 1", "value 2")
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(2, lines.Length);

            Assert.Equal("column 1  column 2", lines[0]);
            Assert.Equal("value 1   value 2", lines[1]);
        }

        [Fact]
        internal void Render_Option()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendOption(
                PageContentRowFormattingStyle.None,
                "option-name",
                new PageContentOptionSettings {
                    Description = "option description."
                }
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("option-name  option description.", lines[0]);
        }

        [Fact]
        internal void Render_Option_With_NameColumnWidth()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendOption(
                PageContentRowFormattingStyle.None,
                "option-name",
                new PageContentOptionSettings {
                    Description = "option description.",
                    NameColumnWidth = 20
                }
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("option-name           option description.", lines[0]);
        }

        [Fact]
        internal void Render_Option_Without_Description()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendOption(
                PageContentRowFormattingStyle.None,
                "option-name",
                new PageContentOptionSettings()
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Single(lines);

            Assert.Equal("option-name", lines[0]);
        }

        [Fact]
        internal void Render_Section()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendSection(
                "header",
                $"section content line 1{Environment.NewLine}section content line 2"
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(3, lines.Length);

            Assert.Equal("header", lines[0]);
            Assert.Equal("section content line 1", lines[1]);
            Assert.Equal("section content line 2", lines[2]);
        }

        [Fact]
        internal void Render_Table_Indent()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendTable(
                PageContentRowFormattingStyle.Indent,
                ("column 1", "column 2"),
                ("value 1", "value 2")
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(2, lines.Length);

            Assert.Equal("  column 1  column 2", lines[0]);
            Assert.Equal("  value 1   value 2", lines[1]);
        }

        [Fact]
        internal void Render_Table_Multiple_Indent()
        {
            // Arrange
            var renderer = new PageRenderer();

            renderer.AppendTable(
                PageContentRowFormattingStyle.Indent,
                ("column 1", "column 2"),
                ("value 1", "value 2"),
                ("value 3", "value 4")
            );

            // Act
            var contentText = renderer.ToString();

            // Assert
            var lines = contentText.ToLines();

            Assert.Equal(3, lines.Length);

            Assert.Equal("  column 1  column 2", lines[0]);
            Assert.Equal("  value 1   value 2", lines[1]);
            Assert.Equal("  value 3   value 4", lines[2]);
        }
    }
}
