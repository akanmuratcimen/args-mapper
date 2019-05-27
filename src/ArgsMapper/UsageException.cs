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
using System.Collections.Generic;

namespace ArgsMapper
{
    /// <inheritdoc />
    /// <summary>
    ///     Represents an error caused by user input.
    /// </summary>
    internal abstract class UsageException : Exception
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new instance of <see cref="UsageException" />.
        /// </summary>
        /// <param name="message">Message describing the error.</param>
        protected UsageException(string message)
            : base(message, null)
        {
        }
    }

    internal class UnknownOptionException : UsageException
    {
        public UnknownOptionException(string option)
            : base($"Unknown option '{option}'.")
        {
        }
    }

    internal class UnknownCommandOptionException : UsageException
    {
        public UnknownCommandOptionException(string command, string option)
            : base($"Unknown '{command}' command option '{option}'.")
        {
        }
    }

    internal class UnknownCommandException : UsageException
    {
        public UnknownCommandException(string command)
            : base($"'{command}' is not a valid command.")
        {
        }
    }

    internal class InvalidOptionValueException : UsageException
    {
        public InvalidOptionValueException(string option, IEnumerable<string> values)
            : base($"'{string.Join(' ', values)}' not a valid value for '{option}' option.")
        {
        }
    }

    internal class RequiredOptionException : UsageException
    {
        public RequiredOptionException(string option)
            : base($"Required option '{option}' is missing.")
        {
        }
    }

    internal class RequiredCommandOptionException : UsageException
    {
        public RequiredCommandOptionException(string command, string option)
            : base($"Required '{command}' command option '{option}' is missing.")
        {
        }
    }
}
