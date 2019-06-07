using System.Collections.Generic;

namespace SubcommandSample
{
    internal class Args
    {
        public Math Math { get; set; }
    }

    public class Math
    {
        public Sum Sum { get; set; }
        public Pow Pow { get; set; }
        public Max Max { get; set; }
        public Min Min { get; set; }
    }

    public class Sum
    {
        public IEnumerable<int> Values { get; set; }
    }

    public class Pow
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Max
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Min
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
