using System;
using ArgsMapper;

namespace Basic
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var mapper = new ArgsMapper<Args>();

            mapper.AddCommand(x => x.AddUser, commandSettings => {
                commandSettings.AddOption(x => x.Username);
                commandSettings.AddOption(x => x.Password);
            });

            mapper.Execute(args, OnExecute);
        }

        private static void OnExecute(Args args)
        {
            if (args.AddUser != null)
            {
                Console.WriteLine($"User created with '{args.AddUser.Username}' " +
                    $"username and '{args.AddUser.Password}' password.");
            }
        }
    }
}
