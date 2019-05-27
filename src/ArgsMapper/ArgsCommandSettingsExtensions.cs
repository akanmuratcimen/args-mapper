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
using ArgsMapper.InitializationValidations.OptionValidations;
using ArgsMapper.Utilities;

namespace ArgsMapper
{
    /// <summary>
    ///     <see cref="ArgsCommandSettings{T, TCommand}" /> extension
    ///     methods to add option or positional option to command.
    /// </summary>
    public static class ArgsCommandSettingsExtensions
    {
        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same long name already exists
        ///     in the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </exception>
        public static void AddOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector) where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, null, false, null);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="optionSettings"><see cref="ArgsOptionSettings{T}" /> for the option.</param>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same long name already exists
        ///     in the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </exception>
        public static void AddOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, 
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, null, false, optionSettings);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="longName">The long name for the option.</param>
        /// <exception cref="OptionLongNameRequiredException">
        ///     Option <paramref name="longName" /> is null or empty.
        /// </exception>
        /// <exception cref="InvalidOptionLongNameException">
        ///     Option <paramref name="longName" /> is not valid.
        ///     It is includes a whitespace or an assignment character (: =).
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same <paramref name="longName" />
        ///     already exists in the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </exception>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        public static void AddOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, string longName) 
            where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, longName, false, null);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="longName">The long name for the option.</param>
        /// <param name="optionSettings"><see cref="ArgsOptionSettings{T}" /> for the option.</param>
        /// <exception cref="OptionLongNameRequiredException">
        ///     Option <paramref name="longName" /> is null or empty.
        /// </exception>
        /// <exception cref="InvalidOptionLongNameException">
        ///     Option <paramref name="longName" /> is not valid.
        ///     It is includes a whitespace or an assignment character (: =).
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same <paramref name="longName" />
        ///     already exists in the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </exception>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        public static void AddOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings) where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, longName, false, optionSettings);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="shortName">The short name for the option.</param>
        /// <param name="longName">The long name for the option.</param>
        /// <exception cref="OptionLongNameRequiredException">
        ///     Option <paramref name="longName" /> is null or empty.
        /// </exception>
        /// <exception cref="InvalidOptionLongNameException">
        ///     Option <paramref name="longName" /> is not valid.
        ///     It is includes a whitespace or an assignment character (: =).
        /// </exception>
        /// <exception cref="OptionShortNameAlreadyExistsException">
        ///     An option with the same <paramref name="shortName" />
        ///     already exists in the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same <paramref name="longName" />
        ///     already exists in the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </exception>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        public static void AddOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, 
            char shortName, string longName) where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, shortName, longName, false, null);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="shortName">The short name for the option.</param>
        /// <param name="longName">The long name for the option.</param>
        /// <param name="optionSettings"><see cref="ArgsOptionSettings{T}" /> for the option.</param>
        /// <exception cref="OptionLongNameRequiredException">
        ///     Option <paramref name="longName" /> is null or empty.
        /// </exception>
        /// <exception cref="InvalidOptionLongNameException">
        ///     Option <paramref name="longName" /> is not valid.
        ///     It is includes a whitespace or an assignment character (: =).
        /// </exception>
        /// <exception cref="OptionShortNameAlreadyExistsException">
        ///     An option with the same <paramref name="shortName" />
        ///     already exists in the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same <paramref name="longName" />
        ///     already exists in the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </exception>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        public static void AddOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, 
            char shortName, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings) where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, shortName, longName, false, optionSettings);
        }

        private static void AddOption<T, TCommand, TProperty>(this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TProperty>> propertySelector, char? shortName, string longName,
            bool isPositional, Action<ArgsOptionSettings<TProperty>> optionSettings) 
            where T : class where TCommand : class
        {
            ushort? position = null;

            if (isPositional)
            {
                position = commandSettings.Options.GetNextPositionalOptionPosition();
            }

            var commandOption = OptionInitializer.Initialize(propertySelector, shortName, longName,
                position, optionSettings, commandSettings.Mapper.Settings.Culture);

            commandSettings.Mapper.CommandOptionValidationService.Validate(commandSettings, commandOption);

            commandSettings.Options.Add(commandOption);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <exception cref="UnsupportedPositionalOptionPropertyTypeException">
        ///     Throws when the positional option property not supported.
        /// </exception>
        public static void AddPositionalOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector) where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, null, true, null);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="optionSettings"><see cref="ArgsOptionSettings{T}" /> for the option.</param>
        /// <exception cref="UnsupportedPositionalOptionPropertyTypeException">
        ///     Throws when the positional option property not supported.
        /// </exception>
        public static void AddPositionalOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, null, true, optionSettings);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="longName">The long name for the option.</param>
        /// <param name="optionSettings"><see cref="ArgsOptionSettings{T}" /> for the option.</param>
        /// <exception cref="UnsupportedPositionalOptionPropertyTypeException">
        ///     Throws when the positional option property not supported.
        /// </exception>
        public static void AddPositionalOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings) where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, longName, true, optionSettings);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsCommandSettings{T, TCommand}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TOption">The type of the option of the command model.</typeparam>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="longName">The long name for the option.</param>
        /// <exception cref="UnsupportedPositionalOptionPropertyTypeException">
        ///     Throws when the positional option property not supported.
        /// </exception>
        public static void AddPositionalOption<T, TCommand, TOption>(
            this ArgsCommandSettings<T, TCommand> commandSettings,
            Expression<Func<TCommand, TOption>> propertySelector, string longName) 
            where T : class where TCommand : class
        {
            AddOption(commandSettings, propertySelector, null, longName, true, null);
        }
    }
}
