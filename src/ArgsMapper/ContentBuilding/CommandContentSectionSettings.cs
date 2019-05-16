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

namespace ArgsMapper.ContentBuilding
{
    internal class CommandContentSectionSettings<TCommand> : ICommandContentSectionSettings<TCommand>
        where TCommand : class
    {
        private readonly IEnumerable<Option> _commandOptions;
        private readonly IContentRenderer _contentRenderer;

        public CommandContentSectionSettings(IEnumerable<Option> commandOptions, IContentRenderer contentRenderer)
        {
            _commandOptions = commandOptions;
            _contentRenderer = contentRenderer;
        }

        public void AddOption<TOption>(Expression<Func<TCommand, TOption>> propertySelector,
            string description = null)
        {
            var option = _commandOptions.Get(propertySelector);

            _contentRenderer.AppendProperty(option.ToString(), description);
        }

        public void AddContent(params string[] contents)
        {
            _contentRenderer.AppendContent(contents);
        }

        public void AddTable(params (string column1, string column2)[] columns)
        {
            _contentRenderer.AppendTable(columns);
        }

        public void AddTable(params (string column1, string column2, string column3)[] columns)
        {
            _contentRenderer.AppendTable(columns);
        }

        public void AddTable(params (string column1, string column2, string column3,
            string column4)[] columns)
        {
            _contentRenderer.AppendTable(columns);
        }

        public void AddTable(params (string column1, string column2, string column3,
            string column4, string column5)[] columns)
        {
            _contentRenderer.AppendTable(columns);
        }

        public void AddTable(params (string column1, string column2, string column3,
            string column4, string column5, string column6)[] columns)
        {
            _contentRenderer.AppendTable(columns);
        }

        public string ContentText => _contentRenderer.ToString();
    }
}