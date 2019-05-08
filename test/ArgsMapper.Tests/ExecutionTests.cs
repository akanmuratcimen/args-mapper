using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgsMapper.Tests
{
    public class ExecutionTests
    {
        [Fact]
        internal void Execute_Should_Write_Error_Text()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            // Act
            mapper.Execute(new[] { "--option" }, null);

            Assert.Equal("Unknown option 'option'.", output.ToString());
        }

        [Fact]
        internal async Task ExecuteAsync_Usage()
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);

            var result = false;

            // Act
            await mapper.ExecuteAsync(new[] { "--option" }, args => {
                result = args.Option;
            });

            // Assert
            Assert.True(result);
        }
    }
}
