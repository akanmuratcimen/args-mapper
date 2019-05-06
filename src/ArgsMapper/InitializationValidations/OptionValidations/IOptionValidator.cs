using ArgsMapper.Models;

namespace ArgsMapper.InitializationValidations.OptionValidations
{
    internal interface IOptionValidator
    {
        void Validate<T>(ArgsMapper<T> mapper, Option option) where T : class;
    }
}
