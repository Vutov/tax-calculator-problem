using System.Linq;
using Enterprise.Contracts;
using Enterprise.Services.Interfaces;

namespace Enterprise.Services
{
    public class RuleEngine : IRuleEngine
    {
        private readonly IRule[] rules;

        public RuleEngine(params IRule[] rules)
        {
            this.rules = rules;
        }

        public double GetTax(Salary salary)
        {
            return this.rules.Sum(rule => rule.GetTax(salary.Value));
        }
    }
}