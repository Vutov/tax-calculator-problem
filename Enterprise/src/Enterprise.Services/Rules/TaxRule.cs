using Enterprise.Models;

namespace Enterprise.Services.Rules
{
    public class TaxRule : Rule
    {
        public TaxRule(ConfigEntity config)
            : base(config)
        {
        }

        public override double GetTax(double value)
        {
            if (value <= this.Config.MinTaxAmount)
            {
                return 0;
            }

            return (value - this.Config.MinTaxAmount) * this.Config.TaxPercentage;
        }
    }
}