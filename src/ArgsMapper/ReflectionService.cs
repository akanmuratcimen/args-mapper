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
using System.Reflection;
using System.Runtime.CompilerServices;
using ArgsMapper.Models;
using ArgsMapper.Utilities;
using ArgsMapper.ValueConversion;

namespace ArgsMapper
{
    internal interface IReflectionService
    {
        void SetValue(Option option, object model, IList<string> values, IFormatProvider formatProvider);
        void SetValue(Option option, object model, string value, IFormatProvider formatProvider);
        void SetValue(Option option, object model, object value);
        object SetValue(Command command, object model);
    }

    internal class ReflectionService : IReflectionService
    {
        private readonly IValueConverterFactory _valueConverterFactory;

        public ReflectionService(IValueConverterFactory valueConverterFactory)
        {
            _valueConverterFactory = valueConverterFactory;
        }

        public void SetValue(Option option, object model, IList<string> values, IFormatProvider formatProvider)
        {
            if (!option.Type.IsList() && values.Count > 1)
            {
                throw new MultipleValueForNotCollectionTypeException(option.ToString(), values.Count);
            }

            try
            {
                SetValue(option, model, _valueConverterFactory.Convert(values, option.Type, formatProvider));
            }
            catch (Exception e) when (e is FormatException || e is OverflowException ||
                e is ArgumentOutOfRangeException)
            {
                throw new InvalidOptionValueException(option.ToString(), values);
            }
        }

        public void SetValue(Option option, object model, string value, IFormatProvider formatProvider)
        {
            SetValue(option, model, new[] { value }, formatProvider);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(Option option, object model, object value)
        {
            SetProperty(option.PropertyInfos, model, value);
        }

        public object SetValue(Command command, object model)
        {
            var commandInstance = Activator.CreateInstance(command.Type);

            command.PropertyInfo.SetValue(model, commandInstance);

            return commandInstance;
        }

        internal void SetProperty(PropertyInfo[] propertyInfos, object model, object value)
        {
            for (var i = 0; i < propertyInfos.Length - 1; i++)
            {
                var propertyInfo = propertyInfos[i];
                var currentValue = propertyInfo.GetValue(model);

                if (currentValue == null)
                {
                    currentValue = Activator.CreateInstance(propertyInfo.PropertyType);
                    propertyInfo.SetValue(model, currentValue);
                }

                model = currentValue;
            }

            propertyInfos[propertyInfos.Length - 1].SetValue(model, value);
        }
    }
}
