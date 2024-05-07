using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Domain.Models.CompanyAggregate;
using PrimeiraAPI.Domain.Models.EmployeeAggregate;

namespace PrimeiraAPI.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Company { get; set; }

        private IConfiguration _configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            "Server=./;Database=employee_sample;User Id=sa;Password=Xbox720v8@; TrustServerCertificate=True"
                );
    }
}
