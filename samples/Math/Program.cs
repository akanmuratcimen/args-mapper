using System;
using ArgsMapper;

namespace Math
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mapper = new ArgsMapper<Args>();

            mapper.AddCommand(x => x.Sum, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Number1);
                commandSettings.AddPositionalOption(x => x.Number2);
            });

            mapper.AddCommand(x => x.Multiply, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Number1);
                commandSettings.AddPositionalOption(x => x.Number2);
            });

            mapper.AddCommand(x => x.Divide, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Number1);
                commandSettings.AddPositionalOption(x => x.Number2);
            });

            mapper.AddCommand(x => x.Subtract, commandSettings => {
                commandSettings.AddPositionalOption(x => x.Number1);
                commandSettings.AddPositionalOption(x => x.Number2);
            });

            mapper.Usage.AddText("usage: [command] <x> <y>");
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
                    commandSettings.Description = "divides the give values.";
                });

                sectionSettings.AddCommand(x => x.Subtract, commandSettings => {
                    commandSettings.NameColumnWidth = nameColumnWidth;
                    commandSettings.Description = "subtracts the given values.";
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
                Console.WriteLine("Sum of the values is: " +
                    (args.Sum.Number1 + args.Sum.Number2));

                return;
            }

            if (args.Multiply != null)
            {
                Console.WriteLine("Multiply of the values is: " +
                    args.Multiply.Number1 * args.Multiply.Number2);

                return;
            }

            if (args.Divide != null)
            {
                Console.WriteLine("Divide of the values is: " +
                    (double)args.Divide.Number1 / args.Divide.Number2);

                return;
            }

            if (args.Subtract != null)
            {
                Console.WriteLine("Subtract of the values is: " +
                    (args.Subtract.Number1 - args.Subtract.Number2));
            }
        }
    }
}
