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
using System.Collections.Generic;
using System.Linq.Expressions;
using ArgsMapper.Models;
using ArgsMapper.Utilities;

namespace ArgsMapper.PageBuilding
{
    internal class CommandPageSectionSettings<TCommand> : DefaultPageBuilder,
        ICommandPageSectionSettings<TCommand> where TCommand : class
    {
        private readonly IEnumerable<Option> _commandOptions;

        public CommandPageSectionSettings(IEnumerable<Option> commandOptions, IPageRenderer pageRenderer) :
            base(pageRenderer)
        {
            _commandOptions = commandOptions;
        }

        public void AddOption<TOption>(Expression<Func<TCommand, TOption>> propertySelector,
            Action<PageContentOptionSettings> settings = null)
        {
            PageContentOptionSettings contentOptionSettings = null;

            if (settings != null)
            {
                contentOptionSettings = new PageContentOptionSettings();

                settings(contentOptionSettings);
            }

            var option = _commandOptions.Get(propertySelector);

            if (option == null)
            {
                throw new OptionCouldNotBeFoundException(propertySelector.GetPropertyInfos()[0]);
            }

            _pageRenderer.AppendOption(PageContentRowFormattingStyle.Indent,
                option.ToString(), contentOptionSettings);
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
    }
}
