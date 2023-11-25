namespace Lab2.Models
{
    public enum Operators
    {
        ADD, SUB, MUL, DIV
    }

    public class CalculatorViewModel
    {
        public Operators? Operator { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public string Op
        {
            get
            {
                switch (Operator)
                {
                    case Operators.ADD:
                        return "+";
                    case Operators.SUB:
                        return "-";
                    case Operators.MUL:
                        return "*";
                    case Operators.DIV:
                        return "/";
                    default:
                        return "";
                }
            }
        }

        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        public double Calculate()
        {
            switch (Operator)
            {
                case Operators.ADD:
                    return (double)(X + Y);
                    break;
                case Operators.SUB:
                    return (double)(X - Y);
                    break;
                case Operators.MUL:
                    return (double)(X * Y);
                    break;
                case Operators.DIV:
                    return (double)(X / Y);
                    break;
                default: return double.NaN;
            }
        }
    }
}
