using ArgsMapper.Models;

namespace ArgsMapper.InitializationValidations.CommandValidations
{
    internal interface ICommandValidator
    {
        void Validate<T>(ArgsMapper<T> mapper, Command command) where T : class;
    }
}
