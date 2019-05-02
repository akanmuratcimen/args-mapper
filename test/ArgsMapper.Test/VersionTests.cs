using System;
using System.IO;
using System.Text;
using Xunit;

namespace ArgsMapper.Test
{
    public class VersionTests
    {
        [Theory]
        [InlineData("-v")]
        [InlineData("--version")]
        internal void Output_Should_Be_1_0_0_0_Version_Text(params string[] args)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            mapper.Settings.DefaultWriter = new StringWriter(output);

            // Act
            mapper.Execute(args, null);

            // Assert
            Assert.Equal(new Version(1, 0, 0, 0).ToString(), output.ToString());
        }

        [Theory]
        [InlineData("-v")]
        [InlineData("--version")]
        internal void Output_Should_Be_Version_Text(params string[] args)
        {
            // Arrange
            var mapper = new ArgsMapper<OneBoolOptionArgs>();
            var output = new StringBuilder();

            var version = new Version(4, 3, 2, 1);

            mapper.Settings.DefaultWriter = new StringWriter(output);
            mapper.Settings.ApplicationVersion = version;

            // Act
            mapper.Execute(args, null);

            // Assert
            Assert.Equal(version.ToString(), output.ToString());
        }
    }
}
