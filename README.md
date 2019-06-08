![logo](https://raw.githubusercontent.com/akanmuratcimen/args-mapper/master/args-mapper.png)

# args-mapper

[![Build status](https://ci.appveyor.com/api/projects/status/hetocc8taw31msma/branch/master?svg=true)](https://ci.appveyor.com/project/akanmuratcimen/args-mapper/branch/master) [![Coverage Status](https://coveralls.io/repos/github/akanmuratcimen/args-mapper/badge.svg?branch=master)](https://coveralls.io/github/akanmuratcimen/args-mapper?branch=master) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=akanmuratcimen_args-mapper&metric=alert_status)](https://sonarcloud.io/dashboard?id=akanmuratcimen_args-mapper) [![BotBuilder Badge](https://buildstats.info/nuget/args-mapper?dWidth=54&includePreReleases=true)](https://www.nuget.org/packages/args-mapper)

An easy to use, simple, strongly typed dotnet core command line parser.

## Introduction

- Compatible with .net core.
- No dependencies.
- Fluent command, option and usage page definitions.
- Supports all primitive types and its collection and nullable versions.
- Also supports enum, uri, datetime, timespan and guid types.
- Rich usage and introduction page building (includes table generator).
- Culture support for value conversion.
- Parsing error page customization support.
- Synchronous and asynchronous Execute method support
- Supports subcommands. (also known as nested commands.)
- Supports positional options. (for both single or collection values.)
- Supports for stacked options.
- Supports `-h|--help` and `-v|--version` options by default.

## Installation

Install the args-mapper nuget package into your project.

```
> Install-Package args-mapper -prerelease
```

## Quick Start

Define a class which is called `Args` in the example below that will hold the application commands and options and call the `Execute` method of the `ArgsMapper` class. 

```csharp
class Program
{
    class Args
    {
        public Command Command { get; set; }
    }

    class Command
    {
        public string Option { get; set; }
    }

    static void Main(string[] args)
    {
        var mapper = new ArgsMapper<Args>();

        mapper.AddCommand(x => x.Command, commandSettings => {
            commandSettings.AddOption(x => x.Option);
        });

        mapper.Execute(args, OnSuccess, OnError);
    }

    static void OnSuccess(Args args)
    {
        if (args.Command != null)
        {
            Console.WriteLine($"Command executed with '{args.Command.Option}' option.");
        }
    }

    static void OnError(ArgsMapperErrorResult errorResult)
    {
        Console.WriteLine(errorResult.ErrorMessage);
    }
}
```

Execution and output:

```
 > program command --option sample
 
 Command executed with 'sample' option.
```

## Samples  
There are [sample projects](https://github.com/akanmuratcimen/args-mapper/tree/master/samples) that you can look at.  

## License  
This project is licensed under the [MIT license](LICENSE).
