// UsageContent.cs
namespace ArgsMapper.Usage
{
    public class UsageContent
    {
        internal UsageContent(params string[] contents)
        {
            Contents = contents;
        }

        internal string[] Contents { get; set; }

        public static implicit operator UsageContent(string content)
        {
            return new UsageContent(content);
        }

        public static implicit operator UsageContent(string[] contents)
        {
            return new UsageContent(contents);
        }

        public static implicit operator UsageContent(
            (string column1, string column2)[] columns)
        {
            return new UsageContent();
        }

        public static implicit operator UsageContent(
            (string column1, string column2, string column3)[] columns)
        {
            return new UsageContent();
        }

        public static implicit operator UsageContent(
            (string column1, string column2, string column3, string column4)[] columns)
        {
            return new UsageContent();
        }

        public static implicit operator UsageContent(
            (string column1, string column2, string column3, string column4,
                string column5)[] columns)
        {
            return new UsageContent();
        }

        public static implicit operator UsageContent(
            (string column1, string column2, string column3, string column4,
                string column5, string column6)[] columns)
        {
            return new UsageContent();
        }
    }
}
