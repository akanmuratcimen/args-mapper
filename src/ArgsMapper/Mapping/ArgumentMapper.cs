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
using ArgsMapper.Models;
using ArgsMapper.Models.EqualityComparers;
using ArgsMapper.Parsing;
using ArgsMapper.Utilities;

namespace ArgsMapper.Mapping
{
    internal class ArgumentMapper<T> where T : class
    {
        private readonly IArgsMapper _mapper;
        private readonly IReflectionService _reflectionService;

        internal ArgumentMapper(IArgsMapper mapper, IReflectionService reflectionService)
        {
            _mapper = mapper;
            _reflectionService = reflectionService;
        }

        internal T Map(T model, string[] args)
        {
            if (args.IsNullOrEmpty() || args[0].IsValidOption() || _mapper.Options.Any() && !_mapper.Commands.Any())
            {
                return MapPositionalOptionsAndOptions(model, args);
            }

            return MapCommandPositionalOptionsAndOptions(model, args);
        }

        private T MapCommandPositionalOptionsAndOptions(T model, string[] args)
        {
            var command = _mapper.Commands.Get(args[0], _mapper.Settings.StringComparison);

            if (command is null || command.IsDisabled)
            {
                throw new UnknownCommandException(args[0]);
            }

            var commandInstance = _reflectionService.SetValue(command, model);

            var optionsStartIndex = 1;

            for (; optionsStartIndex < args.Length; optionsStartIndex++)
            {
                if (command.Options.Any(x => x.IsPositionalOption))
                {
                    break;
                }

                var arg = args[optionsStartIndex];

                if (arg.IsValidOption())
                {
                    break;
                }

                var subcommand = command.Subcommands.Get(arg, _mapper.Settings.StringComparison);

                if (subcommand is null || subcommand.IsDisabled)
                {
                    throw new UnknownCommandException(arg);
                }

                var subcommandInstance = _reflectionService.SetValue(subcommand, commandInstance);

                command = subcommand;
                commandInstance = subcommandInstance;
            }

            var proceededOptions = new HashSet<Option>();
            var parsedOptions = RawParser.ParseOptions(args, optionsStartIndex);

            var groupedOptions = new Dictionary<Option, List<string>>(
                new OptionPropertyInfoEqualityComparer());

            foreach (var ((key, matchType), values) in parsedOptions)
            {
                var option = command.Options.Get(matchType, 
                    key.RemoveOptionPrefix(), _mapper.Settings.StringComparison);

                if (option is null || option.IsDisabled)
                {
                    throw new UnknownCommandOptionException(command.ToString(), key);
                }

                proceededOptions.Add(option);
                groupedOptions.AddOrMergeValues(option, values);
            }

            var positionalOptionsStartIndex = 0;
            var hasPositionalOptionSeparator = false;

            for (var i = 0; i < args.Length; i++)
            {
                if (!args[i].IsPositionalOptionsSeparator())
                {
                    continue;
                }

                positionalOptionsStartIndex = i + 1;
                hasPositionalOptionSeparator = true;

                break;
            }

            positionalOptionsStartIndex = Math.Max(optionsStartIndex, positionalOptionsStartIndex);

            if (command.Options.Any(x => x.IsPositionalOption && x.Type.IsList()))
            {
                var listPositionalOptionValues = new List<string>();

                for (var i = positionalOptionsStartIndex; i < args.Length; i++)
                {
                    if (!hasPositionalOptionSeparator && args[i].IsValidOption())
                    {
                        break;
                    }

                    listPositionalOptionValues.Add(args[i]);
                }

                if (listPositionalOptionValues.Any())
                {
                    var option = command.Options.GetByPosition(0);

                    _reflectionService.SetValue(option, commandInstance,
                        listPositionalOptionValues, _mapper.Settings.Culture);

                    proceededOptions.Add(option);
                }
            }
            else
            {
                for (var i = positionalOptionsStartIndex; i < args.Length; i++)
                {
                    if (!hasPositionalOptionSeparator && args[i].IsValidOption())
                    {
                        break;
                    }

                    var option = command.Options.GetByPosition(i - positionalOptionsStartIndex);

                    if (option is null)
                    {
                        throw new NoMatchedValueForCommandPositionalOptionException(command.ToString(), args[i]);
                    }

                    _reflectionService.SetValue(option, commandInstance, args[i], _mapper.Settings.Culture);

                    proceededOptions.Add(option);
                }
            }

            foreach (var option in command.Options)
            {
                if (option.IsRequired && !proceededOptions.Contains(option))
                {
                    throw new RequiredCommandOptionException(command.ToString(), option.ToString());
                }
            }

            foreach (var option in command.Options)
            {
                if (proceededOptions.Contains(option))
                {
                    continue;
                }

                _reflectionService.SetValue(option, commandInstance, option.DefaultValue);
            }

            foreach (var (option, values) in groupedOptions)
            {
                _reflectionService.SetValue(option, commandInstance, values, _mapper.Settings.Culture);
            }

            return model;
        }

        private T MapPositionalOptionsAndOptions(T model, string[] args)
        {
            var proceededOptions = new HashSet<Option>();
            var parsedOptions = RawParser.ParseOptions(args);

            var groupedOptions = new Dictionary<Option, List<string>>(
                new OptionPropertyInfoEqualityComparer());

            foreach (var ((key, matchType), values) in parsedOptions)
            {
                var option = _mapper.Options.Get(matchType, 
                    key.RemoveOptionPrefix(), _mapper.Settings.StringComparison);

                if (option is null || option.IsDisabled)
                {
                    throw new UnknownOptionException(key);
                }

                proceededOptions.Add(option);
                groupedOptions.AddOrMergeValues(option, values);
            }

            var positionalOptionsStartIndex = 0;
            var hasPositionalOptionSeparator = false;

            for (var i = 0; i < args.Length; i++)
            {
                if (!args[i].IsPositionalOptionsSeparator())
                {
                    continue;
                }

                positionalOptionsStartIndex = i + 1;
                hasPositionalOptionSeparator = true;

                break;
            }

            if (_mapper.Options.Any(x => x.IsPositionalOption && x.Type.IsList()))
            {
                var listPositionalOptionValues = new List<string>();

                for (var i = positionalOptionsStartIndex; i < args.Length; i++)
                {
                    if (!hasPositionalOptionSeparator && args[i].IsValidOption())
                    {
                        break;
                    }

                    listPositionalOptionValues.Add(args[i]);
                }

                if (listPositionalOptionValues.Any())
                {
                    var option = _mapper.Options.GetByPosition(0);

                    _reflectionService.SetValue(option, model,
                        listPositionalOptionValues, _mapper.Settings.Culture);

                    proceededOptions.Add(option);
                }
            }
            else
            {
                for (var i = positionalOptionsStartIndex; i < args.Length; i++)
                {
                    if (!hasPositionalOptionSeparator && args[i].IsValidOption())
                    {
                        break;
                    }

                    var option = _mapper.Options.GetByPosition(i - positionalOptionsStartIndex);

                    if (option is null)
                    {
                        throw new NoMatchedValueForPositionalOptionException(args[i]);
                    }

                    _reflectionService.SetValue(option, model, args[i], _mapper.Settings.Culture);

                    proceededOptions.Add(option);
                }
            }

            foreach (var option in _mapper.Options)
            {
                if (option.IsRequired && !proceededOptions.Contains(option))
                {
                    throw new RequiredOptionException(option.ToString());
                }
            }

            foreach (var option in _mapper.Options)
            {
                if (proceededOptions.Contains(option))
                {
                    continue;
                }

                _reflectionService.SetValue(option, model, option.DefaultValue);
            }

            foreach (var (option, values) in groupedOptions)
            {
                _reflectionService.SetValue(option, model, values, _mapper.Settings.Culture);
            }

            return model;
        }
    }
}
