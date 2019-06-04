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
using ArgsMapper.InitializationValidations.CommandOptionValidations.Validators;
using ArgsMapper.Models;
using ArgsMapper.ValueConversion;

namespace ArgsMapper.InitializationValidations.CommandOptionValidations
{
    internal interface ICommandOptionValidationService
    {
        void Validate<TCommand>(IArgsCommandSettings<TCommand> commandSettings, Option option) 
            where TCommand : class;
    }

    internal class CommandOptionValidationService : ICommandOptionValidationService
    {
        internal CommandOptionValidationService(
            IValueConverterFactory valueConverterFactory,
            IArgsMapperSettings argsMapperSettings)
        {
            Validators = new List<ICommandOptionValidator> {
                new CommandOptionPropertyTypeValidator(valueConverterFactory),
                new CommandOptionLongNameValidator(),
                new CommandOptionLongNameDuplicationValidator(argsMapperSettings),
                new CommandOptionShortNameDuplicationValidator(),
                new CommandOptionShortNameValidator(),
                new CommandPositionalOptionListConflictValidator()
            };
        }

        private IEnumerable<ICommandOptionValidator> Validators { get; }

        public void Validate<TCommand>(IArgsCommandSettings<TCommand> commandSettings, Option option) 
            where TCommand : class
        {
            foreach (var validator in Validators)
            {
                validator.Validate(commandSettings, option);
            }
        }
    }
}
