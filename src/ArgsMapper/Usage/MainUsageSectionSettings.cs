using System;
using System.Linq.Expressions;
using System.Text;

namespace ArgsMapper.Usage
{
    internal class MainUsageSectionSettings<T> : IMainUsageSectionSettings<T> where T : class
    {
        internal StringBuilder StringBuilder;

        public int MaxWidth { get; set; }

        public void AddOption<TOption>(Expression<Func<T, TOption>> propertySelector,
            string description = null)
        {
        }

        public void AddCommand<TCommand>(Expression<Func<T, TCommand>> propertySelector,
            string description = null) where TCommand : class
        {
        }

        public void AddContent(params string[] contents)
        {
            StringBuilder.AppendContent(contents);
        }

        public void AddContent(params (string column1, string column2)[] columns)
        {
            foreach (var (column1, column2) in columns)
            {
                StringBuilder.AppendContent(column1, column2);
            }
        }

        public void AddContent(params (string column1, string column2, string column3)[] columns)
        {
            foreach (var (column1, column2, column3) in columns)
            {
                StringBuilder.AppendContent(column1, column2, column3);
            }
        }

        public void AddContent(params (string column1, string column2, string column3,
            string column4)[] columns)
        {
            foreach (var (column1, column2, column3, column4) in columns)
            {
                StringBuilder.AppendContent(column1, column2, column3, column4);
            }
        }

        public void AddContent(params (string column1, string column2, string column3,
            string column4, string column5)[] columns)
        {
            foreach (var (column1, column2, column3, column4, column5) in columns)
            {
                StringBuilder.AppendContent(column1, column2, column3, column4, column5);
            }
        }

        public void AddContent(params (string column1, string column2, string column3,
            string column4, string column5, string column6)[] columns)
        {
            foreach (var (column1, column2, column3, column4, column5, column6) in columns)
            {
                StringBuilder.AppendContent(column1, column2, column3, column4, column5, column6);
            }
        }
    }
}
