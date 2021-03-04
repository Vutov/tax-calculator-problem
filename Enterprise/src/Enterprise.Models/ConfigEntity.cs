namespace Enterprise.Models
{
    public class ConfigEntity : Entity
    {
        public double MinTaxAmount { get; set; }

        public double TaxPercentage { get; set; }

        public double MaxSocialAmount { get; set; }

        public double SocialPercentage { get; set; }
    }
}