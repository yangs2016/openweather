using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Yang.Weather.DataAccess.Context;
using Yang.Weather.DataAccess.Config;
using System.Data.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Data;
using System.Linq.Expressions;

namespace Yang.Weather.DataAccess.Dao
{
    public class BaseDao : IDbContextFactory<WeatherContext>
    {
        private readonly IDataStoreConfigurationProvider _configurationProvider;

        private readonly WeatherContext _weatherContext;
        public BaseDao(IDataStoreConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
            _weatherContext = CreateDbContext(_configurationProvider.ConnectionString);
        } 

        public WeatherContext DbContext => _weatherContext;
        public static WeatherContext CreateDbContext(string connectionString)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder()
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(connectionString);

            return new WeatherContext(builder.Options);
        }

        public WeatherContext CreateDbContext()
        {
            return CreateDbContext(_configurationProvider.ConnectionString);
        }

        public int Create<TEntity>(TEntity entity) where TEntity : class
        {
            using WeatherContext context = CreateDbContext();
            context.Add<TEntity>(entity);
            return context.SaveChanges();
           
        }

        public int Update<TEntity>(TEntity entity) where TEntity : class
        {
            using WeatherContext context = CreateDbContext();
            context.Update<TEntity>(entity);
            return context.SaveChanges();
        }

        public TEntity? Find<TEntity>(int id) where TEntity : class
        {
            using WeatherContext context = CreateDbContext();
            var entity = context.Find<TEntity>(id);
            return entity;

        }
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            using WeatherContext context = CreateDbContext();
            
            context.Remove<TEntity>(entity);
            context.SaveChanges();
        }

        public void DeleteById<TEntity>(int id) where TEntity : class
        {
            using WeatherContext context = CreateDbContext();
            var existing =Find<TEntity>(id);
            if (existing!=null)
                Delete<TEntity>(existing);
        }

        public IReadOnlyCollection<TEntity>? FindMultiple<TEntity>(Expression<Func<TEntity, bool>> whereClause) where TEntity : class
        {
            using WeatherContext context = CreateDbContext();
            var result = context.Set<TEntity>()
                .AsQueryable()
                .Where(whereClause);
            
            return result.ToList();
        }

        public TEntity? FindSingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> whereClause) where TEntity : class
        {
            using WeatherContext context = CreateDbContext();
            var result = context.Set<TEntity>().SingleOrDefault(whereClause);
            return result;
        }

        public TEntity? FindFirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> whereClause) where TEntity : class
        {
            using WeatherContext context = CreateDbContext();
            var result = context.Set<TEntity>().FirstOrDefault(whereClause);
            return result;
        }
    }
}
