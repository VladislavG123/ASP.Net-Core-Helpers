using System;
using System.Threading.Tasks;
using Data.Base;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    /// <summary>
    /// Database for application
    /// </summary>
    public class ApplicationDbContext : DbContextBase<ApplicationDbContext>, IApplicationDbContext, IAsyncDisposable
    {
        /// <inheritdoc />
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region System

        public DbSet<Log> Logs { get; set; }

        #endregion

        public override ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}