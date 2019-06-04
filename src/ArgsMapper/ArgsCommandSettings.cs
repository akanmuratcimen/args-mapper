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

using System.Collections.Generic;
using ArgsMapper.InitializationValidations.CommandOptionValidations;
using ArgsMapper.InitializationValidations.CommandValidations;
using ArgsMapper.InitializationValidations.OptionValidations;
using ArgsMapper.Models;
using ArgsMapper.PageBuilding;
using ArgsMapper.ValueConversion;

namespace ArgsMapper
{
    public class ArgsCommandSettings<TCommand> where TCommand : class
    {
        internal ArgsCommandSettings(
            IArgsMapperSettings argsMapperSettings,
            ICommandOptionValidationService commandOptionValidationService,
            ICommandValidationService commandValidationService,
            IOptionValidationService optionValidationService,
            IValueConverterFactory valueConverterFactory)
        {
            ArgsMapperSettings = argsMapperSettings;
            CommandOptionValidationService = commandOptionValidationService;
            CommandValidationService = commandValidationService;
            OptionValidationService = optionValidationService;
            ValueConverterFactory = valueConverterFactory;

            Options = new List<Option>();
            Usage = new CommandPageBuilder<TCommand>(Options);
        }

        internal ICommandOptionValidationService CommandOptionValidationService { get; }
        internal ICommandValidationService CommandValidationService { get; }
        internal IOptionValidationService OptionValidationService { get; }
        internal IValueConverterFactory ValueConverterFactory { get; }
        internal IArgsMapperSettings ArgsMapperSettings { get; }

        internal List<Option> Options { get; }

        public bool IsDisabled { get; set; }
        public ICommandPageBuilder<TCommand> Usage { get; }
    }
}
