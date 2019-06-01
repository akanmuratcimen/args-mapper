using System;
using System.Linq;
using ArgsMapper;

namespace Math
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mapper = new ArgsMapper<Args>();

            mapper.AddCommand(x => x.Sum, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Values);
            });

            mapper.AddCommand(x => x.Multiply, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Values, optionSettings => {
                    optionSettings.IsRequired = true;
                });
            });

            mapper.AddCommand(x => x.Divide, commandSettings => {
                commandSettings.AddPositionalOption(x => x.X);
                commandSettings.AddPositionalOption(x => x.Y);
            });

            mapper.AddCommand(x => x.Subtract, commandSettings => {
                commandSettings.AddPositionalOption(x => x.X);
                commandSettings.AddPositionalOption(x => x.Y);
            });

            mapper.Usage.AddText("usage: [sum] <x>...");
            mapper.Usage.AddText("usage: [multiply] <x>...");
            mapper.Usage.AddText("usage: [divide] <x> <y>");
            mapper.Usage.AddText("usage: [subtract] <x> <y>");

            mapper.Usage.AddEmptyLine();

            mapper.Usage.AddSection("commands:", sectionSettings => {
                const int nameColumnWidth = 9;

                sectionSettings.AddCommand(x => x.Sum, commandSettings => {
                    commandSettings.NameColumnWidth = nameColumnWidth;
                    commandSettings.Description = "sums the given values.";
                });

                sectionSettings.AddCommand(x => x.Multiply, commandSettings => {
                    commandSettings.NameColumnWidth = nameColumnWidth;
                    commandSettings.Description = "multiplies the given values.";
                });

                sectionSettings.AddCommand(x => x.Divide, commandSettings => {
                    commandSettings.NameColumnWidth = nameColumnWidth;
                    commandSettings.Description = "divides the given two values.";
                });

                sectionSettings.AddCommand(x => x.Subtract, commandSettings => {
                    commandSettings.NameColumnWidth = nameColumnWidth;
                    commandSettings.Description = "subtracts the given two values.";
                });
            });

            mapper.Usage.AddHelpOption(optionSettings => {
                optionSettings.NameColumnWidth = 11;
                optionSettings.Description = "display help.";
            });

            mapper.Execute(args, OnSuccess);
        }

        private static void OnSuccess(Args args)
        {
            if (args.Sum != null)
            {
                Console.WriteLine($"Sum of the values is: {args.Sum.Values.Sum()}");

                return;
            }

            if (args.Multiply != null)
            {
                Console.WriteLine($"Multiply of the values is: {args.Multiply.Values.Aggregate((i, x) => i * x)}");

                return;
            }

            if (args.Divide != null)
            {
                Console.WriteLine($"Divide of the values is: {(double)args.Divide.X / args.Divide.Y}");

                return;
            }

            if (args.Subtract != null)
            {
                Console.WriteLine($"Subtract of the values is: {args.Subtract.X - args.Subtract.Y}");
            }
        }
    }
}
