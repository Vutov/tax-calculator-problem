using System;
using System.Threading.Tasks;
using Enterprise.Contracts;
using Enterprise.Models;
using Enterprise.Repository.Interfaces;
using Enterprise.Services;
using Enterprise.Services.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace Enterprise
{
    public class Startup
    {
        private readonly IServiceProvider serviceProvider;

        public Startup(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task Run()
        {
            var salary = new Salary() { Value = double.Parse(Console.ReadLine() ?? "3400") };
            if (salary.Value <= 0)
            {
                Console.WriteLine("Invalid salary");
                return;
            }

            var repository = this.serviceProvider.GetService<IRepository<ConfigEntity>>();
            var config = await repository.Get();
            var tax = new RuleEngine(new TaxRule(config), new SocialRule(config)).GetTax(salary);
            Console.WriteLine($"{salary.Value} => {salary.Value - tax}");
        }
    }
}