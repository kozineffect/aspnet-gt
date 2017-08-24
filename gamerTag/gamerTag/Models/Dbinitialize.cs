using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace gamerTag.Models
{
    public static class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new MyDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyDbContext>>());
            context.Database.EnsureCreated();
        }
    }
}