using ArgsMapper.Models;

namespace ArgsMapper.InitializationValidations.CommandOptionValidations
{
    internal interface ICommandOptionValidator
    {
        void Validate<T, TProperty>(ArgsCommandSettings<T, TProperty> commandSettings,
            Option commandOption) where T : class;
    }
}
