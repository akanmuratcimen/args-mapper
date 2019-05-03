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
using System.Reflection;

namespace ArgsMapper.InitializationValidations.CommandOptionValidations
{
    public class CommandOptionShortNameAlreadyExistsException : Exception
    {
        public CommandOptionShortNameAlreadyExistsException(char shortName) :
            base($"An option with '{shortName}' short name already exists in the command.")
        {
        }
    }

    public class CommandOptionLongNameAlreadyExistsException : Exception
    {
        public CommandOptionLongNameAlreadyExistsException(string longName) :
            base($"An option with '{longName}' long name already exists in the command.")
        {
        }
    }

    public class CommandOptionLongNameRequiredException : Exception
    {
        public CommandOptionLongNameRequiredException(string propertyName) :
            base($"'{propertyName}' option long name can not be empty in the command.")
        {
        }
    }

    public class InvalidCommandOptionLongNameException : Exception
    {
        public InvalidCommandOptionLongNameException(string name) :
            base($"'{name}' has invalid characters.")
        {
        }
    }

    public class InvalidCommandOptionShortNameException : Exception
    {
        public InvalidCommandOptionShortNameException(char shortName) :
            base($"'{shortName}' is an invalid short name. A short name can only be a letter.")
        {
        }
    }

    public class UnsupportedCommandOptionPropertyTypeException : Exception
    {
        public UnsupportedCommandOptionPropertyTypeException(MemberInfo memberInfo) :
            base($"Unsupported command option type: '{memberInfo.Name}'.")
        {
        }
    }

    public class UnsupportedCommandPositionalOptionPropertyTypeException : Exception
    {
        public UnsupportedCommandPositionalOptionPropertyTypeException(MemberInfo memberInfo) :
            base($"Unsupported command positional option type: '{memberInfo.Name}'.")
        {
        }
    }

    public class ReservedCommandOptionShortNameException : Exception
    {
        public ReservedCommandOptionShortNameException(char shortName) :
            base($"'{shortName}' is a reserved short name.")
        {
        }
    }

    public class ReservedCommandOptionLongNameException : Exception
    {
        public ReservedCommandOptionLongNameException(string longName) :
            base($"'{longName}' is a reserved long name.")
        {
        }
    }
}
