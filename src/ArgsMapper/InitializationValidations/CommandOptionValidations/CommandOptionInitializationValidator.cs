﻿// The MIT License (MIT)
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

using System.Collections.Generic;
using ArgsMapper.InitializationValidations.CommandOptionValidations.Validators;
using ArgsMapper.Models;

namespace ArgsMapper.InitializationValidations.CommandOptionValidations
{
    internal interface ICommandOptionInitializationValidator
    {
        void Validate<T>(ArgsCommandSettings<T> commandSettings, Option commandOption) where T : class;
    }

    internal class CommandOptionInitializationValidator
    {
        private static IEnumerable<ICommandOptionInitializationValidator> Validators
        {
            get
            {
                yield return new CommandOptionPropertyTypeValidator();
                yield return new CommandOptionLongNameValidator();
                yield return new CommandOptionLongNameDuplicationValidator();
                yield return new CommandOptionShortNameDuplicationValidator();
                yield return new CommandOptionShortNameValidator();
            }
        }

        internal static void Validate<T>(ArgsCommandSettings<T> commandSettings, Option option) where T : class
        {
            foreach (var validator in Validators)
            {
                validator.Validate(commandSettings, option);
            }
        }
    }
}
