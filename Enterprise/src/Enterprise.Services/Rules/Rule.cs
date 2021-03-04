using Enterprise.Models;
using Enterprise.Services.Interfaces;

namespace Enterprise.Services.Rules
{
    public abstract class Rule : IRule
    {
        protected Rule(ConfigEntity config)
        {
            this.Config = config;
        }

        protected ConfigEntity Config { get; }
        
        public abstract double GetTax(double value);
    }
}