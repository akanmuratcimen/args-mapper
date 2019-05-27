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

using System.Collections.Generic;
using System.Linq;
using ArgsMapper.Utilities;

namespace ArgsMapper.PageBuilding
{
    internal class PageRenderer : IPageRenderer
    {
        private readonly IList<PageContent> _contents;
        private readonly IPageContentFormatter _pageContentFormatter;

        public PageRenderer()
        {
            _contents = new List<PageContent>();
            _pageContentFormatter = new PageContentFormatter(_contents);
        }

        public void AppendText(PageContentRowFormattingStyle style,
            params string[] contents)
        {
            foreach (var content in contents)
            {
                _contents.Add(new PageContent {
                    ColumnSize = 1,
                    Style = style,
                    Values = new[] {
                        new[] {
                            content
                        }
                    }
                });
            }
        }

        public void AppendTable(PageContentRowFormattingStyle style,
            (string, string) columns,
            params (string, string)[] rows)
        {
            _contents.Add(new PageContent {
                ColumnSize = 2,
                Style = style,
                Values = columns.Merge(rows).Select(x => new[] {
                    x.Item1, x.Item2
                })
            });
        }

        public void AppendTable(PageContentRowFormattingStyle style,
            (string, string, string) columns,
            params (string, string, string)[] rows)
        {
            _contents.Add(new PageContent {
                ColumnSize = 3,
                Style = style,
                Values = columns.Merge(rows).Select(x => new[] {
                    x.Item1, x.Item2, x.Item3
                })
            });
        }

        public void AppendTable(PageContentRowFormattingStyle style,
            (string, string, string, string) columns,
            params (string, string, string, string)[] rows)
        {
            _contents.Add(new PageContent {
                ColumnSize = 4,
                Style = style,
                Values = columns.Merge(rows).Select(x => new[] {
                    x.Item1, x.Item2, x.Item3, x.Item4
                })
            });
        }

        public void AppendTable(PageContentRowFormattingStyle style,
            (string, string, string, string, string) columns,
            params (string, string, string, string, string)[] rows)
        {
            _contents.Add(new PageContent {
                ColumnSize = 5,
                Style = style,
                Values = columns.Merge(rows).Select(x => new[] {
                    x.Item1, x.Item2, x.Item3, x.Item4, x.Item5
                })
            });
        }

        public void AppendTable(PageContentRowFormattingStyle style,
            (string, string, string, string, string, string) columns,
            params (string, string, string, string, string, string)[] rows)
        {
            _contents.Add(new PageContent {
                ColumnSize = 6,
                Style = style,
                Values = columns.Merge(rows).Select(x => new[] {
                    x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6
                })
            });
        }

        public void AppendOption(PageContentRowFormattingStyle style,
            string name, PageContentOptionSettings settings)
        {
            _contents.Add(new PageContent {
                ColumnSize = 2,
                Style = style,
                ColumnSettings = new[] {
                    new PageContentColumnSettings {
                        Width = settings?.NameColumnWidth ?? 0
                    }
                },
                Values = new[] {
                    new[] {
                        name, settings?.Description
                    }
                }
            });
        }

        public void AppendCommand(PageContentRowFormattingStyle style,
            string name, PageContentCommandSettings settings)
        {
            _contents.Add(new PageContent {
                ColumnSize = 2,
                Style = style,
                ColumnSettings = new[] {
                    new PageContentColumnSettings {
                        Width = settings?.NameColumnWidth ?? 0
                    }
                },
                Values = new[] {
                    new[] {
                        name, settings?.Description
                    }
                }
            });
        }

        public override string ToString()
        {
            return _pageContentFormatter.ToString();
        }

        public void AppendSection(string header, string sectionString)
        {
            _contents.Add(new PageContent {
                ColumnSize = 1,
                Style = PageContentRowFormattingStyle.None,
                Values = new[] {
                    new[] {
                        header
                    }
                }
            });

            _contents.Add(new PageContent {
                ColumnSize = 1,
                Style = PageContentRowFormattingStyle.None,
                Values = new[] {
                    new[] {
                        sectionString
                    }
                }
            });
        }
    }
}
