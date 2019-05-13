// The MIT License (MIT)
// 
// Copyright (c) 2019 Akan Murat Cimen
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using Xunit;

namespace ArgsMapper.Tests.UsageTests
{
    public class UsageInitializationTests
    {
        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_2_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(("column1", "column2"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_3_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(("column1", "column2", "column3"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_4_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(("column1", "column2", "column3", "column4"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_5_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(("column1", "column2", "column3", "column4", "column5"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_6_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(("column1", "column2", "column3", "column4", "column5", "column6"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_Multiple_2_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(
                        ("column1", "column2"),
                        ("column1", "column2")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_Multiple_3_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(
                        ("column1", "column2", "column3"),
                        ("column1", "column2", "column3")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_Multiple_4_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(
                        ("column1", "column2", "column3", "column4"),
                        ("column1", "column2", "column3", "column4")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_Multiple_5_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(
                        ("column1", "column2", "column3", "column4", "column5"),
                        ("column1", "column2", "column3", "column4", "column5")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_Multiple_6_Tuple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent(
                        ("column1", "column2", "column3", "column4", "column5", "column6"),
                        ("column1", "column2", "column3", "column4", "column5", "column6")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_Multiple_String()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent("content", "content");
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddContent_String()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddContent("content");
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddOption_In_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddOption(x => x.Option);
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_MaxWidth_In_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.MaxWidth = 80;
                });
            });
        }

        [Fact]
        internal void Usage_AddContent_2_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(("column1", "column2"));
        }

        [Fact]
        internal void Usage_AddContent_3_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(("column1", "column2", "column3"));
        }

        [Fact]
        internal void Usage_AddContent_4_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(("column1", "column2", "column3", "column4"));
        }

        [Fact]
        internal void Usage_AddContent_5_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(("column1", "column2", "column3", "column4", "column5"));
        }

        [Fact]
        internal void Usage_AddContent_6_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(("column1", "column2", "column3", "column4", "column5", "column6"));
        }

        [Fact]
        internal void Usage_AddContent_Multiple_2_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(
                ("column1", "column2"),
                ("column1", "column2")
            );
        }

        [Fact]
        internal void Usage_AddContent_Multiple_3_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(
                ("column1", "column2", "column3"),
                ("column1", "column2", "column3")
            );
        }

        [Fact]
        internal void Usage_AddContent_Multiple_4_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(
                ("column1", "column2", "column3", "column4"),
                ("column1", "column2", "column3", "column4")
            );
        }

        [Fact]
        internal void Usage_AddContent_Multiple_5_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(
                ("column1", "column2", "column3", "column4", "column5"),
                ("column1", "column2", "column3", "column4", "column5")
            );
        }

        [Fact]
        internal void Usage_AddContent_Multiple_6_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent(
                ("column1", "column2", "column3", "column4", "column5", "column6"),
                ("column1", "column2", "column3", "column4", "column5", "column6")
            );
        }

        [Fact]
        internal void Usage_AddContent_Multiple_String()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent("content", "content");
        }

        [Fact]
        internal void Usage_AddContent_String()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddContent("content");
        }

        [Fact]
        internal void Usage_AddSection_AddCommand_In_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddCommand(x => x.Command);
            });
        }

        [Fact]
        internal void Usage_AddSection_AddContent_2_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddContent(("column1", "column2"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddContent_3_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddContent(("column1", "column2", "column3"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddContent_4_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddContent(("column1", "column2", "column3", "column4"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddContent_5_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddContent(("column1", "column2", "column3", "column4", "column5"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddContent_6_Tuple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddContent(("column1", "column2", "column3", "column4", "column5", "column6"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddContent_Multiple_String()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddContent("content", "content");
            });
        }

        [Fact]
        internal void Usage_AddSection_AddContent_String()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddContent("content");
            });
        }

        [Fact]
        internal void Usage_AddSection_AddOption_In_Settings()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddOption(x => x.Option);
            });
        }

        [Fact]
        internal void Usage_AddSection_MaxWidth_In_Settings()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.MaxWidth = 80;
            });
        }
    }
}
