using Calculator_With_SOLID_Principles.Interfaces;

namespace Calculator_With_SOLID_Principles.BlueWhale.Process
{
    public class Division : IOperation
    {
        public double Calculate(double x, double y)
        {
            if (y == 0) throw new DivideByZeroException();
            return x / y;
        }
    }
}
