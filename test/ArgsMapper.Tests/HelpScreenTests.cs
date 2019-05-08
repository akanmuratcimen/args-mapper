using Xunit;

namespace ArgsMapper.Tests
{
    public class HelpScreenTests
    {
        [Fact]
        internal void Usage()
        {
            // Arrange
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.Usage.AddSection("Section 1 Header", x => {
                x.MaxWidth = 60;

                x.Content = new[] {
                    ("c1", "c2", "c3")
                };

                x.AddCommand(c => c.Command);

                x.AddOption(o => o.Command.Option, true);

                x.AddExample("sample example", args => {
                    args.Command.Option = true;
                });
            });

            mapper.AddCommand(x => x.Command, "command", commandSettings => {
                commandSettings.UsageText = "command usage description";

                commandSettings.AddOption(x => x.Option, optionSettings => {
                    optionSettings.UsageText = "option usage description";
                });
            });
        }
    }
}
