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

namespace ArgsMapper.InitializationValidations.CommandValidations
{
    public class CommandConflictsWithPositionalOptionException : Exception
    {
        public CommandConflictsWithPositionalOptionException() :
            base("Commands cannot be used while using a positional option.")
        {
        }
    }

    public class InvalidCommandNameException : Exception
    {
        public InvalidCommandNameException(string name) :
            base($"'{name}' has invalid characters.")
        {
        }
    }

    public class CommandNameRequiredException : Exception
    {
        public CommandNameRequiredException(MemberInfo propertyInfo) :
            base($"'{propertyInfo.Name}' command name can not be empty.")
        {
        }
    }

    public class CommandNameAlreadyExistsException : Exception
    {
        public CommandNameAlreadyExistsException(string name) :
            base($"A command with '{name}' name already exists.")
        {
        }
    }
}
