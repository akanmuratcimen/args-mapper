namespace Math
{
    internal class Args
    {
        public ValuePair Sum { get; set; }
        public ValuePair Multiply { get; set; }
        public ValuePair Divide { get; set; }
        public ValuePair Subtract { get; set; }

        public class ValuePair
        {
            public int Number1 { get; set; }
            public int Number2 { get; set; }
        }
    }
}
