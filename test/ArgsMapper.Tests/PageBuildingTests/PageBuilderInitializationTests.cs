/**
 * The MIT License (MIT)
 * 
 * Copyright (c) 2019 Akan Murat Cimen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
 * the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using Xunit;

namespace ArgsMapper.Tests.PageBuildingTests
{
    public class PageBuilderInitializationTests
    {
        [Fact]
        internal void Usage_AddCommand_AddSubCommand_Usage_AddEmptyLine()
        {
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.Usage.AddEmptyLine();
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_AddSubCommand_Usage_AddHelpOption()
        {
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.Usage.AddHelpOption();
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_AddSubCommand_Usage_AddSection_AddCommand()
        {
            var mapper = new ArgsMapper<ThreeLevelNestedCommandArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.AddSubcommand(x => x.Command);

                    subcommandSettings.Usage.AddSection("header", section => {
                        section.AddSubcommand(x => x.Command);
                    });
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_AddSubCommand_Usage_AddSection_AddEmptyLine()
        {
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.Usage.AddSection("header", section => {
                        section.AddEmptyLine();
                    });
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_AddSubCommand_Usage_AddSection_AddHelpOption()
        {
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.Usage.AddSection("header", section => {
                        section.AddHelpOption();
                    });
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_AddSubCommand_Usage_AddSection_AddHelpOption_With_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.Usage.AddSection("header", section => {
                        section.AddHelpOption(settings => { });
                    });
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_AddSubCommand_Usage_AddSection_AddOption()
        {
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.AddOption(x => x.Option);

                    subcommandSettings.Usage.AddSection("header", section => {
                        section.AddOption(x => x.Option);
                    });
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_AddSubCommand_Usage_AddSection_AddOption_With_Its_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneClassWithOneBoolOption>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddSubcommand(x => x.Command, subcommandSettings => {
                    subcommandSettings.AddOption(x => x.Option);

                    subcommandSettings.Usage.AddSection("header", section => {
                        section.AddOption(x => x.Option, contentOptionSettings => {
                            contentOptionSettings.Description = "option description";
                            contentOptionSettings.NameColumnWidth = 20;
                        });
                    });
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddEmptyLine()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddEmptyLine();
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddHelpOption()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddHelpOption();
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddEmptyLine()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddEmptyLine();
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddHelpOption()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddHelpOption();
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddHelpOption_With_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.Usage.AddSection("header", section => {
                    section.AddHelpOption(settings => { });
                });
            });
        }

        [Fact]
        internal void Usage_AddCommand_Usage_AddSection_AddOption()
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
        internal void Usage_AddCommand_Usage_AddSection_AddOption_With_Its_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command, commandSettings => {
                commandSettings.AddOption(x => x.Option);

                commandSettings.Usage.AddSection("header", section => {
                    section.AddOption(x => x.Option, contentOptionSettings => {
                        contentOptionSettings.Description = "option description";
                        contentOptionSettings.NameColumnWidth = 20;
                    });
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
        internal void Usage_AddEmptyLine()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.Usage.AddEmptyLine();
        }

        [Fact]
        internal void Usage_AddHelpOption()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddHelpOption();
        }

        [Fact]
        internal void Usage_AddHelpOption_With_Settings()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddHelpOption(settings => { });
        }

        [Fact]
        internal void Usage_AddSection_AddCommand()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command);

            mapper.Usage.AddSection("header", section => {
                section.AddCommand(x => x.Command);
            });
        }

        [Fact]
        internal void Usage_AddSection_AddCommand_With_Settings()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.AddCommand(x => x.Command);

            mapper.Usage.AddSection("header", section => {
                section.AddCommand(x => x.Command, commandSettings => {
                    commandSettings.Description = "sample command description.";
                });
            });
        }

        [Fact]
        internal void Usage_AddSection_AddEmptyLine()
        {
            var mapper = new ArgsMapper<OneCommandWithOneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddEmptyLine();
            });
        }

        [Fact]
        internal void Usage_AddSection_AddHelpOption()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddHelpOption();
            });
        }

        [Fact]
        internal void Usage_AddSection_AddHelpOption_With_Settings()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddHelpOption(settings => { });
            });
        }

        [Fact]
        internal void Usage_AddSection_AddOption()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);

            mapper.Usage.AddSection("header", section => {
                section.AddOption(x => x.Option);
            });
        }

        [Fact]
        internal void Usage_AddSection_AddOption_With_Its_Settings()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.AddOption(x => x.Option);

            mapper.Usage.AddSection("header", section => {
                section.AddOption(x => x.Option, contentOptionSettings => {
                    contentOptionSettings.Description = "option description";
                    contentOptionSettings.NameColumnWidth = 20;
                });
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
        internal void Usage_AddSection_AddVersionOption()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddVersionOption();
            });
        }

        [Fact]
        internal void Usage_AddSection_AddVersionOption_With_Settings()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddSection("header", section => {
                section.AddVersionOption(settings => { });
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

        [Fact]
        internal void Usage_AddVersionOption()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddVersionOption();
        }

        [Fact]
        internal void Usage_AddVersionOption_With_Settings()
        {
            var mapper = new ArgsMapper<OneBoolOptionArgs>();

            mapper.Usage.AddVersionOption(settings => { });
        }
    }
}
