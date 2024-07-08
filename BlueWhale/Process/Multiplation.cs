using Calculator_With_SOLID_Principles.Interfaces;

namespace Calculator_With_SOLID_Principles.BlueWhale.Process
{
    public class Multiplation : IOperation
    {
        public double Calculate(double x, double y) => x * y;
    }
}
