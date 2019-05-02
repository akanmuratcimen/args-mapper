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
using System.Globalization;
using System.IO;

namespace ArgsMapper
{
    /// <summary>
    ///     Args Mapper Settings
    /// </summary>
    public class ArgsMapperSettings
    {
        /// <summary>
        ///     The version of the application.
        /// </summary>
        public Version ApplicationVersion { get; set; } = new Version(1, 0, 0, 0);

        /// <summary>
        ///     Culture settings for value conversion and text-case transformation.
        /// </summary>
        public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;

        /// <summary>
        ///     Default writer for error messages and help screen. Default value is <see cref="Console.Out" />
        /// </summary>
        public TextWriter DefaultWriter { get; set; } = Console.Out;

        /// <summary>
        ///     Specifies how to compare option and command names. Default value is
        ///     <see cref="System.StringComparison.CurrentCultureIgnoreCase" />
        /// </summary>
        public StringComparison StringComparison { get; set; } = StringComparison.CurrentCultureIgnoreCase;
    }
}
