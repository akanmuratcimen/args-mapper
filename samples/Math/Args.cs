using System.Collections.Generic;

namespace Math
{
    internal class Args
    {
        public Sum Sum { get; set; }
        public Multiply Multiply { get; set; }
        public Divide Divide { get; set; }
        public Subtract Subtract { get; set; }
    }

    internal class Sum
    {
        public List<int> Values { get; set; }
    }

    internal class Multiply
    {
        public List<int> Values { get; set; }
    }

    internal class Divide
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    internal class Subtract
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
