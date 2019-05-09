using System;
using System.Linq.Expressions;

namespace ArgsMapper.Usage
{
    public interface IUsageBuilder<T> where T : class
    {
        void AddSection(string header, Action<IUsageSectionSettings<T>> usageSettings);
        void AddContent(UsageContent content);
    }

    public interface IUsageSectionSettings<T> where T : class
    {
        UsageContent Content { get; set; }
        int MaxWidth { get; set; }
        void AddOption<TOption>(Expression<Func<T, TOption>> propertySelector, bool showType = false);
        void AddCommand<TCommand>(Expression<Func<T, TCommand>> propertySelector) where TCommand : class;
        void AddExample(string description, Action<T> args);
    }
}
