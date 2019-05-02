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

using System.Diagnostics;

namespace ArgsMapper
{
    /// <summary>
    ///     Includes the result parameters of the mapper.
    /// </summary>
    /// <typeparam name="T">The type of the arguments model.</typeparam>
    [DebuggerDisplay("HasError = {HasError}, Model = {Model}")]
    internal class ArgsMapperResult<T> where T : class
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgsMapperResult{T}" /> class.
        /// </summary>
        /// <param name="model">The type of the arguments model.</param>
        internal ArgsMapperResult(T model)
        {
            Model = model;
        }

        /// <summary>
        ///     The error message of the mapper result.
        /// </summary>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        ///     Whether the mapper result has error.
        /// </summary>
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        /// <summary>
        ///     The instance of the arguments model.
        /// </summary>
        public T Model { get; internal set; }

        public static implicit operator T(ArgsMapperResult<T> result)
        {
            return result.Model;
        }
    }
}
