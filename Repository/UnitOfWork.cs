// here in this class we are implementing the Unit of Work pattern with the help of
// a generic repository
// This class will coordinate the work of multiple repositories
// It will ensure that all changes are saved to the database in a single transaction
// This helps to maintain data integrity and consistency

using RepoDemo.Api.Data;
using RepoDemo.Api.Models;
using RepoDemo.Api.Repository.Interfaces;
namespace RepoDemo.Api.Repository
{
    public class UnitOfWork : IUnitOfWork// here IUnit of work is defined in previouys interface.
    {
        private readonly AppDbContext _context;
        private readonly IGenericRepository<WeatherForecast> _weatherForecastRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _weatherForecastRepository = new GenericRepository<WeatherForecast>(_context);
        }
        // public IGenericRepository<WeatherForecast> WeatherForecasts => _weatherForecastRepository;
        public IGenericRepository<Product> Products => new GenericRepository<Product>(_context);
        // userdefined entity types
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Implement IDisposable
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}