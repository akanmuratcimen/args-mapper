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
using System.Reflection;

namespace ArgsMapper.InitializationValidations.OptionValidations
{
    public class InvalidOptionLongNameException : Exception
    {
        public InvalidOptionLongNameException(string longName) :
            base($"'{longName}' has invalid characters.")
        {
        }
    }

    public class InvalidOptionShortNameException : Exception
    {
        public InvalidOptionShortNameException(char shortName) :
            base($"'{shortName}' is an invalid short name. A short name can only be a letter.")
        {
        }
    }

    public class OptionShortNameAlreadyExistsException : Exception
    {
        public OptionShortNameAlreadyExistsException(char shortName) :
            base($"An option with '{shortName}' short name already exists.")
        {
        }
    }

    public class OptionLongNameAlreadyExistsException : Exception
    {
        public OptionLongNameAlreadyExistsException(string longName) :
            base($"An option with '{longName}' long name already exists.")
        {
        }
    }

    public class OptionLongNameRequiredException : Exception
    {
        public OptionLongNameRequiredException(MemberInfo propertyInfo) :
            base($"'{propertyInfo.Name}' option name can not be empty.")
        {
        }
    }

    public class PositionalOptionConflictsWithCommandException : Exception
    {
        public PositionalOptionConflictsWithCommandException() :
            base("Positional options cannot be used while using a command.")
        {
        }
    }

    public class ReservedOptionShortNameException : Exception
    {
        public ReservedOptionShortNameException(char shortName) :
            base($"'{shortName}' is a reserved short name.")
        {
        }
    }

    public class ReservedOptionLongNameException : Exception
    {
        public ReservedOptionLongNameException(string longName) :
            base($"'{longName}' is a reserved long name.")
        {
        }
    }

    public class UnsupportedOptionPropertyTypeException : Exception
    {
        public UnsupportedOptionPropertyTypeException(MemberInfo memberInfo) :
            base($"Unsupported option type: '{memberInfo.Name}'.")
        {
        }
    }

    public class PositionalOptionListConflictException : Exception
    {
        public PositionalOptionListConflictException() :
            base("Using another option with a list positional option type not allowed.")
        {
        }
    }
}
