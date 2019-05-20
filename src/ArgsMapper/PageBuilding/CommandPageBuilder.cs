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

using System;
using System.Collections.Generic;
using ArgsMapper.Models;

namespace ArgsMapper.PageBuilding
{
    internal class CommandPageBuilder<TCommand> : ICommandPageBuilder<TCommand> where TCommand : class
    {
        private readonly IEnumerable<Option> _commandOptions;
        private readonly IPageRenderer _pageRenderer;

        public CommandPageBuilder(IEnumerable<Option> commandOptions)
        {
            _commandOptions = commandOptions;
            _pageRenderer = new PageRenderer();
        }

        public void AddSection(string header, Action<ICommandPageSectionSettings<TCommand>> sectionSettings)
        {
            var contentRenderer = new PageRenderer();
            var settings = new CommandPageSectionSettings<TCommand>(_commandOptions, contentRenderer);

            sectionSettings(settings);

            _pageRenderer.AppendSection(header, contentRenderer.ToString());
        }

        public void AddContent(params string[] contents)
        {
            _pageRenderer.AppendContent(PageContentFormattingStyle.None, contents);
        }

        public string ContentText => _pageRenderer.ToString();

        public void AddTable((string, string) columns,
            params (string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentFormattingStyle.None, columns, rows);
        }

        public void AddTable((string, string, string) columns,
            params (string, string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentFormattingStyle.None, columns, rows);
        }

        public void AddTable((string, string, string, string) columns,
            params (string, string, string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentFormattingStyle.None, columns, rows);
        }

        public void AddTable((string, string, string, string, string) columns,
            params (string, string, string, string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentFormattingStyle.None, columns, rows);
        }

        public void AddTable((string, string, string, string, string, string) columns,
            params (string, string, string, string, string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentFormattingStyle.None, columns, rows);
        }
    }
}