using Calculator_With_SOLID_Principles.Interfaces;
using System.Reflection;

namespace Calculator_With_SOLID_Principles.BlueWhale.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IServiceProvider _serviceProvider;

        public CalculatorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public double PerformOperation(string operation, double x, double y)
        {
            var operationType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == operation && typeof(IOperation).IsAssignableFrom(t));

            if (operationType == null)
            {
                throw new InvalidOperationException("Invalid operation");
            }

            var operationInstance = _serviceProvider.GetService(operationType) as IOperation;
           

            return operationInstance?.Calculate(x, y) ?? throw new InvalidOperationException("Invalid operation");
        }

    }

}
