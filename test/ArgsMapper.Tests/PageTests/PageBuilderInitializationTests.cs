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

namespace ArgsMapper.Tests.PageTests
{
    public class PageBuilderInitializationTests
    {
        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddOption_In_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option);

                commandSettings.Usage.AddSection("header", section => {
                    section.AddOption(x => x.Option);
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddOption_With_Description_In_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option);

                commandSettings.Usage.AddSection("header", section => {
                    section.AddOption(x => x.Option, "option description");
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_2_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(("column1", "column2"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_3_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(("column1", "column2", "column3"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_4_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(("column1", "column2", "column3", "column4"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_5_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(("column1", "column2", "column3", "column4", "column5"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_6_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(("column1", "column2", "column3", "column4", "column5", "column6"));
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_With_Rows_2_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(
                        ("column1", "column2"),
                        ("value1", "value2")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_With_Rows_3_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(
                        ("column1", "column2", "column3"),
                        ("value1", "value2", "value3")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_With_Rows_4_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(
                        ("column1", "column2", "column3", "column4"),
                        ("value1", "value2", "value3", "value4")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_With_Rows_5_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(
                        ("column1", "column2", "column3", "column4", "column5"),
                        ("value1", "value2", "value3", "value4", "value5")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddTable_With_Rows_6_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddTable(
                        ("column1", "column2", "column3", "column4", "column5", "column6"),
                        ("value1", "value2", "value3", "value4", "value5", "value6")
                    );
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddText()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddText("content");
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddText_Multiple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddText("content", "content");
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_2_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(("column1", "column2"));
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_3_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(("column1", "column2", "column3"));
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_4_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(("column1", "column2", "column3", "column4"));
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_5_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(("column1", "column2", "column3", "column4", "column5"));
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_6_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(("column1", "column2", "column3", "column4", "column5", "column6"));
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_Multiple_5_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(
                    ("column1", "column2", "column3", "column4", "column5"),
                    ("value1", "value2", "value3", "value4", "value5")
                );
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_With_Rows_2_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(
                    ("column1", "column2"),
                    ("value1", "value2")
                );
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_With_Rows_3_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(
                    ("column1", "column2", "column3"),
                    ("value1", "value2", "value3")
                );
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_With_Rows_4_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(
                    ("column1", "column2", "column3", "column4"),
                    ("value1", "value2", "value3", "value4")
                );
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddTable_With_Rows_6_Columns()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddTable(
                    ("column1", "column2", "column3", "column4", "column5", "column6"),
                    ("value1", "value2", "value3", "value4", "value5", "value6")
                );
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddText()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddText("content");
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddText_Multiple()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddText("content", "content");
            });
        }

        [Fact]
        internal void Usage_AddSection_AddCommand_In_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command);

            mapper.Usage.AddSection("header", section => {
                section.AddCommand(x => x.Command);
            });
        }

        [Fact]
        internal void Usage_AddSection_AddOption_In_Settings()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);

            mapper.Usage.AddSection("header", section => {
                section.AddOption(x => x.Option);
            });
        }

        [Fact]
        internal void Usage_AddSection_AddOption_With_Description_In_Settings()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);

            mapper.Usage.AddSection("header", section => {
                section.AddOption(x => x.Option, "option description");
            });
        }

        [Fact]
        internal void Usage_AddSection_AddTable_3_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddTable(("column1", "column2", "column3"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddTable_4_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddTable(("column1", "column2", "column3", "column4"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddTable_5_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddTable(("column1", "column2", "column3", "column4", "column5"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddTable_6_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddTable(("column1", "column2", "column3", "column4", "column5", "column6"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddText()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddText("content");
            });
        }

        [Fact]
        internal void Usage_AddSection_AddText_2_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddTable(("column1", "column2"));
            });
        }

        [Fact]
        internal void Usage_AddSection_AddText_Multiple()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddText("content", "content");
            });
        }

        [Fact]
        internal void Usage_AddTable_2_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(("column1", "column2"));
        }

        [Fact]
        internal void Usage_AddTable_3_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(("column1", "column2", "column3"));
        }

        [Fact]
        internal void Usage_AddTable_4_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(("column1", "column2", "column3", "column4"));
        }

        [Fact]
        internal void Usage_AddTable_5_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(("column1", "column2", "column3", "column4", "column5"));
        }

        [Fact]
        internal void Usage_AddTable_6_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(("column1", "column2", "column3", "column4", "column5", "column6"));
        }

        [Fact]
        internal void Usage_AddTable_With_Rows_2_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(
                ("column1", "column2"),
                ("value1", "value2")
            );
        }

        [Fact]
        internal void Usage_AddTable_With_Rows_3_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(
                ("column1", "column2", "column3"),
                ("value1", "value2", "value3")
            );
        }

        [Fact]
        internal void Usage_AddTable_With_Rows_4_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(
                ("column1", "column2", "column3", "column4"),
                ("value1", "value2", "value3", "value4")
            );
        }

        [Fact]
        internal void Usage_AddTable_With_Rows_5_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(
                ("column1", "column2", "column3", "column4", "column5"),
                ("value1", "value2", "value3", "value4", "value5")
            );
        }

        [Fact]
        internal void Usage_AddTable_With_Rows_6_Columns()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddTable(
                ("column1", "column2", "column3", "column4", "column5", "column6"),
                ("value1", "value2", "value3", "value4", "value5", "value6")
            );
        }

        [Fact]
        internal void Usage_AddText()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddText("content");
        }

        [Fact]
        internal void Usage_AddText_Multiple_String()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddText("content", "content");
        }
    }
}
