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
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ArgsMapper.Utilities
{
    internal static class ExpressionExtensions
    {
        internal static PropertyInfo[] GetPropertyInfos<T, TProperty>(this Expression<Func<T, TProperty>> expression)
        {
            var propertyInfos = GetPropertyInfos(expression.Body).ToArray();

            if (propertyInfos.Length == 0)
            {
                throw new ArgumentException("Could not get the property name.");
            }

            return propertyInfos;
        }

        private static IEnumerable<PropertyInfo> GetPropertyInfos(Expression expression)
        {
            if (!(expression is MemberExpression memberExpression))
            {
                yield break;
            }

            if (memberExpression.Member is PropertyInfo propertyInfo)
            {
                if (!propertyInfo.HasPublicSetterMethod())
                {
                    throw new ArgumentException($"'{propertyInfo.Name}' property must have a public setter method.");
                }

                foreach (var property in GetPropertyInfos(memberExpression.Expression))
                {
                    yield return property;
                }

                yield return propertyInfo;
            }
            else
            {
                throw new ArgumentException($"Expression '{expression}' not refers to a property.");
            }
        }
    }
}
