using System;
using System.Collections.Generic;
using System.Linq;
using ArgsMapper;

namespace SubcommandSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mapper = new ArgsMapper<Args>();

            mapper.AddCommand(x => x.Math, commandSettings => {
                commandSettings.AddSubcommand(x => x.Sum, subcommandSettings => {
                    subcommandSettings.AddPositionalOption(x => x.Values, optionSettings => {
                        optionSettings.DefaultValue = new List<int>();
                    });
                });

                commandSettings.AddSubcommand(x => x.Pow, subcommandSettings => {
                    subcommandSettings.ShowUsageWhenEmptyOptions = true;

                    subcommandSettings.AddPositionalOption(x => x.X);
                    subcommandSettings.AddPositionalOption(x => x.Y);

                    subcommandSettings.Usage.AddText("Usage: math pow <x> <y>");
                    subcommandSettings.Usage.AddEmptyLine();

                    subcommandSettings.Usage.AddText("Returns a specified number raised to the specified power.");
                    subcommandSettings.Usage.AddEmptyLine();

                    subcommandSettings.Usage.AddSection("Options:", sectionSettings => {
                        sectionSettings.AddOption(x => x.X, optionSettings => {
                            optionSettings.Description = "A double-precision " +
                                "floating-point number to be raised to a power.";
                        });

                        sectionSettings.AddOption(x => x.Y, optionSettings => {
                            optionSettings.Description = "A double-precision " +
                                "floating-point number that specifies a power.";
                        });
                    });

                    subcommandSettings.Usage.AddSection("Examples:", sectionSettings => {
                        sectionSettings.AddTable(
                            ("x", "y", "result"),
                            ("2", "1", "2"),
                            ("2", "2", "4"),
                            ("2", "3", "8"),
                            ("2", "4", "16"),
                            ("2", "5", "32"),
                            ("2", "6", "64"),
                            ("2", "7", "128")
                        );
                    });
                });

                commandSettings.AddSubcommand(x => x.Min, subcommandSettings => {
                    subcommandSettings.AddPositionalOption(x => x.X);
                    subcommandSettings.AddPositionalOption(x => x.Y);
                });

                commandSettings.AddSubcommand(x => x.Max, subcommandSettings => {
                    subcommandSettings.AddPositionalOption(x => x.X);
                    subcommandSettings.AddPositionalOption(x => x.Y);
                });
            });

            mapper.Execute(args, OnSuccess);
        }

        private static void OnSuccess(Args args)
        {
            if (args.Math == null)
            {
                return;
            }

            if (args.Math.Sum != null)
            {
                Console.WriteLine($"Sum result: {args.Math.Sum.Values.Sum()}");

                return;
            }

            if (args.Math.Pow != null)
            {
                Console.WriteLine($"Pow result: {System.Math.Pow(args.Math.Pow.X, args.Math.Pow.Y)}");

                return;
            }

            if (args.Math.Min != null)
            {
                Console.WriteLine($"Min result: {System.Math.Min(args.Math.Min.X, args.Math.Min.Y)}");

                return;
            }

            if (args.Math.Max != null)
            {
                Console.WriteLine($"Max result: {System.Math.Max(args.Math.Max.X, args.Math.Max.Y)}");
            }
        }
    }
}
