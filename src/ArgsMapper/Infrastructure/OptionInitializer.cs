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
using System.Linq.Expressions;
using ArgsMapper.Models;
using ArgsMapper.Utilities;

namespace ArgsMapper.Infrastructure
{
    internal static class OptionInitializer
    {
        internal static Option Initialize<T, TOption>(Expression<Func<T, TOption>> propertySelector,
            char? shortName, string longName, int? position, Action<ArgsOptionSettings<TOption>> optionSettings,
            CultureInfo cultureInfo)
        {
            var option = new Option();

            var propertyInfos = propertySelector.GetPropertyInfos();

            option.PropertyInfos = propertyInfos;

            option.LongName = longName ?? propertyInfos.GetName(cultureInfo);
            option.ShortName = shortName.HasValue && shortName == '\0' ? null : shortName;
            option.Position = position;
            option.CultureInfo = cultureInfo;

            if (optionSettings is null)
            {
                return option;
            }

            var argsOption = new ArgsOptionSettings<TOption>();

            optionSettings(argsOption);

            option.DefaultValue = argsOption.DefaultValue;
            option.IsDisabled = argsOption.IsDisabled;
            option.IsRequired = argsOption.IsRequired;

            return option;
        }
    }
}
