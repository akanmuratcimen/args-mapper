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
using System.Linq.Expressions;
using ArgsMapper.Models;
using ArgsMapper.Utilities;

namespace ArgsMapper.PageBuilding
{
    internal class GeneralPageSectionSettings<T> : IGeneralPageSectionSettings<T> where T : class
    {
        private readonly IEnumerable<Command> _commands;
        private readonly IEnumerable<Option> _options;
        private readonly IPageRenderer _pageRenderer;

        public GeneralPageSectionSettings(IEnumerable<Command> commands,
            IEnumerable<Option> options, IPageRenderer pageRenderer)
        {
            _commands = commands;
            _options = options;
            _pageRenderer = pageRenderer;
        }

        public void AddOption<TOption>(Expression<Func<T, TOption>> propertySelector,
            Action<PageContentOptionSettings> settings = null)
        {
            PageContentOptionSettings contentOptionSettings = null;

            if (settings != null)
            {
                contentOptionSettings = new PageContentOptionSettings();

                settings(contentOptionSettings);
            }

            var option = _options.Get(propertySelector);

            if (option == null)
            {
                throw new OptionCouldNotBeFoundException(propertySelector.GetPropertyInfos()[0]);
            }

            _pageRenderer.AppendOption(PageContentRowFormattingStyle.Indent,
                option.ToString(), contentOptionSettings);
        }

        public void AddCommand<TCommand>(Expression<Func<T, TCommand>> propertySelector,
            Action<PageContentCommandSettings> settings = null) where TCommand : class
        {
            PageContentCommandSettings contentCommandSettings = null;

            if (settings != null)
            {
                contentCommandSettings = new PageContentCommandSettings();

                settings(contentCommandSettings);
            }

            var command = _commands.Get(propertySelector);

            if (command == null)
            {
                throw new CommandCouldNotBeFoundException(propertySelector.GetPropertyInfos()[0]);
            }

            _pageRenderer.AppendCommand(PageContentRowFormattingStyle.Indent,
                command.ToString(), contentCommandSettings);
        }

        public void AddHelpOption(Action<PageContentOptionSettings> settings = null)
        {
            PageContentOptionSettings contentOptionSettings = null;

            if (settings != null)
            {
                contentOptionSettings = new PageContentOptionSettings();

                settings(contentOptionSettings);
            }

            _pageRenderer.AppendOption(PageContentRowFormattingStyle.Indent,
                Constants.HelpOptionString, contentOptionSettings);
        }

        public void AddVersionOption(Action<PageContentOptionSettings> settings = null)
        {
            PageContentOptionSettings contentOptionSettings = null;

            if (settings != null)
            {
                contentOptionSettings = new PageContentOptionSettings();

                settings(contentOptionSettings);
            }

            _pageRenderer.AppendOption(PageContentRowFormattingStyle.Indent,
                Constants.VersionOptionString, contentOptionSettings);
        }

        public void AddEmptyLine()
        {
            _pageRenderer.AppendText(PageContentRowFormattingStyle.None, string.Empty);
        }

        public void AddText(params string[] contents)
        {
            _pageRenderer.AppendText(PageContentRowFormattingStyle.Indent, contents);
        }

        public void AddTable((string, string) columns,
            params (string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentRowFormattingStyle.Indent, columns, rows);
        }

        public void AddTable((string, string, string) columns,
            params (string, string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentRowFormattingStyle.Indent, columns, rows);
        }

        public void AddTable((string, string, string, string) columns,
            params (string, string, string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentRowFormattingStyle.Indent, columns, rows);
        }

        public void AddTable((string, string, string, string, string) columns,
            params (string, string, string, string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentRowFormattingStyle.Indent, columns, rows);
        }

        public void AddTable((string, string, string, string, string, string) columns,
            params (string, string, string, string, string, string)[] rows)
        {
            _pageRenderer.AppendTable(PageContentRowFormattingStyle.Indent, columns, rows);
        }

        public string Content => _pageRenderer.ToString();
    }
}
