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
using System.Collections.Generic;
using System.Threading.Tasks;
using ArgsMapper.InitializationValidations.CommandOptionValidations;
using ArgsMapper.InitializationValidations.CommandValidations;
using ArgsMapper.InitializationValidations.OptionValidations;
using ArgsMapper.Mapping;
using ArgsMapper.Models;
using ArgsMapper.PageBuilding;
using ArgsMapper.Utilities;
using ArgsMapper.ValueConversion;

namespace ArgsMapper
{
    public sealed class ArgsMapper<T> where T : class
    {
        internal ICommandOptionValidationService CommandOptionValidationService;
        internal ICommandValidationService CommandValidationService;
        public IMainPageBuilder<T> Introduction;
        internal IOptionValidationService OptionValidationService;
        internal IReflectionService ReflectionService;
        public IMainPageBuilder<T> Usage;
        internal IValueConverterFactory ValueConverterFactory;

        public ArgsMapper()
        {
            Introduction = new MainPageBuilder<T>(Commands, Options);
            Usage = new MainPageBuilder<T>(Commands, Options);
            OptionValidationService = new OptionValidationService();
            CommandValidationService = new CommandValidationService();
            ValueConverterFactory = new ValueConverterFactory();
            ReflectionService = new ReflectionService(ValueConverterFactory);
            CommandOptionValidationService = new CommandOptionValidationService();
        }

        internal List<Command> Commands { get; } = new List<Command>();
        internal List<Option> Options { get; } = new List<Option>();

        /// <summary>
        ///     Settings of the mapper.
        /// </summary>
        public ArgsMapperSettings Settings { get; } = new ArgsMapperSettings();

        public void Execute(string[] args, Action<T> onExecute)
        {
            if (args.IsNullOrEmpty())
            {
                var introductionContent = Introduction.Content;

                if (introductionContent != string.Empty)
                {
                    Settings.DefaultWriter.Write(introductionContent);

                    return;
                }

                var usageContent = Usage.Content;

                if (usageContent != string.Empty)
                {
                    Settings.DefaultWriter.Write(usageContent);

                    return;
                }
            }
            else
            {
                var args0 = args[0];

                if (args0.IsHelpOption())
                {
                    Settings.DefaultWriter.Write(Usage.Content);

                    return;
                }

                if (args0.IsVersionOption())
                {
                    Settings.DefaultWriter.Write(Settings.ApplicationVersion.ToString());

                    return;
                }
            }

            var mapperResult = Map(args);

            if (mapperResult.HasError)
            {
                Settings.DefaultWriter.Write(mapperResult.ErrorMessage);

                return;
            }

            onExecute(mapperResult.Model);
        }

        public async Task ExecuteAsync(string[] args, Action<T> onExecute)
        {
            Execute(args, onExecute);

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Parses given <paramref name="args" /> and
        ///     returns an instance of <see cref="ArgsMapperResult{T}" />.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        /// <returns>Instance of <see cref="ArgsMapperResult{T}" />.</returns>
        internal ArgsMapperResult<T> Map(params string[] args)
        {
            var result = new ArgsMapperResult<T>();

            try
            {
                result.Model = new ArgumentMapper<T>(this, ReflectionService).Map(result.Model, args);
            }
            catch (UsageException e)
            {
                result.ErrorMessage = e.Message;
            }

            return result;
        }

        ~ArgsMapper()
        {
            Settings.DefaultWriter.Dispose();
        }
    }
}
