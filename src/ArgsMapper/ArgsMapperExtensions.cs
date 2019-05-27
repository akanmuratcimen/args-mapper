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
using ArgsMapper.InitializationValidations.CommandValidations;
using ArgsMapper.InitializationValidations.OptionValidations;
using ArgsMapper.Utilities;

namespace ArgsMapper
{
    /// <summary>
    ///     <see cref="ArgsMapper{T}" /> extension methods to add command, option or positional option.
    /// </summary>
    public static class ArgsMapperExtensions
    {
        /// <summary>
        ///     Adds a new command to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="name">The name for the command.</param>
        /// <exception cref="CommandNameRequiredException">
        ///     Command <paramref name="name" /> is null or empty.
        /// </exception>
        /// <exception cref="InvalidCommandNameException">
        ///     Command <paramref name="name" /> is not valid.
        ///     It is includes a whitespace or an assignment character (: =).
        /// </exception>
        /// <exception cref="CommandNameAlreadyExistsException">
        ///     A command with the same <paramref name="name" />
        ///     already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        /// <exception cref="CommandConflictsWithPositionalOptionException">
        ///     A command cannot be defined if a positional option is already defined.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Throws when the <paramref name="propertySelector" /> is not refers to a property or
        ///     It has no public setter method or It is not a public property at all.
        /// </exception>
        public static void AddCommand<T, TCommand>(this ArgsMapper<T> mapper,
            Expression<Func<T, TCommand>> propertySelector, string name)
            where T : class
            where TCommand : class
        {
            AddCommand(mapper, propertySelector, name, null);
        }

        /// <summary>
        ///     Adds a new command to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <exception cref="CommandConflictsWithPositionalOptionException">
        ///     A command cannot be defined if a positional option is already defined.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Throws when the <paramref name="propertySelector" /> is not refers to a property or
        ///     It has no public setter method or It is not a public property at all.
        /// </exception>
        public static void AddCommand<T, TCommand>(this ArgsMapper<T> mapper,
            Expression<Func<T, TCommand>> propertySelector)
            where T : class
            where TCommand : class
        {
            AddCommand(mapper, propertySelector, null, null);
        }

        /// <summary>
        ///     Adds a new command to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <exception cref="CommandConflictsWithPositionalOptionException">
        ///     A command cannot be defined if a positional option is already defined.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Throws when the <paramref name="propertySelector" /> is not refers to a property or
        ///     It has no public setter method or It is not a public property at all.
        /// </exception>
        public static void AddCommand<T, TCommand>(this ArgsMapper<T> mapper,
            Expression<Func<T, TCommand>> propertySelector,
            Action<ArgsCommandSettings<T, TCommand>> commandSettings)
            where T : class
            where TCommand : class
        {
            AddCommand(mapper, propertySelector, null, commandSettings);
        }

        /// <summary>
        ///     Adds a new command to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TCommand">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="name">The name for the command.</param>
        /// <param name="commandSettings"><see cref="ArgsCommandSettings{T, TCommand}" /> for the command.</param>
        /// <exception cref="CommandNameRequiredException">
        ///     Command <paramref name="name" /> is null or empty.
        /// </exception>
        /// <exception cref="InvalidCommandNameException">
        ///     Command <paramref name="name" /> is not valid.
        ///     It is includes a whitespace or an assignment character (: =).
        /// </exception>
        /// <exception cref="CommandNameAlreadyExistsException">
        ///     A Command with the same <paramref name="name" />
        ///     already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        /// <exception cref="CommandConflictsWithPositionalOptionException">
        ///     A command cannot be defined if a positional option is already defined.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Throws when the <paramref name="propertySelector" /> is not refers to a property or
        ///     It has no public setter method or It is not a public property at all.
        /// </exception>
        public static void AddCommand<T, TCommand>(this ArgsMapper<T> mapper,
            Expression<Func<T, TCommand>> propertySelector, string name,
            Action<ArgsCommandSettings<T, TCommand>> commandSettings)
            where T : class
            where TCommand : class
        {
            var command = CommandInitializer.Initialize(mapper, propertySelector, name, commandSettings);

            mapper.CommandValidationService.Validate(mapper, command);

            mapper.Commands.Add(command);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same long name already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector)
            where T : class
        {
            AddOption(mapper, propertySelector, null, null, false, null);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="optionSettings"><see cref="ArgsOptionSettings{T}" /> for the option.</param>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same long name already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
        {
            AddOption(mapper, propertySelector, null, null, false, optionSettings);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
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
        ///     already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, string longName)
            where T : class
        {
            AddOption(mapper, propertySelector, null, longName, false, null);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
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
        ///     already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
        {
            AddOption(mapper, propertySelector, null, longName, false, optionSettings);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
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
        ///     already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same <paramref name="longName" />
        ///     already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
        public static void AddOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, char shortName, string longName)
            where T : class
        {
            AddOption(mapper, propertySelector, shortName, longName, false, null);
        }

        /// <summary>
        ///     Adds a new option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
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
        ///     already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        /// <exception cref="OptionLongNameAlreadyExistsException">
        ///     An option with the same <paramref name="longName" />
        ///     already exists in the <see cref="ArgsMapper{T}" />.
        /// </exception>
        /// <exception cref="UnsupportedOptionPropertyTypeException">
        ///     Throws when the option property not supported.
        /// </exception>
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
            ushort? position = null;

            if (isPositional)
            {
                position = mapper.Options.GetNextPositionalOptionPosition();
            }

            var option = OptionInitializer.Initialize(propertySelector, shortName,
                longName, position, optionSettings, mapper.Settings.Culture);

            mapper.OptionValidationService.Validate(mapper, option);

            mapper.Options.Add(option);
        }

        /// <summary>
        ///     Adds a new positional option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <exception cref="UnsupportedPositionalOptionPropertyTypeException">
        ///     Throws when the positional option property not supported.
        /// </exception>
        public static void AddPositionalOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector)
            where T : class
        {
            AddOption(mapper, propertySelector, null, null, true, null);
        }

        /// <summary>
        ///     Adds a new positional option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="optionSettings"><see cref="ArgsOptionSettings{T}" /> for the option.</param>
        /// <exception cref="UnsupportedPositionalOptionPropertyTypeException">
        ///     Throws when the positional option property not supported.
        /// </exception>
        public static void AddPositionalOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
            where TOption : IComparable, IConvertible, IEquatable<TOption>
        {
            AddOption(mapper, propertySelector, null, null, true, optionSettings);
        }

        /// <summary>
        ///     Adds a new positional option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="longName">The long name for the option.</param>
        /// <exception cref="UnsupportedPositionalOptionPropertyTypeException">
        ///     Throws when the positional option property not supported.
        /// </exception>
        public static void AddPositionalOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, string longName)
            where T : class
            where TOption : IComparable, IConvertible, IEquatable<TOption>
        {
            AddOption(mapper, propertySelector, null, longName, true, null);
        }

        /// <summary>
        ///     Adds a new positional option to the <see cref="ArgsMapper{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the arguments model.</typeparam>
        /// <typeparam name="TOption">The type of the property of the model.</typeparam>
        /// <param name="mapper">The instance of <see cref="ArgsMapper{T}" />.</param>
        /// <param name="propertySelector">The type of the property the value will be assigned.</param>
        /// <param name="longName">The long name for the option.</param>
        /// <param name="optionSettings"><see cref="ArgsOptionSettings{T}" /> for the option.</param>
        /// <exception cref="UnsupportedPositionalOptionPropertyTypeException">
        ///     Throws when the positional option property not supported.
        /// </exception>
        public static void AddPositionalOption<T, TOption>(this ArgsMapper<T> mapper,
            Expression<Func<T, TOption>> propertySelector, string longName,
            Action<ArgsOptionSettings<TOption>> optionSettings)
            where T : class
            where TOption : IComparable, IConvertible, IEquatable<TOption>
        {
            AddOption(mapper, propertySelector, null, longName, true, optionSettings);
        }
    }
}
