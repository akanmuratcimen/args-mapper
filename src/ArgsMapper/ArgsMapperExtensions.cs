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
using System.Linq.Expressions;
using ArgsMapper.Infrastructure;
using ArgsMapper.Utilities;

namespace ArgsMapper
{
    public static class ArgsMapperExtensions
    {
        public static void AddCommand<T, TCommand>(this ArgsMapper<T> mapper,
            Expression<Func<T, TCommand>> propertySelector, string name)
            where T : class
            where TCommand : class
        {
            AddCommand(mapper, propertySelector, name, null);
        }

        public static void AddCommand<T, TCommand>(this ArgsMapper<T> mapper,
            Expression<Func<T, TCommand>> propertySelector)
            where T : class
            where TCommand : class
        {
            AddCommand(mapper, propertySelector, null, null);
        }

        public static void AddCommand<T, TCommand>(this ArgsMapper<T> mapper,
            Expression<Func<T, TCommand>> propertySelector,
            Action<ArgsCommandSettings<TCommand>> commandSettings)
            where T : class
            where TCommand : class
        {
            AddCommand(mapper, propertySelector, null, commandSettings);
        }

        public static void AddCommand<T, TCommand>(this ArgsMapper<T> mapper,
            Expression<Func<T, TCommand>> propertySelector, string name,
            Action<ArgsCommandSettings<TCommand>> commandSettings)
            where T : class
            where TCommand : class
        {
            var command = CommandInitializer.Initialize(mapper, 
                propertySelector, name, commandSettings);

            mapper.CommandValidationService.Validate(mapper, command);

            mapper.Commands.Add(command);
        }

        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector)
            where T : class
        {
            AddOption(mapper, propertySelector, null, null, false, null);
        }

        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
        {
            AddOption(mapper, propertySelector, null, null, false, optionSettings);
        }

        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, string longName)
            where T : class
        {
            AddOption(mapper, propertySelector, null, longName, false, null);
        }

        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
        {
            AddOption(mapper, propertySelector, null, longName, false, optionSettings);
        }

        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, char shortName, string longName)
            where T : class
        {
            AddOption(mapper, propertySelector, shortName, longName, false, null);
        }

        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, char shortName, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
        {
            AddOption(mapper, propertySelector, shortName, longName, false, optionSettings);
        }

        private static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, char? shortName, string longName,
            bool isPositional, Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
        {
            int? position = null;

            if (isPositional)
            {
                position = mapper.Options.GetNextPositionalOptionPosition();
            }

            var option = OptionInitializer.Initialize(propertySelector, shortName,
                longName, position, optionSettings, mapper.Settings.Culture);

            mapper.OptionValidationService.Validate(mapper, option);

            mapper.Options.Add(option);
        }

        public static void AddPositionalOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector)
            where T : class
        {
            AddOption(mapper, propertySelector, null, null, true, null);
        }

        public static void AddPositionalOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
        {
            AddOption(mapper, propertySelector, null, null, true, optionSettings);
        }

        public static void AddPositionalOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, string longName)
            where T : class
        {
            AddOption(mapper, propertySelector, null, longName, true, null);
        }

        public static void AddPositionalOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
        {
            AddOption(mapper, propertySelector, null, longName, true, optionSettings);
        }
    }
}
