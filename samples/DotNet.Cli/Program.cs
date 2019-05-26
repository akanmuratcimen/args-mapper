using ArgsMapper;

namespace DotNet.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mapper = new ArgsMapper<Args>();

            mapper.AddOption(x => x.Info);
            mapper.AddOption(x => x.ListSdks);
            mapper.AddOption(x => x.ListRuntimes);

            Pages.ConfigureIntroductionPage(mapper.Introduction);

            mapper.Execute(args, OnExecute);
        }

        private static void OnExecute(Args args)
        {
        }
    }
}
