using ArgsMapper.PageBuilding;

namespace DotNet.Cli
{
    internal class Pages
    {
        internal static void ConfigureIntroductionPage(IMainPageBuilder<Args> introduction)
        {
            introduction.AddEmptyLine();

            introduction.AddText("Usage: dotnet [options]");
            introduction.AddText("Usage: dotnet [path-to-application]");

            introduction.AddEmptyLine();

            introduction.AddSection("Options:", sectionSettings => {
                const int columnWidth = 16;

                sectionSettings.AddHelpOption(optionSettings => {
                    optionSettings.Description = "Display help.";
                    optionSettings.NameColumnWidth = columnWidth;
                });

                sectionSettings.AddOption(x => x.Info, optionSettings => {
                    optionSettings.Description = "Display .NET Core information.";
                    optionSettings.NameColumnWidth = columnWidth;
                });

                sectionSettings.AddOption(x => x.ListSdks, optionSettings => {
                    optionSettings.Description = "Display the installed SDKs.";
                    optionSettings.NameColumnWidth = columnWidth;
                });

                sectionSettings.AddOption(x => x.ListRuntimes, optionSettings => {
                    optionSettings.Description = "Display the installed runtimes.";
                    optionSettings.NameColumnWidth = columnWidth;
                });
            });

            introduction.AddSection("path-to-application:", sectionSettings => {
                sectionSettings.AddText("The path to an application .dll file to execute.");
            });
        }
    }
}
