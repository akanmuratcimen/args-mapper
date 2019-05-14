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
using System.Linq.Expressions;
using ArgsMapper.Models;
using ArgsMapper.Utilities;

namespace ArgsMapper.Infrastructure
{
    internal static class CommandInitializer
    {
        internal static Command Initialize<T, TProperty>(ArgsMapper<T> mapper, 
            Expression<Func<T, TProperty>> propertySelector, string name, 
            Action<ArgsCommandSettings<T, TProperty>> commandSettings) 
            where T : class where TProperty : class
        {
            var command = new Command();

            var propertyInfos = propertySelector.GetPropertyInfos();

            command.PropertyInfos = propertyInfos;
            command.Name = name ?? propertyInfos.GetName(mapper.Settings.Culture);
            command.CultureInfo = mapper.Settings.Culture;

            var settings = new ArgsCommandSettings<T, TProperty>();

            settings.Mapper = mapper;

            if (commandSettings is null)
            {
                return command;
            }

            commandSettings(settings);

            command.IsDisabled = settings.IsDisabled;
            command.Options = settings.Options;

            return command;
        }
    }
}
