using Enterprise.Models;

namespace Enterprise.Repository.Context
{
    public class Context
    {
        // Imagine we run EF and this is stored in DB :)
        public ConfigEntity TaxConfig { get; set; } = new ConfigEntity()
        {
            MinTaxAmount = 1000,
            MaxSocialAmount = 3000,
            TaxPercentage = 0.1,
            SocialPercentage = 0.15,
        };
    }
}