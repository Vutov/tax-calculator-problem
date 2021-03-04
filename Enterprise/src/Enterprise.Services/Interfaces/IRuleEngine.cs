using Enterprise.Contracts;

namespace Enterprise.Services.Interfaces
{
    public interface IRuleEngine
    {
        public double GetTax(Salary salary);
    }
}