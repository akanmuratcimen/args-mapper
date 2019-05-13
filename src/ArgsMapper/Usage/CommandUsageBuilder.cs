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

namespace ArgsMapper.Usage
{
    internal class CommandUsageBuilder<T, TCommand> : ICommandUsageBuilder<T, TCommand> where T : class
    {
        public void AddSection(string header, Action<ICommandUsageSectionSettings<T, TCommand>> sectionSettings)
        {
        }

        public void AddContent(params string[] contents)
        {
        }

        public void AddContent(params (string column1, string column2)[] columns)
        {
        }

        public void AddContent(params (string column1, string column2, string column3)[] columns)
        {
        }

        public void AddContent(params (string column1, string column2, string column3,
            string column4)[] columns)
        {
        }

        public void AddContent(params (string column1, string column2, string column3,
            string column4, string column5)[] columns)
        {
        }

        public void AddContent(params (string column1, string column2, string column3,
            string column4, string column5, string column6)[] columns)
        {
        }
    }
}
