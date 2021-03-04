using Enterprise.Models;

namespace Enterprise.Services.Rules
{
    public class SocialRule : Rule
    {
        public SocialRule(ConfigEntity config)
            : base(config)
        {
        }

        public override double GetTax(double value)
        {
            if (value <= this.Config.MinTaxAmount)
            {
                return 0;
            }

            var taxableAmount = value;
            if (value > this.Config.MaxSocialAmount)
            {
                taxableAmount = this.Config.MaxSocialAmount;
            }

            return (taxableAmount - this.Config.MinTaxAmount) * this.Config.SocialPercentage;
        }
    }
}