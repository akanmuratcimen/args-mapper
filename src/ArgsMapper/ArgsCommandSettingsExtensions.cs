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
    public static class ArgsCommandSettingsExtensions
    {
        public static void AddSubcommand<TCommand, TSubcommand>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TSubcommand>> propertySelector)
            where TCommand : class
            where TSubcommand : class
        {
            AddSubcommand(commandSettings, propertySelector, null, null);
        }

        public static void AddSubcommand<TCommand, TSubcommand>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TSubcommand>> propertySelector,
            Action<ArgsCommandSettings<TSubcommand>> subcommandSettings)
            where TCommand : class
            where TSubcommand : class
        {
            AddSubcommand(commandSettings, propertySelector, null, subcommandSettings);
        }

        public static void AddSubcommand<TCommand, TSubcommand>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TSubcommand>> propertySelector, string name)
            where TCommand : class
            where TSubcommand : class
        {
            AddSubcommand(commandSettings, propertySelector, name, null);
        }

        public static void AddSubcommand<TCommand, TSubcommand>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TSubcommand>> propertySelector,
            string name, Action<ArgsCommandSettings<TSubcommand>> subcommandSettings)
            where TCommand : class
            where TSubcommand : class
        {
            var command = SubcommandInitializer.Initialize(commandSettings, 
                propertySelector, name, subcommandSettings);

            commandSettings.SubcommandValidationService.Validate(commandSettings, command);
            commandSettings.Subcommands.Add(command);
        }

        public static void AddOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector) where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, null, false, null);
        }

        public static void AddOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, null, false, optionSettings);
        }

        public static void AddOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, string longName)
            where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, longName, false, null);
        }

        public static void AddOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings) where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, longName, false, optionSettings);
        }

        public static void AddOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector,
            char shortName, string longName) where TCommand : class
        {
            AddOption(commandSettings, propertySelector, shortName, longName, false, null);
        }

        public static void AddOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector,
            char shortName, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings) where TCommand : class
        {
            AddOption(commandSettings, propertySelector, shortName, longName, false, optionSettings);
        }

        private static void AddOption<TCommand, TOption>(this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, char? shortName, string longName,
            bool isPositional, Action<ArgsOptionSettings<TOption>> optionSettings)
            where TCommand : class
        {
            int? position = null;

            if (isPositional)
            {
                position = commandSettings.Options.GetNextPositionalOptionPosition();
            }

            var commandOption = OptionInitializer.Initialize(propertySelector, shortName, longName,
                position, optionSettings, commandSettings.ArgsMapperSettings.Culture);

            commandSettings.CommandOptionValidationService.Validate(commandSettings, commandOption);
            commandSettings.Options.Add(commandOption);
        }

        public static void AddPositionalOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector) where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, null, true, null);
        }

        public static void AddPositionalOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, null, true, optionSettings);
        }

        public static void AddPositionalOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings) where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, longName, true, optionSettings);
        }

        public static void AddPositionalOption<TCommand, TOption>(
            this ArgsCommandSettings<TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, string longName)
            where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, longName, true, null);
        }
    }
}
