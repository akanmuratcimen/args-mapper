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
using ArgsMapper.Models;
using ArgsMapper.Utilities;

namespace ArgsMapper.Infrastructure
{
    internal class SubCommandInitializer
    {
        internal static Command Initialize<TCommand, TSubCommand>(
            ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TSubCommand>> propertySelector, string name,
            Action<ArgsCommandSettings<TSubCommand>> subCommandSettings)
            where TCommand : class where TSubCommand : class
        {
            var command = new Command();

            var propertyInfos = propertySelector.GetPropertyInfos();

            command.PropertyInfos = propertyInfos;
            command.Name = name ?? propertyInfos.GetName(commandSettings.ArgsMapperSettings.Culture);
            command.CultureInfo = commandSettings.ArgsMapperSettings.Culture;

            var settings = new ArgsCommandSettings<TSubCommand>(
                commandSettings.ArgsMapperSettings,
                commandSettings.CommandOptionValidationService,
                commandSettings.CommandValidationService,
                commandSettings.SubCommandValidationService,
                commandSettings.OptionValidationService,
                commandSettings.ValueConverterFactory);

            if (subCommandSettings is null)
            {
                return command;
            }

            subCommandSettings(settings);

            command.Usage = settings.Usage;
            command.IsDisabled = settings.IsDisabled;
            command.Options = settings.Options;
            command.SubCommands = settings.SubCommands;

            return command;
        }
    }
}
